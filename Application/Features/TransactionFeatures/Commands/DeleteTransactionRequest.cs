using Application.Common.Exceptions;
using Domain.Entities.Users;
using Domain.Interfaces;
using Domain.Entities.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TransactionFeatures.Commands
{
    public class DeleteTransactionRequest : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public DeleteTransactionRequest(Guid id) => Id = id;
    }

    public class DeleteTransactionRequestHandler : IRequestHandler<DeleteTransactionRequest, Guid>
    {
        private readonly IRepository<CustomerTransaction> _repository;

        public DeleteTransactionRequestHandler( IRepository<CustomerTransaction> repository) =>
            (_repository) = ( repository);

        public async Task<Guid> Handle(DeleteTransactionRequest request, CancellationToken cancellationToken)
        {
            var transaction = await _repository.GetByIdAsync(request.Id, cancellationToken);

            _ = transaction ?? throw new NotFoundException("Transaction {0} Not Found.");

            await _repository.DeleteAsync(transaction, cancellationToken);

            return request.Id;
        }
    }
}
