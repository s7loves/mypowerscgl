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
    public partial class frmXLSBZRQHFMXBEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_xlsbzrqhfmbb> m_CityDic = new SortableSearchableBindingList<PJ_xlsbzrqhfmbb>();

        public frmXLSBZRQHFMXBEdit()
        {
            InitializeComponent();
        }
        void dataBind() {

            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "jsxl");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "zjxl");

            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "gytq");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "zytq");
            //this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "zrr");
         
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");
           

        }
        #region IPopupFormEdit Members
        private PJ_xlsbzrqhfmbb rowData = null;

        public object RowData {
            get {
               
                return rowData;
              
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_xlsbzrqhfmbb;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_xlsbzrqhfmbb>(value as PJ_xlsbzrqhfmbb, rowData);
                }
            
            }
        }

        #endregion




        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList post)
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

        private void InitComboBoxData() {


            comboBoxEdit1.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='线路设备责任区划分明白表' and sx like '%{0}%' and nr!=''", "局属线路"));
            if (strlist.Count > 0)
                comboBoxEdit1.Properties.Items.AddRange(strlist);
            else
            {
                strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select LineName from PS_xl where  Owner='局属' and LineCode like '{0}%'", rowData.OrgCode));
                comboBoxEdit1.Properties.Items.AddRange(strlist);


            }
            
            comboBoxEdit2.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='线路设备责任区划分明白表' and sx like '%{0}%' and nr!=''", "自建线路"));
            if (strlist.Count > 0)
                comboBoxEdit2.Properties.Items.AddRange(strlist);
            else
            {
                strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select LineName from PS_xl where  Owner!='局属' and LineCode like '{0}%'", rowData.OrgCode));
                comboBoxEdit2.Properties.Items.AddRange(strlist);


            }
            comboBoxEdit3.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='线路设备责任区划分明白表' and sx like '%{0}%' and nr!=''", "公用台区"));
            if (strlist.Count > 0)
                comboBoxEdit3.Properties.Items.AddRange(strlist);
            else
            {
                strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select tqName from PS_tq where  Owner='局属' and tqCode like '{0}%'", rowData.OrgCode));
                comboBoxEdit3.Properties.Items.AddRange(strlist);


            }
            comboBoxEdit4.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='线路设备责任区划分明白表' and sx like '%{0}%' and nr!=''", "专业台区"));
            if (strlist.Count > 0)
                comboBoxEdit4.Properties.Items.AddRange(strlist);
            else
            {
                strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select tqName from PS_tq where  Owner!='局属' and tqCode like '{0}%'", rowData.OrgCode));
                comboBoxEdit4.Properties.Items.AddRange(strlist);


            }

            //comboBoxEdit5.Properties.Items.Clear();
            // strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            //string.Format("select nr from pj_dyk where  dx='线路设备责任区划分明白表' and sx like '%{0}%' and nr!=''", "负责人"));
            //if (strlist.Count > 0)
            //    comboBoxEdit5.Properties.Items.AddRange(strlist);
            //else
            //{
            //    strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            //    string.Format("select UserName from mUser where  OrgCode = '{0}'", rowData.OrgCode));
            //    comboBoxEdit5.Properties.Items.AddRange(strlist);


            //}


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

      

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("线路设备责任区划分明白表", "备注", memoEdit3);
        }

       
    }
}