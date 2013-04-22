﻿using System;
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
using System.Text.RegularExpressions;
namespace Ebada.Scgl.Yxgl
{
    public partial class frmSDaqgjEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<sdjl_aqgj> m_CityDic = new SortableSearchableBindingList<sdjl_aqgj>();

        public frmSDaqgjEdit()
        {
            InitializeComponent();
        }
        void dataBind() {


            this.dateEdit1.DataBindings.Add("EditValue", rowData, "syrq");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "syrq2");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "sbCode");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "syzq");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "sbModle");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "sbType");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "syxm");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "sbName");

            //this.textEdit1.DataBindings.Add("EditValue", rowData, "tq");
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private sdjl_aqgj rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as sdjl_aqgj;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<sdjl_aqgj>(value as sdjl_aqgj, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData()
        {
            IList<sd_gtsb> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_gtsb>("where gtid in(select gtid from sd_gt where linecode in (select linecode from sd_xl where OrgCode='" + rowData.OrgID + "'))");
            foreach (sd_gtsb pt in list)
            {
                comboBoxEdit5.Properties.Items.Add(pt.sbName);
                comboBoxEdit2.Properties.Items.Add(pt.sbType);
                comboBoxEdit1.Properties.Items.Add(pt.sbModle);
            }
            ComboBoxHelper.FillCBoxByDyk("14电力安全工具试验记录", "工具名称", comboBoxEdit5.Properties);
           // ComboBoxHelper.FillCBoxByDyk("14电力安全工具试验记录", "编号", comboBoxEdit3.Properties);
            ComboBoxHelper.FillCBoxByDyk("14电力安全工具试验记录", "试验周期", comboBoxEdit7.Properties);
           // ComboBoxHelper.FillCBoxByDyk("14电力安全工具试验记录", "试验项目", comboBoxEdit4.Properties);
            IList<sdjl_dyk> dic = new List<sdjl_dyk>();
            sdjl_dyk di = new sdjl_dyk();
            di.nr = "工频耐压";
            
            dic.Add(di);
            di = new sdjl_dyk();
            di.nr = "绝缘电阻";
            dic.Add(di);
            di = new sdjl_dyk();
            di.nr = "成组绝缘电阻";
            dic.Add(di);
            di = new sdjl_dyk();
            di.nr = "直流电阻";
            dic.Add(di);

            ////this.InitionData(this.cltOrderState, "DicItemCnName", "DicItemCode", "请选择", "类型名称", dic);
            this.InitionData(this.comboBoxEdit4, "nr", "nr", "请选择", "实验项目", dic);

          }

        private void InitionData(DevExpress.XtraEditors.CheckedComboBoxEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, object post)
        {
            comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBox.Properties.DataSource = post;
            comboBox.Properties.DisplayMember = displayMember;
            comboBox.Properties.ValueMember = valueMember;
            comboBox.Properties.NullText = nullTest;
            comboBox.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(valueMember, "ID", 15, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember, cnStr)});
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

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControlOrg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmdlgzdhjtjlEdit_Load(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click_1(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Regex r1 = new Regex(@"[[0-9]+.[0-9]+|[0-9]+]");
            string strvalue = r1.Match(comboBoxEdit7.Text).Value;
            if (strvalue == "")
            {
                MsgBox.ShowWarningMessageBox("试验周期格式不对");
                return;
            }
        }
    }
}