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
using Excel = Microsoft.Office.Interop.Excel;
namespace Ebada.Scgl.Lcgl
{
    public partial class frm23Edit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_23> m_CityDic = new SortableSearchableBindingList<PJ_23>();

        public frm23Edit() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "cqfw");
           // this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "LineCode");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "cqdw");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "Remark");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "qdrq");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "qxydd");
            //this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "gzrjID");
            //this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "CreateMan");
           
            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_23 rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_23;
                    
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_23>(value as PJ_23, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<PJ_23>(" WHERE Citylevel = '2'"));
          /*  IList<DicType> list = new List<DicType>();
            list.Add(new DicType("0", "机构"));
            list.Add(new DicType("1", "供电所"));
            list.Add(new DicType("2", "变电所"));
            this.SetComboBoxData(this.lookUpEdit1, "Value", "Key", "请选择", "种类", list);*/
            ComboBoxHelper.FillCBoxByDyk("23配电线路产权维护范围协议书", "签协议地点", comboBoxEdit4.Properties);
            //if (null != cityCode && cityCode.Trim().Length > 0)
            //    this.cltCity.Properties.KeyValue = cityCode;
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

        private void frmdlgzdhjtjlEdit_Load(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click_1(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit1_Properties_Click(object sender, EventArgs e)
        {
            frmDykSelector dlg = new frmDykSelector();
            PJ_dyk dyk = null;
            PJ_dyk parentObj = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_dyk>("where dx='23配电线路产权维护范围协议书' and sx='维护界限划分原则' and parentid=''");
            if (parentObj != null)
            {
                dlg.ucpJ_dykSelector1.ParentObj = parentObj;
                // dlg.TxtMemo = txt;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    comboBoxEdit1.Text = dlg.ucpJ_dykSelector1.GetSelectedRow().nr4;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rowData.BigData.Length == 0)
            {
                mOrg org = MainHelper.PlatformSqlMap.GetOneByKey<mOrg>(rowData.ParentID);
                string fname = Application.StartupPath + "\\00记录模板\\23配电线路产权维护范围协议书.xls";
                DSOFramerControl dsoFramerControl1 = new DSOFramerControl();
                dsoFramerControl1.FileOpen(fname);
                Microsoft.Office.Interop.Excel.Workbook wb = dsoFramerControl1.AxFramerControl.ActiveDocument as Microsoft.Office.Interop.Excel.Workbook;
                PJ_23 obj = (PJ_23)MainHelper.PlatformSqlMap.GetObject("SelectPJ_23List", "where ParentID='" + rowData.ParentID + "' and xybh like '" + SelectorHelper.GetPYString(org.OrgName) + "-" + DateTime.Now.Year.ToString() + "-%' order by xybh ASC");
                int icount = 1;
                if (obj != null && obj.xybh != "")
                {
                    icount = Convert.ToInt32(obj.xybh.Split('-')[2]) + 1;
                }
                string strname = SelectorHelper.GetPYString(org.OrgName);
                ExcelAccess ea = new ExcelAccess();
                ea.MyWorkBook = wb;
                ea.MyExcel = wb.Application;
                ea.SetCellValue(strname.ToUpper(), 4, 8);
                strname = DateTime.Now.Year.ToString();
                ea.SetCellValue(strname, 4, 9);
                strname = string.Format("{0:D3}", icount);
                ea.SetCellValue(strname, 4, 10);
                dsoFramerControl1.FileSave();
                rowData.BigData = dsoFramerControl1.FileData;
                dsoFramerControl1.FileClose();
                dsoFramerControl1.Dispose();
                dsoFramerControl1 = null;
                rowData.xybh = SelectorHelper.GetPYString(org.OrgName).ToUpper() + "-" + DateTime.Now.Year.ToString() + "-" + string.Format("{0:D3}", icount);
                
            }
        }
    }
}