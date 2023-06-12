using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string UserID { get; set; }
        public string Description { get; set; }
        public int FatherComment { get; set; }
    }
}
