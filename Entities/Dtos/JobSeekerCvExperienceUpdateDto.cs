using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class JobSeekerCvExperienceUpdateDto : IDto
    {
        public int Id { get; set; }
        public string WorkplaceName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? QuitDate { get; set; }

        public int JobSeekerCvId { get; set; }
        public JobSeekerCv JobSeekerCv { get; set; }

        public int JobPositionId { get; set; }
        public JobPosition JobPosition { get; set; }
    }
}
