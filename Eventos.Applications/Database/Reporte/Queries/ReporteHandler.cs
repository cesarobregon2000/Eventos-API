using AutoMapper;
using Eventos.Applications.Common.Feactures;
using Eventos.Applications.Common.Interfaces;
using Eventos.Applications.Database.ListarVenues.Queries;
using Eventos.Domains.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Applications.Database.Reporte.Queries
{
  

    public class ReporteHandler : IRequestHandler<ReporteQuery, Result<List<ReporteOcupacionDTO>>>
    {
        private readonly IDatosEventosRepository datosEventos;
        private readonly IMapper _mapper;

        public ReporteHandler(IDatosEventosRepository datosPermiso, IMapper mapper)
        {
            datosEventos = datosPermiso;
            _mapper = mapper;
        }

        public async Task<Result<List<ReporteOcupacionDTO>>> Handle(ReporteQuery request, CancellationToken cancellationToken)
        {
            var Reporte = await datosEventos.ReporteEventos();
            if (Reporte.Count == 0)
                return Result<List<ReporteOcupacionDTO>>.NotFound();
            var mapped = _mapper.Map<List<ReporteOcupacionDTO>>(Reporte);
            return Result<List<ReporteOcupacionDTO>>.Ok(mapped);
        }
    }
}
