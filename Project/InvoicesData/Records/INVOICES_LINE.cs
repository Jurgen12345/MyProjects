using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Data.DB;

namespace Invoices.Data.Records
{
    public class INVOICES_LINE : CDBRecord
    {
        [Key]
        public int ID { get; set; }
        
        public int INVOICE_ID { get; set; }

        public int ITEM_ID { get; set; }

        public float QTY { get; set; }

        public float PRICE { get; set; }

        public float LINE_TOTAL { get; set; }
    }
}
