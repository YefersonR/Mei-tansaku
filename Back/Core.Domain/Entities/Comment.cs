using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Comment : AuditableEntity
    {
        public int ProductID { get; set; }
        public string UserID { get; set; }
        public string Description { get; set; }
        public int FatherComment { get; set; }
        public Product Product { get; set; }
        public ICollection<Helpful> Helpfuls { get; set; }
    }
}
