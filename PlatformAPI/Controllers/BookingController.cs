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

    public BookingController(IBookingService bookingService, IAccountService accountService,
        IMapper mapper, ITransactionService transactionService, ISlotService slotService,
        IBookingDetailService bookingDetailService)
    {
        _bookingService = bookingService;
        _accountService = accountService;
        _mapper = mapper;
        _transactionService = transactionService;
        _slotService = slotService;
        _bookingDetailService = bookingDetailService;
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
                BookingStatusId = 1
            });
            List<Slot> slots = new List<Slot>();
            foreach (var item in request.CreateBookingSlotRequests)
            {
                var bookingDetail = await _bookingDetailService.AddNewBookingDetails(new BookingDetail()
                {
                    CourtId = item.CourtId,
                    BookingId = booking.Id
                });
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

}