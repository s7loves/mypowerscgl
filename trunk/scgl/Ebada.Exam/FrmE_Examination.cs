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
    public partial class FrmE_ExaminationEdit :FormBase, IPopupFormEdit {
        SortableSearchableBindingList<E_Examination> m_CityDic = new SortableSearchableBindingList<E_Examination>();
        public FrmE_ExaminationEdit()
        {
            InitializeComponent();
        }

        void dataBind()
        {

            this.txtName.DataBindings.Add("EditValue", rowData, "E_Name");
            this.lkueExPaper.DataBindings.Add("EditValue", rowData, "EP_ID");
            this.checkOrderRand.DataBindings.Add("EditValue", rowData, "ShowResult");
            this.cobType.DataBindings.Add("EditValue", rowData, "UserType");

            this.dateStart.DataBindings.Add("EditValue", rowData, "StartTime");
            this.dateEnd.DataBindings.Add("EditValue", rowData, "EndTime");

            //this.lkuePro.DataBindings.Add("EditValue", rowData, "ProfessionalID");

        }
        private E_Examination rowData = null;

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
                    this.rowData = value as E_Examination;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<E_Examination>(value as E_Examination, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {

            //SetComboBoxData(comboBoxEdit2, "mc", "bh", "", "种类", Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>("where len(bh)=5 order by bh"));
            //comboBoxEdit2.EditValueChanged += new EventHandler(comboBoxEdit2_EditValueChanged);
            IList<E_Professional> orglist = Client.ClientHelper.PlatformSqlMap.GetList<E_Professional>("");
           

            //SetComboBoxData(lkuePro, "PName", "ID", "请选择", "专业", orglist);
            SetComboBoxData(lkueExPaper, "Value", "Key", "请选择", "试卷", DicTypeHelper.ExPaperDic);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string exname = txtName.Text.Trim();
            if (exname.Length == 0)
            {
                MsgBox.ShowWarningMessageBox("考试名称不能为空！");
                return;
            }

            if (lkueExPaper.EditValue==null||lkueExPaper.EditValue.ToString()==string.Empty)
            {
                MsgBox.ShowWarningMessageBox("请选择试卷！");
                return;
            }
            if (cobType.EditValue == null || cobType.EditValue.ToString() == string.Empty)
            {
                MsgBox.ShowWarningMessageBox("请选参考对象类型！");
                return;
            }

            //if (lkuePro.EditValue == null || lkuePro.EditValue.ToString() == string.Empty)
            //{
            //    MsgBox.ShowWarningMessageBox("请选择专业！");
            //    return;
            //}
            IList<E_Examination> list = Client.ClientHelper.PlatformSqlMap.GetList<E_Examination>(" where E_Name='" + exname + "' ");
            if (list.Count>0&&rowData.ID!=list[0].ID)
            {
                MsgBox.ShowWarningMessageBox("已存在名称为【" + exname + "】的考试！");
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

        private void lkueExPaper_EditValueChanged(object sender, EventArgs e)
        {
            if (lkueExPaper.EditValue!=null&&lkueExPaper.EditValue.ToString()!=string.Empty)
            {
                string id = lkueExPaper.EditValue.ToString();
                E_ExaminationPaper ep = Client.ClientHelper.PlatformSqlMap.GetOneByKey<E_ExaminationPaper>(id);
                E_ExamSetting es = Client.ClientHelper.PlatformSqlMap.GetOneByKey<E_ExamSetting>(ep.SettingID);
                rowData.BySCol1 = es.WaitTime.ToString();
            }
        }

        private void btnEditQuestion_Click(object sender, EventArgs e)
        {
            if (lkueExPaper.EditValue == null || lkueExPaper.EditValue.ToString() == string.Empty)
            {
                MsgBox.ShowWarningMessageBox("请选择试卷！");
                return;
            }
            if (cobType.EditValue == null || cobType.EditValue.ToString() == string.Empty)
            {
                MsgBox.ShowWarningMessageBox("请选参考对象类型！");
                return;
            }
            string stype = string.Empty;
            if (cobType.EditValue.ToString() == "人员")
            {
                stype = "user";
            }
            else
            {
                stype = "org";
            }
            FrmE_ExaminationUserEdit frm = new FrmE_ExaminationUserEdit(stype, GetOrgIDS(lkueExPaper.EditValue.ToString()), rowData.OrgIDS, rowData.UserIDS);
           
            if (frm.ShowDialog()==DialogResult.OK)
            {
                rowData.OrgIDS = frm.GetOgrIDS;
                rowData.UserIDS = frm.GetUserIDS;
            }

        }
        char charsplit = ',';
        private string  GetOrgIDS(string exampaperid)
        {
            string strresult=string.Empty;
            E_ExaminationPaper ep = Client.ClientHelper.PlatformSqlMap.GetOneByKey<E_ExaminationPaper>(exampaperid);
            E_ExamSetting es = Client.ClientHelper.PlatformSqlMap.GetOneByKey<E_ExamSetting>(ep.SettingID);
            string sql = " where EBID='" + es.EQBID + "'";
            IList<E_R_EBankORG> erbolist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_R_EBankORG>(sql);

            foreach (E_R_EBankORG item in erbolist)
	        {
        		 strresult+=item.ORGID+charsplit;
	        }
            if (strresult.Length>1)
	        {
                strresult=strresult.Substring(0,strresult.Length-1);
	        }
            return strresult;
        }
       

       
    }
}
