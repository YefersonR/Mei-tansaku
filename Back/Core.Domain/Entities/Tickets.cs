using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Tickets : AuditableEntity
    {
        public string UserID { get; set;}
        public int ProductID { get;set;}
        public int ReasonID { get; set;}
        public string TakenBy { get; set; }
        public Product Product { get; set; }
        public Reason Reason { get; set; }
    }
}
