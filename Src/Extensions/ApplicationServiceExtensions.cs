using courses_dotnet_api.Src.Data;
using courses_dotnet_api.Src.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace courses_dotnet_api.Src.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IStudentRepository, StudentRepository>();

        return services;
    }
}
