using Eventos.Applications.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Applications.Database.PagoEvento.Commands
{
    public class ConfirmarPagoHandler : IRequestHandler<ConfirmarPagoCommand, string>
    {
        private readonly IDatosEventosRepository _repo;

        public ConfirmarPagoHandler(IDatosEventosRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> Handle(ConfirmarPagoCommand request, CancellationToken cancellationToken)
        {
            return await _repo.ConfirmarPago(request.ReservaId);
        }
    }
}
