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
    public partial class UcTroQuestonPD : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 判断题
        /// </summary>
        /// <param name="order"></param>
        /// <param name="eq"></param>
        public UcTroQuestonPD( int order,E_QuestionBank eq)
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
        }
        private void InitData()
        {
            labQOrder.Text = Order.ToString() + "、";
            labTG.Text = EQ.Title;
            labTGB.Text = EQ.Title;

        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (DelEvent!=null)
            {
                Del();
            }
        }
        private void Del()
        {
            DelEvent(EQ.ID);
            labTS.Visible = true;
            btnDel.Enabled = false;
            labTG.Visible = false;
            labTGB.Visible = true;
        }

 
    }
}
