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
    public partial class frm_ksnrEdit : FormBase, IPopupFormEdit 
    {
        public frm_ksnrEdit()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_ksnr rowData;
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
                    this.rowData = value as bdjl_ksnr;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_ksnr>(value as bdjl_ksnr, rowData);
                }
            }
        }

       

        private void dataBind()
        {
            this.memonr.DataBindings.Add("EditValue", rowData, "nr");
            this.memopj.DataBindings.Add("EditValue", rowData, "pj");
        }

        private void Initlkue()
        {

            
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

        private void btnnr_Click(object sender, EventArgs e)
        {
             SelectorHelper.SelectDyk("考试记录", "内容", this.memonr);
             if (!string.IsNullOrEmpty(this.memonr.EditValue as string))
                 rowData.nr = memonr.EditValue as string;
        }

        private void btnpj_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("考试记录", "评价", this.memopj);
            if (!string.IsNullOrEmpty(this.memopj.EditValue as string))
                rowData.pj = memopj.EditValue as string;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(memonr.EditValue as string))
            {
                MsgBox.ShowWarningMessageBox("请填写内容!");
                return;
            }
            if (string.IsNullOrEmpty(memopj.EditValue as string))
            {
                MsgBox.ShowWarningMessageBox("请填写评价!");
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