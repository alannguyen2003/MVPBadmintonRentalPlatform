using DataTransfer;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourtController : ControllerBase
{
    private readonly ICourtService _courtService;

    public CourtController(ICourtService courtService)
    {
        _courtService = courtService;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllCourts()
    {
        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "Get all courts successful!",
            Data = await _courtService.GetAllCourts()
        });
    }

    [HttpGet("get-with-badminton-court")]
    public async Task<IActionResult> GetAllCourtsWithBadmintonCourt(int badmintonCourtId)
    {
        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "Get all courts with badminton court successful!",
            Data = await _courtService.GetAllCourtsWithBadmintonCourt(badmintonCourtId)
        });
    }
}