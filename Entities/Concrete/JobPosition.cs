using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class JobPosition : EntityBase, IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<JobAdvert> JobAdverts { get; set; }
        public ICollection<JobSeekerCvExperience> JobSeekerCvExperiences { get; set; }
    }
}
