using Ardalis.Specification.Audit;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Ardalis.Specification.EntityFrameworkCore.Audit
{
    public class SavingChangesHandler: ISavingChangesHandler
    {
        public async Task UpdateAuditableEntities(DbContext eventDataContext)
        {
            var entities = eventDataContext.ChangeTracker.Entries<IAuditable>()
                .Where(e => e.State != EntityState.Detached && e.State != EntityState.Unchanged)
                .ToList();

            foreach (var entity in entities)
            {
                await AddAuditEntryAsync(entity, eventDataContext);
            }
        }

        public async Task AddAuditEntryAsync(EntityEntry<IAuditable> entity, DbContext context)
        {
            DateTime utcNow = DateTime.UtcNow;

            var auditEntry = new Audits
            {
                Id = Guid.NewGuid(),
                Type = entity.State.ToString(),
                Sql = "sql",
                CreatedAt = entity.State == EntityState.Added ? utcNow : null,
                ModifiedAt = entity.State == EntityState.Added ? null : utcNow,
            };

            await context.Set<Audits>().AddAsync(auditEntry);
        }
    }
}
