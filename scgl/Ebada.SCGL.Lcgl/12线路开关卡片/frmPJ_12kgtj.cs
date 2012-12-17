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

namespace Ebada.Scgl.Lcgl
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
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            if (string.IsNullOrEmpty(rowData.pdcxmc)) {
                simpleButton1.PerformClick();
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e) {
            string sql = string.Format(" where linecode in (select linecode from ps_gt where gtid in (select gtid from ps_kg where kgid='{0}'))", rowData.kgID);
            PS_xl xl = ClientHelper.PlatformSqlMap.GetOne<PS_xl>(sql);
            if (xl == null) return;
            this.txtpdcxmc.EditValue = rowData.pdcxmc = xl.LineName;
            this.txtjkdxcd.EditValue = rowData.jkdxcd = "" + (xl.TotalLength / 1000);
            //统计容量
            Object num0 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where  tqID in (select tqID from ps_tq where xlCode2 like '" + xl.LineCode + "%')");
            Object num1 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqOwner like '自%' and   tqID in (select tqID from ps_tq where xlCode2 like '" + xl.LineCode + "%')");
            num0 = num0 ?? 0;
            num1 = num1 ?? 0;
            int num2 = (int)num0 - (int)num1;

            this.txtPublicbtrlCount.EditValue = rowData.publicbtrlcount = num2;
            this.txtzybtrlCount.EditValue = rowData.zybtrlcount = (int)num1;
            //统计数量
            num0 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where tqID in (select tqID from ps_tq where xlCode2 like '" + xl.LineCode + "%')");

            num1 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqOwner like '自%' and  tqID in (select tqID from ps_tq where xlCode2 like '" + xl.LineCode + "%')");
            num0 = num0 ?? 0;
            num1 = num1 ?? 0;
            num2 = (int)num0 - (int)num1;
            this.txtPublicbtCount.EditValue = rowData.publicbtcount = num2;
            this.txtzybtCount.EditValue = rowData.zybtcount = (int)num1;
        }
    }
}