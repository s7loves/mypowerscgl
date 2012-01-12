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
    public partial class frmqtzlEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_qtzl> m_CityDic = new SortableSearchableBindingList<PJ_qtzl>();

        public frmqtzlEdit()
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
        private PJ_qtzl rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_qtzl;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_qtzl>(value as PJ_qtzl, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            comboBoxEdit1.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='记录、卡片' and sx like '%{0}%' and nr!=''", "文档名称"));
            if (strlist.Count > 0)
                comboBoxEdit1.Properties.Items.AddRange(strlist);
            else
            {




                comboBoxEdit1.Properties.Items.Add("01工作日志");
                comboBoxEdit1.Properties.Items.Add("02安全活动记录");
                comboBoxEdit1.Properties.Items.Add("03运行分析记录");
                comboBoxEdit1.Properties.Items.Add("04事故、障碍、异常运行记录");
                comboBoxEdit1.Properties.Items.Add("05交叉跨越及对地距离测量记录");
                comboBoxEdit1.Properties.Items.Add("06设备巡视及缺陷消除记录");
                comboBoxEdit1.Properties.Items.Add("07接地装置检测记录");
                comboBoxEdit1.Properties.Items.Add("08设备停电检修记录");
                comboBoxEdit1.Properties.Items.Add("09培训记录");

                comboBoxEdit1.Properties.Items.Add("10配电变压器汇总表");
                comboBoxEdit1.Properties.Items.Add("11配电变压器卡片");
                comboBoxEdit1.Properties.Items.Add("12线路开关卡片");
                comboBoxEdit1.Properties.Items.Add("13剩余电流动作保护器测试记录");
                comboBoxEdit1.Properties.Items.Add("14电力工器具测试记录");
                comboBoxEdit1.Properties.Items.Add("15工具、仪表台张");
                comboBoxEdit1.Properties.Items.Add("16高压配电线路条图");
                comboBoxEdit1.Properties.Items.Add("17高压配电线路条图汇总表");
                comboBoxEdit1.Properties.Items.Add("18高压配电设备评级表");
                comboBoxEdit1.Properties.Items.Add("19高压配电设备完好率汇总表");
                comboBoxEdit1.Properties.Items.Add("20低压线路完好率及台区网络图");
                comboBoxEdit1.Properties.Items.Add("21电力故障报修电话接听记录");
                comboBoxEdit1.Properties.Items.Add("22报修服务修理票");
                comboBoxEdit1.Properties.Items.Add("23配电设备产权产权及维护范围协议书");
                comboBoxEdit1.Properties.Items.Add("24设备变更通知书");
                comboBoxEdit1.Properties.Items.Add("25双电源协议书");
                comboBoxEdit1.Properties.Items.Add("26电力线路防护通知书");

            }

            

            comboBoxEdit3.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='记录、卡片' and sx like '%{0}%' and nr!=''", "文档类型"));
            if (strlist.Count > 0)
                comboBoxEdit3.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit3.Properties.Items.Add("01工作日志");
                comboBoxEdit3.Properties.Items.Add("02安全活动记录");
                comboBoxEdit3.Properties.Items.Add("03运行分析记录");
                comboBoxEdit3.Properties.Items.Add("04事故、障碍、异常运行记录");
                comboBoxEdit3.Properties.Items.Add("05交叉跨越及对地距离测量记录");
                comboBoxEdit3.Properties.Items.Add("06设备巡视及缺陷消除记录");
                comboBoxEdit3.Properties.Items.Add("07接地装置检测记录");
                comboBoxEdit3.Properties.Items.Add("08设备停电检修记录");
                comboBoxEdit3.Properties.Items.Add("09培训记录");

                comboBoxEdit3.Properties.Items.Add("10配电变压器汇总表");
                comboBoxEdit3.Properties.Items.Add("11配电变压器卡片");
                comboBoxEdit3.Properties.Items.Add("12线路开关卡片");
                comboBoxEdit3.Properties.Items.Add("13剩余电流动作保护器测试记录");
                comboBoxEdit3.Properties.Items.Add("14电力工器具测试记录");
                comboBoxEdit3.Properties.Items.Add("15工具、仪表台张");
                comboBoxEdit3.Properties.Items.Add("16高压配电线路条图");
                comboBoxEdit3.Properties.Items.Add("17高压配电线路条图汇总表");
                comboBoxEdit3.Properties.Items.Add("18高压配电设备评级表");
                comboBoxEdit3.Properties.Items.Add("19高压配电设备完好率汇总表");
                comboBoxEdit3.Properties.Items.Add("20低压线路完好率及台区网络图");
                comboBoxEdit3.Properties.Items.Add("21电力故障报修电话接听记录");
                comboBoxEdit3.Properties.Items.Add("22报修服务修理票");
                comboBoxEdit3.Properties.Items.Add("23配电设备产权产权及维护范围协议书");
                comboBoxEdit3.Properties.Items.Add("24设备变更通知书");
                comboBoxEdit3.Properties.Items.Add("25双电源协议书");
                comboBoxEdit3.Properties.Items.Add("26电力线路防护通知书");


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
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Excel文件(*.xls)|*.xls|Word文件(*.doc)|*.doc";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                buttonEdit1.Text = openFileDialog1.FileName;
                rowData.BigData = Ecommon.GetImageBate(openFileDialog1.FileName);
                string[] str_name =  buttonEdit1.Text.Split("\\".ToCharArray());
                string[] filename = str_name[str_name.Length - 1].Split(".".ToCharArray());
                byte[] Excbyte = System.Text.Encoding.Default.GetBytes(filename[filename.Length - 1]);
                string Exc = System.Text.Encoding.Default.GetString(Excbyte);
                rowData.S1 ="."+ Exc;
            }
        }

      
    }
}