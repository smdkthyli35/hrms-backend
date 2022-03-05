using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class JobAdvertAddDto : IDto
    {
        public string Description { get; set; }
        public int? MinSalary { get; set; }
        public int? MaxSalary { get; set; }
        public int NumberOfOpenPositions { get; set; }
        public DateTime? ApplicationDeadline { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int EmployerId { get; set; }
        public Employer Employer { get; set; }

        public int JobPositionId { get; set; }
        public JobPosition JobPosition { get; set; }

        public short? WorkingTimeId { get; set; }
        public WorkingTime WorkingTime { get; set; }

        public short? WorkingTypeId { get; set; }
        public WorkingType WorkingType { get; set; }
    }
}
