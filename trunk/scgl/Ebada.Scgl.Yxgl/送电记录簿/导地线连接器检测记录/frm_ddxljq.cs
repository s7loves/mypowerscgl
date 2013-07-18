using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.UI.Base;
using Ebada.Client;
using Ebada.Client.Platform;
using Ebada.Core;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Collections;

namespace Ebada.Scgl.Yxgl
{
    public partial class frm_ddxljq : FormBase, IPopupFormEdit 
    {
        public frm_ddxljq()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员

        private sdjls_ddxljq rowData;
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
                    this.rowData = value as sdjls_ddxljq;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sdjls_ddxljq>(value as sdjls_ddxljq, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {
            IList<sd_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_xl>(" where OrgCode='" + rowData.OrgCode +"'");
            this.cmbLineName.Properties.Items.Clear();
            for (int i = 0; i < xlList.Count; i++)
            {
                ListItem ot = new ListItem();
                ot.DisplayMember = xlList[i].LineName;
                ot.ValueMember = xlList[i].LineCode;
                this.cmbLineName.Properties.Items.Add(ot);
            }
            
        }

        private void dataBind()
        {
            
            this.cmbLineVol.DataBindings.Add("EditValue", rowData, "LineVol");
            this.datejcrq.DataBindings.Add("EditValue", rowData, "jcrq");
           
        }

        #endregion

        

        private void btnOk_Click(object sender, EventArgs e)
        {
            string lineCode = "";
            try
            {
                lineCode = ((Ebada.UI.Base.ListItem)(this.cmbLineName.EditValue)).ValueMember;
            }
            catch
            {
               
            }
            rowData.LineName = cmbLineName.Text;
            rowData.LineCode = lineCode;
            this.DialogResult = DialogResult.OK;
        }

        private void cmbLineName_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cmbLineName.EditValue.ToString()))
                return;
            string lineCode = "";
            try
            {
                 lineCode = ((Ebada.UI.Base.ListItem)(this.cmbLineName.EditValue)).ValueMember;
            }
            catch
            {
                return;
            }
            
            ICollection list = new ArrayList();
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select distinct lineVol from sd_xl where   LineCode='{0}' ", lineCode));
            //cmbLineVol.EditValue = null;
            cmbLineVol.Properties.Items.Clear();
            cmbLineVol.Properties.Items.AddRange(list);
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            
            
        }

        private void frm_ddxljq_Load(object sender, EventArgs e)
        {
            this.cmbLineName.EditValue = rowData.LineName;
        }

       
    }
}