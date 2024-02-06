using Microsoft.AspNetCore.Mvc;
using MyGraphQl.Application;

namespace MyGraphQl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
	private readonly ILogger<UserController> _logger;
	private readonly IUserApplication _userApplication;

    public UserController(ILogger<UserController> logger, IUserApplication userApplication)
    {
        _logger = logger;
        this._userApplication = userApplication;
    }

    [HttpGet(template: "{id:int}", Name = nameof(GetUser))]
	public async Task<IActionResult> GetUser(int id)
	{
        var user = await this._userApplication.GetUser(id);

        return this.Ok(user);
	}
}
