namespace Frames.Web.Services;

public class AdminFrameService : IAdminFrameService
{
    private readonly AppDbContext context;

    public AdminFrameService(AppDbContext context)
    {
        this.context = context;
    }

    #region AdminFramesIn
    public async Task<IQueryable<AdminFramesIn>> GetAllAdminFramesIn(Query query = null)
    {
        var items = context.AdminFramesIns.AsQueryable();

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
    public async Task<AdminFramesIn> GetAdminFramesIn(int id, Query query = null)
    {
        var items = context.AdminFramesIns.AsNoTracking().Where(x => x.Id == id);

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
    public async Task<AdminFramesIn> AddAdminFramesIn(AdminFramesIn adminFramesIn)
    {
        using (var transaction = await context.Database.BeginTransactionAsync())
        {
            try
            {
                await context.AdminFramesIns.AddAsync(adminFramesIn);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex;
            }
        }

        return adminFramesIn;
    }
    public async Task<AdminFramesIn> UpdateAdminFramesIn(AdminFramesIn adminFramesIn)
    {
        var item = await context.AdminFramesIns.FindAsync(adminFramesIn.Id);
        
        if (item is null)
            throw new Exception("Item no longer available");
        try
        {
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(adminFramesIn);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            context.Entry(item).State = EntityState.Unchanged;
            throw ex;
        }
        return adminFramesIn;
    }
    public async Task<AdminFramesIn> DeleteAdminFramesIn(int adminFrameInId)
    {
        var item = await context.AdminFramesIns.FindAsync(adminFrameInId);

        if (item is null)
            throw new Exception("Item no longer available");

        context.AdminFramesIns.Remove(item);

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

    #endregion
}
