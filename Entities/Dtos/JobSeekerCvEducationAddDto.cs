using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class JobSeekerCvEducationAddDto : IDto
    {
        public string SchoolName { get; set; }
        public string DepartmentName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? GraduationDate { get; set; }

        public int JobSeekerCvId { get; set; }
        public JobSeekerCv JobSeekerCv { get; set; }
    }
}
