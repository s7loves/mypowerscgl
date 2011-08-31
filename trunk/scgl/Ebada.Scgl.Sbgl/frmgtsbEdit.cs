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
namespace Ebada.Scgl.Sbgl
{
    public partial class frmgtsbEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_gtsb> m_CityDic = new SortableSearchableBindingList<PS_gtsb>();

        public frmgtsbEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "sbCode");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "sbType");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "sbModle");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "sbName");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "C1");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "C2");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "C3");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "C4");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "C5");

            this.spinEdit2.DataBindings.Add("EditValue", rowData, "sbNumber");

        }
        #region IPopupFormEdit Members
        private PS_gtsb rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_gtsb;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PS_gtsb>(value as PS_gtsb, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {

            SetComboBoxData(comboBoxEdit2, "mc", "bh", "", "种类", Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>("where len(bh)=5 order by bh"));
            comboBoxEdit2.EditValueChanged += new EventHandler(comboBoxEdit2_EditValueChanged);
        }

        void comboBoxEdit2_EditValueChanged(object sender, EventArgs e) {
            object xh = comboBoxEdit2.EditValue;
            if (string.IsNullOrEmpty(xh as string)) return;
            rowData.sbName = comboBoxEdit4.Text = comboBoxEdit2.Text;
            pdsbModelHelper.FillCBox(comboBoxEdit3, xh.ToString().Substring(0, 2));
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<PS_sbcs> post) {
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text == "")
            {
                MsgBox.ShowTipMessageBox("设备编号不能为空。");
                comboBoxEdit1.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comboBoxEdit4_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit3.Text == "")
            {
                comboBoxEdit3.Properties.Items.Clear();
                IList<PS_sbcs> list = Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>(" where mc='" + comboBoxEdit4.Text  + "' order by ID");
                for (int i = 0; i < list.Count; i++)
                {

                    comboBoxEdit3.Properties.Items.Add(list[i].xh);
                
                }
            
            }
        }
    
    }
}