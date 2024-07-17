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
public class ExpenditureController : ControllerBase
{
    private readonly ITransactionService _transactionService;
    private readonly ITransactionStatusService _transactionStatusService;
    private readonly ITransactionTypeService _transactionTypeService;
    private readonly IMapper _mapper;

    public ExpenditureController(ITransactionService transactionService, ITransactionStatusService transactionStatusService,
        ITransactionTypeService transactionTypeService, IMapper mapper)
    {
        _transactionService = transactionService;
        _transactionStatusService = transactionStatusService;
        _transactionTypeService = transactionTypeService;
        _mapper = mapper;
    }

    [HttpGet("get-all-expenditure-type")]
    public async Task<IActionResult> GetAllExpenditureType()
    {
        var expenditureTypes = await _transactionTypeService.GetAllExpenditureRecord();
        if (expenditureTypes.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all expenditure record successful!",
                Data = expenditureTypes
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!"
        });
    }
    
    [HttpPost("add-new-expenditure-record")]
    [Authorize]
    public async Task<IActionResult> AddNewExpenditureRecord(ExpenditureRequest request)
    {
        try
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("UserId").Value;
            var transaction = _mapper.Map<Transaction>(request);
            transaction.AccountId = Int32.Parse(userId);
            transaction.TransactionStatusId = 2;
            transaction.Timestamp = request.DateTime;
            await _transactionService.AddNewTransaction(transaction);
            return Ok(new ApiResponse()
            {
                StatusCode = 201,
                Message = "Create new expenditure record successful!"
            });
        }
        catch (Exception ex)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 400,
                Message = "Error in create new expenditure record: " + ex.Message
            });
        }
    }

    [HttpGet("get-expenditure-records")]
    [Authorize]
    public async Task<IActionResult> GetAllExpenditureRecordsOfUser()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var userId = Int32.Parse(identity.FindFirst("UserId").Value);
        var transactions = await _transactionService.GetAllTransactionByAccount(userId);
        if (transactions.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get expenditure records of user!",
                Data = transactions
            });
        }
        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!"
        });
    }
    
}