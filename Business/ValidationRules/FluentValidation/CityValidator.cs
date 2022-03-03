using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Şehir adı boş geçilmemelidir.");
            RuleFor(c => c.Name).MinimumLength(3).WithMessage("Şehir adı en az 3 karakterden oluşmalıdır.");
            RuleFor(c => c.Name).MaximumLength(50).WithMessage("Şehir adı en fazla 50 karakterden oluşmalıdır.");
        }
    }
}
