using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Commands.ReservationCommands;
using UdemyCarBook.Dto.ReservationDtos;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReservationController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand createReservationCommand)
        {
           await  mediator.Send(createReservationCommand);
            return Ok("Reservation created successfully");
        }
    }
}
