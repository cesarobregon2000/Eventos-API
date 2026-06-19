using AutoMapper;
using Eventos.Applications.Common.Feactures;
using Eventos.Applications.Common.Interfaces;
using Eventos.Applications.Database.ListarTipoEvento.Queries;
using Eventos.Domains.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Applications.Database.ListarVenues.Queries
{
   
    public class ListarVenuesHandler : IRequestHandler<ListarVenuesQuery, Result<List<VenueDTO>>>
    {
        private readonly IDatosEventosRepository datosEventos;
        private readonly IMapper _mapper;

        public ListarVenuesHandler(IDatosEventosRepository datosPermiso, IMapper mapper)
        {
            datosEventos = datosPermiso;
            _mapper = mapper;
        }

        public async Task<Result<List<VenueDTO>>> Handle(ListarVenuesQuery request, CancellationToken cancellationToken)
        {
            var ListaVenues = await datosEventos.ListarVenues();
            if (ListaVenues.Count == 0)
                return Result<List<VenueDTO>>.NotFound();
            var mapped = _mapper.Map<List<VenueDTO>>(ListaVenues);
            return Result<List<VenueDTO>>.Ok(mapped);
        }
    }
}