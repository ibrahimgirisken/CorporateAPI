using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.Application.DTOs.Page;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Validators.Pages
{
    public class PageValidator:AbstractValidator<CreatePageDTO>
    {
        public PageValidator()
        {
            RuleFor(p=>p.Title).NotEmpty().NotNull();
            RuleFor(p => p.Title).Length(3, 80);                               
        }
    }
}
