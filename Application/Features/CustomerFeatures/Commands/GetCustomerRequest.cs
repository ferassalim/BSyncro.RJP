using Application.Common.Exceptions;
using Application.Features.TransactionFeatures.Commands;
using Ardalis.Specification;
using Domain.Entities.Transactions;
using Domain.Entities.Users;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CustomerFeatures.Commands
{
    public class GetCustomerRequest : IRequest<CustomerDto>
    {
        public Guid Id { get; set; }

        public GetCustomerRequest(Guid id) => Id = id;
    }
    public class CustomerByIdSpec : Specification<Customer, CustomerDto>, ISingleResultSpecification
    {
        public CustomerByIdSpec(Guid id) =>
            Query.Where(p => p.Id == id);
    }
    public class GetCustomerRequestHandler : IRequestHandler<GetCustomerRequest, CustomerDto>
    {
        private readonly IRepository<Customer> _repository;
        private readonly IRepository<CustomerTransaction> _transactionRepository;

        public GetCustomerRequestHandler(IRepository<Customer> repository, IRepository<CustomerTransaction> transactionRepository) => (_repository, _transactionRepository) = (repository,transactionRepository);

        public async Task<CustomerDto> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
           var cusomter =  await _repository.GetBySpecAsync(
                (ISpecification<Customer, CustomerDto>)new CustomerByIdSpec(request.Id), cancellationToken)
            ?? throw new NotFoundException($"Customer {request.Id} Not Found.");
            cusomter.Transactions = (await _transactionRepository.ListAsync((ISpecification<CustomerTransaction, TransactionDto>)new TransactionByCustomerSpec(request.Id),cancellationToken));
            return cusomter;
        }
    }
}
