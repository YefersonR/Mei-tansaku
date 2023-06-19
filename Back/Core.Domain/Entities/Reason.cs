using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Reason : AuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Tickets> Tickets{ get; set; }
        public ICollection<Reports> Reports { get; set; }
    }
}
