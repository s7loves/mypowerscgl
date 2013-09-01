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
    public partial class FrmE_ExaminationPaperEdit :FormBase, IPopupFormEdit {
        SortableSearchableBindingList<E_ExaminationPaper> m_CityDic = new SortableSearchableBindingList<E_ExaminationPaper>();
        public FrmE_ExaminationPaperEdit()
        {
            InitializeComponent();
        }

        void dataBind()
        {

            this.txtName.DataBindings.Add("EditValue", rowData, "EP_Name");
            this.lkueSetting.DataBindings.Add("EditValue", rowData, "SettingID");
            this.checkOrderRand.DataBindings.Add("EditValue", rowData, "OrderRandom");
            this.cobType.DataBindings.Add("EditValue", rowData, "Paper_Type");
            //this.lkuePro.DataBindings.Add("EditValue", rowData, "ProfessionalID");

        }
        private E_ExaminationPaper rowData = null;

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
                    this.rowData = value as E_ExaminationPaper;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<E_ExaminationPaper>(value as E_ExaminationPaper, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {

            //SetComboBoxData(comboBoxEdit2, "mc", "bh", "", "种类", Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>("where len(bh)=5 order by bh"));
            //comboBoxEdit2.EditValueChanged += new EventHandler(comboBoxEdit2_EditValueChanged);
            IList<E_Professional> orglist = Client.ClientHelper.PlatformSqlMap.GetList<E_Professional>("");
           

            //SetComboBoxData(lkuePro, "PName", "ID", "请选择", "专业", orglist);
            SetComboBoxData(lkueSetting, "Value", "Key", "请选择", "设置", DicTypeHelper.SettingDic);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string exname = txtName.Text.Trim();
            if (exname.Length == 0)
            {
                MsgBox.ShowWarningMessageBox("试卷名称不能为空！");
                return;
            }

            if (lkueSetting.EditValue==null||lkueSetting.EditValue.ToString()==string.Empty)
            {
                MsgBox.ShowWarningMessageBox("请选择试卷设置！");
                return;
            }
            if (cobType.EditValue == null || cobType.EditValue.ToString() == string.Empty)
            {
                MsgBox.ShowWarningMessageBox("请选择试卷类型！");
                return;
            }

            //if (lkuePro.EditValue == null || lkuePro.EditValue.ToString() == string.Empty)
            //{
            //    MsgBox.ShowWarningMessageBox("请选择专业！");
            //    return;
            //}
            IList<E_ExaminationPaper> list = Client.ClientHelper.PlatformSqlMap.GetList<E_ExaminationPaper>(" where EP_Name='" + exname + "' ");
            if (list.Count>0&&rowData.ID!=list[0].ID)
            {
                MsgBox.ShowWarningMessageBox("已存在名称为【" + exname + "】的试卷！");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<E_Professional> post)
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

        private void lkueSetting_EditValueChanged(object sender, EventArgs e)
        {
            if (lkueSetting.EditValue != null && lkueSetting.EditValue.ToString()!=string.Empty)
            {
                E_ExamSetting eset = Client.ClientHelper.PlatformSqlMap.GetOneByKey<E_ExamSetting>(lkueSetting.EditValue.ToString());
                rowData.TotalScore = eset.TotalScore;
            }
            
        }

        private void cobType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobType.EditValue!=null)
            {
                if (cobType.EditValue.ToString()=="指定试题")
                {
                    btnEditQuestion.Enabled = true;
                }
                else
                {
                    btnEditQuestion.Enabled = false;
                    rowData.CreateMan = string.Empty;
                }
            }
            else
            {
                btnEditQuestion.Enabled = false;
            }
        }

        private void btnEditQuestion_Click(object sender, EventArgs e)
        {
            FrmE_PaperEdit frm = new FrmE_PaperEdit();
            frm.EPID = rowData.ID;
            frm.SetId = rowData.SettingID;
            if (frm.ShowDialog()==DialogResult.OK)
            {
                rowData.CreateTime = DateTime.Now;
                rowData.CreateMan = MainHelper.User.UserName;
            }
        }
    }
}
