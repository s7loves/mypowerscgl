using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ebada.Kcgl.Model;

namespace Ebada.Kcgl.App {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin dlg = new frmLogin();
            if (dlg.ShowDialog() == DialogResult.OK)
            Application.Run(new FrmSystem());
        }
    }
}
