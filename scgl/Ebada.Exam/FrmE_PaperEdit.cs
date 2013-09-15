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
            gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
        }
        TurnE_R_ESetPro currtenter;
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRow()!=null)
            {
                currtenter=gridView1.GetFocusedRow() as TurnE_R_ESetPro;
                CheckCanAdd();
            }
        }

        private void CheckCanAdd()
        {
            if (currtenter != null && currtenter.PROID != fixedid)
            {
                if (currtenter.JudgeNUM > currtenter.RealJudgeNUM || currtenter.SelectNUM > currtenter.RealSelectNUM || currtenter.MuSelectNUM > currtenter.RealMuSelectNUM)
                {
                    btnAdd.Enabled = true;
                }
                else
                {
                    btnAdd.Enabled = false;
                }
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }
        //试卷编号
        public string EPID = string.Empty;

        public IList<E_QuestionBank> EQlist;
        E_ExamSetting ESet;
        public string SetId = string.Empty;

        string fixedid = "010101";


        IList<E_R_ESetPro> ereslist;

        IList<TurnE_R_ESetPro> realereslist;

        TurnE_R_ESetPro realallere = new TurnE_R_ESetPro();

        Dictionary<string, E_QuestionBank> PdDic = new Dictionary<string, E_QuestionBank>();
        Dictionary<string, E_QuestionBank> SelectDic = new Dictionary<string, E_QuestionBank>();
        Dictionary<string, E_QuestionBank> MuSelectDic = new Dictionary<string, E_QuestionBank>();

        Dictionary<string, TurnE_R_ESetPro> RealEREPDic = new Dictionary<string, TurnE_R_ESetPro>();

        private void InitData()
        {
            PdDic.Clear();
            SelectDic.Clear();
            MuSelectDic.Clear();
            RealEREPDic.Clear();
            if (SetId != string.Empty)
            {
                //
                ESet = Client.ClientHelper.PlatformSqlMap.GetOneByKey<E_ExamSetting>(SetId);
                string sqlwhere = " where ESETID='" + SetId + "'";
                IList<E_R_ESetPro> eresblist = Client.ClientHelper.PlatformSqlMap.GetList<E_R_ESetPro>(sqlwhere);
                ereslist = eresblist;
                foreach (E_R_ESetPro item in eresblist)
                {
                    TurnE_R_ESetPro teres = new TurnE_R_ESetPro();
                    teres.ID = item.ID;
                    teres.PROID = item.PROID;
                    teres.JudgeNUM = item.JudgeNUM;
                    teres.SelectNUM = item.SelectNUM;
                    teres.MuSelectNUM = item.MuSelectNUM;
                    RealEREPDic.Add(teres.PROID, teres);
                }



                if (EPID != string.Empty)
                {
                    string sqlwhere2 = " where ExID='" + EPID + "'";
                    IList<E_ExaminationPaperQuestion> eepqlist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_ExaminationPaperQuestion>(sqlwhere2);
                    string str = string.Empty;
                    if (eepqlist.Count > 0)
                    {
                        foreach (E_ExaminationPaperQuestion item in eepqlist)
                        {
                            str += "'" + item.QuID + "' ,";
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
                                    RealEREPDic[item.Professional].RealJudgeNUM += 1;
                                }
                                if (item.Type == "单项选择题")
                                {
                                    SelectDic.Add(item.ID, item);
                                    RealEREPDic[item.Professional].RealSelectNUM += 1;
                                }
                                if (item.Type == "多项选择题")
                                {
                                    MuSelectDic.Add(item.ID, item);
                                    RealEREPDic[item.Professional].RealMuSelectNUM += 1;
                                }
                            }

                        }
                    }

                }
                ViewQuestionPaper();
            }


        }

        /// <summary>
        /// 显示设计题数和实际题数
        /// </summary>
        private void ShowSet()
        {
            //清空实际试题数量
            foreach (string item in RealEREPDic.Keys)
            {
                RealEREPDic[item].RealJudgeNUM = 0;
                RealEREPDic[item].RealSelectNUM = 0;
                RealEREPDic[item].RealMuSelectNUM = 0;
            }
            //计算实际判断题数量
            foreach (string key in PdDic.Keys)
            {
                RealEREPDic[PdDic[key].Professional].RealJudgeNUM += 1;
            }
            //计算实际选择题数量
            foreach (string key in SelectDic.Keys)
            {
                RealEREPDic[SelectDic[key].Professional].RealSelectNUM += 1;
            }
            //计算实际多项选择题数量
            foreach (string key in MuSelectDic.Keys)
            {
                RealEREPDic[MuSelectDic[key].Professional].RealMuSelectNUM += 1;
            }



            TurnE_R_ESetPro realere = new TurnE_R_ESetPro();
            realere.PROID = fixedid;

            List<TurnE_R_ESetPro> datalist = new List<TurnE_R_ESetPro>();
            foreach (string item in RealEREPDic.Keys)
            {
                TurnE_R_ESetPro temptere = RealEREPDic[item];
                datalist.Add(temptere);

                realere.JudgeNUM += temptere.JudgeNUM;
                realere.SelectNUM += temptere.SelectNUM;
                realere.MuSelectNUM += temptere.MuSelectNUM;

                realere.RealJudgeNUM += temptere.RealJudgeNUM;
                realere.RealSelectNUM += temptere.RealSelectNUM;
                realere.RealMuSelectNUM += temptere.RealMuSelectNUM;


            }
            realallere = realere;
            datalist.Add(realere);

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
        /// 按当前规则生成随机试题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRandPaper_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowAskMessageBox("您确定要生成随机试题吗？当前试题将被删除") == DialogResult.OK)
            {
                if (CreateRandomQuestion())
                {
                    ViewQuestionPaper();
                }
            }
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
                UcTroQuestonPD pd = new UcTroQuestonPD(pdjs, PdDic[key]);
                pd.DelEvent += new UcTroQuestonPD.DelQue(pd_DelEvent);
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
                y = y + muselect.GetHeight + 5;
                muselectjs++;
            }
            ShowSet();
            CheckPaperQNum();
        }


        private bool  CheckPaperQNum()
        {
            bool result = true;

            string str = string.Empty;

            if (realallere.JudgeNUM != PdDic.Count)
            {
                str += " 判断题数量应为【" + realallere.JudgeNUM + "】道，目前缺少【" + (realallere.JudgeNUM - PdDic.Count) + "】道;";
            }
            if (realallere.SelectNUM != SelectDic.Count)
            {
                str += " 单项选择题数量应为【" + realallere.SelectNUM + "】道，目前缺少【" + (realallere.SelectNUM - SelectDic.Count) + "】道;";
            }
            if (realallere.MuSelectNUM != MuSelectDic.Count)
            {
                str += " 多项选择题数量应为【" + realallere.MuSelectNUM + "】道，目前缺少【" + (realallere.MuSelectNUM - MuSelectDic.Count) + "】道;";
            }
            if (str.Length > 1)
            {
                str = "提示：" + str;
                labWaring.Text = str;
                labWaring.Visible = true;
                btnAddQ.Enabled = true;
                result = false;
            }
            else
            {
                labWaring.Visible = false;
                btnAddQ.Enabled = false;
            }
            return result;
        }
        /// <summary>
        /// 删除判断题
        /// </summary>
        /// <param name="qid"></param>
        void pd_DelEvent(string qid)
        {
            if (PdDic.ContainsKey(qid))
            {
                PdDic.Remove(qid);
            }
        }
        /// <summary>
        /// 删除单项选择题
        /// </summary>
        /// <param name="qid"></param>
        void select_DelEvent(string qid)
        {
            if (SelectDic.ContainsKey(qid))
            {
                SelectDic.Remove(qid);
            }
        }
        /// <summary>
        /// 删除多项选择题
        /// </summary>
        /// <param name="qid"></param>
        void muselect_DelEvent(string qid)
        {
            if (MuSelectDic.ContainsKey(qid))
            {
                MuSelectDic.Remove(qid);
            }
        }

        /// <summary>
        /// 生成随机试题
        /// </summary>
        /// <returns></returns>
        private bool CreateRandomQuestion()
        {
            PdDic.Clear();
            SelectDic.Clear();
            MuSelectDic.Clear();
            bool hasst = true;
            foreach (E_R_ESetPro item in ereslist)
            {
                //统计时临时加上的一个标识
                if (item.PROID != fixedid)
                {
                    string sqlwherepd = " where Professional='" + item.PROID + "' and Type='判断题' and ByScol1!='del'";
                    IList<E_QuestionBank> eqpdblist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_QuestionBank>(sqlwherepd);
                    E_Professional ep = Client.ClientHelper.PlatformSqlMap.GetOneByKey<E_Professional>(item.PROID);
                    if (eqpdblist.Count < item.JudgeNUM)
                    {
                        MsgBox.ShowWarningMessageBox("请选维护试题，专业[" + ep.PName + "]判断题数量只有" + eqpdblist.Count + "道，到少需要" + item.JudgeNUM + "道!");
                        hasst = false;
                        break;
                    }
                    RandSelectQuestion(eqpdblist, item.JudgeNUM);

                    string sqlwhereselect = " where Professional='" + item.PROID + "' and Type='单项选择题' and ByScol1!='del'";
                    IList<E_QuestionBank> eqselectblist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_QuestionBank>(sqlwhereselect);
                    if (eqselectblist.Count < item.SelectNUM)
                    {
                        MsgBox.ShowWarningMessageBox("请选维护试题，专业[" + ep.PName + "]单项选择题数量只有" + eqselectblist.Count + "道，到少需要" + item.SelectNUM + "道!");
                        hasst = false;
                        break;
                    }
                    RandSelectQuestion(eqselectblist, item.SelectNUM);

                    string sqlwheremuselect = " where Professional='" + item.PROID + "' and Type='多项选择题' and ByScol1!='del'";
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

        /// <summary>
        /// 根据随机数和指定列表，选出随机试题
        /// </summary>
        /// <param name="eqlist"></param>
        /// <param name="randnum"></param>
        private void RandSelectQuestion(IList<E_QuestionBank> eqlist, int randnum)
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
                if (type == "判断题")
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

        /// <summary>
        /// 将列表中的数据填加到字典中
        /// </summary>
        /// <param name="eqlist"></param>
        /// <param name="dic"></param>
        private void AddQuestion(IList<E_QuestionBank> eqlist, Dictionary<string, E_QuestionBank> dic)
        {
            foreach (E_QuestionBank item in eqlist)
            {
                dic.Add(item.ID, item);
            }
        }
        /// <summary>
        /// 将一个字典中的数据加到另一个字典中
        /// </summary>
        /// <param name="dicold"></param>
        /// <param name="dic"></param>
        private void AddQuestion(Dictionary<string, E_QuestionBank> dicold, Dictionary<string, E_QuestionBank> dic)
        {
            foreach (string item in dicold.Keys)
            {
                dic.Add(item, dicold[item]);
            }
        }
        /// <summary>
        /// 刷新试卷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewQuestionPaper();
        }
      
        /// <summary>
        /// 从列表中生成随机数量的度题，添加到字典中
        /// </summary>
        /// <param name="fromeqlist"></param>
        /// <param name="randnum"></param>
        /// <param name="ToDic"></param>
        private void RandAddQuestion(IList<E_QuestionBank> fromeqlist, int randnum, Dictionary<string, E_QuestionBank> ToDic)
        {

            for (int i = 0; i < randnum; i++)
            {
                bool hasdel = true;
                while (hasdel)
                {
                    int index = rand.Next(fromeqlist.Count);
                    if (!ToDic.ContainsKey(fromeqlist[index].ID))
                    {
                        ToDic.Add(fromeqlist[index].ID, fromeqlist[index]);
                        hasdel = false;
                    }
                }
            }



        }
        /// <summary>
        /// 补齐试题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddQ_Click(object sender, EventArgs e)
        {

            foreach (string key in RealEREPDic.Keys)
            {
                TurnE_R_ESetPro item = RealEREPDic[key];
                //缺少判断题
                if (item.JudgeNUM > item.RealJudgeNUM)
                {
                    string sqlwherepd = " where Professional='" + item.PROID + "' and Type='判断题'  and ByScol1!='del'";
                    IList<E_QuestionBank> eqpdblist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_QuestionBank>(sqlwherepd);
                    RandAddQuestion(eqpdblist, (item.JudgeNUM - item.RealJudgeNUM), PdDic);

                }

                //缺少单项选择题
                if (item.SelectNUM > item.RealSelectNUM)
                {
                    string sqlwherepd = " where Professional='" + item.PROID + "' and Type='单项选择题' and ByScol1!='del'";
                    IList<E_QuestionBank> eqpdblist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_QuestionBank>(sqlwherepd);
                    RandAddQuestion(eqpdblist, (item.SelectNUM - item.RealSelectNUM), SelectDic);

                }

                //缺少多面选择题
                if (item.MuSelectNUM > item.RealMuSelectNUM)
                {
                    string sqlwherepd = " where Professional='" + item.PROID + "' and Type='多项选择题' and ByScol1!='del'";
                    IList<E_QuestionBank> eqpdblist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_QuestionBank>(sqlwherepd);
                    RandAddQuestion(eqpdblist, (item.MuSelectNUM - item.RealMuSelectNUM), MuSelectDic);

                }
            }
            ViewQuestionPaper();
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckPaperQNum())
            {
                ShowSet();
                MsgBox.ShowWarningMessageBox("当前试题数量不够，请补齐试题！");
                return;
            }
            EQlist = new List<E_QuestionBank>();

            string del = " where ExID='" + EPID + "'";
            Client.ClientHelper.PlatformSqlMap.DeleteByWhere<E_ExaminationPaperQuestion>(del);

            int i = 0;
            foreach (string key in PdDic.Keys)
            {
                i++;
                E_ExaminationPaperQuestion eepq = new E_ExaminationPaperQuestion();
                eepq.ID += i.ToString();
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

        private void AddDic(Dictionary<string, E_QuestionBank> FromDic, Dictionary<string, E_QuestionBank> ToDic)
        {
            foreach (string key in FromDic.Keys)
            {
                if (!ToDic.ContainsKey(key))
                {
                    ToDic.Add(key, FromDic[key]);

                }
            }
        }
        private void DelDic(Dictionary<string, E_QuestionBank> dic, string proid)
        {
            foreach (string key in dic.Keys)
            {
                if (dic[key].Professional == proid)
                {
                    dic.Remove(key);
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dictionary<string, E_QuestionBank> TempPdDic = new Dictionary<string, E_QuestionBank>();
            Dictionary<string, E_QuestionBank> TempSelectDic = new Dictionary<string, E_QuestionBank>();
            Dictionary<string, E_QuestionBank> TempMuSelectDic = new Dictionary<string, E_QuestionBank>();

            foreach (string  key in PdDic.Keys)
            {
                if (PdDic[key].Professional==currtenter.PROID)
                {
                    TempPdDic.Add(key, PdDic[key]);
                }

            }
            foreach (string key in SelectDic.Keys)
            {
                if (SelectDic[key].Professional == currtenter.PROID)
                {
                    TempSelectDic.Add(key, PdDic[key]);
                }

            }
            foreach (string key in MuSelectDic.Keys)
            {
                if (MuSelectDic[key].Professional == currtenter.PROID)
                {
                    TempMuSelectDic.Add(key, PdDic[key]);
                }

            }
            FrmE_AddQuestion frm = new FrmE_AddQuestion(currtenter, TempPdDic, TempSelectDic, TempMuSelectDic);

            if (frm.ShowDialog()==DialogResult.OK)
            {
                DelDic(PdDic, currtenter.PROID);
                DelDic(SelectDic, currtenter.PROID);
                DelDic(MuSelectDic, currtenter.PROID);

                AddDic(frm.PdDic, PdDic);
                AddDic(frm.SelectDic, SelectDic);
                AddDic(frm.MuSelectDic, MuSelectDic);

                ViewQuestionPaper();
            }
        }

       
    }
}