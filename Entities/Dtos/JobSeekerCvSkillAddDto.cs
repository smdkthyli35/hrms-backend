using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class JobSeekerCvSkillAddDto : IDto
    {
        public string Name { get; set; }

        public int JobSeekerCvId { get; set; }
        public JobSeekerCv JobSeekerCv { get; set; }

        public bool IsActive { get; set; }
    }
}
