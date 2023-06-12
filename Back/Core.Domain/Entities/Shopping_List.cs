using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Shopping_List
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public bool Default { get; set; } = false;
        public string Title { get; set; }
    }
}
