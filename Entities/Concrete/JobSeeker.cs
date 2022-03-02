using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class JobSeeker : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int JobSeekerCvId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }

        public JobSeekerCv JobSeekerCv { get; set; }

        public ICollection<JobSeekerCv> JobSeekerCvs { get; set; }
        public ICollection<JobSeekersFavoriteJobAdvert> JobSeekersFavoriteJobAdverts { get; set; }
    }
}
