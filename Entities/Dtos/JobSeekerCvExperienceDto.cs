using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class JobSeekerCvExperienceDto : IDto
    {
        public JobSeekerCvExperience JobSeekerCvExperience { get; set; }
    }
}
