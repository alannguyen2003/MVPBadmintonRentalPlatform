using DataTransfer;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BankController : ControllerBase
{
    private readonly IBankService _bankService;

    public BankController(IBankService bankService)
    {
        _bankService = bankService;
    }

    [HttpGet("get-all-banks")]
    public async Task<IActionResult> GetAllBanks()
    {
        var banks = await _bankService.GetAllBanks();
        if (banks.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all banks successful!",
                Data = banks
            });
        }
        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!"
        });
    }
}