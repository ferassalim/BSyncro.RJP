using MediatR;
using Domain.Entities.Transactions;
using Domain.Interfaces;
using Application.Common.Exceptions;

namespace Application.Features.TransactionFeatures.Commands
{
    public class UpdateTransactionCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
    }
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, Guid>
    {
        // Add Domain Events automatically by using IRepositoryWithEvents
        private readonly IRepository<CustomerTransaction> _repository;

        public UpdateTransactionCommandHandler(IRepository<CustomerTransaction> repository) =>
            (_repository) = (repository);

        public async Task<Guid> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _repository.GetByIdAsync(request.Id, cancellationToken);

            _ = transaction
            ?? throw new NotFoundException($"Transaction { request.Id} Not Found.");

            transaction.Update(request.Amount);

            await _repository.UpdateAsync(transaction, cancellationToken);

            return request.Id;
        }
    }
}
