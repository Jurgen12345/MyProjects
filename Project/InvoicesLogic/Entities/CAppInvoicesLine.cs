using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lib.Logic;
using Lib.Common.Attribs;
using Invoices.Data.Records;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Invoices.Logic.Entities
{
    public class CAppInvoicesLine : CEntity<INVOICES_LINE>
    {
        [Key]
        [ColumnWidth(50)]
        public int invoicesLineId
        {
            get { return this.Record.ID; }
            set { this.Record.ID = value; }
        }

        [ColumnWidth (50)]
        public int invoceId
        {
            get { return this.Record.INVOICE_ID; }
            set { this.Record.INVOICE_ID = value; }
        }

        public int? itemId
        {
            get
            {
                if (this.Record.ITEM_ID == 0)
                {
                    return -1;
                }
                else
                {
                    return this.Record.ITEM_ID;
                }
            }
            set
            {
                if (value != null)
                {
                    this.Record.ITEM_ID = value ?? -1;
                }
                this.InvokePropertyChanged(nameof(itemId));
            }
        }

        [Browsable(false)]
        public CItem? Item { get; set; } = null;

        public void LookupItem(List<CItem> p_oItems)
        {
            var oFound = p_oItems.Where(x => x.itemId == this.itemId).ToList();
            if (oFound.Count > 0)
            {
                this.Item = oFound[0];
            }
            else
            {
                this.Item = null;
            }
        }

        public string ItemCode
        {
            get
            {
                if(this.Item == null)
                {
                    return "";
                }
                else
                {
                    return this.Item.code;
                }
            }
        }
        



        public float qty
        {
            get { return this.Record.QTY; }
            set { this.Record.QTY = value; }

        }

        public float price
        {
            get { return this.Record.PRICE; }
            set { this.Record.PRICE = value;}
        }

        public float lineTotal
        {
            get { return this.Record.LINE_TOTAL; }
            set { this.Record.LINE_TOTAL = value; }
        }


        public CAppInvoicesLine() : base(){ }

    }
}
