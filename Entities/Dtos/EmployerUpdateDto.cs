using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class EmployerUpdateDto : IDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string WebSite { get; set; }
        public string CorporateEmail { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
