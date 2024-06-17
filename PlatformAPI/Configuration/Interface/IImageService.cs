using CloudinaryDotNet.Actions;

namespace PlatformAPI.Configuration.Interface;

public interface IImageService
{
    public Task<ImageUploadResult> UploadImageAsync(IFormFile file);
    public Task<DeletionResult> DeletePhotoAsync(string publicId);
}