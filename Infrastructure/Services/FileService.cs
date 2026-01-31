using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public class FileService(IConfiguration config) : IFileService
{
    // Connection String
    private readonly string _connectionString = config.GetConnectionString("AzureStorage")
                                                ?? throw new Exception("Azure Storage Connection String not found");

    // Container Name
     private readonly string _containerName = "images";

    public async Task<string> SaveFileAsync(IFormFile file )
    {
        //Connect to Azure Blob Storage
        var blobServiceClient = new BlobServiceClient(_connectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);

        //Craete the container
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

        //Create a unique name
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var blobClient = containerClient.GetBlobClient(fileName);

        // Upload
        using var stream = file.OpenReadStream();
        await blobClient.UploadAsync(stream, true);

        // Return URL
        return blobClient.Uri.ToString();
    }

    public async Task<bool> DeleteFileAsync(string fileUrl)
    {
        var blobServiceClient = new BlobServiceClient(_connectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);

        // Extract file name from URL
        var fileName = Path.GetFileName(new Uri(fileUrl).LocalPath);
        var blobClient = containerClient.GetBlobClient(fileName);

        return await blobClient.DeleteIfExistsAsync();
    }


}