using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Enviromments.Commands.Delete
{
    public class DeleteEnvironmentCommandValidator : AbstractValidator<DeleteEnviromentCommand>
    {
        public DeleteEnvironmentCommandValidator()
        {
            RuleFor(p => p.Id)
             .NotEmpty()
             .WithMessage("Environment Id is required");
        }
    }
}
