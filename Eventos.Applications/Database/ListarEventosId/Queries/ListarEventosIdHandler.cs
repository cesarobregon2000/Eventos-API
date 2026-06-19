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

namespace Eventos.Applications.Database.ListarEventosId.Queries
{
    

    public class ListarEventosIdHandler : IRequestHandler<ListarEventosIdQuery, Result<List<ListarEventosDTO>>>
    {
        private readonly IDatosEventosRepository datosEventos;
        private readonly IMapper _mapper;

        public ListarEventosIdHandler(IDatosEventosRepository datosPermiso, IMapper mapper)
        {
            datosEventos = datosPermiso;
            _mapper = mapper;
        }

        public async Task<Result<List<ListarEventosDTO>>> Handle(ListarEventosIdQuery request, CancellationToken cancellationToken)
        {
            var ListaEvento = await datosEventos.ListarEventosId(request.EventoId);
            if (ListaEvento.Count == 0)
                return Result<List<ListarEventosDTO>>.NotFound();
            var mapped = _mapper.Map<List<ListarEventosDTO>>(ListaEvento);
            return Result<List<ListarEventosDTO>>.Ok(mapped);
        }
    }
}
