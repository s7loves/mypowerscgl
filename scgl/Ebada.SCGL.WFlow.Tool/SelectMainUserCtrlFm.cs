using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Client;
using Ebada.UI.Base;
using Ebada.Client.Platform;



namespace Ebada.SCGL.WFlow.Tool
{
    public partial class fmSelectMainUserCtrl : BaseForm_Single
    {

        public System.Windows.Forms.ListView FatherUserview;
        string UserId = "";
        string UserName = "";
        public fmSelectMainUserCtrl(string iKey)
        {
            InitializeComponent();
            tbxCaption.Text = iKey;

        }
        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitializeUIData(string ikey )
        {
           
            //列出所有主表单
       
            lvMainUserCtrl.Columns.Add("主表单名", 200, HorizontalAlignment.Left);
            lvMainUserCtrl.Columns.Add("表单Id", 0, HorizontalAlignment.Left);
            lvMainUserCtrl.Columns.Add("描述", 200, HorizontalAlignment.Left);
            DataTable dtSearch = MainUserControl.GetMainUserControlByCaption(ikey);
            foreach (DataRow dr in dtSearch.Rows)
            {
                ListViewItem lvi1 = new ListViewItem(dr["CellName"].ToString(), 0);
                lvi1.SubItems.Add(dr["LPID"].ToString());
                lvi1.SubItems.Add(dr["CtrlType"].ToString());
                lvMainUserCtrl.Items.Add(lvi1);

            }
        }
        
       

        private void fmSelectUser_Load(object sender, EventArgs e)
        {
            InitializeUIData(tbxCaption.Text);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (tbxCaption.Text.Length == 0)
            //{
            //    MsgBox.ShowTipMessageBox ("请输入主表单名!");
            //    tbxCaption.Focus();
            //    return;
            //}
            lvMainUserCtrl.Clear();
            InitializeUIData(tbxCaption.Text);

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            //if (this.lvMainUserCtrl.SelectedItems.Count <= 0) return;
            //string key = lvMainUserCtrl.SelectedItems[0].SubItems[1].Text;
            //fmMainUserControl f = new fmMainUserControl(UserId, UserName, WorkConst.STATE_MOD, key);
            //f.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //fmMainUserControl f = new fmMainUserControl(UserId, UserName, WorkConst.STATE_ADD, "");
            //f.ShowDialog();
            FormBase dlg = new FormBase();
            UCmExcelTableControl tc = new UCmExcelTableControl();
            dlg.Text = "表单管理";
            dlg.WindowState = FormWindowState.Maximized;
            //dlg.MdiParent = MainHelper.MainForm;
            dlg.Controls.Add(tc);
            (tc).Dock = DockStyle.Fill;
            dlg.ShowDialog();
        }

        

       
    }
}

