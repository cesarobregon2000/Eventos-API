using Eventos.Applications.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Applications.Database.CrearReserva.Commands
{
    public class CrearReservaHandler : IRequestHandler<CrearReservaCommand, string>
    {
        private readonly IDatosEventosRepository _repo;

        public CrearReservaHandler(IDatosEventosRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> Handle(
            CrearReservaCommand request,
            CancellationToken cancellationToken)
        {
            return await _repo.CrearReserva(
                request.EventoId,
                request.Nombre,
                request.Email,
                request.Cantidad
            );
        }
    }
}
