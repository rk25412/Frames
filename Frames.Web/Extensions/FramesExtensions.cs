using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Frames.Web.Extensions;

public static class FramesExtensions
{
    public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b =>
                b.MigrationsAssembly("Frames.Web")));
}
