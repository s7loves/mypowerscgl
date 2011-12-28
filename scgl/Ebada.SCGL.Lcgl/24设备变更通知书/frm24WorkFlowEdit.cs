using System;
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
namespace Ebada.Scgl.Lcgl
{
    public partial class frm24WorkFlowEdit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<PJ_24> m_CityDic = new SortableSearchableBindingList<PJ_24>();

        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_08sbtdjx,LP_Record";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
            }
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
            set
            {
                currRecord = value;

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
            }
        }
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value; ;
            }
        }

        public frm24WorkFlowEdit()
        {
            InitializeComponent();
        }
        void dataBind()
        {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "dd");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "sj");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "nr", false, DataSourceUpdateMode.OnPropertyChanged);
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "Remark");

        }
        #region IPopupFormEdit Members
        private PJ_24 rowData = null;

        public object RowData
        {
            get
            {
                return rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as PJ_24;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<PJ_24>(value as PJ_24, rowData);
                }
                if (rowData.dd == "")
                {
                    rowData.sj = DateTime.Now;

                }
            }

        }

        #endregion

        private void InitComboBoxData()
        {
            ICollection ryList = ComboBoxHelper.Getbtq();
            if (ryList.Count > 0)
            {
                comboBoxEdit1.Properties.Items.AddRange(ryList);
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



        private void frmdlgzdhjtjlEdit_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (comboBoxEdit1.Text == "")
            //{
            //    MsgBox.ShowTipMessageBox("变动地点不能为空。");
            //    comboBoxEdit1.Focus();
            //    return;
            //}

            ////if (rowData.BigData == null)
            ////{
            ////    rowData.BigData = new byte[0];
            ////}
            //this.DialogResult = DialogResult.OK;
            //this.Close();
            string strmes = "";
            DSOFramerControl dsoFramerControl1 = new DSOFramerControl();
            Microsoft.Office.Interop.Excel.Workbook wb;
            if (rowData.BigData == null || rowData.BigData.Length == 0)
            {
                string fname = Application.StartupPath + "\\00记录模板\\24设备变更通知书.xls";
                dsoFramerControl1.FileOpen(fname);
            }
            else
                dsoFramerControl1.FileData = rowData.BigData;
            wb = dsoFramerControl1.AxFramerControl.ActiveDocument as Microsoft.Office.Interop.Excel.Workbook;
            ExcelAccess ea = new ExcelAccess();
            ea.MyWorkBook = wb;
            ea.MyExcel = wb.Application;
            DateTime dt = Convert.ToDateTime(dateEdit1.EditValue);
            ea.SetCellValue(dt.Year.ToString(), 4, 7);
            mOrg org = MainHelper.PlatformSqlMap.GetOne<mOrg>(" where orgid='" + rowData.ParentID + "'");
            if (org != null)
                ea.SetCellValue(org.OrgName,4, 9);
            ea.SetCellValue(dt.Year.ToString(), 9, 1);
            ea.SetCellValue(dt.Month.ToString(), 9, 3);
            ea.SetCellValue(dt.Day.ToString(), 9, 5);
            ea.SetCellValue(comboBoxEdit1.Text, 6, 7);
            ea.SetCellValue(memoEdit1.Text, 6, 8);
            ea.SetCellValue(memoEdit2.Text, 6, 11);
            dsoFramerControl1.FileSave();
            rowData.BigData = dsoFramerControl1.FileData;
            dsoFramerControl1.FileClose();
            dsoFramerControl1.Dispose();
            dsoFramerControl1 = null;
            MainHelper.PlatformSqlMap.Update<PJ_24>(rowData);

            currRecord.LastChangeTime = DateTime.Now.ToString();
            if (RecordWorkTask.CheckOnRiZhi(WorkFlowData))
            {

                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { rowData, currRecord });

            }
            WF_WorkTaskCommands wt;
            //string[] strtemp = RecordWorkTask.RunNewGZPRecord(currRecord.ID, kind, MainHelper.User.UserID);
            wt = (WF_WorkTaskCommands)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
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
            strmes = RecordWorkTask.GetWorkFlowTaskCaption(WorkFlowData.Rows[0]["WorkTaskInsId"].ToString());
            if (strmes == "结束节点1")
            {
                currRecord.Status = "存档";
            }
            else
            {
                currRecord.Status = strmes;
            }
            if (currRecord.ImageAttachment == null)
            {
                currRecord.ImageAttachment = new byte[0];
            }
            if (currRecord.DocContent == null)
            {
                currRecord.DocContent = new byte[0];
            }
            if (currRecord.SignImg == null)
            {
                currRecord.SignImg = new byte[0];
            }

            currRecord.LastChangeTime = DateTime.Now.ToString();
            MainHelper.PlatformSqlMap.Update("UpdateLP_Record", currRecord);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("24设备变更通知书", "变动内容及说明", memoEdit1);

        }


    }
}