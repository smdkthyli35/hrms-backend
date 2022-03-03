using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("İsim boş geçilmemelidir.");
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage("İsim en az 2 karakterden oluşmalıdır.");
            RuleFor(u => u.FirstName).MaximumLength(30).WithMessage("İsim en fazla 30 karakterden oluşmalıdır.");

            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyisim boş geçilmemelidir.");
            RuleFor(u => u.LastName).MinimumLength(3).WithMessage("Soyisim en az 3 karakterden oluşmalıdır.");
            RuleFor(u => u.LastName).MaximumLength(30).WithMessage("Soyisim en fazla 30 karakterden oluşmalıdır.");

            RuleFor(u => u.Email).NotEmpty().WithMessage("E-posta adresi boş geçilmemelidir.");
            RuleFor(u => u.Email).MinimumLength(13).WithMessage("E-posta adresi en az 13 karakterden oluşmalıdır.");
            RuleFor(u => u.Email).MaximumLength(50).WithMessage("E-posta adresi en fazla 50 karakterden oluşmalıdır.");
        }
    }
}
