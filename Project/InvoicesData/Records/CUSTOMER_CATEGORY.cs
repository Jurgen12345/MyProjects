using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Data.DB;

namespace Invoices.Data.Records
{
    public class CUSTOMER_CATEGORY :CDBRecord
    {
        [Key]
        public int CID { get; set; }
        

        public int LEVEL { get; set; }
    }
}
