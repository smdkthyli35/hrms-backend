using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class JobSeekerCvImage : EntityBase, IEntity
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public JobSeekerCv JobSeekerCv { get; set; }
        public int JobSeekerCvId { get; set; }
    }
}
