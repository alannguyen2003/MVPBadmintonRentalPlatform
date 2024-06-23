using DataTransfer;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionStatusController : ControllerBase
{
    private readonly ITransactionStatusService _transactionStatusService;

    public TransactionStatusController(ITransactionStatusService transactionStatusService)
    {
        _transactionStatusService = transactionStatusService;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllTransactionStatus()
    {
        var transactionStatus = await _transactionStatusService.GetAllTransactionStatus();
        if (transactionStatus.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all transaction status successful!",
                Data = transactionStatus
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!"
        });
    }
}