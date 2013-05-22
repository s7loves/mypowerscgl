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
using Ebada.Scgl.Core;

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
            this.cbxCompleteStatus.Properties.Items.Add("完成");
            this.cbxCompleteStatus.Properties.Items.Add("未完成");
            IList<mUser> userList= Client.ClientHelper.PlatformSqlMap.GetListByWhere<mUser>("where orgcode='" + rowData.单位代码 + "'");
            List<DicType> dicTypeList = new List<DicType>();
            foreach (mUser user in userList)
            {
                dicTypeList.Add(new DicType(user.UserName, user.UserName));
            }
            this.cmbCooperationMan.Properties.DataSource = dicTypeList;
            this.cmbCooperationMan.Properties.DisplayMember = "Value";
            this.cmbCooperationMan.Properties.ValueMember = "Key";
        }

        void dataBind()
        {
            if (rowData.完成时间.Year == 1900)
            {
                rowData.完成时间 = DateTime.Now;
            }
            rowData.单位名称 = MainHelper.User.OrgName;
            this.mePlanPro.DataBindings.Add("EditValue", rowData, "计划项目");
            this.meWorkContent.DataBindings.Add("EditValue", rowData, "工作内容");
            this.cmbCooperationMan.DataBindings.Add("EditValue", rowData, "协作人员");
            this.dateStartDate.DataBindings.Add("EditValue", rowData, "预计时间");
            this.dateEndDate.DataBindings.Add("EditValue", rowData, "预计时间2");
            this.cbxCompleteStatus.DataBindings.Add("EditValue", rowData, "完成标记");
            this.dateCompleteDate.DataBindings.Add("EditValue", rowData, "完成时间");
            this.meSummryUp.DataBindings.Add("EditValue", rowData, "总结提升");
            this.meUnCompleteReason.DataBindings.Add("EditValue", rowData, "未完成原因");
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnPlanPro_Click(object sender, EventArgs e)
        {
            //SelectorHelper.SelectDyk("周工作计划", "计划项目", mePlanPro);
            //rowData.计划项目 = mePlanPro.EditValue.ToString();
            JH_weekmant weekmant = Client.ClientHelper.PlatformSqlMap.GetOne<JH_weekmant>("where id='"+rowData.ParentID+"'");
            if (weekmant == null)
                return;
            frmJH_PlanPro frm = new frmJH_PlanPro();
            frm.year = weekmant.年月周.Substring(0, 4);
            frm.orgcode = rowData.单位代码;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.mePlanPro.EditValue = frm.planPro;
                rowData.计划项目 = frm.planPro;
            }
        }

        private void btnSummryUp_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("周工作计划", "总结提升", meSummryUp);
            rowData.总结提升 = meSummryUp.EditValue.ToString();
        }

        private void btnUnCompleteReason_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("周工作计划", "未完成原因", meUnCompleteReason);
            rowData.未完成原因 = meUnCompleteReason.EditValue.ToString();
        }

        private void btnWrokContent_Click(object sender, EventArgs e)
        {
            JH_weekmant weekmant= Client.ClientHelper.PlatformSqlMap.GetOne<JH_weekmant>("where id='" + rowData.ParentID + "'");
            if (weekmant == null)
                return;
            frmJH_WorkContent frm = new frmJH_WorkContent();
            frm.year = weekmant.年月周.Substring(0, 4);
            frm.orgcode = rowData.单位代码;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                meWorkContent.EditValue = frm.content;
                rowData.工作内容 = frm.content;
            }
        }

    }
}
