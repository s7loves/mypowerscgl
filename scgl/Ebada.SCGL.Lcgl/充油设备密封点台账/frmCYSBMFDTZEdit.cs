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
    public partial class frmCYSBMFDTZEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_cysbmfdtz> m_CityDic = new SortableSearchableBindingList<PJ_cysbmfdtz>();

        public frmCYSBMFDTZEdit()
        {
            InitializeComponent();
        }
        void dataBind() {

            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "sbmc");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "cysbmc");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "mfStatus");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "cysbFactory");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "InstallPlace");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "jcr");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "sbCapcity");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "sbModle");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "changeDate");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "inDate");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "jcDate");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");
           

        }
        #region IPopupFormEdit Members
        private PJ_cysbmfdtz rowData = null;

        public object RowData {
            get {
               
                return rowData;
              
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_cysbmfdtz;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_cysbmfdtz>(value as PJ_cysbmfdtz, rowData);
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
           
            //填充下拉列表数据
           
            dateEdit1.DateTime = DateTime.Now;
            dateEdit2.DateTime = DateTime.Now;
            dateEdit3.DateTime = DateTime.Now;

            comboBoxEdit2.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='充油设备密封点台帐' and sx like '%{0}%' and nr!=''", "设备名称"));
            if (strlist.Count > 0)
                comboBoxEdit2.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit2.Properties.Items.Add("变压器");
                comboBoxEdit2.Properties.Items.Add("多油断路器");
                comboBoxEdit2.Properties.Items.Add("电容器");
            }

            comboBoxEdit6.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='充油设备密封点台帐' and sx like '%{0}%' and nr!=''", "充油部件名称"));
            if (strlist.Count > 0)
                comboBoxEdit3.Properties.Items.AddRange(strlist);
            else
            {
                            comboBoxEdit3.Properties.Items.Add("注油阀");
                            comboBoxEdit3.Properties.Items.Add("油表管");
                            comboBoxEdit3.Properties.Items.Add("油箱盖");
                            comboBoxEdit2.Properties.Items.Add("吸湿器");
                            comboBoxEdit3.Properties.Items.Add("a相高压套管");
                            comboBoxEdit3.Properties.Items.Add("c相高压套管");
                            comboBoxEdit3.Properties.Items.Add("a相低压套管");
                            comboBoxEdit3.Properties.Items.Add("b相低压套管");
                            comboBoxEdit3.Properties.Items.Add("c相低压套管");
                            comboBoxEdit3.Properties.Items.Add("零线低压套管");
                            comboBoxEdit3.Properties.Items.Add("调档位");
                            comboBoxEdit3.Properties.Items.Add("油箱口");
                            comboBoxEdit3.Properties.Items.Add("放油阀");
                            comboBoxEdit3.Properties.Items.Add("防爆管");
                            comboBoxEdit3.Properties.Items.Add("耐油橡胶垫");

            }

            comboBoxEdit4.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='充油设备密封点台帐' and sx like '%{0}%' and nr!=''", "密封点状况"));
            if (strlist.Count > 0)
                comboBoxEdit6.Properties.Items.AddRange(strlist);
            else
            {
                        comboBoxEdit4.Properties.Items.Add("完好");	
                        comboBoxEdit4.Properties.Items.Add("老化");	
                        comboBoxEdit4.Properties.Items.Add("渗油");
                        comboBoxEdit4.Properties.Items.Add("漏油");	

            }

            comboBoxEdit7.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='充油设备密封点台帐' and sx like '%{0}%' and nr!=''", "检查人"));
            if (strlist.Count > 0)
                comboBoxEdit7.Properties.Items.AddRange(strlist);
            else
            {
                
            }

            comboBoxEdit5.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='充油设备密封点台帐' and sx like '%{0}%' and nr!=''", "制造厂"));
            if (strlist.Count > 0)
                comboBoxEdit5.Properties.Items.AddRange(strlist);
            else
            {
                
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

       
      

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("所月度停电计划", "备注", memoEdit3);
        }

      

       

      

       
    }
}