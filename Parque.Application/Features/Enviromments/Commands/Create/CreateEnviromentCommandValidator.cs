using FluentValidation;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Enviromments.Commands.Create
{
    public class CreateEnviromentCommandValidator : AbstractValidator<CreateEnviromentCommand>
    {
        public CreateEnviromentCommandValidator()
        {
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
                .WithMessage("The DocumentRoute is required")
                .Length(1, 280)
                .WithMessage("The DocumentRoute does not comply with the required extension, minimum 1 and maximum 280 characters");
        }
    }
}
