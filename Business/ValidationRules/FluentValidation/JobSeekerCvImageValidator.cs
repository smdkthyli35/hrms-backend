using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class JobSeekerCvImageValidator : AbstractValidator<JobSeekerCvImage>
    {
        public JobSeekerCvImageValidator()
        {
            RuleFor(j => j.Url).NotEmpty().WithMessage("Resim adresi boş geçilmemelidir.");
            RuleFor(j => j.Url).MaximumLength(250).WithMessage("Resim adresi en fazla 250 karakterden oluşmalıdır.");
        }
    }
}
