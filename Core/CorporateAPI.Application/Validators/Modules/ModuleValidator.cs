using CorporateAPI.Application.DTOs.Module;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Validators.Modules
{
    public class ModuleValidator:AbstractValidator<CreateModuleDTO>
    {
        public ModuleValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .NotNull()
                .Length(3,80)
                .WithMessage("Lütfen Name bilgisini boş geçmeyiniz!");

            RuleFor(m=>m.ModuleData)
                .NotEmpty()
                .NotNull();
        }
    }
}
