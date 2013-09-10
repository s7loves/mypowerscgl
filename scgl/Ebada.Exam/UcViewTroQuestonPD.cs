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
    public partial class UcViewTroQuestonPD : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 判断题
        /// </summary>
        /// <param name="order"></param>
        /// <param name="eq"></param>
        public UcViewTroQuestonPD(int order, E_QuestionBank eq)
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

        public    delegate void  DelQue(string qid);
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
            string str = string.Empty;
            if (bool.TryParse(EQ.BySCol5.Trim(), out dn))
            {
                if (dn)
                {
                    rOk.Checked = true;
                }
                else
                {
                    rError.Checked = true;
                }

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
                    if (bool.TryParse(EQ.Answer.Trim(), out dn))
                    {
                       
                        if (dn)
                        {
                            str = "√ ( 对 )";
                        }
                        else
                        {
                            str = "× ( 错 )";
                        }
                        labShowAnswer.Text = " 【错误】 正确答案是" + str + " 解释：" + EQ.Explain;
                    }
                    else
                    {
                        labShowAnswer.Text = " 【此题答案有问题】 请向管理员反应";
                    }



                }
            }
            else
            {
                labTG.Appearance.ForeColor = System.Drawing.Color.Sienna;
                labShowAnswer.Appearance.ForeColor = System.Drawing.Color.Sienna;
                labShowAnswer.Text = " 【您没有选择答案】 正确答案是" + str + " 解释：" + EQ.Explain;

            }
        }
        private void InitData()
        {
            labQOrder.Text = Order.ToString() + "、";
            labTG.Text = EQ.Title;
 
        }
       
      

 
    }
}
