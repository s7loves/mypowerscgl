﻿using System;
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
using System.Text.RegularExpressions;

namespace Ebada.Scgl.Lcgl
{
    public partial class LPFrm : Form
    {
        #region 字段

        const int wordWidth = 13;
        private LP_Temple parentTemple = null;
        private IList<LP_Temple> templeList;
        private LP_Record currRecord = null;
        private string kind,status;
        private string plitchar = "|";
        private char pchar = '|';

        public string Kind
        {
            set { kind = value; }
        }

        public string Status//add,edit,etc....
        {
            set { status = value; }
        }

        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set { currRecord = value; }
        }

        #endregion
        public LPFrm()
        {
            InitializeComponent();
        }

        private void LPFrm_Load(object sender, EventArgs e)
        {
            InitIndex();
            if (parentTemple != null)
                InitContorl();
            if (status == "add" && parentTemple.DocContent != null && parentTemple.DocContent.Length > 0)
                this.dsoFramerWordControl1.FileDataGzip = parentTemple.DocContent;
            else if (status == "edit" && currRecord.DocContent != null && currRecord.DocContent.Length > 0)
            {
                this.dsoFramerWordControl1.FileDataGzip = currRecord.DocContent;
                LoadContent();
            }
        }

        
        public void InitIndex()
        {
            templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", "where ParentID!='0' and Kind='" + kind + "' Order by SortID");
            IList<LP_Temple> parentlist = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", "where ParentID='0' and Kind='" + kind + "'");
            if (parentlist.Count > 0)
                parentTemple = parentlist[0];
           // dsoFramerWordControl1.
        }

        public void InitContorl()
        {
            int MaxWordWidth = CalcWidth();
            int currentPosY = 10;
            int currentPosX = 10;
            int index = 0;
            foreach (LP_Temple lp in templeList)
            {
                Label label = new Label();
                label.Text = lp.CellName;
                //string[] location = lp.CtrlLocation.Split(',');
                string[] size = lp.CtrlSize.Split(',');
                label.Location = new Point(currentPosX, currentPosY);
                label.Size = new Size(MaxWordWidth, 14);
                currentPosY += 20;
                Control ctrl ;
                if (lp.CtrlType.Contains("uc_gridcontrol"))
                    ctrl = new uc_gridcontrol();
                else
                    ctrl = (Control)Activator.CreateInstance(Type.GetType(lp.CtrlType));
                ctrl.Location = new Point(currentPosX, currentPosY);
                ctrl.Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                currentPosY += int.Parse(size[1]) + 10; 
                ctrl.Leave += new EventHandler(ctrl_Leave);
                ctrl.Tag = lp;
                ctrl.TabIndex = index;
                if (lp.CtrlType.Contains("uc_gridcontrol"))
                {
                    (ctrl as uc_gridcontrol).InitCol(lp.ColumnName.Split(pchar),lp);
                }
                index++;
                ctrl.Name = lp.LPID;
                dockPanel1.Controls.Add(label);
                dockPanel1.Controls.Add(ctrl);
            }
            InitEvent();
            InitData();
            Button btn_Submit = new Button();
            dockPanel1.Controls.Add(btn_Submit);
            btn_Submit.Location = new Point(currentPosX, currentPosY + 10);
            btn_Submit.Text = "提交";
            btn_Submit.Click += new EventHandler(btn_Submit_Click);
            if (dockPanel1.ControlContainer.Controls.Count > 0)
                dockPanel1.ControlContainer.Controls[0].Focus();
        }

        void btn_Submit_Click(object sender, EventArgs e)
        {

            switch (status)
            {
                case "add":
                    LP_Record newRecord = new LP_Record();
                    dsoFramerWordControl1.FileSave();
                    newRecord.DocContent = dsoFramerWordControl1.FileDataGzip;
                    newRecord.Kind = kind;
                    newRecord.Content = GetContent();
                    newRecord.CreateTime = DateTime.Now.ToString();
                    MainHelper.PlatformSqlMap.Create<LP_Record>(newRecord);
                    break;
                case "edit":
                    currRecord.LastChangeTime = DateTime.Now.ToString();
                    dsoFramerWordControl1.FileSave();
                    currRecord.DocContent = this.dsoFramerWordControl1.FileDataGzip;
                    byte[] bt = new byte[0];
                    currRecord.ImageAttachment = bt;
                    currRecord.SignImg = bt;
                    currRecord.Content = GetContent();
                    if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                    if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                    MainHelper.PlatformSqlMap.Update("UpdateLP_Record", CurrRecord);
                    break;
            }
            this.DialogResult = DialogResult.OK;
        }

        public string GetContent()
        {
            StringBuilder strBuild = new StringBuilder();
            foreach (Control ctrl in dockPanel1.ControlContainer.Controls)
            {
                if (ctrl.Tag != null)
                {
                    LP_Temple lp = ctrl.Tag as LP_Temple;
                    strBuild.Append(lp.LPID);
                    strBuild.Append(",");
                    if (lp.CtrlType.Contains("uc_gridcontrol"))
                    {
                        strBuild.Append((ctrl as uc_gridcontrol).ConvertBetweenDataTableAndXML_AX((ctrl as uc_gridcontrol).GetDS()));
                    }
                    else
                        strBuild.Append(ctrl.Text);
                    strBuild.Append(plitchar);
                }
            }
            return strBuild.ToString();
        }

        public void LoadContent()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string[] arrContent = currRecord.Content.Split(pchar);
            for (int i = 0; i < arrContent.Length; i++)
            {
                if (arrContent[i] != "")
                {
                    int index = arrContent[i].IndexOf(',');
                    dict[arrContent[i].Substring(0, index)] = arrContent[i].Substring(index + 1);
                }
            }
            foreach (Control ctrl in dockPanel1.ControlContainer.Controls)
            {
                if (ctrl.Tag != null)
                {
                    LP_Temple lp = ctrl.Tag as LP_Temple;
                    if (lp.CtrlType.Contains("uc_gridcontrol"))
                    {
                        (ctrl as uc_gridcontrol).SetDs((ctrl as uc_gridcontrol).ConvertBetweenDataTableAndXML_AX(dict[lp.LPID]));
                    }
                    else if (lp.CtrlType.Contains("DevExpress.XtraEditors.DateEdit"))
                    {
                        (ctrl as DevExpress.XtraEditors.DateEdit).DateTime = Convert.ToDateTime(dict[lp.LPID]);
                    }
                    else
                        ctrl.Text = dict[lp.LPID];
                }
            }
        }

        public void InitEvent()
        {
            foreach (Control ctrl in dockPanel1.ControlContainer.Controls)
            {
                if (ctrl.Tag != null) 
                {
                    RelateEvent(ctrl);
                }
            }
        }

        public void InitData()
        {
            foreach (Control ctrl in dockPanel1.ControlContainer.Controls)
            {
                if (ctrl.Tag != null)
                    InitCtrlData(ctrl, ((LP_Temple)ctrl.Tag).SqlSentence);
            }
        }

        void ctrl_Leave(object sender, EventArgs e)
        {
            LP_Temple lp = (LP_Temple)(sender as Control).Tag;
            string str = (sender as Control).Text;
            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            ExcelAccess ea = new ExcelAccess();
            ea.MyWorkBook = wb;
            ea.MyExcel=wb.Application;
            if (lp.CtrlType.Contains("uc_gridcontrol"))
            { FillTable(ea, lp, (sender as uc_gridcontrol).GetContent(String2Int(lp.WordCount.Split(pchar)))); return; }
            else if (lp.CtrlType.Contains("DevExpress.XtraEditors.DateEdit"))
            { FillTime(ea, lp, (sender as DateEdit).DateTime); return; }
            string[] arrCellpos = lp.CellPos.Split(pchar);
            string[] arrtemp = lp.WordCount.Split(pchar);
            List<int> arrCellCount = String2Int(arrtemp);
            if (arrCellpos.Length == 1)
                ea.SetCellValue(str, GetCellPos(lp.CellPos)[0], GetCellPos(lp.CellPos)[1]);
            else if(arrCellpos.Length>1)
            {
                StringHelper help = new StringHelper();
                int i = 0;
                if (arrCellCount[0] != arrCellCount[1])
                {
                    if (str.IndexOf("\r\n") == -1 && str.Length <= help.GetFristLen(str, arrCellCount[0]))
                    {
                        ea.SetCellValue(str, GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);
                        return;
                    }
                    ea.SetCellValue(str.Substring(0, str.IndexOf("\r\n") != -1 && help.GetFristLen(str, arrCellCount[0]) >=
                        str.IndexOf("\r\n") ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0])),
                        GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);

                    str = str.Substring(help.GetFristLen(str, arrCellCount[0]) >= str.IndexOf("\r\n") &&
                        str.IndexOf("\r\n") != -1 ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0]));
                    i++;
                }
                str = help.GetPlitString(str, arrCellCount[1]);
                FillMutilRows(ea, i, lp, str, arrCellCount, arrCellpos);

            }
        }

        public void FillTable(ExcelAccess ea, LP_Temple lp, string[] content)
        {
            string[] arrCol = lp.CellPos.Split(pchar);
            string[] arrtemp=lp.WordCount.Split(pchar);
            List<int> arrCellCount = String2Int(arrtemp);
            for (int i = 0; i < arrCol.Length; i++)
            {
                if(content[i]!=null)
                    FillMutilRowsT(ea, lp, content[i], arrCellCount[i], arrCol[i]);
            }
        }

        public void FillMutilRows(ExcelAccess ea, int i, LP_Temple lp, string str, List<int> arrCellCount, string[] arrCellPos)
        {
            StringHelper help = new StringHelper();
            str = help.GetPlitString(str, arrCellCount[1]);
            string[] arrRst = str.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int j = 0;
            for (; i < arrCellPos.Length; i++)
            {
                if (j >= arrRst.Length)
                    break;
                ea.SetCellValue(arrRst[j], GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                j++;
            }
        }

        public void FillTime(ExcelAccess ea, LP_Temple lp,DateTime dt)
        {
            string[] arrCellPos = lp.CellPos.Split(pchar);
            IList<string> strList=new List<string>();
            if (arrCellPos.Length == 5)
            { 
                strList.Add(dt.Year.ToString());strList.Add(dt.Month.ToString());
                strList.Add(dt.Day.ToString()); strList.Add(dt.Hour.ToString()); strList.Add(dt.Minute.ToString());
            }
            else if (arrCellPos.Length == 4)
            {
                strList.Add(dt.Day.ToString()); strList.Add(dt.Hour.ToString()); strList.Add(dt.Minute.ToString());
            }
            else if (arrCellPos.Length == 3)
            {
                strList.Add(dt.Year.ToString()); strList.Add(dt.Month.ToString());
                strList.Add(dt.Day.ToString());
            }
            else if (arrCellPos.Length == 1)
            {
                strList.Add(dt.ToString());
            }
            int i = 0;
            foreach (string str in strList)
            {
                ea.SetCellValue(str, GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                i++;
            }
        }

        public void FillMutilRowsT(ExcelAccess ea, LP_Temple lp, string str, int cellcount, string arrCellPos)
        {
            StringHelper help = new StringHelper();
            //str = help.GetPlitString(str, cellcount);
            string[] arrRst = str.Split(new string[] { "\r\n" },StringSplitOptions.None);
            for (int i=0; i < arrRst.Length; i++)
            {
                ea.SetCellValue(arrRst[i], GetCellPos(arrCellPos)[0] + i, GetCellPos(arrCellPos)[1]);
            }
        }

        public int[] GetCellPos(string cellpos)
        {

            cellpos = cellpos.Replace("|", "");
            Regex r1 = new Regex(@"[0-9]+");
            string str = r1.Match(cellpos).Value;
            int ix = 0;
            int iy = 0;
            ix = int.Parse(str);
            r1 = new Regex(@"[A-Z]+");
            str = r1.Match(cellpos).Value;
            if (str.Length == 2)
            {
                iy = ((int)str[0] - 64) * 26 + ((int)str[1] - 64);
            }
            else
            {
                iy = (int)cellpos[0] - 64;
            }
            return new int[] { ix, iy };
        }

        public List<int> String2Int(string[] temp)
        {
            List<int> arrRst = new List<int>();
            for (int i = 0; i < temp.Length; i++)
            {
                arrRst.Add(int.Parse(temp[i]));
            }
            return arrRst;
        }


        public void InitCtrlData(Control ctrl, string sqlSentence)
        {
            LP_Temple lp = (LP_Temple)ctrl.Tag;
            string ctrltype = "";
            if (lp.CtrlType.IndexOf(',') == -1)
                ctrltype = lp.CtrlType;
            else
                ctrltype = lp.CtrlType.Substring(0, lp.CtrlType.IndexOf(','));
            switch (ctrltype)
            {
                case "DevExpress.XtraEditors.TextEdit":
                    break;
                case "DevExpress.XtraEditors.ComboBoxEdit":
                    ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.Clear();
                    if (sqlSentence == "")
                        break;
                    ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                    IList list = MainHelper.PlatformSqlMap.GetList(SplitSQL(sqlSentence)[0], SplitSQL(sqlSentence)[1]);
                    for (int i = 0; i < list.Count; i++)
                    {
                        ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.Add(list[i].GetType().GetProperty(lp.SqlColName).GetValue(list[i],null));
                    }
                    if (((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.Count > 0)
                        ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).SelectedIndex = 0;
                    break;
                case "DevExpress.XtraEditors.DateEdit":
                    //((DevExpress.XtraEditors.DateEdit)ctrl).Properties.EditMask = "F";
                    //string[] arrCellPos = lp.CellPos.Split(pchar);
                    //if (arrCellPos.Length == 5)
                    //{
                    //    ((DevExpress.XtraEditors.DateEdit)ctrl).DateTime = DateTime.Now;
                    //    ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
                    //    ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.EditMask = "yyyy-MM-dd HH:mm";
                    //}
                    //else if (arrCellPos.Length == 3)
                    //{

                    //    ((DevExpress.XtraEditors.DateEdit)ctrl).DateTime = DateTime.Now;
                    //    ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
                    //    ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.EditMask = "yyyy-MM-dd";
                    //}
                    ((DevExpress.XtraEditors.DateEdit)ctrl).DateTime = DateTime.Now;

                    if (lp.WordCount != "" && lp.WordCount.IndexOf("|") == -1)
                    {
                        ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.DisplayFormat.FormatString = lp.WordCount;
                        ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.EditMask = lp.WordCount;
                    }
                    else
                    {
                        ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
                        ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.EditMask = "yyyy-MM-dd HH:mm";

                    }
                    break;
                case "DevExpress.XtraEditors.MemoEdit":
                    break;
                case "uc_gridcontrol":
                    ((uc_gridcontrol)ctrl).InitData(lp.SqlSentence, lp.SqlColName.Split(pchar),lp.ComBoxItem.Split(pchar),dsoFramerWordControl1,lp,currRecord);
                    break;
            }
        }

        public int CalcWidth()
        {
            int wordcount = 0;
            foreach (LP_Temple lp in templeList)
            {
                if (lp.CellName.Length > wordcount)
                    wordcount = lp.CellName.Length;
            }
            return wordWidth * wordcount;
        }

        public string[] SplitSQL(string sql)
        {
            int pos = sql.IndexOf("where");
            string temp = "";
            return new string[] { pos == -1 ? (temp=sql.Replace(" ","")) : 
                (temp=sql.Substring(0, pos).Replace(" ","")), pos == -1 ? "" : sql.Substring(pos) };
        }


        public void RelateEvent(Control ctrl)
        {
            LP_Temple lp = (LP_Temple)ctrl.Tag;
            if (lp.AffectLPID != null && lp.AffectLPID != "")
            {
                string[] arrLPID = lp.AffectLPID.Split(pchar);
                string[] arrEvent = lp.AffectEvent.Split(pchar);
                for (int i = 0; i < arrLPID.Length; i++)
                {
                    ctrl.GetType().GetEvent(arrEvent[i]).AddEventHandler(ctrl, new EventHandler(TriggerRelateEvent));
                }
            }
        }

        public void TriggerRelateEvent(object sender, EventArgs e)
        {
            LP_Temple lp = (LP_Temple)((Control)sender).Tag;
            string[] arrLPID = lp.AffectLPID.Split(pchar);
            foreach (string lpid in arrLPID)
            {
                Control ctrl = FindCtrl(lpid);
                if (ctrl != null)
                {                    
                    UpdateRelateData(ctrl); 
                }
            }
        }

        public void UpdateRelateData(Control ctrl)
        {
            LP_Temple lp = (LP_Temple)ctrl.Tag;
            string[] arrLPID = lp.RelateLPID.Split(pchar);
            string sqlSentence = lp.SqlSentence;
            foreach (string lpid in arrLPID)
            {
                Control relateCtrl = FindCtrl(lpid);
                if (relateCtrl != null)
                {
                    int pos = sqlSentence.IndexOf("@"+lpid);
                    if (pos != -1)
                    {
                        sqlSentence = sqlSentence.Remove(pos, ("@" + lpid).Length);
                        sqlSentence = sqlSentence.Insert(pos, relateCtrl.Text);
                    }
                }
            }
            InitCtrlData(ctrl, sqlSentence);
        }

        public Control FindCtrl(string name)
        {
            foreach (Control ctrl in dockPanel1.ControlContainer.Controls)
            {
                if (ctrl.Name == name)
                    return ctrl;
            }
            return null;
        }
    }
}
