using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lib.Logic;
using Lib.UX.DataForms;
using Lib.UX.DataGrid;

namespace Invoices.UX
{
    public class CViewBrowserDefault<T> : IBrowserViewForm
    {
        private CFormTemplateMaster? _parent = null;
        private List<T> browserModel;

        public bool HasSelectedInBrowser
        {
            get
            {
                bool bResult = false;
                if (_parent?.BrowserGrid.GridCurrentEntity != null)
                {
                    IEntity? oCurrentEntity = _parent?.BrowserGrid.GridCurrentEntity as IEntity;
                    if (oCurrentEntity != null)
                        bResult = oCurrentEntity.PrimaryKeyValue > 0;
                }

                return bResult;
            }
        }

        public IEntity? SelectedEntity
        {
            get
            {
                return _parent?.BrowserGrid.GridCurrentEntity;
            }
        }

        public CViewBrowserDefault(List<T> p_oBrowserModel)
        {
            this.browserModel = p_oBrowserModel;
        }

        public void SetParent(Form p_oForm)
        {
            _parent = (CFormTemplateMaster) p_oForm;
        }

        public void Dock(Control p_oContainer) { }

        public void WriteBrowserListToTheUI()
        {
            _parent?.BrowserGrid.Populate<T>(browserModel);
        }

    }
}
