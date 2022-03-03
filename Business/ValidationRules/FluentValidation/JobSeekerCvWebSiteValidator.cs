using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class JobSeekerCvWebSiteValidator : AbstractValidator<JobSeekerCvWebSite>
    {
        public JobSeekerCvWebSiteValidator()
        {
            RuleFor(j => j.Address).NotEmpty().WithMessage("Website adresi boş geçilmemelidir.");
            RuleFor(j => j.Address).MinimumLength(10).WithMessage("Website adresi en az 10 karakterden oluşmalıdır.");
            RuleFor(j => j.Address).MaximumLength(50).WithMessage("Website adresi en fazla 50 karakterden oluşmalıdır.");
        }
    }
}
