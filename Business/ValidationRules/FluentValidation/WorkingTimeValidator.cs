using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class WorkingTimeValidator : AbstractValidator<WorkingTime>
    {
        public WorkingTimeValidator()
        {
            RuleFor(w => w.Name).NotEmpty().WithMessage("Çalışma zamanı boş geçilmemelidir.");
            RuleFor(w => w.Name).MinimumLength(5).WithMessage("Çalışma zamanı en az 5 karakterden oluşmalıdır.");
            RuleFor(w => w.Name).MaximumLength(50).WithMessage("Çalışma zamanı en fazla 50 karakterden oluşmalıdır.");
        }
    }
}
