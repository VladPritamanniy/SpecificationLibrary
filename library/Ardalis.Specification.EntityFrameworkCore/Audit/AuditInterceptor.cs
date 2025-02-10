using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ardalis.Specification.EntityFrameworkCore.Audit
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        private readonly ISavingChangesHandler _savingChangesHandler;

        public AuditInterceptor(ISavingChangesHandler savingChangesHandler)
        {
            _savingChangesHandler = savingChangesHandler;
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            if (eventData.Context is not null)
            {
                await _savingChangesHandler.UpdateAuditableEntities(eventData.Context);
            }

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            if (eventData.Context is not null)
            {
                _savingChangesHandler.UpdateAuditableEntities(eventData.Context);
            }

            return base.SavingChanges(eventData, result);
        }
    }
}
