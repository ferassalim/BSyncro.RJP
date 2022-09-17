
using Ardalis.Specification;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T>
    where T : class, IAggregateRoot
    {

    }
}
