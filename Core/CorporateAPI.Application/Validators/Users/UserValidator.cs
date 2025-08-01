using CorporateAPI.Domain.Entities.Identity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace CorporateAPI.Application.Validators.Users
{
    public class UserValidator:AbstractValidator<AppUser>
    {
        private readonly UserManager<AppUser> _userManager;

        public UserValidator(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
                .MustAsync(BeUniqueEmail).WithMessage("Bu e-posta adresi zaten kullanılıyor.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı zorunludur.")
                .MustAsync(BeUniqueUsername).WithMessage("Bu kullanıcı adı zaten kullanılıyor.");

            RuleFor(x => x)
            .Must(x => !x.Email.Equals(x.UserName, StringComparison.OrdinalIgnoreCase))
            .WithMessage("Kullanıcı adı ve e-posta adresi aynı olamaz.");
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            var existing = await _userManager.FindByEmailAsync(email);
            return existing == null;
        }

        private async Task<bool> BeUniqueUsername(string username, CancellationToken cancellationToken)
        {
            var existing = await _userManager.FindByNameAsync(username);
            return existing == null;
        }

    }
}
