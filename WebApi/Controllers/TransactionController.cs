using Application.Features.TransactionFeatures.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : BaseApiController
    {


        [HttpGet("{id:guid}")]
        public Task<TransactionDto> GetAsync(Guid id)
        {
            return Mediator.Send(new GetTransactionRequest(id));
        }

        [HttpPost]
        public Task<Guid> CreateAsync(CreateTransactionCommand request)
        {
            return Mediator.Send(request);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateAsync(UpdateTransactionCommand request, Guid id)
        {
            return id != request.Id
                ? BadRequest()
                : Ok(await Mediator.Send(request));
        }

        [HttpDelete("{id:guid}")]
        public Task<Guid> DeleteAsync(Guid id)
        {
            return Mediator.Send(new DeleteTransactionRequest(id));
        }


    }
}
