using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using PlatformAPI.Configuration.Domain;
using PlatformAPI.Configuration.Interface;

namespace PlatformAPI.Configuration;

public class ImageService : IImageService
{
    private readonly Cloudinary _cloudinary;

    public ImageService(IOptions<CloudinarySetting> options)
    {
        var account = new Account(options.Value.CloudName, options.Value.ApiKey, options.Value.ApiSecret);
        _cloudinary = new Cloudinary(account);
    }
    
    public async Task<ImageUploadResult> UploadImageAsync(IFormFile file)
    {
        var result = await _cloudinary.UploadAsync(
            new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DisplayName = file.FileName,
                Folder = "badminton-rental-exe201"
            }
        );
        if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return result;
        }
        return null;
    }

    public async Task<DeletionResult> DeletePhotoAsync(string publicId)
    {
        var deleteParams = new DeletionParams(publicId);
        return await _cloudinary.DestroyAsync(deleteParams);
    }
}