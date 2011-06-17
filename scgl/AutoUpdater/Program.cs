using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.ComponentModel;

namespace EbadaAutoupdater
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #region check and download new version program
            bool bHasError = false;
            IAutoUpdater autoUpdater = new AutoUpdater();
            try {
                autoUpdater.Update();
            } catch (WebException exp) {
                MessageBox.Show("Can not find the specified resource");
                bHasError = true;
            } catch (XmlException exp) {
                bHasError = true;
                MessageBox.Show("Download the upgrade file error");
            } catch (NotSupportedException exp) {
                bHasError = true;
                MessageBox.Show("Upgrade address configuration error");
            } catch (ArgumentException exp) {
                bHasError = true;
                MessageBox.Show("Download the upgrade file error");
            } catch (Exception exp) {
                bHasError = true;
                MessageBox.Show("An error occurred during the upgrade process");
            } finally {
                if (bHasError == true) {
                    try {
                        autoUpdater.RollBack();
                    } catch (Exception) {
                        //Log the message to your file or database
                    }
                }
            }

            #endregion
            if (!bHasError) {
                //                
                try {
                    System.Diagnostics.Process.Start(Application.StartupPath + "\\Ebada.SCGL.exe");
                } catch (Win32Exception ex) {
                    MeBox(ex.Message);
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
