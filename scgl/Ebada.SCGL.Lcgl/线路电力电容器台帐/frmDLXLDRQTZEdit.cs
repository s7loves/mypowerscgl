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
    public partial class frmDLXLDRQTZEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_dlxldrqtz> m_CityDic = new SortableSearchableBindingList<PJ_dlxldrqtz>();

        public frmDLXLDRQTZEdit()
        {
            InitializeComponent();
        }
        void dataBind() {

            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "lineName");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "gtNumber");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "edVol");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "drqModle");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "sbFactory");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "sbnum");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "Capcity");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "tqfs");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "inDate");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");
           
           
           

        }
        #region IPopupFormEdit Members
        private PJ_dlxldrqtz rowData = null;

        public object RowData {
            get {
               
                return rowData;
              
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_dlxldrqtz;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_dlxldrqtz>(value as PJ_dlxldrqtz, rowData);
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
            string.Format("select nr from pj_dyk where  dx='线路电力电容器台帐' and sx like '%{0}%' and nr!=''", "电容器型号"));
            if (strlist.Count > 0)
                comboBoxEdit5.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit5.Properties.Items.Add("15GH-F");
                comboBoxEdit5.Properties.Items.Add("BFFR11-100-3W");
            }
            comboBoxEdit10.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='线路电力电容器台帐' and sx like '%{0}%' and nr!=''", "容量"));
            if (strlist.Count > 0)
                comboBoxEdit10.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit10.Properties.Items.Add("100");
                comboBoxEdit10.Properties.Items.Add("120");
                comboBoxEdit10.Properties.Items.Add("150");
            }
            comboBoxEdit4.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='线路电力电容器台帐' and sx like '%{0}%' and nr!=''", "制造厂"));
            if (strlist.Count > 0)
                comboBoxEdit4.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit4.Properties.Items.Add("闽东电机厂");
                comboBoxEdit4.Properties.Items.Add("指月集团有限公司");
            }
            comboBoxEdit8.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='线路电力电容器台帐' and sx like '%{0}%' and nr!=''", "投切方式"));
            if (strlist.Count > 0)
                comboBoxEdit8.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit8.Properties.Items.Add("手动");
                comboBoxEdit8.Properties.Items.Add("自动");
            }
            comboBoxEdit2.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='线路电力电容器台帐' and sx like '%{0}%' and nr!=''", "线路名称"));
            if (strlist.Count > 0)
                comboBoxEdit2.Properties.Items.AddRange(strlist);
            else
            {
                
                    comboBoxEdit2.Properties.Items.Add("长南线");
                    comboBoxEdit2.Properties.Items.Add("长西线");
                    comboBoxEdit2.Properties.Items.Add("长北线");
                    comboBoxEdit2.Properties.Items.Add("长东线");
                    comboBoxEdit2.Properties.Items.Add("红南线");
                    comboBoxEdit2.Properties.Items.Add("红东线");
                    comboBoxEdit2.Properties.Items.Add("津东线");
                    comboBoxEdit2.Properties.Items.Add("津内线");
                    comboBoxEdit2.Properties.Items.Add("津北线");
                    comboBoxEdit2.Properties.Items.Add("连内线");
                    comboBoxEdit2.Properties.Items.Add("连东线");
                    comboBoxEdit2.Properties.Items.Add("连西线");
                    comboBoxEdit2.Properties.Items.Add("镇内线");
                    comboBoxEdit2.Properties.Items.Add("富力线");
                    comboBoxEdit2.Properties.Items.Add("铁东线");
                    comboBoxEdit2.Properties.Items.Add("铁西线");
                    comboBoxEdit2.Properties.Items.Add("镇西线");
                    comboBoxEdit2.Properties.Items.Add("镇东线");
                    comboBoxEdit2.Properties.Items.Add("镇北线");
                    comboBoxEdit2.Properties.Items.Add("台内线");
                    comboBoxEdit2.Properties.Items.Add("台西线");
                    comboBoxEdit2.Properties.Items.Add("台东线");
                    comboBoxEdit2.Properties.Items.Add("台民线");
                    comboBoxEdit2.Properties.Items.Add("平东线");
                    comboBoxEdit2.Properties.Items.Add("平西线");
                    comboBoxEdit2.Properties.Items.Add("平南线");
                    comboBoxEdit2.Properties.Items.Add("平北线");
                    comboBoxEdit2.Properties.Items.Add("营东线");
                    comboBoxEdit2.Properties.Items.Add("营南线");
                    comboBoxEdit2.Properties.Items.Add("营西线");
                    comboBoxEdit2.Properties.Items.Add("华东线");
                    comboBoxEdit2.Properties.Items.Add("华西线");
                    comboBoxEdit2.Properties.Items.Add("华南线");
                    comboBoxEdit2.Properties.Items.Add("华北线");
                    comboBoxEdit2.Properties.Items.Add("团结线");
                    comboBoxEdit2.Properties.Items.Add("粮库线");
                    comboBoxEdit2.Properties.Items.Add("三井线");
                    comboBoxEdit2.Properties.Items.Add("联合线");
                    comboBoxEdit2.Properties.Items.Add("新生线");
                    comboBoxEdit2.Properties.Items.Add("民吉线");
                    comboBoxEdit2.Properties.Items.Add("中心线");
                    comboBoxEdit2.Properties.Items.Add("源林线");
                    comboBoxEdit2.Properties.Items.Add("污水线");
                    comboBoxEdit2.Properties.Items.Add("双东线");
                    comboBoxEdit2.Properties.Items.Add("双南线");
                    comboBoxEdit2.Properties.Items.Add("双西线");
                    comboBoxEdit2.Properties.Items.Add("双北线");
                    comboBoxEdit2.Properties.Items.Add("宝山线");
                    comboBoxEdit2.Properties.Items.Add("光大线");
                    comboBoxEdit2.Properties.Items.Add("郊西线");
                    comboBoxEdit2.Properties.Items.Add("先锋线");
                    comboBoxEdit2.Properties.Items.Add("郊东线");
                    comboBoxEdit2.Properties.Items.Add("郊北线");
                    comboBoxEdit2.Properties.Items.Add("农东线");
                    comboBoxEdit2.Properties.Items.Add("铁水线");
                    comboBoxEdit2.Properties.Items.Add("东园线");
                    comboBoxEdit2.Properties.Items.Add("永太线");
                    comboBoxEdit2.Properties.Items.Add("永胜线");
                    comboBoxEdit2.Properties.Items.Add("永农线");
                    comboBoxEdit2.Properties.Items.Add("永镇线");
                    comboBoxEdit2.Properties.Items.Add("利民线");
                    comboBoxEdit2.Properties.Items.Add("利北线");
                    comboBoxEdit2.Properties.Items.Add("民东线");
                    comboBoxEdit2.Properties.Items.Add("龙太线");
                    comboBoxEdit2.Properties.Items.Add("东津线");
                    comboBoxEdit2.Properties.Items.Add("提水线");
            }
            dateEdit1.DateTime = DateTime.Now;
           
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
            SelectorHelper.SelectDyk("线路电力电容器台帐", "备注", memoEdit3);
        }

       
    }
}