using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Lib.Logic;
using Invoices.Data.Records;
using Lib.Common.Attribs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Logic.Entities
{
    public class CCustomer : CEntity<CUSTOMER>
    {
        [Key]
        [DisplayName("Customer id")]
        public int customerId
        {
            get { return this.Record.CUSTOMER_ID; }
            set { this.Record.CUSTOMER_ID = value; }
        }

        
        //public int customerCategoryCid
        //{
        //    get { return this.Record.CUSTOMER_CATEGORY_CID; }
        //    set { this.Record.CUSTOMER_CATEGORY_CID = value; }
        //}


        public CCustomer() : base() { }

        public override string ToString() { 
            return $"Customer Number : {customerId.ToString()}";
        }
    }
}
