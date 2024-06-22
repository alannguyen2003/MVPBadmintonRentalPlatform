using DataTransfer;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionTypeController : ControllerBase
{
    private readonly ITransactionTypeService _transactionTypeService;

    public TransactionTypeController(ITransactionTypeService transactionTypeService)
    {
        _transactionTypeService = transactionTypeService;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllTransactionTypes()
    {
        var transactionTypes = await _transactionTypeService.GetAllTransactionType();
        if (transactionTypes.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all transaction types successful!",
                Data = transactionTypes
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!"
        });
    }
}