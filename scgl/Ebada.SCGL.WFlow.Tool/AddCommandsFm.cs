using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class fmAddCommands : BaseForm_Single
    {
        private string fmState="";
        public string CommandId = "";

        public fmAddCommands(string state)
        {
            InitializeComponent();
            fmState = state;


        }
        private void InitData()
        {
 
        }
        private void fmAddCommands_Load(object sender, EventArgs e)
        {
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

