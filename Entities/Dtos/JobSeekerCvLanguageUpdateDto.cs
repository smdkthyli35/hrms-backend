using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class JobSeekerCvLanguageUpdateDto : IDto
    {
        public int Id { get; set; }
        public short Level { get; set; }

        public int JobSeekerCvId { get; set; }
        public JobSeekerCv JobSeekerCv { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
