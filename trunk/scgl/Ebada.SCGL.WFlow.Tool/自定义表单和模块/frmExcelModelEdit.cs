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
        bool isclose = true;
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
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "ExtraWord");
            this.lookUpEdit4.DataBindings.Add("EditValue", rowData, "RelateLPID");
            this.lookUpEdit5.DataBindings.Add("EditValue", rowData, "AffectLPID");
            this.textEdit8.DataBindings.Add("EditValue", rowData, "AffectEvent");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "Birthday");
            //this.checkEdit1.DataBindings.Add("EditValue", rowData, "IsVisible");
            this.textEdit9.DataBindings.Add("EditValue", rowData, "ColumnName");
            //this.textEdit10.DataBindings.Add("EditValue", rowData, "Status");
            this.lookUpEdit2.DataBindings.Add("EditValue", rowData, "Status");  
            this.textEdit11.DataBindings.Add("EditValue", rowData, "ComBoxItem");
            this.textEdit12.DataBindings.Add("EditValue", rowData, "SqlColName");
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
            ListItem lt = new ListItem("yyyy年MM月dd日", "yyyy年MM月dd日");
            comboBoxEdit5.Properties.Items.Add(lt);
            lt = new ListItem("yyyy-MM-dd", "yyyy-MM-dd");
            comboBoxEdit5.Properties.Items.Add(lt);
            lt = new ListItem("MM-dd日", "MM-dd日");
            comboBoxEdit5.Properties.Items.Add(lt);
            lt = new ListItem("yyyy-MM-dd HH:mm", "yyyy-MM-dd HH:mm");
            comboBoxEdit5.Properties.Items.Add(lt);
            lt = new ListItem("yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd HH:mm:ss");
            comboBoxEdit5.Properties.Items.Add(lt);
            lt = new ListItem("MM-dd日 HH:mm", "MM-dd日 HH:mm");
            comboBoxEdit5.Properties.Items.Add(lt);
            lt = new ListItem("dd日 HH:mm", "dd日 HH:mm");
            comboBoxEdit5.Properties.Items.Add(lt);
            lt = new ListItem("HH:mm:ss", "HH:mm:ss");
            comboBoxEdit5.Properties.Items.Add(lt);
            lt = new ListItem("HH:mm", "HH:mm");
            comboBoxEdit5.Properties.Items.Add(lt);
            lt = new ListItem("yyyy", "yyyy");
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
           int j = 0;
            for (int i = 1; i <= wb.Application.Sheets.Count; i++)
           {

               Microsoft.Office.Interop.Excel.Worksheet tmpSheet = (Microsoft.Office.Interop.Excel.Worksheet)wb.Application.Sheets.get_Item(i);
                   try
                   {
                       if (tmpSheet != null)
                       {
                           //tmpSheet.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetHidden;
                          
                           if (xx.Name == tmpSheet.Name)
                           {
                               j = comboBoxEdit4.Properties.Items.Add(tmpSheet.Name);
                             
                           }
                           else
                           {
                                comboBoxEdit4.Properties.Items.Add(tmpSheet.Name);
                           }
                       }

                   }
                   catch { }

               
           }
            dsoFramerWordControl1.FileClose();
            dsoFramerWordControl1.Dispose();
            comboBoxEdit4.SelectedIndex = j;
           //comboBoxEdit4.Text = xx.Name;
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
            string strpos = textEdit1.Text;
            if(strpos=="")return;
            setWordLen();
        }
        private void setWordLen()
        {
            if (textEdit7.Visible == false) return;
            string strpos = textEdit1.Text;
            string strlen = textEdit7.Text;
            if (strpos.Substring(strpos.Length - 1) != "|")
                strpos = strpos + "|";
            if (strlen.Length> 0)
            {
                if (strlen.Substring(strlen.Length - 1) != "|")
                    strlen = strlen + "|";
            }
            string[] celpos = strpos.Split('|');
            string[] cellen = strlen.Split('|');
            //位置比大小限制多
            if (celpos.Length != cellen.Length)
            {
                if (strlen.Length > 0)
                labelTip.Text = (celpos.Length - cellen.Length).ToString()+"   ";
                else
                    labelTip.Text = (celpos.Length - cellen.Length + 1).ToString() + "   ";

            }
           
            else
            {
                labelTip.Text ="";
            }
        }
        private void groupControlOrg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (textEdit7.Text == "" && textEdit7.Visible)
            {
                MsgBox.ShowWarningMessageBox("控件字数不能为空");
                isclose = false;
                return;
            }
            if (textEdit5.Text == "")
            {
                MsgBox.ShowWarningMessageBox("控件大小不能为空");
                isclose = false;
                
                return;
            }
            if (lookUpEdit1.EditValue==null || lookUpEdit1.EditValue.ToString() == "")
            {
                MsgBox.ShowWarningMessageBox("控件类型不能为空");
                isclose = false;

                return;
            }
            isclose = true;
            object ob = new object();
           
            if (comboBoxEdit5.Visible)
            {
                //rowData.WordCount = ((ListItem)comboBoxEdit5.SelectedItem).ID;
                rowData.WordCount = comboBoxEdit5.Text;
            }
            rowData.IsVisible = checkEdit1.Checked ? 0 : 1;
            rowData.CellPos = rowData.CellPos.ToUpper();
            rowData.isExplorer = comboBoxEdit3.SelectedIndex;
            this.DialogResult = DialogResult.OK;
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
                if (rowData.KindTable=="") rowData.KindTable = xx.Name;
                
            
            }
            InitComboBoxData();
            if (rowData.KindTable == "")
            {

                if (comboBoxEdit4.Properties.Items.Count > 0)
                {
                    rowData.KindTable = comboBoxEdit4.Properties.Items[0].ToString();
                    comboBoxEdit4.Text = rowData.KindTable;
                }
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
                    case "MM-dd日":
                        comboBoxEdit5.SelectedIndex = 1;
                    break;
                    case "yyyy-MM-dd HH:mm":
                        comboBoxEdit5.SelectedIndex = 2;
                        break;
                    case "yyyy-MM-dd HH:mm:ss":
                        comboBoxEdit5.SelectedIndex = 3;
                        break;
                    case "MM-dd日 HH:mm":
                        comboBoxEdit5.SelectedIndex = 4;
                        break;
                    case "dd日 HH:mm":
                        comboBoxEdit5.SelectedIndex = 5;
                        break;
                    case "HH:mm:ss":
                        comboBoxEdit5.SelectedIndex = 6;
                        break;
                    case "HH:mm":
                        comboBoxEdit5.SelectedIndex = 7;
                        break;
                    default:
                        comboBoxEdit5.Text = rowData.WordCount;
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
            comboBoxEdit6.Properties.Items.Clear();
            //comboBoxEdit3.Properties.Items.Add("SelectedIndexChanged");
            comboBoxEdit6.Properties.Items.Add("TextChanged");
            comboBoxEdit6.Properties.Items.Add("GotFocus");
            comboBoxEdit6.Properties.Items.Add("LostFocus");
            if (lookUpEdit1.EditValue.ToString().IndexOf("DateEdit") > -1)
            {

                labelControl3.Visible = false;
                textEdit7.Visible = false;

                labelControl24.Visible = true;
                comboBoxEdit5.Visible = true;
                comboBoxEdit2.Properties.Items.Clear();
                comboBoxEdit2.Properties.Items.Add("{0}年{1}月{2}日");
            }
            else
            {
                if (lookUpEdit1.EditValue.ToString().IndexOf("ComboBoxEdit") > -1)
                {
                    comboBoxEdit6.Properties.Items.Clear();
                    comboBoxEdit6.Properties.Items.Add("SelectedIndexChanged");
                    comboBoxEdit6.Properties.Items.Add("TextChanged");
                    comboBoxEdit6.Properties.Items.Add("GotFocus");
                    comboBoxEdit6.Properties.Items.Add("LostFocus");
                }
                labelControl3.Visible = true;
                textEdit7.Visible = true;

                labelControl24.Visible = false;
                comboBoxEdit5.Visible = false;
                comboBoxEdit2.Properties.Items.Clear();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (rowData.CtrlType.IndexOf("uc_gridcontrol") == -1)
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
            else
            {
                simpleButton2_Click(sender, e);
            }
        }

        private void frmExcelModelEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isclose)
            {
                e.Cancel = true;
                return;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmGridcontrolSQLSet fees = new frmGridcontrolSQLSet();
            fees.RowData = rowData;
            fees.StrSQL = textEdit3.Text;
            if (fees.ShowDialog() == DialogResult.OK)
            {
                textEdit3.Text = fees.StrSQL;
                rowData.SqlSentence = fees.StrSQL;
            }
        }

        private void labelTip_Click(object sender, EventArgs e)
        {
            string strpos = textEdit1.Text;
            string strlen = textEdit7.Text;
            if (strpos.Substring(strpos.Length-1) != "|")
                strpos = strpos + "|";
            if (strlen.Substring(strlen.Length - 1) != "|")
                strlen = strlen + "|";
            string[] celpos = strpos.Split('|');
            string[] cellen = strlen.Split('|');
            //位置比大小限制多
            if (celpos.Length > cellen.Length)
            {
                for(int i=0;i<celpos.Length - cellen.Length;i++)
                {
                    strlen += "50|";
                }
                textEdit7.Text = strlen;
                rowData.WordCount = textEdit7.Text;
            }
            else if (celpos.Length < cellen.Length)//位置比大小限制少
            {
                int j = 0;
                string strtemp = strlen.Substring(0, strlen.Length-1);
                for (int i = 0; i <cellen.Length- celpos.Length  ; i++)
                {
                    j = strtemp.LastIndexOf("|");
                    strtemp=strtemp.Substring(0,j);
                }
                textEdit7.Text = strtemp;
                rowData.WordCount = textEdit7.Text;
            }
        }

        private void textEdit7_EditValueChanged(object sender, EventArgs e)
        {
            string strpos = textEdit1.Text;
            if (strpos == "") return;
            setWordLen();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmGridcontrolColumnSet fees = new frmGridcontrolColumnSet();
            fees.RowData = rowData;
            fees.StrSQL = textEdit11.Text;
            if (fees.ShowDialog() == DialogResult.OK)
            {
                textEdit11.Text = fees.StrSQL;
                rowData.ComBoxItem = fees.StrSQL;
            }
        }

        private void textEdit9_EditValueChanged(object sender, EventArgs e)
        {
           
            string strcolumn = textEdit9.Text;
            if (strcolumn == "") return;
            if (strcolumn.Substring(strcolumn.Length - 1) != "|")
                strcolumn = strcolumn + "|";
            string strlen = textEdit11.Text;
            if (strlen.Length > 0)
            {
                if (strlen.Substring(strlen.Length - 1) != "|")
                    strlen = strlen + "|";
            }
            string[] celcolumn = strcolumn.Split('|');
            string[] cellen = strlen.Split('|');
            //位置比大小限制多
            if (celcolumn.Length > cellen.Length)
            {
                if (cellen.Length == 1 && cellen[0].ToString() == "")
                {
                    strlen = "[0:RepositoryItemComboBox]|";
                }

                for (int i = cellen.Length-1; i <cellen.Length+ celcolumn.Length - cellen.Length; i++)
                {
                    strlen += "[" + i + ":RepositoryItemComboBox]|";
                }
                textEdit11.Text = strlen;
                rowData.ComBoxItem = textEdit11.Text;
            }
            else if (celcolumn.Length < cellen.Length)//位置比大小限制少
            {
                int j = 0;
                string strtemp = strlen.Substring(0, strlen.Length - 1);
                for (int i = 0; i < cellen.Length - celcolumn.Length; i++)
                {
                    j = strtemp.LastIndexOf("|");
                    strtemp = strtemp.Substring(0, j);
                }
                textEdit11.Text = strtemp;
                rowData.ComBoxItem = textEdit11.Text;
            }
        }

       
    }
}