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
namespace Ebada.Scgl.Yxgl
{
    public partial class frmtqbyqEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_tqbyq> m_CityDic = new SortableSearchableBindingList<PS_tqbyq>();

        public frmtqbyqEdit() {
            InitializeComponent();
        }
        void dataBind() {

            this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "tqID");

            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "byqCode");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "byqName");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "byqModle");
            this.checkEdit1.DataBindings.Add("EditValue", rowData, "omniseal");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "byqOwner");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "byqVol");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "byqPhase");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "byqCapcity");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "byqLineGroup");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "byqFactory");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "byqNumber");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "byqMadeDate");
            this.comboBoxEdit12.DataBindings.Add("EditValue", rowData, "byqCycle");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "byqVolOne");
            this.spinEdit3.DataBindings.Add("EditValue", rowData, "byqVolTwo");
            this.spinEdit4.DataBindings.Add("EditValue", rowData, "byqCurrentOne");
            this.spinEdit5.DataBindings.Add("EditValue", rowData, "byqCurrentTwo");
            this.dateEdit4.DataBindings.Add("EditValue", rowData, "byqInstallDate");
            this.comboBoxEdit14.DataBindings.Add("EditValue", rowData, "byqInstallAdress");
            this.comboBoxEdit13.DataBindings.Add("EditValue", rowData, "byqState");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "InDate");
          
        }
        #region IPopupFormEdit Members
        private PS_tqbyq rowData = null;

        public object RowData {
            get {
                if (rowData.byqMadeDate.Year < 1900) rowData.byqMadeDate = DateTime.Parse("2000-01-01");
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_tqbyq;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PS_tqbyq>(value as PS_tqbyq, rowData);
                }
                if (rowData.byqCode == "")
                {
                    rowData.byqInstallDate = DateTime.Now;
                    rowData.byqMadeDate = DateTime.Now;
                    rowData.InDate = DateTime.Now;
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            IList<PS_tq> tqlist = Client.ClientHelper.PlatformSqlMap.GetList<PS_tq>("");

            SetComboBoxData(lookUpEdit1, "tqName", "tqID", "选择台区", "", tqlist);



            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "型号", comboBoxEdit3.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "制造厂", comboBoxEdit10.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "一次电压", spinEdit2.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "二次电压", spinEdit3.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", " 一  次  额定电流", spinEdit4.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", " 二  次  额定电流", spinEdit5.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "容量", spinEdit1.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "相别", comboBoxEdit8.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "结线组别", comboBoxEdit9.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "周  波", comboBoxEdit12.Properties);
           
       
        
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<PS_tq> post)
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue==null||lookUpEdit1.EditValue.ToString()=="")
            {
                MsgBox.ShowTipMessageBox("请选择台区。");
                return;
            }
            if (comboBoxEdit1.Text == "")
            {
                MsgBox.ShowTipMessageBox("变压器编号不能为空。");
                comboBoxEdit1.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            rowData.tqID = lookUpEdit1.EditValue.ToString();
            //string constr = "where tqID='" + lookUpEdit1.EditValue.ToString() + "'";
            //IList<PS_tqbyq> byqlist = Client.ClientHelper.PlatformSqlMap.GetList<PS_tqbyq>("SelectPS_tqbyqList", constr);
            //comboBoxEdit1.Properties.Items.Clear();
            //comboBoxEdit2.Properties.Items.Clear();

            //for (int i = 0; i < byqlist.Count; i++)
            //{
            //    comboBoxEdit1.Properties.Items.Add(byqlist[i].byqCode);
            //    comboBoxEdit2.Properties.Items.Add(byqlist[i].byqName);
            //}
        }
    
    }
}