using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Chat : AuditableEntity
    {
        public string UserID { get; set; }
        public string SellerID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public ICollection<Messages> Messages { get; set; }
    }
}
