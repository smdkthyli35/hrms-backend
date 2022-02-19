using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class JobSeekerCvEducation : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int JobSeekerCvId { get; set; }
        public string SchoolName { get; set; }
        public string DepartmentName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? GraduationDate { get; set; }
    }
}
