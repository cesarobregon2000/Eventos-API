using Asp.Versioning;
using Eventos.Applications.Database.CancelarReserva.Commands;
using Eventos.Applications.Database.CrearReserva.Commands;
using Eventos.Applications.Database.ListarEventos.Queries;
using Eventos.Domains.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eventos.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/Reservas")]
    [ApiController]
    public class ReservasController :  ControllerBase
    {
        private readonly ISender _sender;
    public ReservasController(ISender sender)
    {
        _sender = sender;
    }

        [AllowAnonymous]
        [HttpPost("Crear-Reserva")]
        public async Task<IActionResult> CrearReserva(
    [FromBody] CrearReservaDTO request)
        {
            var result = await _sender.Send(
                new CrearReservaCommand(
                    request.EVENTO_ID,
                    request.NOMBRE,
                    request.EMAIL,
                    request.CANTIDAD
                ));

            return Ok(new { result });
        }

        [AllowAnonymous]
        [HttpGet("Listar-Reservas/{EventoId}")]
        public async Task<IActionResult> ObtenerListaEvento(string EventoId)
        {
            var result = await _sender.Send(new ListarReservasQuery(EventoId));

            if (result.IsNotFound)
                return NotFound(new { message = result.Message });

            if (result.IsError)
                return BadRequest(new { message = result.Message, errors = result.Errors });

            return Ok(result);
        }

        [HttpPost("cancelar-reserva/{id}")]
        public async Task<IActionResult> Cancelar(int id)
        {
            var result = await _sender.Send(new CancelarReservaCommand(id));

            return Ok(new { result });
        }

    }
}
