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
        public int? CompanyStaffId { get; set; }
        public string CompanyName { get; set; }
        public string WebSite { get; set; }
        public string CorporateEmail { get; set; }
        public string Phone { get; set; }
        public bool IsApproved { get; set; }

        public Employer Employer { get; set; }
        public int EmployerId { get; set; }
    }
}
