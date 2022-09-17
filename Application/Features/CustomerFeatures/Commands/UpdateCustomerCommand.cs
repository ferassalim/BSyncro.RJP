using MediatR;
using Domain.Entities.Users;
using Domain.Interfaces;
using Application.Common.Exceptions;

namespace Application.Features.CustomerFeatures.Commands
{
    public class UpdateCustomerCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
    }
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Guid>
    {
        // Add Domain Events automatically by using IRepositoryWithEvents
        private readonly IRepository<Customer> _repository;

        public UpdateCustomerCommandHandler(IRepository<Customer> repository) =>
            (_repository) = (repository);

        public async Task<Guid> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.Id, cancellationToken);

            _ = customer
            ?? throw new NotFoundException($"Customer { request.Id} Not Found.");

            customer.Update(request.Name, request.SureName);

            await _repository.UpdateAsync(customer, cancellationToken);

            return request.Id;
        }
    }
}
