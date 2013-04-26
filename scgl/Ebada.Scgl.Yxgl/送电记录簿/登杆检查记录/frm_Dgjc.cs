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
    public partial class frm_Dgjc : FormBase, IPopupFormEdit 
    {
        public frm_Dgjc()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员

        private sdjls_dgjcjl rowData;
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
                    this.rowData = value as sdjls_dgjcjl;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sdjls_dgjcjl>(value as sdjls_dgjcjl, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {
            IList<mOrg> orglist = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where c1='是' order by orgcode");
            foreach (mOrg org in orglist)
            {
                ListItem item = new ListItem();
                item.DisplayMember = org.OrgName;
                item.ValueMember = org.OrgCode;
                cmbOrg.Properties.Items.Add(item);
            }
        }

        private void dataBind()
        {
            //this.cmbOrg.DataBindings.Add("EditValue", rowData, "OrgCode");
            //this.cmbline.DataBindings.Add("EditValue", rowData, "LineCode");
            cmbOrg.EditValue = rowData.OrgName;
            cmbline.EditValue = rowData.LineName;
            this.cmbLineVol.DataBindings.Add("EditValue", rowData, "LineVol");
        }

        #endregion

        private void cmbOrg_EditValueChanged(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(cmbOrg.EditValue.ToString()))
                return;
            string orgCode = ((Ebada.UI.Base.ListItem)(cmbOrg.EditValue)).ValueMember;
            IList<sd_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetList<sd_xl>("where OrgCode ='"+orgCode+"'");
            if (xlList == null)
                return;
            if (xlList.Count == 0)
                return;
            foreach (sd_xl xl in xlList)
            {
                ListItem item = new ListItem();
                item.DisplayMember = xl.LineName;
                item.ValueMember = xl.LineCode;
                cmbline.Properties.Items.Add(item);
            }
            rowData.OrgCode = orgCode;
            rowData.OrgName = cmbOrg.Text;
        }
        private void cmbline_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbline.EditValue.ToString()))
                return;
            string lineCode = ((Ebada.UI.Base.ListItem)(this.cmbline.EditValue)).ValueMember;
            ICollection list = new ArrayList();
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select distinct lineVol from sd_xl where   LineCode='{0}' ", lineCode));
            cmbLineVol.Properties.Items.AddRange(list);
            rowData.LineCode = lineCode;
            rowData.LineName = cmbline.Text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbOrg.EditValue == null)
            {
                MsgBox.ShowWarningMessageBox("请选择单位!");
                return;
            }
            if (cmbline.EditValue == null)
            {
                MsgBox.ShowWarningMessageBox("请选择线路!");
                return;
            }
            if (cmbLineVol.EditValue == null)
            {
                MsgBox.ShowWarningMessageBox("请选择电压!");
                return;
            }
            IList<sdjls_dgjcjl> dgjlList= Client.ClientHelper.PlatformSqlMap.GetListByWhere<sdjls_dgjcjl>("where orgcode='"+cmbOrg.EditValue.ToString()+"' and linecode='"
                +cmbline.EditValue.ToString()+"' and linevol='"+cmbLineVol.EditValue.ToString()+"'");
            if (dgjlList.Count == 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}