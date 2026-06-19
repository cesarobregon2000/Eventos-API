using AutoMapper;
using Eventos.Applications.Common.Feactures;
using Eventos.Applications.Common.Interfaces;
using Eventos.Applications.Database.ListarEventos.Queries;
using Eventos.Domains.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Applications.Database.ListarReservas.Queries
{
    public class ListarReservasHandler : IRequestHandler<ListarReservasQuery, Result<List<ListarReservaEventosDTO>>>
    {
        private readonly IDatosEventosRepository datosEventos;
        private readonly IMapper _mapper;

        public ListarReservasHandler(IDatosEventosRepository datosPermiso, IMapper mapper)
        {
            datosEventos = datosPermiso;
            _mapper = mapper;
        }

        public async Task<Result<List<ListarReservaEventosDTO>>> Handle(ListarReservasQuery request, CancellationToken cancellationToken)
        {
            var ListaReserva = await datosEventos.ListarReservasEventos(request.EventoId);
            if (ListaReserva.Count == 0)
                return Result<List<ListarReservaEventosDTO>>.NotFound();
            var mapped = _mapper.Map<List<ListarReservaEventosDTO>>(ListaReserva);
            return Result<List<ListarReservaEventosDTO>>.Ok(mapped);
        }
    }
}
