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
using Ebada.Scgl.WFlow;
using System.Threading;
namespace Ebada.Scgl.Yxgl
{
    public partial class frmSDyxfxEdit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<sdjl_03yxfx> m_CityDic = new SortableSearchableBindingList<sdjl_03yxfx>();

        public frmSDyxfxEdit()
        {
            InitializeComponent();
            //IniControlStatus();
        }
        void dataBind()
        {


            this.comboBoxEdit16.DataBindings.Add("EditValue", rowData, "zcr");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "rq");
            this.dateEdit4.DataBindings.Add("EditValue", rowData, "qzrq");
            //this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "cjry");
            this.memoEdit5.DataBindings.Add("EditValue", rowData, "zt", false, DataSourceUpdateMode.OnPropertyChanged);
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "jy", false, DataSourceUpdateMode.OnPropertyChanged);
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "jr", false, DataSourceUpdateMode.OnPropertyChanged);
            this.memoEdit4.DataBindings.Add("EditValue", rowData, "py");
            this.comboBoxEdit17.DataBindings.Add("EditValue", rowData, "qz");
            this.comboBoxEdit18.DataBindings.Add("EditValue", rowData, "hydd");


        }
        void setqqry()
        {
            string str = rowData.cjry;
            string[] mans = str.Split(new char[1] { ';' }, 15, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < 15; i++)
            {
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue = "";
                // ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 11)]).EditValue = "";
            }
            for (int i = 0; i < mans.Length; i++)
            {
                //string[] ry = mans[i].Split(':');
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue = mans[i];
                //((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 11)]).EditValue = ry[1];
            }
        }
        void getqqry()
        {
            string str = "";
            string ry = "";
            //string yy = "";
            for (int i = 0; i < 15; i++)
            {
                ry = ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue.ToString();
                //yy = ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 11)]).EditValue.ToString();
                if (!string.IsNullOrEmpty(ry.Trim()))
                    str += ry + ";";
            }
            rowData.cjry = str;
        }
        #region IPopupFormEdit Members
        private sdjl_03yxfx rowData = null;

        public object RowData
        {
            get
            {
                getqqry();
                return rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as sdjl_03yxfx;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sdjl_03yxfx>(value as sdjl_03yxfx, rowData);
                }
                setqqry();
            }
        }

        private DataTable WorkFlowData = null;//实例流程信息

        public DataTable RecordWorkFlowData
        {
            get
            {

                return WorkFlowData;
            }
            set
            {


                WorkFlowData = value;


            }
        }

        //private int recordStatus = -1;//记录流程
        private int recordStatus = 0;//记录流程
        public int RecordStatus
        {
            get
            {

                return recordStatus;
            }
            set
            {


                recordStatus = value;
                //IniControlStatus();

            }
        }
        #endregion
        private void IniControlStatus()
        {
            simpleButton1.Enabled = false;
            switch (recordStatus)
            {
                case 0:
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;
                    memoEdit5.Properties.ReadOnly = false;
                    memoEdit1.Properties.ReadOnly = false;
                    memoEdit2.Properties.ReadOnly = false;
                    simpleButton1.Enabled = true;
                    dateEdit4.Enabled = false;
                    comboBoxEdit17.Enabled = false;
                    groupBox7.Enabled = false;
                    break;
                case 1:

                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    memoEdit5.Properties.ReadOnly = true;
                    memoEdit1.Properties.ReadOnly = true;
                    memoEdit2.Properties.ReadOnly = true;

                    dateEdit4.Enabled = false;
                    comboBoxEdit17.Enabled = false;
                    groupBox7.Enabled = true;
                    break;
                case 2:

                    groupBox1.Enabled = true;
                    groupBox2.Enabled = false;
                    memoEdit5.Properties.ReadOnly = true;
                    memoEdit1.Properties.ReadOnly = true;
                    memoEdit2.Properties.ReadOnly = true;
                    dateEdit3.Enabled = false;
                    comboBoxEdit16.Enabled = false;
                    comboBoxEdit18.Enabled = false;

                    dateEdit4.Enabled = true;
                    comboBoxEdit17.Enabled = true;
                    groupBox7.Enabled = false;
                    break;
                default:
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    memoEdit5.Properties.ReadOnly = true;
                    memoEdit1.Properties.ReadOnly = true;
                    memoEdit2.Properties.ReadOnly = true;

                    dateEdit4.Enabled = false;
                    comboBoxEdit17.Enabled = false;
                    groupBox7.Enabled = false;
                    break;
            }

        }
        private void InitComboBoxData()
        {

            //填充下拉列表数据
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表
            // ICollection yyList = ComboBoxHelper.GetQqyy();//获取缺勤原因列表
            for (int i = 0; i < 16; i++)
            {
                if (ryList.Count > 0)
                {
                    if (i < 15)
                    {
                        ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).Properties.Items.AddRange(ryList);
                    }
                    if (i >= 15)
                    {
                        ((ComboBoxEdit)groupBox1.Controls["comboBoxEdit" + (i + 1)]).Properties.Items.AddRange(ryList);
                    }
                }


            }
            //((ComboBoxEdit)groupBox7.Controls["comboBoxEdit" + 17]).Properties.Items.AddRange(ryList);
            ((ComboBoxEdit)groupBox7.Controls["comboBoxEdit" + 17]).Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("公用属性", "签字人", ((ComboBoxEdit)groupBox7.Controls["comboBoxEdit" + 17]));
            comboBoxEdit18.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("送电运行分析", "运行分析地点", comboBoxEdit18.Properties);
            if (comboBoxEdit18.Properties.Items.Count == 0) {
                comboBoxEdit18.Properties.Items.Add("工区会议室");
            }

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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post)
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

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControlOrg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (recordStatus == 0)
            //{

            sdjl_gzrjnr gzr = new sdjl_gzrjnr();
            sdjl_03yxfx yxfx = RowData as sdjl_03yxfx;
            object obj = MainHelper.PlatformSqlMap.GetOneByKey<sdjl_03yxfx>(yxfx.ID);
            if (obj == null)
            {
                rowData.gznrID = gzr.gznrID;
                gzr.ParentID = yxfx.ID;
                yxfx.CreateDate = DateTime.Now;
                yxfx.CreateMan = MainHelper.User.UserName;
                IList<sdjl_01gzrj> gzrj01 = MainHelper.PlatformSqlMap.GetList<sdjl_01gzrj>("Selectsdjl_01gzrjList", "where rq between '" + rowData.rq.ToString("yyyy-MM-dd 00:00:00") + "' and '" + rowData.rq.ToString("yyyy-MM-dd 23:59:59") + "'");
                if (gzrj01.Count > 0)
                {
                    gzr.gzrjID = gzrj01[0].gzrjID;
                }
                else
                {
                    sdjl_01gzrj pj = new sdjl_01gzrj();
                    pj.gzrjID = pj.CreateID();
                    pj.GdsCode = rowData.OrgCode;
                    pj.GdsName = rowData.OrgName;
                    pj.CreateDate = rowData.rq;
                    pj.CreateMan = MainHelper.User.UserName;
                    gzr.gzrjID = pj.gzrjID;
                    pj.rq = rowData.rq;
                    pj.xq = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
                    pj.rsaqts = (DateTime.Today - MainHelper.UserOrg.PSafeTime.Date).Days;
                    pj.sbaqts = (DateTime.Today - MainHelper.UserOrg.DSafeTime.Date).Days;
                    Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                    MainHelper.PlatformSqlMap.Create<sdjl_01gzrj>(pj);


                }
                IList<sdjl_gzrjnr> gzrlist = MainHelper.PlatformSqlMap.GetList<sdjl_gzrjnr>("Selectsdjl_gzrjnrList", "where ParentID  = '" + gzr.ParentID + "' order by seq  ");
                if (gzrlist.Count > 0)
                {
                    gzr.seq = gzrlist[gzrlist.Count - 1].seq + 1;
                }
                else
                    gzr.seq = 1;
                gzr.gznr = yxfx.hydd + "运行分析-" + yxfx.type;
                gzr.fzr = yxfx.zcr;
                gzr.fssj = yxfx.rq;
                string[] ss = yxfx.cjry.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                if (ss.Length >= 1)
                {

                    gzr.cjry = ss[0] + ss[1];
                    if (ss.Length > 2) gzr.cjry = gzr.cjry + "等";
                    gzr.cjry = gzr.cjry + ss.Length + "人";
                }
                else
                {
                    gzr.cjry = gzr.fzr;
                }
                MainHelper.PlatformSqlMap.Create<sdjl_gzrjnr>(gzr);
                MainHelper.PlatformSqlMap.Create<sdjl_03yxfx>(yxfx);
            }
            else
            {
                yxfx.CreateDate = yxfx.rq;
                MainHelper.PlatformSqlMap.Update<sdjl_03yxfx>(RowData);
            }
            //string strmes = RecordWorkTask.RunNewYXFXRecord(rowData.ID, yxfx.type,MainHelper.User.UserID   );

            //if (strmes.IndexOf("未提交至任何人") > -1)
            //{
            //    MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
            //    return;
            //}
            //else
            //    MsgBox.ShowTipMessageBox(strmes);
            //if (gzrj01.Count > 0)
            //    MainHelper.PlatformSqlMap.Create<sdjl_gzrjnr>(gzr);
            //MainHelper.PlatformSqlMap.Create<sdjl_03yxfx>(yxfx);
            //this.Close();
            //}
            //else
            //{
            //    //try
            //    //{
            //    //    string strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), "提交");
            //    //    if (strmes.IndexOf("未提交至任何人") > -1)
            //    //    {
            //    //        MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
            //    //        return;
            //    //    }
            //    //    else
            //    //        MsgBox.ShowTipMessageBox(strmes);

            //    //}
            //    //catch (System.Exception ex)
            //    //{

            //    //}

            //    MainHelper.PlatformSqlMap.Update<sdjl_03yxfx>(RowData);

            //}

            //this.Close(); 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PJ_dyk dyk = SelectorHelper.SelectDyk("03运行分析记录", "分析记录内容", memoEdit5, memoEdit1, memoEdit2);
            if (dyk != null)
            {
                rowData.zt = dyk.nr;
                rowData.jy = dyk.nr2;
                rowData.jr = dyk.nr3;
            }
           
            //memoEdit1.Focus();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmorgRySelect fr = new frmorgRySelect();
            fr.gdscode = rowData.OrgCode;
            DataTable dt = new DataTable();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                dt = fr.DT1;
                if (MsgBox.ShowAskMessageBox("是否确认快速写入人名") == DialogResult.OK)
                {
                    resetCxry();
                    int count = 15;
                    if (dt.Rows.Count < count)
                        count = dt.Rows.Count;
                    int j = 1;
                    for (int i = 0; i < count; i++)
                    {
                        if ((bool)dt.Rows[i][1] == true)
                        {
                            ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + j]).EditValue = dt.Rows[i][0].ToString();
                            j++;
                        }
                    }
                }
            }
        }

        private void resetCxry()
        {
            for (int i = 1; i <= 15; i++)
            {
                
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + i]).EditValue = string.Empty;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("03运行分析记录", "工作评语", memoEdit4);
        }
    }
}