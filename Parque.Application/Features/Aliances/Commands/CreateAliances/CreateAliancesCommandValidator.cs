using FluentValidation;

namespace Parque.Application.Features.Aliances.Commands.CreateAliances
{
    public class CreateAliancesCommandValidator : AbstractValidator<CreateAliancesCommand>
    {
        public CreateAliancesCommandValidator()
        {
            RuleFor(p => p.AlianceDate).NotEmpty().WithMessage("Fecha de alianza es un campo obligatorio")
                .Matches(@"\d{2}/\d{2}/\d{4}").WithMessage("La fecha debe cumplir con el formato dd-mm-yyyy");

            RuleFor(p => p.Description).NotEmpty().WithMessage("La descripcion de la alianza es requerida")
                .Length(30, 300).WithMessage("la descripcion no cumple la longitud requerida");

            RuleFor(p => p.IdTypeAliance).NotEmpty().WithMessage("Se nececita saber que tipo de alianza es.");

            RuleFor(p => p.Name).NotEmpty().WithMessage("Requerido");
        }
    }
}
