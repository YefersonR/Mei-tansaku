using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Helpful : AuditableEntity
    {
        public string UserID { get; set; }
        public int CommentID { get; set; }
        public Comment Comment { get; set; }
    }
}
