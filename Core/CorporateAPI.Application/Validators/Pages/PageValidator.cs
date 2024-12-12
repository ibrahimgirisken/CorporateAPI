using CorporateAPI.Application.DTOs.Page;
using FluentValidation;


namespace CorporateAPI.Application.Validators.Pages
{
    public class PageValidator:AbstractValidator<CreatePageDTO>
    {
        public PageValidator()
        {
            RuleFor(p=>p.Title).NotEmpty().NotNull().WithMessage("Boş geçmeyiniz!");
            RuleFor(p => p.Title).MinimumLength(3).MaximumLength(80).WithMessage("Title alanı 3 ie 80 karakter arasında olması gerekmektedir!");                               
        }
    }
}
