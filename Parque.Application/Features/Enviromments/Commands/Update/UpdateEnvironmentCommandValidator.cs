using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Enviromments.Commands.Update
{
    public class UpdateEnvironmentCommandValidator : AbstractValidator<UpdateEnviromentCommand>
    {
        public UpdateEnvironmentCommandValidator()
        {
            RuleFor(p => p.Id)
             .NotEmpty()
             .WithMessage("Environment Id is required");
            RuleFor(p => p.Title)
             .NotEmpty()
             .WithMessage("The Title of the environment is required")
             .Length(2, 250)
             .WithMessage("The environment title does not comply with the required extension, minimum 2 and maximum 250 characters");
            RuleFor(p => p.Description)
             .NotEmpty()
             .WithMessage("The Description of the environment is required")
             .Length(10, 450)
             .WithMessage("The environment Description does not comply with the required extension, minimum 10 and maximum 450 characters");
            RuleFor(p => p.DocumentRoute)
             .NotEmpty()
             .WithMessage("DocumentRoute is required")
             .Length(1, 280)
             .WithMessage("DocumentRoute does not comply with the required extension, minimum 1 and maximum 280 characters");
        }
    }
}
