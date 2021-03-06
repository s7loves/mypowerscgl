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
    public partial class frm25Edit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_25> m_CityDic = new SortableSearchableBindingList<PJ_25>();

        public frm25Edit() {
            InitializeComponent();
        }
        void dataBind() {



            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "cqdw");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "qdrq");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "Remark");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "bszz");
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "fzcs");
            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_25 rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_25;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_25>(value as PJ_25, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            ComboBoxHelper.FillCBoxByDyk("25电源协议书", "产权单位", comboBoxEdit1.Properties);
            ComboBoxHelper.FillCBoxByDyk("25电源协议书", "闭锁装置", comboBoxEdit3.Properties);
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<PJ_25>(" WHERE Citylevel = '2'"));
          /*  IList<DicType> list = new List<DicType>();
            list.Add(new DicType("0", "机构"));
            list.Add(new DicType("1", "供电所"));
            list.Add(new DicType("2", "变电所"));
            this.SetComboBoxData(this.lookUpEdit1, "Value", "Key", "请选择", "种类", list);*/

            //if (null != cityCode && cityCode.Trim().Length > 0)
            //    this.cltCity.Properties.KeyValue = cityCode;
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
            //DSOFramerControl dsoFramerControl1 = new DSOFramerControl();
            //Microsoft.Office.Interop.Excel.Workbook wb;
            ////if (rowData.BigData==null||rowData.BigData.Length == 0)
            ////{
            //    string fname = Application.StartupPath + "\\00记录模板\\25双自备电源协议书.xls";
            //    dsoFramerControl1.FileOpen(fname);
            ////}
            ////else
            //    //dsoFramerControl1.FileData = rowData.BigData;
            //IList<PJ_25zbdymx> list = Client.ClientHelper.PlatformSqlMap.GetList<PJ_25zbdymx>("where ParentID='"+rowData.ID+"'and Type='发电机'");
            //IList<PJ_25zbdymx> list1 = Client.ClientHelper.PlatformSqlMap.GetList<PJ_25zbdymx>("where ParentID='"+rowData.ID+"'and Type='原动机'");
            //wb = dsoFramerControl1.AxFramerControl.ActiveDocument as Microsoft.Office.Interop.Excel.Workbook;
            //ExcelAccess ea = new ExcelAccess();
            //ea.MyWorkBook = wb;
            //ea.MyExcel = wb.Application;
            //ea.SetCellValue("乙 方："+comboBoxEdit1.Text, 5, 1);
            //ea.SetCellValue(rowData.qdrq.Year.ToString(), 42, 6);
            //ea.SetCellValue(rowData.qdrq.Month.ToString(), 42, 8);
            //ea.SetCellValue(rowData.qdrq.Day.ToString(), 42, 10);
            //for (int i = 0; i < list.Count;i++ )
            //{
            //    ea.SetCellValue(list[i].xh, 26 + i, 1);
            //    ea.SetCellValue("'" + list[i].gl.ToString() + "/" + list[i].ts.ToString(), 26 + i, 2);
            //    ea.SetCellValue(list[i].dy.ToString(), 26 + i,3);
            //    ea.SetCellValue(list[i].azrq.ToString("yyyy-MM-dd"), 26 + i,4);
            //    ea.SetCellValue(list[i].sccj, 26 + i, 5);
            //}
            //for (int i = 0; i < list1.Count; i++)
            //{
            //    ea.SetCellValue(list[i].xh, 26 + i, 8);
            //    ea.SetCellValue("'" + list[i].gl.ToString() + "/" + list[i].ts.ToString(), 26 + i, 11);
            //    ea.SetCellValue(list[i].dy.ToString(), 26 + i,12);
            //    ea.SetCellValue(list[i].azrq.ToString("yyyy-MM-dd"), 26 + i,13);
            //    ea.SetCellValue(list[i].sccj, 26 + i,14);
            //}
            //ea.SetCellValue(rowData.bszz, 30, 2);
            //ea.SetCellValue(rowData.fzcs, 31, 2);
            //dsoFramerControl1.FileSave();
            //rowData.BigData = dsoFramerControl1.FileData;
            //dsoFramerControl1.FileClose();
            //dsoFramerControl1.Dispose();
            //dsoFramerControl1 = null;
        }

      
    }
}