using System;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ErrorController : BaseApiController
{
    [HttpGet("unauthorized")]
    public IActionResult GetUnauthorized()
    {
        return Unauthorized();
    }

    [HttpGet("badrequest")]
    public IActionResult GetBadRequest()
    {
        return BadRequest("This is a bad request");
    }
    [HttpGet("notfound")]
    public IActionResult GetNotFound()
    {
        return NotFound();
    }
    [HttpGet("internalerror")]
    public IActionResult GetInternalError()
    {
        throw new Exception("This is an internal server error");
    }
    [HttpPost("validationerror")]
    public IActionResult GetValidationError(Core.Dtos.CreateProductDto product)
    {
       return Ok();
    }

}
