using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Applications.Database.CrearReserva.Commands
{
    public record CrearReservaCommand(
    int EventoId,
    string Nombre,
    string Email,
    int Cantidad
) : IRequest<string>;

}
