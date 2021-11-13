namespace Frames.Web.Controllers;

public class AdminBillingController : Controller
{
    private readonly IAdminFrameService adminFrameService;
    private readonly ILogger<AdminBillingController> logger;

    public AdminBillingController(IAdminFrameService adminFrameService, ILogger<AdminBillingController> logger)
    {
        this.adminFrameService = adminFrameService;
        this.logger = logger;
    }

    [HttpGet]
    public IActionResult Index() => View();
}
