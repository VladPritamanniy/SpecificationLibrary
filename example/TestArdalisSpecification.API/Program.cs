using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore.Audit;
using Microsoft.EntityFrameworkCore;
using TestArdalisSpecification.Application.Services;
using TestArdalisSpecification.Core.Services;
using TestArdalisSpecification.Infrastructure.Data;

namespace TestArdalisSpecification.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler"; // https://localhost:7261/profiler/results-index
                options.ColorScheme = StackExchange.Profiling.ColorScheme.Dark;
            }).AddEntityFramework();

            services.AddAuditableContext<AppDbContext>((sp, options) => options
                .UseNpgsql(
                    builder.Configuration.GetConnectionString("DbConnection"),
                    b => b.MigrationsAssembly("TestArdalisSpecification.Infrastructure")));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped(typeof(IReadRepositoryBase<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IRepositoryBase<>), typeof(EfRepository<>));
            services.AddScoped<IEmployeeService, EmployeeService>();

            var app = builder.Build();
            app.UseMiniProfiler();
            var migrationTask = app.Services.MigrateDatabaseAsync();
            
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            await migrationTask;

            await app.RunAsync();
        }
    }
}
