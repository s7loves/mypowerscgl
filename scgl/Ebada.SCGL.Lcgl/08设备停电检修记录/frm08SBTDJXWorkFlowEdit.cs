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
    public partial class frm08SBTDJXWorkFlowEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_08sbtdjx> m_CityDic = new SortableSearchableBindingList<PJ_08sbtdjx>();
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

        public frm08SBTDJXWorkFlowEdit()
        {
            InitializeComponent();
        }
        void dataBind() {

            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "LineName");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "tdxz");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "gzfzr");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "sdsj");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "tdsj");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "jxnr", false, DataSourceUpdateMode.OnPropertyChanged);
           
            

            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_08sbtdjx rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_08sbtdjx;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_08sbtdjx>(value as PJ_08sbtdjx, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<PJ_08sbtdjx>(" WHERE Citylevel = '2'"));
          /*  IList<DicType> list = new List<DicType>();
            list.Add(new DicType("0", "机构"));
            list.Add(new DicType("1", "供电所"));
            list.Add(new DicType("2", "变电所"));
            this.SetComboBoxData(this.lookUpEdit1, "Value", "Key", "请选择", "种类", list);*/

            //if (null != cityCode && cityCode.Trim().Length > 0)
            //    this.cltCity.Properties.KeyValue = cityCode;

            ICollection xlList = ComboBoxHelper.GetGdsxl(rowData.OrgCode);//获取供电所线路列表
            //if (xlList.Count > 0)
            //{
                this.comboBoxEdit1.Properties.Items.AddRange(xlList);
            //}
                ICollection ryList = ComboBoxHelper.GetGdsRyfzr(rowData.OrgCode);//获取供电所人员列表
            if (ryList.Count > 0)
            {
                this.comboBoxEdit3.Properties.Items.AddRange(ryList);
            }
            //ICollection tdxz = ComboBoxHelper.GetTDXZ();

            //this.comboBoxEdit4.Properties.Items.AddRange(tdxz);
            ComboBoxHelper.FillCBoxByDyk("08设备停电检修记录", "停电性质", comboBoxEdit4.Properties);
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

        private void frmgzrjEdit_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("08设备停电检修记录", "检修内容", memoEdit1);
            //memoEdit1.Focus();
        }

        private void comboBoxEdit4_Properties_Click(object sender, EventArgs e)
        {
            //frmDykSelector dlg = new frmDykSelector();
            //PJ_dyk dyk = null;
            //PJ_dyk parentObj = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_dyk>("where dx='08设备停电检修记录' and sx='停电性质' and parentid=''");
            //if (parentObj != null)
            //{
            //    dlg.ucpJ_dykSelector1.ParentObj = parentObj;
            //   // dlg.TxtMemo = txt;
            //    if (dlg.ShowDialog()==DialogResult.OK)
            //    {
            //        comboBoxEdit4.Text = dlg.ucpJ_dykSelector1.GetSelectedRow() .nr;
            //    }
                
                
            //}
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
            if (rowData.sdsj<rowData.tdsj)
            {
                MsgBox.ShowTipMessageBox("送电应在停电后!");
                dateEdit3.Focus();
                return;
            }
            PJ_08sbtdjx sbxs = RowData as PJ_08sbtdjx;
            string strmes = "";
            object obj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_08sbtdjx>(sbxs.ID);
            if (obj == null)
            {
                MainHelper.PlatformSqlMap.Create<PJ_08sbtdjx>(sbxs);
            }

            else {



              
                MainHelper.PlatformSqlMap.Update<PJ_08sbtdjx>(sbxs);
            
            }
            if (isWorkflowCall )
            {
              

                currRecord.LastChangeTime = DateTime.Now.ToString();
                if (RecordWorkTask.CheckOnRiZhi(WorkFlowData))
                {

                    RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { sbxs, currRecord });

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
                if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                MainHelper.PlatformSqlMap.Update("UpdateLP_Record", currRecord);
            }
            this.DialogResult= DialogResult.OK;
        }
    }
}