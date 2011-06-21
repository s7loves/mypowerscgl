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
    public partial class frmtqdlbhEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_tqdlbh> m_CityDic = new SortableSearchableBindingList<PS_tqdlbh>();

        public frmtqdlbhEdit() {
            InitializeComponent();
        }
        private string lineCode = "";

        public string LineCode
        {
            get { return lineCode; }
            set { lineCode = value; }
        }

        void dataBind() {



            this.textEdit1.DataBindings.Add("EditValue", rowData, "sbCode");
            this.textEdit2.DataBindings.Add("EditValue", rowData, "Number");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "MadeDate");
            this.dateEdit4.DataBindings.Add("EditValue", rowData, "InDate");
            this.dateEdit5.DataBindings.Add("EditValue", rowData, "InstallDate");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "State");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "sbModle");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "glr");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "dzdl");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "tqID");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "InstallAdress");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "dzsj");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "sbName");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "Factory");

        }
        #region IPopupFormEdit Members
        private PS_tqdlbh rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_tqdlbh;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PS_tqdlbh>(value as PS_tqdlbh, rowData);
                }
                if(rowData.sbCode==""){
                    rowData.InstallDate = DateTime.Now;
                    rowData.InDate = DateTime.Now;
                    rowData.MadeDate = DateTime.Now;
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            IList<PJ_dyk> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid!=''", "13剩余电流动作保护器测试记录", "额定漏电动作电流"));
            object[] yylist = new object[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                yylist[i] = list[i].nr;
            }
            this.comboBoxEdit4.Properties.Items.AddRange(yylist);
            IList<PJ_dyk> list2 = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid!=''", "13剩余电流动作保护器测试记录", "型   号"));
            object[] yylist2 = new object[list2.Count];
            for (int i = 0; i < list2.Count; i++)
            {
                yylist2[i] = list2[i].nr;
            }
            this.comboBoxEdit2.Properties.Items.AddRange(yylist2);
            IList<PJ_dyk> list3 = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid!=''", "13剩余电流动作保护器测试记录", "制造厂名"));
            object[] yylist3 = new object[list3.Count];
            for (int i = 0; i < list3.Count; i++)
            {
                yylist3[i] = list3[i].nr;
            }
            this.comboBoxEdit9.Properties.Items.AddRange(yylist3);
            IList<PJ_dyk> list4 = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid!=''", "13剩余电流动作保护器测试记录", "额定漏电动作时间"));
            object[] yylist4 = new object[list4.Count];
            for (int i = 0; i < list4.Count; i++)
            {
                yylist4[i] = list4[i].nr;
            }
            this.comboBoxEdit7.Properties.Items.AddRange(yylist4);

            IList<PS_tq> listtq = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>("where xlCode='" + lineCode + "'");
            comboBoxEdit5.Properties.DataSource = listtq;

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
            if (comboBoxEdit5.Text == "")
            {
                MsgBox.ShowTipMessageBox("台区名称不能为空。");
                comboBoxEdit5.Focus();
                return;
            }
            if (textEdit1.Text == "")
            {
                MsgBox.ShowTipMessageBox("设备编号不能为空。");
                textEdit1.Focus();
                return;
            }
            rowData.tqName = comboBoxEdit5.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}