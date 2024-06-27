using DataTransfer;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public AdminController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }
    [HttpGet("get-revenue-by-badminton-court-id-chart")]
    public async Task<IActionResult> GetRevenueByBadmintonCourtIdChart(int badmintonCourtId, DateTime date)
    {
        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "Get revenue date " + date + " successful!",
            Data = await _bookingService.GetRevenueByBadmintonCourtIdAndDate(badmintonCourtId, date)
        });
    }
}