using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : EntityBase, IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public ICollection<CompanyStaffVerification> CompanyStaffVerifications { get; set; }
        public ICollection<EmailActivation> EmailActivations { get; set; }
        public Employer Employer { get; set; }
        public JobSeeker JobSeeker { get; set; }
        public CompanyStaff CompanyStaff { get; set; }
    }
}
