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
    public partial class FrmE_QuestionBankEdit :FormBase, IPopupFormEdit {
        SortableSearchableBindingList<E_QuestionBank> m_CityDic = new SortableSearchableBindingList<E_QuestionBank>();
        public FrmE_QuestionBankEdit()
        {
            InitializeComponent();
        }
        int xxnum = 0;
        void dataBind()
        {

            //this.lkueorg.DataBindings.Add("EditValue", rowData, "OID");

        }
        private E_QuestionBank rowData = null;

        public object RowData
        {
            get
            {
                return rowData;
            }
            set
            {
                
                if (value == null) return;
                 this.rowData = value as E_QuestionBank;
                this.InitComboBoxData();
                Deal(rowData);
                //if (rowData == null)
                //{
                //    this.rowData = value as E_QuestionBank;
                    
                //    dataBind();
                //}
                //else
                //{
                //    ConvertHelper.CopyTo<E_QuestionBank>(value as E_QuestionBank, rowData);
                //}
            }
        }
        void Deal(E_QuestionBank eq)
        {
            string[] da = eq.Option.Split('@');
            xxnum = da.Length;
            switch (eq.Type)
            {
                case "单项选择题":
                    groupd.Visible = true;
                    groupdx.Visible = false;
                    grouppd.Visible = false;
                    this.Height = 504;
                    PiPeiDAD(eq.Title,da, eq.Answer,eq.Explain);
                    break;
                case "多项选择题":
                    groupd.Visible = false;
                    groupdx.Visible = true;
                    grouppd.Visible = false;
                    this.Height = 504;
                    PiPeiDADX(eq.Title, da, eq.Answer, eq.Explain);
                    break;
                case "判断题":
                    groupd.Visible = false;
                    groupdx.Visible = false;
                    grouppd.Visible = true;
                    this.Height = 360;
                    PiPeiDAPD(eq.Title, eq.Answer, eq.Explain);
                    break;
                default:
                    break;
            }

        }

        void PiPeiDAD(string tg,string[] da,string sel,string js)
        {
            DTG.Text = tg;

            DtxtA.Text = string.Empty;
            DtxtB.Text = string.Empty;
            DtxtC.Text = string.Empty;
            DtxtD.Text = string.Empty;
            DtxtE.Text = string.Empty;
            DtxtF.Text = string.Empty;

            DRA.Checked = false;
            DRB.Checked = false;
            DRC.Checked = false;
            DRD.Checked = false;
            DRE.Checked = false;
            DRF.Checked = false;

            for (int i = 0; i < da.Length; i++)
            {
                switch (i+1)
                {
                    case 1:
                        DtxtA.Text = da[i];
                        if (DRA.Text==sel)
                        {
                            DRA.Checked = true;
                        }
                        break;
                    case 2:
                        DtxtB.Text = da[i];
                        if (DRB.Text == sel)
                        {
                            DRB.Checked = true;
                        }
                        break;
                    case 3:
                        DtxtC.Text = da[i];
                        if (DRC.Text == sel)
                        {
                            DRC.Checked = true;
                        }
                        break;
                    case 4:
                        DtxtD.Text = da[i];
                        if (DRD.Text == sel)
                        {
                            DRD.Checked = true;
                        }
                        break;
                    case 5:
                        DtxtE.Text = da[i];
                        if (DRE.Text == sel)
                        {
                            DRE.Checked = true;
                        }
                        break;
                    case 6:
                        DtxtF.Text = da[i];
                        if (DRF.Text == sel)
                        {
                            DRF.Checked = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            DJS.Text = js;
        }
        void PiPeiDADX(string tg, string[] da, string sel, string js)
        {
            DXTG.Text = tg;

            DXtxtA.Text = string.Empty;
            DXtxtB.Text = string.Empty;
            DXtxtC.Text = string.Empty;
            DXtxtD.Text = string.Empty;
            DXtxtE.Text = string.Empty;
            DXtxtF.Text = string.Empty;

            DXCA.Checked = false;
            DXCB.Checked = false;
            DXCC.Checked = false;
            DXCD.Checked = false;
            DXCE.Checked = false;
            DXCF.Checked = false;


            for (int i = 0; i < da.Length; i++)
            {
                switch (i+1)
                {
                    case 1:
                        DXtxtA.Text = da[i];
                        if (sel.Contains(DXCA.Text))
                        {
                            DXCA.Checked = true;
                        }
                        break;
                    case 2:
                        DXtxtB.Text = da[i];
                        if (sel.Contains(DXCB.Text))
                        {
                            DXCB.Checked = true;
                        }
                        break;
                    case 3:
                        DXtxtC.Text = da[i];
                        if (sel.Contains(DXCC.Text))
                        {
                            DXCC.Checked = true;
                        }
                        break;
                    case 4:
                        DXtxtD.Text = da[i];
                        if (sel.Contains(DXCD.Text))
                        {
                            DXCD.Checked = true;
                        }
                        break;
                    case 5:
                        DXtxtE.Text = da[i];
                        if (sel.Contains(DXCE.Text))
                        {
                            DXCE.Checked = true;
                        }
                        break;
                    case 6:
                        DXtxtF.Text = da[i];
                        if (sel.Contains(DXCF.Text))
                        {
                            DXCF.Checked = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            DXJS.Text = js;
        }
        void PiPeiDAPD(string tg, string sel, string js)
        {
            PDTG.Text = tg;

            PDROK.Checked = false;
            PDRError.Checked = false;

            if (sel.Trim().ToLower()=="true")
            {
                PDROK.Checked = true;
            }
            else if (sel.Trim().ToLower() == "false")
            {
                PDRError.Checked = true;
            }
            else
            {
                PDROK.Checked = false;
                PDRError.Checked = false;
            }
            PDJS.Text = js;
        }
        private void InitComboBoxData()
        {
            //IList<mOrg> orglist=Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("");
            //SetComboBoxData(lkueorg, "OrgName", "OrgCode", "请选择","单位",orglist);

            IList<E_Professional> orglist = Client.ClientHelper.PlatformSqlMap.GetList<E_Professional>("");
            SetComboBoxData(lkuePro, "PName", "ID", "请选择", "专业", orglist);
            SetComboBoxData(lkueDic, "Value", "Key", "请选择", "难度系数", DicTypeHelper.GetE_QuDicList());
            lkuePro.EditValue = rowData.Professional;
            cobType.EditValue = rowData.Type;
            lkueDic.EditValue = rowData.DifficultyLevel.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lkuePro.EditValue==null)
            {
                MsgBox.ShowAskMessageBox("请选择专业！");
                return;
            }
            if (lkueDic.EditValue==null)
            {
                MsgBox.ShowAskMessageBox("请选择难度系数！");
                return;
            }
            rowData.Professional = lkuePro.EditValue.ToString();
            rowData.DifficultyLevel = int.Parse(lkueDic.EditValue.ToString());
            bool isRight = false;
            switch (rowData.Type)
            {
                case "单项选择题":
                    isRight=SaveDaD();
                    break;
                case "多项选择题":
                    isRight = SaveDaDX();
                    break;
                case "判断题":
                    isRight = SaveDaPD();
                    break;
                default:
                    break;
            }
            if (isRight)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        string JKChar = "@";
        bool  SaveDaD()
        {
            if (DTG.Text.Trim().Length==0)
            {
                MsgBox.ShowWarningMessageBox("题干不能为空！");
                DTG.Focus();
                return false;
            }
            rowData.Title = DTG.Text;
            string answer = string.Empty;
            string tempda = string.Empty;
            bool novalue = false;
            if (DtxtA.Text.Trim().Length!=0)
            {
                if (novalue)
                {
                     MsgBox.ShowWarningMessageBox("请按顺序填写答案！");
                     return false;
                }
                tempda = DtxtA.Text.Trim().Replace(JKChar,"");
                answer += tempda + JKChar;
                if (DRA.Checked)
                {
                    rowData.Answer = DRA.Text;
                }
            }
            else
            {
                novalue = true;
            }

            if (DtxtB.Text.Trim().Length != 0)
            {
                if (novalue)
                {
                    MsgBox.ShowWarningMessageBox("请按顺序填写答案！");
                    return false;
                }
                tempda = DtxtB.Text.Trim().Replace(JKChar, "");
                answer += tempda + JKChar;
                if (DRB.Checked)
                {
                    rowData.Answer = DRB.Text;
                }
            }
            else
            {
                novalue = true;
            }

            if (DtxtC.Text.Trim().Length != 0)
            {
                if (novalue)
                {
                    MsgBox.ShowWarningMessageBox("请按顺序填写答案！");
                    return false;
                }
                tempda = DtxtC.Text.Trim().Replace(JKChar, "");
                answer += tempda + JKChar;
                if (DRC.Checked)
                {
                    rowData.Answer = DRC.Text;
                }
            }
            else
            {
                novalue = true;
            }

            if (DtxtD.Text.Trim().Length != 0)
            {
                if (novalue)
                {
                    MsgBox.ShowWarningMessageBox("请按顺序填写答案！");
                    return false;
                }
                tempda = DtxtD.Text.Trim().Replace(JKChar, "");
                answer += tempda + JKChar;
                if (DRD.Checked)
                {
                    rowData.Answer = DRD.Text;
                }
            }
            else
            {
                novalue = true;
            }
            if (DtxtE.Text.Trim().Length != 0)
            {
                if (novalue)
                {
                    MsgBox.ShowWarningMessageBox("请按顺序填写答案！");
                    return false;
                }
                tempda = DtxtD.Text.Trim().Replace(JKChar, "");
                answer += tempda + JKChar;
                if (DRE.Checked)
                {
                    rowData.Answer = DRE.Text;
                }
            }
            else
            {
                novalue = true;
            }

            if (DtxtF.Text.Trim().Length != 0)
            {
                if (novalue)
                {
                    MsgBox.ShowWarningMessageBox("请按顺序填写答案！");
                    return false;
                }
                tempda = DtxtD.Text.Trim().Replace(JKChar, "");
                answer += tempda + JKChar;
                if (DRF.Checked)
                {
                    rowData.Answer = DRF.Text;
                }
            }
            else
            {
                novalue = true;
            }

            if (answer.Length==0)
            {
                MsgBox.ShowWarningMessageBox("请填写答案内容！");
                return false;
            }
            else
            {
                answer = answer.Substring(0, answer.Length - 1);
            }

            if (rowData.Answer==string.Empty)
            {
                MsgBox.ShowWarningMessageBox("请您选择正确的答案选项！");
                return false;
            }
            rowData.Option = answer;
            rowData.Explain = DJS.Text;
            return true;
        }

        bool SaveDaDX()
        {
            if (DXTG.Text.Trim().Length == 0)
            {
                MsgBox.ShowWarningMessageBox("题干不能为空！");
                DXTG.Focus();
                return false;
            }
            rowData.Title = DXTG.Text;
            string answer = string.Empty;
            string tempda = string.Empty;
            bool novalue = false;
            rowData.Answer = "";
            if (DXtxtA.Text.Trim().Length != 0)
            {
                if (novalue)
                {
                    MsgBox.ShowWarningMessageBox("请按顺序填写答案！");
                    return false;
                }
                tempda = DXtxtA.Text.Trim().Replace(JKChar, "");
                answer += tempda + JKChar;
                if (DXCA.Checked)
                {
                    rowData.Answer += DXCA.Text;
                }
            }
            else
            {
                novalue = true;
            }

            if (DXtxtB.Text.Trim().Length != 0)
            {
                if (novalue)
                {
                    MsgBox.ShowWarningMessageBox("请按顺序填写答案！");
                    return false;
                }
                tempda = DXtxtB.Text.Trim().Replace(JKChar, "");
                answer += tempda + JKChar;
                if (DXCB.Checked)
                {
                    rowData.Answer += DXCB.Text;
                }
            }
            else
            {
                novalue = true;
            }

            if (DXtxtC.Text.Trim().Length != 0)
            {
                if (novalue)
                {
                    MsgBox.ShowWarningMessageBox("请按顺序填写答案！");
                    return false;
                }
                tempda = DXtxtC.Text.Trim().Replace(JKChar, "");
                answer += tempda + JKChar;
                if (DXCC.Checked)
                {
                    rowData.Answer += DXCC.Text;
                }
            }
            else
            {
                novalue = true;
            }

            if (DXtxtD.Text.Trim().Length != 0)
            {
                if (novalue)
                {
                    MsgBox.ShowWarningMessageBox("请按顺序填写答案！");
                    return false;
                }
                tempda = DXtxtD.Text.Trim().Replace(JKChar, "");
                answer += tempda + JKChar;
                if (DXCD.Checked)
                {
                    rowData.Answer += DXCD.Text;
                }
            }
            else
            {
                novalue = true;
            }
            if (DXtxtE.Text.Trim().Length != 0)
            {
                if (novalue)
                {
                    MsgBox.ShowWarningMessageBox("请按顺序填写答案！");
                    return false;
                }
                tempda = DXtxtD.Text.Trim().Replace(JKChar, "");
                answer += tempda + JKChar;
                if (DXCE.Checked)
                {
                    rowData.Answer += DXCE.Text;
                }
            }
            else
            {
                novalue = true;
            }

            if (DXtxtF.Text.Trim().Length != 0)
            {
                if (novalue)
                {
                    MsgBox.ShowWarningMessageBox("请按顺序填写答案！");
                    return false;
                }
                tempda = DXtxtD.Text.Trim().Replace(JKChar, "");
                answer += tempda + JKChar;
                if (DXCF.Checked)
                {
                    rowData.Answer += DXCF.Text;
                }
            }
            else
            {
                novalue = true;
            }

            if (answer.Length == 0)
            {
                MsgBox.ShowWarningMessageBox("请填写答案内容！");
                return false;
            }
            else
            {
                answer = answer.Substring(0, answer.Length - 1);
            }

            if (rowData.Answer == string.Empty)
            {
                MsgBox.ShowWarningMessageBox("请您选择正确的答案选项！");
                return false;
            }
            rowData.Option = answer;
            rowData.Explain = DXJS.Text;
            return true;
        }

        bool SaveDaPD()
        {
            if (PDTG.Text.Trim().Length == 0)
            {
                MsgBox.ShowWarningMessageBox("题干不能为空！");
                DXTG.Focus();
                return false;
            }
            rowData.Title = PDTG.Text;
            if (PDROK.Checked)
            {
                rowData.Answer = "True";
            }
            if (PDRError.Checked)
            {
                rowData.Answer = "False";
            }
            if (rowData.Answer == string.Empty)
            {
                MsgBox.ShowWarningMessageBox("请您选择正确的答案选项！");
                return false;
            }
            rowData.Explain = PDJS.Text;
            return true;
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

     
    }
}
