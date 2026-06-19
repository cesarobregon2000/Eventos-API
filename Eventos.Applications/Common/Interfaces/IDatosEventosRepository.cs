using Eventos.Applications.Common.Behaviours;
using Eventos.Domains.DTOs;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Applications.Common.Interfaces
{
    public interface IDatosEventosRepository
    {
        Task<string> CrearEventos(string titulo, string descripcion, int venue, int tipo, int capacidad, DateTime fechaInicio, DateTime fechaFin, int Precio);
        Task<List<ListarEventosDTO>> ListarEventos();
        Task<List<ListarEventosDTO>> ListarEventosId(int eventoId);
        Task<string> CrearReserva(int eventoId, string nombre, string email, int cantidad);
        Task<List<ListarReservaEventosDTO>> ListarReservasEventos(string EventoId);
        Task<List<TipoEventoDTO>> ListarTiposEvento();
        Task<List<VenueDTO>> ListarVenues();
        Task<string> CancelarReserva(int reservaId);
        Task<string> ConfirmarPago(int reservaId);
        Task<List<ReporteOcupacionDTO>> ReporteEventos();
    }
}
