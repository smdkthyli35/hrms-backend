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
        public int JobSeekerCvId { get; set; }
        public string LanguageId { get; set; }
        public short Level { get; set; }
    }
}
