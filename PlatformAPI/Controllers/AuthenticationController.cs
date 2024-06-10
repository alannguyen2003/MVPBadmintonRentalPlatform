using AutoMapper;
using BusinessObject;
using DataTransfer;
using DataTransfer.Request;
using DataTransfer.Response;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IBadmintonCourtService _badmintonCourtService;
    private readonly IMapper _mapper;

    public AuthenticationController(IAccountService accountService, IMapper mapper,
        IBadmintonCourtService badmintonCourtService)
    {
        _accountService = accountService;
        _mapper = mapper;
        _badmintonCourtService = badmintonCourtService;
    }

    [HttpGet("get-accounts")]
    public async Task<IActionResult> GetAllAccounts()
    {
        var accounts = await _accountService.GetAllAccounts();
        if (accounts.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Successful!",
                Data = _mapper.Map<List<AccountResponse>>(accounts)
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 400,
            Message = "Not found any record!",
            Data = null
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var account = await _accountService.GetAccount(request.Email, request.Password);
        if (account != null)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Successful!",
                Data = await _accountService.GenerateJwtToken(account)
            });
        }
        else
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 400,
                Message = "Login failed!",
                Data = null
            });
        }
    }

    [HttpPost("player-register")]
    public async Task<IActionResult> Register(PlayerRegisterRequest request)
    {
        try
        {
            var account = _mapper.Map<Account>(request);
            account.Bank = "";
            account.RoleId = 1;
            account.CardNumber = "";
            var accountRegister = await _accountService.AddNewAccountAsync(account);
            return Ok(new ApiResponse()
            {
                StatusCode = 201,
                Message = "Register successful!",
                Data = await _accountService.GenerateJwtToken(accountRegister)
            });
        }
        catch (Exception ex)
        {
            return BadRequest("Error in register: " + ex.Message);
        }
    }

    [HttpPost("owner-register")]
    public async Task<IActionResult> OwnerRegister(OwnerRegisterRequest request)
    {
        await _accountService.AddNewAccount(_mapper.Map<Account>(request));
        
        return Ok();
    }
}