﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Security.Claims;
using AutoMapper;
using BusinessObject;
using CloudinaryDotNet;
using DataTransfer;
using DataTransfer.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;
    private readonly IMapper _mapper;
    private readonly IAccountService _accountService;

    public TransactionController(ITransactionService transactionService, IMapper mapper,
        IAccountService accountService)
    {
        _transactionService = transactionService;
        _mapper = mapper;
        _accountService = accountService;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllTransactions()
    {
        var transactions = await _transactionService.GetAllTransaction();
        if (transactions.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all transactions successful!",
                Data = transactions
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!"
        });
    }

    [HttpGet("get-all-with-account")]
    public async Task<IActionResult> GetAllTransactionsWithAccount(int accountId)
    {
        var transactions = await _transactionService.GetAllTransactionByAccount(accountId);
        if (transactions.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all transactions successful!",
                Data = transactions
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!"
        });
    }

    [HttpGet("get-all-with-type")]
    public async Task<IActionResult> GetAllTransactionWithType(int transactionTypeId)
    {
        var transactions = await _transactionService.GetAllTransactionByType(transactionTypeId);
        if (transactions.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all transactions with type successful!",
                Data = transactions
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!"
        });
    }

    [HttpGet("get-all-with-status")]
    public async Task<IActionResult> GetAllTransactionWithStatus(int transactionStatusId)
    {
        var transactions = await _transactionService.GetAllTransactionByStatus(transactionStatusId);
        if (transactions.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all transaction successful!",
                Data = transactions
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No record found!"
        });
    }

    [HttpPost("add-new-transaction")]
    [Authorize]
    public async Task<IActionResult> AddNewTransaction(TransactionRequest request)
    {
        try
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("UserId").Value;
            var transaction = _mapper.Map<Transaction>(request);
            transaction.AccountId = Int32.Parse(userId);
            transaction.TransactionStatusId = 1;
            transaction.Timestamp = DateTime.Now;
            await _transactionService.AddNewTransaction(transaction);
            return Ok(new ApiResponse()
            {
                StatusCode = 201,
                Message = "Create new transaction successful!"
            });
        }
        catch (Exception ex)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 400,
                Message = "Error in create new transaction: " + ex.InnerException
            });
        }
    }

    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetTransactionById(int transactionId)
    {
        var transaction = await _transactionService.GetTransaction(transactionId);
        if (transaction != null)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get transaction successful!",
                Data = transaction
            });
        }
        return Ok(new ApiResponse()
        {
            StatusCode = 404,
            Message = "No record found!"
        });
    }

    [HttpPost("approve-transaction")]
    public async Task<IActionResult> ApproveTransaction(int transactionId)
    {
        try
        {
            var transaction = await _transactionService.GetTransaction(transactionId);
            if (transaction != null)
            {
                await _transactionService.ApproveTransaction(transaction);
                return Ok(new ApiResponse()
                {
                    StatusCode = 200,
                    Message = "Approve transaction succesful!"
                });
            }
            else throw new Exception();
        }
        catch (Exception ex)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 400,
                Message = "Error in approve transaction: " + ex.InnerException
            });
        }
    }
    
    [HttpPost("reject-transaction")]
    public async Task<IActionResult> RejectTransaction(int transactionId)
    {
        try
        {
            var transaction = await _transactionService.GetTransaction(transactionId);
            if (transaction != null)
            {
                await _transactionService.RejectTransaction(transaction);
                return Ok(new ApiResponse()
                {
                    StatusCode = 200,
                    Message = "Approve transaction succesful!"
                });
            }
            else throw new Exception();
        }
        catch (Exception ex)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 400,
                Message = "Error in approve transaction: " + ex.InnerException
            });
        }
    }

    [HttpPost("add-money")]
    public async Task<IActionResult> AddMoneyForAccount(int accountId, int money)
    {
        try
        {
            var account = await _accountService.GetAccount(accountId);
            account.Balance += money;
            await _accountService.EditProfileAsync(account);
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Add money for account successful!",
                Data = account
            });
        }
        catch (Exception ex)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 400,
                Message = "Error in add money: " + ex.InnerException
            });
        }
    }

    [HttpPost("cash-out-request")]
    [Authorize]
    public async Task<IActionResult> CashOutRequest(int money)
    {
        try
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("UserId").Value;
            var transaction = new Transaction()
            {
                AccountId = Int32.Parse(userId),
                TransactionTypeId = 2,
                TransactionStatusId = 1,
                Amount = money,
                Timestamp = DateTime.Now
            };
            await _transactionService.AddNewTransaction(transaction);
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Add new transaction successful!"
            });
        }
        catch (Exception ex)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 400,
                Message = "Error in cash out request: " + ex.InnerException
            });
        }
    }

    [HttpGet("approve-cash-out-request")]
    public async Task<IActionResult> ApproveCashOutRequest(int transactionId)
    {
        try
        {
            var transaction = await _transactionService.GetTransaction(transactionId);
            if (transaction != null)
            {
                await _transactionService.RejectTransaction(transaction);
                return Ok(new ApiResponse()
                {
                    StatusCode = 200,
                    Message = "Approve transaction succesful!"
                });
            }
            else throw new Exception();
        }
        catch (Exception ex)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 400,
                Message = "Error in approve transaction: " + ex.InnerException
            });
        }
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
                Message = "Create new transaction successful!"
            });
        }
        catch (Exception ex)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 400,
                Message = "Error in create new transaction: " + ex.InnerException
            });
        }
    }

    [HttpPost("cancel-request")]
    public async Task<IActionResult> CancelRequest(int transactionId)
    {
        try
        {
            var transaction = await _transactionService.GetTransaction(transactionId);
            if (transaction != null)
            {
                await _transactionService.CancelRequestTransaction(transaction);
                return Ok(new ApiResponse()
                {
                    StatusCode = 200,
                    Message = "Cancel request successful!"
                });
            }
            else throw new Exception();
        }
        catch (Exception ex)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 400,
                Message = "Error in cancel request transaction: " + ex.InnerException
            });
        }
    }
}