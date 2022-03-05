using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class WorkingTimeListDto : IDto
    {
        public IList<WorkingTime> WorkingTimes { get; set; }
    }
}
