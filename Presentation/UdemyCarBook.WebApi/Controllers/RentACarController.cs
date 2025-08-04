using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Feature.MediatR.Queries.RentACarQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRentACar(int locationId, bool available)
        {
            var values = await _mediator.Send(new GetRentACarQuery(locationId, available));
            return Ok(values);
        }

      
    }
}
