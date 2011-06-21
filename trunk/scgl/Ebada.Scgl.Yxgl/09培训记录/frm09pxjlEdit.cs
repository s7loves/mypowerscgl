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
    public partial class frm09pxjlEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_09pxjl> m_CityDic = new SortableSearchableBindingList<PJ_09pxjl>();

        public frm09pxjlEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.dateEdit1.DataBindings.Add("EditValue", rowData, "rq");
            //this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "xxss");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "cjrs");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "zjr");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "zcr");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "tm");
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "nr");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "py");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "qz");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "qzrq");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "hydd");
            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_09pxjl rowData = null;
        
        public object RowData {
            get {
                getxxss();
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_09pxjl;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_09pxjl>(value as PJ_09pxjl, rowData);
                }
                setxxss();
            }
        }

        #endregion

        private void InitComboBoxData() {
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表
            comboBoxEdit3.Properties.Items.AddRange(ryList);
            comboBoxEdit4.Properties.Items.AddRange(ryList);
            comboBoxEdit5.Properties.Items.AddRange(ryList);
            for (int i = 1; i < 24; i++)
            {
                comboBoxEdit1.Properties.Items.Add(i);
            }
            for (int j = 1; j < 60; j++)
            {
                comboBoxEdit6.Properties.Items.Add(j);
            }
            for (int k = 1; k <= ryList.Count; k++)
            {
                comboBoxEdit2.Properties.Items.Add(k);

            }
            ComboBoxHelper.FillCBoxByDyk("09培训记录", "地点", comboBoxEdit7.Properties);
         
        }
        void setxxss()
        {
            string str = rowData.xxss;
            string[] mans = str.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
            comboBoxEdit1.EditValue = "";
            comboBoxEdit6.EditValue = "";
            int m = 0;
            comboBoxEdit1.EditValue = "";
            comboBoxEdit6.EditValue = "";
            if (mans.Length>=1)
            {
                comboBoxEdit1.EditValue = mans[0];
            }
            if (mans.Length >= 2)
            {
                comboBoxEdit6.EditValue = mans[1];
            }
            
        }
        void getxxss()
        {
            string str = "";
            string yy1 = "";
            yy1 = comboBoxEdit1.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy1 + ";";
            string yy2 = "";
            yy2 = comboBoxEdit6.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy2.Trim()))
                str += yy2 + ";";
          
            rowData.xxss = str;
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

        private void frm09pxjlEdit_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("09培训记录内容", "记录内容", memoEdit2);

        }
    }
}