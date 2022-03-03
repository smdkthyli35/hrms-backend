using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class JobPositionValidator : AbstractValidator<JobPosition>
    {
        public JobPositionValidator()
        {
            RuleFor(j => j.Title).NotEmpty().WithMessage("Başlık boş geçilmemelidir.");
            RuleFor(j => j.Title).MinimumLength(3).WithMessage("Başlık en az 3 karakterden oluşmalıdır.");
            RuleFor(j => j.Title).MaximumLength(100).WithMessage("Başlık en fazla 100 karakterden oluşmalıdır.");
        }
    }
}
