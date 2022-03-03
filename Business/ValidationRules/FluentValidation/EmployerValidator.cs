using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class EmployerValidator : AbstractValidator<Employer>
    {
        public EmployerValidator()
        {
            RuleFor(e => e.CompanyName).NotEmpty().WithMessage("Şirket adı boş geçilmemelidir.");
            RuleFor(e => e.CompanyName).MinimumLength(10).WithMessage("Şirket adı en az 10 karakterden oluşmalıdır.");
            RuleFor(e => e.CompanyName).MaximumLength(100).WithMessage("Şirket adı en fazla 100 karakterden oluşmalıdır");

            RuleFor(e => e.WebSite).NotEmpty().WithMessage("Website adı boş geçilmemelidir.");
            RuleFor(e => e.WebSite).MinimumLength(7).WithMessage("Website adı en az 7 karakterden oluşmalıdır.");
            RuleFor(e => e.WebSite).MaximumLength(50).WithMessage("Website adı en fazla 50 karakterden oluşmalıdır");

            RuleFor(e => e.CorporateEmail).NotEmpty().WithMessage("Kurumsal e-posta adresi boş geçilmemelidir.");
            RuleFor(e => e.CorporateEmail).MinimumLength(13).WithMessage("Kurumsal e-posta adresi en az 13 karakterden oluşmalıdır.");
            RuleFor(e => e.CorporateEmail).MaximumLength(50).WithMessage("Kurumsal e-posta adresi en fazla 50 karakterden oluşmalıdır.");

            RuleFor(e => e.Phone).NotEmpty().WithMessage("Telefon numarası boş geçilmemelidir.");
            RuleFor(e => e.Phone).MinimumLength(13).WithMessage("Telefon numarası en az 13 karakterden oluşmalıdır.");
            RuleFor(e => e.Phone).MaximumLength(13).WithMessage("Telefon numarası en fazla 13 karakterden oluşmalıdır.");
        }
    }
}
