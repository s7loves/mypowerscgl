using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UpDateService
{
   public  class UpdateLog
    {

        #region 读取和写入txt文件

        public static string BaseName = Application.StartupPath + "\\";

        public static string logname = "更新数据志日.txt";

        public static void WritLog(string content)
        {
            content = "\r\n时间：\r\n" + DateTime.Now.ToLongTimeString() + "\r\n内容：\r\n" + content;
            if (HasTxtFile(logname))
            {

                PushString(logname, content);
            }
            else
            {
                WriteTxt(content, logname);
            }
        }
        private  static void PushString(string txtname,string content)
        {
            FileStream fs = null;
            fs = new FileStream(BaseName + txtname, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(content);
            sw.Close();
         
        }
        public static string ReadFromTxt(string txtname)
        {
            string result = string.Empty;
            if (HasTxtFile(BaseName + txtname))
            {
                FileStream fs = null;
                fs = new FileStream(BaseName + txtname, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                result = sr.ReadLine();
                fs.Close();
            }
            return result;
        }

        public static void WriteTxt(string str, string txtname)
        {
            DeleteFile(txtname);
            FileStream fs = new FileStream(BaseName + txtname, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(str);
            sw.Close();
        }

        public static bool HasTxtFile(string txtname)
        {
            if (File.Exists(txtname))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void DeleteFile(string txtname)
        {
            if (HasTxtFile(BaseName + txtname))
            {
                File.Delete(BaseName + txtname);
            }
        }

        #endregion
    }
}
