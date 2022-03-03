using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class JobSeekerCvExperienceValidator : AbstractValidator<JobSeekerCvExperience>
    {
        public JobSeekerCvExperienceValidator()
        {
            RuleFor(j => j.WorkplaceName).NotEmpty().WithMessage("İşyeri adı boş geçilmemelidir.");
            RuleFor(j => j.WorkplaceName).MinimumLength(10).WithMessage("İşyeri adı en az 10 karakterden oluşmalıdır.");
            RuleFor(j => j.WorkplaceName).MaximumLength(100).WithMessage("İşyeri adı en fazla 100 karakterden oluşmalıdır.");

            RuleFor(j => j.StartDate).NotEmpty().WithMessage("Başlangıç tarihi boş geçilmemelidir.");
        }
    }
}
