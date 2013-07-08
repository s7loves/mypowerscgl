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
    public partial class frmSD26Edit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<sdjl_26> m_CityDic = new SortableSearchableBindingList<sdjl_26>();

        public frmSD26Edit()
        {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "tzdw");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "lineVol");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "tzrq");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "Remark");
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "fxwt");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "clcs");
            this.lkuexlmc.DataBindings.Add("EditValue", rowData, "c1");
            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private sdjl_26 rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as sdjl_26;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<sdjl_26>(value as sdjl_26, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<sdjl_26>(" WHERE Citylevel = '2'"));
          /*  IList<DicType> list = new List<DicType>();
            list.Add(new DicType("0", "机构"));
            list.Add(new DicType("1", "供电所"));
            list.Add(new DicType("2", "变电所"));
            this.SetComboBoxData(this.lookUpEdit1, "Value", "Key", "请选择", "种类", list);*/

            //if (null != cityCode && cityCode.Trim().Length > 0)
            //    this.cltCity.Properties.KeyValue = cityCode;
            ComboBoxHelper.FillCBoxByDyk("送电电力线路防护通知书", "通知单位", comboBoxEdit1.Properties);
            ComboBoxHelper.FillCBoxByDyk("送电电力线路防护通知书", "电压等级", comboBoxEdit3.Properties);
           IList<sd_xl> xsList= Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_xl>("where orgcode='" + rowData.ParentID + "'");
           List<DicType> dicxlList = new List<DicType>();
           foreach (sd_xl xl in xsList)
           {
               dicxlList.Add(new DicType(xl.LineName, xl.LineName));
           }
           SetComboBoxData(this.lkuexlmc, "Value", "Key", "请选择", "线路名称", dicxlList);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Client.ClientHelper.PlatformSqlMap.Create<sdjl_26>(rowData);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           PJ_dyk pjdyk= SelectorHelper.SelectDyk("送电电力线路防护通知书", "防护信息", memoEdit2, memoEdit3, memoEdit1);
           if (pjdyk != null)
           {
               rowData.fxwt = pjdyk.nr;
               rowData.clcs = pjdyk.nr2;
               rowData.Remark = pjdyk.nr3;
           }
        }

      
    }
}