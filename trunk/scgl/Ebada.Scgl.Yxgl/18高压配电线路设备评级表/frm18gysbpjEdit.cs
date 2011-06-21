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
    public partial class frm18gysbpjEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_18gysbpj> m_CityDic = new SortableSearchableBindingList<PJ_18gysbpj>();

        public frm18gysbpjEdit() {
            InitializeComponent();
        }
        void dataBind() {

            PJ_18gysbpj temp = new PJ_18gysbpj();
         
           this.dateEdit1.DataBindings.Add("EditValue", rowData, "rq");
            //this.dateEdit2.DataBindings.Add("EditValue", rowData, "CreateDate");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "fzr");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "zbr");
          
      
        
                
        }
        #region IPopupFormEdit Members
        private PJ_18gysbpj rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_18gysbpj;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_18gysbpj>(value as PJ_18gysbpj, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            comboBoxEdit1.Properties.Items.Clear();
            comboBoxEdit3.Properties.Items.Clear();
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表
            comboBoxEdit1.Properties.Items.AddRange(ryList);
            comboBoxEdit3.Properties.Items.AddRange(ryList);
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

    }
}