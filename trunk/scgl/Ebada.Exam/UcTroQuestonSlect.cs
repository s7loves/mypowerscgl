﻿using System;
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
    public partial class UcTroQuestonSlect : DevExpress.XtraEditors.XtraUserControl
    {
        public UcTroQuestonSlect(int order, E_QuestionBank eq)
        {
            InitializeComponent();
            Order = order;
            EQ = eq;
            
        }
        char spchar = '@';
        private int JSheight(E_QuestionBank eq)
        {
            int intresult = 75;
            string[] a = eq.Option.Split(spchar);
            intresult= 75 + (a.Length - 1) * 30;

            if (intresult<75)
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
