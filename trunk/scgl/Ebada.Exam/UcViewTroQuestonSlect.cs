using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;

namespace Ebada.Exam
{
    public partial class UcViewTroQuestonSlect : DevExpress.XtraEditors.XtraUserControl
    {
        public UcViewTroQuestonSlect(int order, E_QuestionBank eq)
        {
            InitializeComponent();
            Order = order;
            EQ = eq;
            
        }
        char spchar = '@';
        private int JSheight(E_QuestionBank eq)
        {
            int intresult = 110;
            string[] a = eq.Option.Split(spchar);
            intresult = 110 + (a.Length - 1) * 30;

            if (intresult < 110)
            {
                intresult = 110;
            }
            return intresult;

        }
        /// <summary>
        /// 计算高度
        /// </summary>
        public int GetHeight
        {
            get
            {
                return JSheight(EQ);
            }
        }

        private int Order = 0;
        private E_QuestionBank EQ;

        public delegate void DelQue(string qid);
        public event DelQue DelEvent;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitData();
            if (Order % 2 == 0)
            {
                this.BackColor = System.Drawing.Color.PowderBlue;
            }
            else
            {
                this.BackColor = System.Drawing.Color.LightSkyBlue;
            }
            ShowAnswer();
        }
        private void ShowAnswer()
        {
            bool dn = false;
            if (DealAnswer())
            {
                //答案正确
                if (EQ.Answer.Trim() == EQ.BySCol5.Trim())
                {
                    labTG.Appearance.ForeColor = System.Drawing.Color.Green;
                    labShowAnswer.Text = " 【正确】";
                    labShowAnswer.Appearance.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    labTG.Appearance.ForeColor = System.Drawing.Color.Red;
                    labShowAnswer.Appearance.ForeColor = System.Drawing.Color.Red;
                    labShowAnswer.Text = " 【错误】 正确答案是【" + EQ.Answer.Trim() + "】  解释：" + EQ.Explain;

                }
            }
            else
            {
                labTG.Appearance.ForeColor = System.Drawing.Color.Sienna;
                labShowAnswer.Appearance.ForeColor = System.Drawing.Color.Sienna;
                labShowAnswer.Text = " 【您没有选择答案】 正确答案是 【" + EQ.Answer.Trim() + "】  解释：" + EQ.Explain;

            }
        }

        private bool  DealAnswer()
        {
            bool result=true;

            switch (EQ.BySCol5.Trim())
            {
                case "A":
                    rA.Checked = true;
                    break;
                case "B":
                    rB.Checked = true;
                    break;
                case "C":
                    rC.Checked = true;
                    break;
                case "D":
                    rD.Checked = true;
                    break;
                case "E":
                    rE.Checked = true;
                    break;
                case "F":
                    rF.Checked = true;
                    break;
                default:
                    result=false;
                    break;
            }
            return result;
        }
        private void InitData()
        {
            labQOrder.Text = Order.ToString() + "、";
            labTG.Text = EQ.Title;
            DealOperation(EQ.Option);
            this.Height = GetHeight;
        }
        string strchar = "、  ";
        private void DealOperation(string operatioin)
        {
            string[] a = operatioin.Split(spchar);
            for (int i = 0; i < a.Length; i++)
            {

                switch (i+1)
                {
                    case 1:
                        rA.Text ="A"+strchar+ a[i];
                        rA.Visible = true;
                        break;
                    case 2:
                        rB.Text = "B" + strchar + a[i];
                        rB.Visible = true;
                        break;
                    case 3:
                        rC.Text = "C" + strchar + a[i];
                        rC.Visible = true;
                        break;
                    case 4:
                        rD.Text = "D" + strchar + a[i];
                        rD.Visible = true;
                        break;
                    case 5:
                        rE.Text = "E" + strchar + a[i];
                        rE.Visible = true;
                        break;
                    case 6:
                        rF.Text = "F" + strchar + a[i];
                        rF.Visible = true;
                        break;
                    default:
                        break;
                }
            }
        }
       
 
    }
}
