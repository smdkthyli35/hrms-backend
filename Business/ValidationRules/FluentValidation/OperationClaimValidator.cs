using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class OperationClaimValidator : AbstractValidator<OperationClaim>
    {
        public OperationClaimValidator()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage("Yetki adı boş geçilmemelidir.");
            RuleFor(o => o.Name).MinimumLength(3).WithMessage("Yetki adı en az 3 karakterden oluşmalıdır.");
            RuleFor(o => o.Name).MaximumLength(50).WithMessage("Yetki adı en fazla 50 karakterden oluşmalıdır.");
        }
    }
}
