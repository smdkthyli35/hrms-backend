using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class JobSeekerCv : EntityBase, IEntity
    {
        public int Id { get; set; }
        public string CoverLetter { get; set; }

        public JobSeeker JobSeeker { get; set; }
        public int? JobSeekerId { get; set; }

        public ICollection<JobSeekerCvEducation> JobSeekerCvEducations { get; set; }
        public ICollection<JobSeekerCvExperience> JobSeekerCvExperiences { get; set; }
        public ICollection<JobSeekerCvImage> JobSeekerCvImages { get; set; }
        public ICollection<JobSeekerCvLanguage> JobSeekerCvLanguages { get; set; }
        public ICollection<JobSeekerCvSkill> JobSeekerCvSkills { get; set; }
        public ICollection<JobSeekerCvWebSite> JobSeekerCvWebSites { get; set; }
        public ICollection<JobSeeker> JobSeekers { get; set; }
    }
}
