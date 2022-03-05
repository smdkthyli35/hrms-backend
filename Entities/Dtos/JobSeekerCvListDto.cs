using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class JobSeekerCvListDto : IDto
    {
        public IList<JobSeekerCv> JobSeekerCvs { get; set; }
    }
}
