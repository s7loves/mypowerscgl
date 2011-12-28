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
    public partial class frmJSBPJJHEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_jsbpjjh> m_CityDic = new SortableSearchableBindingList<PJ_jsbpjjh>();

        public frmJSBPJJHEdit()
        {
            InitializeComponent();
        }
        void dataBind() {



            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "gzxm");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "wcsj");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "lsr");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "dbr");

            this.memoEdit1.DataBindings.Add("EditValue", rowData, "lsyq");

            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");

            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_jsbpjjh rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_jsbpjjh;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_jsbpjjh>(value as PJ_jsbpjjh, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
       
            comboBoxEdit1.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='局设备评级计划' and sx like '%{0}%' and nr!=''", "工作项目"));
            if (strlist.Count > 0)
                comboBoxEdit1.Properties.Items.AddRange(strlist);
            else
            {

                comboBoxEdit1.Properties.Items.Add("以供电所为单位组织线路设备巡视");
                comboBoxEdit1.Properties.Items.Add("以供电所为单位汇总发现的各类缺陷");
                comboBoxEdit1.Properties.Items.Add("填报《高压配电设备评级表》《低压线路完好率及台区网络图》");
                comboBoxEdit1.Properties.Items.Add("生产部审批并抽检,对供电所评定情况");
                comboBoxEdit1.Properties.Items.Add("高压配电设备完好率汇总表");
                comboBoxEdit1.Properties.Items.Add("制定设备升级计划");
                comboBoxEdit1.Properties.Items.Add("对设备评级情况进行总结");
              

            }



           comboBoxEdit5.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='局设备评级计划' and sx like '%{0}%' and nr!=''", "督办人"));
            if (strlist.Count > 0)
                comboBoxEdit5.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit5.Properties.Items.Add("尹传玺 窦若穹");
                comboBoxEdit5.Properties.Items.Add("张汉军");

            }



            comboBoxEdit3.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='局设备评级计划' and sx like '%{0}%' and nr!=''", "落实人"));
            if (strlist.Count > 0)
                comboBoxEdit3.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit3.Properties.Items.Add("供电所长 配电班长");
                comboBoxEdit3.Properties.Items.Add("尹传玺 窦若穹");
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
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "Excel文件(*.xls)|*.xls|Word文件(*.doc)|*.doc";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    buttonEdit1.Text = openFileDialog1.FileName;
            //    rowData.BigData = Ecommon.GetImageBate(openFileDialog1.FileName);
            //    string[] str_name =  buttonEdit1.Text.Split("\\".ToCharArray());
            //    string[] filename = str_name[str_name.Length - 1].Split(".".ToCharArray());
            //    byte[] Excbyte = System.Text.Encoding.Default.GetBytes(filename[filename.Length - 1]);
            //    string Exc = System.Text.Encoding.Default.GetString(Excbyte);
            //    rowData.S1 ="."+ Exc;
            //}
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("局设备评级计划", "备注", memoEdit3);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("局设备评级计划", "落实要求", memoEdit3);
        }

      
    }
}