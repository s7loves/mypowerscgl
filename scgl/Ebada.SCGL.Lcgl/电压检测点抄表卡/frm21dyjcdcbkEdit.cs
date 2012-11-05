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
    public partial class frm21dyjcdcbkEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_21dyjcdcbk> m_CityDic = new SortableSearchableBindingList<PJ_21dyjcdcbk>();

        public frm21dyjcdcbkEdit()
        {
            InitializeComponent();
        }
        void dataBind() {


            this.cobGds.DataBindings.Add("EditValue", rowData, "GdsName");
            this.cobType.DataBindings.Add("EditValue", rowData, "type");
            this.cobYear.DataBindings.Add("EditValue", rowData,"year");
            this.cobModel.DataBindings.Add("EditValue", rowData, "zzxh");
            this.cobNum.DataBindings.Add("EditValue", rowData,"num");
        }
        #region IPopupFormEdit Members
        private PJ_21dyjcdcbk rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_21dyjcdcbk;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_21dyjcdcbk>(value as PJ_21dyjcdcbk, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {

            cobNum.Properties.Items.Clear();
            for (int i = 1; i < 21; i++)
            {
                cobNum.Properties.Items.Add(i);
            }
            cobType.Properties.Items.Clear();
            cobType.Properties.Items.Add("A类");
            cobType.Properties.Items.Add("B类");
            cobType.Properties.Items.Add("C类");
            cobType.Properties.Items.Add("D类220");
            cobType.Properties.Items.Add("D类380");

            cobYear.Properties.Items.Clear();
            int m = DateTime.Now.Year;
            for (int i = -5; i < 5; i++)
            {
                cobYear.Properties.Items.Add(m + i);
            }
            
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

       
        private void btnOK_Click(object sender, EventArgs e)
        {
            //PS_tqbyq byq = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PJ_21dyjcdcbk>(rowData.byqID);
            ////if (rowData.azrq>byq.InDate)
            ////{
            ////    MsgBox.ShowTipMessageBox("安装时间不能在投放时间之后！");
            ////    return;
            ////}
            //if (rowData.ccrq.Year>1900 && rowData.ccrq < rowData.azrq)
            //{
            //    MsgBox.ShowTipMessageBox("撤除时间不能在安装时间之前！");
            //    return;
            //}
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}