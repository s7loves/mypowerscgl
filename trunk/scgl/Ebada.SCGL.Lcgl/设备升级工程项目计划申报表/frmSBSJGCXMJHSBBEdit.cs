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
    public partial class frmSBSJGCXMJHSBBEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_sbsjgcxmjhsbb> m_CityDic = new SortableSearchableBindingList<PJ_sbsjgcxmjhsbb>();

        public frmSBSJGCXMJHSBBEdit()
        {
            InitializeComponent();
        }
        void dataBind() {



            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "xsjmc");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "gcmc");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "zybr");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "dgzj");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "qtzj");
            this.spinEdit3.DataBindings.Add("EditValue", rowData, "sxzjsum");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "wcsj");

            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");

            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_sbsjgcxmjhsbb rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_sbsjgcxmjhsbb;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_sbsjgcxmjhsbb>(value as PJ_sbsjgcxmjhsbb, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            comboBoxEdit1.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='设备升级工程项目计划申报表' and sx like '%{0}%' and nr!=''", "县（市）局"));
            if (strlist.Count > 0)
                comboBoxEdit1.Properties.Items.AddRange(strlist);
            else
            {

                comboBoxEdit1.Properties.Items.Add("绥化农电局");
              

            }



            comboBoxEdit5.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='设备升级工程项目计划申报表' and sx like '%{0}%' and nr!=''", "工程项目名称"));
            if (strlist.Count > 0)
                comboBoxEdit5.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit5.Properties.Items.Add("变电所试验、整定");
                comboBoxEdit5.Properties.Items.Add("春检");
                comboBoxEdit5.Properties.Items.Add("调度所办公用品");
                comboBoxEdit5.Properties.Items.Add("变电所低值易耗品");
                comboBoxEdit5.Properties.Items.Add("新华等3所办公用品、生产用具等");
                comboBoxEdit5.Properties.Items.Add("工区检修工具购置");
                comboBoxEdit5.Properties.Items.Add("线路及变电所备品备件");
                comboBoxEdit5.Properties.Items.Add("标示牌");
                comboBoxEdit5.Properties.Items.Add("秋检");
                comboBoxEdit5.Properties.Items.Add("建设供电所");
                comboBoxEdit5.Properties.Items.Add("变电安全运行奖");
                comboBoxEdit5.Properties.Items.Add("空气开关更换");
                comboBoxEdit5.Properties.Items.Add("变压器检修及油");
                comboBoxEdit5.Properties.Items.Add("供电所线路维修");

            }



            comboBoxEdit3.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='设备升级工程项目计划申报表' and sx like '%{0}%' and nr!=''", "主要内容及措施"));
            if (strlist.Count > 0)
                comboBoxEdit3.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit3.Properties.Items.Add("变电所试验、整定");
                comboBoxEdit3.Properties.Items.Add("春检");
                comboBoxEdit3.Properties.Items.Add("调度所办公用品");
                comboBoxEdit3.Properties.Items.Add("变电所低值易耗品");
                comboBoxEdit3.Properties.Items.Add("新华等3所办公用品、生产用具等");
                comboBoxEdit3.Properties.Items.Add("工区检修工具购置");
                comboBoxEdit3.Properties.Items.Add("10kv真空开关");
                comboBoxEdit3.Properties.Items.Add("电流互感器");
                comboBoxEdit3.Properties.Items.Add("三河、长发主控屏");
                comboBoxEdit3.Properties.Items.Add("66kv高压熔断器1组");
                comboBoxEdit3.Properties.Items.Add("四方台10kv刀闸支持绝缘子");
                comboBoxEdit3.Properties.Items.Add("标示牌");
                comboBoxEdit3.Properties.Items.Add("秋检");
                comboBoxEdit3.Properties.Items.Add("建设供电所");
                comboBoxEdit3.Properties.Items.Add("变电安全运行奖");
                comboBoxEdit3.Properties.Items.Add("空气开关更换");
                comboBoxEdit3.Properties.Items.Add("变压器检修及油");
                comboBoxEdit3.Properties.Items.Add("供电所线路维修");

            }


            comboBoxEdit4.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='设备升级工程项目计划申报表' and sx like '%{0}%' and nr!=''", "完成时间"));
            if (strlist.Count > 0)
                comboBoxEdit4.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit4.Properties.Items.Add("1月");
                comboBoxEdit4.Properties.Items.Add("2月");
                comboBoxEdit4.Properties.Items.Add("3月");
                comboBoxEdit4.Properties.Items.Add("4月");
                comboBoxEdit4.Properties.Items.Add("5月");
                comboBoxEdit4.Properties.Items.Add("6月");
                comboBoxEdit4.Properties.Items.Add("7月");
                comboBoxEdit4.Properties.Items.Add("8月");
                comboBoxEdit4.Properties.Items.Add("9月");
                comboBoxEdit4.Properties.Items.Add("10月");
                comboBoxEdit4.Properties.Items.Add("11月");
                comboBoxEdit4.Properties.Items.Add("12月");
                comboBoxEdit4.Properties.Items.Add("秋检");
                comboBoxEdit4.Properties.Items.Add("建设供电所");
                comboBoxEdit4.Properties.Items.Add("变电安全运行奖");
                comboBoxEdit4.Properties.Items.Add("空气开关更换");
                comboBoxEdit4.Properties.Items.Add("变压器检修及油");
                comboBoxEdit4.Properties.Items.Add("供电所线路维修");

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
            SelectorHelper.SelectDyk("设备升级工程项目计划申报表", "备注", memoEdit3);
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            spinEdit2_EditValueChanged(sender,e);
        }

        private void spinEdit2_EditValueChanged(object sender, EventArgs e)
        {
            spinEdit3.Value = spinEdit1.Value + spinEdit2.Value;
        }

      
    }
}