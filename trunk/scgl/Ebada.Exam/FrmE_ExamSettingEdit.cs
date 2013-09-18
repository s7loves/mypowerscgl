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
    public partial class FrmE_ExamSettingEdit :FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_gtsb> m_CityDic = new SortableSearchableBindingList<PS_gtsb>();
        public FrmE_ExamSettingEdit()
        {
            InitializeComponent();
            ucE_R_ESetPro1.AfterEdit += new UCE_R_ESetPro.edit(ucE_R_ESetPro1_AfterEdit);
        }

        void ucE_R_ESetPro1_AfterEdit()
        {
            ReCount();
        }

        private void ReCount()
        {
            string sqlwhere=" where ESETID='"+rowData.ID+"'";
            IList<E_R_ESetPro> erslist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_R_ESetPro>(sqlwhere);
            int pdnum = 0;
            int selectnum = 0;
            int muselectnum = 0;
            foreach (E_R_ESetPro item in erslist)
            {
                pdnum += item.JudgeNUM;
                selectnum += item.SelectNUM;
                muselectnum += item.MuSelectNUM;
            }
            rowData.JudgeNUM = pdnum;
            rowData.SelectNUM = selectnum;
            rowData.MuSelectNUM = muselectnum;

            spJudgeNUM.Value = pdnum;
            spSelectNUM.Value = selectnum;
            spMuSelectNUM.Value = muselectnum;
            Account();
        }

        void dataBind()
        {

            this.txtSettingName.DataBindings.Add("EditValue", rowData, "SettingName");
            this.lkueEBank.DataBindings.Add("EditValue", rowData, "EQBID");

            this.spJudgeNUM.DataBindings.Add("EditValue", rowData, "JudgeNUM");
            this.spJudgeScore.DataBindings.Add("EditValue", rowData, "JudgeScore");
            this.spSelectNUM.DataBindings.Add("EditValue", rowData, "SelectNUM");
            this.spSelectScore.DataBindings.Add("EditValue", rowData, "SelectScore");
            this.spMuSelectNUM.DataBindings.Add("EditValue", rowData, "MuSelectNUM");
            this.spMuSelectScore.DataBindings.Add("EditValue", rowData, "MuSelectScore");
           

            this.spWaitTime.DataBindings.Add("EditValue", rowData, "WaitTime");
            this.spPassScore.DataBindings.Add("EditValue", rowData, "PassScore");
            this.spTotalScore.DataBindings.Add("EditValue", rowData, "TotalScore");

        }
        private E_ExamSetting rowData = null;

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
                    this.rowData = value as E_ExamSetting;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<E_ExamSetting>(value as E_ExamSetting, rowData);
                }
                ucE_R_ESetPro1.ESETID = rowData.ID;
            }
        }

        private void InitComboBoxData()
        {

            //SetComboBoxData(comboBoxEdit2, "mc", "bh", "", "种类", Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>("where len(bh)=5 order by bh"));
            //comboBoxEdit2.EditValueChanged += new EventHandler(comboBoxEdit2_EditValueChanged);
            IList<E_QBank> orglist = Client.ClientHelper.PlatformSqlMap.GetList<E_QBank>("");
            //SetComboBoxData(lkueEBank, "Value", "Key", "请选择", "题库", DicTypeHelper.EbankDicList);
            SetComboBoxData(lkueEBank, "TKName", "ID", "请选择", "题库", orglist);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string pname = txtSettingName.Text.Trim();
            if (pname.Length== 0)
            {
                MsgBox.ShowWarningMessageBox("设置名称不能为空！");
                return;
            }
            //IList<E_ExamSetting> list = Client.ClientHelper.PlatformSqlMap.GetList<E_ExamSetting>(" where PName='" + pname + "' ");
            //if (list.Count>0&&rowData.ID!=list[0].ID)
            //{
            //    MsgBox.ShowWarningMessageBox("已存在名称为【" + pname + "】的专业！");
            //    return;
            //}
            this.DialogResult = DialogResult.OK;
        }

        private void spJudgeScore_EditValueChanged(object sender, EventArgs e)
        {
            Account();
        }

        private void spSelectScore_EditValueChanged(object sender, EventArgs e)
        {
            Account();
        }

        private void spMuSelectScore_EditValueChanged(object sender, EventArgs e)
        {
            Account();
        }

       
        private void Account()
        {

            double pdnum = (double)spJudgeNUM.Value;
            double pdscore = (double)spJudgeScore.Value;

            int dxnum = (int)spSelectNUM.Value;
            double dxscore = (double)spSelectScore.Value;

            double dxxnum = (double)spMuSelectNUM.Value;
            double dxxscore = (double)spMuSelectScore.Value;

            double allscore = pdnum * pdscore + dxnum * dxscore + dxxnum * dxxscore;
            rowData.TotalScore = Math.Round(allscore,2);
            spTotalScore.Value = (decimal)(rowData.TotalScore);
        }
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<E_QBank> post)
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

        private void lkueEBank_EditValueChanged(object sender, EventArgs e)
        {
            if (lkueEBank.EditValue != null && lkueEBank.EditValue.ToString() != string.Empty)
            {
                try
                {
                    string tkid = lkueEBank.EditValue.ToString();
                    //删除除其它题库的设置
                    string delsql = " where ESETID='" + rowData.ID + "' and BySCol1!='" + tkid + "'";
                    Client.ClientHelper.PlatformSqlMap.DeleteByWhere<E_R_ESetPro>(delsql);
                    string sqlwhere = " where ESETID='" + rowData.ID + "' and BySCol1='" + tkid + "'";
                    IList<E_R_ESetPro> eresblist = Client.ClientHelper.PlatformSqlMap.GetList<E_R_ESetPro>(sqlwhere);
                    if (eresblist.Count == 0)
                    {
                        IList<E_R_EBankPro> erblist = Client.ClientHelper.PlatformSqlMap.GetList<E_R_EBankPro>(" where EBID='" + tkid + "'");
                        for (int i = 0; i < erblist.Count; i++)
                        {
                            E_R_ESetPro er = new E_R_ESetPro();
                            er.ID += i;
                            er.ESETID = rowData.ID;
                            er.PROID = erblist[i].PROID;
                            er.BySCol1 = tkid;
                            Client.ClientHelper.PlatformSqlMap.Create<E_R_ESetPro>(er);
                        }
                       
                    }
                }
                catch (Exception ee)
                {
                    
                }
              
            }
            ucE_R_ESetPro1.ESETID = rowData.ID;
        }
    }
}
