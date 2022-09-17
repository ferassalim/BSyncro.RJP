using Application.Common.Exceptions;
using Application.Features.TransactionFeatures.Commands;
using Domain.Entities.Users;
using Domain.Interfaces;
using Domain.Entities.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CustomerFeatures.Commands
{
    public class DeleteCustomerRequest : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public DeleteCustomerRequest(Guid id) => Id = id;
    }

    public class DeleteCustomerRequestHandler : IRequestHandler<DeleteCustomerRequest, Guid>
    {
        // Add Domain Events automatically by using IRepositoryWithEvents
        private readonly IRepository<Customer> _customerRepo;
        private readonly IRepository<CustomerTransaction> _transactionRepo;

        public DeleteCustomerRequestHandler(IRepository<Customer> CustomerRepo, IRepository<CustomerTransaction> productRepo) =>
            (_customerRepo, _transactionRepo) = (CustomerRepo, productRepo);

        public async Task<Guid> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            if (await _transactionRepo.AnyAsync(new TransactionByCustomerSpec(request.Id), cancellationToken))
            {
                throw new ConflictException("Customer cannot be deleted as it's being used.");
            }

            var Customer = await _customerRepo.GetByIdAsync(request.Id, cancellationToken);

            _ = Customer ?? throw new NotFoundException("Customer {0} Not Found.");

            await _customerRepo.DeleteAsync(Customer, cancellationToken);

            return request.Id;
        }
    }
}
