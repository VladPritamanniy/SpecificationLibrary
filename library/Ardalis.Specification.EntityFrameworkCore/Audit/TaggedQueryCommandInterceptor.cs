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
            await ManipulateCommand(command);

            return result;
        }

        private static async Task ManipulateCommand(DbCommand command)
        {
            // TODO: Implement the ManipulateCommand method
        }
    }
}
