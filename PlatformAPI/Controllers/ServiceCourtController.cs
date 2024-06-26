﻿using AutoMapper;
using DataTransfer;
using DataTransfer.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ServiceCourtController : ControllerBase
{
    private readonly IServiceCourtService _serviceCourtService;
    private readonly IBadmintonCourtService _badmintonCourtService;
    private readonly IMapper _mapper;

    public ServiceCourtController(IServiceCourtService serviceCourtService,
        IBadmintonCourtService badmintonCourtService, IMapper mapper)
    {
        _serviceCourtService = serviceCourtService;
        _badmintonCourtService = badmintonCourtService;
        _mapper = mapper;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllServices()
    {
        var services = await _serviceCourtService.GetAllServices();
        if (services.Any())
        {
            
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Successful!",
                Data = _mapper.Map<List<ServiceOfCourtResponse>>(services)
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 400,
            Message = "No record found!",
            Data = null
        });
    }

    [HttpGet("get-by-badminton-court")]
    public async Task<IActionResult> GetByBadmintonCourt(int badmintonCourtId)
    {
        var services = await _serviceCourtService.GetAllSerivcesBasedOnBadmintonCourt(badmintonCourtId);
        if (services.Any())
        {
            ServiceCourtResponse response = new ServiceCourtResponse()
            {
                Services = new List<string>()
            };
            var badmintonCourt = await _badmintonCourtService.GetBadmintonCourt(badmintonCourtId);
            response.CourtName = badmintonCourt!.CourtName;
            foreach (var item in services)
            {
                response.Services.Add(item.ServiceName);
            }
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Successful!",
                Data = response
            });
        }

        return Ok(new ApiResponse()
        {
            StatusCode = 400,
            Message = "No record found!",
            Data = null
        });
    }

    [HttpPost("add-service-court")]
    public async Task<IActionResult> AddServiceForBadmintonCourt(int badmintonCourtId)
    {
        return Ok();
    }
}