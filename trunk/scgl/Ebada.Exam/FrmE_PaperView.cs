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
    public partial class FrmE_PaperView : DevExpress.XtraEditors.XtraForm
    {
        public FrmE_PaperView( string EID,string userid)
        {
            InitializeComponent();
            E_ID = EID;
            UserID = userid;
        }
        //考试ID
        public string E_ID = string.Empty;
        //用户ID
        public string UserID = string.Empty;

        Dictionary<string, E_QuestionBank> PdDic = new Dictionary<string, E_QuestionBank>();
        Dictionary<string, E_QuestionBank> SelectDic = new Dictionary<string, E_QuestionBank>();
        Dictionary<string, E_QuestionBank> MuSelectDic = new Dictionary<string, E_QuestionBank>();

        E_ExamSetting ESet;

        private void InitData()
        {
            PdDic.Clear();
            SelectDic.Clear();
            MuSelectDic.Clear();

            E_Examination exam = ClientHelper.PlatformSqlMap.GetOneByKey<E_Examination>(E_ID);
            E_ExaminationPaper expaper = ClientHelper.PlatformSqlMap.GetOneByKey<E_ExaminationPaper>(exam.EP_ID);
            ESet = ClientHelper.PlatformSqlMap.GetOneByKey<E_ExamSetting>(expaper.SettingID);

            string sqlwhere = "  b.E_ID='" + E_ID + "' and b.EP_ID='" + expaper.ID + "' and b.UserID='" + UserID + "' order by ExamQuestonType,cast(b.RandomID as int) asc";
            IList<E_QuestionBank> banklist = ClientHelper.PlatformSqlMap.GetList<E_QuestionBank>("SelectE_QuestionBankCount", sqlwhere);
            foreach (E_QuestionBank item in banklist)
            {
                if (item.Type == "判断题")
                {
                    PdDic.Add(item.ID, item);
                }
                if (item.Type == "单项选择题")
                {
                    SelectDic.Add(item.ID, item);
                   
                }
                if (item.Type == "多项选择题")
                {
                    MuSelectDic.Add(item.ID, item);
                  
                }
            }

                ViewQuestionPaper();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitData();
        }
       
        private void ViewQuestionPaper()
        {
            panel1.Controls.Clear();
            int x = 15;
            int y = 15;

            LabelControl pdlab = new LabelControl();
            pdlab.Font = labMB.Font;
            pdlab.Text = "一、判断题（ " + PdDic.Count + "道，每题" + ESet.JudgeScore + "分， 共计" + PdDic.Count * ESet.JudgeScore + "分 ）";
            pdlab.AutoSize = true;
            panel1.Controls.Add(pdlab);
            pdlab.Location = new Point(x, y);

            y = y + pdlab.Height + 5;

            int pdjs = 1;
            foreach (string key in PdDic.Keys)
            {
                UcViewTroQuestonPD pd = new UcViewTroQuestonPD(pdjs, PdDic[key]);
               
                panel1.Controls.Add(pd);
                pd.Location = new Point(x, y);
                y = y + pd.Height + 5;
                pdjs++;
            }


            LabelControl selectlab = new LabelControl();
            selectlab.Font = labMB.Font;
            selectlab.Text = "二、单项选择题（ " + SelectDic.Count + "道，每题" + ESet.SelectScore + "分， 共计" + SelectDic.Count * ESet.SelectScore + "分 ）";
            selectlab.AutoSize = true;
            panel1.Controls.Add(selectlab);
            selectlab.Location = new Point(x, y);
            y = y + selectlab.Height + 5;

            int selectjs = 1;
            foreach (string key in SelectDic.Keys)
            {
                UcViewTroQuestonSlect select = new UcViewTroQuestonSlect(selectjs, SelectDic[key]);
               
                panel1.Controls.Add(select);
                select.Location = new Point(x, y);
                y = y + select.GetHeight + 5;
                selectjs++;
            }

            Label muselectlab = new Label();
            muselectlab.Font = labMB.Font;
            muselectlab.Text = "三、多项选择题（ " + MuSelectDic.Count + "道，每题" + ESet.MuSelectScore + "分， 共计" + MuSelectDic.Count * ESet.MuSelectScore + "分 ）";
            muselectlab.AutoSize = true;
            panel1.Controls.Add(muselectlab);
            muselectlab.Location = new Point(x, y);
            y = y + muselectlab.Height + 5;

            int muselectjs = 1;
            foreach (string key in MuSelectDic.Keys)
            {
                UcViewTroQuestonMuSlect muselect = new UcViewTroQuestonMuSlect(muselectjs, MuSelectDic[key]);
               
                panel1.Controls.Add(muselect);
                muselect.Location = new Point(x, y);
                y = y + muselect.GetHeight + 5;
                muselectjs++;
            }
           
        }

    }
}