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
namespace Ebada.Scgl.Yxgl
{
    public partial class frm26Edit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_26> m_CityDic = new SortableSearchableBindingList<PJ_26>();

        public frm26Edit() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "tzdw");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "lineVol");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "tzrq");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "Remark");
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "fxwt");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "clcs");
            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_26 rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_26;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_26>(value as PJ_26, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<PJ_26>(" WHERE Citylevel = '2'"));
          /*  IList<DicType> list = new List<DicType>();
            list.Add(new DicType("0", "机构"));
            list.Add(new DicType("1", "供电所"));
            list.Add(new DicType("2", "变电所"));
            this.SetComboBoxData(this.lookUpEdit1, "Value", "Key", "请选择", "种类", list);*/

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strname = "";
            string fname = "";
            string bhname="";
            int icount = 1;

           
            DSOFramerControl dsoFramerControl1 = new DSOFramerControl();
            Microsoft.Office.Interop.Excel.Workbook wb;
            ExcelAccess ea = new ExcelAccess();
            if (rowData.BigData == null || rowData.BigData.Length == 0)
            {
                 fname = Application.StartupPath + "\\00记录模板\\26防护通知书.xls";
                dsoFramerControl1.FileOpen(fname);
            }
            else
                dsoFramerControl1.FileData = rowData.BigData;
            wb = dsoFramerControl1.AxFramerControl.ActiveDocument as Microsoft.Office.Interop.Excel.Workbook;
            ea.MyWorkBook = wb;
            ea.MyExcel = wb.Application;
            if (rowData.BigData == null || rowData.BigData.Length == 0)
            {
                fname = Application.StartupPath + "\\00记录模板\\26防护通知书.xls";



                mOrg org = MainHelper.PlatformSqlMap.GetOneByKey<mOrg>(rowData.ParentID);
                bhname = org.OrgName.Replace("供电所", "");
                PJ_26 obj = (PJ_26)MainHelper.PlatformSqlMap.GetObject("SelectPJ_26List", "where ParentID='" + rowData.ParentID + "' and xybh like '" + SelectorHelper.GetPysm(org.OrgName.Replace("供电所", ""), true) + "-" + DateTime.Now.Year.ToString() + "-%' order by xybh ASC");

                if (obj != null && obj.xybh != "")
                {
                    icount = Convert.ToInt32(obj.xybh.Split('-')[2]) + 1;
                }
                rowData.xybh = SelectorHelper.GetPysm(bhname, true).ToUpper() + "-" + DateTime.Now.Year.ToString() + "-" + string.Format("{0:D3}", icount);
                strname = SelectorHelper.GetPysm(bhname, true);
                ea.SetCellValue(strname.ToUpper(), 4, 9);
                strname = DateTime.Now.Year.ToString();
                ea.SetCellValue(strname, 4, 11);
                strname = string.Format("{0:D3}", icount);
                ea.SetCellValue(strname, 4, 13);
               
            }
            ea.SetCellValue(comboBoxEdit1.Text + "：", 5, 2);
            ea.SetCellValue(comboBoxEdit3.Text, 6, 11);
            if (memoEdit2.Text.Length > 25)
            {
                ea.SetCellValue(memoEdit2.Text.Substring(0, 25), 7, 3);
                ea.SetCellValue(memoEdit2.Text.Substring(26), 8, 2);
            }
            else
                {
                    ea.SetCellValue(memoEdit2.Text, 7, 3);
                }
            if (memoEdit3.Text.Length > 23)
            {
                ea.SetCellValue(memoEdit3.Text.Substring(0, 23), 13, 4);
                ea.SetCellValue(memoEdit3.Text.Substring(24), 14, 2);
            }
            else
                {
                    ea.SetCellValue(memoEdit3.Text, 13, 4);
                }
            dsoFramerControl1.FileSave();
            rowData.BigData = dsoFramerControl1.FileData;
            dsoFramerControl1.FileClose();
            dsoFramerControl1.Dispose();
            dsoFramerControl1 = null;
        }
    }
}