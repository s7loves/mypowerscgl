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
    public partial class frmaqgjEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_aqgj> m_CityDic = new SortableSearchableBindingList<PS_aqgj>();

        public frmaqgjEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.dateEdit1.DataBindings.Add("EditValue", rowData, "syrq");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "syrq2");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "sbCode");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "syzq");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "sbModle");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "sbType");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "syxm");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "sbName");

            //this.textEdit1.DataBindings.Add("EditValue", rowData, "tq");
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PS_aqgj rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_aqgj;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PS_aqgj>(value as PS_aqgj, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData()
        {
            IList<PS_tqsb> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tqsb>("where tqid in(select tqid from ps_tq where xlcode in (select linecode from ps_xl where OrgCode='"+rowData.OrgID+"'))");
            foreach (PS_tqsb pt in list)
            {
                comboBoxEdit5.Properties.Items.Add(pt.sbName);
                comboBoxEdit2.Properties.Items.Add(pt.sbType);
                comboBoxEdit1.Properties.Items.Add(pt.sbModle);
            }
            ComboBoxHelper.FillCBoxByDyk("14电力安全工具试验记录", "工具名称", comboBoxEdit5.Properties);
           // ComboBoxHelper.FillCBoxByDyk("14电力安全工具试验记录", "编号", comboBoxEdit3.Properties);
            ComboBoxHelper.FillCBoxByDyk("14电力安全工具试验记录", "试验周期", comboBoxEdit7.Properties);
            ComboBoxHelper.FillCBoxByDyk("14电力安全工具试验记录", "试验项目", comboBoxEdit4.Properties);


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
    }
}