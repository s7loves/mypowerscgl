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
            IList<Model.材料名称表> mm= Ebada.Client.ClientHelper.TransportSqlMap.GetList<Model.材料名称表>(null);
            Application.Run(new Form1());
        }
    }
}
