using AutoMapper;
using Eventos.Applications.Common.Feactures;
using Eventos.Applications.Common.Interfaces;
using Eventos.Domains.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Applications.Database.ListarEventos.Queries
{
    public class ListarEventosHandler : IRequestHandler<ListarEventosQuery, Result<List<ListarEventosDTO>>>
    {
        private readonly IDatosEventosRepository datosEventos;
        private readonly IMapper _mapper;

        public ListarEventosHandler(IDatosEventosRepository datosPermiso, IMapper mapper)
        {
            datosEventos = datosPermiso;
            _mapper = mapper;
        }

        public async Task<Result<List<ListarEventosDTO>>> Handle(ListarEventosQuery request, CancellationToken cancellationToken)
        {
            var ListaEvento = await datosEventos.ListarEventos();
            if (ListaEvento.Count == 0)
                return Result<List<ListarEventosDTO>>.NotFound();
            var mapped = _mapper.Map<List<ListarEventosDTO>>(ListaEvento);
            return Result<List<ListarEventosDTO>>.Ok(mapped);
        }
    }
}
