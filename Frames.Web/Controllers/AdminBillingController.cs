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
    public IActionResult Index() => View(); // For Frames In

    [HttpPost]
    public async Task<IActionResult> GetData(int month, int year)
    {
        (string draw, string start, string length, string sortColumn, string sortColumnDirection, string searchValue) = ExtractTableData();

        Query query = new();

        DateTime date = new DateTime(year, month, 1);

        // Sorting
        if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
            query.OrderBy = sortColumn + " " + sortColumnDirection;

        // setting skip
        if (!string.IsNullOrEmpty(start))
            query.Skip = Convert.ToInt32(start);

        // setting take
        if (!string.IsNullOrEmpty(length))
            query.Top = Convert.ToInt32(length) > 0 ? Convert.ToInt32(length) : null;

        query.Filter = $"x => x.Date >= DateTime.Parse(\"{date}\") && x.Date < DateTime.Parse(\"{date.AddMonths(1)}\")";
        try
        {
            var dataFromDb = await adminFrameService.GetAllAdminFramesIn(query);

            List<AdminFramesInResponseDto> returnData = new();

            foreach (var data in dataFromDb)
            {
                if (!returnData.Any(x => x.Date.Equals(DateOnly.FromDateTime(data.Date).ToString())))
                    returnData.Add(new(DateOnly.FromDateTime(data.Date).ToString()));

                returnData.FirstOrDefault(x =>
                    x.Date.Equals(DateOnly.FromDateTime(data.Date).ToString())).Total += data.NoOfFrames;
                returnData.FirstOrDefault(x =>
                    x.Date.Equals(DateOnly.FromDateTime(data.Date).ToString())).TimeAndNo.Add(new(data.Id, TimeOnly.FromDateTime(data.Date).ToString(), data.NoOfFrames));
            }

            return Json(new DatatableDto(draw, returnData.Count, returnData.Count, returnData.OrderBy(x => x.Date)));
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    private (string, string, string, string, string, string) ExtractTableData()
    {
        var draw = Request.Form["draw"].FirstOrDefault() ?? "";

        // Skiping number of Rows count  
        var start = Request.Form["start"].FirstOrDefault() ?? "";

        // Paging Length 10,20  
        var length = Request.Form["length"].FirstOrDefault() ?? "";

        // Sort Column Name  
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() ?? "" + "][name]"].FirstOrDefault() ?? "";

        // Sort Column Direction (asc ,desc)  
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault() ?? "";

        // Search Value from (Search box)  
        var searchValue = Request.Form["search[value]"].FirstOrDefault() ?? "";

        return (draw, start, length, sortColumn, sortColumnDirection, searchValue);
    }

}
