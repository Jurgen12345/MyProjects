using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lib.Logic;
using Lib.Common.Attribs;
using Invoices.Data.Records;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Logic.Entities
{
    public class CItem : CEntity<ITEM>
    {
        [Key]
        public int itemId
        {
            get { return this.Record.ID; }
            set { this.Record.ID = value; }
        }

        [ColumnWidth(250)]
        public string code
        {
            get { return this.Record.CODE; }
            set { this.Record.CODE = value; }
        }

        public int measurementUnitCid
        {
            get { return this.Record.MEASUREMENT_UNIT_CID; }
            set { this.Record.MEASUREMENT_UNIT_CID = value; }
        }

        public int itemCategoryCid
        {
            get { return this.Record.ITEM_CATEGORY_CID; }
            set { this.Record.ITEM_CATEGORY_CID = value; }
        }

        public CItem() : base() { }



    }
}
