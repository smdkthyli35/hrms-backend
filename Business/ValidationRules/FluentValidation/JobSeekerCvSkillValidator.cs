using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class JobSeekerCvSkillValidator : AbstractValidator<JobSeekerCvSkill>
    {
        public JobSeekerCvSkillValidator()
        {
            RuleFor(j => j.Name).NotEmpty().WithMessage("Yetenek adı boş geçilmemelidir.");
            RuleFor(j => j.Name).MinimumLength(3).WithMessage("Yetenek adı en az 3 karakterden oluşmalıdır.");
            RuleFor(j => j.Name).MaximumLength(50).WithMessage("Yetenek adı en fazla 50 karakterden oluşmalıdır.");
        }
    }
}
