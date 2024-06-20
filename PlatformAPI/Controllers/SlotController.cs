using AutoMapper;
using DataTransfer;
using DataTransfer.Response;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SlotController : ControllerBase
{
    private readonly ISlotService _slotService;
    private readonly IBadmintonCourtService _badmintonCourtService;
    private readonly IMapper _mapper;

    public SlotController(ISlotService slotService, IMapper mapper, IBadmintonCourtService badmintonCourtService)
    {
        _slotService = slotService;
        _badmintonCourtService = badmintonCourtService;
        _mapper = mapper;
    }

    [HttpGet("get-all-slots")]
    public async Task<IActionResult> GetAllSlots()
    {
        var slots = await _slotService.GetAllSlots();
        var slotsResponse = _mapper.Map<List<SlotResponse>>(slots);
        for(int i = 0; i < slots.Count; i++)
        {
            var minuteStart = slots[i].MinuteStart == 0 ? "00" : "" + slots[i].MinuteStart;
            var minuteEnd = slots[i].MinuteEnd == 0 ? "00" : "" + slots[i].MinuteEnd;
            slotsResponse[i].TimeFrame = slots[i].HourStart + ":" + minuteStart + " - " +
                                         slots[i].HourEnd + ":" + minuteEnd;
        }
        if (slots.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all slots successful!",
                Data = slotsResponse
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
        var slotsResponse = _mapper.Map<List<SlotResponse>>(slots);
        for(int i = 0; i < slots.Count; i++)
        {
            var minuteStart = slots[i].MinuteStart == 0 ? "00" : "" + slots[i].MinuteStart;
            var minuteEnd = slots[i].MinuteEnd == 0 ? "00" : "" + slots[i].MinuteEnd;
            slotsResponse[i].TimeFrame = slots[i].HourStart + ":" + minuteStart + " - " +
                                         slots[i].HourEnd + ":" + minuteEnd;
        }
        if (slots.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all slots successful!",
                Data = slotsResponse
            });
        }
        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!"
        });
    }

    [HttpGet("get-all-slots-of-badminton-court")]
    public async Task<IActionResult> GetAllSlotsOfBadmintonCourt(int badmintonCourtId)
    {
        var slots = await _badmintonCourtService.GetAllSlotsOfBadmintonCourt(badmintonCourtId);
        var slotsResponse = _mapper.Map<List<SlotResponse>>(slots);
        for(int i = 0; i < slots.Count; i++)
        {
            var minuteStart = slots[i].MinuteStart == 0 ? "00" : "" + slots[i].MinuteStart;
            var minuteEnd = slots[i].MinuteEnd == 0 ? "00" : "" + slots[i].MinuteEnd;
            slotsResponse[i].TimeFrame = slots[i].HourStart + ":" + minuteStart + " - " +
                                         slots[i].HourEnd + ":" + minuteEnd;
        }
        if (slots.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all slots successful!",
                Data = slotsResponse
            });
        }
        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!"
        });
    }
}