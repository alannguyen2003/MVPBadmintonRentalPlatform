using System.Security.Claims;
using AutoMapper;
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
    private readonly IMapper _mapper;

    public BookingController(IBookingService bookingService, IAccountService accountService,
        IMapper mapper)
    {
        _bookingService = bookingService;
        _accountService = accountService;
        _mapper = mapper;
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
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var userId = identity.FindFirst("UserId").Value;
        var account = await _accountService.GetAccount(Int32.Parse(userId));
        return Ok(account);
    }

}