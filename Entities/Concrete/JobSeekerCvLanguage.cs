using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class JobSeekerCvLanguage : EntityBase, IEntity
    {
        public int Id { get; set; }
        public short Level { get; set; }

        public JobSeekerCv JobSeekerCv { get; set; }
        public int JobSeekerCvId { get; set; }

        public Language Language { get; set; }
        public int LanguageId { get; set; }
    }
}
