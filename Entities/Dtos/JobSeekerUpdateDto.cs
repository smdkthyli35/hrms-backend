using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class JobSeekerUpdateDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int JobSeekerCvId { get; set; }
        public JobSeekerCv JobSeekerCv { get; set; }
    }
}
