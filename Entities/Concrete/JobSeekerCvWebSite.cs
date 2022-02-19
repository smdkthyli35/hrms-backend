using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class JobSeekerCvWebSite : EntityBase, IEntity
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public JobSeekerCv JobSeekerCv { get; set; }
        public int JobSeekerCvId { get; set; }

        public WebSite WebSite { get; set; }
        public short WebSiteId { get; set; }
    }
}
