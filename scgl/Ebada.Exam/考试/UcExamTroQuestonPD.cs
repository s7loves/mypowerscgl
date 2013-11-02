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
    public partial class UcExamTroQuestonPD : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 判断题
        /// </summary>
        /// <param name="order"></param>
        /// <param name="eq"></param>
        public UcExamTroQuestonPD(int order, E_QuestionBank eq)
        {
            InitializeComponent();
            Order = order;
            EQ = eq;
            
        }
        /// <summary>
        /// 计算高度
        /// </summary>
        public int GetHeight
        {
            get
            {
                return this.Height;
            }
        }
        private int Order = 0;
        private E_QuestionBank EQ;

        public    delegate void  AnswerQue(string qid);
        public event AnswerQue AnswerEvent;

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
 
        }

        private void rOk_CheckedChanged(object sender, EventArgs e)
        {
            HasAnswer();
            if (rOk.Checked)
            {
                EQ.BySCol5 = "True";
            }
            else
            {
                EQ.BySCol5 = "";
            }
            this.Tag = EQ;
        }

        private void rError_CheckedChanged(object sender, EventArgs e)
        {
            HasAnswer();
            if (rError.Checked)
            {
                EQ.BySCol5 = "False";
            }
            else
            {
                EQ.BySCol5 = "";
            }
            this.Tag = EQ;
        }

        private void HasAnswer()
        {
            if (AnswerEvent!=null)
            {
                AnswerEvent(EQ.ID);
            }
        }

 
    }
}
