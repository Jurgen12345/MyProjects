using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// LOOSELY-COUPLED DESIGN: There are no dependencies to custom code, and this template form could be moved to the library
using Lib.UX.DataGrid;
using Lib.Logic;
using Lib.UX.DataForms.TableForm;

namespace Invoices.UX
{
    public partial class CFormTemplateTable : Form
    {
        protected CEditableGridDecorator editableGridRecords;
        protected CTableFormContext formContext;

        // --------------------------------------------------------------------------------------
        public CFormTemplateTable()
        {
            InitializeComponent();
            
            // Creates a new context and assigns the controls that will be handled by the states of the context.
            // Then initializes the context with the initial state.
            this.formContext = new CTableFormContext(this.btnLoadTable, this.btnSaveTable, this.btnCancel);
            this.formContext.Initialize(typeof(CTableFormStateInitial));

            
            this.editableGridRecords = new CEditableGridDecorator(this.gridRecords, this.formContext);
        }
        // --------------------------------------------------------------------------------------
        // [PATTERNS] Template Method: The skeleton of the table editing form functionality is defined here,
        //  it lets a descendand override some parts with custom functionality, but the descendand cannot
        // fully override the logic
        private void doLoad()
        {
            if (LoadModule())
            { 
                this.DisplayModelEntitiesOnGrid();
                this.formContext.PerformAction("TableLoaded");
            }
            else
                MessageBox.Show(LastErrorMessage(), " Error");
        }
        // --------------------------------------------------------------------------------------
        // [PATTERNS] Template Method: The skeleton of the table editing form functionality is defined here,
        //  it lets a descendand override some parts with custom functionality, but the descendand cannot
        // fully override the logic
        private void doSave()
        {
            DialogResult oResult = MessageBox.Show("Save changes?", "Warning"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (oResult == DialogResult.Yes)
            { 
                if (SaveModule())
                {
                    this.gridRecords.DataSource = null;
                    if (LoadModule())
                    { 
                        this.DisplayModelEntitiesOnGrid();
                        this.formContext.PerformAction("TableLoaded");
                    }
                    else
                        MessageBox.Show(LastErrorMessage(), "Error");
                }
                else
                    MessageBox.Show(LastErrorMessage(), "Error");
            }
        }
        // --------------------------------------------------------------------------------------
        private void doCancel()
        {
            DialogResult oResult = MessageBox.Show("Cancel changes?", "Warning"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (oResult == DialogResult.Yes)
                doLoad();
        }
        // --------------------------------------------------------------------------------------
        private void DoOnAnyCommand(object sender, EventArgs e)
        {
            if (sender == this.btnLoadTable)
                doLoad();
            else if (sender == this.btnSaveTable)
                doSave();
            else
                doCancel();
        }
        // --------------------------------------------------------------------------------------


        #region // Virtual Methods \\
        // --------------------------------------------------------------------------------------
        protected virtual void CreateDataModule()
        {
        }
        // --------------------------------------------------------------------------------------
        protected virtual void DisplayModelEntitiesOnGrid()
        {
        }
        // --------------------------------------------------------------------------------------
        protected virtual bool IsModuleLoaded()
        {
            return false;
        }
        // --------------------------------------------------------------------------------------
        protected virtual bool LoadModule()
        {
            return false;
        }
        // --------------------------------------------------------------------------------------
        protected virtual bool SaveModule()
        {
            return false;
        }
        // --------------------------------------------------------------------------------------
        protected virtual string LastErrorMessage()
        {
            return String.Empty;
        }
        // --------------------------------------------------------------------------------------
        #endregion
    }
}
