using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Inscriptions.Commands.UpdateInscriptions
{
    public class UpdateInscriptionsCommandValidator : AbstractValidator<UpdateInscriptionsCommand>
    {
        public UpdateInscriptionsCommandValidator()
        {
            RuleFor(p => p.IdUser)
              .NotEmpty()
              .WithMessage("IdUser is required");
            RuleFor(p => p.IdPublication)
                .NotEmpty()
                .WithMessage("IdPublication is required");
            RuleFor(p => p.UserDocumentRoute)
                .NotEmpty()
                .WithMessage("UserDocumentRoute is required")
                .Length(1, 490)
                .WithMessage("UserDocumentRoute does not comply with the required extension, minimum 1 and maximum 490 characters");
        }
    }
}
