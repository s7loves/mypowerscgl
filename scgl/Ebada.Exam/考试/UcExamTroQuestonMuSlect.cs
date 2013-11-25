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
    public partial class UcExamTroQuestonMuSlect : DevExpress.XtraEditors.XtraUserControl
    {
        public UcExamTroQuestonMuSlect(int order, E_QuestionBank eq)
        {
            InitializeComponent();
            Order = order;
            EQ = eq;
            this.Tag = EQ;
        }
        char spchar = '@';
        private int JSheight(E_QuestionBank eq)
        {
            int intresult = 75;
            string[] a = eq.Option.Split(spchar);
            intresult = 75 + (a.Length - 1) * 30;

            if (intresult < 75)
            {
                intresult = 75;
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

        public delegate void AnswerQue(string qid);
        public event AnswerQue AnswerEvent;
        private void HasAnswer()
        {
            EQ.BySCol5 = GetAnswer();
            this.Tag = EQ;
            if (AnswerEvent != null)
            {
                AnswerEvent(EQ.ID);
            }
            
        }
        private string GetAnswer()
        {
            string result = string.Empty;
            if (cA.Checked)
            {
                result += "A";
            }
            if (cB.Checked)
            {
                result += "B";
            }
            if (cC.Checked)
            {
                result += "C";
            }
            if (cD.Checked)
            {
                result += "D";
            }
            if (cE.Checked)
            {
                result += "E";
            }
            if (cF.Checked)
            {
                result += "F";
            }

            return result;
        }
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

        private void cA_CheckedChanged(object sender, EventArgs e) {
            HasAnswer();
        }

        private void cB_CheckedChanged(object sender, EventArgs e) {
            HasAnswer();
        }

        private void cC_CheckedChanged(object sender, EventArgs e) {
            HasAnswer();
        }

        private void cD_CheckedChanged(object sender, EventArgs e) {
            HasAnswer();
        }

        private void cE_CheckedChanged(object sender, EventArgs e) {
            HasAnswer();
        }

        private void cF_CheckedChanged(object sender, EventArgs e) {
            HasAnswer();
        }
       

 
    }
}
