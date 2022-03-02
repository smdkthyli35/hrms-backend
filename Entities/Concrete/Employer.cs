using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Employer : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string WebSite { get; set; }
        public string CorporateEmail { get; set; }
        public string Phone { get; set; }

        public ICollection<EmployerUpdate> EmployerUpdates { get; set; }
        public ICollection<JobAdvert> JobAdverts { get; set; }
    }
}
