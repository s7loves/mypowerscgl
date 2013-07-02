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
    public partial class frmSD23Edit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<sdjl_23> m_CityDic = new SortableSearchableBindingList<sdjl_23>();

        public frmSD23Edit()
        {
            InitializeComponent();
        }
        void dataBind()
        {

            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "cqfw");
            // this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "LineCode");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "cqdw");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "Remark");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "qdrq");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "qxydd");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "linename");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "fzlinename");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "gh");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "xybh");
             this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "jf");
            //this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "gzrjID");
            //this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "CreateMan");
        }
        #region IPopupFormEdit Members
        private sdjl_23 rowData = null;

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
                    this.rowData = value as sdjl_23;

                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sdjl_23>(value as sdjl_23, rowData);
                }
            }
        }

        #endregion

        /// <summary>
        /// 初始协议编号
        /// </summary>

        private void InitComboBoxData()
        {
           
            comboBoxEdit4.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("23配电线路产权维护范围协议书", "签协议地点", comboBoxEdit4.Properties);
            IList<sd_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_xl>(" where OrgCode='" + rowData.ParentID + "' and linevol>=10.0 and parentid=''");
            foreach (sd_xl pl in xlList)
            {
                comboBoxEdit6.Properties.Items.Add(pl.LineName);
                
            }
            comboBoxEdit9.Properties.Items.Clear();
            comboBoxEdit9.Properties.Items.Add(MainHelper.UserCompany);
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
            comboBoxEdit6.Properties.Items.Clear();
            IList list=new ArrayList();
           list= Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select linename from sd_xl where orgcode='"+rowData.ParentID+"' and parentid='0'");
           comboBoxEdit6.Properties.Items.AddRange(list);
        }

       

        

        private void comboBoxEdit1_Properties_Click(object sender, EventArgs e)
        {
            frmDykSelector dlg = new frmDykSelector();
            PJ_dyk dyk = null;
            PJ_dyk parentObj = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_dyk>("where dx='电力设备产权维护范围协议书' and sx='维护界限划分原则' and parentid=''");
            if (parentObj != null)
            {
                dlg.ucpJ_dykSelector1.ParentObj = parentObj;
                //dlg.TxtMemo = txt;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    comboBoxEdit1.Text = dlg.ucpJ_dykSelector1.GetSelectedRow().nr;
                }
            }
            else
            {
                MsgBox.ShowWarningMessageBox("请维护短语库：电力设备产权维护范围协议书|维护界限划分原则");
            }
            //frmCqSelector fcs = new frmCqSelector();
            //if (fcs.ShowDialog()==DialogResult.OK)
            //{
            //    comboBoxEdit1.Text = fcs.dynr;
            //}
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rowData.BigData.Length == 0)
            {
                mOrg org = MainHelper.PlatformSqlMap.GetOneByKey<mOrg>(rowData.ParentID);
                string fname = Application.StartupPath + "\\00记录模板\\送电电力设备产权、维护范围协议书.xls";
                string bhname = org.OrgName.Replace("供电所", "");
                DSOFramerControl dsoFramerControl1 = new DSOFramerControl();
                dsoFramerControl1.FileOpen(fname);
                Microsoft.Office.Interop.Excel.Workbook wb = dsoFramerControl1.AxFramerControl.ActiveDocument as Microsoft.Office.Interop.Excel.Workbook;
                //sdjl_23 obj = (sdjl_23)MainHelper.PlatformSqlMap.GetObject("Selectsdjl_23List", "where ParentID='" + rowData.ParentID + "' and xybh like '" + SelectorHelper.GetPysm(org.OrgName.Replace("供电所", ""), true) + "" + DateTime.Now.Year.ToString() + "%' order by xybh ASC");
                //int icount = 1;
                //if (obj != null && obj.xybh !="")
                //{
                //    icount = Convert.ToInt32(obj.xybh.Split('-')[2])+1;
                //}
                //string strname = SelectorHelper.GetPysm(bhname, true);
                ExcelAccess ea = new ExcelAccess();
                ea.MyWorkBook = wb;
                ea.MyExcel = wb.Application;
                ea.SetCellValue(rowData.xybh.ToUpper(), 4, 8);
                //strname = DateTime.Now.Year.ToString();
                //ea.SetCellValue(strname, 4, 9);
                //strname = string.Format("{0:D3}", icount);
                //ea.SetCellValue(strname, 4, 10);
                ea.SetCellValue(rowData.linename, 10, 7);
                ea.SetCellValue(rowData.fzlinename, 10, 10);
                ea.SetCellValue("'" + rowData.gh, 10, 16);
                ea.SetCellValue(rowData.cqfw, 11, 4);
                ea.SetCellValue(rowData.cqdw, 13, 4);
                ea.SetCellValue(rowData.qdrq.Year.ToString(), 21, 7);
                ea.SetCellValue(rowData.qdrq.Month.ToString(), 21, 9);
                ea.SetCellValue(rowData.qdrq.Day.ToString(), 21, 11);
                dsoFramerControl1.FileSave();
                rowData.BigData = dsoFramerControl1.FileData;
                dsoFramerControl1.FileClose();
                dsoFramerControl1.Dispose();
                dsoFramerControl1 = null;
                //rowData.xybh = SelectorHelper.GetPysm(bhname, true).ToUpper() + "-" + DateTime.Now.Year.ToString() + "-" + string.Format("{0:D3}", icount);
            }
            DSOFramerControl dsoFramerControl2 = new DSOFramerControl();
            dsoFramerControl2.FileData = rowData.BigData;
            Microsoft.Office.Interop.Excel.Workbook wb2 = dsoFramerControl2.AxFramerControl.ActiveDocument as Microsoft.Office.Interop.Excel.Workbook;
            ExcelAccess ea2 = new ExcelAccess();
            ea2.MyWorkBook = wb2;
            ea2.MyExcel = wb2.Application;
            ea2.SetCellValue(comboBoxEdit1.Text, 11, 4);
            dsoFramerControl2.FileSave();
            rowData.BigData = dsoFramerControl2.FileData;
            dsoFramerControl2.FileClose();
            dsoFramerControl2.Dispose();
            dsoFramerControl2 = null;
        }

        private void comboBoxEdit6_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.comboBoxEdit6.EditValue as string))
                return;
            comboBoxEdit7.Properties.Items.Clear();
            sd_xl xl= Client.ClientHelper.PlatformSqlMap.GetOne<sd_xl>("where linename='" + this.comboBoxEdit6.EditValue as string+"'");
            if (xl == null)
                return;
            IList gtList = new ArrayList();
            gtList= Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select gth from sd_gt where linecode='"+xl.LineCode+"'");
            comboBoxEdit7.Properties.Items.AddRange(gtList);
        }
    }
}