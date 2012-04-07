using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Client;
using DevExpress.XtraEditors;
using Ebada.Core;
using Ebada.Scgl.Model;
namespace Ebada.Scgl.Run
{
    public partial class frmModuleEdit : XtraForm ,IPopupFormEdit
    {
        SortableSearchableBindingList<mModule> m_CityDic = new SortableSearchableBindingList<mModule>();
        public frmModuleEdit()
        {
            InitializeComponent();
        }
        private mModule rowData = null;
        void dataBind()
        {

            this.txtName.DataBindings.Add("EditValue", rowData, "ModuName");
            this.txtAssemfileName.DataBindings.Add("EditValue", rowData, "AssemblyFileName");
            this.txtFileName.DataBindings.Add("EditValue", rowData, "ModuTypes");
            this.spesequence.DataBindings.Add("EditValue", rowData, "Sequence");
            this.txtIcoName.DataBindings.Add("EditValue", rowData, "IconName");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "IsCores");
        }
        public object RowData
        {
            get
            {
                return rowData;

            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as mModule;
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<mModule>(value as mModule, rowData);
                }
               
            }
        }

        private void txtIcoName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmSlectIcon dlg = new frmSlectIcon();
           
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(dlg.SelectedImageKey);
                txtIcoName.Text = dlg.SelectedImageKey;
                rowData.IconName = dlg.SelectedImageKey;
            }
        }

      
        
    }
}