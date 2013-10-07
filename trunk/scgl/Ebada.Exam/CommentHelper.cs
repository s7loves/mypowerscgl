using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using Ebada.Client;
using System.IO;

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
}
