using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class JobSeekerValidator : AbstractValidator<JobSeeker>
    {
        public JobSeekerValidator()
        {
            RuleFor(j => j.FirstName).NotEmpty().WithMessage("İsim boş geçilmemelidir.");
            RuleFor(j => j.FirstName).MinimumLength(2).WithMessage("İsim en az 2 karakterden oluşmalıdır.");
            RuleFor(j => j.FirstName).MaximumLength(50).WithMessage("İsim en fazla 50 karakterden oluşmalıdır.");

            RuleFor(j => j.LastName).NotEmpty().WithMessage("Soyisim boş geçilmemelidir.");
            RuleFor(j => j.LastName).MinimumLength(3).WithMessage("Soyisim en az 3 karakterden oluşmalıdır.");
            RuleFor(j => j.LastName).MaximumLength(50).WithMessage("Soyisim en fazla 50 karakterden oluşmalıdır.");

            RuleFor(j => j.IdentityNumber).NotEmpty().WithMessage("TC Kimlik No boş geçilmemelidir.");
            RuleFor(j => j.IdentityNumber).MinimumLength(11).WithMessage("TC Kimlik No en az 11 karakterden oluşmalıdır.");
            RuleFor(j => j.IdentityNumber).MaximumLength(11).WithMessage("TC Kimlik No en fazla 11 karakterden oluşmalıdır.");

            RuleFor(j => j.BirthDate).NotEmpty().WithMessage("Doğum tarihi boş geçilmemelidir.");
        }
    }
}
