using System;
using System.Collections.Generic;
using System.Text;

namespace Ebada.SCGL.WFlow.Tool
{
    public class BaseTreeNode : System.Windows.Forms.TreeNode
    {
        public string NodeType = "";
        public string NodeId = "";
        public string FatherNodeId = "";
        public string Description;
        public string MgrUrl = "";

    }
}
