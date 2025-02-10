using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace Ardalis.Specification.EntityFrameworkCore.Audit
{
    public class TaggedQueryCommandInterceptor : DbCommandInterceptor
    {
        public override async ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result,
            CancellationToken cancellationToken = default)
        {
            return result; // TODO: Implement the method
        }
    }
}
