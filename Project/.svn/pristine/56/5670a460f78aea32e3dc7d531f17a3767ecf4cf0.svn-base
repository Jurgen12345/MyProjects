using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lib.Common.Attribs;
using Lib.Logic;
using Invoices.Data.Records;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Logic.Entities
{
    public class CSupplier : CEntity<SUPPLIER>
    {
        [Key]
        public int supplierId
        {
            get { return this.Record.SUPPLIER_ID; }
            set { this.Record.SUPPLIER_ID = value; }
        }

        public int supplierCategoryCid
        {
            get { return this.Record.SUPPLIER_CATEGORY_CID; }
            set { this.Record.SUPPLIER_CATEGORY_CID = value; }
        }

        public CSupplier() : base() { }

    }
}
