using Microsoft.EntityFrameworkCore;

namespace Ardalis.Specification.EntityFrameworkCore.Audit
{
    public interface ISavingChangesHandler
    {
        Task UpdateAuditableEntities(DbContext eventDataContext);
    }
}
