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

namespace Eventos.Applications.Database.ListarTipoEvento.Queries
{
    public class TipoEventoHandler : IRequestHandler<TipoEventoQuery, Result<List<TipoEventoDTO>>>
    {
        private readonly IDatosEventosRepository datosEventos;
        private readonly IMapper _mapper;

        public TipoEventoHandler(IDatosEventosRepository datosPermiso, IMapper mapper)
        {
            datosEventos = datosPermiso;
            _mapper = mapper;
        }

        public async Task<Result<List<TipoEventoDTO>>> Handle(TipoEventoQuery request, CancellationToken cancellationToken)
        {
            var ListaTipoEvento = await datosEventos.ListarTiposEvento();
            if (ListaTipoEvento.Count == 0)
                return Result<List<TipoEventoDTO>>.NotFound();
            var mapped = _mapper.Map<List<TipoEventoDTO>>(ListaTipoEvento);
            return Result<List<TipoEventoDTO>>.Ok(mapped);
        }
    }
}
