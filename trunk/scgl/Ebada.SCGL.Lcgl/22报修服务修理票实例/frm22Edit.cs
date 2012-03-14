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
    public partial class frm22Edit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_22> m_CityDic = new SortableSearchableBindingList<PJ_22>();

        public frm22Edit() {
            InitializeComponent();
        }
        void dataBind() {


            //this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "OrgName");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "ph");
            this.dateEdit5.DataBindings.Add("EditValue", rowData, "bxsj");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "bxdd");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "xlfzr");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "xlry");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "zbslr");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "bggzqc");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "bgfs");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "bxrxm");
            this.textEdit1.DataBindings.Add("EditValue", rowData, "lxdh");
            this.comboBoxEdit12.DataBindings.Add("EditValue", rowData, "sjgzqc");
            this.comboBoxEdit13.DataBindings.Add("EditValue", rowData, "sycl");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "dsj");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "wsj");
            this.comboBoxEdit14.DataBindings.Add("EditValue", rowData, "jhry");
            this.comboBoxEdit15.DataBindings.Add("EditValue", rowData, "czry");
            this.comboBoxEdit16.DataBindings.Add("EditValue", rowData, "yhqm");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "tdsj");
            this.dateEdit4.DataBindings.Add("EditValue", rowData, "sdsj");
            this.comboBoxEdit17.DataBindings.Add("EditValue", rowData, "tdxl");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "tdxlgt");
            this.comboBoxEdit19.DataBindings.Add("EditValue", rowData, "ddsb");
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "wxd",false,DataSourceUpdateMode.OnPropertyChanged);
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "cljg", false, DataSourceUpdateMode.OnPropertyChanged);
            this.memoEdit4.DataBindings.Add("EditValue", rowData, "Remark");

            this.checkEdit1.DataBindings.Add("EditValue", rowData, "tdcz1xz");
            this.checkEdit2.DataBindings.Add("EditValue", rowData, "tdcz1cz");
            this.checkEdit3.DataBindings.Add("EditValue", rowData, "tdcz2xz");
            this.checkEdit4.DataBindings.Add("EditValue", rowData, "tdcz2cz");
            this.checkEdit5.DataBindings.Add("EditValue", rowData, "tdcz3xz");
            this.checkEdit6.DataBindings.Add("EditValue", rowData, "tdcz3cz");
            this.checkEdit7.DataBindings.Add("EditValue", rowData, "tdcz4xz");
            this.checkEdit8.DataBindings.Add("EditValue", rowData, "tdcz4cz");
            this.checkEdit9.DataBindings.Add("EditValue", rowData, "tdcz5xz");
            this.checkEdit10.DataBindings.Add("EditValue", rowData, "tdcz5cz");
            this.checkEdit11.DataBindings.Add("EditValue", rowData, "tdcz6xz");
            this.checkEdit12.DataBindings.Add("EditValue", rowData, "tdcz6cz");
            this.checkEdit13.DataBindings.Add("EditValue", rowData, "tdcz7xz");
            this.checkEdit14.DataBindings.Add("EditValue", rowData, "tdcz7cz");
            this.checkEdit15.DataBindings.Add("EditValue", rowData, "tdcz8xz");
            this.checkEdit16.DataBindings.Add("EditValue", rowData, "tdcz8cz");
            this.textEdit2.DataBindings.Add("EditValue", rowData, "tdczjxname1");
            this.textEdit3.DataBindings.Add("EditValue", rowData, "tdczjxname2");
            this.textEdit4.DataBindings.Add("EditValue", rowData, "tdczjxname3");

            this.checkEdit17.DataBindings.Add("EditValue", rowData, "sdcz1xz");
            this.checkEdit18.DataBindings.Add("EditValue", rowData, "sdcz1cz");
            this.checkEdit19.DataBindings.Add("EditValue", rowData, "sdcz2xz");
            this.checkEdit20.DataBindings.Add("EditValue", rowData, "sdcz2cz");
            this.checkEdit21.DataBindings.Add("EditValue", rowData, "sdcz3xz");
            this.checkEdit22.DataBindings.Add("EditValue", rowData, "sdcz3cz");
            this.checkEdit23.DataBindings.Add("EditValue", rowData, "sdcz4xz");
            this.checkEdit24.DataBindings.Add("EditValue", rowData, "sdcz4cz");
            this.checkEdit25.DataBindings.Add("EditValue", rowData, "sdcz5xz");
            this.checkEdit26.DataBindings.Add("EditValue", rowData, "sdcz5cz");
            this.checkEdit27.DataBindings.Add("EditValue", rowData, "sdcz6xz");
            this.checkEdit28.DataBindings.Add("EditValue", rowData, "sdcz6cz");
            this.checkEdit29.DataBindings.Add("EditValue", rowData, "sdcz7xz");
            this.checkEdit30.DataBindings.Add("EditValue", rowData, "sdcz7cz");
            this.checkEdit31.DataBindings.Add("EditValue", rowData, "sdcz8xz");
            this.checkEdit32.DataBindings.Add("EditValue", rowData, "sdcz8cz");
            this.textEdit5.DataBindings.Add("EditValue", rowData, "sdczjxname1");
            this.textEdit6.DataBindings.Add("EditValue", rowData, "sdczjxname2");
        }
        #region IPopupFormEdit Members
        private PJ_22 rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_22;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_22>(value as PJ_22, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<PJ_22>(" WHERE Citylevel = '2'"));
          /*  IList<DicType> list = new List<DicType>();
            list.Add(new DicType("0", "机构"));
            list.Add(new DicType("1", "供电所"));
            list.Add(new DicType("2", "变电所"));
            this.SetComboBoxData(this.lookUpEdit1, "Value", "Key", "请选择", "种类", list);*/

            //if (null != cityCode && cityCode.Trim().Length > 0)
            //    this.cltCity.Properties.KeyValue = cityCode;
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表
            if (ryList.Count > 0)
            {
                this.comboBoxEdit5.Properties.Items.AddRange(ryList);
                this.comboBoxEdit6.Properties.Items.AddRange(ryList);
                this.comboBoxEdit7.Properties.Items.AddRange(ryList);
                this.comboBoxEdit10.Properties.Items.AddRange(ryList);
                this.comboBoxEdit14.Properties.Items.AddRange(ryList);
                this.comboBoxEdit15.Properties.Items.AddRange(ryList);

            }
            ComboBoxHelper.FillCBoxByDyk("22报修服务修理票实例", "报告故障情况", comboBoxEdit8.Properties);
            ComboBoxHelper.FillCBoxByDyk("22报修服务修理票实例", "所有材料", comboBoxEdit13.Properties);
            ComboBoxHelper.FillCBoxByDyk("22报修服务修理票实例", "停电线路名称及杆号：", comboBoxEdit17.Properties);
            ComboBoxHelper.FillCBoxByDyk("22报修服务修理票实例", "实际故障情况", comboBoxEdit12.Properties);
            
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

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("22报修服务修理票实例", "危险点及安全措施：", memoEdit2);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("22报修服务修理票实例", "故障处理经过和结果：", memoEdit3);
        }
    }
}