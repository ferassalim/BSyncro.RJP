using MediatR;
using Domain.Entities.Users;
using Domain.Interfaces;

namespace Application.Features.CustomerFeatures.Commands
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string SureName { get;  set; }
        public decimal InitialCredit { get;  set; }

    }
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly IRepository<Customer> _repository;

        public CreateCustomerCommandHandler(IRepository<Customer> repository) =>
            (_repository) = (repository);

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Name, request.SureName);

            
            await _repository.AddAsync(customer, cancellationToken);
           
            return customer.Id;
        }
    }
}
