﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lib.Logic;
using Invoices.Logic.Entities;
using System.Collections;
using Invoices.Logic.Models;

namespace Invoices.Logic.Visitors
{
    public class CVisitorRecordAdder : IVisitorToModel
    {
        public void Visit(IList p_oRecordSet, List<CAppInvoices> p_oEntityList)
        {
            foreach (var oEntity in p_oEntityList)
            {
                if (oEntity.Change == EntityChangeType.CREATED)
                {
                    if (p_oRecordSet.IndexOf(oEntity.Record) == -1)
                        p_oRecordSet.Add(oEntity.Record);
                }
            }
        }

        public void Visit(IList p_oRecordSet, List<CAppInvoicesLine> p_oEntityList)
        {
            foreach (var oEntity in p_oEntityList)
            {
                if (oEntity.Change == EntityChangeType.CREATED)
                {
                    if (p_oRecordSet.IndexOf(oEntity.Record) == -1)
                        p_oRecordSet.Add(oEntity.Record);
                }
            }
        }


        public void Visit(IList p_oRecordSet, List<CCustomer> p_oEntityList)
        {
            foreach (var oEntity in p_oEntityList)
            {
                if (oEntity.Change == EntityChangeType.CREATED)
                {
                    if (p_oRecordSet.IndexOf(oEntity.Record) == -1)
                        p_oRecordSet.Add(oEntity.Record);
                }
            }
        }

        public void Visit(IList p_oRecordSet, List<CItem> p_oEntityList)
        {
            foreach (var oEntity in p_oEntityList)
            {
                if (oEntity.Change == EntityChangeType.CREATED)
                {
                    if (p_oRecordSet.IndexOf(oEntity.Record) == -1)
                        p_oRecordSet.Add(oEntity.Record);
                }
            }
        }


        public void Visit(IList p_oRecordSet, List<CSupplier> p_oEntityList)
        {
            foreach (var oEntity in p_oEntityList)
            {
                if (oEntity.Change == EntityChangeType.CREATED)
                {
                    if (p_oRecordSet.IndexOf(oEntity.Record) == -1)
                        p_oRecordSet.Add(oEntity.Record);
                }
            }
        }

        
    }
}
