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
            gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
        }
        E_R_ESetPro _currentEr;
        E_R_ESetPro currentEr
        {
            set
            {
                if (value == null) return;
                this._currentEr = value as E_R_ESetPro;
                spinEdit1.EditValue = _currentEr.JudgeNUM;
                spinEdit2.EditValue = _currentEr.SelectNUM;
                spinEdit3.EditValue = _currentEr.MuSelectNUM;

                //if (_currentEr == null)
                //{
                //    this._currentEr = value as E_R_ESetPro;


                //    //this.spinEdit1.DataBindings.Add("EditValue", _currentEr, "JudgeNUM");
                //    //this.spinEdit2.DataBindings.Add("EditValue", _currentEr, "SelectNUM");
                //    //this.spinEdit3.DataBindings.Add("EditValue", _currentEr, "MuSelectNUM");
                //}
                //else
                //{
                //    ConvertHelper.CopyTo<E_R_ESetPro>(value as E_R_ESetPro, _currentEr);
                //    spinEdit1.EditValue = _currentEr.JudgeNUM;
                //    spinEdit2.EditValue = _currentEr.SelectNUM;
                //    spinEdit3.EditValue = _currentEr.MuSelectNUM;
                //}
            }
            get
            {
                return _currentEr;
            }
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRow()!=null)
            {
                E_R_ESetPro er = gridView1.GetFocusedRow() as E_R_ESetPro;
                currentEr = er;
            }
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
                    spinEdit1.EditValue = 0;
                    spinEdit2.EditValue = 0;
                    spinEdit3.EditValue = 0;
                    ConvertHelper.CopyTo<E_ExamSetting>(value as E_ExamSetting, rowData);
                }
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

        private void spJudgeNUM_EditValueChanged(object sender, EventArgs e)
        {
            Account();
        }

        private void spSelectNUM_EditValueChanged(object sender, EventArgs e)
        {
            Account();
        }

        private void spMuSelectNUM_EditValueChanged(object sender, EventArgs e)
        {
            Account();
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

        private void spComJudgeNUM_EditValueChanged(object sender, EventArgs e)
        {
            Account();
        }

        private void spComMuSelectNUM_EditValueChanged(object sender, EventArgs e)
        {
            Account();
        }

        private void spinEdit11_EditValueChanged(object sender, EventArgs e)
        {
            Account();
        }
        private void Account()
        {
            int allscore = rowData.SelectNUM  * rowData.SelectScore + rowData.MuSelectNUM  * rowData.MuSelectScore + rowData.JudgeNUM  * rowData.JudgeScore;
            rowData.TotalScore = allscore;
            spTotalScore.Value = allscore;
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
                string tkid = lkueEBank.EditValue.ToString();
                //删除除它题库的设置
                string delsql = " where BySCol1!='" + tkid + "'";
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
                    IList<E_R_ESetPro> eresblist2 = Client.ClientHelper.PlatformSqlMap.GetList<E_R_ESetPro>(sqlwhere);
                    gridControl1.DataSource = eresblist2;
                }
                else
                {
                    gridControl1.DataSource = eresblist;
                }
                gridView1.Columns["PROID"].ColumnEdit = DicTypeHelper.E_proDic;
            }
            else
            {
                gridControl1.DataSource = null;
                gridView1.Columns.Clear();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (currentEr==null)
            {
                MsgBox.ShowWarningMessageBox("请选择左侧列表中的一行，然后修改保存");
                return;
            }
            currentEr.JudgeNUM = int.Parse(spinEdit1.EditValue.ToString());
            currentEr.SelectNUM = int.Parse(spinEdit2.EditValue.ToString());
            currentEr.MuSelectNUM = int.Parse(spinEdit3.EditValue.ToString());

            Client.ClientHelper.PlatformSqlMap.Update<E_R_ESetPro>(currentEr);
            string tkid = lkueEBank.EditValue.ToString();
            string sqlwhere = " where ESETID='" + rowData.ID + "' and BySCol1='" + tkid + "'";


            IList<E_R_ESetPro> eresblist = Client.ClientHelper.PlatformSqlMap.GetList<E_R_ESetPro>(sqlwhere);

            rowData.JudgeNUM = 0;
            rowData.SelectNUM = 0;
            rowData.MuSelectNUM = 0;
            for (int i = 0; i < eresblist.Count; i++)
            {
                rowData.JudgeNUM += eresblist[i].JudgeNUM;
                rowData.SelectNUM += eresblist[i].SelectNUM;
                rowData.MuSelectNUM += eresblist[i].MuSelectNUM;
            }
            spJudgeNUM.Value = rowData.JudgeNUM;
            spSelectNUM.Value = rowData.SelectNUM;
            spMuSelectNUM.Value = rowData.MuSelectNUM;
            Account();
            gridControl1.DataSource = eresblist;
            gridView1.Columns["PROID"].ColumnEdit = DicTypeHelper.E_proDic;
        }
    }
}
