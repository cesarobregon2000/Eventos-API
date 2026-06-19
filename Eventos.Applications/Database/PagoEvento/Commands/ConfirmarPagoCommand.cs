using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Applications.Database.PagoEvento.Commands
{
    public record ConfirmarPagoCommand(int ReservaId) : IRequest<string>;
}
