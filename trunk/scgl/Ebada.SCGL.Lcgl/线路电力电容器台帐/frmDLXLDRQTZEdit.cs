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
            comboBoxEdit3.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='公用属性' and sx like '%{0}%' and nr!=''", "电压等级"));
            comboBoxEdit3.Properties.Items.AddRange(strlist);
            comboBoxEdit4.Properties.Items.Clear();
         //    IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",

              strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='公用属性' and sx like '%{0}%' and nr!=''", "电容器厂家"));
            comboBoxEdit4.Properties.Items.AddRange(strlist);
            comboBoxEdit8.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='公用属性' and sx like '%{0}%' and nr!=''", "投切方式"));
            comboBoxEdit8.Properties.Items.AddRange(strlist);
            comboBoxEdit5.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='公用属性' and sx like '%{0}%' and nr!=''", "电容器型号"));
            if (strlist.Count > 0)
                comboBoxEdit5.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit5.Properties.Items.Add("15GH-F");
                comboBoxEdit5.Properties.Items.Add("BFFR11-100-3W");
            }
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select LineName from ps_xl where orgcode='{0}' and  LineVol='10'", rowData.OrgCode));
            // string.Format("select LineName from ps_xl where orgcode='{0}' and len(linecode)=6", rowData.OrgCode));
            //  where LineVol='10'
            if (strlist.Count > 0)
                comboBoxEdit2.Properties.Items.AddRange(strlist);
            else
            {

            ICollection list = new ArrayList();
            if (comboBoxEdit2.EditValue!=null)
            {
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select gth from PS_gt where   LineCode='{0}' ", comboBoxEdit2.EditValue.ToString()));
                //ICollection list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + comboBoxEdit1.EditValue.ToString() + "'");
                comboBoxEdit6.Properties.Items.AddRange(list);
            }
          
            }
           
            comboBoxEdit10.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='公用属性' and sx like '%{0}%' and nr!=''", "电容器容量"));
            if (strlist.Count > 0)
                comboBoxEdit10.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit10.Properties.Items.Add("100");
                comboBoxEdit10.Properties.Items.Add("120");
                comboBoxEdit10.Properties.Items.Add("150");
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
            SelectorHelper.SelectDyk("公用属性", "备注", memoEdit3);
        }

        private void comboBoxEdit2_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBoxEdit6.Properties.Items.Clear();
            ICollection list = new ArrayList();
            if (comboBoxEdit2.EditValue != null)
            {
                PS_xl pl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>("where linename='" + comboBoxEdit2.EditValue.ToString() + "'");
                if (pl!=null)
                { 
                    list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select right(gth,4) from PS_gt where   LineCode='{0}' ",pl.LineCode));
                //ICollection list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + comboBoxEdit1.EditValue.ToString() + "'");
                comboBoxEdit6.Properties.Items.AddRange(list);
                }
              
            }
        }
       
    }
}