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
    public partial class frmKHDLDRQTZEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_khdldrqtz> m_CityDic = new SortableSearchableBindingList<PJ_khdldrqtz>();

        public frmKHDLDRQTZEdit()
        {
            InitializeComponent();
        }
        void dataBind() {

            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "zhm");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "pdrl");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "sbFactory");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "drqModle");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "hm");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "tyStatus");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "khVol");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "tqfs");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "sbnum");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "sbsumFactory");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");
           

        }
        #region IPopupFormEdit Members
        private PJ_khdldrqtz rowData = null;

        public object RowData {
            get {
               
                return rowData;
              
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_khdldrqtz;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_khdldrqtz>(value as PJ_khdldrqtz, rowData);
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
            comboBoxEdit5.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='客户电力电容器台帐' and sx like '%{0}%' and nr!=''", "电容器型号"));
            if (strlist.Count > 0)
                comboBoxEdit5.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit5.Properties.Items.Add("BSMJ-12-3");
                comboBoxEdit5.Properties.Items.Add("BSMJ-15-3");
                comboBoxEdit5.Properties.Items.Add("BSMJ-14-3");
                comboBoxEdit5.Properties.Items.Add("BSMJ-20-3");
                comboBoxEdit5.Properties.Items.Add("BSMJ-16-3");
                comboBoxEdit5.Properties.Items.Add("DSZK1型");
            }
            //comboBoxEdit10.Properties.Items.Clear();
            //IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            //string.Format("select nr from pj_dyk where  dx='客户电力电容器台帐' and sx like '%{0}%' and nr!=''", "容量"));
            //if (strlist.Count > 0)
            //    comboBoxEdit10.Properties.Items.AddRange(strlist);
            //else
            //{
            //    comboBoxEdit10.Properties.Items.Add("15");
            //    comboBoxEdit10.Properties.Items.Add("50");
            //}
            comboBoxEdit4.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='客户电力电容器台帐' and sx like '%{0}%' and nr!=''", "制造厂"));
            if (strlist.Count > 0)
                comboBoxEdit4.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit4.Properties.Items.Add("正泰");
                comboBoxEdit4.Properties.Items.Add("德力西");
                comboBoxEdit4.Properties.Items.Add("沈阳");
            }
            comboBoxEdit8.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='客户电力电容器台帐' and sx like '%{0}%' and nr!=''", "投切方式"));
            if (strlist.Count > 0)
                comboBoxEdit8.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit8.Properties.Items.Add("手动");
                comboBoxEdit8.Properties.Items.Add("自动");
            }
            comboBoxEdit7.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='客户电力电容器台帐' and sx like '%{0}%' and nr!=''", "投运状况"));
            if (strlist.Count > 0)
                comboBoxEdit7.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit7.Properties.Items.Add("运行");
                comboBoxEdit7.Properties.Items.Add("脱运");
            }
            comboBoxEdit1.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='客户电力电容器台帐' and sx like '%{0}%' and nr!=''", "客户电压等级"));
            if (strlist.Count > 0)
                comboBoxEdit7.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit7.Properties.Items.Add("10KV");
                comboBoxEdit7.Properties.Items.Add("0.38KV");
            }
           
        }

     

      

      
      

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("客户电力电容器台帐", "备注", memoEdit3);
        }

       
    }
}