using System.Net;
using DataTransfer;
using DataTransfer.Response;
using Microsoft.AspNetCore.Mvc;
using PlatformAPI.Configuration.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }
    
    [HttpPost("upload")]
    public async Task<IActionResult> UploadAsync(IFormFile file)
    {
        var result = await _imageService.UploadImageAsync(file);
        if (result == null)
        {
            ModelState.AddModelError("Upload image", " Something went wrong");
            return Problem("Something went wrong", null, (int)HttpStatusCode.InternalServerError);
        }
        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "Upload new image successful!",
            Data = new ImageUploadResponse()
            {
                Link = result.SecureUri.AbsoluteUri, 
                PublicId = result.PublicId
            }
        });
    }
}