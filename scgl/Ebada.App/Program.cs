/**********************************************
系统:企业ERP
模块:启动模块
作者:Rabbit
创建时间:2011-6-16
最后一次修改:2011-6-17
***********************************************/
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ebada.App {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #region check and download new version program
            bool bHasError = false;
            EbadaAutoupdater.IAutoUpdater autoUpdater = new EbadaAutoupdater.AutoUpdater();
            try {
                autoUpdater.Update();
            } catch (System.Net.WebException exp) {
                MessageBox.Show("连接更新服务器失败！"+exp.Message);
                bHasError = true;
            } catch (System.Xml.XmlException exp) {
                bHasError = true;
                MessageBox.Show("读取版本信息失败！"+exp.Message);
            } catch (NotSupportedException exp) {
                bHasError = true;
                MessageBox.Show("读取版本信息失败！"+exp.Message);
            } catch (ArgumentException exp) {
                bHasError = true;
                MessageBox.Show("读取版本信息失败！"+exp.Message);
            } catch (Exception exp) {
                bHasError = true;
                MessageBox.Show("自动更新程序无法运行！"+exp.Message);
            } finally {
                if (bHasError == true) {
                    try {
                        autoUpdater.RollBack();
                    } catch (Exception) {
                    }
                }
            }

            #endregion
            if (!bHasError) {
                //                
                try {
                    System.Diagnostics.Process.Start(Application.StartupPath + "\\Ebada.SCGL.exe");
                } catch (System.ComponentModel.Win32Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                Application.Exit();
            }
        } 
        /// <summary>
        /// 弹出提示框
        /// </summary>
        /// <param name="txt">输入提示信息</param>
        private static void MeBox(string txt) {
            MessageBox.Show(
                txt,
                "提示信息",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
