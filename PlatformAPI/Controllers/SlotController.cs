using DataTransfer;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SlotController : ControllerBase
{
    private readonly ISlotService _slotService;

    public SlotController(ISlotService slotService)
    {
        _slotService = slotService;
    }

    [HttpGet("get-all-slots")]
    public async Task<IActionResult> GetAllSlots()
    {
        var slots = await _slotService.GetAllSlots();
        if (slots.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all slots successful!",
                Data = slots
            });
        }
        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!"
        });
    }

    [HttpGet("get-all-slots-of-court")]
    public async Task<IActionResult> GetAllSlotsOfCourt(int courtId)
    {
        var slots = await _slotService.GetAllSlotsWithCourt(courtId);
        if (slots.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all slots successful!",
                Data = slots
            });
        }
        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!"
        });
    }
}