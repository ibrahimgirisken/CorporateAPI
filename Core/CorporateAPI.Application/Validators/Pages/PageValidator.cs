using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Validators.Pages
{
    public class PageValidator:AbstractValidator<Domain.Entities.Page>
    {
        public PageValidator()
        {
            RuleFor(p=>p.Title).NotEmpty();
            RuleFor(p => p.Title).Length(3, 80);                               
        }
    }
}
