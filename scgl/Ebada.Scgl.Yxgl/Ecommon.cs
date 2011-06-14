using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
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
        public static void CreatandWritesheet(ExcelAccess ex,List<string>[] bdzlist,int[] hs,int[] stawz,int pageindex )
        {
            for (int j = 1; j <= pageindex; j++)
            {
                if (j > 1)
                {
                    ex.CopySheet(1, j + 1);
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

   }
}
