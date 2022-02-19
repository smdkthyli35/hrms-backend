using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class JobSeekerCvExperience : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int JobSeekerCvId { get; set; }
        public int JobPositionId { get; set; }
        public string WorkplaceName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? QuitDate { get; set; }
    }
}
