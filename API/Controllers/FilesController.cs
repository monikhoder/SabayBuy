using System;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class FilesController(IFileService fileService) : BaseApiController
{
    [HttpPost("upload")]
    public async Task<ActionResult<string>> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded");

        // allow only image files
        if (!file.ContentType.StartsWith("image/"))
            return BadRequest("Only image files are allowed");

        var imageUrl = await fileService.SaveFileAsync(file);

        // Return URL
        return Ok(new { Url = imageUrl });
    }
    [HttpDelete("delete")]
    public async Task<ActionResult> DeleteFile([FromQuery] string fileUrl)
    {
        if (string.IsNullOrEmpty(fileUrl))
            return BadRequest("File URL is required");

        var result = await fileService.DeleteFileAsync(fileUrl);
        if (!result)
            return NotFound("File not found or could not be deleted");

        return Ok("File deleted successfully");
    }

}
