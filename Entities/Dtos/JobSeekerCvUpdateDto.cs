using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class JobSeekerCvUpdateDto : IDto
    {
        public int Id { get; set; }
        public string CoverLetter { get; set; }

        public int? JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }
    }
}
