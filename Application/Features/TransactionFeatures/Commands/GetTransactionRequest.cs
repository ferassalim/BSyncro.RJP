using Application.Common.Exceptions;
using Ardalis.Specification;
using Domain.Entities.Transactions;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TransactionFeatures.Commands
{
    public class GetTransactionRequest : IRequest<TransactionDto>
    {
        public Guid Id { get; set; }

        public GetTransactionRequest(Guid id) => Id = id;
    }
    public class TransactionByIdSpec : Specification<CustomerTransaction, TransactionDto>, ISingleResultSpecification
    {
        public TransactionByIdSpec(Guid id) =>
            Query.Where(p => p.Id == id);
    }
    public class GetTransactionRequestHandler : IRequestHandler<GetTransactionRequest, TransactionDto>
    {
        private readonly IRepository<CustomerTransaction> _repository;

        public GetTransactionRequestHandler(IRepository<CustomerTransaction> repository) => (_repository) = (repository);

        public async Task<TransactionDto> Handle(GetTransactionRequest request, CancellationToken cancellationToken) =>
            await _repository.GetBySpecAsync(
                (ISpecification<CustomerTransaction, TransactionDto>)new TransactionByIdSpec(request.Id), cancellationToken)
            ?? throw new NotFoundException($"Customer {request.Id} Not Found.");
    }
}
