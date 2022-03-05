using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class JobSeekerCvWebSiteAddDto : IDto
    {
        public string Address { get; set; }

        public int JobSeekerCvId { get; set; }
        public JobSeekerCv JobSeekerCv { get; set; }

        public short WebSiteId { get; set; }
        public WebSite WebSite { get; set; }

        public bool IsActive { get; set; }
    }
}
