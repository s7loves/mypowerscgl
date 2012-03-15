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
namespace Ebada.Scgl.Lcgl
{
    public partial class frmrsdaEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_ryda> m_CityDic = new SortableSearchableBindingList<PJ_ryda>();

        public frmrsdaEdit()
        {
            InitializeComponent();
        }
        void dataBind() {



            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "wdmc");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "wdlx");
            
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "Remark");

            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_ryda rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_ryda;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_ryda>(value as PJ_ryda, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            comboBoxEdit1.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='人事档案' and sx like '%{0}%' and nr!=''", "文档名称"));
            if (strlist.Count > 0)
                comboBoxEdit1.Properties.Items.AddRange(strlist);
            else
            {

                strlist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                    "select distinct UserName  from mUser where  OrgName='" + rowData.OrgName + "' and UserName!='' ");


                comboBoxEdit1.Properties.Items.AddRange(strlist);
                

            }

            

            comboBoxEdit3.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='人事档案' and sx like '%{0}%' and nr!=''", "文档类型"));
            if (strlist.Count > 0)
                comboBoxEdit3.Properties.Items.AddRange(strlist);
            else
            {
                strlist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                   "select distinct PostName  from mUser where  OrgName='" + rowData.OrgName + "' and PostName!='' ");

                comboBoxEdit3.Properties.Items.AddRange(strlist);

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
            buttonEdit1.Text = "";
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
           
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Excel文件(*.xls)|*.xls";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                buttonEdit1.Text = openFileDialog1.FileName;
                DSOFramerControl dsoFramerControl1 = new DSOFramerControl();
                Microsoft.Office.Interop.Excel.Workbook wb;
                dsoFramerControl1.FileOpen(buttonEdit1.Text);
                dsoFramerControl1.FileSave();
                rowData.BigData = dsoFramerControl1.FileDataGzip;

                dsoFramerControl1.FileClose() ;
                dsoFramerControl1.Dispose();
                //string[] str_name =  buttonEdit1.Text.Split("\\".ToCharArray());
                //string[] filename = str_name[str_name.Length - 1].Split(".".ToCharArray());
                //byte[] Excbyte = System.Text.Encoding.Default.GetBytes(filename[filename.Length - 1]);
                //string Exc = System.Text.Encoding.Default.GetString(Excbyte);
                //rowData.S1 ="."+ Exc;
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxEdit3.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct PostName  from mUser where  UserName='" + comboBoxEdit1.Text + "' ");
            comboBoxEdit3.Properties.Items.AddRange(mclist);

        }

       
      
    }
}