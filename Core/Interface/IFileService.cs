namespace Core.Interface;
using Microsoft.AspNetCore.Http;

public interface IFileService
{
    Task<string> SaveFileAsync(IFormFile file);
    Task<bool> DeleteFileAsync(string fileUrl);
}

