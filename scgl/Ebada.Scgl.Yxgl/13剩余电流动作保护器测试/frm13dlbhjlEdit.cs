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
    public partial class frm13dlbhjlEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_13dlbhjl> m_CityDic = new SortableSearchableBindingList<PJ_13dlbhjl>();

        public frm13dlbhjlEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.dateEdit1.DataBindings.Add("EditValue", rowData, "rq");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "dzdl");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "yxqk");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "csr");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "dzsj");

        }
        #region IPopupFormEdit Members
        private PJ_13dlbhjl rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_13dlbhjl;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_13dlbhjl>(value as PJ_13dlbhjl, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            ComboBoxHelper.FillCBoxByDyk("13剩余电流动作保护器测试记录", "动作电流（mA）", comboBoxEdit1);
            ComboBoxHelper.FillCBoxByDyk("13剩余电流动作保护器测试记录", "动作时间（S）", comboBoxEdit4);
            ComboBoxHelper.FillCBoxByDyk("13剩余电流动作保护器测试记录", "运行情况", comboBoxEdit2);
            if (rowData.csr == "")
            {
                rowData.CreateDate = DateTime.Now;
                rowData.rq = DateTime.Now;
            }
           // PJ_13dlbhjl pj = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PJ_05jcky>(rowData.jckyID);
            this.comboBoxEdit3.Properties.Items.AddRange(ComboBoxHelper.GetGdsRy(rowData.OrgCode));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        /// <param name="nullTest"></param>
        /// <param name="cnStr"></param>
        /// <param name="post"></param>
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post) {
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit3.Text == "")
            {
                MsgBox.ShowTipMessageBox("测试人不能为空。");
                comboBoxEdit3.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    

      
    }
}