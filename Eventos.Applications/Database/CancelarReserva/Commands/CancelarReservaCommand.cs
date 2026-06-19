using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Applications.Database.CancelarReserva.Commands
{

    public record CancelarReservaCommand(int ReservaId) : IRequest<string>;
}
