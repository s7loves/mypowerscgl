/**********************************************
系统:计划管理
模块:年计划
作者:Rabbit
创建时间:2012-9-12
最后一次修改:2012-9-15
***********************************************/
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
using System.Collections;
namespace Ebada.jhgl
{
    public partial class frmJH_yearksEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<JH_yearks> m_CityDic = new SortableSearchableBindingList<JH_yearks>();

        public frmJH_yearksEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "主要负责人");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "参加人员");
            //this.textEdit3.DataBindings.Add("EditValue", rowData, "c1");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "c1");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "计划项目");
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "实施内容");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "计划种类");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "预计时间");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "预计时间2");

            this.comboBoxEdit1.Properties.Items.Add("常规计划");
            this.comboBoxEdit1.Properties.Items.Add("一次性计划");
            this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }
        #region IPopupFormEdit Members
        private JH_yearks rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as JH_yearks;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<JH_yearks>(value as JH_yearks, rowData);                    
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            ICollection list = Ebada.Scgl.Core.ComboBoxHelper.GetGdsRyfzr(MainHelper.User.OrgCode);
            if(list.Count==0)
                list = Ebada.Scgl.Core.ComboBoxHelper.GetGdsRy(MainHelper.User.OrgCode);
             comboBoxEdit2.Properties.Items.AddRange( list);
             ICollection ic= Ebada.Scgl.Core.ComboBoxHelper.GetGdsRy(MainHelper.User.OrgCode);
             foreach (string sr in ic) {
                 comboBoxEdit3.Properties.Items.Add(sr, CheckState.Unchecked, true);
             }
            IList<mOrg> list2 =Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where parentid='0' and orgtype='0'");

            foreach (mOrg org in list2) {
                comboBoxEdit4.Properties.Items.Add(org.OrgName, CheckState.Unchecked, true);
            }
        }

        

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
        }

        private void labelControl2_Click(object sender, EventArgs e) {

        }

        private void labelControl3_Click(object sender, EventArgs e) {

        }

        private void groupBox1_Enter(object sender, EventArgs e) {

        }
    }
}