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
namespace Ebada.Scgl.Sbgl
{
    public partial class frmxlEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_xl> m_CityDic = new SortableSearchableBindingList<PS_xl>();

        public frmxlEdit() {
            InitializeComponent();
            
        }
        
        void dataBind() {

            
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "InDate");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "WireLength");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "TotalLength");
            this.spinEdit3.DataBindings.Add("EditValue", rowData, "TheoryLoss");
            this.spinEdit4.DataBindings.Add("EditValue", rowData, "ActualLoss");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "LineType");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "LineCode");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "LineName");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "LineNamePath");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "LineVol");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "OrgCode");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "OrgCode2");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "Owner");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "Contractor");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "RunState");
            this.comboBoxEdit12.DataBindings.Add("EditValue", rowData, "LineGtbegin");
            this.comboBoxEdit13.DataBindings.Add("EditValue", rowData, "LineGtend");
            this.comboBoxEdit14.DataBindings.Add("EditValue", rowData, "WireType");
            this.comboBoxEdit15.DataBindings.Add("EditValue", rowData, "ParentGT");//分支杆号
        }
        #region IPopupFormEdit Members
        private PS_xl rowData = null;

        public object RowData {
            get {
                PS_xl xl = new PS_xl();
                ConvertHelper.CopyTo(rowData, xl);
                return xl;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_xl;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PS_xl>(value as PS_xl, rowData);
                }
                if(rowData.LineType==""){
                    rowData.InDate = DateTime.Now;
                }
                isnew = false;
                if (rowData.LineVol == "") {
                    rowData.LineVol = "10";
                    
                }
                if(rowData.LineName=="")
                    isnew = true;
            }
        }
        bool isnew = false;
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            this.Invoke(new MethodInvoker(initParentGtList));
            if ("rabbit赵建明".Contains(MainHelper.User.UserName) && !isnew) {
                simpleButton1.Show();
                simpleButton2.Show();
            } else {
                simpleButton1.Hide();
                simpleButton2.Hide();
            }
            groupControl1.Hide();
            groupBox1.Show();
        }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);

            
        }
        #endregion
        private void initParentGtList() {
            //初始分支杆号
            string sql =string.Format("select a.gtcode from ps_gt a ,ps_xl b where a.LineCode=b.Linecode and b.LineID='{0}'",rowData.ParentID);
            IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sql);
            comboBoxEdit15.Properties.Items.Clear();
            comboBoxEdit15.Properties.Items.AddRange(list);
        }
        private void InitComboBoxData() {
            IList<ViewGds> list = Client.ClientHelper.PlatformSqlMap.GetList<ViewGds>("");
            comboBoxEdit7.Properties.DataSource = list;
            IList<mOrg> list2 = Client.ClientHelper.PlatformSqlMap.GetListByWhere<mOrg>(" where Orgtype='2'");
            comboBoxEdit8.Properties.DataSource = list2;
            pdsbModelHelper.FillCBox(comboBoxEdit14, pdsbModelHelper.dxxh);
            ComboBoxHelper.Fillgdsry(comboBoxEdit10, rowData.OrgCode);
            this.comboBoxEdit14.Properties.Items.AddRange(ComboBoxHelper.GetLineTye());
            //this.comboBoxEdit5.Properties.Items.AddRange(ComboBoxHelper.GetVoltage()); 
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
            if (comboBoxEdit2.Text == "")
            {
                MsgBox.ShowTipMessageBox("线路编号不能为空。");
                comboBoxEdit2.Focus();
                return;
            }
            if (comboBoxEdit3.Text == "") {
                MsgBox.ShowTipMessageBox("线路名称不能为空。");
                comboBoxEdit2.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        UCPS_GT gt = null;
        private void simpleButton2_Click(object sender, EventArgs e) {
            groupControl1.Text = rowData.LineName;
            if (gt == null) {
                gt = new UCPS_GT(rowData);
                gt.Dock = DockStyle.Fill;
                groupControl1.Controls.Add(gt);
                
            }
            bool flag = groupBox1.Visible;
            groupBox1.Visible = !flag;
            groupControl1.Visible = flag;
            if (flag)
                simpleButton2.Text = "线路信息";
            else
                simpleButton2.Text = "杆塔信息";
        }

    }
}