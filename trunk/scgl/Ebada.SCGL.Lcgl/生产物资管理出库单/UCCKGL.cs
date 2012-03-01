﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Ebada.Client;
using System.Collections;
using Ebada.Scgl.Model;
using System.Threading;
using Ebada.Core;
using Ebada.Scgl.WFlow;
using Ebada.Client.Platform;

namespace Ebada.Scgl.Lcgl
{
    public partial class UCCLCKGL : UserControl
    {
        public UCCLCKGL()
        {
            InitializeComponent();
        }
        string strSQL = "";

        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "LP_Record";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set { parentTemple = value; }
        }
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;

            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set { currRecord = value; }
        }

        public DataTable RecordWorkFlowData
        {
            get
            {

                return WorkFlowData;
            }
            set
            {


                WorkFlowData = value;

                if (isWorkflowCall)
                {
                    if (RecordWorkTask.HaveRunSPYJRole(currRecord.Kind) || RecordWorkTask.HaveRunFuJianRole(currRecord.Kind))
                    {
                        barFJLY.Visible = true;
                        if (fjly == null) fjly = new frmModleFjly();
                    }
                    //liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                    //liuchenBarClear.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                    IList<WF_WorkTaskCommands> wtlist = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskCommands>("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
                    foreach (WF_WorkTaskCommands wt in wtlist)
                    {
                        //if (wt.CommandName == "01")
                        //{
                        //    //SubmitButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                        //    //if (wt.Description != "") SubmitButton.Caption = wt.Description;
                        //    //barFJLY.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        //}
                        //else
                        //    if (wt.CommandName == "02")
                        //    {
                        TaskOverButton.Visible = true;
                        if (wt.Description != "") TaskOverButton.Text = wt.Description;
                        //}

                    }
                }
            }
        }

        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string ssgc = " and 1=1 ", ssxm = " and 1=1 ", wpgg = " and 1=1 ", wpmc = " and 1=1 ";
            if (comboBoxEdit1.Text  != "")
                ssgc = " and ssgc='" + comboBoxEdit1.Text + "' ";
            if (comboBoxEdit2.Text != "")
                ssxm = " and ssxm='" + comboBoxEdit2.Text + "' ";
            if (comboBoxEdit3.Text != "")
                wpmc = " and wpmc='" + comboBoxEdit3.Text + "' ";
            if (comboBoxEdit4.Text != "")
                wpgg = " and wpgg='" + comboBoxEdit4.Text + "' ";
            strSQL = " where  (type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') "
                + ssgc + ssxm + wpmc + wpgg+" and cast(kcsl as int)>0 order by ssgc,wpmc,wpgg,cast( indate as datetime) ";
            IList<PJ_clcrkd> datalist = ClientHelper.PlatformSqlMap.GetListByWhere<PJ_clcrkd>(strSQL);
           gridControl1.DataSource  = datalist;
           //hideColumn("OrgCode");
           //hideColumn("OrgName");
           //hideColumn("type");
           //hideColumn("yt");
           //hideColumn("cksl");
           //hideColumn("kcsl");
           //hideColumn("lqdw");
           //hideColumn("kcsl");
           //hideColumn("ckdate");
        }
        private void hideColumn(string colname)
        {
            gridView1.Columns[colname].Visible = false;
        }
        private void UCCLCKGL_Load(object sender, EventArgs e)
        {

            comboBoxEdit5.SelectedIndex = 0;
            comboBoxEdit6.SelectedIndex = 0;
            comboBoxEdit1.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct ssgc  from PJ_clcrkd where type = '"+comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存'  and ssgc!='' ");
            comboBoxEdit1.Properties.Items.AddRange(mclist);

            
        }

        private void comboBoxEdit1_TextChanged(object sender, EventArgs e)
        {
            comboBoxEdit2.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct ssxm  from PJ_clcrkd where type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存'  and ssgc!='' ");
            comboBoxEdit2.Properties.Items.AddRange(mclist);

            comboBoxEdit3.Properties.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_clcrkd where  ssgc='" + comboBoxEdit1.Text + "' and ( type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') and wpmc!='' ");
            comboBoxEdit3.Properties.Items.AddRange(mclist);

            comboBoxEdit4.Properties.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg  from PJ_clcrkd where  ssgc='" + comboBoxEdit1.Text + "' and ( type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') and wpgg!='' ");
            comboBoxEdit4.Properties.Items.AddRange(mclist);
        }

        private void comboBoxEdit2_TextChanged(object sender, EventArgs e)
        {


            comboBoxEdit3.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_clcrkd where  ssxm='" + comboBoxEdit2.Text + "' and ( type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') and wpmc!='' ");
            comboBoxEdit3.Properties.Items.AddRange(mclist);

            comboBoxEdit4.Properties.Items.Clear();
             mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg  from PJ_clcrkd where  ssxm='" + comboBoxEdit2.Text + "' and ( type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') and wpgg!='' ");
            comboBoxEdit4.Properties.Items.AddRange(mclist);
        }

        private void comboBoxEdit3_TextChanged(object sender, EventArgs e)
        {


            comboBoxEdit4.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg  from PJ_clcrkd where  wpmc='" + comboBoxEdit3.Text + "' and ( type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') and wpgg!='' ");
            comboBoxEdit4.Properties.Items.AddRange(mclist);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmCLCKXZ frm = new frmCLCKXZ();
            frm.strType = comboBoxEdit5.Text;

            int i = Client.ClientHelper.PlatformSqlMap.GetRowCount
                   <PJ_clcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='"+comboBoxEdit6.Text +"' ");
            frm.strNum = DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", i + 1);
            frm.RowData = new PJ_clcrkd();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string ssgc = " and 1=1 ",  wpgg = " and 1=1 ", wpmc = " and 1=1 ";
                long isum = 0;
                    ssgc = " and ssgc='" + frm.ReturnData.ssgc  + "' ";

                    wpmc = " and wpmc='" + frm.ReturnData.wpmc  + "' ";

                    wpgg = " and wpgg='" + frm.ReturnData.wpgg  + "' ";
                    isum =Convert.ToInt64( frm.ReturnData.cksl);
                  string   strsql = " where  (type = '" + comboBoxEdit5.Text
                    + "' or type = '" + comboBoxEdit5.Text + "原始库存') "
                    + ssgc + wpmc + wpgg + " and cast(kcsl as int)>0 order by cast( indate as datetime) ";
                IList<PJ_clcrkd> datalist = ClientHelper.PlatformSqlMap.GetListByWhere<PJ_clcrkd>
                    (strsql);
                long cktemp = isum;
                long zkc = Convert.ToInt64(frm.ReturnData.zkcsl);
                IList<PJ_clcrkd> ckdatalist = new List<PJ_clcrkd>();
                foreach (PJ_clcrkd pc in datalist)
                {
                    PJ_clcrkd ckd =new PJ_clcrkd() ;
                    ConvertHelper.CopyTo<PJ_clcrkd>(pc, ckd);
                    ckd.ID = ckd.CreateID();
                    i = Client.ClientHelper.PlatformSqlMap.GetRowCount
                    <PJ_clcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "' ");
                    ckd.num = "CK"+DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", i + 1);
                    ckd.type = comboBoxEdit6.Text;
                    ckd.Remark = frm.ReturnData.Remark;
                    ckd.yt = pc.yt;
                    ckd.ssxm = pc.ssxm;
                    ckd.ssxm = frm.ReturnData.lqdw;
                    ckd.ckdate = DateTime.Now;
                    if (cktemp >= Convert.ToInt64(pc.kcsl))
                    {
                        ckd.cksl = pc.kcsl;
                        ckd.zkcsl = (zkc - Convert.ToInt64(pc.kcsl)).ToString();
                        cktemp = cktemp - Convert.ToInt64(pc.kcsl);
                        pc.kcsl = "0";
                        //ClientHelper.PlatformSqlMap.Update<PJ_clcrkd>(pc);
                    }
                    else
                    {
                        ckd.cksl = cktemp.ToString();
                        ckd.zkcsl = (zkc - cktemp).ToString();

                        pc.kcsl = (Convert.ToInt64(pc.kcsl) - cktemp).ToString();
                        cktemp = 0;
                        //ClientHelper.PlatformSqlMap.Update<PJ_clcrkd>(pc);
                    }
                    ckd.lyparent = pc.ID;
                    zkc = Convert.ToInt64(ckd.zkcsl);
                    Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                    
                    //ClientHelper.PlatformSqlMap.Create<PJ_clcrkd>(ckd);

                    ckdatalist.Add(ckd);
                    if (cktemp<1) break;
                }
                frmCLCKXZShow frmshow = new frmCLCKXZShow();
                frmshow.DataList = ckdatalist;
                if (frmshow.ShowDialog() == DialogResult.OK)
                {
                    cktemp = isum;
                    zkc = Convert.ToInt64(frm.ReturnData.zkcsl);
                    foreach (PJ_clcrkd pc in datalist)
                    {
                        PJ_clcrkd ckd = new PJ_clcrkd();
                        ConvertHelper.CopyTo<PJ_clcrkd>(pc, ckd);
                        ckd.ID = ckd.CreateID();
                        i = Client.ClientHelper.PlatformSqlMap.GetRowCount
                        <PJ_clcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "' ");
                        ckd.num = "CK" + DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", i + 1);
                        ckd.type = comboBoxEdit6.Text;
                        ckd.Remark = frm.ReturnData.Remark;
                        ckd.ssxm = frm.ReturnData.lqdw;
                        ckd.yt = pc.yt;
                        ckd.ssxm = pc.ssxm;
                        ckd.ckdate = DateTime.Now;
                        if (cktemp >= Convert.ToInt64(pc.kcsl))
                        {
                            ckd.cksl = pc.kcsl;
                            ckd.zkcsl = (zkc - Convert.ToInt64(pc.kcsl)).ToString();
                            cktemp = cktemp - Convert.ToInt64(pc.kcsl);
                            pc.kcsl = "0";
                            ClientHelper.PlatformSqlMap.Update<PJ_clcrkd>(pc);
                        }
                        else
                        {
                            ckd.cksl = cktemp.ToString();
                            ckd.zkcsl = (zkc - cktemp).ToString();

                            pc.kcsl = (Convert.ToInt64(pc.kcsl) - cktemp).ToString();
                            cktemp = 0;
                            ClientHelper.PlatformSqlMap.Update<PJ_clcrkd>(pc);
                        }
                        ckd.lyparent = pc.ID;
                        zkc = Convert.ToInt64(ckd.zkcsl);
                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒

                        ClientHelper.PlatformSqlMap.Create<PJ_clcrkd>(ckd);

                        
                        if (cktemp < 1) break;
                    }
                    ucclck1.inidata();
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < -1)
                return;
            PJ_clcrkd rowdata = gridView1.GetFocusedRow() as PJ_clcrkd;
            frmCLCKSingleXZ frm = new frmCLCKSingleXZ();
            frm.RowData = new PJ_clcrkd();
            ConvertHelper.CopyTo<PJ_clcrkd>(rowdata, (PJ_clcrkd)frm.RowData);
            ((PJ_clcrkd)frm.RowData).Remark = ""; 
            long i = Client.ClientHelper.PlatformSqlMap.GetRowCount
            <PJ_clcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "' ");
            ((PJ_clcrkd)frm.RowData).num = "CK" + DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", i + 1);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PJ_clcrkd ckd = new PJ_clcrkd();
                ConvertHelper.CopyTo<PJ_clcrkd>(rowdata, ckd);
                ckd.ID = ckd.CreateID();
                long cktemp = Convert.ToInt64(frm.ReturnData.cksl);
                long zkc = Convert.ToInt64(frm.ReturnData.kcsl);
                // i = Client.ClientHelper.PlatformSqlMap.GetRowCount
                //<PJ_clcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "' ");
                ckd.num = frm.ReturnData.num;
                ckd.type = comboBoxEdit6.Text;
                ckd.Remark = frm.ReturnData.Remark;
                ckd.yt = frm.ReturnData.yt;
                ckd.ssxm = frm.ReturnData.ssxm;
                ckd.ckdate = DateTime.Now;
                if (cktemp >= Convert.ToInt64(rowdata.kcsl))
                {
                    ckd.cksl = rowdata.kcsl;
                    ckd.zkcsl = (zkc - Convert.ToInt64(rowdata.kcsl)).ToString();
                    cktemp = cktemp - Convert.ToInt64(rowdata.kcsl);
                    rowdata.kcsl = "0";
                    ClientHelper.PlatformSqlMap.Update<PJ_clcrkd>(rowdata);
                }
                else
                {
                    ckd.cksl = cktemp.ToString();
                    ckd.zkcsl = (zkc - cktemp).ToString();

                    rowdata.kcsl = (Convert.ToInt64(rowdata.kcsl) - cktemp).ToString();
                    cktemp = 0;
                    ClientHelper.PlatformSqlMap.Update<PJ_clcrkd>(rowdata);
                }
                ckd.lyparent = rowdata.ID;
                zkc = Convert.ToInt64(ckd.zkcsl);
                Thread.Sleep(new TimeSpan(100000));//0.1毫秒

                ClientHelper.PlatformSqlMap.Create<PJ_clcrkd>(ckd);
                ucclck1.inidata();
            }
        }

        private void TaskOverButton_Click(object sender, EventArgs e)
        {
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认此节点结束，并进入下一流程?") != DialogResult.OK)
            {
                //SendMessage(this.Handle, 0x0010, (IntPtr)0, (IntPtr)0);
                return;
            }
            string strmes = "";
            WF_WorkTaskCommands wt = (WF_WorkTaskCommands)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
            if (wt != null)
            {
                strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), wt.CommandName);
            }
            else
            {
                strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), "提交");
            }
            if (strmes.IndexOf("未提交至任何人") > -1)
            {
                MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                return;
            }
            else
                MsgBox.ShowTipMessageBox(strmes);
            fjly.btn_Submit_Click(sender, e);
            strmes = RecordWorkTask.GetWorkFlowTaskCaption(WorkFlowData.Rows[0]["WorkTaskInsId"].ToString());
            if (strmes == "结束节点1")
            {
                currRecord.Status = "存档";
            }
            else
            {
                currRecord.Status = strmes;
            }
            currRecord.LastChangeTime = DateTime.Now.ToString();
            MainHelper.PlatformSqlMap.Update("UpdateLP_Record", CurrRecord);

            gridControl1.FindForm().Close();
        }

        private void barFJLY_Click(object sender, EventArgs e)
        {
            if (fjly == null) fjly = new frmModleFjly();
            fjly.CurrRecord = currRecord;
            fjly.RecordWorkFlowData = WorkFlowData;
            fjly.Kind = currRecord.Kind;
            fjly.Status = RecordWorkTask.GetWorkTaskStatus(WorkFlowData, currRecord);
            fjly.ShowDialog();
        }
    }
}
