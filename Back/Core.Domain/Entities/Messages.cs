using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Messages
    {
        public int ID { get; set; }
        public int ChatID { get; set; }
        public string? Message { get; set; }
        public string? ImageUrl { get; set;}
        public string? PersonID { get; set;}
    }
}
