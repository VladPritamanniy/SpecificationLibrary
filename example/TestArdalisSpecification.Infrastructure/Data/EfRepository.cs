using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;

namespace TestArdalisSpecification.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepositoryBase<T>, IRepositoryBase<T> where T : class
    {
        public EfRepository(AppDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
