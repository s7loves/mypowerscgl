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
            button2.Click += new EventHandler(button2_Click);
        }

        void button2_Click(object sender, EventArgs e) {
            showmodul(new UC材料名称() { Dock = DockStyle.Fill }, "材料名称");
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

        private void button5_Click(object sender, EventArgs e) {
            Client.ClientHelper.TransportSqlMap.SetDatabase("ebadakcgl");

        }

        private void button4_Click(object sender, EventArgs e) {
            Client.ClientHelper.TransportSqlMap.SetDatabase("ebadakcgl2");
        }

        private void button6_Click(object sender, EventArgs e) {
            IList<Model.kc_工程项目> list = Client.ClientHelper.TransportSqlMap.GetList<Model.kc_工程项目>(null);
            if (list.Count > 0)
                MessageBox.Show(list[0].工程类别);
        }
    }
}
