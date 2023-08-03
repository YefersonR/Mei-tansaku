using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Shopping_List : AuditableEntity
    {
        public string UserID { get; set; }
        public bool Default { get; set; } = false;
        public string Title { get; set; }
        public ICollection<Product_List> Product_Lists { get; set; }
    }
}
