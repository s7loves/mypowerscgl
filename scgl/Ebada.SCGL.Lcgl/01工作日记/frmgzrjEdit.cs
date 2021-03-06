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
namespace Ebada.Scgl.Lcgl {
    public partial class frmgzrjEdit : FormBase, IPopupFormEdit {
        //SortableSearchableBindingList<PJ_01gzrj> m_CityDic = new SortableSearchableBindingList<PJ_01gzrj>();

        public frmgzrjEdit() {
            InitializeComponent();
        }
        void dataBind() {
            //this.textEdit1.DataBindings.Add("EditValue", rowData, "rq");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "rq");
            this.textEdit2.DataBindings.Add("EditValue", rowData, "xq");
            this.cBoxTq.DataBindings.Add("EditValue", rowData, "tq");
            this.textEdit4.DataBindings.Add("EditValue", rowData, "rsaqts");
            this.textEdit5.DataBindings.Add("EditValue", rowData, "sbaqts");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "js",false, DataSourceUpdateMode.OnPropertyChanged);
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "py",false, DataSourceUpdateMode.OnPropertyChanged);
            this.comboBoxEdit21.DataBindings.Add("EditValue", rowData, "qz");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "qzrq");

        }
        void setqqry() {
            string str = rowData.qqry;
            string[] mans = str.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < 10; i++) {
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue = "";
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 11)]).EditValue = "";
            }
            for (int i = 0; i < mans.Length; i++) {
                string[] ry = mans[i].Split(':');
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue = ry[0];
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 11)]).EditValue = ry[1];
            }
        }
        void getqqry() {
            string str = "";
            string ry = "";
            string yy = "";
            for (int i = 0; i < 10; i++) {
                ry = ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue.ToString();
                yy = ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 11)]).EditValue.ToString();
                if (!string.IsNullOrEmpty(ry.Trim()))
                    str += ry + ":" + yy + ";";
            }
            rowData.qqry = str;
        }
        #region IPopupFormEdit Members
        private PJ_01gzrj rowData = null;

        public object RowData {
            get {
                getqqry();
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_01gzrj;
                    this.InitComboBoxData();

                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_01gzrj>(value as PJ_01gzrj, rowData);
                }
                InitGdsRy();
                setqqry();
                if(rowData.js==""){
                    rowData.qzrq = DateTime.Now;
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            IList<PJ_dyk> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid!=''", "01工作日记", "原因"));
            object[] yylist=new object[list.Count];
            for (int i = 0; i < list.Count;i++ )
            {
                yylist[i] = list[i].nr;
            }
            for (int i = 0; i < 10; i++) {
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 11)]).Properties.Items.AddRange(yylist);
            }

            this.cBoxTq.Properties.Items.AddRange(ComboBoxHelper.GetTQ());//设置天气列表
        }
        string gdscode = "";
        private void InitGdsRy() {
            if (gdscode == rowData.GdsCode) return;
            gdscode = rowData.GdsCode;
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.GdsCode);//获取供电所人员列表
            for (int i = 0; i < 10; i++) {
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).Properties.Items.Clear();
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).Properties.Items.AddRange(ryList);

            }
            comboBoxEdit21.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("公用属性", "签字人", comboBoxEdit21);
            //comboBoxEdit21.Properties.Items.AddRange(ryList);
        }
        
        private void textEdit1_EditValueChanged(object sender, EventArgs e) {

        }

        private void groupControlOrg_Paint(object sender, PaintEventArgs e) {

        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            SelectorHelper.SelectDyk("01工作日记", "记事", memoEdit1);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("01工作日记", "领导检查评语", memoEdit2);
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            DateTime dt=Convert.ToDateTime (dateEdit2.Text );
            textEdit2.Text = "星期" + dt.ToString("ddd",new System.Globalization.CultureInfo("zh-cn"));
            rowData.xq = textEdit2.Text;
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOne <mOrg>("where orgcode='" + rowData.GdsCode + "'");
            if (org != null)
            {
                rowData.rsaqts = (dt - org.PSafeTime.Date).Days;
                rowData.sbaqts = (dt - org.DSafeTime.Date).Days;
            }
            this.textEdit4.Text= rowData.rsaqts.ToString();
            this.textEdit5.Text = rowData.sbaqts.ToString();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmorgRySelect fr = new frmorgRySelect();
            fr.gdscode = rowData.GdsCode;
            DataTable dt = new DataTable();
            if (fr.ShowDialog()==DialogResult.OK)
            {
                dt = fr.DT1;
                if (MsgBox.ShowAskMessageBox("是否确认快速写入人名") == DialogResult.OK)
                {
                    if (dt.Rows.Count >= 10)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue = dt.Rows[i][0].ToString();
                           // ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 10)]).EditValue = dt.Rows[i+5][0].ToString();
                        }
                        
                    }
                    else
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue = dt.Rows[i][0].ToString();
                            //if (dt.Rows.Count<=5)
                            //{
                            //    ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue = dt.Rows[i][0].ToString();
                            //}
                            //else
                            //{
                            //    if (i<5)
                            //    {
                            //        ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue = dt.Rows[i][0].ToString();
                            //    }
                            //    else
                            //    {
                            //        ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 6)]).EditValue = dt.Rows[i][0].ToString();
                            //    }
                            //}
                        }
                    }
                }
            }
        }
    }
}