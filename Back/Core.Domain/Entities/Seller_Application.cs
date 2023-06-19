﻿using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Seller_Application : AuditableEntity
    {
        public string UserID { get; set; }
        public string Description { get; set; }
        public string Identification { get; set; }
        public bool Status { get; set; }

    }
}
