using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class WebSiteValidator : AbstractValidator<WebSite>
    {
        public WebSiteValidator()
        {
            RuleFor(w => w.Name).NotEmpty().WithMessage("Website adı boş geçilmemelidir.");
            RuleFor(w => w.Name).MinimumLength(10).WithMessage("Website adı en az 10 karakterden oluşmalıdır.");
            RuleFor(w => w.Name).MaximumLength(50).WithMessage("Website adı en fazla 50 karakterden oluşmalıdır.");
        }
    }
}
