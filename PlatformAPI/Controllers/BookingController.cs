using System.Security.Claims;
using AutoMapper;
using BusinessObject;
using DataTransfer;
using DataTransfer.Request;
using DataTransfer.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;
    private readonly IAccountService _accountService;
    private readonly ITransactionService _transactionService;
    private readonly IMapper _mapper;
    private readonly ISlotService _slotService;
    private readonly IBookingDetailService _bookingDetailService;
    private readonly IBadmintonCourtService _badmintonCourtService;

    public BookingController(IBookingService bookingService, IAccountService accountService,
        IMapper mapper, ITransactionService transactionService, ISlotService slotService,
        IBookingDetailService bookingDetailService, IBadmintonCourtService badmintonCourtService)
    {
        _bookingService = bookingService;
        _accountService = accountService;
        _mapper = mapper;
        _transactionService = transactionService;
        _slotService = slotService;
        _bookingDetailService = bookingDetailService;
        _badmintonCourtService = badmintonCourtService;
    }

    [HttpGet("get-all-bookings")]
    public async Task<IActionResult> GetAllBookings()
    {
        var bookings = await _bookingService.GetAllBookings();
        var bookingResponses = _mapper.Map<List<BookingResponse>>(bookings);
        for (int i = 0; i < bookingResponses.Count; i++)
        {
            var userBooking = await _accountService.GetAccount(bookings[i].AccountId);
            bookingResponses[i].UserName = userBooking.FullName;
        }
        if (bookings.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all bookings successful!", 
                Data = bookingResponses
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!",
            Data = null
        });
    }

    [HttpPost("create-booking")]
    [Authorize]
    public async Task<IActionResult> CreateBookingForPlayer(CreateBookingRequest request)
    {
        try
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("UserId").Value;
            var account = await _accountService.GetAccount(Int32.Parse(userId));
            var booking = await _bookingService.AddNewBookingAsync(new Booking()
            {
                Price = request.PriceTotal,
                AccountId = Int32.Parse(userId),
                BadmintonCourtId = request.BadmintonCourtId,
                BookingStatusId = 2,
                DateTime = request.CreateBookingSlotRequests[0].Date
            });
            await _transactionService.AddNewTransaction(new Transaction()
            {
                AccountId = Int32.Parse(userId),
                TransactionStatusId = 2,
                TransactionTypeId = 3,
                Amount = booking.Price,
                Timestamp = DateTime.Now
            });
            foreach (var item in request.CreateBookingSlotRequests)
            {
                var bookingDetail = await _bookingDetailService.AddNewBookingDetails(new BookingDetail()
                {
                    CourtId = item.CourtId,
                    BookingId = booking.Id
                });
                List<Slot> slots = new List<Slot>();
                foreach (var slot in item.TimeFrames)
                {
                    slots.Add(new Slot()
                    {
                        CourtId = item.CourtId,
                        SlotStatusId = 1,
                        TimeFrame = slot.TimeFrame,
                        BookingDetailId = bookingDetail.Id,
                        DateTime = item.Date
                    });
                }
                await _slotService.AddRangeSlot(slots);
            }

            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Booking successful!",
                Data = booking
            });
        }
        catch (Exception ex)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 400,
                Message = "error" + ex.InnerException
            });
        }
    }

    [HttpGet("get-all-by-user")]
    [Authorize]
    public async Task<IActionResult> GetAllByPlayerId()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        int userId = Int32.Parse(identity.FindFirst("UserId").Value);
        var bookings = await _bookingService.GetBookingsWithPlayerId(userId);
        if (bookings.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get bookings by player's id successful!",
                Data = bookings
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!",
            Data = null
        });
    }

    [HttpGet("cancel-booking")]
    public async Task<IActionResult> CancelBooking(int bookingId)
    {
        try
        {
            var booking = await _bookingService.GetBookingWithId(bookingId);
            await _bookingService.CancelBooking(booking);
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Cancel booking successful!",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 400,
                Message = "Error in cancel: " + ex.InnerException
            });
        }
    }

    [HttpGet("get-booking-detail")]
    public async Task<IActionResult> GetAllBookingDetailsWithBookingId(int bookingId)
    {
        var bookingDetails = await _bookingService.GetBookingDetails(bookingId);
        var booking = await _bookingService.GetBookingWithId(bookingId);
        List<BookingDetailResponse> response = new List<BookingDetailResponse>();
        for(int i = 0; i < bookingDetails.Count; i++)
        {
            var slots = await _slotService.GetAllSlotsByBookingDetail(bookingDetails[i].Id);
            if (slots.Any())
            {
                response.Add(new BookingDetailResponse()
                {
                    BookingId = bookingId,
                    Date = DateTime.Now,
                    Price = booking.Price,
                    Slots = _mapper.Map<List<SlotResponse>>(slots)
                });
            }
            else
            {
                response.Add(new BookingDetailResponse()
                {
                    BookingId = bookingId,
                    Date = DateTime.Now,
                    Price = booking.Price,
                    Slots = new List<SlotResponse>()
                });
            }
        }
        if (bookingDetails.Any())
        {
            var badmintonCourt = await _badmintonCourtService.GetBadmintonCourt(booking.BadmintonCourtId);
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get booking details based on booking id successful!",
                Data = new
                {
                    BadmintonCourtName = badmintonCourt.CourtName,
                    CourtId = badmintonCourt.Id,
                    Response = response
                }
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!",
            Data = null
        });
    }

    [HttpGet("get-booking-before-now")]
    [Authorize]
    public async Task<IActionResult> GetBookingsBeforeNow()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        int userId = Int32.Parse(identity.FindFirst("UserId").Value);
        var bookings = await _bookingService.GetAllBookingsBeforeNow(userId);
        if (bookings.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get bookings before now successful!",
                Data = bookings
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!",
            Data = null
        });
    }

    [HttpGet("get-booking-after-now")]
    public async Task<IActionResult> GetAllBookingsAfterNow()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        int userId = Int32.Parse(identity.FindFirst("UserId").Value);
        var bookings = await _bookingService.GetAllBookingAfterNow(userId);
        if (bookings.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all bookings successful!",
                Data = bookings
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!",
            Data = null
        });
    }

}