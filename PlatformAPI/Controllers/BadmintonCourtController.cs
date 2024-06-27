using System.Security.Claims;
using AutoMapper;
using BusinessObject;
using DataAccess;
using DataTransfer;
using DataTransfer.Request;
using DataTransfer.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PlatformAPI.Configuration;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BadmintonCourtController : ControllerBase
{
    private readonly IBadmintonCourtService _badmintonCourtService;
    private readonly IAccountService _accountService;
    private readonly IServiceCourtService _serviceCourtService;
    private readonly IMapper _mapper;
    private readonly ICourtService _courtService;
    private readonly Utilization _utilization;

    public BadmintonCourtController(IBadmintonCourtService badmintonCourtService, IMapper mapper,
        IServiceCourtService serviceCourtService, IAccountService accountService,
        ICourtService courtService, Utilization utilization)
    {
        _badmintonCourtService = badmintonCourtService;
        _serviceCourtService = serviceCourtService;
        _accountService = accountService;
        _mapper = mapper;
        _courtService = courtService;
        _utilization = utilization;
    }

    [HttpGet("get-all-badminton-courts")]
    public async Task<IActionResult> GetAllBadmintonCourts()
    {
        var badmintonCourts = await _badmintonCourtService.GetAllBadmintonCourts();
        if (badmintonCourts.Any())
        {
            var badmintonCourtResponse = _mapper.Map<List<BadmintonCourtResponse>>(badmintonCourts);
            for (int i = 0; i < badmintonCourts.Count; i++)
            {
                var minuteStart = badmintonCourts[i].MinuteStart == 0 ? "00" : "" + badmintonCourts[i].MinuteStart;
                var minuteEnd = badmintonCourts[i].MinuteEnd == 0 ? "00" : "" + badmintonCourts[i].MinuteEnd;
                badmintonCourtResponse[i].AvailableTime = 
                    badmintonCourts[i].HourStart + ":" + minuteStart + " - " +
                    badmintonCourts[i].HourEnd + ":" + minuteEnd;
                var services = await _serviceCourtService.GetAllSerivcesBasedOnBadmintonCourt(badmintonCourts[i].Id);
                badmintonCourtResponse[i].ServiceCourts = new List<string>();
                foreach (var item in services)
                {
                    badmintonCourtResponse[i].ServiceCourts.Add(item.ServiceName);
                }
                var owner = await _accountService.GetAccount(badmintonCourts[i].AccountId);
                badmintonCourtResponse[i].Owner = owner.FullName;
                badmintonCourtResponse[i].PhoneNumber = owner.PhoneNumber;
            }
            
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Successful!",
                Data = badmintonCourtResponse
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "Data not found!",
            Data = null
        });
    }

    [HttpPost("add-badminton-court")]
    public async Task<IActionResult> AddNewBadmintonCourt(BadmintonCourtRequest request)
    {
        try
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("UserId").Value;
            var badmintonCourt = _mapper.Map<BadmintonCourt>(request);
            badmintonCourt.AccountId = Int32.Parse(userId);
            badmintonCourt.ProfileImage = "";
            await _badmintonCourtService.AddBadmintonCourt(badmintonCourt);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
        return Ok(new ApiResponse()
        {
            StatusCode = 201, 
            Message = "Add new badminton court successful!"
        });
    }

    [HttpGet("get-with-owner")]
    public async Task<IActionResult> GetBadmintonCourtWithOwnerId(int ownerId)
    {
        var badmintonCourt = await _badmintonCourtService.GetBadmintonCourtWithOwnerId(ownerId);
        if (badmintonCourt != null)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get badminton court successful!",
                Data = badmintonCourt
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!",
            Data = null
        });
    }
    
    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetBadmintonCourt(int badmintonCourtId)
    {
        var badmintonCourt = await _badmintonCourtService.GetBadmintonCourt(badmintonCourtId);
        var badmintonCourtResponse = _mapper.Map<BadmintonCourtResponse>(badmintonCourt);
        var minuteStart = badmintonCourt.MinuteStart == 0 ? "00" : "" + badmintonCourt.MinuteStart;
        var minuteEnd = badmintonCourt.MinuteEnd == 0 ? "00" : "" + badmintonCourt.MinuteEnd;
        badmintonCourtResponse.AvailableTime = 
            badmintonCourt.HourStart + ":" + minuteStart + " - " +
            badmintonCourt.HourEnd + ":" + minuteEnd;
        var services = await _serviceCourtService.GetAllSerivcesBasedOnBadmintonCourt(badmintonCourt.Id);
        badmintonCourtResponse.ServiceCourts = new List<string>();
        foreach (var item in services)
        {
            badmintonCourtResponse.ServiceCourts.Add(item.ServiceName);
        }
        var owner = await _accountService.GetAccount(badmintonCourt.AccountId);
        badmintonCourtResponse.Owner = owner.FullName;
        badmintonCourtResponse.PhoneNumber = owner.PhoneNumber;
        if (badmintonCourt != null)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get badminton court successful!",
                Data = badmintonCourtResponse
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!",
            Data = null
        });
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchBadmintonCourtByName(string search)
    {
        var badmintonCourts = await _badmintonCourtService.SearchBadmintonCourtByName(search);
        if (badmintonCourts.Any())
        {
            var badmintonCourtResponse = _mapper.Map<List<BadmintonCourtResponse>>(badmintonCourts);
            for (int i = 0; i < badmintonCourts.Count; i++)
            {
                var minuteStart = badmintonCourts[i].MinuteStart == 0 ? "00" : "" + badmintonCourts[i].MinuteStart;
                var minuteEnd = badmintonCourts[i].MinuteEnd == 0 ? "00" : "" + badmintonCourts[i].MinuteEnd;
                badmintonCourtResponse[i].AvailableTime = 
                    badmintonCourts[i].HourStart + ":" + minuteStart + " - " +
                    badmintonCourts[i].HourEnd + ":" + minuteEnd;
                var services = await _serviceCourtService.GetAllSerivcesBasedOnBadmintonCourt(badmintonCourts[i].Id);
                badmintonCourtResponse[i].ServiceCourts = new List<string>();
                foreach (var item in services)
                {
                    badmintonCourtResponse[i].ServiceCourts.Add(item.ServiceName);
                }
                var owner = await _accountService.GetAccount(badmintonCourts[i].AccountId);
                badmintonCourtResponse[i].Owner = owner.FullName;
                badmintonCourtResponse[i].PhoneNumber = owner.PhoneNumber;
            }
            
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Successful!",
                Data = badmintonCourtResponse
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!",
            Data = null
        });
    }

    [HttpGet("generate-slot-by-date")]
    public async Task<IActionResult> GenerateSlotByDate(int badmintonCourtId, DateTime date)
    {
        var badmintonCourt = await _badmintonCourtService.GetBadmintonCourt(badmintonCourtId);
        var listCourt = new List<GenerateSlotResponse>();
        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "Generate slot successful!",
            Data = new BadmintonCourtSlotReponse()
            {
                CourtId = badmintonCourtId,
                CourtName = badmintonCourt.CourtName,
                GenerateSlotResponses = await _utilization.GenerateSlotResponseForBadmintonCourt(badmintonCourtId, date)
            }
        });
    }
    
    [HttpGet("generate-slot-by-date-and-court")]
    public async Task<IActionResult> GenerateSlotByDateAndCourt(int badmintonCourtId, int courtId, DateTime date)
    {
        var badmintonCourt = await _badmintonCourtService.GetBadmintonCourt(badmintonCourtId);
        var listCourt = new List<GenerateSlotResponse>();
        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "Generate slot successful!",
            Data = new SlotOfCourtResponse()
            {
                CourtId = badmintonCourtId,
                CourtName = badmintonCourt.CourtName,
                GenerateSlotResponse = await _utilization.GenerateSlotForBadmintonCourtWithCourt(badmintonCourtId, courtId, date)
            }
        });
    }
    
    [HttpGet("generate-slot-by-date-for-owner")]
    public async Task<IActionResult> GenerateSlotByDateForOwner(int badmintonCourtId, DateTime date)
    {
        /*var badmintonCourt = await _badmintonCourtService.GetBadmintonCourt(badmintonCourtId);
        var listCourt = new List<GenerateSlotResponse>();
        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "Generate slot successful!",
            Data = new BadmintonCourtSlotReponse()
            {
                CourtId = badmintonCourtId,
                CourtName = badmintonCourt.CourtName,
                GenerateSlotResponses = await _utilization.GenerateSlotResponseForBadmintonCourt(badmintonCourtId, date)
            }
        });*/
        return Ok();
    }
    
    [HttpGet("generate-slot-by-date-and-court-for-owner")]
    public async Task<IActionResult> GenerateSlotByDateAndCourtForOwner(int badmintonCourtId, int courtId, DateTime date)
    {
        var badmintonCourt = await _badmintonCourtService.GetBadmintonCourt(badmintonCourtId);
        var listCourt = new List<GenerateSlotResponse>();
        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "Generate slot successful!",
            Data = new SlotOfCourtResponseForOwner()
            {
                CourtId = badmintonCourtId,
                CourtName = badmintonCourt.CourtName,
                GenerateSlotResponseForOwner = await _utilization.GenerateSlotForBadmintonCourtWithCourtForOwner(badmintonCourtId, courtId, date)
            }
        });
    }
}
