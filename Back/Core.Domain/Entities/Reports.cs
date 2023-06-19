using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Reports : AuditableEntity
    {
        public string PersonID { get; set; }
        public int ReportedID { get; set; }
        public int ReasonID { get; set; }
        public Reason Reason { get; set; }
    }
}
