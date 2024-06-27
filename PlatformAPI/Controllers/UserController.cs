using System.Security.Claims;
using AutoMapper;
using BusinessObject;
using DataTransfer;
using DataTransfer.Request;
using DataTransfer.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public UserController(IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    [HttpGet("get-profile")]
    [Authorize]
    public async Task<IActionResult> GetProfile()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var userId = identity.FindFirst("UserId").Value;
        var account = await _accountService.GetAccount(Int32.Parse(userId));
        return Ok(new ApiResponse()
        {
            StatusCode = 200, Message = "Get account successful!",
            Data = _mapper.Map<AccountResponse>(account)
        });
    }
    
    [HttpGet("get-detail-user")]
    [Authorize]
    public async Task<IActionResult> GetDetailUser(int userId)
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var account = await _accountService.GetAccount(userId);
        return Ok(new ApiResponse()
        {
            StatusCode = 200, Message = "Get account successful!",
            Data = _mapper.Map<AccountResponse>(account)
        });
    }

    [HttpPost("edit-user-profile")]
    public async Task<IActionResult> EditUserProfileAsync(EditAccountRequest request)
    {
        try
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var account = _mapper.Map<Account>(request);
            var userId = identity.FindFirst("UserId").Value;
            account.Id = Int32.Parse(userId);
            await _accountService.EditProfileAsync(account);
            return Ok(new ApiResponse()
            {
                StatusCode = 200, 
                Message = "Edit user profile successful!",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 400,
                Message = "Edit profile failed, see log: " + ex.Message,
                Data = null
            });
        }
    }

    [HttpGet("get-number-of-player-and-owner")]
    public async Task<IActionResult> GetNumberOfPlayerAndOwner()
    {
        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "Get number of player and owner successful!",
            Data = new NumberOfPlayerAndOwner()
            {
                NumberOfOwner = await _accountService.GetNumberOfOwner(),
                NumberOfPlayer = await _accountService.GetNumberOfPlayer()
            }
        });
    }
}