using Microsoft.AspNetCore.Mvc;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    [HttpGet("get-revenue-by-badminton-court-id-chart")]
    public async Task<IActionResult> GetRevenueByBadmintonCourtIdChart(int badmintonCourtId)
    {
        return Ok();
    }
}