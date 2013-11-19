using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Core;
using Ebada.Client.Platform;
using Ebada.Client;
using Ebada.UI.Base;
using Ebada.Scgl.Core;

namespace Ebada.Exam
{
    public partial class FrmE_UserPrizeRecordEdit :FormBase, IPopupFormEdit {
        SortableSearchableBindingList<E_UserPrizeRecord> m_CityDic = new SortableSearchableBindingList<E_UserPrizeRecord>();
        public FrmE_UserPrizeRecordEdit()
        {
            InitializeComponent();
        }

        void dataBind()
        {

            this.lkueUser.DataBindings.Add("EditValue", rowData,"UserID");
            this.lkuePrize.DataBindings.Add("EditValue", rowData, "PrizeID");
            this.spNUM.DataBindings.Add("EditValue", rowData, "PrizeNum");
            this.dateSendTime.DataBindings.Add("EditValue", rowData,"SendTime");
            this.dateExchangeTime.DataBindings.Add("EditValue", rowData, "ExchangeTime");
            this.memoRecord.DataBindings.Add("EditValue", rowData, "Record");
        }
        private E_UserPrizeRecord rowData = null;

        public object RowData
        {
            get
            {
                return rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as E_UserPrizeRecord;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<E_UserPrizeRecord>(value as E_UserPrizeRecord, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {

            //SetComboBoxData(comboBoxEdit2, "mc", "bh", "", "种类", Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>("where len(bh)=5 order by bh"));
            //comboBoxEdit2.EditValueChanged += new EventHandler(comboBoxEdit2_EditValueChanged);
            SetComboBoxData(lkuePrize, "Value", "Key", "请选择", "奖品", DicTypeHelper.PrizeList);
            SetComboBoxData(lkueUser, "Value", "Key", "请选择", "人员", DicTypeHelper.UserList);
        }
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post)
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
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (memoRecord.Text.Length==0)
            {
                MsgBox.ShowWarningMessageBox("请填写记事！");
                return;

            }

            rowData.HasFinished = true;
            rowData.Handler = MainHelper.User.UserID;
            this.DialogResult = DialogResult.OK;
        }

      

       
    }
}
