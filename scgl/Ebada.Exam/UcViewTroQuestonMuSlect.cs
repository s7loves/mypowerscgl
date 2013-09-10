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
    public partial class UcViewTroQuestonMuSlect : DevExpress.XtraEditors.XtraUserControl
    {
        public UcViewTroQuestonMuSlect(int order, E_QuestionBank eq)
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
            intresult= 110 + (a.Length - 1) * 30;

            if (intresult<110)
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

        private bool DealAnswer()
        {
            bool result = true;
            string dastr = EQ.BySCol5.Trim();
            if (dastr.Contains("A"))
            {
                cA.Checked = true;
            }
            if (dastr.Contains("B"))
            {
                cB.Checked = true;
            }
            if (dastr.Contains("C"))
            {
                cC.Checked = true;
            }
            if (dastr.Contains("D"))
            {
                cD.Checked = true;
            }
            if (dastr.Contains("E"))
            {
                cE.Checked = true;
            }
            if (dastr.Contains("F"))
            {
                cF.Checked = true;
            }
            if (dastr.Length==0)
            {
                result = false;
            }
            return result;
        }
        private void InitData()
        {
            labQOrder.Text = Order.ToString() + "、";
            labTG.Text = EQ.Title;
            labTGB.Text = EQ.Title;
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
                        cA.Text ="A"+strchar+ a[i];
                        cA.Visible = true;
                        break;
                    case 2:
                        cB.Text = "B" + strchar + a[i];
                        cB.Visible = true;
                        break;
                    case 3:
                        cC.Text = "C" + strchar + a[i];
                        cC.Visible = true;
                        break;
                    case 4:
                        cD.Text = "D" + strchar + a[i];
                        cD.Visible = true;
                        break;
                    case 5:
                        cE.Text = "E" + strchar + a[i];
                        cE.Visible = true;
                        break;
                    case 6:
                        cF.Text = "F" + strchar + a[i];
                        cF.Visible = true;
                        break;
                    default:
                        break;
                }
            }
        }
       

 
    }
}
