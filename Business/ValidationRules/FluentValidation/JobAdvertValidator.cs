using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class JobAdvertValidator : AbstractValidator<JobAdvert>
    {
        public JobAdvertValidator()
        {
            RuleFor(j => j.Description).NotEmpty().WithMessage("Açıklama boş geçilmemelidir.");
            RuleFor(j => j.Description).MinimumLength(10).WithMessage("Açıklama en az 10 karakterden oluşmalıdır.");
            RuleFor(j => j.Description).MaximumLength(500).WithMessage("Açıklama en fazla 500 karakterden oluşmalıdır.");

            RuleFor(j => j.NumberOfOpenPositions).NotEmpty().WithMessage("Açık pozisyon sayısı boş geçilmemelidir.");
        }
    }
}
