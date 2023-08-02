using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.NewsPapers.Commands.CreateNewsPapers
{
    public class CreateNewsPapersCommandValidator : AbstractValidator<CreateNewsPapersCommand>
    {
        public CreateNewsPapersCommandValidator()
        {
            RuleFor(p => p.Title)
                 .NotEmpty()
                 .WithMessage("Title is required")
                 .Length(1, 250)
                 .WithMessage("The Title does not comply with the required extension, minimum 1 and maximum 250 characters");
            RuleFor(p => p.IdPublishingHouse)
                .NotEmpty()
                .WithMessage("IdPublishingHouse is required");
            RuleFor(p => p.DocumentRoute)
                .NotEmpty()
                .WithMessage("DocumentRoute is required")
                .Length(1, 295)
                .WithMessage("The DocumentRoute does not comply with the required extension, minimum 1 and maximum 295   characters");
        }
    }
}
