using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Client;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Ebada.Client.Platform;
using Ebada.UI.MessageBoxEx;

namespace Ebada.Exam
{
    public partial class FrmUserExam : DevExpress.XtraEditors.XtraForm
    {

        double ExamAllTime = 0;
        public double ExamLeftTime = 0;
        double  HasExamTime = 0;

        double CurrtenScore = 0;

        string UserID = string.Empty;
        E_Examination Exam = null;
        int AllQuestionNum = 0;
        int LeftQuestionNum = 0;
        E_ExamSetting ESet;
        protected override void OnShown(EventArgs e)
        {
            
            base.OnShown(e);
            this.btnOK.Focus();
        }
        public FrmUserExam(string userid,E_Examination exam)
        {
            InitializeComponent();
            UserID = userid;
            Exam = exam;
            this.Text = MainHelper.User.UserName + "  正在进行 " + exam.E_Name + " 考试     时间：" + exam.BySCol1 + " 分钟";
            this.Move += new EventHandler(FrmUserExam_Move);
        }

        void FrmUserExam_Move(object sender, EventArgs e) {
            this.Location = new Point(0, 0);
        }
        Dictionary<string, string> HasAnswerDic = new Dictionary<string, string>();
        private void FrmUserExam_Load(object sender, EventArgs e)
        {
            //判断是否已开始考试
            if (!SendExamStart())
            {
                ExamLeftTime = ExamAllTime;
            }
            else
            {
                ExamLeftTime = ExamAllTime - HasExamTime;
            }

            //考试已没有时间
            if (ExamLeftTime<=0)
            {
                MsgBox.ShowWarningMessageBox("对不起，您的考试时间已用完！");
                E_Examination exam = Exam;
                string sqlwhere = " where E_ID='" + exam.ID + "'  and EP_ID='" + exam.EP_ID + "' and UserID='" + UserID + "'";
                IList<E_ExamResult> erlist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_ExamResult>(sqlwhere);
                erlist[0].IsExamed = true;
                erlist[0].RealEenTime = GetSysTime();
                erlist[0].Remark = "意外中止考试，再次考试时已超时";
                Client.ClientHelper.PlatformSqlMap.Update<E_ExamResult>(erlist[0]);
            }
            else
            {   
                createWaitDlg();              
                InitData();
                panel1.AutoScrollPosition = new Point(X_Value, Y_Value);
                closeWaitDlg();

                timer1.Enabled = true;
            }
        }
        public void FullScrean() {
            FormState formState = new FormState();
            this.SetVisibleCore(false);
            formState.Maximize(this);
            this.SetVisibleCore(true);
        }
        WaitDialogForm waitdlg;
        void createWaitDlg() {
            waitdlg = new WaitDialogForm("", "正在下载试卷，请稍候。。。");
        }
        void closeWaitDlg() {
            if (waitdlg != null) {
                waitdlg.Close();
                waitdlg = null;
            }
        }
        private void InitData()
        {
            PdDic.Clear();
            SelectDic.Clear();
            MuSelectDic.Clear();

            IList<E_QuestionBank> banklist = GetExamQuestionList();
            AllQuestionNum = banklist.Count;
            this.labAllNum.Text = AllQuestionNum.ToString();

            this.labLeftNum.Text = AllQuestionNum.ToString();

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
        Dictionary<string, DevExpress.XtraEditors.XtraUserControl> controldic = new Dictionary<string, DevExpress.XtraEditors.XtraUserControl>();
        private void ViewQuestionPaper()
        {
            HasAnswerDic.Clear();
            controldic.Clear();
            XtraScrollableControl panel2 = xtraScrollableControl1;

            panel2.Controls.Clear();
            int x = 15;
            int y = 15;

            LabelControl pdlab = new LabelControl();
            pdlab.Font = labMB.Font;
            pdlab.Text = "一、判断题（ " + PdDic.Count + "道，每题" + ESet.JudgeScore + "分， 共计" + PdDic.Count * ESet.JudgeScore + "分 ）";
            pdlab.AutoSize = true;
            panel2.Controls.Add(pdlab);
            pdlab.Location = new Point(x, y);

            y = y + pdlab.Height + 5;

            int pdjs = 1;
            foreach (string key in PdDic.Keys)
            {
                E_QuestionBank eq=PdDic[key];
                UcExamTroQuestonPD pd = new UcExamTroQuestonPD(pdjs, eq);
                pd.AnswerEvent += new UcExamTroQuestonPD.AnswerQue(pd_AnswerEvent);
                panel2.Controls.Add(pd);
                pd.Location = new Point(x, y);
                y = y + pd.Height + 5;
                pdjs++;
                controldic.Add(eq.ID, pd);
            }


            LabelControl selectlab = new LabelControl();
            selectlab.Font = labMB.Font;
            selectlab.Text = "二、单项选择题（ " + SelectDic.Count + "道，每题" + ESet.SelectScore + "分， 共计" + SelectDic.Count * ESet.SelectScore + "分 ）";
            selectlab.AutoSize = true;
            panel2.Controls.Add(selectlab);
            selectlab.Location = new Point(x, y);
            y = y + selectlab.Height + 5;

            int selectjs = 1;
            foreach (string key in SelectDic.Keys)
            {
                E_QuestionBank eq = SelectDic[key];
                UcExamTroQuestonSlect select = new UcExamTroQuestonSlect(selectjs, eq);
                select.AnswerEvent += new UcExamTroQuestonSlect.AnswerQue(select_AnswerEvent);
                panel2.Controls.Add(select);
                select.Location = new Point(x, y);
                y = y + select.GetHeight + 5;
                selectjs++;
                controldic.Add(eq.ID, select);
            }

            Label muselectlab = new Label();
            muselectlab.Font = labMB.Font;
            muselectlab.Text = "三、多项选择题（ " + MuSelectDic.Count + "道，每题" + ESet.MuSelectScore + "分， 共计" + MuSelectDic.Count * ESet.MuSelectScore + "分 ）";
            muselectlab.AutoSize = true;
            panel2.Controls.Add(muselectlab);
            muselectlab.Location = new Point(x, y);
            y = y + muselectlab.Height + 5;

            int muselectjs = 1;
            foreach (string key in MuSelectDic.Keys)
            {
                E_QuestionBank eq = MuSelectDic[key];
                UcExamTroQuestonMuSlect muselect = new UcExamTroQuestonMuSlect(muselectjs, eq);
                muselect.AnswerEvent += new UcExamTroQuestonMuSlect.AnswerQue(muselect_AnswerEvent);
                panel2.Controls.Add(muselect);
                muselect.Location = new Point(x, y);
                y = y + muselect.GetHeight + 5;
                muselectjs++;
                controldic.Add(eq.ID, muselect);
            }

        }

        void muselect_AnswerEvent(string qid)
        {
            DealHasAnswer(qid);
        }

        void select_AnswerEvent(string qid)
        {
            DealHasAnswer(qid);
        }
        void pd_AnswerEvent(string qid)
        {
            DealHasAnswer(qid);
        }
        private void DealHasAnswer(string eqid)
        {
            if (!HasAnswerDic.ContainsKey(eqid))
            {
                HasAnswerDic.Add(eqid, eqid);
                LeftQuestionNum=AllQuestionNum-HasAnswerDic.Count;
                labLeftNum.Text = LeftQuestionNum.ToString();
            }
        }

        List<E_QuestionBank> Pdlist = new List<E_QuestionBank>();
        List<E_QuestionBank> Selectlist = new List<E_QuestionBank>();
        List<E_QuestionBank> MuSelectlist = new List<E_QuestionBank>();


        Dictionary<string, E_QuestionBank> PdDic = new Dictionary<string, E_QuestionBank>();
        Dictionary<string, E_QuestionBank> SelectDic = new Dictionary<string, E_QuestionBank>();
        Dictionary<string, E_QuestionBank> MuSelectDic = new Dictionary<string, E_QuestionBank>();

        Random rand = new Random();
        public IList<E_QuestionBank> GetExamQuestionList()
        {
            Pdlist.Clear();
            Selectlist.Clear();
            MuSelectlist.Clear();
            IList<E_QuestionBank> returnlist = new List<E_QuestionBank>();

            try
            {

                E_Examination exam = Exam;
                if (exam != null)
                {
                    E_ExaminationPaper eep = Client.ClientHelper.PlatformSqlMap.GetOneByKey<E_ExaminationPaper>(exam.EP_ID);
                    ESet = ClientHelper.PlatformSqlMap.GetOneByKey<E_ExamSetting>(eep.SettingID);
                    if (eep != null)
                    {
                        if (eep.Paper_Type == "指定试题")
                        {
                            //试题已经准备好了
                            if (eep.BySCol1 == "1")
                            {
                                string strtemp = " select QuID from E_ExaminationPaperQuestion where ExID='" + eep.ID + "'";
                                string stsqlwhere = " where ID in (" + strtemp + ") order by  Type";
                                IList<E_QuestionBank> banklist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_QuestionBank>(stsqlwhere);

                                if (banklist.Count > 0)
                                {
                                    foreach (E_QuestionBank item in banklist)
                                    {
                                        if (item.Type == "判断题")
                                        {
                                            Pdlist.Add(item);
                                        }
                                        if (item.Type == "单项选择题")
                                        {
                                            Selectlist.Add(item);
                                        }
                                        if (item.Type == "多项选择题")
                                        {
                                            MuSelectlist.Add(item);
                                        }
                                    }
                                    //随机顺序
                                    if (eep.OrderRandom)
                                    {
                                        int[] pdtemparray = ThisHelper.OrderINT(Pdlist.Count);
                                        for (int i = 0; i < pdtemparray.Length; i++)
                                        {
                                            returnlist.Add(Pdlist[pdtemparray[i]]);
                                        }
                                        int[] selecttemparray = ThisHelper.OrderINT(Selectlist.Count);
                                        for (int i = 0; i < selecttemparray.Length; i++)
                                        {
                                            returnlist.Add(Selectlist[selecttemparray[i]]);
                                        }
                                        int[] muselecttemparray = ThisHelper.OrderINT(MuSelectlist.Count);
                                        for (int i = 0; i < muselecttemparray.Length; i++)
                                        {
                                            returnlist.Add(MuSelectlist[muselecttemparray[i]]);
                                        }
                                    }
                                    else
                                    {
                                        for (int i = 0; i < Pdlist.Count; i++)
                                        {
                                            returnlist.Add(Pdlist[i]);
                                        }
                                        for (int i = 0; i < Selectlist.Count; i++)
                                        {
                                            returnlist.Add(Selectlist[i]);
                                        }
                                        int[] muselecttemparray = ThisHelper.OrderINT(MuSelectlist.Count);
                                        for (int i = 0; i < MuSelectlist.Count; i++)
                                        {
                                            returnlist.Add(MuSelectlist[i]);
                                        }

                                    }


                                }
                                //没有试题,则用随机试题
                                else
                                {
                                    CreateRandomQuestion(eep.SettingID, returnlist);
                                }

                            }
                            //没有准备好，则用随机试题
                            else
                            {
                                CreateRandomQuestion(eep.SettingID, returnlist);
                            }
                        }
                        else if (eep.Paper_Type == "随机试题")
                        {
                            CreateRandomQuestion(eep.SettingID, returnlist);

                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            return returnlist;
        }

        /// <summary>
        /// 生成随机试题
        /// </summary>
        /// <param name="SetId">设置ID</param>
        /// <param name="eqblist">结果表</param>
        /// <returns></returns>
        private bool CreateRandomQuestion(string SetId, IList<E_QuestionBank> eqblist)
        {

            bool hasst = true;
            string sqlwhere = " where ESETID='" + SetId + "'";
            IList<E_R_ESetPro> eresblist = Client.ClientHelper.PlatformSqlMap.GetList<E_R_ESetPro>(sqlwhere);

            foreach (E_R_ESetPro item in eresblist)
            {

                string sqlwherepd = " where Professional='" + item.PROID + "' and Type='判断题'  and ByScol1!='del' ";
                IList<E_QuestionBank> eqpdblist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_QuestionBank>(sqlwherepd);
                E_Professional ep = Client.ClientHelper.PlatformSqlMap.GetOneByKey<E_Professional>(item.PROID);

                RandSelectQuestion(eqpdblist, item.JudgeNUM, eqblist);

                string sqlwhereselect = " where Professional='" + item.PROID + "' and Type='单项选择题' and ByScol1!='del' ";
                IList<E_QuestionBank> eqselectblist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_QuestionBank>(sqlwhereselect);

                RandSelectQuestion(eqselectblist, item.SelectNUM, eqblist);

                string sqlwheremuselect = " where Professional='" + item.PROID + "' and Type='多项选择题' and ByScol1!='del' ";
                IList<E_QuestionBank> eqmuselectblist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_QuestionBank>(sqlwheremuselect);

                RandSelectQuestion(eqmuselectblist, item.MuSelectNUM, eqblist);

            }
            return hasst;
        }
        /// <summary>
        /// 从列表中随机取题
        /// </summary>
        /// <param name="eqlist">有试题的列表</param>
        /// <param name="randnum">选取试题数量</param>
        /// <param name="eqblist">生成的结果表</param>
        private void RandSelectQuestion(IList<E_QuestionBank> eqlist, int randnum, IList<E_QuestionBank> eqblist)
        {
            string type = eqlist[0].Type;
            int qunumall = eqlist.Count;
            //如果总试题数不多，小于2 倍的出题数，侧采用减少试题的方法
            if (eqlist.Count <= randnum * 2)
            {

                for (int i = 0; i < qunumall - randnum; i++)
                {
                    int index = rand.Next(eqlist.Count);
                    eqlist.RemoveAt(index);
                }
                AddQuestion(eqlist, eqblist);

            }
            else
            {
                //如果总试题比较多，侧采用抽选试题的方法
                Dictionary<string, E_QuestionBank> tempdic = new Dictionary<string, E_QuestionBank>();
                for (int i = 0; i < randnum; i++)
                {
                    bool hasdel = true;
                    while (hasdel)
                    {
                        int index = rand.Next(qunumall);
                        if (!tempdic.ContainsKey(eqlist[index].ID))
                        {
                            tempdic.Add(eqlist[index].ID, eqlist[index]);
                            hasdel = false;
                        }
                    }
                }
                AddQuestion(tempdic, eqblist);

            }

        }


        /// <summary>
        /// 从一个列表加入另一个列表
        /// </summary>
        /// <param name="frmeqlist">源表</param>
        /// <param name="toeqlist">目标表</param>
        private void AddQuestion(IList<E_QuestionBank> frmeqlist, IList<E_QuestionBank> toeqlist)
        {
            int i = 1;
            foreach (E_QuestionBank item in frmeqlist)
            {
                item.Sequence = i;
                toeqlist.Add(item);
                i++;
            }
            
        }
        /// <summary>
        /// 从一个集合加入另一个表
        /// </summary>
        /// <param name="dicold">源集合</param>
        /// <param name="toeqlist">目标表</param>
        private void AddQuestion(Dictionary<string, E_QuestionBank> dicold, IList<E_QuestionBank> toeqlist)
        {
            int i = 1;
            foreach (string item in dicold.Keys)
            {
                E_QuestionBank eq = dicold[item];
                eq.Sequence = i;
                toeqlist.Add(eq);
                i++;
            }
        }
        /// <summary>
        /// 是否已开始考试，true,之前已开始，false之前没有开始
        /// </summary>
        /// <param name="examid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool  SendExamStart()
        {
            bool result = true;

            try
            {
                E_Examination exam = Exam;
                ExamAllTime = double.Parse(exam.BySCol1) * 60;
                string sqlwhere = " where E_ID='" + exam.ID + "'  and EP_ID='" + exam.EP_ID + "' and UserID='" + UserID + "'";
                IList<E_ExamResult> erlist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_ExamResult>(sqlwhere);
                //没有考试，可以开始考试
                if (erlist.Count == 0)
                {
                    E_ExamResult er = new E_ExamResult();
                    er.E_ID = exam.ID;
                    er.EP_ID = exam.EP_ID;
                    er.UserID = UserID;
                    er.RealStartTime = GetSysTime();
                    er.IsExamed = false;
                    Client.ClientHelper.PlatformSqlMap.Create<E_ExamResult>(er);
                    result = false ;

                }
                else
                {
                    E_ExamResult eer = erlist[0];
                   HasExamTime= GetSysTime().Subtract(eer.RealStartTime).TotalSeconds;
                }

            }
            catch (Exception ee)
            {
            }
           return result;
        }
        /// <summary>
        /// true, 正常结束，false 异常
        /// </summary>
        /// <returns></returns>
        public bool  SendExamEnd()
        {
            bool result = false;
            try
            {
                E_Examination exam = Exam;
                string sqlwhere = " where E_ID='" + exam.ID + "'  and EP_ID='" + exam.EP_ID + "' and UserID='" + UserID + "'";
                IList<E_ExamResult> erlist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_ExamResult>(sqlwhere);
                if (erlist.Count > 0)
                {
                    erlist[0].RealEenTime = GetSysTime();
                    erlist[0].IsExamed = true;
                    Client.ClientHelper.PlatformSqlMap.Update<E_ExamResult>(erlist[0]);
                    //计算考试结果
                   CurrtenScore= CountExamResult();
                    result = true;
                }

            }
            catch (Exception ee)
            {
               
            }
            return result;
        }

        //是否多个地点考试已结束
        public bool ExamIsEnd()
        {
            bool result = false;
            try
            {
                E_Examination exam = Exam;
                string sqlwhere = " where E_ID='" + exam.ID + "'  and EP_ID='" + exam.EP_ID + "' and UserID='" + UserID + "'";
                IList<E_ExamResult> erlist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_ExamResult>(sqlwhere);
                if (erlist.Count > 0 && erlist[0].IsExamed)
                {
                    result = true;
                }

            }
            catch (Exception ee)
            {

            }
            return result;
        }
        //获取服务器时间
        private DateTime GetSysTime()
        {
            string sql = " Select CONVERT(varchar(100), GETDATE(), 20)";
            string timestr = Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", sql).ToString();
            DateTime dt = DateTime.Parse(timestr);
            return dt;
        }

        /// <summary>
        /// 计算分数
        /// </summary>
        /// <param name="examid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        private double  CountExamResult( )
        {

            E_Examination exam = Exam;
            E_ExaminationPaper expaper = Client.ClientHelper.PlatformSqlMap.GetOneByKey<E_ExaminationPaper>(exam.EP_ID);
            E_ExamSetting eset = Client.ClientHelper.PlatformSqlMap.GetOneByKey<E_ExamSetting>(expaper.SettingID);

            string sqlwhere = "  b.E_ID='" + exam.ID + "' and b.EP_ID='" + expaper.ID + "' and b.UserID='" + UserID + "'";
            IList<E_QuestionBank> qqblist = Client.ClientHelper.PlatformSqlMap.GetList<E_QuestionBank>("SelectE_QuestionBankCount", sqlwhere);

            double score = 0;
            for (int i = 0; i < qqblist.Count; i++)
            {
                if (qqblist[i].Type == "判断题")
                {
                    bool temp = false;
                    if (bool.TryParse(qqblist[i].Answer, out temp))
                    {
                        bool temp2 = false;
                        if (bool.TryParse(qqblist[i].BySCol5, out temp2))
                        {
                            if (temp == temp2)
                            {
                                score += eset.JudgeScore;
                            }
                        }

                    }

                }
                if (qqblist[i].Type == "单项选择题")
                {
                    if (qqblist[i].Answer.Trim() == qqblist[i].BySCol5.Trim())
                    {
                        score += eset.SelectScore;
                    }
                }
                if (qqblist[i].Type == "多项选择题")
                {
                    if (qqblist[i].Answer.Trim() == qqblist[i].BySCol5.Trim())
                    {
                        score += eset.MuSelectScore;
                    }
                }

            }
           

            string sqlresultwhere = " where E_ID='" + exam.ID + "' and EP_ID='" + expaper.ID + "' and UserID='" + UserID + "'";
            IList<E_ExamResult> resultlist = Client.ClientHelper.PlatformSqlMap.GetList<E_ExamResult>(sqlresultwhere);
            if (resultlist.Count > 0)
            {
                resultlist[0].Score =score;
                if (score>=ESet.PassScore)
                {
                    resultlist[0].IsPassed = true;
                }
                else
	            {
                    resultlist[0].IsPassed = false;
	            }
                
                resultlist[0].BySCol1 = "1";
                Client.ClientHelper.PlatformSqlMap.Update<E_ExamResult>(resultlist[0]);
            }
            return score;

        }

        //是否时间到
        bool TimeIsOut = false;
        //计时
        private void timer1_Tick(object sender, EventArgs e)
        {
            ExamLeftTime -= 1;
            ShowLeftTime();
            //时间到，自动提交
            if (ExamLeftTime<=0)
            {
                TimeIsOut = true;
                WaitDialogForm wait = new WaitDialogForm("", "考试时间已到，正在自动交卷，请不要关闭本程序，否则很可能没有成绩...");
                timer1.Enabled=false;
                btnOK.PerformClick();
                wait.Close();
            }
        }
        private void ShowLeftTime()
        {
            if (ExamLeftTime <= 0)
            {
                ExamLeftTime = 0;
            }
            int m = (int)(ExamLeftTime / 60);
            int s = (int)(ExamLeftTime % 60);
            
            labLeftTime.Text = m.ToString("00") + ":" + s.ToString("00");
        }
        private bool  SendAnswer()
        {
            bool result=false;

             E_Examination exam = Exam;
           
             string sqlwhere = " where E_ID='" + exam.ID + "' and EP_ID='" + exam .EP_ID+ "' and UserID='" + UserID + "'";
             Client.ClientHelper.PlatformSqlMap.DeleteByWhere<E_ExamAnswerResult>(sqlwhere);

                 int i = 0;
                 foreach (string key in controldic.Keys)
                 {
                     try
                     {

                         i++;
                         E_QuestionBank eq = controldic[key].Tag as E_QuestionBank;

                         E_ExamAnswerResult eear = new E_ExamAnswerResult();
                         eear.ID += i.ToString();
                         eear.E_ID = exam.ID;
                         eear.EP_ID = exam.EP_ID;
                         eear.UserID = UserID;
                         eear.ExamQueston_ID = eq.ID;
                         eear.ExamQuestonType = eq.Type;
                         eear.Answer = eq.BySCol5;
                         eear.RandomID = eq.Sequence.ToString();
                         Client.ClientHelper.PlatformSqlMap.Create<E_ExamAnswerResult>(eear);
                     }
                     catch (Exception)
                     {
                         
                         throw;
                     }
                     

                 }
                 result = true;

            
            return result;

        }
        DialogResult MsgAsk(string msg) {

            return MessageBoxEx.Show(this, msg, MsgBox.GetProductName(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        DialogResult MsgInfo(string msg) {

            return MessageBoxEx.Show(this, msg, MsgBox.GetProductName(),MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }
        //交卷
        private void btnOK_Click(object sender, EventArgs e)
        {
            //到时自动交卷
            if (TimeIsOut)
            {
                if ( !ExamIsEnd())
                {
                    SendAnswer();
                    SendExamEnd();
                    if (Exam.ShowResult)
                    {
                        MsgInfo("得分：" + CurrtenScore);
                        btnOK.Enabled = false;
                        labLeftTime.Text = "考试已结束！";
                        labAllNum.Text = "0";
                        labLeftNum.Text = "0";
                    }
                }
                else
                {
                    MsgInfo("您本次考试已结束，不能提交当前结果!");
                    btnOK.Enabled = false;
                    labLeftTime.Text = "考试已结束！";
                    labAllNum.Text = "0";
                    labLeftNum.Text = "0";
                }
                
            }
            else//主动交卷
            {
                if (MsgAsk("您确定要交卷吗？交卷后考试即结束！") == DialogResult.OK)
                {
                    if (!ExamIsEnd())
                    {
                        timer1.Enabled = false;
                        SendAnswer();
                        SendExamEnd();
                        if (Exam.ShowResult)
                        {
                            MsgInfo("得分：" + CurrtenScore);
                            btnOK.Enabled = false;
                            labLeftTime.Text = "考试已结束！";
                            labAllNum.Text = "0";
                            labLeftNum.Text = "0";
                        }
                    }
                    else
                    {
                        MsgInfo("您本次考试已结束，不能提交当前结果!");
                        btnOK.Enabled = false;
                        labLeftTime.Text = "考试已结束！";
                        labAllNum.Text = "0";
                        labLeftNum.Text = "0";
                    }
                    
                }
                
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (btnOK.Enabled)
            {
                if (MsgAsk("您确定要退出考试吗？您还没有交卷！") == DialogResult.OK)
                {
                    timer1.Enabled = false;
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
        int X_Value=0; 
        int Y_Value=0; 

        private void FrmUserExam_Activated(object sender, EventArgs e)
        {
            
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            //if (e.ScrollOrientation ==System.Windows.Forms.ScrollOrientation.HorizontalScroll)
            //{
            //    X_Value = e.NewValue;
            //}

            //if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
            //{
            //    Y_Value = e.NewValue;
            //}

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }
    }
    public class ThisHelper
    {
        /// <summary>
        /// 给定一个数，反回一个该数的随机顺序数组
        /// </summary>
        /// <param name="randomnum"></param>
        /// <returns></returns>
        public static int[] OrderINT(int randomnum)
        {
            Random rand = new Random();
            Dictionary<int, int> intdic = new Dictionary<int, int>();
            for (int i = 0; i < randomnum; i++)
            {
                bool has = false;
                while (!has)
                {
                    int tempint = rand.Next(randomnum);
                    if (!intdic.ContainsKey(tempint))
                    {
                        intdic.Add(tempint, tempint);
                        has = true;
                    }
                }

            }
            int[] order = new int[randomnum];
            int index = 0;
            foreach (int key in intdic.Keys)
            {
                order[index] = key;
                index++;
            }
            return order;
        }
    }
}
