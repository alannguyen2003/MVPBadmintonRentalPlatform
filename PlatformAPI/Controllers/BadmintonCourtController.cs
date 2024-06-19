using System.Security.Claims;
using AutoMapper;
using BusinessObject;
using DataTransfer;
using DataTransfer.Request;
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
    private readonly IMapper _mapper;

    public BadmintonCourtController(IBadmintonCourtService badmintonCourtService, IMapper mapper)
    {
        _badmintonCourtService = badmintonCourtService;
        _mapper = mapper;
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
    
    
}