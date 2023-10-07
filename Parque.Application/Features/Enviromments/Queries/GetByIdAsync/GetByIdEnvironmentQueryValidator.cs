using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Enviromments.Queries.GetByIdAsync
{
    public class GetByIdEnvironmentQueryValidator : AbstractValidator<GetByIdEnviromentQuery>
    {
        public GetByIdEnvironmentQueryValidator()
        {
            RuleFor(p => p.Id)
            .NotEmpty()
            .WithMessage("Environment Id is required");
        }
    }
}
