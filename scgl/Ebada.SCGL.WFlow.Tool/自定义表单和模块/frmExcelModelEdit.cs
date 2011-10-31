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
namespace Ebada.SCGL.WFlow.Tool
{
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
            //this.checkEdit1.DataBindings.Add("EditValue", rowData, "IsVisible");
            this.textEdit9.DataBindings.Add("EditValue", rowData, "ColumnName");
            //this.textEdit10.DataBindings.Add("EditValue", rowData, "Status");
            this.lookUpEdit2.DataBindings.Add("EditValue", rowData, "Status");  
            this.textEdit11.DataBindings.Add("EditValue", rowData, "ComBoxItem");
            this.textEdit12.DataBindings.Add("EditValue", rowData, "ExtraWord");
            //this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "isExplorer");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "KindTable");
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
                    dataBind();
                    //this.InitComboBoxData();
                   
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
            comboBoxEdit5.Properties.Items.Clear();
            ListItem lt = new ListItem("yyyy-MM-dd","年-月-日");
            comboBoxEdit5.Properties.Items.Add(lt);
            lt = new ListItem("yyyy-MM-dd HH:mm", "年-月-日 时:分");
            comboBoxEdit5.Properties.Items.Add(lt);
            lt = new ListItem("yyyy-MM-dd HH:mm:ss", "年-月-日 时:分:秒");
            comboBoxEdit5.Properties.Items.Add(lt);
            lt = new ListItem("MM-dd日 HH:mm", "月-日 时:分");
            comboBoxEdit5.Properties.Items.Add(lt);
            lt = new ListItem("dd日 HH:mm", "日 时:分");
            comboBoxEdit5.Properties.Items.Add(lt);
            lt = new ListItem("HH:mm:ss", "时:分:秒");
            comboBoxEdit5.Properties.Items.Add(lt);
            lt = new ListItem("HH:mm", "时:分");
            comboBoxEdit5.Properties.Items.Add(lt);

            comboBoxEdit1.Properties.Items.Clear();
            comboBoxEdit1.Properties.Items.Add("table");
            comboBoxEdit1.Properties.Items.Add("enter");
            LP_Temple tp = ClientHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(UCmExcel.GetParentID());
            //IList<WF_WorkTask> wflist = ClientHelper.PlatformSqlMap.GetList<WF_WorkTask>(" WHERE WorkFlowId = '" + rowData.ParentID + "' and TaskTypeId!='2'");
            //list = new List<DicType>();
            //foreach (WF_WorkTask wf in wflist)
            //{
            //    list.Add(new DicType(wf.TaskCaption, wf.TaskCaption));
            //}
            //this.SetComboBoxData(this.lookUpEdit2, "Value", "Key", "请选择", "状态", list);
           DSOFramerControl dsoFramerWordControl1 =new DSOFramerControl ();
           //bool isadd = true;
           if (tp == null)
           {
               dsoFramerWordControl1.FileDataGzip = rowData.DocContent;
               rowData.DocContent = new byte[0];
           }
           else
           {
               dsoFramerWordControl1.FileDataGzip = tp.DocContent;
               
           }

           Microsoft.Office.Interop.Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Microsoft.Office.Interop.Excel.Workbook;
           Microsoft.Office.Interop.Excel.Worksheet xx = wb.Application.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
           comboBoxEdit4.Properties.Items.Clear();
            for (int i = 1; i <= wb.Application.Sheets.Count; i++)
           {

               Microsoft.Office.Interop.Excel.Worksheet tmpSheet = (Microsoft.Office.Interop.Excel.Worksheet)wb.Application.Sheets.get_Item(i);
                   try
                   {
                       if (tmpSheet != null)
                       {
                           //tmpSheet.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetHidden;
                           comboBoxEdit4.Properties.Items.Add(tmpSheet.Name);
                       }

                   }
                   catch { }

               
           }
            dsoFramerWordControl1.FileClose();
            dsoFramerWordControl1.Dispose();
           comboBoxEdit4.Text = xx.Name;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit5.Visible)
            {
                rowData.WordCount = ((ListItem)comboBoxEdit5.SelectedItem).ID;
            }
            rowData.IsVisible = checkEdit1.Checked ? 0 : 1;
            rowData.CellPos = rowData.CellPos.ToUpper();
            rowData.isExplorer = comboBoxEdit3.SelectedIndex;
        }

        private void frmExcelModelEdit_Load(object sender, EventArgs e)
        {
            comboBoxEdit3.SelectedIndex = rowData.isExplorer;
            if (rowData.DocContent.Length>0)
            {
                DSOFramerControl dsoFramerWordControl1 = new DSOFramerControl();
                dsoFramerWordControl1.FileDataGzip = rowData.DocContent;
                Microsoft.Office.Interop.Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Microsoft.Office.Interop.Excel.Workbook;
                Microsoft.Office.Interop.Excel.Worksheet xx = wb.Application.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
                rowData.KindTable = xx.Name;
                
            
            }
            InitComboBoxData();
            if (rowData.KindTable == "")
            {
               
                if (comboBoxEdit4.Properties.Items.Count > 0) rowData.KindTable = comboBoxEdit4.Properties.Items[0].ToString();
                comboBoxEdit4.Text = rowData.KindTable;
            }
            if (rowData.CtrlType.IndexOf("DateEdit")>-1)
            {
                if (rowData.WordCount.IndexOf("|") == -1)
                { 
                    
                switch (rowData.WordCount)
                {
                    case "yyyy-MM-dd":
                comboBoxEdit5.SelectedIndex =0;
                        break;
                    case "yyyy-MM-dd HH:mm":
                        comboBoxEdit5.SelectedIndex = 1;
                        break;
                    case "yyyy-MM-dd HH:mm:ss":
                        comboBoxEdit5.SelectedIndex = 2;
                        break;
                    case "MM-dd日 HH:mm":
                        comboBoxEdit5.SelectedIndex = 3;
                        break;
                    case "dd日 HH:mm":
                        comboBoxEdit5.SelectedIndex = 4;
                        break;
                    case "HH:mm:ss":
                        comboBoxEdit5.SelectedIndex = 4;
                        break;
                    case "HH:mm":
                        comboBoxEdit5.SelectedIndex = 5;
                        break;
                    default:
                        comboBoxEdit5.SelectedIndex = -1;
                        break;
                
                }
                
                }
                else
                    comboBoxEdit5.SelectedIndex = 0;

                labelControl3.Visible = false;
                textEdit7.Visible = false;

                labelControl24.Visible = true;
                comboBoxEdit5.Visible = true;
            }
            else
            {
                labelControl3.Visible = true;
                textEdit7.Visible = true;

                labelControl24.Visible = false;
                comboBoxEdit5.Visible = false;
            }
            checkEdit1.Checked= rowData.IsVisible==0? true:false;
            
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue.ToString().IndexOf("DateEdit") > -1)
            {

                labelControl3.Visible = false;
                textEdit7.Visible = false;

                labelControl24.Visible = true;
                comboBoxEdit5.Visible = true;
            }
            else
            {
                labelControl3.Visible = true;
                textEdit7.Visible = true;

                labelControl24.Visible = false;
                comboBoxEdit5.Visible = false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmExcelEditSQLSet fees = new frmExcelEditSQLSet();
            fees.RowData = rowData;
            fees.StrSQL = textEdit3.Text;
            if (fees.ShowDialog() == DialogResult.OK)
            {
                textEdit3.Text = fees.StrSQL;
                rowData.SqlSentence = fees.StrSQL;
            }
        }
    }
}