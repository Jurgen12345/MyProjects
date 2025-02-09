using Lib.Logic;
using Lib.UX.DataForms;
using Lib.UX.DataForms.MasterForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.UX.DataGrid
{
    public class CBrowserGridDecorator
    {
        // ....................................................................
        private DataGridView grid;
        public DataGridView Grid { get { return grid; } }
        // ....................................................................
        private IBindingList? _bindingList = null;
        // ....................................................................
        public IEntity? GridCurrentEntity
        {
            get
            {
                IEntity? oResult = null;
                if (this.grid.CurrentRow != null)
                    oResult = this.grid.CurrentRow.DataBoundItem as IEntity;

                return oResult;
            }
        }
        // ....................................................................
        private CMasterFormContext masterFormContext = null;
        // ....................................................................



        // --------------------------------------------------------------------------------------
        public CBrowserGridDecorator(DataGridView p_oWrappedControl, CMasterFormContext p_oFormContext)
        {
            masterFormContext = p_oFormContext;
            grid = p_oWrappedControl;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.KeyDown += DoOnGridKeyDown;
            grid.DoubleClick += DoOnGridDoubleClick;
        }
        // --------------------------------------------------------------------------------------
        public void Populate<T>(List<T> p_oEntityList)
        {
            // Create a BindingsList to allow table edit operations
            _bindingList = new BindingList<T>(p_oEntityList);
            this.grid.DataSource = null;
            this.grid.DataSource = _bindingList;
            this.grid.SetColumnSizes(typeof(T));
            this.grid.Select();
        }
        // --------------------------------------------------------------------------------------
        public void DoOnGridDoubleClick(object? sender, EventArgs e)
        {
            masterFormContext.HandleEvent(masterFormContext.Open);
        }
        // --------------------------------------------------------------------------------------
        private void DoOnGridKeyDown(object? sender, KeyEventArgs e)
        {
            if (!this.grid.ReadOnly)
            {
                if (e.KeyCode == Keys.Enter)
                { 
                    masterFormContext.HandleEvent(masterFormContext.Open);
                    e.Handled = true;
                }
            }
        }
        // --------------------------------------------------------------------------------------

    }
}
