using CloudinaryDotNet;
using DataTransfer;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SlotStatusController : ControllerBase
{
    private readonly ISlotStatusService _slotStatusService;

    public SlotStatusController(ISlotStatusService slotStatusService)
    {
        _slotStatusService = slotStatusService;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllSlotStatus()
    {
        var slotStatus = await _slotStatusService.GetAllSlotStatus();
        if (slotStatus.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all slot statuses successful!",
                Data = slotStatus
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!"
        });
    }
}