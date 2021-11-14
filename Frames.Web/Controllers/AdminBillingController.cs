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

    [HttpPost]
    public void GetData(int month, int year)
    {
        (string draw, string start, string length, string sortColumn, string sortColumnDirection, string searchValue) = ExtractTableData();

        Query query = new();

        //Sorting
        if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
            query.OrderBy = sortColumn + " " + sortColumnDirection;

        // setting skip
        if (!string.IsNullOrEmpty(start))
            query.Skip = Convert.ToInt32(start);

        // setting take
        if (!string.IsNullOrEmpty(length))
            query.Top = Convert.ToInt32(length);

        DateTime date = new DateTime(1, month, year);

        
    }

    private (string, string, string, string, string, string) ExtractTableData()
    {
        var draw = Request.Form["draw"].FirstOrDefault();

        // Skiping number of Rows count  
        var start = Request.Form["start"].FirstOrDefault();

        // Paging Length 10,20  
        var length = Request.Form["length"].FirstOrDefault();

        // Sort Column Name  
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

        // Sort Column Direction (asc ,desc)  
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

        // Search Value from (Search box)  
        var searchValue = Request.Form["search[value]"].FirstOrDefault();

        return (draw, start, length, sortColumn, sortColumnDirection, searchValue);
    }

}
