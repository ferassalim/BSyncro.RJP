using Application.Features.CustomerFeatures.Commands;
using Application.Features.TransactionFeatures.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseApiController
    {
 

        [HttpGet("{id:guid}")]
        public Task<CustomerDto> GetAsync(Guid id)
        {
            return Mediator.Send(new GetCustomerRequest(id));
        }

        [HttpPost]
        public async Task<Guid> CreateAsync(CreateCustomerCommand request)
        {
            var customerId=await Mediator.Send(request);
            if (request.InitialCredit != 0)
            {
                await Mediator.Send(new CreateTransactionCommand { Amount = request.InitialCredit, CustomerId = customerId });
            }
            return customerId;
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateAsync(UpdateCustomerCommand request, Guid id)
        {
            return id != request.Id
                ? BadRequest()
                : Ok(await Mediator.Send(request));
        }

        [HttpDelete("{id:guid}")]
        public Task<Guid> DeleteAsync(Guid id)
        {
            return Mediator.Send(new DeleteCustomerRequest(id));
        }

    }
}
