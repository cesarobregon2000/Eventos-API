using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Applications.Database.CrearEventos.Commands
{
   

    public record CrearEventoCommand(string titulo, string descripcion, int venue, int tipo, int capacidadMaxima, DateTime fechaInicio, DateTime fechaFin, int Precio)
: IRequest<string>;
}
