using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyStaffVerification : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsAproved { get; set; }
        public DateTime? ApprovalDate { get; set; }
    }
}
