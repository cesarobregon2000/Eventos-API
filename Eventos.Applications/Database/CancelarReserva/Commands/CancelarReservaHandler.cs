using Eventos.Applications.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Applications.Database.CancelarReserva.Commands
{
    public class CancelarReservaHandler : IRequestHandler<CancelarReservaCommand, string>
    {
        private readonly IDatosEventosRepository _repo;

        public CancelarReservaHandler(IDatosEventosRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> Handle(CancelarReservaCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CancelarReserva(request.ReservaId);
        }
    }
}
