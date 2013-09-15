using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using Ebada.Client;

namespace Ebada.Exam
{
    public partial class FrmE_AddQuestion : DevExpress.XtraEditors.XtraForm
    {
        public FrmE_AddQuestion(TurnE_R_ESetPro terew,Dictionary<string, E_QuestionBank> pd,Dictionary<string, E_QuestionBank> sd,Dictionary<string, E_QuestionBank> msd)
        {
            InitializeComponent();
            ucm_EaddQuestionPD.ChangeDic += new Ucm_EaddQuestion.ChangeObj(ucm_EaddQuestionPD_ChangeDic);
            ucm_EaddQuestionSelect.ChangeDic += new Ucm_EaddQuestion.ChangeObj(ucm_EaddQuestionSelect_ChangeDic);
            ucm_EaddQuestionMuSelect.ChangeDic += new Ucm_EaddQuestion.ChangeObj(ucm_EaddQuestionMuSelect_ChangeDic);
            currtenter = terew;
            PdDic = pd;
            SelectDic = sd;
            MuSelectDic = msd;

            ucm_EaddQuestionPD.DesNum = currtenter.JudgeNUM;
            ucm_EaddQuestionPD.PID = currtenter.PROID;
            ucm_EaddQuestionPD.Type = "判断题";
            ucm_EaddQuestionPD.eqdic = PdDic;

            ucm_EaddQuestionSelect.DesNum = currtenter.SelectNUM;
            ucm_EaddQuestionSelect.PID = currtenter.PROID;
            ucm_EaddQuestionSelect.Type = "单项选择题";
            ucm_EaddQuestionSelect.eqdic = SelectDic;

            ucm_EaddQuestionMuSelect.DesNum = currtenter.MuSelectNUM;
            ucm_EaddQuestionMuSelect.PID = currtenter.PROID;
            ucm_EaddQuestionMuSelect.Type = "多项选择题";
            ucm_EaddQuestionMuSelect.eqdic = MuSelectDic;
        }


        void ucm_EaddQuestionPD_ChangeDic(Dictionary<string, E_QuestionBank> dic)
        {
            PdDic = dic;
            ShowSet();
        }

        void ucm_EaddQuestionSelect_ChangeDic(Dictionary<string, E_QuestionBank> dic)
        {
            SelectDic = dic;
            ShowSet();
        }

        void ucm_EaddQuestionMuSelect_ChangeDic(Dictionary<string, E_QuestionBank> dic)
        {
            MuSelectDic = dic;
            ShowSet();
        }

       

        public  TurnE_R_ESetPro currtenter;

        //试卷编号

        public  Dictionary<string, E_QuestionBank> PdDic = new Dictionary<string, E_QuestionBank>();
        public  Dictionary<string, E_QuestionBank> SelectDic = new Dictionary<string, E_QuestionBank>();
        public  Dictionary<string, E_QuestionBank> MuSelectDic = new Dictionary<string, E_QuestionBank>();

        Dictionary<string, TurnE_R_ESetPro> RealEREPDic = new Dictionary<string, TurnE_R_ESetPro>();
        

        private void InitData()
        {

            ShowSet();
        }

        /// <summary>
        /// 显示设计题数和实际题数
        /// </summary>
        private void ShowSet()
        {
            //清空实际试题数量
            currtenter.RealJudgeNUM = 0;
            currtenter.RealSelectNUM = 0;
            currtenter.RealMuSelectNUM = 0;
            //计算实际判断题数量
            foreach (string key in PdDic.Keys)
            {
                currtenter.RealJudgeNUM += 1;
            }
            //计算实际选择题数量
            foreach (string key in SelectDic.Keys)
            {
                currtenter.RealSelectNUM += 1;
            }
            //计算实际多项选择题数量
            foreach (string key in MuSelectDic.Keys)
            {
                currtenter.RealMuSelectNUM += 1;
            }

            List<TurnE_R_ESetPro> datalist = new List<TurnE_R_ESetPro>();
            datalist.Add(currtenter);
            int i = 1;
            gridControl1.DataSource = null;
            gridControl1.DataSource = datalist;
            gridView1.Columns["PROID"].ColumnEdit = DicTypeHelper.E_proDicTB;
            gridView1.Columns["PROID"].VisibleIndex = i++;
            gridView1.Columns["JudgeNUM"].Width = 110;
            gridView1.Columns["JudgeNUM"].VisibleIndex = i++;
            gridView1.Columns["RealJudgeNUM"].Width = 110;
            gridView1.Columns["RealJudgeNUM"].VisibleIndex = i++;
            gridView1.Columns["SelectNUM"].Width = 110;
            gridView1.Columns["SelectNUM"].VisibleIndex = i++;
            gridView1.Columns["RealSelectNUM"].Width = 110;
            gridView1.Columns["RealSelectNUM"].VisibleIndex = i++;
            gridView1.Columns["MuSelectNUM"].Width = 110;
            gridView1.Columns["MuSelectNUM"].VisibleIndex = i++;
            gridView1.Columns["RealMuSelectNUM"].Width = 110;
            gridView1.Columns["RealMuSelectNUM"].VisibleIndex = i++;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitData();
        }
       
       

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (currtenter.RealJudgeNUM<currtenter.JudgeNUM)
            {
                MsgBox.ShowWarningMessageBox("判断题数量不足，请添加！");
                return;
            }
            if (currtenter.RealSelectNUM < currtenter.SelectNUM)
            {
                MsgBox.ShowWarningMessageBox("单项选择题数量不足，请添加！");
                return;
            }
            if (currtenter.RealMuSelectNUM < currtenter.MuSelectNUM)
            {
                MsgBox.ShowWarningMessageBox("多项选择题数量不足，请添加！");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

    }
}