using CorporateAPI.Application.DTOs.Module;
using FluentValidation;

namespace CorporateAPI.Application.Validators.Modules
{
    public class ModuleValidator:AbstractValidator<ModuleTranslationDTO>
    {
        public ModuleValidator()
        {
            List<string> allowedValues = new List<string> { "tr", "en", "de" };
            RuleFor(m => m.Name)
                 .NotEmpty()
                 .NotNull()
                 .MinimumLength(3)
                 .MaximumLength(120);

            RuleFor(m => m.LangId)
                .NotEmpty()
                .NotNull()
                .WithMessage($"Sadece:{string.Join(",", allowedValues)}");
        }
    }
}
