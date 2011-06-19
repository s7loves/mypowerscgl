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
    public partial class fmSelectGroup :BaseForm_Single
    {
        public fmSelectGroup()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitializeUIData()
        {
            lvGroup.Columns.Add("角色名称", 100, HorizontalAlignment.Left);
            lvGroup.Columns.Add("groupId", 0, HorizontalAlignment.Left);
            lvGroup.Columns.Add("描述", 200, HorizontalAlignment.Left);

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
            string strSQL = "where  1=1 ";
            if (tbxGroupName.Text.Length == 0)
            {
                MsgBox.ShowWarningMessageBox ("请输入角色名称!");
                tbxGroupName.Focus();
                return;

            }
            lvGroup.Clear();
            InitializeUIData();
            DataTable dtSearch = null;
            if (tbxGroupName.Text != "")
                strSQL = strSQL + " and RoleName like '%" + tbxGroupName.Text + "%'";
            dtSearch = RoleGroupData.GetGroupTableByName(strSQL);

            foreach (DataRow dr in dtSearch.Rows)
            {
                ListViewItem lvi1 = new ListViewItem(dr["GroupName"].ToString(), 0);
                lvi1.SubItems.Add(dr["GroupId"].ToString());
                lvi1.SubItems.Add(dr["GroupDes"].ToString());
                lvGroup.Items.Add(lvi1);

            }

        }
        
    }
}

