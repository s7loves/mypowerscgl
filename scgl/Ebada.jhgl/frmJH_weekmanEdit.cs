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
using System.Collections;

namespace Ebada.jhgl
{
    public partial class frmJH_weekmanEdit : FormBase, IPopupFormEdit
    {

         IList<mOrg> list2 = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where parentid='0' and orgtype='0'");

            //foreach (mOrg org in list2) {
            //    comboBoxEdit4.Properties.Items.Add(org.OrgName, CheckState.Unchecked, true);
        public frmJH_weekmanEdit()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit Members
        private JH_weekman rowData = null;

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
                    this.rowData = value as JH_weekman;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<JH_weekman>(value as JH_weekman, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData()
        {
            //comboBoxEdit2.Properties.Items.AddRange(list);
            ICollection ic = Ebada.Scgl.Core.ComboBoxHelper.GetGdsRy(MainHelper.User.OrgCode);
            foreach (string sr in ic)
            {
                ccboxCooperationMan.Properties.Items.Add(sr, CheckState.Unchecked, true);
            }
            IList<mOrg> list2 = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where parentid='0' and orgtype='0'");
            ICollection ic2 = (ICollection)list2;
            for (int i = 0; i < list2.Count; i++)
            {
                comboxOrgName.Properties.Items.Add(list2[i].OrgName);
            }
           
           
        }

        void dataBind()
        {
            if (rowData.完成时间.Year == 1900)
            {
                rowData.完成时间 = DateTime.Now;
            }
            this.comboxOrgName.DataBindings.Add("EditValue", rowData, "单位名称");
            this.mePlanPro.DataBindings.Add("EditValue", rowData, "计划项目");
            this.meWorkContent.DataBindings.Add("EditValue", rowData, "工作内容");
            this.ccboxCooperationMan.DataBindings.Add("EditValue", rowData, "协作人员");
            this.dateStartDate.DataBindings.Add("EditValue", rowData, "预计时间");
            this.dateEndDate.DataBindings.Add("EditValue", rowData, "预计时间2");
            this.txtComplete.DataBindings.Add("EditValue", rowData, "完成标记");
            this.dateCompleteDate.DataBindings.Add("EditValue", rowData, "完成时间");
            this.meSummryUp.DataBindings.Add("EditValue", rowData, "总结提升");
            this.meUnCompleteReason.DataBindings.Add("EditValue", rowData, "未完成原因");
            this.txtCommentMan.DataBindings.Add("EditValue", rowData, "评语考核人");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
