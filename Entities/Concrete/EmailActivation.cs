using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EmailActivation : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ActivationCode { get; set; }
        public string Email { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? ActivationDate { get; set; }
    }
}
