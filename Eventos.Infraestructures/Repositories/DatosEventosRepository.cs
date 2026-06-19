using Dapper;
using Eventos.Applications.Common.Interfaces;
using Eventos.Domains.DTOs;
using Eventos.Infraestructures.Data.SQL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Eventos.Infraestructures.Repositories
{
    public class DatosEventosRepository : IDatosEventosRepository
    {
        private readonly SQLContext _context;
        private readonly IConfiguration _configuration;

        public DatosEventosRepository(SQLContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<string> CrearEventos(string titulo, string descripcion, int venue, int tipo, int capacidad, DateTime fechaInicio, DateTime fechaFin, int Precio)
        {
            using var conn = await _context.CreateConnectionAsync();

            var parameters = new DynamicParameters();

            parameters.Add("@TITULO", titulo);
            parameters.Add("@DESCRIPCION", descripcion);
            parameters.Add("@VENUE_ID", venue);
            parameters.Add("@TIPO_EVENTO_ID", tipo);
            parameters.Add("@CAPACIDAD_MAXIMA", capacidad);
            parameters.Add("@FECHA_INICIO", fechaInicio);
            parameters.Add("@FECHA_FIN", fechaFin);
            parameters.Add("@PRECIO_ENTRADA", Precio);
            await conn.ExecuteAsync(
                "PR_CREAR_EVENTO",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return "OK";
        }

        public async Task<List<ListarEventosDTO>> ListarEventos()
        {
            using var conn = await _context.CreateConnectionAsync();

            var result = await conn.QueryAsync<ListarEventosDTO>(
                "SELECT * FROM dbo.FN_LISTAR_EVENTOS()"
            );

            return result.ToList();
        }

        public async Task<List<ListarEventosDTO>> ListarEventosId(int eventoId)
        {
            using var conn = await _context.CreateConnectionAsync();

            var parameters = new DynamicParameters();
            parameters.Add("@EVENTO_ID", eventoId);

            var result = await conn.QueryAsync<ListarEventosDTO>(
                "SELECT * FROM dbo.FN_LISTAR_EVENTOS_ID(@EVENTO_ID)",
                parameters
            );

            return result.ToList();
        }
        public async Task<string> CrearReserva(int eventoId,string nombre,string email,int cantidad)
        {
            using var conn = await _context.CreateConnectionAsync();

            var parameters = new DynamicParameters();

            parameters.Add("@EVENTO_ID", eventoId);
            parameters.Add("@NOMBRE", nombre);
            parameters.Add("@EMAIL", email);
            parameters.Add("@CANTIDAD", cantidad);

            await conn.ExecuteAsync(
                "PR_CREAR_RESERVA",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return "OK";
        }
        public async Task<List<ListarReservaEventosDTO>> ListarReservasEventos(string EventoId)
        {
            using var conn = await _context.CreateConnectionAsync();

            var parameters = new DynamicParameters();
            parameters.Add("@EVENTO_ID", EventoId);
            var result = await conn.QueryAsync<ListarReservaEventosDTO>("SELECT * FROM dbo.FN_LISTAR_RESERVAS(@EVENTO_ID)",
        parameters
    );

            return result.ToList();
        }

        public async Task<List<TipoEventoDTO>> ListarTiposEvento()
        {
            using var conn = await _context.CreateConnectionAsync();

            var result = await conn.QueryAsync<TipoEventoDTO>(
                "SELECT * FROM dbo.FN_LISTAR_TIPOS_EVENTO()"
            );

            return result.ToList();
        }

        public async Task<List<VenueDTO>> ListarVenues()
        {
            using var conn = await _context.CreateConnectionAsync();

            var result = await conn.QueryAsync<VenueDTO>(
                "SELECT * FROM dbo.FN_LISTAR_VENUES()"
            );

            return result.ToList();
        }

        public async Task<string> CancelarReserva(int reservaId)
        {
            using var conn = await _context.CreateConnectionAsync();

            var parameters = new DynamicParameters();
            parameters.Add("@RESERVA_ID", reservaId);

            await conn.ExecuteAsync(
                "PR_CANCELAR_RESERVA",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return "OK";
        }

        public async Task<string> ConfirmarPago(int reservaId)
        {
            using var conn = await _context.CreateConnectionAsync();

            var parameters = new DynamicParameters();
            parameters.Add("@RESERVA_ID", reservaId);

            await conn.ExecuteAsync(
                "PR_CONFIRMAR_PAGO",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return "OK";
        }

        public async Task<List<ReporteOcupacionDTO>> ReporteEventos()
        {
            using var conn = await _context.CreateConnectionAsync();

            var result = await conn.QueryAsync<ReporteOcupacionDTO>(
                "SELECT * FROM dbo.FN_REPORTAR_OCUPACION()"
            );

            return result.ToList();
        }
    }
}
