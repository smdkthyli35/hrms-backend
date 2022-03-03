using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class EmailActivationValidator : AbstractValidator<EmailActivation>
    {
        public EmailActivationValidator()
        {
            RuleFor(e => e.ActivationCode).NotEmpty().WithMessage("Etkinleştirme kodu boş geçilmemelidir.");
            RuleFor(e => e.ActivationCode).MinimumLength(20).WithMessage("Etkinleştirme kodu en az 20 karakterden oluşmalıdır.");
            RuleFor(e => e.ActivationCode).MaximumLength(20).WithMessage("Etkinleştirme kodu en fazla 20 karakterden oluşmalıdır.");

            RuleFor(e => e.Email).NotEmpty().WithMessage("E-posta adresi boş geçilmemelidir.");
            RuleFor(e => e.Email).MinimumLength(10).WithMessage("E-posta adresi en az 10 karakterden oluşmalıdır.");
            RuleFor(e => e.Email).MaximumLength(40).WithMessage("E-posta adresi en fazla 40 karakterden oluşmalıdır.");

            RuleFor(e => e.ExpirationDate).NotEmpty().WithMessage("Son geçerlilik tarihi boş geçilmemelidir.");
        }
    }
}
