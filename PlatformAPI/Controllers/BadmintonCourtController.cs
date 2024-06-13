using DataTransfer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BadmintonCourtController : ControllerBase
{
    private readonly IBadmintonCourtService _badmintonCourtService;

    public BadmintonCourtController(IBadmintonCourtService badmintonCourtService)
    {
        _badmintonCourtService = badmintonCourtService;
    }

    [HttpGet("get-all-badmintonton-courts")]
    public async Task<IActionResult> GetAllBadmintonCourts()
    {
        var badmintonCourts = await _badmintonCourtService.GetAllBadmintonCourts();
        if (badmintonCourts.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Successful!",
                Data = badmintonCourts
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "Data not found!",
            Data = null
        });
    }
}