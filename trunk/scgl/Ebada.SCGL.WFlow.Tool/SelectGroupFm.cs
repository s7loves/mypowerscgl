using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class fmSelectGroup :BaseForm_Single
    {
        public fmSelectGroup()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        private void InitializeUIData()
        {
            lvGroup.Columns.Add("��ɫ����", 100, HorizontalAlignment.Left);
            lvGroup.Columns.Add("groupId", 0, HorizontalAlignment.Left);
            lvGroup.Columns.Add("����", 200, HorizontalAlignment.Left);

        }

        private void plclassFill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SelectGroupFm_Load(object sender, EventArgs e)
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
            //if (tbxGroupName.Text.Length == 0)
            //{
            //    WorkDialog.InformationDlg("�������ɫ����!", "�������ѯ����");
            //    tbxGroupName.Focus();
            //    return;

            //}
            //lvGroup.Clear();
            //InitializeUIData();
            //DataTable dtSearch = null;

            //dtSearch = GroupData.GetGroupTableByName(tbxGroupName.Text);

            //foreach (DataRow dr in dtSearch.Rows)
            //{
            //    ListViewItem lvi1 = new ListViewItem(dr["GroupName"].ToString(), 0);
            //    lvi1.SubItems.Add(dr["GroupId"].ToString());
            //    lvi1.SubItems.Add(dr["GroupDes"].ToString());
            //    lvGroup.Items.Add(lvi1);

            //}

        }
        
    }
}

