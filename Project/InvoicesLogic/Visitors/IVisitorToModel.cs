﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoices.Logic.Entities;
using Invoices.Logic.Models;
using Lib.Data.DB;
using Lib.Logic;

namespace Invoices.Logic.Visitors
{
    public interface IVisitorToModel
    {
        public void Visit(IList p_oRecordSet, List<CAppInvoices> p_oEntityList);
        public void Visit(IList p_oRecordSet, List<CAppInvoicesLine> p_oEntityList);
        public void Visit(IList p_oRecordSet, List<CCustomer> p_oEntityList);
        public void Visit(IList p_oRecordSet, List<CItem> p_oEntityList);
        public void Visit(IList p_oRecordSet, List<CSupplier> p_oEntityList);
        
    }
}
