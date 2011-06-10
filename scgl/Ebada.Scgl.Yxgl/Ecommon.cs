using System;
using System.Collections.Generic;
using System.Text;

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


   }
}
