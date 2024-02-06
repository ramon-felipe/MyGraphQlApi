using Microsoft.AspNetCore.Mvc;
using MyGraphQl.Application;

namespace MyGraphQl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = nameof(Get))]
    public IActionResult Get()
    {
        return this.Ok("test");
    }
}