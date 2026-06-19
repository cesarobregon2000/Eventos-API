using Eventos.Applications.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Applications.Database.CrearEventos.Commands
{
    public class CrearEventoHandler : IRequestHandler<CrearEventoCommand, string>
    {
        private readonly IDatosEventosRepository datosEventos;

        public CrearEventoHandler(IDatosEventosRepository repo)
        {
            datosEventos = repo;
        }

        public async Task<string> Handle(CrearEventoCommand request, CancellationToken cancellationToken)
        {
            return await datosEventos.CrearEventos(
                request.titulo,
                request.descripcion,
                request.venue,
                request.tipo,
                request.capacidadMaxima,
                request.fechaInicio,
                request.fechaFin,
                request.Precio
                
            );
        }
    }
}
