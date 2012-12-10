using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;
using Ebada.Core;
using Ebada.Scgl.Core;
using Ebada.Client;
using System.Collections;

namespace Ebada.Scgl.Yxgl
{
    public partial class frmPJ_12kgtj : Ebada.UI.Base.FormBase, IPopupFormEdit 
    {
        public frmPJ_12kgtj()
        {
            InitializeComponent();
        }
        #region IPopupFormEdit Members
        private PS_kgjctj rowData = null;

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
                    this.rowData = value as PS_kgjctj;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<PS_kgjctj>(value as PS_kgjctj, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {
            IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select lineName from PS_xl where LineVol='10' and lEFT(LineCode,3)='" + rowData.OrgCode + "' order by LineCode");
            txtpdcxmc.Properties.Items.AddRange(list);
        }

        void dataBind()
        {
            this.txtpdcxmc.DataBindings.Add("EditValue", rowData, "pdcxmc");
            this.txtxdfw.DataBindings.Add("EditValue", rowData, "xdfw");
            this.txtjkdxcd.DataBindings.Add("EditValue", rowData, "jkdxcd");
            this.txtdlxlcd.DataBindings.Add("EditValue", rowData, "dlxlcd");
            this.txtCreateTime.DataBindings.Add("EditValue", rowData, "CreateTime");
            this.txtPublicUserCount.DataBindings.Add("EditValue", rowData, "publicusercount");
            this.txtPublicbtCount.DataBindings.Add("EditValue", rowData, "publicbtcount");
            this.txtPublicbtrlCount.DataBindings.Add("EditValue", rowData, "publicbtrlcount");
            this.txtzyUserCount.DataBindings.Add("EditValue", rowData, "zyusercount");
            this.txtzybtCount.DataBindings.Add("EditValue", rowData, "zybtcount");
            this.txtzybtrlCount.DataBindings.Add("EditValue", rowData, "zybtrlcount");
            this.txtsdyUserCount.DataBindings.Add("EditValue", rowData, "sdyusercount");
            this.txtsdyrlCount.DataBindings.Add("EditValue", rowData, "sdyrlcount");
            this.txtdrqCount.DataBindings.Add("EditValue", rowData, "drqcount");
            this.txtdrqrl.DataBindings.Add("EditValue", rowData, "drqrl");
            this.txtzyUserqtsbCount.DataBindings.Add("EditValue", rowData, "zyuserqtsbcount");
            this.txtzyUserqtsbrl.DataBindings.Add("EditValue", rowData, "zyuserqtsbrlcount");
            this.ckiscxkg.DataBindings.Add("EditValue", rowData, "iscxkg");
        }

        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, object post)
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
    }
}