
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Domain.Common;
using Domain.Interfaces;
using Mapster;
using Persistence.Context;

namespace Persistence.Repository
{
    public class ApplicationDbRepository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public ApplicationDbRepository(ApplicationDbContext dbContext)
       : base(dbContext)
        {
        }
        protected override IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification) =>
        specification.Selector is not null
            ? base.ApplySpecification(specification)
            : ApplySpecification(specification, false)
                .ProjectToType<TResult>();
    }
}
