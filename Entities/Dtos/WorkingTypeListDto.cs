using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities.Dtos
{
    public class WorkingTypeListDto : IDto
    {
        public IList<WorkingType> WorkingTypes { get; set; }
    }
}
