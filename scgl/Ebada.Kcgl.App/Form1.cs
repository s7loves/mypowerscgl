using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ebada.Kcgl.App {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        void showmodul(UserControl c,string text) {
            Form dlg = new Form();
            dlg.Text = text;
            dlg.Size = new Size(800, 600);
            dlg.StartPosition = FormStartPosition.CenterScreen;
            dlg.Controls.Add(c);
            dlg.Show();
        }
        private void button1_Click(object sender, EventArgs e) {

            showmodul(new UC工程项目() { Dock = DockStyle.Fill },button1.Text);
        }
    }
}
