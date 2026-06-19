using Eventos.Applications.Database.CrearReserva.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Applications.Validators
{
    public class CrearReservaValidator : AbstractValidator<CrearReservaCommand>
    {
        public CrearReservaValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("El correo electrónico no tiene un formato válido");

            RuleFor(x => x.EventoId)
                .GreaterThan(0);

            RuleFor(x => x.Cantidad)
                .GreaterThan(0)
                .WithMessage("La cantidad debe ser mayor a cero");
        }
    }
}
