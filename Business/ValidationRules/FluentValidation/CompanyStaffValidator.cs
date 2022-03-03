using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CompanyStaffValidator : AbstractValidator<CompanyStaff>
    {
        public CompanyStaffValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("Şirket personeli adı boş geçilmemelidir.");
            RuleFor(c => c.FirstName).MinimumLength(2).WithMessage("Şirket personeli adı en az 2 karakterden oluşmalıdır.");
            RuleFor(c => c.FirstName).MaximumLength(50).WithMessage("Şirket personeli adı en fazla 50 karakterden oluşmalıdır.");

            RuleFor(c => c.LastName).NotEmpty().WithMessage("Şirket personeli soyadı boş geçilmemelidir.");
            RuleFor(c => c.LastName).MinimumLength(4).WithMessage("Şirket personeli soyadı en az 4 karakterden oluşmalıdır.");
            RuleFor(c => c.LastName).MaximumLength(50).WithMessage("Şirket personeli soyadı en fazla 50 karakterden oluşmalıdır.");
        }
    }
}
