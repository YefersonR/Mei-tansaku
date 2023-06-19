using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Messages : AuditableEntity
    {
        public int ChatID { get; set; }
        public string? Message { get; set; }
        public string? ImageUrl { get; set;}
        public string? PersonID { get; set;}
        public Chat Chat { get; set; }
    }
}
