using AutoMapper;
using DataTransfer;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;

    public RoleController(IRoleService roleService, IMapper mapper)
    {
        _roleService = roleService;
        _mapper = mapper;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _roleService.GetAllRoles();
        if (roles.Any())
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 200,
                Message = "Successful!",
                Data = roles
            });
        }
        return Ok(new ApiResponse()
        {
            StatusCode = 400,
            Message = "Get failed!",
            Data = null
        });
    }

}