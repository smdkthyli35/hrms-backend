using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class JobSeekerCvValidator : AbstractValidator<JobSeekerCv>
    {
        public JobSeekerCvValidator()
        {
            RuleFor(j => j.CoverLetter).NotEmpty().WithMessage("Ön yazı boş geçilmemelidir.");
            RuleFor(j => j.CoverLetter).MinimumLength(10).WithMessage("Ön yazı en az 10 karakterden oluşmalıdır.");
            RuleFor(j => j.CoverLetter).MaximumLength(250).WithMessage("Ön yazı en fazla 250 karakterden oluşmalıdır.");
        }
    }
}
