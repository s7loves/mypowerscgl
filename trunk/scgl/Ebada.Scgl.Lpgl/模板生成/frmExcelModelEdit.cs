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
namespace Ebada.Scgl.Lpgl {
    public partial class frmExcelModelEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<LP_Temple> m_CityDic = new SortableSearchableBindingList<LP_Temple>();
        private string parentID;
        public string ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }
        public frmExcelModelEdit() {
            InitializeComponent();
        }
        public frmExcelModelEdit(string parentid)
        {
            ParentID = parentid;
            InitializeComponent();
        }
        void dataBind() {


            this.textEdit1.DataBindings.Add("EditValue", rowData, "CellPos");
            this.textEdit2.DataBindings.Add("EditValue", rowData, "CellName");
            this.textEdit7.DataBindings.Add("EditValue", rowData, "WordCount");
            this.textEdit6.DataBindings.Add("EditValue", rowData, "CtrlLocation");
            this.textEdit5.DataBindings.Add("EditValue", rowData, "CtrlSize");
            this.textEdit3.DataBindings.Add("EditValue", rowData, "SqlSentence");
            //this.textEdit7.DataBindings.Add("EditValue", rowData, "SortID");

            this.textEdit4.DataBindings.Add("EditValue", rowData, "SortID");       
            this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "CtrlType");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "EventName");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "SqlColName");
            this.lookUpEdit4.DataBindings.Add("EditValue", rowData, "RelateLPID");
            this.lookUpEdit5.DataBindings.Add("EditValue", rowData, "AffectLPID");
            this.textEdit8.DataBindings.Add("EditValue", rowData, "AffectEvent");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "Birthday");
            this.checkEdit1.DataBindings.Add("EditValue", rowData, "IsVisible");
            this.textEdit9.DataBindings.Add("EditValue", rowData, "ColumnName");
            //this.textEdit10.DataBindings.Add("EditValue", rowData, "Status");
            this.lookUpEdit2.DataBindings.Add("EditValue", rowData, "Status");  
            this.textEdit11.DataBindings.Add("EditValue", rowData, "ComBoxItem");
            this.textEdit12.DataBindings.Add("EditValue", rowData, "ExtraWord");
            parentID = UCmExcel.GetParentID();
        }
        #region IPopupFormEdit Members
        private LP_Temple rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as LP_Temple;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<LP_Temple>(value as LP_Temple, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {

            IList<DicType> list = new List<DicType>();
            list.Add(new DicType("DevExpress.XtraEditors.TextEdit,DevExpress.XtraEditors,Version=10.1.7.0,Culture=neutral,PublicKeyToken=b88d1754d700e49a", "DevExpress.XtraEditors.TextEdit"));
            list.Add(new DicType("DevExpress.XtraEditors.ComboBoxEdit,DevExpress.XtraEditors,Version=10.1.7.0,Culture=neutral,PublicKeyToken=b88d1754d700e49a", "DevExpress.XtraEditors.ComboBoxEdit"));
            list.Add(new DicType("DevExpress.XtraEditors.DateEdit,DevExpress.XtraEditors,Version=10.1.7.0,Culture=neutral,PublicKeyToken=b88d1754d700e49a", "DevExpress.XtraEditors.DateEdit"));
            list.Add(new DicType("DevExpress.XtraEditors.MemoEdit,DevExpress.XtraEditors,Version=10.1.7.0,Culture=neutral,PublicKeyToken=b88d1754d700e49a", "DevExpress.XtraEditors.MemoEdit"));
            list.Add(new DicType("uc_gridcontrol", "uc_gridcontrol"));
            //list.Add(new DicType("xlqxp", "抢修票"));停电操作票
            this.SetComboBoxData(this.lookUpEdit1, "Value", "Key", "请选择", "种类", list);

            comboBoxEdit1.Properties.Items.Clear();
            comboBoxEdit1.Properties.Items.Add("table");
            comboBoxEdit1.Properties.Items.Add("enter");
            LP_Temple tp = ClientHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(UCmExcel.GetParentID());
            IList<WF_WorkTask> wflist = ClientHelper.PlatformSqlMap.GetList<WF_WorkTask>(" WHERE WorkFlowId = '" + tp.ParentID + "' and TaskTypeId!='2'");
            list = new List<DicType>();
            foreach (WF_WorkTask wf in wflist)
            {
                list.Add(new DicType(wf.TaskCaption, wf.TaskCaption));
            }
            this.SetComboBoxData(this.lookUpEdit2, "Value", "Key", "请选择", "状态", list);
            //comboBoxEdit2.Properties.Items.Clear();
            //ICollection col3 = Ebada.Scgl.Core.ComboBoxHelper.GetTables();
            //comboBoxEdit2.Properties.Items.AddRange(col3);

            //IList<LP_Temple> listCellPos = ClientHelper.PlatformSqlMap.GetList<LP_Temple>(" WHERE parentid = '" + UCmExcel.GetParentID() + "'");
         
            //IList<DicType> list4 = new List<DicType>();
            //char []chSplit = new char[]{','};
            //foreach (LP_Temple lp in listCellPos)
            //{
            //    list4.Add(new DicType(lp.LPID, lp.CellPos + "(" + (lp.CtrlType.Split(chSplit))[0] + ")"));                
            //}

            //this.SetComboBoxData(this.lookUpEdit4, "Value", "Key", "请选择", "影响此控件的控件", list4);
            //this.SetComboBoxData(this.lookUpEdit5, "Value", "Key", "请选择", "受此控件影响的控件", list4);   
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

        private void lookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}