using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Helpful
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int CommentID { get; set; }
    }
}
