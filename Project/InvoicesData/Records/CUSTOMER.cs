﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Data.DB;

namespace Invoices.Data.Records
{
    public class CUSTOMER : CDBRecord
    {
        [Key]

        public int CUSTOMER_ID { get; set; }

        

    }
}
