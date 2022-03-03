using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class LanguageValidator : AbstractValidator<Language>
    {
        public LanguageValidator()
        {
            RuleFor(l => l.Name).NotEmpty().WithMessage("Dil adı boş geçilmemelidir.");
            RuleFor(l => l.Name).MinimumLength(5).WithMessage("Dil adı en az 5 karakterden oluşmalıdır.");
            RuleFor(l => l.Name).MaximumLength(50).WithMessage("Dil adı en fazla 50 karakterden oluşmalıdır.");
        }
    }
}
