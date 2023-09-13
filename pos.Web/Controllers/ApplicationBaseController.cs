using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace pos.Web.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ApplicationBaseController : ControllerBase
{
    private readonly ILogger<ApplicationBaseController> _logger;

    public ApplicationBaseController(ILogger<ApplicationBaseController> logger)
    {
        _logger = logger;
    }
}