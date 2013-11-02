using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;
using Ebada.Client;

namespace Ebada.Exam
{
    public partial class FrmExamSelect : DevExpress.XtraEditors.XtraForm
    {
        public FrmExamSelect()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ShowExam();
        }
        private void ShowExam()
        {
            string userid = MainHelper.User.UserID;
            string datatimestr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string sqlwhere = " where StartTime<'" + datatimestr + "' and EndTime>'" + datatimestr + "' and UserIDS like '%," + userid + ",%'  and  id not in( select E_ID from dbo.E_ExamResult where IsExamed=1 and UserID='" + userid + "' ) order by StartTime asc";
            IList<E_Examination> list =  Client.ClientHelper.PlatformSqlMap.GetList<E_Examination>(sqlwhere);
            if (list.Count==0)
            {
                label1.Text = "您最近不需要考试";
            }

            int index = 0;
            foreach (E_Examination item in list)
            {
                index++;
                Point lpoint = new Point();
                lpoint.X = 30;
                lpoint.Y = 10 + index * 25;
                LinkLabel ll = new LinkLabel();
                ll.Text = index+"、  "+ item.E_Name + "     " + item.StartTime.ToShortDateString() + " --" + item.EndTime.ToShortDateString(); ;
                ll.Tag = item;
                ll.Location = lpoint;
                ll.LinkClicked += new LinkLabelLinkClickedEventHandler(ll_LinkClicked);
                ll.AutoSize = true;
                panel1.Controls.Add(ll);
            }
        }

        void ll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            E_Examination ee = ((LinkLabel)sender).Tag as E_Examination;
              string sqlwhere = " where E_ID='" + ee.ID + "'  and EP_ID='" + ee.EP_ID + "' and UserID='" + MainHelper.User.UserID + "'";
                IList<E_ExamResult> erlist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_ExamResult>(sqlwhere);
            if (erlist.Count>0&&erlist[0].IsExamed)
            {
                MsgBox.ShowWarningMessageBox("您本次考试已经完成，不能重考！");
                return;
            }
            //开始考试
            if ( MsgBox.ShowAskMessageBox("您确定要开始考试码？开始后不能取消")==DialogResult.OK)
            {
                FrmUserExam frm = new FrmUserExam(MainHelper.User.UserID, ee);
                frm.ShowDialog();
            }
        }
    }
}
