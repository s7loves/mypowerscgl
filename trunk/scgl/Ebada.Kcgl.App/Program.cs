using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ebada.Kcgl.Model;
using System.Collections;

namespace Ebada.Kcgl.App {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //testdictionary();
            
            //frmLogin dlg = new frmLogin();
            //if (dlg.ShowDialog() == DialogResult.OK)
            Application.Run(new FrmSystem());
        }
       static void testdatabase() {
            string str = Client.ClientHelper.TransportSqlMap.GetConnectionString();
            kc_材料名称表 obj = Client.ClientHelper.TransportSqlMap.GetOneByKey<kc_材料名称表>("1");
            Client.ClientHelper.TransportSqlMap.SetDatabase("ebadakcgl2");
            obj = Client.ClientHelper.TransportSqlMap.GetOneByKey<kc_材料名称表>("1");
            str = Client.ClientHelper.TransportSqlMap.GetConnectionString();
        }
       static void testdictionary(){
            IDictionary dic= Client.ClientHelper.TransportSqlMap.GetDictionary<kc_材料名称表>(null, kc_材料名称表.f_ID, null);

            dic = Client.ClientHelper.TransportSqlMap.GetDictionary<kc_材料名称表>(null, kc_材料名称表.f_ID, kc_材料名称表.f_材料代码);
        }
    }
}
