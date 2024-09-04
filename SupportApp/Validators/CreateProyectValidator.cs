using FluentValidation;
using SupportApp.DTOs;
using SupportApp.Proyects;

namespace DefaultNamespace;

public class CreateProyectValidator : AbstractValidator<CreateProyectDto>, IValidator<CreateProyectDto>
{
    public CreateProyectValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithName(FrequenceMessage.EmptyMessage);
        RuleFor(x => x.Name).MaximumLength(8).WithName("El máximo nº de caracteres para Nombre es de 8");
        
    }
}