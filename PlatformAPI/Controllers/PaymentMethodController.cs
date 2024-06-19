using AutoMapper;
using BusinessObject;
using CloudinaryDotNet;
using DataTransfer;
using DataTransfer.Request;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentMethodController : ControllerBase
{
    private readonly IPaymentMethodService _paymentMethodService;
    private readonly IMapper _mapper;

    public PaymentMethodController(IPaymentMethodService paymentMethodService, IMapper mapper)
    {
        _paymentMethodService = paymentMethodService;
        _mapper = mapper;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllPaymentMethods()
    {
        var payments = await _paymentMethodService.GetAllPaymentMethod();
        if (payments.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all payment methods successful!",
                Data = payments
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No records found!",
            Data = null
        });
    }
    
    [HttpGet("get-payment")]
    public async Task<IActionResult> GetPaymentMethodById(int paymentMethodId)
    {
        var payment = await _paymentMethodService.GetPaymentMethodById(paymentMethodId);
        if (payment != null)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Get all payment methods successful!",
                Data = payment
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "No records found!",
            Data = null
        });
    }

    [HttpPost("add-payment")]
    public async Task<IActionResult> AddNewPaymentMethodAsync(PaymentMethodRequest request)
    {
        try
        {
            await _paymentMethodService.AddPaymentMethodAsync(_mapper.Map<PaymentMethod>(request));
            return Ok(new ApiResponse()
            {
                StatusCode = 201,
                Message = "Add new payment successful!",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return Problem("Add new payment failed!", null, 500, "Add Payment Failed", "POST");
        }
    }
}