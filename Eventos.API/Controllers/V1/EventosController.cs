using Asp.Versioning;
using Eventos.Applications.Database.CrearEventos.Commands;
using Eventos.Applications.Database.CrearReserva.Commands;
using Eventos.Applications.Database.ListarEventos.Queries;
using Eventos.Applications.Database.ListarEventosId.Queries;
using Eventos.Applications.Database.ListarTipoEvento.Queries;
using Eventos.Applications.Database.ListarVenues.Queries;
using Eventos.Applications.Database.PagoEvento.Commands;
using Eventos.Applications.Database.Reporte.Queries;
using Eventos.Domains.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/Eventos")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly ISender _sender;
        public EventosController(ISender sender)
        {
            _sender = sender;
        }

       

        [AllowAnonymous]
        [HttpPost("Crear-Evento")]
        public async Task<IActionResult> CrearEventos(
  [FromBody] CrearEventoDTO request)
        {

            var result = await _sender.Send(
                new CrearEventoCommand(
                    request.TITULO,
                    request.DESCRIPCION,
                    request.VENUE,
                    request.TIPO_EVENTO_ID,
                    request.CAPACIDAD_MAXIMA,
                     request.FECHA_INICIO,
                    request.FECHA_FIN,
                    request.PRECIO_ENTRADA

                ));

            return Ok(new { result });
        }

        [AllowAnonymous]
        [HttpGet("Listar-Eventos")]
        public async Task<IActionResult> ObtenerListaEvento()
        {
            var result = await _sender.Send(new ListarEventosQuery());

            if (result.IsNotFound)
                return NotFound(new { message = result.Message });

            if (result.IsError)
                return BadRequest(new { message = result.Message, errors = result.Errors });

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("Listar-Eventos-Id/{EventoId}")]
        public async Task<IActionResult> ObtenerListaEventoId(int EventoId)
        {
            var result = await _sender.Send(new ListarEventosIdQuery(EventoId));

            if (result.IsNotFound)
                return NotFound(new { message = result.Message });

            if (result.IsError)
                return BadRequest(new { message = result.Message, errors = result.Errors });

            return Ok(result);

        }
        [AllowAnonymous]
        [HttpGet("Listar-Tipo-Evento/")]
        public async Task<IActionResult> ObtenerListaTipoEvento()
        {
            var result = await _sender.Send(new TipoEventoQuery());

            if (result.IsNotFound)
                return NotFound(new { message = result.Message });

            if (result.IsError)
                return BadRequest(new { message = result.Message, errors = result.Errors });

            return Ok(result);
        }


        [AllowAnonymous]
        [HttpGet("listar-venues")]
            public async Task<IActionResult> Listar()
            {
            var result = await _sender.Send(new ListarVenuesQuery());

            if (result.IsNotFound)
                return NotFound(new { message = result.Message });

            if (result.IsError)
                return BadRequest(new { message = result.Message, errors = result.Errors });

            return Ok(result);
        }

        [HttpPut("confirmar-pago/{id}")]
        public async Task<IActionResult> ConfirmarPago(int id)
        {
            var result = await _sender.Send(new ConfirmarPagoCommand(id));

            return Ok(new { result });
        }

        [AllowAnonymous]
        [HttpGet("reporte-eventos")]
        public async Task<IActionResult> reporte()
        {
            var result = await _sender.Send(new ReporteQuery());

            if (result.IsNotFound)
                return NotFound(new { message = result.Message });

            if (result.IsError)
                return BadRequest(new { message = result.Message, errors = result.Errors });

            return Ok(result);
        }
    }
}
