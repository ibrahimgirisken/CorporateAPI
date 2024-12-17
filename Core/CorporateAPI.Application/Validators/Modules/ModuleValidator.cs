using CorporateAPI.Application.DTOs.Module;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            RuleFor(m => m.Locale)
                .NotEmpty()
                .NotNull()
                .Must(value => allowedValues.Contains(value))
                .WithMessage($"Sadece:{string.Join(",", allowedValues)}");
        }
    }
}
