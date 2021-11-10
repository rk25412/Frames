namespace Frames.Web.Data;

public class SeedData
{
    public static void EnsurePopulated(IApplicationBuilder app)
    {
        AppDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

        if (context.Database.GetPendingMigrations().Any())
            context.Database.Migrate();

        if (!context.Workers.Any())
        {
            context.Workers.AddRange(
                new Worker { Name = "Logan" },
                new Worker { Name = "Jean" },
                new Worker { Name = "Scott" },
                new Worker { Name = "Kitty" },
                new Worker { Name = "Storm" }
            );

            context.SaveChanges();
        }
    }
}
