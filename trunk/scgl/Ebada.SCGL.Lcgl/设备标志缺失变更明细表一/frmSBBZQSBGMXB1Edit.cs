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
    public partial class frmSBBZQSBGMXB1Edit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_sbbzqsbgmxb1> m_CityDic = new SortableSearchableBindingList<PJ_sbbzqsbgmxb1>();

        public frmSBBZQSBGMXB1Edit()
        {
            InitializeComponent();
        }
        void dataBind() {

            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "sssbmc");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "sssswz");
            //this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "sssbbh");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "statuts");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");
           

        }
        #region IPopupFormEdit Members
        private PJ_sbbzqsbgmxb1 rowData = null;

        public object RowData {
            get {
               
                return rowData;
              
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_sbbzqsbgmxb1;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_sbbzqsbgmxb1>(value as PJ_sbbzqsbgmxb1, rowData);
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
       
            comboBoxEdit1.Properties.Items.Clear();
            comboBoxEdit1.Properties.Items.Add("杆号牌");

            comboBoxEdit1.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='设备标志缺失变更明细表一' and sx like '%{0}%' and nr!=''", "所属设备名称"));
            if (strlist.Count > 0)
                comboBoxEdit1.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit1.Properties.Items.Add("配电线路杆塔");
                comboBoxEdit1.Properties.Items.Add("开关");
                comboBoxEdit1.Properties.Items.Add("相序牌");
                comboBoxEdit1.Properties.Items.Add("电缆走向桩");
                comboBoxEdit1.Properties.Items.Add("变台、变电亭、箱式变"); 
            }

            comboBoxEdit2.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='设备标志缺失变更明细表一' and sx like '%{0}%' and nr!=''", "所属设备位置"));
            if (strlist.Count > 0)
                comboBoxEdit2.Properties.Items.AddRange(strlist);
            else
            {
         //       comboBoxEdit2.Properties.Items.Add("10KV双西线");
                comboBoxEdit2.Properties.Items.Clear();
                IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select LineName from PS_xl where OrgCode ='" + rowData.OrgCode + "' and linevol='10'");
                comboBoxEdit2.Properties.Items.AddRange(list);
            }

            comboBoxEdit3.Properties.Items.Clear();
            // strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            //string.Format("select nr from pj_dyk where  dx='设备标志缺失变更明细表一' and sx like '%{0}%' and nr!=''", "所属设备编号"));
            //if (strlist.Count > 0)
            //    comboBoxEdit3.Properties.Items.AddRange(strlist);
            //else
            //{
            //    comboBoxEdit3.Properties.Items.Add("5#杆");
            //    comboBoxEdit3.Properties.Items.Add("13#杆");

            //}  
            for (int i = 0; i < 50; i++)
            {
                comboBoxEdit3.Properties.Items.Add(i + "#杆");
            }


         
          
           

            comboBoxEdit4.Properties.Items.Clear();
            string.Format("select nr from pj_dyk where  dx='设备标志缺失变更明细表一' and sx like '%{0}%' and nr!=''", "状态");
            if (strlist.Count > 0)
                comboBoxEdit4.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit4.Properties.Items.Add("缺失");
                comboBoxEdit4.Properties.Items.Add("变更");
                comboBoxEdit4.Properties.Items.Add("新增");

            }
        }

        private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text != string.Empty)
            {
                addresschange(comboBoxEdit1.Text);
            }
        }
        private void comboBoxEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit2.Text != string.Empty)
            {
                codechange(comboBoxEdit2.Text);
            }
        }


        private void addresschange(string name)
        {
            switch (name)
            {
                case "配电线路杆塔":
                case "开关":
                    comboBoxEdit2.Properties.Items.Clear();
                    ICollection list1 = ComboBoxHelper.GetGdsxl(rowData.OrgCode);
                    comboBoxEdit2.Properties.Items.AddRange(list1);
                    break;
                case "相序牌":
                    comboBoxEdit2.Properties.Items.Clear();
                     list1 = ComboBoxHelper.GetGdsxl(rowData.OrgCode);
                    comboBoxEdit2.Properties.Items.AddRange(list1);
                    ICollection list2 = ComboBoxHelper.Getbtq(rowData.OrgCode);
                    comboBoxEdit2.Properties.Items.AddRange(list2);
                    break;
                case "电缆走向桩":
                    comboBoxEdit2.Properties.Items.Clear();
                    list1 = ComboBoxHelper.GetGdsxl(rowData.OrgCode);
                    comboBoxEdit2.Properties.Items.AddRange(list1);
                    break;
                case "变台、变电亭、箱式变":
                    comboBoxEdit2.Properties.Items.Clear();
                    IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select OrgName from ViewGds "));
                    comboBoxEdit2.Properties.Items.AddRange(strlist);
                    break;
                default:
                    break;
            }
        }

        private void codechange(string addstr)
        {
            string namestr=comboBoxEdit1.Text;
            if (namestr != string.Empty)
            {
                switch (namestr)
                {
                    case "配电线路杆塔":
                        comboBoxEdit3.Properties.Items.Clear();
                        string sqlwhere = "select b.gtCode from dbo.PS_gt b ,dbo.PS_xl c where   b.LineCode=c.LineCode and c.LineName='" + addstr + "'";
                        IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sqlwhere);
                        comboBoxEdit3.Properties.Items.AddRange(strlist);
                        break;
                    case "开关":
                        comboBoxEdit3.Properties.Items.Clear();
                        strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select LineName from PS_xl  where OrgCode='{0}' and  len(linecode)=6 ",rowData.OrgCode));
                        comboBoxEdit3.Properties.Items.AddRange(strlist);
                        break;
                    case "相序牌":
                        comboBoxEdit3.Properties.Items.Clear();
                        comboBoxEdit3.Properties.Items.Add("A相*个");
                        comboBoxEdit3.Properties.Items.Add("B相*个");
                        comboBoxEdit3.Properties.Items.Add("C相*个");
                        comboBoxEdit3.Properties.Items.Add("*手工录入");
                        break;
                    case "电缆走向桩":
                        comboBoxEdit3.Properties.Items.Clear();
                      
                        break;
                    case "变台、变电亭、箱式变":
                        comboBoxEdit3.Properties.Items.Clear();
                        for (int i = 1; i < 301; i++)
                        {
                             comboBoxEdit3.Properties.Items.Add(i+"号");
                        }
                        break;
                    default:
                        break;

                }
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
            SelectorHelper.SelectDyk("设备标志缺失变更明细表一", "备注", memoEdit3);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBoxEdit3.Properties.Items.Clear();
            //ICollection list = new ArrayList();
            //PS_xl xl = null;
            //xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where linename='" + comboBoxEdit2.Text + "'");
            //if (xl != null)
            //{
            //    list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select gth from PS_gt where   lineCode='{0}' ", xl.LineCode));
            //    //ICollection list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + comboBoxEdit1.EditValue.ToString() + "'");
            //    comboBoxEdit3.Properties.Items.AddRange(list);
            //}
           

        }

       
      

       

      

       
    }
}