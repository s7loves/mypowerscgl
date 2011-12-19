using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;
using System.Reflection;
using System.Collections;
using Ebada.Client;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using System.IO;
using Ebada.Core;
using DevExpress.XtraRichEdit.API.Word;
using Ebada.Scgl.WFlow;
using DevExpress.XtraGrid.Views.Base;
using System.Text.RegularExpressions;
using DevExpress.XtraTreeList;
using System.Net;
using System.Threading;
using Ebada.Scgl.Core;

namespace Ebada.Scgl.Lcgl
{
    public partial class frmModleFjly : Form, IPopupFormEdit
    {
        #region 字段

        const int wordWidth = 13;
        private LP_Temple parentTemple = null;
        private IList<LP_Temple> templeList;
        private IList<Control> tempCtrlList = null;
        private LP_Record currRecord = null;
        private string kind, status;
        private string plitchar = "|";
        private char pchar = '|';
        private char pcomboxchar = '，';
        private string strNumber = "";
        private Control ctrlNumber = null;
        private string activeSheetName = "";
        private int activeSheetIndex = 1;
        private DownFileControl filecontrol = null;
        private SPYJControl hqyjcontrol = null;
        private Hashtable valuehs = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private bool isWorkflowCall = false;
        private string varDbTableName = "LP_Record";
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;
            }
        }

        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set { parentTemple = value; }
        }
        public string Kind
        {
            get { return kind; }
            set { kind = value; }
        }

        public string Status//add,edit,etc....
        {
            get { return status; }
            set { status = value; }
        }

        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set { currRecord = value; }
        }
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
            }
        }

        #endregion
        #region IPopupFormEdit Members
        private LP_Record rowData = null;

        public object RowData
        {
            get
            {
                rowData = currRecord;
                return rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as LP_Record;
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<LP_Record>(value as LP_Record, rowData);
                }
            }
        }

        #endregion
        public frmModleFjly()
        {
            InitializeComponent();
        }
        void dataBind()
        {

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


            }
        }
     
    
        private void LPFrm_Load(object sender, EventArgs e)
        {
                InitContorl();
          
        }

        protected override void OnShown(EventArgs e)
        {
            //InitializeComponent();
            base.OnShown(e);

            //InitIndex();

            //if (parentTemple != null)
            //    InitContorl();
            ////currRecord = rowData;
            //if (status == "add" && parentTemple.DocContent != null && parentTemple.DocContent.Length > 0)
            //{              
            //    this.dsoFramerWordControl1.FileDataGzip = parentTemple.DocContent;                
            //}
            //else if (status == "edit" && currRecord.DocContent != null && currRecord.DocContent.Length > 0)
            //{
            //    this.dsoFramerWordControl1.FileDataGzip = currRecord.DocContent;
            //    LoadContent();
            //}

            // this.dsoFramerWordControl1.FileDataGzip = this.rowData.DocContent;
        }
        public void InitIndex()
        {
            if (parentTemple != null) templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", "where LPID in ( select FieldId from WF_TableUsedField where UserControlId ='" + parentTemple.LPID + "' and WorkflowId='" + WorkFlowData.Rows[0]["WorkflowId"] + "'and WorkTaskid='" + WorkFlowData.Rows[0]["WorkTaskid"] + "' ) Order by SortID");
            //else
            //{
            //    LP_Temple temple = new LP_Temple();
            //   templeList =(List<LP_Temple>)temple ;
            //}
            //IList<LP_Temple> parentlist = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", "where ParentID='0' and Kind='" + kind + "'");
            //if (parentlist.Count > 0)
            //    parentTemple = parentlist[0];
            // dsoFramerWordControl1.
        }
        public static string GetWorkFlowNmae(string kind)
        {
            string strkind = kind;
            if (kind == "dzczp")
                strkind = "电力线路倒闸操作票";
            else if (kind == "yzgzp")
                strkind = "电力线路第一种工作票";
            else if (kind == "ezgzp")
                strkind = "电力线路第二种工作票";
            else if (kind == "xlqxp")
                strkind = "电力线路事故应急抢修单";



            return strkind;


        }
        public void InitContorl()
        {
            int MaxWordWidth =0;
            int currentPosY = 10;
            int currentPosX = 10;
            int index = 0;
            if (MaxWordWidth < 300) MaxWordWidth = 300;
       
            if (RecordWorkTask.HaveRunSPYJRole(kind))
            {
                if (hqyjcontrol == null) hqyjcontrol = new SPYJControl();
                hqyjcontrol.Size = new System.Drawing.Size(400, 200);
                hqyjcontrol.Location = new System.Drawing.Point(currentPosX, currentPosY + 10);
                currentPosY = currentPosY + hqyjcontrol.Size.Height;
                hqyjcontrol.RecordID = CurrRecord.ID;
                hqyjcontrol.TabIndex = index;
                index++;
                dockPanel1.Controls.Add(hqyjcontrol);
            }

            if (RecordWorkTask.HaveRunFuJianRole(kind))
            {

                if (filecontrol == null) filecontrol = new DownFileControl();
                if (status == "add")
                    filecontrol.FormType = "上传";
                else if (status == "edit")
                {
                    filecontrol.FormType = "下载";
                }
                filecontrol.Size = new System.Drawing.Size(400, 300);
                filecontrol.Location = new System.Drawing.Point(currentPosX, currentPosY + 10);
                currentPosY = currentPosY + filecontrol.Size.Height;
                filecontrol.UpfilePath = GetWorkFlowNmae(kind);
                if (currRecord == null)
                {
                    currRecord = new LP_Record();
                }
                filecontrol.RecordID = CurrRecord.ID;
                filecontrol.TabIndex = index;
                index++;
                dockPanel1.Controls.Add(filecontrol);
                currentPosY += 20;
            }

            Button btn_Submit = new Button();
            dockPanel1.Controls.Add(btn_Submit);
            btn_Submit.Location = new Point(currentPosX, currentPosY + 10);
            btn_Submit.Text = "关闭";
            btn_Submit.Click += new EventHandler(btn_Hide);
            if (dockPanel1.ControlContainer.Controls.Count > 0)
                dockPanel1.ControlContainer.Controls[0].Focus();
        }

        public void btn_Hide(object sender, EventArgs e)
        {
            this.Close();
        }
       public void btn_Submit_Click(object sender, EventArgs e)
        {
            
            if (filecontrol != null)
            {
                if (filecontrol.Isupfile)
                {
                    MsgBox.ShowTipMessageBox("请稍后，正在上传文件");
                    return;
                }
                if (filecontrol.Isdownfile)
                {
                    if (MsgBox.ShowAskMessageBox("正在下载文件，确认提交?") != DialogResult.OK)
                    {
                        return;
                    }

                }
            }
           
          
            switch (status)
            {
                case "add":
                  
                    if (hqyjcontrol != null)
                    {
                        PJ_lcspyj lcyj = new PJ_lcspyj();
                        lcyj.Charman = MainHelper.User.UserName;
                        lcyj.ID = PJ_lcspyj.Newid();
                        lcyj.RecordID = currRecord.ID;
                        lcyj.taskID = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                        lcyj.Spyj = hqyjcontrol.nowMemoEdit.Text;
                        lcyj.Creattime = DateTime.Now;
                        if (hqyjcontrol.nowMemoEdit.Text != "")
                            MainHelper.PlatformSqlMap.Create<PJ_lcspyj>(lcyj);
                    }
                    if (filecontrol != null)
                    {
                        for (int i = 0; i < filecontrol.FJtable.Rows.Count; i++)
                        {

                            PJ_lcfj lcfu = new PJ_lcfj();
                            lcfu.ID = lcfu.CreateID();
                            lcfu.Filename = Path.GetFileName(filecontrol.FJtable.Rows[i]["FilePath"].ToString());
                            lcfu.FileRelativePath = filecontrol.FJtable.Rows[i]["SaveFileName"].ToString();
                            lcfu.FileSize = Convert.ToInt64(filecontrol.FJtable.Rows[i]["FileSize"]);
                            lcfu.RecordID = currRecord.ID;
                            lcfu.Creattime = DateTime.Now;
                            Thread.Sleep((new TimeSpan(100000)));//0.1毫秒
                            MainHelper.PlatformSqlMap.Create<PJ_lcfj>(lcfu);
                        }

                    }
                    break;
                case "edit":
                    if (hqyjcontrol != null)
                    {
                        PJ_lcspyj lcyj = new PJ_lcspyj();
                        lcyj.Charman = MainHelper.User.UserName;
                        lcyj.ID = PJ_lcspyj.Newid();
                        lcyj.RecordID = currRecord.ID;
                        lcyj.taskID = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                        lcyj.Spyj = hqyjcontrol.nowMemoEdit.Text;
                        lcyj.Creattime = DateTime.Now;
                        if (hqyjcontrol.nowMemoEdit.Text != "")
                            MainHelper.PlatformSqlMap.Create<PJ_lcspyj>(lcyj);

                    }
                    break;
            }
            this.DialogResult = DialogResult.OK;
        }
       
        private void frmLP_FormClosed(object sender, FormClosedEventArgs e)
        {

            try
            {
                //base.Close();
                //rowData = null;
               
                dockPanel1.ControlContainer.Controls.Clear();
                templeList.Clear();
                currRecord = null;
                if (filecontrol != null)
                {

                    if (filecontrol.upThread != null && filecontrol.upThread.ThreadState == ThreadState.Running)
                    {
                        filecontrol.upThread.IsBackground = true;
                        filecontrol.upThread.Abort();
                    }
                    if (filecontrol.Isdownfile)
                    {

                        if (filecontrol.webClient != null) filecontrol.webClient.CancelAsync();

                    }
                }
            }
            catch { }
        }

        private void frmLP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (filecontrol != null)
            {
                if (filecontrol.Isupfile)
                {
                    if (MsgBox.ShowAskMessageBox("正在上传文件，确认退出?") != DialogResult.OK)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                if (filecontrol.Isdownfile)
                {
                    if (MsgBox.ShowAskMessageBox("正在下载文件，确认退出?") != DialogResult.OK)
                    {
                        e.Cancel = true;
                    }

                }
            }
        }
    }
}