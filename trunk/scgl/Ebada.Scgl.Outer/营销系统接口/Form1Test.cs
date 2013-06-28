using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ebada.Scgl.Outer
{
    public partial class Form1Test : Form
    {
        public Form1Test()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YYUpdate yd = new YYUpdate();
            yd.UpdateUserTable();
        }
    }
}
