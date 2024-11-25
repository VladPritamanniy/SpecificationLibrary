using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TestArdalisSpecification.Infrastructure.Data
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task MigrateDatabaseAsync(this IServiceProvider provider)
        {
            using var scope = provider.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<AppDbContext>();
            await context.Database.MigrateAsync();
        }
    }
}
