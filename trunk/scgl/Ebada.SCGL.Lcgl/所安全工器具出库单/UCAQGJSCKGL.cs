using System;
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
    public partial class UCAQGJSCKGL : UserControl
    {
        public UCAQGJSCKGL()
        {
            InitializeComponent();
        }
        string strSQL = "";

        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "LP_Record,PJ_anqgjcrkd";
        PJ_anqgjcrkd clccktemp = null;
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
                ucclck1.ParentTemple = value;
            }
        }
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;
                ucclck1.IsWorkflowCall = value;

            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
                ucclck1.CurrRecord = value;
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
                    ucclck1.RecordWorkFlowData = value;
                }
            }
        }

        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
                ucclck1.VarDbTableName = value;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string  wpgg = " and 1=1 ", wpmc = " and 1=1 ";
            
            if (comboBoxEdit3.Text != "")
                wpmc = " and wpmc='" + comboBoxEdit3.Text + "' ";
            if (comboBoxEdit4.Text != "")
                wpgg = " and wpgg='" + comboBoxEdit4.Text + "' ";
            strSQL = " where  (type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') "
                + wpmc + wpgg+" and cast(kcsl as float)>0 order by wpmc,wpgg,cast( indate as datetime) ";
            IList<PJ_anqgjcrkd> datalist = ClientHelper.PlatformSqlMap.GetListByWhere<PJ_anqgjcrkd>(strSQL);
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
            comboBoxEdit3.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_anqgjcrkd where    ( type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') and wpmc!='' ");
            comboBoxEdit3.Properties.Items.AddRange(mclist);
            comboBoxEdit1.Properties.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select OrgName   from mOrg where OrgType = '1' or OrgType = '2'");
            comboBoxEdit1.Properties.Items.AddRange(mclist);
            comboBoxEdit1.SelectedIndex = 0;

            
        }

        private void comboBoxEdit1_TextChanged(object sender, EventArgs e)
        {
            

            comboBoxEdit3.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_anqgjcrkd where    ( type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') and wpmc!='' ");
            comboBoxEdit3.Properties.Items.AddRange(mclist);

            comboBoxEdit4.Properties.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg  from PJ_anqgjcrkd where  ( type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') and wpgg!='' ");
            comboBoxEdit4.Properties.Items.AddRange(mclist);
        }

        private void comboBoxEdit2_TextChanged(object sender, EventArgs e)
        {


            comboBoxEdit3.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_anqgjcrkd where   ( type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') and wpmc!='' ");
            comboBoxEdit3.Properties.Items.AddRange(mclist);

            comboBoxEdit4.Properties.Items.Clear();
             mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg  from PJ_anqgjcrkd where   ( type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') and wpgg!='' ");
            comboBoxEdit4.Properties.Items.AddRange(mclist);
        }

        private void comboBoxEdit3_TextChanged(object sender, EventArgs e)
        {


            comboBoxEdit4.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg  from PJ_anqgjcrkd where  wpmc='" + comboBoxEdit3.Text + "' and ( type = '" + comboBoxEdit5.Text
                + "' or type = '" + comboBoxEdit5.Text + "原始库存') and wpgg!='' ");
            comboBoxEdit4.Properties.Items.AddRange(mclist);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmAQGJSCKXZ frm = new frmAQGJSCKXZ();
            frm.strType = comboBoxEdit5.Text;
            if (clccktemp == null) clccktemp = new PJ_anqgjcrkd();

            //int i = Client.ClientHelper.PlatformSqlMap.GetRowCount
            //       <PJ_anqgjcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "' order by id desc  ");
            //frm.strNum = DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", i + 1);
            
            IList<PJ_anqgjcrkd> pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
                       <PJ_anqgjcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "'  order by id desc  ");
            if (clccktemp.num == "")
            {
                if (pnumli.Count == 0)
                    clccktemp.num = "SAQGJCK" + DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", 1);
                else
                {
                    clccktemp.num = "SAQGJCK" + (Convert.ToDecimal(pnumli[0].num.Replace("SAQGJCK", "")) + 1);

                }
            }
            else
            {
                if (pnumli.Count > 0)
                {

                    if ((Convert.ToDecimal(clccktemp.num.Replace("SAQGJCK", ""))) - (Convert.ToDecimal(pnumli[0].num.Replace("SAQGJCK", ""))) > 1)
                    {
                        clccktemp.num = "SAQGJCK" + (Convert.ToDecimal(pnumli[0].num.Replace("SAQGJCK", "") + 1));
                    }
                }
            }
            frm.strNum = clccktemp.num;
            //frm.RowData = new PJ_anqgjcrkd();
            frm.RowData = clccktemp;
            ((PJ_anqgjcrkd)frm.RowData).ckdate = DateTime.Now;
            ((PJ_anqgjcrkd)frm.RowData).OrgName = comboBoxEdit1.Text;
            mOrg org = ClientHelper.PlatformSqlMap.GetOne<mOrg>(" where orgname = '" + comboBoxEdit1.Text + "' ");
            if (org != null)
            {
                ((PJ_anqgjcrkd)frm.RowData).OrgCode = org.OrgCode;
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string ssgc = " and 1=1 ",  wpgg = " and 1=1 ", wpmc = " and 1=1 ";
                double isum = 0;

                    wpmc = " and wpmc='" + frm.ReturnData.wpmc  + "' ";

                    wpgg = " and wpgg='" + frm.ReturnData.wpgg  + "' ";
                    isum =Convert.ToDouble( frm.ReturnData.cksl);
                  string   strsql = " where  (type = '" + comboBoxEdit5.Text
                    + "' or type = '" + comboBoxEdit5.Text + "原始库存') "
                    + ssgc + wpmc + wpgg + " and cast(kcsl as float)>0 order by cast( indate as datetime) ";
                IList<PJ_anqgjcrkd> datalist = ClientHelper.PlatformSqlMap.GetListByWhere<PJ_anqgjcrkd>
                    (strsql);
                double cktemp = isum;
                double zkc = Convert.ToDouble(frm.ReturnData.zkcsl);
                double szkc = 0;
                IList<PJ_anqgjcrkd> ckdatalist = new List<PJ_anqgjcrkd>();
                decimal num = 0;
                 pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
                               <PJ_anqgjcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "'  order by id desc  ");
                    if (pnumli.Count == 0)
                        num = Convert.ToDecimal(DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", 0));
                    else
                    {
                        num =  (Convert.ToDecimal(pnumli[0].num.Replace("SAQGJCK", "")));

                    }

                   
                foreach (PJ_anqgjcrkd pc in datalist)
                {
                    PJ_anqgjcrkd ckd =new PJ_anqgjcrkd() ;
                    ConvertHelper.CopyTo<PJ_anqgjcrkd>(pc, ckd);
                    ckd.ID = ckd.CreateID();
                    //int i = Client.ClientHelper.PlatformSqlMap.GetRowCount
                    //       <PJ_anqgjcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "' order by id desc  ");
                    //frm.strNum = DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", i + 1);

                    //ckd.num = "SAQGJCK" + (num + 1);
                    ckd.num = clccktemp.num;
                    ckd.type = comboBoxEdit6.Text;
                    ckd.Remark = frm.ReturnData.Remark;
                    ckd.OrgName = frm.ReturnData.OrgName;
                    ckd.OrgCode = frm.ReturnData.OrgCode;
                    ckd.ckdate = DateTime.Now;
                    ckd.lqdw = frm.ReturnData.lqdw;
                    if (cktemp >= Convert.ToDouble(pc.kcsl))
                    {
                        ckd.cksl = pc.kcsl;
                        ckd.zkcsl = (zkc - Convert.ToDouble(pc.kcsl)).ToString();
                        cktemp = cktemp - Convert.ToDouble(pc.kcsl);
                        pc.kcsl = "0";
                        //ClientHelper.PlatformSqlMap.Update<PJ_anqgjcrkd>(pc);
                    }
                    else
                    {
                        ckd.cksl = cktemp.ToString();
                        ckd.zkcsl = (zkc - cktemp).ToString();

                        pc.kcsl = (Convert.ToDouble(pc.kcsl) - cktemp).ToString();
                        cktemp = 0;
                        //ClientHelper.PlatformSqlMap.Update<PJ_anqgjcrkd>(pc);
                    }
                    ckd.lyparent = pc.ID;
                    zkc = Convert.ToDouble(ckd.zkcsl);
                    Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                    
                    //ClientHelper.PlatformSqlMap.Create<PJ_anqgjcrkd>(ckd);

                    ckdatalist.Add(ckd);
                    if (cktemp<1) break;
                    //num=(num + 1);
                }
                frmAQGJSCKXZShow frmshow = new frmAQGJSCKXZShow();
                frmshow.DataList = ckdatalist;
                if (frmshow.ShowDialog() == DialogResult.OK)
                {
                    cktemp = isum;
                    zkc = Convert.ToDouble(frm.ReturnData.zkcsl);
                    pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
                       <PJ_anqgjcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "' ");
                    if (pnumli.Count == 0)
                        num = Convert.ToDecimal(DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", 0));
                    else
                    {
                        num =  (Convert.ToDecimal(pnumli[0].num.Replace("SAQGJCK", "")) );

                    }
                    
                    datalist = ClientHelper.PlatformSqlMap.GetListByWhere<PJ_anqgjcrkd>
                     (strsql);
                    foreach (PJ_anqgjcrkd pc in datalist)
                    {
                        PJ_anqgjcrkd ckd = new PJ_anqgjcrkd();

                        ConvertHelper.CopyTo<PJ_anqgjcrkd>(pc, ckd);
                        ckd.ID = ckd.CreateID();
                        //ckd.num = "SAQGJCK" + (num + 1);
                        ckd.num = clccktemp.num;
                        ckd.type = comboBoxEdit6.Text;
                        ckd.Remark = frm.ReturnData.Remark;
                        ckd.OrgName = frm.ReturnData.OrgName;
                        ckd.OrgCode = frm.ReturnData.OrgCode;
                        ckd.lqdw = frm.ReturnData.lqdw;
                        ckd.ckdate = DateTime.Now;
                        ckd.lasttime = DateTime.Now;
                        if (cktemp >= Convert.ToDouble(pc.kcsl))
                        {
                            ckd.cksl = pc.kcsl;
                            ckd.zkcsl = (zkc - Convert.ToDouble(pc.kcsl)).ToString();
                            cktemp = cktemp - Convert.ToDouble(pc.kcsl);
                            pc.kcsl = "0";
                            ClientHelper.PlatformSqlMap.Update<PJ_anqgjcrkd>(pc);
                        }
                        else
                        {
                            ckd.cksl = cktemp.ToString();
                            ckd.zkcsl = (zkc - cktemp).ToString();

                            pc.kcsl = (Convert.ToDouble(pc.kcsl) - cktemp).ToString();
                            cktemp = 0;
                            ClientHelper.PlatformSqlMap.Update<PJ_anqgjcrkd>(pc);
                        }
                        ckd.lyparent = pc.ID;
                        zkc = Convert.ToDouble(ckd.zkcsl);
                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒

                        if (isWorkflowCall)
                        {

                            MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>(" where ModleRecordID='" + ckd.ID + "' and RecordID='" + currRecord.ID + "'"
                                + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                                + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                                + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                                + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'");
                        }
                        ClientHelper.PlatformSqlMap.Create<PJ_anqgjcrkd>(ckd);

                        if (isWorkflowCall)
                        {
                            WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                            mrwt.ModleRecordID = ckd.ID;
                            mrwt.RecordID = currRecord.ID;
                            mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                            mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                            mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                            mrwt.ModleTableName = ckd.GetType().ToString();
                            mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                            mrwt.CreatTime = DateTime.Now;
                            MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                        }


                        if (cktemp < 1) break;
                        //num = (num + 1);

                    }
                    ucclck1.inidata();
                    simpleButton1_Click(sender, e);
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < -1)
                return;
            PJ_anqgjcrkd rowdata = gridView1.GetFocusedRow() as PJ_anqgjcrkd;
            rowdata = ClientHelper.PlatformSqlMap.GetOneByKey<PJ_anqgjcrkd>(rowdata.ID);
            frmAQGJSCKSingleXZ frm = new frmAQGJSCKSingleXZ();
            frm.RowData = new PJ_anqgjcrkd();
            ConvertHelper.CopyTo<PJ_anqgjcrkd>(rowdata, (PJ_anqgjcrkd)frm.RowData);
            ((PJ_anqgjcrkd)frm.RowData).Remark = "";

            IList<PJ_anqgjcrkd> pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
            <PJ_anqgjcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "' order by id desc ");
            if (pnumli.Count == 0)
                ((PJ_anqgjcrkd)frm.RowData).num = "SAQGJCK" + DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", 1);
            else
            {
                ((PJ_anqgjcrkd)frm.RowData).num = "SAQGJCK" + (Convert.ToDecimal(pnumli[0].num.Replace("SAQGJCK", "")) + 1);

            }
            ((PJ_anqgjcrkd)frm.RowData).ckdate = DateTime.Now;
            double i = 0;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PJ_anqgjcrkd ckd = new PJ_anqgjcrkd();
                ConvertHelper.CopyTo<PJ_anqgjcrkd>(rowdata, ckd);
                ckd.ID = ckd.CreateID();
               
                System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneInt",
                    "select  sum(cast(kcsl as float) )  from PJ_anqgjcrkd where (type = '所安全工器具入库单' or type = '所安全工器具入库单原始库存' and orgname='" + ckd.OrgName + "')"
                    + " and wpmc='" + rowdata.wpmc + "' "
                    + " and wpgg='" + rowdata.wpgg + "' ");
                if (mclist[0] != null) i = Convert.ToDouble(mclist[0].ToString());
                double cktemp = Convert.ToDouble(frm.ReturnData.cksl);
                double zkc = Convert.ToDouble(i);
                // i = Client.ClientHelper.PlatformSqlMap.GetRowCount
                //<PJ_anqgjcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + comboBoxEdit6.Text + "' ");
                ckd.num = frm.ReturnData.num;
                ckd.type = comboBoxEdit6.Text;
                ckd.Remark = frm.ReturnData.Remark;
                ckd.OrgName = frm.ReturnData.OrgName;
                ckd.OrgCode = frm.ReturnData.OrgCode;
                ckd.lqdw = frm.ReturnData.lqdw;
                ckd.ckdate = DateTime.Now;
                ckd.lasttime = DateTime.Now;
                if (cktemp >= Convert.ToDouble(rowdata.kcsl))
                {
                    ckd.cksl = rowdata.kcsl;
                    ckd.zkcsl = (zkc - Convert.ToDouble(rowdata.kcsl)).ToString();
                    cktemp = cktemp - Convert.ToDouble(rowdata.kcsl);
                    ckd.kcsl = "0";
                    rowdata.kcsl = "0";
                    ClientHelper.PlatformSqlMap.Update<PJ_anqgjcrkd>(rowdata);
                }
                else
                {
                    ckd.cksl = cktemp.ToString();
                    ckd.zkcsl = (zkc - cktemp).ToString();
                    rowdata.kcsl = (Convert.ToDouble(rowdata.kcsl) - cktemp).ToString();
                    ckd.kcsl = rowdata.kcsl;
                    cktemp = 0;
                    ClientHelper.PlatformSqlMap.Update<PJ_anqgjcrkd>(rowdata);
                }
                ckd.lyparent = rowdata.ID;
                zkc = Convert.ToDouble(ckd.zkcsl);
                Thread.Sleep(new TimeSpan(100000));//0.1毫秒

                if (isWorkflowCall)
                {

                    MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>(" where ModleRecordID='" + ckd.ID + "' and RecordID='" + currRecord.ID + "'"
                        + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                        + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                        + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                        + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'");
                }
                ClientHelper.PlatformSqlMap.Create<PJ_anqgjcrkd>(ckd);

                if (isWorkflowCall)
                {
                    WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                    mrwt.ModleRecordID = ckd.ID;
                    mrwt.RecordID = currRecord.ID;
                    mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                    mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                    mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                    mrwt.ModleTableName = ckd.GetType().ToString();
                    mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                    mrwt.CreatTime = DateTime.Now;
                    MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                }

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
            if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
            if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
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
