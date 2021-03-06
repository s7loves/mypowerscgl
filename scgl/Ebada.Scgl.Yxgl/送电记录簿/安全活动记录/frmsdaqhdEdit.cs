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
    public partial class frmsdaqhdEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<sdjl_02aqhd> m_CityDic = new SortableSearchableBindingList<sdjl_02aqhd>();

        public frmsdaqhdEdit()
        {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit26.DataBindings.Add("EditValue", rowData, "zcr");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "kssj");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "jssj");
            //this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "cjry");
            //this.comboBoxEdit28.DataBindings.Add("EditValue", rowData, "qxry");
            this.memohdnr.DataBindings.Add("EditValue", rowData, "hdnr", false, DataSourceUpdateMode.OnPropertyChanged);
            this.memofxczwt.DataBindings.Add("EditValue", rowData, "hdxj", false, DataSourceUpdateMode.OnPropertyChanged);
            this.memoEdit4.DataBindings.Add("EditValue", rowData, "py");
            this.memofyjyjl.DataBindings.Add("EditValue", rowData, "fyjyjl", false, DataSourceUpdateMode.OnPropertyChanged);
            this.comboBoxEdit27.DataBindings.Add("EditValue", rowData, "qz");
            this.dateEdit4.DataBindings.Add("EditValue", rowData, "qzrq");
            this.memoffdc.DataBindings.Add("EditValue", rowData, "c1");

        }
        #region IPopupFormEdit Members
        private sdjl_02aqhd rowData = null;

        public object RowData {
            get {
                getqqry();
                getcqry();
                return rowData;
              
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as sdjl_02aqhd;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<sdjl_02aqhd>(value as sdjl_02aqhd, rowData);
                }
                setqqry();
                setcqry();
                if (MainHelper.UserOrg.OrgType == "1")
                {
                    groupBox2.Enabled = true;
                    groupBox1.Enabled = true;
                    groupBox6.Enabled = true;
                    groupBox3.Enabled = true;

                    groupBox7.Enabled = false;
                }
                else if (MainHelper.UserOrg.OrgType == "0")
                {
                    //groupBox2.Enabled = false;
                    //groupBox1.Enabled = false;
                    //groupBox6.Enabled = false;
                    //groupBox3.Enabled = false;

                    groupBox7.Enabled = true;
                }
            }
        }

        #endregion
        void setqqry()
        {
            string str = rowData.qxry;
            string[] mans = str.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 28; i <= 32; i++)
            {
                ((ComboBoxEdit)groupBox6.Controls["comboBoxEdit" + i]).EditValue = "";
               
            }
            for (int i = 0; i < mans.Length; i++)
            {
               
                ((ComboBoxEdit)groupBox6.Controls["comboBoxEdit" + (i+28)]).EditValue = mans[i];
               
            }
        }
        void getqqry()
        {
            string str = "";
            string yy = "";
            for (int i = 28; i <=32; i++)
            {
               
                yy = ((ComboBoxEdit)groupBox6.Controls["comboBoxEdit" + i]).EditValue.ToString();
                if (!string.IsNullOrEmpty(yy.Trim()))
                    str +=  yy + ";";
            }
            rowData.qxry = str;
        }
        void setcqry()
        {
            string str = rowData.cjry;
            string[] mans = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i <= 25; i++)
            {
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + i]).EditValue = "";
            }
            
            for (int i = 0; i < mans.Length; i++)
            {
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i+1)]).EditValue = mans[i];

            }
        }
        void getcqry()
        {
            string str = "";
            string yy = "";
            for (int i = 1; i <= 25; i++)
            {
                yy = ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + i]).EditValue.ToString();
                if (!string.IsNullOrEmpty(yy.Trim()))
                    str += yy + ";";
            }
            rowData.cjry = str;
        }


        private void InitComboBoxData() {
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表
            
            for (int i = 1; i <=25; i++)
            {
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i)]).Properties.Items.AddRange(ryList);
            }
            for (int i = 28; i <= 32; i++)
            {

                ((ComboBoxEdit)groupBox6.Controls["comboBoxEdit" + (i)]).Properties.Items.AddRange(ryList);

            }
            ((ComboBoxEdit)groupBox1.Controls["comboBoxEdit" + 26]).Properties.Items.AddRange(ryList);
            
            //string zhi = "领导";
            // ICollection   list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select UserName from mUser where Type like'%" + zhi + "%'");
            //((ComboBoxEdit)groupBox7.Controls["comboBoxEdit" + 6]).Properties.Items.AddRange(list);
            ComboBoxHelper.FillCBoxByDyk("公用属性", "签字人", ((ComboBoxEdit)groupBox7.Controls["comboBoxEdit" + 27]).Properties);
            
            //填充下拉列表数据
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //SelectorHelper.SelectDyk("02安全活动记录簿", "安全活动内容", memoEdit1, memoEdit1,memoEdit2, memoEdit5);
            PJ_dyk dyk = SelectorHelper.SelectDyk("送电安全活动记录簿", "安全活动内容", memohdnr, memofxczwt, memoffdc, memofyjyjl);
            if (dyk != null)
            {
                rowData.hdnr = dyk.nr;
                rowData.hdxj = dyk.nr2;
                rowData.c1 = dyk.nr3;
                rowData.fyjyjl = dyk.nr4;
            }
            //memoEdit5.Update();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmorgRySelect fr = new frmorgRySelect();
            fr.gdscode = rowData.OrgCode;
            DataTable dt = new DataTable();
            if (fr.ShowDialog() == DialogResult.OK)
            {

                ResetCqry();
                dt = fr.DT1;
                if (MsgBox.ShowAskMessageBox("是否确认快速写入人名") == DialogResult.OK)
                {
                    int count = 25;
                    if (dt.Rows.Count < 25)
                        count = dt.Rows.Count;
                    int j = 1;
                    for (int i = 1; i <= count; i++)
                    {
                        if ((bool)dt.Rows[i - 1][1] == true)
                        {
                            ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + j]).EditValue = dt.Rows[i - 1][0].ToString();
                            j++;
                        }
                    }
                }
            }
        }

        private void ResetCqry()
        {
            for (int i = 1; i <= 25; i++)
            {
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + i]).EditValue = string.Empty;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("送电安全活动记录簿", "工作评语", memoEdit4);
            if (!string.IsNullOrEmpty(memoEdit4.EditValue as string))
                rowData.py = memoEdit4.EditValue as string;
        }
    }
}