using AutoMapper;
using DataTransfer;
using DataTransfer.Response;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceCourtController : ControllerBase
{
    private readonly IServiceCourtService _serviceCourtService;
    private readonly IMapper _mapper;

    public ServiceCourtController(IServiceCourtService serviceCourtService, IMapper mapper)
    {
        _serviceCourtService = serviceCourtService;
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
            response.CourtName = services.FirstOrDefault().BadmintonCourt.CourtName;
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
}