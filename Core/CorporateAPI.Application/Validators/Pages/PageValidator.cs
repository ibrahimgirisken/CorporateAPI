using CorporateAPI.Application.DTOs.Page;
using FluentValidation;


namespace CorporateAPI.Application.Validators.Pages
{
    public class PageValidator:AbstractValidator<PageTranslationDTO>
    {
        public PageValidator()
        {
            RuleFor(m => m.Title)
                 .NotEmpty()
                 .NotNull()
                 .MinimumLength(3)
                 .MaximumLength(120);

            RuleFor(m => m.Locale)
                .NotEmpty()
                .NotNull();
        }
    }
}
