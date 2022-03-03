using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class WorkingTypeValidator : AbstractValidator<WorkingType>
    {
        public WorkingTypeValidator()
        {
            RuleFor(w => w.Name).NotEmpty().WithMessage("Çalışma tipi boş geçilmemelidir.");
            RuleFor(w => w.Name).MinimumLength(5).WithMessage("Çalışma tipi en az 5 karakterden oluşmalıdır.");
            RuleFor(w => w.Name).MaximumLength(50).WithMessage("Çalışma tipi en fazla 50 karakterden oluşmalıdır.");
        }
    }
}
