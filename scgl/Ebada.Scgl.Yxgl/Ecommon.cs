﻿using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using System.IO;
namespace Ebada.Scgl.Yxgl
{
    class Ecommon
    {
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
             int tempLen=0; 
             string tempString=""; 
             byte[] s = ascii.GetBytes(inputString);
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
                 tempString += inputString.Substring(i, 1); 
                 if (tempLen>=len&&i<=(s.Length-1))
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
             return RList;
           
 
        }
        /// <summary>
        /// 返回list集合中的全部字符list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<string> GetCollList(System.Collections.ArrayList list)
        {
            List<string> allList = new List<string>();
            for (int i = 0; i < list.Count;i++ )
            {
                List<string> l = list[i] as List<string>;
                for(int j=0;j<l.Count;j++){
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
        public static void CreatandWritesheet(ExcelAccess ex,List<string>[] bdzlist,int[] hs,int[] stawz )
        {
            int pageindex = 1;
            for (int i = 0; i < bdzlist.Length;i++ )
            {
                if (pageindex < GetPagecount(bdzlist[i].Count,hs[i]))
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
                for (int num = 0; num < bdzlist.Length;num++ )
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
       
        public static void CreatandWritesheet(ExcelAccess ex,List<string> bdzlist,int hs,int star,int clm )
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

                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * hs+ 1;
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
       public static void addstring(List<string> jh ,ref List<string> strcol)
       {
           
           for (int i = 0; i < jh.Count;i++ )
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
