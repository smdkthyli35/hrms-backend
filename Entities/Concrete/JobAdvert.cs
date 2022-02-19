using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class JobAdvert : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public int JobPositionId { get; set; }
        public int CityId { get; set; }
        public string Description { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public int NumberOfOpenPositions { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public short WorkingTypeId { get; set; }
        public short WorkingTimeId { get; set; }
    }
}
