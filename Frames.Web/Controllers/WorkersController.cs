using Microsoft.AspNetCore.Mvc;

namespace Frames.Web.Controllers;

public class WorkersController : Controller
{
    private readonly ILogger<WorkersController> _logger;
    public WorkersController(ILogger<WorkersController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index() => View();
}
