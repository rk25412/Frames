namespace Frames.Web.Data;

public class SeedData
{
    public static void EnsurePopulated(IApplicationBuilder app)
    {
        AppDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

        ILogger<SeedData> logger = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<ILogger<SeedData>>();

        try
        {
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            if (!context.ItemTypes.Any())
            {
                context.ItemTypes.AddRange(
                    new ItemType("Ilet", 17, 12.5m),
                    new ItemType("Ring", 9, 7.5m),
                    new ItemType("Miki", 13, 9)
                );
            }

            if (!context.Workers.Any())
            {
                context.Workers.AddRange(
                    new Worker("Logan"),
                    new Worker("Jean"),
                    new Worker("Scott"),
                    new Worker("Kitty"),
                    new Worker("Storm")
                );
            }

            if (!context.AdminFramesIns.Any())
            {
                var rnd = new Random();
                DateTime dateTime = DateTime.Today;

                context.AdminFramesIns.AddRange(
                    new AdminFramesIn(rnd.Next(50, 100), new DateTime(dateTime.Year, dateTime.Month, rnd.Next(1, DateTime.Today.Day), rnd.Next(9, 17), rnd.Next(1, 59), 0)),
                    new AdminFramesIn(rnd.Next(50, 100), new DateTime(dateTime.Year, dateTime.Month, rnd.Next(1, DateTime.Today.Day), rnd.Next(9, 17), rnd.Next(1, 59), 0)),
                    new AdminFramesIn(rnd.Next(50, 100), new DateTime(dateTime.Year, dateTime.Month, rnd.Next(1, DateTime.Today.Day), rnd.Next(9, 17), rnd.Next(1, 59), 0)),
                    new AdminFramesIn(rnd.Next(50, 100), new DateTime(dateTime.Year, dateTime.Month, rnd.Next(1, DateTime.Today.Day), rnd.Next(9, 17), rnd.Next(1, 59), 0)),
                    new AdminFramesIn(rnd.Next(50, 100), new DateTime(dateTime.Year, dateTime.Month, rnd.Next(1, DateTime.Today.Day), rnd.Next(9, 17), rnd.Next(1, 59), 0)),
                    new AdminFramesIn(rnd.Next(50, 100), new DateTime(dateTime.Year, dateTime.Month, rnd.Next(1, DateTime.Today.Day), rnd.Next(9, 17), rnd.Next(1, 59), 0)),
                    new AdminFramesIn(rnd.Next(50, 100), new DateTime(dateTime.Year, dateTime.Month, rnd.Next(1, DateTime.Today.Day), rnd.Next(9, 17), rnd.Next(1, 59), 0)),
                    new AdminFramesIn(rnd.Next(50, 100), new DateTime(dateTime.Year, dateTime.Month, rnd.Next(1, DateTime.Today.Day), rnd.Next(9, 17), rnd.Next(1, 59), 0)),
                    new AdminFramesIn(rnd.Next(50, 100), new DateTime(dateTime.Year, dateTime.Month, rnd.Next(1, DateTime.Today.Day), rnd.Next(9, 17), rnd.Next(1, 59), 0)),
                    new AdminFramesIn(rnd.Next(50, 100), new DateTime(dateTime.Year, dateTime.Month, rnd.Next(1, DateTime.Today.Day), rnd.Next(9, 17), rnd.Next(1, 59), 0))
                );
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
        }
        finally
        {
            context.SaveChanges();
        }
    }
}
