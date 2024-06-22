using AutoMapper;
using BusinessObject;
using DataTransfer;
using DataTransfer.Request;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingStatusController : ControllerBase
{
    private readonly IBookingStatusService _bookingStatusService;
    private readonly IMapper _mapper;

    public BookingStatusController(IBookingStatusService bookingStatusService, IMapper mapper)
    {
        _bookingStatusService = bookingStatusService;
        _mapper = mapper;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllBookingStatus()
    {
        var bookingStatus = await _bookingStatusService.GetAllBookingStatus();
        if (bookingStatus.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all booking status successful!",
                Data = bookingStatus
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!",
            Data = null
        });
    }

    [HttpPost("add-new-booking-status")]
    public async Task<IActionResult> AddNewBookingStatus(CreateBookingStatusRequest request)
    {
        try
        {
            await _bookingStatusService.AddNewBookingStatus(_mapper.Map<BookingStatus>(request));
            return Ok(new ApiResponse()
            {
                StatusCode = 201,
                Message = "Add new booking status successful!"
            });
        }
        catch (Exception ex)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 400,
                Message = "Error in add new booking status: " + ex.InnerException
            });
        }
    }
}