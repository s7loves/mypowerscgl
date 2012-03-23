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
    public partial class UCWGGCCLDGL : UserControl
    {
        public UCWGGCCLDGL()
        {
            InitializeComponent();
        }
        string strSQL = "";

        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "LP_Record,PJ_wgclcrkd";
        PJ_wgclcrkd clccktemp = null;
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
                ucgccld1.ParentTemple = value;
            }
        }
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;
                ucgccld1.IsWorkflowCall = value;
            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
                ucgccld1.CurrRecord = value;
            }
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
                    ucgccld1.RecordWorkFlowData = value;
                }
            }
        }

        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
                ucgccld1.VarDbTableName = value;
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
            IList<PJ_wgclcrkd> datalist = ClientHelper.PlatformSqlMap.GetListByWhere<PJ_wgclcrkd>(strSQL);
           gridControl1.DataSource  = datalist;
           //hideColumn("OrgCode");
           //hideColumn("OrgName");
           //hideColumn("type");
           //hideColumn("yt");
           //hideColumn("CLDCKsl");
           //hideColumn("kcsl");
           //hideColumn("lqdw");
           //hideColumn("kcsl");
           //hideColumn("CLDCKdate");
        }
        private void hideColumn(string colname)
        {
            gridView1.Columns[colname].Visible = false;
        }
        private void UCCLCLDCKGL_Load(object sender, EventArgs e)
        {

            comboBoxEdit5.SelectedIndex = 0;
            comboBoxEdit6.SelectedIndex = 1;
            comboBoxEdit1.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct ssgc  from PJ_wgclcrkd where type = '"+comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存'  and ssgc!='' ");
            comboBoxEdit1.Properties.Items.AddRange(mclist);

            
        }

        private void comboBoxEdit1_TextChanged(object sender, EventArgs e)
        {
            comboBoxEdit2.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct ssxm  from PJ_wgclcrkd where type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存'  and ssgc!='' ");
            comboBoxEdit2.Properties.Items.AddRange(mclist);

            comboBoxEdit3.Properties.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_wgclcrkd where  ssgc='" + comboBoxEdit1.Text + "' and ( type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') and wpmc!='' ");
            comboBoxEdit3.Properties.Items.AddRange(mclist);

            comboBoxEdit4.Properties.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg  from PJ_wgclcrkd where  ssgc='" + comboBoxEdit1.Text + "' and ( type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') and wpgg!='' ");
            comboBoxEdit4.Properties.Items.AddRange(mclist);
        }

        private void comboBoxEdit2_TextChanged(object sender, EventArgs e)
        {


            comboBoxEdit3.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_wgclcrkd where  ssxm='" + comboBoxEdit2.Text + "' and ( type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') and wpmc!='' ");
            comboBoxEdit3.Properties.Items.AddRange(mclist);

            comboBoxEdit4.Properties.Items.Clear();
             mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg  from PJ_wgclcrkd where  ssxm='" + comboBoxEdit2.Text + "' and ( type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') and wpgg!='' ");
            comboBoxEdit4.Properties.Items.AddRange(mclist);
        }

        private void comboBoxEdit3_TextChanged(object sender, EventArgs e)
        {


            comboBoxEdit4.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg  from PJ_wgclcrkd where  wpmc='" + comboBoxEdit3.Text + "' and ( type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') and wpgg!='' ");
            comboBoxEdit4.Properties.Items.AddRange(mclist);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmWGGCCLDXZ frm = new frmWGGCCLDXZ();
            frm.strType = comboBoxEdit5.Text;
            if (clccktemp == null) clccktemp = new PJ_wgclcrkd();
            clccktemp.cksl = "0";
            clccktemp.yt = "工程";
            //int i = Client.ClientHelper.PlatformSqlMap.GetRowCount
            //       <PJ_wgclcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "' order by id desc  ");
            //frm.strNum = DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", i + 1);
            
            IList<PJ_wgclcrkd> pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
                       <PJ_wgclcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "'  order by id desc  ");
            if (clccktemp.num == "")
            {
                if (pnumli.Count == 0)
                    clccktemp.num = "SCCLDCK" + DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", 1);
                else
                {
                    clccktemp.num = "SCCLDCK" + (Convert.ToDecimal(pnumli[0].num.Replace("SCCLDCK", "")) + 1);

                }
            }
            else
            {
                if (pnumli.Count > 0)
                {

                    if ((Convert.ToDecimal(clccktemp.num.Replace("SCCLDCK", ""))) - (Convert.ToDecimal(pnumli[0].num.Replace("SCCLDCK", ""))) > 1)
                    {
                        clccktemp.num = "SCCLDCK" + (Convert.ToDecimal(pnumli[0].num.Replace("SCCLDCK", "") + 1));
                    }
                }
            }
            frm.strNum = clccktemp.num;
            //frm.RowData = new PJ_wgclcrkd();
            frm.RowData = clccktemp;
            ((PJ_wgclcrkd)frm.RowData).ckdate = DateTime.Now;
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
                IList<PJ_wgclcrkd> datalist = ClientHelper.PlatformSqlMap.GetListByWhere<PJ_wgclcrkd>
                    (strsql);
                long cktemp = isum;
                long zkc = Convert.ToInt64(frm.ReturnData.zkcsl);
                IList<PJ_wgclcrkd> ckdatalist = new List<PJ_wgclcrkd>();
                decimal num = 0;
                 pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
                               <PJ_wgclcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "'  order by id desc  ");
                    if (pnumli.Count == 0)
                        num = Convert.ToDecimal(DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", 0));
                    else
                    {
                        num =  (Convert.ToDecimal(pnumli[0].num.Replace("SCCLDCK", "")));

                    }
                
                foreach (PJ_wgclcrkd pc in datalist)
                {
                    PJ_wgclcrkd ckd = new PJ_wgclcrkd();
                    ConvertHelper.CopyTo<PJ_wgclcrkd>(pc, ckd);
                    ckd.ID = ckd.CreateID();
                    //int i = Client.ClientHelper.PlatformSqlMap.GetRowCount
                    //       <PJ_wgclcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "' order by id desc  ");
                    //frm.strNum = DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", i + 1);

                    //ckd.num = "SCCLDCK" + (num + 1);
                    ckd.num = clccktemp.num;
                    ckd.type = comboBoxEdit6.Text;
                    ckd.Remark = frm.ReturnData.Remark;
                    ckd.yt = frm.ReturnData.yt;
                    ckd.ssxm = pc.ssxm;
                    ckd.lqdw = frm.ReturnData.lqdw;
                    ckd.ghdw= frm.ReturnData.ghdw;
                    ckd.ckdate = frm.ReturnData.ckdate;
                    if (cktemp >= Convert.ToInt64(pc.kcsl))
                    {
                        ckd.cksl = pc.kcsl;
                        ckd.zkcsl = (zkc - Convert.ToInt64(pc.kcsl)).ToString();
                        cktemp = cktemp - Convert.ToInt64(pc.kcsl);
                        pc.kcsl = "0";
                        //ClientHelper.PlatformSqlMap.Update<PJ_wgclcrkd>(pc);
                    }
                    else
                    {
                        ckd.cksl = cktemp.ToString();
                        ckd.zkcsl = (zkc - cktemp).ToString();

                        pc.kcsl = (Convert.ToInt64(pc.kcsl) - cktemp).ToString();
                        cktemp = 0;
                        //ClientHelper.PlatformSqlMap.Update<PJ_wgclcrkd>(pc);
                    }
                    ckd.lyparent = pc.ID;
                    zkc = Convert.ToInt64(ckd.zkcsl);
                    Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                    
                    //ClientHelper.PlatformSqlMap.Create<PJ_wgclcrkd>(CLDCKd);

                    ckdatalist.Add(ckd);
                    if (cktemp<1) break;
                    //num=(num + 1);
                }
                frmWGGCCLDShow frmshow = new frmWGGCCLDShow();
                frmshow.DataList = ckdatalist;
                if (frmshow.ShowDialog() == DialogResult.OK)
                {
                    cktemp = isum;
                    zkc = Convert.ToInt64(frm.ReturnData.zkcsl);
                    pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
                       <PJ_wgclcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "' ");
                    if (pnumli.Count == 0)
                        num = Convert.ToDecimal(DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", 0));
                    else
                    {
                        num =  (Convert.ToDecimal(pnumli[0].num.Replace("SCCLDCK", "")));

                    } 
                    datalist = ClientHelper.PlatformSqlMap.GetListByWhere<PJ_wgclcrkd>
                     (strsql);
                    foreach (PJ_wgclcrkd pc in datalist)
                    {
                        PJ_wgclcrkd ckd = new PJ_wgclcrkd();
                        ConvertHelper.CopyTo<PJ_wgclcrkd>(pc, ckd);
                        ckd.ID = ckd.CreateID();
                        //ckd.num = "SCCLDCK" + (num + 1);
                        ckd.num = clccktemp.num;
                        ckd.type = comboBoxEdit6.Text;
                        ckd.Remark = frm.ReturnData.Remark;
                        ckd.lqdw = frm.ReturnData.lqdw;
                        ckd.ghdw = frm.ReturnData.ghdw;
                        ckd.yt = frm.ReturnData.yt;
                        ckd.ssxm = frm.ReturnData.ssxm;
                        ckd.ckdate = frm.ReturnData.ckdate;
                        if (cktemp >= Convert.ToInt64(pc.kcsl))
                        {
                            ckd.cksl = pc.kcsl;
                            ckd.zkcsl = (zkc - Convert.ToInt64(pc.kcsl)).ToString();
                            cktemp = cktemp - Convert.ToInt64(pc.kcsl);
                            pc.kcsl = "0";
                            ClientHelper.PlatformSqlMap.Update<PJ_wgclcrkd>(pc);
                        }
                        else
                        {
                            ckd.cksl = cktemp.ToString();
                            ckd.zkcsl = (zkc - cktemp).ToString();

                            pc.kcsl = (Convert.ToInt64(pc.kcsl) - cktemp).ToString();
                            cktemp = 0;
                            ClientHelper.PlatformSqlMap.Update<PJ_wgclcrkd>(pc);
                        }
                        ckd.lyparent = pc.ID;
                        zkc = Convert.ToInt64(ckd.zkcsl);
                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                        if (isWorkflowCall)
                        {

                            MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>(" where ModleRecordID='" + ckd.ID + "' and RecordID='" + currRecord.ID + "'"
                                + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                                + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                                + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                                + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'");
                        }
                        ClientHelper.PlatformSqlMap.Create<PJ_wgclcrkd>(ckd);


                        if (cktemp < 1) break;
                        //num = (num + 1);

                    }
                    ucgccld1.inidata();
                    simpleButton1_Click(sender, e);
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < -1)
                return;
            PJ_wgclcrkd rowdata = gridView1.GetFocusedRow() as PJ_wgclcrkd;
            rowdata = ClientHelper.PlatformSqlMap.GetOneByKey<PJ_wgclcrkd>(rowdata.ID);
            frmWGGCCLDSingleXZ frm = new frmWGGCCLDSingleXZ();
            frm.RowData = new PJ_wgclcrkd();
            ConvertHelper.CopyTo<PJ_wgclcrkd>(rowdata, (PJ_wgclcrkd)frm.RowData);
            ((PJ_wgclcrkd)frm.RowData).Remark = "";
            ((PJ_wgclcrkd)frm.RowData).yt = "工程";

            IList<PJ_wgclcrkd> pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
            <PJ_wgclcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "' order by id desc ");
            if (pnumli.Count == 0)
                ((PJ_wgclcrkd)frm.RowData).num = "SCCLDCK" + DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", 1);
            else
            {
                ((PJ_wgclcrkd)frm.RowData).num = "SCCLDCK" + (Convert.ToDecimal(pnumli[0].num.Replace("SCCLDCK","")) + 1);

            }
            ((PJ_wgclcrkd)frm.RowData).ckdate = DateTime.Now;
            long i = 0;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PJ_wgclcrkd ckd = new PJ_wgclcrkd();
                ConvertHelper.CopyTo<PJ_wgclcrkd>(rowdata, ckd);
                ckd.ID = ckd.CreateID();
               
                System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneInt",
                    "select  sum(cast(kcsl as int) )  from PJ_wgclcrkd where (type = '工程材料入库单' or type = '工程材料入库单原始库存')"
                    + " and wpmc='" + rowdata.wpmc + "' " + " and ssgc='" + rowdata.ssgc + "' "
                    + " and wpgg='" + rowdata.wpgg + "' ");
                if (mclist[0] != null) i = Convert.ToInt64(mclist[0].ToString());
                long cktemp = Convert.ToInt64(frm.ReturnData.cksl);
                long zkc = Convert.ToInt64(i);
                // i = Client.ClientHelper.PlatformSqlMap.GetRowCount
                //<PJ_wgclcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "' ");
                ckd.num = frm.ReturnData.num;
                ckd.type = comboBoxEdit6.Text;
                ckd.Remark = frm.ReturnData.Remark;
                ckd.yt = frm.ReturnData.yt;
                ckd.ssxm = frm.ReturnData.ssxm;
                ckd.lqdw = frm.ReturnData.lqdw;
                ckd.ghdw = frm.ReturnData.ghdw;
                ckd.ckdate = frm.ReturnData.ckdate;
                if (cktemp >= Convert.ToInt64(rowdata.kcsl))
                {
                    ckd.cksl = rowdata.kcsl;
                    ckd.zkcsl = (zkc - Convert.ToInt64(rowdata.kcsl)).ToString();
                    cktemp = cktemp - Convert.ToInt64(rowdata.kcsl);
                    ckd.kcsl = "0";
                    rowdata.kcsl = "0";
                    ClientHelper.PlatformSqlMap.Update<PJ_wgclcrkd>(rowdata);
                }
                else
                {
                    ckd.cksl = cktemp.ToString();
                    ckd.zkcsl = (zkc - cktemp).ToString();
                    rowdata.kcsl = (Convert.ToInt64(rowdata.kcsl) - cktemp).ToString();
                    ckd.kcsl = rowdata.kcsl;
                    cktemp = 0;
                    ClientHelper.PlatformSqlMap.Update<PJ_wgclcrkd>(rowdata);
                }
                ckd.lyparent = rowdata.ID;
                zkc = Convert.ToInt64(ckd.zkcsl);
                Thread.Sleep(new TimeSpan(100000));//0.1毫秒

                if (isWorkflowCall)
                {

                    MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>(" where ModleRecordID='" + ckd.ID + "' and RecordID='" + currRecord.ID + "'"
                        + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                        + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                        + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                        + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'");
                }
                ClientHelper.PlatformSqlMap.Create<PJ_wgclcrkd>(ckd);
                ucgccld1.inidata();
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

            if (RecordWorkTask.CheckOnRiZhi(WorkFlowData))
            {

                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { currRecord });

            }
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
