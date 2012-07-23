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

            string str = Client.ClientHelper.TransportSqlMap.GetConnectionString();
            kc_材料名称表 obj = Client.ClientHelper.TransportSqlMap.GetOneByKey<kc_材料名称表>("1");
            Client.ClientHelper.TransportSqlMap.SetDatabase("ebadakcgl2");
            obj = Client.ClientHelper.TransportSqlMap.GetOneByKey<kc_材料名称表>("1");
            str = Client.ClientHelper.TransportSqlMap.GetConnectionString();
            //frmLogin dlg = new frmLogin();
            //if (dlg.ShowDialog() == DialogResult.OK)
            Application.Run(new Form1());
        }
    }
}
