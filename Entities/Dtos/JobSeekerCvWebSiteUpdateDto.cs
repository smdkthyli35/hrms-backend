using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class JobSeekerCvWebSiteUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public int JobSeekerCvId { get; set; }
        public JobSeekerCv JobSeekerCv { get; set; }

        public short WebSiteId { get; set; }
        public WebSite WebSite { get; set; }
    }
}
