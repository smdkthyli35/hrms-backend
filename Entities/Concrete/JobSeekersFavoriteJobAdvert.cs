using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class JobSeekersFavoriteJobAdvert : EntityBase, IEntity
    {
        public int Id { get; set; }

        public JobAdvert JobAdvert { get; set; }
        public int? JobAdvertId { get; set; }

        public JobSeeker JobSeeker { get; set; }
        public int? JobSeekerId { get; set; }
    }
}
