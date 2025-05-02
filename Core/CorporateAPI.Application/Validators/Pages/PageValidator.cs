using CorporateAPI.Application.DTOs.Page;
using FluentValidation;


namespace CorporateAPI.Application.Validators.Pages
{
    public class PageValidator:AbstractValidator<PageTranslationDTO>
    {
        public PageValidator()
        {
            List<string> allowedValues = new List<string> {"tr","en","de"};
            RuleFor(m => m.Title)
                 .NotEmpty()
                 .NotNull()
                 .MinimumLength(3)
                 .MaximumLength(120);

            RuleFor(m => m.LangId)
                .NotEmpty()
                .NotNull()
                .WithMessage($"Sadece:{string.Join(",",allowedValues)}");
        }
    }
}
