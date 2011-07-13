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
    public partial class frmjckyjlEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_05jckyjl> m_CityDic = new SortableSearchableBindingList<PJ_05jckyjl>();

        public frmjckyjlEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.dateEdit1.DataBindings.Add("EditValue", rowData, "clrq");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "scz");
            this.textEdit1.DataBindings.Add("EditValue", rowData, "qw");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "clrqz");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "jr");

        }
        #region IPopupFormEdit Members
        private PJ_05jckyjl rowData = null;

        public object RowData {
            get {
                getqqry();
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_05jckyjl;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_05jckyjl>(value as PJ_05jckyjl, rowData);
                }
                setqqry();
                if (rowData.jr == "")
                {
                    rowData.clrq = DateTime.Now;
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            ComboBoxHelper.FillCBoxByDyk("05交叉跨越及对地距离测量记录", "结论", comboBoxEdit2);

            PJ_05jcky pj= Client.ClientHelper.PlatformSqlMap.GetOneByKey<PJ_05jcky>(rowData.jckyID);
            this.comboBoxEdit1.Properties.Items.AddRange(ComboBoxHelper.GetGdsRy(pj.OrgCode));
            this.comboBoxEdit3.Properties.Items.AddRange(ComboBoxHelper.GetGdsRy(pj.OrgCode));
        }
        void setqqry()
        {
            string str = rowData.clrqz;
            comboBoxEdit1.EditValue = "";
            comboBoxEdit3.EditValue = "";
            string[] mans = str.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
            if (mans.Length >= 1)
            {
                comboBoxEdit1.EditValue = mans[0];
            }
            if (mans.Length >= 2)
            {
                comboBoxEdit3.EditValue = mans[1];
            }

           
        }
        void getqqry()
        {
            string str = "";
            string yy1 = "";
            yy1 = comboBoxEdit1.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy1 + ";";
            string yy2 = "";
            yy2 = comboBoxEdit3.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy2 + ";";
            rowData.clrqz = str;
            
           
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit2.Text == "")
            {
                MsgBox.ShowTipMessageBox("结论不能为空。");
                comboBoxEdit2.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}