using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ardalis.Specification.EntityFrameworkCore.Audit
{
    public static class AuditMiddleware
    {
        public static IServiceCollection AddAuditableContext<TContext>(this IServiceCollection services, Action<IServiceProvider, DbContextOptionsBuilder> dbOptionsAction) where TContext : DbContext
        {
            dbOptionsAction += (sp, options) => options.AddInterceptors(sp.GetRequiredService<AuditInterceptor>());
            services.AddDbContext<TContext>(dbOptionsAction);

            services.AddScoped<ISavingChangesHandler, SavingChangesHandler>();
            services.AddScoped<AuditInterceptor>();
            return services;
        }
    }
}