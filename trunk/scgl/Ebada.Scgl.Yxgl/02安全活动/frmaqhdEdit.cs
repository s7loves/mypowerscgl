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
namespace Ebada.Scgl.Yxgl
{
    public partial class frmaqhdEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_02aqhd> m_CityDic = new SortableSearchableBindingList<PJ_02aqhd>();

        public frmaqhdEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "zcr");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "kssj");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "jssj");
            //this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "cjry");
            //this.comboBoxEdit28.DataBindings.Add("EditValue", rowData, "qxry");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "hdnr");
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "hdxj");
            this.memoEdit4.DataBindings.Add("EditValue", rowData, "py");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "qz");
            this.dateEdit4.DataBindings.Add("EditValue", rowData, "qzrq");

        }
        #region IPopupFormEdit Members
        private PJ_02aqhd rowData = null;

        public object RowData {
            get {
                getqqry();
                getcqry();
                return rowData;
              
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_02aqhd;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_02aqhd>(value as PJ_02aqhd, rowData);
                }
                setqqry();
                setcqry();
            }
        }

        #endregion
        void setqqry()
        {
            string str = rowData.qxry;
            string[] mans = str.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 28; i <= 32; i++)
            {
                ((ComboBoxEdit)groupBox6.Controls["comboBoxEdit" + i]).EditValue = "";
               
            }
            for (int i = 0; i < mans.Length; i++)
            {
               
                ((ComboBoxEdit)groupBox6.Controls["comboBoxEdit" + (i+28)]).EditValue = mans[i];
               
            }
        }
        void getqqry()
        {
            string str = "";
            string yy = "";
            for (int i = 28; i <=32; i++)
            {
               
                yy = ((ComboBoxEdit)groupBox6.Controls["comboBoxEdit" + i]).EditValue.ToString();
                if (!string.IsNullOrEmpty(yy.Trim()))
                    str +=  yy + ";";
            }
            rowData.qxry = str;
        }
        void setcqry()
        {
            string str = rowData.cjry;
            string[] mans = str.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 2; i <= 27; i++)
            {
                if (i != 6)
                {
                    ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + i]).EditValue = "";
                }
              

            }
            int m=0;
            for (int i = 0; i < mans.Length; i++)
            {
                if (i>=4)
                {
                    m = i + 2;
                }
                else
                {
                    m = i + 1;
                }
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (m+1)]).EditValue = mans[i];

            }
        }
        void getcqry()
        {
            string str = "";
            string yy = "";
            for (int i = 2; i <= 27; i++)
            {
                if (i!=6)
                {
                    yy = ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + i]).EditValue.ToString();
                    if (!string.IsNullOrEmpty(yy.Trim()))
                        str += yy + ";";
                }
             
            }
            rowData.cjry = str;
        }


        private void InitComboBoxData() {
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表
            
            for (int i = 1; i < 27; i++)
            {
                if (i!=5)
                {
                    ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).Properties.Items.AddRange(ryList);

                }
  
            }
            for (int i = 27; i <32; i++)
            {
              
                ((ComboBoxEdit)groupBox6.Controls["comboBoxEdit" + (i + 1)]).Properties.Items.AddRange(ryList);

            }
            ((ComboBoxEdit)groupBox1.Controls["comboBoxEdit" +  1]).Properties.Items.AddRange(ryList);
            ((ComboBoxEdit)groupBox1.Controls["comboBoxEdit" + 6]).Properties.Items.AddRange(ryList);

            //填充下拉列表数据
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("02安全活动记录簿", "安全活动内容", memoEdit1,memoEdit2);
        }
    }
}