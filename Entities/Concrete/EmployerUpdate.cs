using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EmployerUpdate : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyStaffId { get; set; }
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public string CorporateEmail { get; set; }
        public string Phone { get; set; }
        public bool IsApproved { get; set; }
    }
}
