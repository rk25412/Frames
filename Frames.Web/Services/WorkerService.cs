namespace Frames.Web.Services;

public class WorkerService : IWorkerService
{
    private readonly AppDbContext context;
    
    public WorkerService(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<IQueryable<Worker>> GetWorkers(Query query = null)
    {
        var items = context.Workers.AsQueryable();

        if (query is not null)
        {
            if (!string.IsNullOrEmpty(query.Filter))
                items = items.Where(query.Filter);

            if (!string.IsNullOrEmpty(query.OrderBy))
                items = items.OrderBy(query.OrderBy);

            if (!string.IsNullOrEmpty(query.Expand))
            {
                var propertiesToExpand = query.Expand.Split(',');
                foreach (var p in propertiesToExpand)
                    items = items.Include(p);
            }

            if (query.Skip.HasValue)
                items = items.Skip(query.Skip.Value);

            if (query.Top.HasValue)
                items = items.Take(query.Top.Value);
        }

        return await Task.FromResult(items);
    }
    public async Task<Worker> GetWorker(int id, Query query = null)
    {
        var items = context.Workers.AsNoTracking().Where(x => x.Id == id);

        if (query is not null)
        {
            if (!string.IsNullOrEmpty(query.Filter))
                items = items.Where(query.Filter);

            if (!string.IsNullOrEmpty(query.OrderBy))
                items = items.OrderBy(query.OrderBy);

            if (!string.IsNullOrEmpty(query.Expand))
            {
                var propertiesToExpand = query.Expand.Split(',');
                foreach (var p in propertiesToExpand)
                    items = items.Include(p);
            }

            if (query.Skip.HasValue)
                items = items.Skip(query.Skip.Value);

            if (query.Top.HasValue)
                items = items.Take(query.Top.Value);
        }

        var item = await items.FirstOrDefaultAsync();

        return await Task.FromResult(item);
    }
    public async Task<Worker> AddWorker(Worker worker)
    {
        using (var transaction = await context.Database.BeginTransactionAsync())
        {
            try
            {
                await context.Workers.AddAsync(worker);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }

        return worker;
    }
    public async Task<Worker> UpdateWorker(Worker worker)
    {
        var item = await context.Workers.FindAsync(worker.Id);

        if (item is null)
            throw new Exception("Item no longer available");
        
        var entry = context.Entry(item);
        entry.CurrentValues.SetValues(worker);
        entry.State = EntityState.Modified;
        await context.SaveChangesAsync();

        return worker;
    }
    public async Task<Worker> DeleteWorker(int workerId)
    {
        var item = await context.Workers.FindAsync(workerId);
        if (item is null)
            throw new Exception("Item no longer available");

        context.Workers.Remove(item);

        try
        {
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            context.Entry(item).State = EntityState.Unchanged;
            throw ex;
        }

        return item;
    }
    public async Task<int> GetTotalCount() =>
        await context.Workers.CountAsync();
    public async Task<bool> DoesWorkerExists(string name) => 
        await context.Workers.AnyAsync(x => x.Name.ToUpper() == name.ToUpper());
}
