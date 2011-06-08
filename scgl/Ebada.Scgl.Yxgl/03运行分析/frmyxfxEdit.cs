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
    public partial class frmyxfxEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_03yxfx> m_CityDic = new SortableSearchableBindingList<PJ_03yxfx>();

        public frmyxfxEdit() {
            InitializeComponent();
        }
        void dataBind() {


          this.comboBoxEdit16.DataBindings.Add("EditValue", rowData, "zcr");
          this.dateEdit3.DataBindings.Add("EditValue", rowData, "rq");
          this.dateEdit4.DataBindings.Add("EditValue", rowData, "qzrq");
          this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "cjry");
          this.memoEdit5.DataBindings.Add("EditValue", rowData, "zt");
          this.memoEdit1.DataBindings.Add("EditValue", rowData, "jy");
          this.memoEdit2.DataBindings.Add("EditValue", rowData, "jr");
          this.memoEdit4.DataBindings.Add("EditValue", rowData, "py");
          this.comboBoxEdit17.DataBindings.Add("EditValue", rowData, "qz");

        }
        void setqqry()
        {
            string str = rowData.cjry;
            string[] mans = str.Split(new char[1] { ';' }, 15, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < 15; i++)
            {
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue = "";
               // ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 11)]).EditValue = "";
            }
            for (int i = 0; i < mans.Length; i++)
            {
                //string[] ry = mans[i].Split(':');
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue =mans[i];
                //((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 11)]).EditValue = ry[1];
            }
        }
        void getqqry()
        {
            string str = "";
            string ry = "";
            //string yy = "";
            for (int i = 0; i < 15; i++)
            {
                ry = ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue.ToString();
                //yy = ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 11)]).EditValue.ToString();
                if (!string.IsNullOrEmpty(ry.Trim()))
                    str += ry + ";";
            }
            rowData.cjry = str;
        }
        #region IPopupFormEdit Members
        private PJ_03yxfx rowData = null;

        public object RowData {
            get {
                getqqry();
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_03yxfx;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_03yxfx>(value as PJ_03yxfx, rowData);
                }
                setqqry();
            }
        }

        #endregion

        private void InitComboBoxData() {

            //填充下拉列表数据
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表
           // ICollection yyList = ComboBoxHelper.GetQqyy();//获取缺勤原因列表
            for (int i = 0; i < 17; i++)
            {
                if (ryList.Count>0)
                {
                    ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).Properties.Items.AddRange(ryList);
                }
                
                //((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 11)]).Properties.Items.AddRange(yyList);
            }

            //this.cBoxTq.Properties.Items.AddRange(ComboBoxHelper.GetTQ());//设置天气列表
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

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}