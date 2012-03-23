using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using System.IO;
namespace Ebada.Scgl.Lcgl
{
    class Ecommon
    {

        /// <summary>
        ///取汉字的首字母
        /// </summary>
        /// <param name="strText">输入汉字串</param>

        /// <returns>string<string> </returns>
        public static string GetChineseSpell(string strText)
        {
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                myStr += getSpell(strText.Substring(i, 1));
            }
            return myStr;
        }
        private static string getSpell(string cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "*";
            }
            else return cnChar;
        }

        /// <summary>
        ///返回三位编号
        /// </summary>
        /// <param name="count">数字</param>

        /// <returns>string<string> </returns>

        public static string GenBH(int count)
        {
            return count.ToString("000");
        }
        /// <summary>
        ///判断前几个字是否重复
        /// </summary>
        /// <param name="inputString">输入字符串</param>
        /// <param name="bpstring">判断的字符</param>
        /// <returns>bool<string> </returns>
        public static bool Comparestring(string inputstring, string bpstring)
        {
            int length = bpstring.Length;
            if (!string.IsNullOrEmpty(inputstring.Trim()))
            {
                if (string.Equals(inputstring.Substring(0, length), bpstring))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;

        }

        /// <summary>
        ///按指定长度截断字符串
        /// </summary>
        /// <param name="inputString">输入字符串</param>
        /// <param name="len">指定长度</param>
        /// <returns>返回List<string> </returns>
        public static List<string> ResultStrList(string inputString, int len)
        {
            List<string> RList = new List<string>();
            ASCIIEncoding ascii = new ASCIIEncoding();
            string[] lines = inputString.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                int tempLen = 0;
                string tempString = "";

                byte[] s = ascii.GetBytes(line);
                for (int i = 0; i < s.Length; i++)
                {
                    if ((int)s[i] == 63)
                    {
                        tempLen += 2;
                    }
                    else
                    {
                        tempLen += 1;
                    }
                    tempString += line.Substring(i, 1);
                    if (tempLen >= len && i <= (s.Length - 1))
                    {
                        RList.Add(tempString);
                        tempString = "";
                        tempLen = 0;
                    }
                    else if (i == (s.Length - 1) && tempLen < len)
                    {
                        RList.Add(tempString);
                    }

                }
            }
            ////寻找标点是否在第一个 则加到上一个字符中
            //for (int i = 1; i < RList.Count;i++ )
            //{
            //    if (RList[i].Substring(0, 1) == "，" || RList[i].Substring(0, 1) == "。")
            //    {
            //        RList[i - 1] += RList[i].Substring(0, 1);
            //        RList[i].Remove(0, 1);
            //    }
            //}
            return RList;


        }
        //寻找标点是否在第一个 则加到上一个字符中
        public static void Resultstrbystartbd(ref List<string> RList)
        {
            for (int i = 1; i < RList.Count; i++)
            {
                if (RList[i].Substring(0, 1) == "，" || RList[i].Substring(0, 1) == "。" || RList[i].Substring(0, 1) == "、" || RList[i].Substring(0, 1) == "：" || RList[i].Substring(0, 1) == "！")
                {
                    RList[i - 1] += RList[i].Substring(0, 1);
                    RList[i] = RList[i].Substring(1);
                }
            }

        }
        /// <summary>
        /// 根据给定条件截取字符串（可解决换页问题）
        /// </summary>
        /// <param name="fixstr">换页时的固定字符（如：“活动内容：”）</param>
        /// <param name="inputString">内容字符(不要添加固定字符)</param>
        /// <param name="len">截取长度</param>
        /// <param name="onepagerows">每页显示行数</param>
        /// <returns></returns>
        public static List<string> ResultStrListByPage(string fixstr, string inputString, int len, int onepagerows)
        {

            fixstr = fixstr.Trim();
            inputString = inputString.Trim();
            bool mustbreak = false;
            string firststr = fixstr + inputString;
            List<string> strRnlist = ResultStrList(firststr, len);
            List<string> RList = new List<string>();
            ASCIIEncoding ascii = new ASCIIEncoding();
            int fixlen = strleng(fixstr);

            int coutrows = 0;

            for (int j = 0; j < strRnlist.Count; j++)
            {
                int tempLen = 0;
                string tempString = "";
                firststr = strRnlist[j];
                byte[] s = ascii.GetBytes(firststr);

                for (int i = 0; i < s.Length; i++)
                {
                    if ((int)s[i] == 63)
                    {
                        tempLen += 2;
                    }
                    else
                    {
                        tempLen += 1;
                    }

                    tempString += firststr.Substring(i, 1);
                    if (tempLen >= len && i <= (s.Length - 1))
                    {
                        RList.Add(tempString);
                        tempString = "";
                        tempLen = 0;
                        coutrows++;
                    }
                    else if (i == (s.Length - 1) && tempLen < len)
                    {
                        RList.Add(tempString);
                        coutrows++;
                    }
                    //换页
                    if (coutrows >= onepagerows)
                    {
                        coutrows = 0;
                        tempString = fixstr;
                        tempLen = fixlen;
                    }
                }
            }
            Resultstrbystartbd(ref RList);
            return RList;
        }
        /// <summary>
        /// 根据给定条件截取字符串（可解决换页问题） 原来的
        /// </summary>
        /// <param name="fixstr">换页时的固定字符（如：“活动内容：”）</param>
        /// <param name="inputString">内容字符(不要添加固定字符)</param>
        /// <param name="len">截取长度</param>
        /// <param name="onepagerows">每页显示行数</param>
        /// <returns></returns>
        public static List<string> ResultStrListByPagenr(string fixstr, string inputString, int len, int onepagerows)
        {
            fixstr = fixstr.Trim();
            inputString = inputString.Trim();
            bool mustbreak = false;
            string firststr = fixstr + inputString;
            List<string> RList = new List<string>();
            ASCIIEncoding ascii = new ASCIIEncoding();
            int fixlen = strleng(fixstr);
            int tempLen = 0;
            int coutrows = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(firststr);

            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                tempString += firststr.Substring(i, 1);
                if (tempLen >= len && i <= (s.Length - 1))
                {
                    RList.Add(tempString);
                    tempString = "";
                    tempLen = 0;
                    coutrows++;
                }
                else if (i == (s.Length - 1) && tempLen < len)
                {
                    RList.Add(tempString);
                    coutrows++;
                }
                //换页
                if (coutrows >= onepagerows)
                {
                    coutrows = 0;
                    tempString = fixstr;
                    tempLen = fixlen;
                }
            }
            return RList;


        }
        /// <summary>
        /// 返回字符串字符长度（中文字符长为2，非中文为1）
        /// </summary>
        /// <param name="inputstr">输入字符串</param>
        /// <returns></returns>
        public static int strleng(string inputstr)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputstr);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }
            }
            return tempLen;
        }

        /// <summary>
        /// 返回list集合中的全部字符list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<string> GetCollList(System.Collections.ArrayList list)
        {
            List<string> allList = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                List<string> l = list[i] as List<string>;
                for (int j = 0; j < l.Count; j++)
                {
                    allList.Add(l[j]);
                }
            }
            return allList;
        }

        public static int GetPagecount(int sum, int rowcount)
        {
            if (rowcount != 0)
            {
                if (sum % rowcount != 0)
                {
                    return (sum / rowcount + 1);
                }
                else
                {
                    return sum / rowcount;
                }
            }
            else
                return 1;

        }
        /// <summary>
        ///创建工作表并将数据加入到工作表中
        /// </summary>
        /// <param name="ex">操作EXCEL表</param>
        /// <param name="bdzlist">填入的数据组</param>
        ///  <param name="hs">每一个对应的行数</param>
        ///  <param name="stawz">每一个对应的要填写的位置</param>
        ///  <param name="pageindex">分的工作表的数目</param>
        /// <returns>返回List<string> </returns>
        public static void CreatandWritesheet(ExcelAccess ex, List<string>[] bdzlist, int[] hs, int[] stawz)
        {
            int pageindex = 1;
            for (int i = 0; i < bdzlist.Length; i++)
            {
                if (pageindex < GetPagecount(bdzlist[i].Count, hs[i]))
                {
                    pageindex = GetPagecount(bdzlist[i].Count, hs[i]);
                }
            }
            for (int j = 1; j <= pageindex; j++)
            {
                if (j > 1)
                {
                    ex.CopySheet(0, j + 1);
                    ex.ActiveSheet(j + 1);
                }
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 2 + 1;
                int endrow = j * 2;
                for (int num = 0; num < bdzlist.Length; num++)
                {
                    if (bdzlist[num].Count > endrow)
                    {
                        for (int i = 0; i < hs[num]; i++)
                        {
                            ex.SetCellValue(bdzlist[num][starow - 1 + i], stawz[num] + i, 1);
                        }
                    }
                    else if (bdzlist[num].Count <= endrow && bdzlist[num].Count >= starow)
                    {
                        for (int i = 0; i < bdzlist[num].Count - starow + 1; i++)
                        {
                            ex.SetCellValue(bdzlist[num][starow - 1 + i], stawz[num] + i, 1);
                        }
                    }
                }


            }
        }
        /// <summary>
        ///创建工作表并将数据加入到工作表中
        /// </summary>
        /// <param name="ex">操作EXCEL表</param>
        /// <param name="bdzlist">填入的数据</param>
        ///  <param name="hs">一页对应的总行数</param>
        ///  <param name="stawz">一页中填入的开始的位置</param>
        ///  <param name="pageindex">一页填入的列位置</param>

        public static void CreatandWritesheet(ExcelAccess ex, List<string> bdzlist, int hs, int star, int clm)
        {
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(bdzlist.Count, hs))
            {
                pageindex = Ecommon.GetPagecount(bdzlist.Count, hs);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                if (j > 1)
                {
                    ex.CopySheet(1, 1);

                }
            }
            ex.ShowExcel();
            for (int j = 1; j <= pageindex; j++)
            {

                ex.ActiveSheet(j);
                ex.ReNameWorkSheet(j, "Sheet" + (j));
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * hs + 1;
                int endrow = j * hs;
                if (bdzlist.Count > endrow)
                {
                    for (int i = 0; i < hs; i++)
                    {

                        ex.SetCellValue(bdzlist[starow - 1 + i], star + i, clm);
                        //ex.SetCellValue(objlist[starow - 1 + i].rq.Month.ToString(), rowcount + i, 1);
                        //ex.SetCellValue(objlist[starow - 1 + i].rq.Day.ToString(), rowcount + i, 2);
                        //ex.SetCellValue(objlist[starow - 1 + i].rq.Hour.ToString(), rowcount + i, 3);
                        //ex.SetCellValue(objlist[starow - 1 + i].rq.Minute.ToString(), rowcount + i, 4);
                        //ex.SetCellValue(objlist[starow - 1 + i].lxfs, rowcount + i, 5);
                        //ex.SetCellValue(objlist[starow - 1 + i].yhdz, rowcount + i, 6);
                        //ex.SetCellValue(objlist[starow - 1 + i].gzjk, rowcount + i, 7);
                        //ex.SetCellValue(objlist[starow - 1 + i].djr, rowcount + i, 8);
                        //ex.SetCellValue(objlist[starow - 1 + i].clr, rowcount + i, 9);

                    }
                }
                else if (bdzlist.Count <= endrow && bdzlist.Count >= starow)
                {
                    for (int i = 0; i < bdzlist.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(bdzlist[starow - 1 + i], star + i, clm);
                        //ex.SetCellValue(objlist[starow - 1 + i].rq.Month.ToString(), rowcount + i, 1);
                        //ex.SetCellValue(objlist[starow - 1 + i].rq.Day.ToString(), rowcount + i, 2);
                        //ex.SetCellValue(objlist[starow - 1 + i].rq.Hour.ToString(), rowcount + i, 3);
                        //ex.SetCellValue(objlist[starow - 1 + i].rq.Minute.ToString(), rowcount + i, 4);
                        //ex.SetCellValue(objlist[starow - 1 + i].lxfs, rowcount + i, 5);
                        //ex.SetCellValue(objlist[starow - 1 + i].yhdz, rowcount + i, 6);
                        //ex.SetCellValue(objlist[starow - 1 + i].gzjk, rowcount + i, 7);
                        //ex.SetCellValue(objlist[starow - 1 + i].djr, rowcount + i, 8);
                        //ex.SetCellValue(objlist[starow - 1 + i].clr, rowcount + i, 9);

                    }
                }
            }
        }

        /// <summary>
        ///创建工作表并将数据加入到工作表中
        /// </summary>
        /// <param name="ex">操作EXCEL表</param>
        /// <param name="bdzlist">填入的数据</param>
        ///  <param name="hs">一页对应的总行数</param>
        ///  <param name="stawz">一页中填入的开始的位置</param>
        ///  <param name="pageindex">一页填入的列位置</param>
        ///  <param name="strnumcol">第一个字符开始的行数</param>
        ///  <param name="boldnum">加粗的数量</param>
        public static void CreatandWritesheet1(ExcelAccess ex, List<string> bdzlist, int hs, int star, int clm, int[] strnumcol, int[] boldnum)
        {
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(bdzlist.Count, hs))
            {
                pageindex = Ecommon.GetPagecount(bdzlist.Count, hs);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                if (j > 1)
                {
                    ex.CopySheet(1, 1);

                }
            }
            ex.ShowExcel();
            for (int j = 1; j <= pageindex; j++)
            {

                ex.ActiveSheet(j);
                ex.ReNameWorkSheet(j, "Sheet" + (j));
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * hs + 1;
                int endrow = j * hs;
                if (bdzlist.Count > endrow)
                {
                    for (int i = 0; i < hs; i++)
                    {

                        ex.SetCellValue(bdzlist[starow - 1 + i], star + i, clm);
                        //加粗过程
                        for (int n = 0; n < strnumcol.Length; n++)
                        {
                            if (starow - 1 + i == strnumcol[n])
                            {
                                ex.SetFontBold(star + i, clm, star + i, clm, true, 0, boldnum[n]);
                            }

                        }

                        //ex.SetCellValue(objlist[starow - 1 + i].rq.Month.ToString(), rowcount + i, 1);
                        //ex.SetCellValue(objlist[starow - 1 + i].rq.Day.ToString(), rowcount + i, 2);
                        //ex.SetCellValue(objlist[starow - 1 + i].rq.Hour.ToString(), rowcount + i, 3);
                        //ex.SetCellValue(objlist[starow - 1 + i].rq.Minute.ToString(), rowcount + i, 4);
                        //ex.SetCellValue(objlist[starow - 1 + i].lxfs, rowcount + i, 5);
                        //ex.SetCellValue(objlist[starow - 1 + i].yhdz, rowcount + i, 6);
                        //ex.SetCellValue(objlist[starow - 1 + i].gzjk, rowcount + i, 7);
                        //ex.SetCellValue(objlist[starow - 1 + i].djr, rowcount + i, 8);
                        //ex.SetCellValue(objlist[starow - 1 + i].clr, rowcount + i, 9);

                    }
                }
                else if (bdzlist.Count <= endrow && bdzlist.Count >= starow)
                {
                    for (int i = 0; i < bdzlist.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(bdzlist[starow - 1 + i], star + i, clm);
                        //加粗过程
                        for (int n = 0; n < strnumcol.Length; n++)
                        {
                            if (starow - 1 + i == strnumcol[n])
                            {
                                ex.SetFontBold(star + i, clm, star + i, clm, true, 0, boldnum[n]);
                            }

                        }

                        //ex.SetCellValue(objlist[starow - 1 + i].rq.Month.ToString(), rowcount + i, 1);
                        //ex.SetCellValue(objlist[starow - 1 + i].rq.Day.ToString(), rowcount + i, 2);
                        //ex.SetCellValue(objlist[starow - 1 + i].rq.Hour.ToString(), rowcount + i, 3);
                        //ex.SetCellValue(objlist[starow - 1 + i].rq.Minute.ToString(), rowcount + i, 4);
                        //ex.SetCellValue(objlist[starow - 1 + i].lxfs, rowcount + i, 5);
                        //ex.SetCellValue(objlist[starow - 1 + i].yhdz, rowcount + i, 6);
                        //ex.SetCellValue(objlist[starow - 1 + i].gzjk, rowcount + i, 7);
                        //ex.SetCellValue(objlist[starow - 1 + i].djr, rowcount + i, 8);
                        //ex.SetCellValue(objlist[starow - 1 + i].clr, rowcount + i, 9);

                    }
                }
            }
        }
        public static void addstring(List<string> jh, ref List<string> strcol)
        {

            for (int i = 0; i < jh.Count; i++)
            {
                strcol.Add(jh[i]);
            }
        }

        public static byte[] GetImageBate(string filepath)
        {
            System.IO.FileStream fs = new System.IO.FileStream(filepath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            byte[] filebt = br.ReadBytes((int)fs.Length);
            byte[] allbyte = new byte[filebt.Length + 10];
            string[] str_name = filepath.Split("\\".ToCharArray());
            string[] filename = str_name[str_name.Length - 1].Split(".".ToCharArray());
            byte[] Excbyte = System.Text.Encoding.Default.GetBytes(filename[filename.Length - 1]);
            string Exc = System.Text.Encoding.Default.GetString(Excbyte);
            filebt.CopyTo(allbyte, 0);
            Excbyte.CopyTo(allbyte, filebt.Length);
            br.Close();
            fs.Close();
            return allbyte;
        }
        public static byte[] GetByte(byte[] img)
        {
            byte[] newbt = new byte[img.Length - 10];
            for (int i = 0; i < newbt.Length; i++)
            {
                newbt[i] = img[i];
            }
            //img.CopyTo(newbt, 0);
            return newbt;
        }

        public static void WriteDoc(byte[] img, ref string filename)
        {
            BinaryWriter bw;
            FileStream fs;
            try
            {
                byte[] newbt = new byte[img.Length - 10];
                for (int i = 0; i < newbt.Length; i++)
                {
                    newbt[i] = img[i];
                }
                byte[] _excbt = new byte[10];
                for (int i = 0; i < 10; i++)
                {
                    _excbt[i] = img[img.Length - 10 + i];
                }
                string[] str = System.Text.Encoding.Default.GetString(_excbt).Split("\0".ToCharArray());
                string Exc = str[0];

                fs = new FileStream("C:\\" + filename + "." + Exc, FileMode.Create, FileAccess.Write);
                bw = new BinaryWriter(fs);
                bw.Write(newbt);
                bw.Flush();
                bw.Close();
                fs.Close();
                filename = "C:\\" + filename + "." + Exc;
                //System.Diagnostics.Process.Start("C:\\" + filename + "." + Exc);
            }
            catch
            {

            }
        }

    }
}
