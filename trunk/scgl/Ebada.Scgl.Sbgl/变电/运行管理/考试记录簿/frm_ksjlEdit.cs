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

namespace Ebada.Scgl.Sbgl
{
    public partial class frm_ksjlEdit : FormBase, IPopupFormEdit 
    {
        public frm_ksjlEdit()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_ksjl rowData;
        public object RowData
        {
            get
            {
                return this.rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as bdjl_ksjl;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_ksjl>(value as bdjl_ksjl, rowData);
                }
            }
        }

       

        private void dataBind()
        {
            this.cmbksxm.DataBindings.Add("EditValue", rowData, "Ksxm");
            this.txtUserName.DataBindings.Add("EditValue", rowData, "UserName");
            this.txtPostName.DataBindings.Add("EditValue", rowData, "PostName");
            this.spePostAge.DataBindings.Add("EditValue", rowData, "PostAge");
            this.dateLastExamTime.DataBindings.Add("EditValue", rowData, "LastExamTime");
            this.timeStartTime.DataBindings.Add("EditValue", rowData, "ExamStartTime");
            this.ExamEndTime.DataBindings.Add("EditValue", rowData, "ExamEndTime");
        }

        private void Initlkue()
        {
            ComboBoxHelper.FillCBoxByDyk("考试记录","考试项目",cmbksxm);
            
        }

        //SetComboBoxData(lkueStartGt, "Value", "Key", "请选择", "起始杆塔", gtDictypeList);
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post)
        {
            comboBox.Properties.Columns.Clear();
            comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBox.Properties.DataSource = post;
            comboBox.Properties.DisplayMember = displayMember;
            comboBox.Properties.ValueMember = valueMember;
            comboBox.Properties.NullText = nullTest;
            comboBox.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(valueMember, "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember, cnStr)});
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbksxm.EditValue as string))
            {
                MsgBox.ShowWarningMessageBox("请选择考试项目!");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

       
    }
}