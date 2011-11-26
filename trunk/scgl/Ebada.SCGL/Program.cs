using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ebada.SCGL
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ICSharpCode.SharpZipLib.Zip.FastZip fz=new ICSharpCode.SharpZipLib.Zip.FastZip();
            string direct = AppDomain.CurrentDomain.BaseDirectory + "\\msg";
            string zipFile = AppDomain.CurrentDomain.BaseDirectory+"\\msg\\msg.zip";
            if (System.IO.File.Exists(zipFile)) {
                killmsg();
                try {
                    fz.ExtractZip(zipFile, direct, ICSharpCode.SharpZipLib.Zip.FastZip.Overwrite.Always, null, null, null, false);
                    if(!zipFile.Contains("output"))
                        System.IO.File.Delete(zipFile);
                } catch { }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            //DevExpress.Utils.Localization.AccLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressUtilsLocalizationCHS();
            DevExpress.XtraBars.Localization.BarLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraBarsLocalizationCHS();
            //DevExpress.XtraCharts.Localization.ChartLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraChartsLocalizationCHS();
            DevExpress.XtraEditors.Controls.Localizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraEditorsLocalizationCHS();
            DevExpress.XtraGrid.Localization.GridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraGridLocalizationCHS();
            DevExpress.XtraLayout.Localization.LayoutLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraLayoutLocalizationCHS();
            DevExpress.XtraNavBar.NavBarLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraNavBarLocalizationCHS();
            //DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraPivotGridLocalizationCHS();
            DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraPrintingLocalizationCHS();
            DevExpress.XtraReports.Localization.ReportLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraReportsLocalizationCHS();
            //DevExpress.XtraRichTextEdit.Localization.XtraRichTextEditLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraRichTextEditLocalizationCHS();
            //DevExpress.XtraRichEdit.Localization.XtraRichEditLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraRichEditLocalizationCHS();
            DevExpress.XtraScheduler.Localization.SchedulerLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraSchedulerLocalizationCHS();
            DevExpress.XtraScheduler.Localization.SchedulerExtensionsLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraSchedulerExtensionsLocalizationCHS();
            DevExpress.XtraSpellChecker.Localization.SpellCheckerLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraSpellCheckerLocalizationCHS();
            DevExpress.XtraTreeList.Localization.TreeListLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraTreeListLocalizationCHS();
            //DevExpress.XtraVerticalGrid.Localization.VGridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraVerticalGridLocalizationCHS();
            //DevExpress.XtraWizard.Localization.WizardLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraWizardLocalizationCHS();
            //frmLogin dlg = new frmLogin(); 
            //if (dlg.ShowDialog() == DialogResult.OK)
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Application.ThreadExit += new EventHandler(Application_ThreadExit);
                Application.Run(new frmMain2());
        }

        static void Application_ThreadExit(object sender, EventArgs e) {
            killmsg();
        }

        static void Application_ApplicationExit(object sender, EventArgs e) {
            killmsg();
        }
        
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
            Client.MsgBox.ShowException(e.Exception);
        }
        public static void killmsg() {
            System.Diagnostics.Process[] pTemp = System.Diagnostics.Process.GetProcesses();
            int n = 0;

            foreach (System.Diagnostics.Process pTempProcess in pTemp)
                if ((pTempProcess.ProcessName.ToLower() == ("Ebada.MsgClient").ToLower()) || (pTempProcess.ProcessName.ToLower()) == ("Ebada.MsgClient.exe").ToLower()) {
                    pTempProcess.Kill();
                }
        }

    }
}
