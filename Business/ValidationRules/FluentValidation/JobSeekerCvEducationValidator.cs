using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class JobSeekerCvEducationValidator : AbstractValidator<JobSeekerCvEducation>
    {
        public JobSeekerCvEducationValidator()
        {
            RuleFor(j => j.SchoolName).NotEmpty().WithMessage("Okul adı boş geçilmemelidir.");
            RuleFor(j => j.SchoolName).MinimumLength(10).WithMessage("Okul adı en az 10 karakterden oluşmalıdır.");
            RuleFor(j => j.SchoolName).MaximumLength(50).WithMessage("Okul adı en fazla 50 karakterden oluşmalıdır.");

            RuleFor(j => j.DepartmentName).NotEmpty().WithMessage("Bölüm adı boş geçilmemelidir.");
            RuleFor(j => j.DepartmentName).MinimumLength(5).WithMessage("Bölüm adı en az 5 karakterden oluşmalıdır.");
            RuleFor(j => j.DepartmentName).MaximumLength(50).WithMessage("Bölüm adı en fazla 50 karakterden oluşmalıdır.");

            RuleFor(j => j.StartDate).NotEmpty().WithMessage("Başlangıç tarihi boş geçilemez.");
        }
    }
}
