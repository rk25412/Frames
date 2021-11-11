using Microsoft.AspNetCore.Mvc;

namespace Frames.Web.Controllers;

public class WorkersController : Controller
{
    private readonly IWorkerService workerService;
    private readonly ILogger<WorkersController> _logger;
    public WorkersController(IWorkerService workerService, ILogger<WorkersController> logger)
    {
        this.workerService = workerService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index() => View();

    [HttpPost]
    public async Task<IActionResult> GetAllWorkers()
    {
        try
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

            // setting search
            if (!string.IsNullOrEmpty(searchValue))
                query.Filter = $"i => i.Name.ToUpper().Contains(\"{searchValue.ToUpper()}\")";

            int recordsTotal = await workerService.GetTotalCount();

            var data = await workerService.GetWorkers(query);

            return Json(new DatatableDto(draw, recordsTotal, data.Count(), data));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> IsWorkersNameTaken(string name)
    {
        if (string.IsNullOrEmpty(name))
            return BadRequest("Name cannot be empty");

        try
        {
            var exists = await workerService.DoesWorkerExists(name);
            return Ok(exists);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrUpdateWorker([FromBody] CreateWorkerDto workerDto)
    {
        try
        {
            Worker worker;

            if (workerDto.Id <= 0)
            {
                worker = await workerService.AddWorker(new()
                {
                    Id = workerDto.Id,
                    Name = workerDto.Name
                });

                return Ok(worker);
            }
            else
            {
                worker = await workerService.UpdateWorker(new()
                {
                    Id = workerDto.Id,
                    Name = workerDto.Name
                });

                return Ok(workerDto);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetOneWorkerDetails(int workerId)
    {
        if (workerId <= 0)
            return BadRequest("workerId is required");

        try
        {
            var resoponse = await workerService.GetWorker(workerId);
            return Ok(resoponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> DeleteWorker(int workerId)
    {
        if (workerId <= 0)
            return BadRequest("workerId is required");

        try
        {
            var deletedWorker = await workerService.DeleteWorker(workerId);
            return Ok(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
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
