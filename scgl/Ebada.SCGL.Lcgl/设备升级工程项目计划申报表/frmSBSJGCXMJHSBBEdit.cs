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



            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "wdmc");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "wdlx");
            
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "Remark");

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
            string.Format("select nr from pj_dyk where  dx='规程规则制度条例' and sx like '%{0}%' and nr!=''", "文档名称"));
            if (strlist.Count > 0)
                comboBoxEdit1.Properties.Items.AddRange(strlist);
            else
            {




                comboBoxEdit1.Properties.Items.Add("1电力法");
                comboBoxEdit1.Properties.Items.Add("2安全生产法");
                comboBoxEdit1.Properties.Items.Add("3[2009]664号《国家电网公司电力安全工作规程(线路部分)》2009版");
                comboBoxEdit1.Properties.Items.Add("4电力安全工作规程热力和机械部分");
                comboBoxEdit1.Properties.Items.Add("5国网公司电力安全工作规程（变电站和发电厂电气部分）（试行）");
                comboBoxEdit1.Properties.Items.Add("6国网公司农电事故调查与统计规定2007");
                comboBoxEdit1.Properties.Items.Add("7电力安全工器具预防性试验规程");
                comboBoxEdit1.Properties.Items.Add("8架空绝缘配电线路设计技术规程");
                comboBoxEdit1.Properties.Items.Add("9架空绝缘配电线路施工及验收规范");

                comboBoxEdit1.Properties.Items.Add("10架空配电线路设计技术规程");
                comboBoxEdit1.Properties.Items.Add("11电力设备接地设计技术规程");
                comboBoxEdit1.Properties.Items.Add("12高压配电装置设计技术规程");
                comboBoxEdit1.Properties.Items.Add("13电力设备过电压保护设计技术规程");
                comboBoxEdit1.Properties.Items.Add("14架空配电线路安装检修规程");
                comboBoxEdit1.Properties.Items.Add("15架空电力线路爆炸压接施工工艺规程");
                comboBoxEdit1.Properties.Items.Add("1610KV及以下电力电缆安装与检修工艺规程");
                comboBoxEdit1.Properties.Items.Add("17电气装置安装工程35KV及以下架空电力线路施工及验收规范");
                comboBoxEdit1.Properties.Items.Add("18关于对电力线、通信线、广播电视线交越和搭挂进行整治的通知");
                comboBoxEdit1.Properties.Items.Add("19架空配电线路及设备运行规程");
                comboBoxEdit1.Properties.Items.Add("2010KV及以下电力电缆运行规程");
                comboBoxEdit1.Properties.Items.Add("21电力变压器运行规程");
                comboBoxEdit1.Properties.Items.Add("22电力设备预防性试验规程");
                comboBoxEdit1.Properties.Items.Add("23电力设施保护条例");
                comboBoxEdit1.Properties.Items.Add("24电力设施保护条例实施细则");
                comboBoxEdit1.Properties.Items.Add("25架空电力线路与弱电线路接近和交叉装置规定");
                comboBoxEdit1.Properties.Items.Add("26关于电线与行道树互相妨碍的规定");
                comboBoxEdit1.Properties.Items.Add("27农村低压电气安全工作规程");
                comboBoxEdit1.Properties.Items.Add("28农村低压电力技术规程");
                comboBoxEdit1.Properties.Items.Add("29农村安全用电规程");
                comboBoxEdit1.Properties.Items.Add("30黑龙江省电网调度规范用语");
                comboBoxEdit1.Properties.Items.Add("31剩余电流动保护器农村安装运行规程");
                comboBoxEdit1.Properties.Items.Add("32黑龙江省农电系统两票实施细则");
                comboBoxEdit1.Properties.Items.Add("33供电所规范化管理读本");
                comboBoxEdit1.Properties.Items.Add("34黑龙江省农电系统配电管理制度");

            }

            

            comboBoxEdit3.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='规程规则制度条例' and sx like '%{0}%' and nr!=''", "文档类型"));
            if (strlist.Count > 0)
                comboBoxEdit3.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit3.Properties.Items.Add("国务院颁布");
                comboBoxEdit3.Properties.Items.Add("国务院安委办");
                comboBoxEdit3.Properties.Items.Add("三部颁");
                comboBoxEdit3.Properties.Items.Add("电力部颁");
                comboBoxEdit3.Properties.Items.Add("水电部颁");
                comboBoxEdit3.Properties.Items.Add("电力部94年");
                comboBoxEdit3.Properties.Items.Add("国电公司颁布");
                comboBoxEdit3.Properties.Items.Add("东电颁");
                comboBoxEdit3.Properties.Items.Add("黑龙江省公司");
                comboBoxEdit3.Properties.Items.Add("省电力工业局");
                comboBoxEdit3.Properties.Items.Add("国电农电部");
                comboBoxEdit3.Properties.Items.Add("黑省农电局");

                comboBoxEdit3.Properties.Items.Add("DL|T596-1996");
                comboBoxEdit3.Properties.Items.Add("DL|T601-1996");
                comboBoxEdit3.Properties.Items.Add("DL|T602-1996");
                comboBoxEdit3.Properties.Items.Add("DL|T449-2001");
                comboBoxEdit3.Properties.Items.Add("DL|T736-2000");
                comboBoxEdit3.Properties.Items.Add("DLJ206-1987");
                comboBoxEdit3.Properties.Items.Add("GB50173-92");
                comboBoxEdit3.Properties.Items.Add("SD292-88");
                comboBoxEdit3.Properties.Items.Add("DL447-2001");
                comboBoxEdit3.Properties.Items.Add("DL493-2001");
                comboBoxEdit3.Properties.Items.Add("DL572-95");

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

      
    }
}