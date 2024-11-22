using CorporateAPI.Application.ViewModels.Menus;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Validators.Menus
{
    public class CreateMenuValidators:AbstractValidator<VM_Create_Menus>
    {
        public CreateMenuValidators()
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen boş geçmeyiniz!")
                .MaximumLength(120)
                .MinimumLength(3)
                .WithMessage("Başlık 3 ile 120 karakter arasında metin içermelidir!");
        }
    }
}
