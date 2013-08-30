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
    public partial class FrmE_PaperEdit : DevExpress.XtraEditors.XtraForm
    {
        public FrmE_PaperEdit()
        {
            InitializeComponent();
        }

        //试卷编号
        public string EPID = string.Empty;

        public IList<E_QuestionBank> EQlist;
        E_ExamSetting ESet;
        public   string SetId = string.Empty;

        IList<E_R_ESetPro> ereslist;

        Dictionary<string, E_QuestionBank> PdDic = new Dictionary<string, E_QuestionBank>();
        Dictionary<string, E_QuestionBank> SelectDic = new Dictionary<string, E_QuestionBank>();
        Dictionary<string, E_QuestionBank> MuSelectDic = new Dictionary<string, E_QuestionBank>();

        private void InitData()
        {
            PdDic.Clear();
            SelectDic.Clear();
            MuSelectDic.Clear();
            if (SetId!=string.Empty)
            {
                //
                ESet = Client.ClientHelper.PlatformSqlMap.GetOneByKey<E_ExamSetting>(SetId);
                string sqlwhere = " where ESETID='" + SetId + "'";
                IList<E_R_ESetPro> eresblist = Client.ClientHelper.PlatformSqlMap.GetList<E_R_ESetPro>(sqlwhere);
                ereslist = eresblist;
                E_R_ESetPro ere = new E_R_ESetPro();
                ere.PROID = "010101";
                
                foreach (E_R_ESetPro item in eresblist)
                {
                    ere.JudgeNUM += item.JudgeNUM;
                    ere.SelectNUM += item.SelectNUM;
                    ere.MuSelectNUM += item.MuSelectNUM;

                }
                eresblist.Add(ere);

                gridControl1.DataSource = eresblist;
                gridView1.Columns["PROID"].ColumnEdit = DicTypeHelper.E_proDicTB;
                gridView1.Columns["JudgeNUM"].Width = 80;
                gridView1.Columns["SelectNUM"].Width = 80;
                gridView1.Columns["MuSelectNUM"].Width = 80;
            }
            if (EPID!=string.Empty)
            {
                string sqlwhere = " where ExID='" + EPID + "'";
                IList<E_ExaminationPaperQuestion> eepqlist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_ExaminationPaperQuestion>(sqlwhere);

                string str = string.Empty;
                if (eepqlist.Count>0)
                {
                    foreach (E_ExaminationPaperQuestion item in eepqlist)
                    {
                        str += "'"+item.QuID + "' ,";
                    }
                    str = str.Substring(0, str.Length - 1);

                    string stsqlwhere = " where ID in (" + str + ")";
                    IList<E_QuestionBank> banklist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_QuestionBank>(stsqlwhere);
                    if (banklist.Count > 0)
                    {
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
                }
               
               
               
            }
           
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitData();
        }
        /// <summary>
        /// 按当前规则生成随机试题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRandPaper_Click(object sender, EventArgs e)
        {
            if (CreateRandomQuestion())
            {
                ViewQuestionPaper();
            }
           
        }
        private void ViewQuestionPaper()
        {
            panel1.Controls.Clear();
            int x=15;
            int y=15;

            LabelControl pdlab = new LabelControl();
            pdlab.Font = labMB.Font;
            pdlab.Text = "一、判断题（ " + PdDic.Count + "道，每题" + ESet.JudgeScore + "分， 共计" + PdDic.Count * ESet.JudgeScore + "分 ）";
            pdlab.AutoSize = true;
            panel1.Controls.Add(pdlab);
            pdlab.Location = new Point(x, y);

            y = y + pdlab.Height + 5;
            

            int pdjs = 1;
            foreach (string  key in PdDic.Keys)
            {
                UcTroQuestonPD pd = new UcTroQuestonPD(pdjs, PdDic[key]);
                pd.DelEvent +=new UcTroQuestonPD.DelQue(pd_DelEvent);
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
                UcTroQuestonSlect select = new UcTroQuestonSlect(selectjs, SelectDic[key]);
                select.DelEvent += new UcTroQuestonSlect.DelQue(select_DelEvent);
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
                UcTroQuestonMuSlect muselect = new UcTroQuestonMuSlect(muselectjs, MuSelectDic[key]);
                muselect.DelEvent += new UcTroQuestonMuSlect.DelQue(muselect_DelEvent);
                panel1.Controls.Add(muselect);
                muselect.Location = new Point(x, y);
                y = y + muselect.GetHeight +5;
                muselectjs++;
            }
        }
        void pd_DelEvent(string qid)
        {
            if (PdDic.ContainsKey(qid))
            {
                PdDic.Remove(qid);
            }
        }
        void select_DelEvent(string qid)
        {
            if (SelectDic.ContainsKey(qid))
            {
                SelectDic.Remove(qid);
            }
        }

        void muselect_DelEvent(string qid)
        {
            if (MuSelectDic.ContainsKey(qid))
            {
                MuSelectDic.Remove(qid);
            }
        }

       
       
        private bool CreateRandomQuestion()
        {
            PdDic.Clear();
            SelectDic.Clear();
            MuSelectDic.Clear();
            bool hasst = true;
            foreach (E_R_ESetPro item in ereslist)
            {
                //统计时临时加上的一个标识
                if (item.PROID != "010101")
                {
                    string sqlwherepd = " where Professional='" + item.PROID + "' and Type='判断题'";
                    IList<E_QuestionBank> eqpdblist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_QuestionBank>(sqlwherepd);
                    E_Professional ep = Client.ClientHelper.PlatformSqlMap.GetOneByKey<E_Professional>(item.PROID);
                    if (eqpdblist.Count < item.JudgeNUM)
                    {
                        MsgBox.ShowWarningMessageBox("请选维护试题，专业[" + ep.PName + "]判断题数量只有" + eqpdblist.Count + "道，到少需要" + item.JudgeNUM + "道!");
                        hasst = false;
                        break;
                    }
                    RandSelectQuestion(eqpdblist, item.JudgeNUM);

                    string sqlwhereselect = " where Professional='" + item.PROID + "' and Type='单项选择题'";
                    IList<E_QuestionBank> eqselectblist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_QuestionBank>(sqlwhereselect);
                    if (eqselectblist.Count < item.SelectNUM)
                    {
                        MsgBox.ShowWarningMessageBox("请选维护试题，专业[" + ep.PName + "]单项选择题数量只有" + eqselectblist.Count + "道，到少需要" + item.SelectNUM + "道!");
                        hasst = false;
                        break;
                    }
                    RandSelectQuestion(eqselectblist, item.SelectNUM);

                    string sqlwheremuselect = " where Professional='" + item.PROID + "' and Type='多项选择题'";
                    IList<E_QuestionBank> eqmuselectblist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_QuestionBank>(sqlwheremuselect);
                    if (eqmuselectblist.Count < item.MuSelectNUM)
                    {
                        MsgBox.ShowWarningMessageBox("请选维护试题，专业[" + ep.PName + "]多项选择题数量只有" + eqmuselectblist.Count + "道，到少需要" + item.MuSelectNUM + "道!");
                        hasst = false;
                        break;
                    }
                    RandSelectQuestion(eqmuselectblist, item.MuSelectNUM);
                }
                
            }
            return hasst;
        }
        Random rand = new Random();
        private void RandSelectQuestion(IList<E_QuestionBank> eqlist, int randnum)
        {
            string type = eqlist[0].Type;
            int qunumall = eqlist.Count;
            //如果总试题数不多，小于2 倍的出题数，侧采用减少试题的方法
            if (eqlist.Count<=randnum*2)
            {
               
                for (int i = 0; i < qunumall-randnum; i++)
                {
                    int index = rand.Next(eqlist.Count);
                    eqlist.RemoveAt(index);
                }
                if (type=="判断题")
                {
                    AddQuestion(eqlist, PdDic);
                }
                if (type == "单项选择题")
                {
                    AddQuestion(eqlist, SelectDic);
                }
                if (type == "多项选择题")
                {
                    AddQuestion(eqlist, MuSelectDic);
                }
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
                if (type == "判断题")
                {
                    AddQuestion(tempdic, PdDic);
                }
                if (type == "单项选择题")
                {
                    AddQuestion(tempdic, SelectDic);
                }
                if (type == "多项选择题")
                {
                    AddQuestion(tempdic, MuSelectDic);
                }
            }
            
        }
        

        private void AddQuestion(IList<E_QuestionBank> eqlist, Dictionary<string, E_QuestionBank> dic)
        {
            foreach (E_QuestionBank item in eqlist)
            {
                dic.Add(item.ID, item);
            }
        }
        private void AddQuestion(Dictionary<string, E_QuestionBank> dicold, Dictionary<string, E_QuestionBank> dic)
        {
            foreach (string  item in dicold.Keys)
            {
                dic.Add(item, dicold[item]);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewQuestionPaper();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EQlist = new List<E_QuestionBank>();

            string del = " where ExID='" + EPID + "'";
            Client.ClientHelper.PlatformSqlMap.DeleteByWhere<E_ExaminationPaperQuestion>(del);

            int i=0;
            foreach (string key in PdDic.Keys)
            {
                i++;
                E_ExaminationPaperQuestion eepq = new E_ExaminationPaperQuestion();
                eepq.ID+=i.ToString();
                eepq.ExID = EPID;
                eepq.QuID = key;
                eepq.QuType = "判断题";
                Client.ClientHelper.PlatformSqlMap.Create<E_ExaminationPaperQuestion>(eepq);

            }
            foreach (string key in SelectDic.Keys)
            {
                i++;
                E_ExaminationPaperQuestion eepq = new E_ExaminationPaperQuestion();
                eepq.ID += i.ToString();
                eepq.ExID = EPID;
                eepq.QuID = key;
                eepq.QuType = "单项选择题";
                Client.ClientHelper.PlatformSqlMap.Create<E_ExaminationPaperQuestion>(eepq);

            }
            foreach (string key in MuSelectDic.Keys)
            {
                i++;
                E_ExaminationPaperQuestion eepq = new E_ExaminationPaperQuestion();
                eepq.ID += i.ToString();
                eepq.ExID = EPID;
                eepq.QuID = key;
                eepq.QuType = "多项选择题";
                Client.ClientHelper.PlatformSqlMap.Create<E_ExaminationPaperQuestion>(eepq);

            }
            this.DialogResult = DialogResult.OK;

        }
    }
}