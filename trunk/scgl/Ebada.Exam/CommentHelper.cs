using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using Ebada.Client;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Ebada.Exam
{
    public class CommentHelper
    {

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool SaveFile(byte[] byt,string type)
        {
            bool result = false;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文件类型|*" + type;
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                WaitDialogForm wait = new WaitDialogForm("", "正在下载数据, 请稍候...");
                try
                {
                    GetFile(byt, sfd.FileName);
                    wait.Close();
                    if (MsgBox.ShowAskMessageBox("下载已完成，是否打开文件？") == DialogResult.OK)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(sfd.FileName);
                        }
                        catch { System.Diagnostics.Process.Start(sfd.FileName); }
                    }

                }
                catch
                {
                    wait.Close();
                }
            }
            return result;
        }
        public static void GetFile(byte[] bt, string filename)
        {
            BinaryWriter bw;
            FileStream fs;
            try
            {
                fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                bw = new BinaryWriter(fs);
                bw.Write(bt);
                bw.Flush();
                bw.Close();
                fs.Close();

            }
            catch
            {

            }
        }
    }
    /// <summary>
    /// Selected Win AI Function Calls
    /// </summary>

    public class WinApi {
        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int which);

        [DllImport("user32.dll")]
        public static extern void
            SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter,
                         int X, int Y, int width, int height, uint flags);

        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;
        private static IntPtr HWND_TOP = IntPtr.Zero;
        private const int SWP_SHOWWINDOW = 64; // 0x0040

        public static int ScreenX {
            get { return GetSystemMetrics(SM_CXSCREEN); }
        }

        public static int ScreenY {
            get { return GetSystemMetrics(SM_CYSCREEN); }
        }

        public static void SetWinFullScreen(IntPtr hwnd) {
            SetWindowPos(hwnd, HWND_TOP, 0, 0, ScreenX, ScreenY, SWP_SHOWWINDOW);
        }
    }

    /// <summary>
    /// Class used to preserve / restore state of the form
    /// </summary>
    public class FormState {
        private FormWindowState winState;
        private FormBorderStyle brdStyle;
        private bool topMost;
        private Rectangle bounds;

        private bool IsMaximized = false;

        public void Maximize(Form targetForm) {
            if (!IsMaximized) {
                IsMaximized = true;
                Save(targetForm);
                targetForm.WindowState = FormWindowState.Maximized;
                //targetForm.FormBorderStyle = FormBorderStyle.None;
                targetForm.TopMost = true;
                WinApi.SetWinFullScreen(targetForm.Handle);
            }
        }

        public void Save(Form targetForm) {
            winState = targetForm.WindowState;
            brdStyle = targetForm.FormBorderStyle;
            topMost = targetForm.TopMost;
            bounds = targetForm.Bounds;
        }

        public void Restore(Form targetForm) {
            targetForm.WindowState = winState;
            targetForm.FormBorderStyle = brdStyle;
            targetForm.TopMost = topMost;
            targetForm.Bounds = bounds;
            IsMaximized = false;
        }
    }
}
