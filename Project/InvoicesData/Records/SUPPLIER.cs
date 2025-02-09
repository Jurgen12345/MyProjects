using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Data.DB;

namespace Invoices.Data.Records
{
    public class SUPPLIER : CDBRecord
    {

        [Key]
        public int SUPPLIER_ID { get; set; }

        public int SUPPLIER_CATEGORY_CID { get; set; }
    }
}
