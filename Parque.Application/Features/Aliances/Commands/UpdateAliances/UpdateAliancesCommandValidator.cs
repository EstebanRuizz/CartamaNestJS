using FluentValidation;

namespace Parque.Application.Features.Aliances.Commands.UpdateAliances
{
    public class UpdateAliancesCommandValidator : AbstractValidator<UpdateAliancesCommand>
    {
        public UpdateAliancesCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("El idenficador unico es requerido");
            RuleFor(p => p.AlianceDate).NotEmpty().WithMessage("Fecha de alianza es un campo obligatorio");

            RuleFor(p => p.Description).NotEmpty().WithMessage("La descripcion de la alianza es requerida")
                .Length(30, 300).WithMessage("la descripcion no cumple la longitud requerida");

            RuleFor(p => p.IdTypeAliance).NotEmpty().WithMessage("Se nececita saber que tipo de alianza es.");

            RuleFor(p => p.Name).NotEmpty().WithMessage("Requerido");
        }
    }
}
