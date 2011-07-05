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
    public partial class fmSelectClass : BaseForm_Single
    {
        public string workflowClassId = "";
        public fmSelectClass()
        {
            InitializeComponent();
          
        }
       

        private void SelectDutyFm_Load(object sender, EventArgs e)
        {
            WorkFlowClassTreeNode.LoadWorkFlowClass("####", tvWorkClass.Nodes);
            tvWorkClass.ExpandAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tvWorkClass.SelectedNode != null)
            {
                workflowClassId = (tvWorkClass.SelectedNode as WorkFlowClassTreeNode).NodeId;
                Close();
            }
            else
            {
                MsgBox.ShowWarningMessageBox ("请选择流程分类!");
            }
           
        }

        private void tvArch_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void tvWorkClass_DoubleClick(object sender, EventArgs e)
        {
            workflowClassId = (tvWorkClass.SelectedNode as WorkFlowClassTreeNode).NodeId;
            Close();
        }
    }
}

