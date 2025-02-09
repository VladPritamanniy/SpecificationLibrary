using Ardalis.Specification.Audit;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Ardalis.Specification.EntityFrameworkCore.Audit
{
    public class SavingChangesHandler : ISavingChangesHandler
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

             var json = entity.State == EntityState.Added
                ? JsonConvert.SerializeObject(
                    entity.CurrentValues.Properties
                        .Where(p => entity.Metadata.FindPrimaryKey()!.Properties.Any(pk => pk.Name != p.Name))
                        .ToDictionary(p => p.Name, p => entity.CurrentValues[p]))
                : entity.State == EntityState.Modified
                    ? JsonConvert.SerializeObject(entity.CurrentValues.Properties.ToDictionary(p => p.Name, p => entity.CurrentValues[p]))
                    : null!;

            var auditEntry = new Audits
            {
                Id = Guid.NewGuid(),
                Type = entity.State.ToString(),
                EntityName = entity.Entity.GetType().Name,
                Json = json,
                CreatedAt = entity.State == EntityState.Added ? utcNow : null,
                ModifiedAt = entity.State == EntityState.Added ? null : utcNow,
            };

            await context.Set<Audits>().AddAsync(auditEntry);
        }
    }
}
