using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Client;




namespace Ebada.SCGL.WFlow.Tool
{
    public partial class fmSelectUser : BaseForm_Single
    {

        public System.Windows.Forms.ListView FatherUserview;
        public fmSelectUser()
        {
            InitializeComponent();

        }
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        private void InitializeUIData()
        {
           
            //�г������û�
       
            lvUser.Columns.Add("�ʺ�", 100, HorizontalAlignment.Left);
            lvUser.Columns.Add("�û���", 100, HorizontalAlignment.Left);
            lvUser.Columns.Add("����", 200, HorizontalAlignment.Left);

        }
        
       

        private void fmSelectUser_Load(object sender, EventArgs e)
        {
            InitializeUIData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (tbxUserId.Text.Length == 0&&tbxUserName.Text.Length==0)
            //{
            //    MsgBox.ShowTipMessageBox ("�������ʺŻ����û���!");
            //    tbxUserId.Focus();
            //    return;
                
            //}
            //lvUser.Clear();
            //InitializeUIData();
            //DataTable dtSearch=null;
            //if (tbxUserId.Text.Length!=0)
            //{
            //    dtSearch = UserData.GetUserById(tbxUserId.Text);
            //}
            //else
            //    if (tbxUserName.Text.Length != 0)
            //    {
            //        dtSearch = UserData.GetUserByName(tbxUserName.Text);
            //    }
            //foreach (DataRow dr in dtSearch.Rows)
            //{
            //    ListViewItem lvi1 = new ListViewItem(dr["UserId"].ToString(), 0);
            //    lvi1.SubItems.Add(dr["UserName"].ToString());
            //    lvi1.SubItems.Add(dr["UserDes"].ToString());
            //    lvUser.Items.Add(lvi1);

            //}

        }

        

       
    }
}

