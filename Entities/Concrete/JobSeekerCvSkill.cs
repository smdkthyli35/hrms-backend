using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class JobSeekerCvSkill : EntityBase, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public JobSeekerCv JobSeekerCv { get; set; }
        public int JobSeekerCvId { get; set; }
    }
}
