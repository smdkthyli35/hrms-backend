using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class JobPositionAddDto : IDto
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
