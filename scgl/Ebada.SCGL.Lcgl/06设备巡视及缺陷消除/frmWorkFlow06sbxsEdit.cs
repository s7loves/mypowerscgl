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
using System.Threading;
using Ebada.Scgl.WFlow;
namespace Ebada.Scgl.Lcgl {
    public partial class frmWorkFlow06sbxsEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_06sbxsmx> m_CityDic = new SortableSearchableBindingList<PJ_06sbxsmx>();

        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_06sbxsmx,LP_Record";
        private bool readOnly = false;
        public bool ReadOnly {
            get { return readOnly; }
            set {
                readOnly = value;
                btnOK.Visible = !value;
            }
        }
        public LP_Temple ParentTemple {
            get { return parentTemple; }
            set {
                parentTemple = value;
            }
        }
        public bool IsWorkflowCall {
            set {

                isWorkflowCall = value;
            }
        }
        public LP_Record CurrRecord {
            get { return currRecord; }
            set {
                currRecord = value;

            }
        }

        public DataTable RecordWorkFlowData {
            get {
                return WorkFlowData;
            }
            set {
                WorkFlowData = value;
            }
        }
        public string VarDbTableName {
            get { return varDbTableName; }
            set {
                varDbTableName = value; ;
            }
        }

        public frmWorkFlow06sbxsEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "LineID");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "xlqd");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "xssj");
            //this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "xsr");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "qxlb");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "qxnr", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "xcr");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "xcrq");

            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
            // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_06sbxsmx rowData = null;

        public object RowData {
            get {
                getxsr();
                getxcr();
                return rowData;
            }
            set {
                if (value == null) return;

                if (rowData == null) {
                    this.rowData = value as PJ_06sbxsmx;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_06sbxsmx>(value as PJ_06sbxsmx, rowData);
                    this.InitComboBoxData();
                }
                setxsr();
                setxcr();
            }
        }

        #endregion

        private void InitComboBoxData() {
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表

            comboBoxEdit3.Properties.Items.AddRange(ryList);
            comboBoxEdit5.Properties.Items.AddRange(ryList);
            comboBoxEdit6.Properties.Items.AddRange(ryList);
            comboBoxEdit7.Properties.Items.AddRange(ryList);
            //ICollection linelist = ComboBoxHelper.GetGdsxl(rowData.OrgCode);//获取供电线路名称
            ////线路名称
            //comboBoxEdit1.Properties.Items.AddRange(linelist);
            IList<PS_xl> xllit = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>(" where OrgCode='" + rowData.OrgCode + "'and linevol>=10.0 ");
            if (xllit.Count == 0) {
                xllit = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>(" where 1=1");
            }
            SetComboBoxData(lookUpEdit1, "LineName", "LineID", "选择线路", "", xllit);

            //巡视区段
            // ComboBoxHelper.FillCBoxByDyk("06设备巡视及缺陷消除记录", "巡视区段", comboBoxEdit2.Properties);


            //ICollection qxlist = ComboBoxHelper.GetQxlb();//获取缺陷类别
            //缺陷类别GetQxlb
            ComboBoxHelper.FillCBoxByDyk("06设备巡视及缺陷消除记录", "缺陷类别", comboBoxEdit4.Properties);

            //ComboBoxHelper.FillCBoxByDyk("06设备巡视及缺陷消除记录", "巡视人", comboBoxEdit3.Properties);

            //comboBoxEdit4.Properties.Items.AddRange(qxlist);
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<PS_xl> post) {
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
        void setxsr() {
            string str = rowData.xsr;
            comboBoxEdit3.EditValue = "";
            comboBoxEdit6.EditValue = "";
            string[] mans = str.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
            if (mans.Length >= 1) {
                comboBoxEdit3.EditValue = mans[0];
            }
            if (mans.Length >= 2) {
                comboBoxEdit6.EditValue = mans[1];
            }
        }
        void getxsr() {
            string str = "";
            string yy1 = "";
            yy1 = comboBoxEdit3.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy1 + ";";
            string yy2 = "";
            yy2 = comboBoxEdit6.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy2 + ";";
            rowData.xsr = str;
        }
        void setxcr() {
            string str = rowData.xcr;
            comboBoxEdit5.EditValue = "";
            comboBoxEdit7.EditValue = "";
            string[] mans = str.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
            if (mans.Length >= 1) {
                comboBoxEdit5.EditValue = mans[0];
            }
            if (mans.Length >= 2) {
                comboBoxEdit7.EditValue = mans[1];
            }
        }
        void getxcr() {
            string str = "";
            string yy1 = "";
            yy1 = comboBoxEdit5.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy1 + ";";
            string yy2 = "";
            yy2 = comboBoxEdit7.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy2 + ";";
            rowData.xcr = str;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(lookUpEdit1.Text)) {
                rowData.LineID = lookUpEdit1.EditValue.ToString();
                rowData.LineName = lookUpEdit1.Text;
                comboBoxEdit2.Properties.Items.Clear();
                //comboBoxEdit3.Properties.Items.Clear();
                //comboBoxEdit6.Properties.Items.Clear();
                IList<PJ_sbxsqd> xllit = Client.ClientHelper.PlatformSqlMap.GetList<PJ_sbxsqd>(" where LineCode='" + rowData.LineID + "'");
                foreach (PJ_sbxsqd xsqd in xllit) {
                    comboBoxEdit2.Properties.Items.Add(xsqd.XsqdName);
                    comboBoxEdit3.Properties.Items.Add(xsqd.XSR1);
                    comboBoxEdit6.Properties.Items.Add(xsqd.XSR2);
                }
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            SelectorHelper.SelectDyk("06设备巡视及缺陷消除记录", "缺陷内容", memoEdit1);

        }



        private void comboBoxEdit3_Properties_SelectedValueChanged(object sender, EventArgs e) {
            //string xsry = comboBoxEdit3.Properties.GetDisplayText(null);
            ////comboBoxEdit3.EditValue = "";
            //comboBoxEdit6.EditValue = "";
            //string[] mans = xsry.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
            //if (mans.Length >= 1)
            //{
            //    comboBoxEdit3.EditValue = mans[0];
            //}
            //if (mans.Length >= 2)
            //{
            //    comboBoxEdit6.EditValue = mans[1];
            //}

        }

        private void comboBoxEdit2_EditValueChanged(object sender, EventArgs e) {
            string xsqdname = comboBoxEdit2.EditValue.ToString();
            PJ_sbxsqd ps = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_sbxsqd>("where XsqdName='" + xsqdname + "'and LineCode='" + rowData.LineID + "' ");
            if (ps != null) {
                comboBoxEdit3.EditValue = ps.XSR1;
                comboBoxEdit6.EditValue = ps.XSR2;
            }
        }

        private void comboBoxEdit2_Properties_EditValueChanged(object sender, EventArgs e) {
            //ICollection list = new ArrayList();
            //list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select XSR1 from PJ_sbxsqd where XsqdName='{0}' ", comboBoxEdit2.EditValue));
            //comboBoxEdit3.Properties.Items.Clear();
            //comboBoxEdit3.Properties.Items.AddRange(list);

            //list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select XSR2 from PJ_sbxsqd where XsqdName='{0}' ", comboBoxEdit2.EditValue));
            //comboBoxEdit6.Properties.Items.Clear();
            //comboBoxEdit6.Properties.Items.AddRange(list); 
        }

        private void comboBoxEdit4_EditValueChanged(object sender, EventArgs e) {

            DateTime dt = Convert.ToDateTime(rowData.xssj);
            string dx = "", sx = "";
            int dayspan1 = 1, dayspan2 = 10, dayspan3 = 30;
            dx = "06设备巡视及缺陷消除记录";
            sx = "紧急缺陷";
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}'", dx, sx));
            if (list.Count > 0) {
                dayspan1 = Convert.ToInt32(list[0]);
            }

            sx = "重大缺陷";
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}'", dx, sx));
            if (list.Count > 0) {
                dayspan2 = Convert.ToInt32(list[0]);
            }
            sx = "一般缺陷";
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}'", dx, sx));
            if (list.Count > 0) {
                dayspan3 = Convert.ToInt32(list[0]);
            }
            if (comboBoxEdit4.EditValue == null) return;
            switch (comboBoxEdit4.EditValue.ToString()) {
                case "紧急缺陷":
                    rowData.xcqx = dt.AddDays(dayspan1).ToShortDateString();
                    break;
                case "重大缺陷":
                    rowData.xcqx = dt.AddDays(dayspan2).ToShortDateString();
                    break;
                case "一般缺陷":
                    rowData.xcqx = dt.AddDays(dayspan3).ToShortDateString();
                    break;
            }


        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e) {
            comboBoxEdit4_EditValueChanged(sender, e);
        }
        public static void update(PJ_06sbxsmx qxjl) {
           PJ_06sbxsmx sbxs = qxjl;
            string strmes = "";
            object obj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_06sbxsmx>(sbxs.ID);
            PJ_qxfl qxfj = new PJ_qxfl();
            if (obj == null) {
                obj = MainHelper.PlatformSqlMap.GetOne<PJ_06sbxs>("where  OrgCode='" + sbxs.OrgCode + "' and  LineID='" + sbxs.LineID + "' and xlqd='" + sbxs.xlqd + "'");
                if (obj == null) {
                    PJ_06sbxs sbxstemp = new PJ_06sbxs();
                    sbxstemp.OrgCode = sbxs.OrgCode;
                    sbxstemp.OrgName = sbxs.OrgName;
                    sbxstemp.LineID = sbxs.LineID;
                    sbxstemp.LineName = sbxs.LineName;
                    sbxstemp.xlqd = sbxs.xlqd;
                    sbxstemp.xssj = DateTime.Now;
                    sbxstemp.CreateMan = MainHelper.User.UserName;
                    MainHelper.PlatformSqlMap.Create<PJ_06sbxs>(sbxstemp);
                    sbxs.ParentID = sbxstemp.ID;
                } else {
                    sbxs.ParentID = (obj as PJ_06sbxs).ID;
                }

                MainHelper.PlatformSqlMap.Create<PJ_06sbxsmx>(sbxs);
            } else {
                PJ_06sbxsmx qxfltemp = obj as PJ_06sbxsmx;
                qxfltemp.LineID = sbxs.LineID;
                qxfltemp.LineName = sbxs.LineName;
                qxfltemp.OrgCode = sbxs.OrgCode;
                qxfltemp.OrgName = sbxs.OrgName;
                qxfltemp.qxlb = sbxs.qxlb;
                qxfltemp.qxnr = sbxs.qxnr;
                qxfltemp.xssj = sbxs.xssj;
                qxfltemp.xsr = sbxs.xsr;
                qxfltemp.xcqx = sbxs.xcqx;
                qxfltemp.xlqd = sbxs.xlqd; ;
                qxfltemp.xcr = sbxs.xcr;
                qxfltemp.xcrq = sbxs.xcrq;
                MainHelper.PlatformSqlMap.Update<PJ_06sbxsmx>(qxfltemp);
            }
        }
        private void btnOK_Click(object sender, EventArgs e) {
            PJ_06sbxsmx sbxs = RowData as PJ_06sbxsmx;
            string strmes = "";
            object obj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_06sbxsmx>(sbxs.ID);
            PJ_qxfl qxfj = new PJ_qxfl();
            if (obj == null) {
                obj = MainHelper.PlatformSqlMap.GetOne<PJ_06sbxs>("where  OrgCode='" + sbxs.OrgCode + "' and  LineID='" + sbxs.LineID + "' and xlqd='" + sbxs.xlqd + "'");
                if (obj == null) {
                    PJ_06sbxs sbxstemp = new PJ_06sbxs();
                    sbxstemp.OrgCode = sbxs.OrgCode;
                    sbxstemp.OrgName = sbxs.OrgName;
                    sbxstemp.LineID = sbxs.LineID;
                    sbxstemp.LineName = sbxs.LineName;
                    sbxstemp.xlqd = sbxs.xlqd;
                    sbxstemp.xsr = sbxs.xsr;
                    sbxstemp.xssj = DateTime.Now;
                    sbxstemp.CreateMan = MainHelper.User.UserName;
                    MainHelper.PlatformSqlMap.Create<PJ_06sbxs>(sbxstemp);
                    sbxs.ParentID = sbxstemp.ID;
                } else {
                    sbxs.ParentID = (obj as PJ_06sbxs).ID;
                }

                MainHelper.PlatformSqlMap.Create<PJ_06sbxsmx>(sbxs);
                //WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                //mrwt.ModleRecordID = sbxs.ID;
                //mrwt.RecordID = currRecord.ID;
                //mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                //mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                //mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                //mrwt.ModleTableName = sbxs.GetType().ToString();
                //mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                //mrwt.CreatTime = DateTime.Now;
                //MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                if (sbxs.qxlb != "") {


                    qxfj.CreateDate = sbxs.CreateDate;
                    qxfj.CreateMan = sbxs.CreateMan;
                    qxfj.LineID = sbxs.LineID;
                    qxfj.LineName = sbxs.LineName;
                    qxfj.OrgCode = sbxs.OrgCode;
                    qxfj.OrgName = sbxs.OrgName;
                    qxfj.qxlb = sbxs.qxlb;
                    qxfj.qxly = "设备巡视";
                    qxfj.qxnr = sbxs.qxnr;
                    qxfj.xcqx = sbxs.xcqx;
                    qxfj.xcr = sbxs.xcr;
                    qxfj.xlqd = sbxs.xlqd;
                    qxfj.xsr = sbxs.xsr;
                    qxfj.xssj = sbxs.xssj;
                    MainHelper.PlatformSqlMap.Create<PJ_qxfl>(qxfj);
                }
            } else {
                PJ_qxfl qxfltemp = MainHelper.PlatformSqlMap.GetOne<PJ_qxfl>(" where CONVERT(varchar, CreateDate, 120 ) =  '" + sbxs.CreateDate + "'"
                  + " and LineID='" + sbxs.LineID + "'"
                  + " and OrgCode='" + sbxs.OrgCode + "'"
                   + " and qxlb='" + sbxs.qxlb + "'"
                   + " and xsr='" + sbxs.xsr + "'"
                   + " and xlqd='" + sbxs.xlqd + "'"
                  );
                if (qxfltemp != null) {
                    qxfltemp.LineID = sbxs.LineID;
                    qxfltemp.LineName = sbxs.LineName;
                    qxfltemp.OrgCode = sbxs.OrgCode;
                    qxfltemp.OrgName = sbxs.OrgName;
                    qxfltemp.qxlb = sbxs.qxlb;
                    qxfltemp.qxnr = sbxs.qxnr;
                    qxfltemp.xssj = sbxs.xssj;
                    qxfltemp.xsr = sbxs.xsr;
                    qxfltemp.xcqx = sbxs.xcqx;
                    qxfltemp.xlqd = sbxs.xlqd; ;
                    qxfltemp.xcr = sbxs.xcr;
                    qxfltemp.xcrq = sbxs.xcrq;
                    MainHelper.PlatformSqlMap.Update<PJ_qxfl>(qxfltemp);
                }
                MainHelper.PlatformSqlMap.Update<PJ_06sbxsmx>(sbxs);
            }


            currRecord.LastChangeTime = DateTime.Now.ToString();
            if (RecordWorkTask.CheckOnRiZhi(WorkFlowData)) {

                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { sbxs, qxfj, currRecord });

            }
            WF_WorkTaskCommands wt;
            //string[] strtemp = RecordWorkTask.RunNewGZPRecord(currRecord.ID, kind, MainHelper.User.UserID);
            wt = (WF_WorkTaskCommands)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
            if (wt != null) {
                strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), wt.CommandName);
            } else {
                strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), "提交");
            }
            if (strmes.IndexOf("未提交至任何人") > -1) {
                MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                return;
            } else
                MsgBox.ShowTipMessageBox(strmes);
            strmes = RecordWorkTask.GetWorkFlowTaskCaption(WorkFlowData.Rows[0]["WorkTaskInsId"].ToString());
            if (strmes == "结束节点1") {
                currRecord.Status = "存档";
            } else {
                currRecord.Status = strmes;
            }
            if (currRecord.ImageAttachment == null) {
                currRecord.ImageAttachment = new byte[0];
            }
            if (currRecord.DocContent == null) {
                currRecord.DocContent = new byte[0];
            }
            if (currRecord.SignImg == null) {
                currRecord.SignImg = new byte[0];
            }

            currRecord.LastChangeTime = DateTime.Now.ToString();
            if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
            if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
            MainHelper.PlatformSqlMap.Update("UpdateLP_Record", currRecord);
            //if (obj == null ) {//&& (sbxs.qxlb != "")
            //    DataTable dttemp = RecordWorkTask.GetRecordWorkFlowData(currRecord.ID);
            //    if (dttemp.Rows.Count > 0) {
            //        Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            //        WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
            //        mrwt.ID = mrwt.CreateID();
            //        mrwt.ModleRecordID = sbxs.ID;
            //        mrwt.RecordID = currRecord.ID;
            //        mrwt.WorkFlowId = dttemp.Rows[0]["WorkFlowId"].ToString();
            //        mrwt.WorkFlowInsId = dttemp.Rows[0]["WorkFlowInsId"].ToString();
            //        mrwt.WorkTaskId = dttemp.Rows[0]["WorkTaskId"].ToString();
            //        mrwt.ModleTableName = sbxs.GetType().ToString();
            //        mrwt.WorkTaskInsId = dttemp.Rows[0]["WorkTaskInsId"].ToString();
            //        mrwt.CreatTime = DateTime.Now;
            //        MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
            //    }

            //}
        }
    }
}