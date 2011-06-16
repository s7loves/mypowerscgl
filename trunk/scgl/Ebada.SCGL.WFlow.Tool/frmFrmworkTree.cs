using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ebada.SCGL.WorkFlow.Tool
{
    public partial class frmFrmworkTree : Form
    {
        public frmFrmworkTree()
        {
            InitializeComponent();
        }
        public frmFrmworkTree(string state, string iInfoId, FrmworkTreeNode node)
        {
            InitializeComponent();
            formState = state;
            InfoId = iInfoId;
            nowTreeNode = node;

            if (formState == "新建")
            {
                this.Text = "新建";
                this.tbxFatherCaption.Text = nowTreeNode.Text;

            }
            else
            {
                this.Text = "修改";
                getInfoById();
            }

        }
        private string formState;//窗体状态，是修改还是新建
        private string InfoId;//操做主键
        private FrmworkTreeNode nowTreeNode;//当前节点


       

       
        private void getInfoById()
        {
            this.tbxNodeCaption.Text = nowTreeNode.Text;
            this.tbxFatherCaption.Text = nowTreeNode.FatherCaption;
            this.tbxDllFile.Text = nowTreeNode.DllFileName;
            this.tbxClassName.Text = nowTreeNode.DllClassName;
            this.tbxMethodName.Text = nowTreeNode.DllMethodName;
            this.tbxFormName.Text = nowTreeNode.FormName;
            this.cbxBlankWindow.Checked = nowTreeNode.BlankWindows;
            this.cbxSDIWindows.Checked = nowTreeNode.WindowsSDI;
            this.cbxMouseClick.Checked = nowTreeNode.MouseIsClick;
            this.cbxVisable.Checked = nowTreeNode.CanVisable;
            this.cmbxNodeType.SelectedIndex = cmbxNodeType.Items.IndexOf(nowTreeNode.NodeType);
            this.cmbxImageIndex.SelectedIndex = nowTreeNode.ImageIndex;


        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (formState == "新建")
            {
                FrmworkTreeNode tmpNodeInfo = new FrmworkTreeNode();
                tmpNodeInfo.FatherId = nowTreeNode.NodeId;
                tmpNodeInfo.NodeId = Guid.NewGuid().ToString();
                tmpNodeInfo.Text = this.tbxNodeCaption.Text;

                tmpNodeInfo.FatherCaption = this.tbxFatherCaption.Text;
                tmpNodeInfo.DllFileName = this.tbxDllFile.Text;
                tmpNodeInfo.DllClassName = this.tbxClassName.Text;
                tmpNodeInfo.DllMethodName = this.tbxMethodName.Text;
                tmpNodeInfo.FormName = this.tbxFormName.Text;
                tmpNodeInfo.BlankWindows = this.cbxBlankWindow.Checked;
                tmpNodeInfo.WindowsSDI = this.cbxSDIWindows.Checked;
                tmpNodeInfo.MouseIsClick = this.cbxMouseClick.Checked;
                tmpNodeInfo.CanVisable = this.cbxVisable.Checked;
                tmpNodeInfo.NodeType = this.cmbxNodeType.Items[cmbxNodeType.SelectedIndex].ToString();
                tmpNodeInfo.ImageIndex = this.cmbxImageIndex.SelectedIndex;
                tmpNodeInfo.AddNodeInfo();
                nowTreeNode.Nodes.Add(tmpNodeInfo);

            }
            else
            {

                nowTreeNode.Text = this.tbxNodeCaption.Text;
                nowTreeNode.FatherCaption = this.tbxFatherCaption.Text;
                nowTreeNode.DllFileName = this.tbxDllFile.Text;
                nowTreeNode.DllClassName = this.tbxClassName.Text;
                nowTreeNode.DllMethodName = this.tbxMethodName.Text;
                nowTreeNode.FormName = this.tbxFormName.Text;
                nowTreeNode.BlankWindows = this.cbxBlankWindow.Checked;
                nowTreeNode.WindowsSDI = this.cbxSDIWindows.Checked;
                nowTreeNode.MouseIsClick = this.cbxMouseClick.Checked;
                nowTreeNode.CanVisable = this.cbxVisable.Checked;
                nowTreeNode.NodeType = this.cmbxNodeType.Items[cmbxNodeType.SelectedIndex].ToString();
                nowTreeNode.ImageIndex = this.cmbxImageIndex.SelectedIndex;
                nowTreeNode.ModifyNodeInfo();


            }
            this.Close();


        }

        private void cmbxNodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxNodeType.SelectedItem.ToString() == "Function")
            {
                grpCommand.Enabled = false;
                tbxMethodName.Enabled = true;
            }
            else
                if (cmbxNodeType.SelectedItem.ToString() == "Window")
                {
                    grpCommand.Enabled = true;
                    tbxMethodName.Enabled = false;
                }

        }
    }
}
