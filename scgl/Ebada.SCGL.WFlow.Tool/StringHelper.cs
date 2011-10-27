using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using DevExpress.XtraRichEdit.API.Word;
using System.Collections;

namespace Ebada.SCGL.WFlow.Tool
{
    public class StringHelper
    {

        public int GetRealLen(string str)
        {
            // int len = 0;
            string arrayText = str;
            int real = 0; double temp = 0.0;
            for (int i = 0; i < arrayText.Length; i++)
            {
                Regex r = new Regex(@"[^\x00-\xff]");
                Match m = r.Match(arrayText[i].ToString());
                int l = 1;
                if (m.Success)
                    l = 2;
                if (l != 2)// && (char.IsDigit(arrayText[i]) || arrayText[i] == '#' || arrayText[i] == 'V' || char.IsLower(arrayText[i]) || char.IsWhiteSpace(arrayText[i])))
                {
                    temp += 0.5;
                }
                else
                    temp += 1;

            }
            return (int)(temp);
        }
        
        
        public string GetPlitString(string oldText, int len)
        {
            string newString = "";
            string[] plit = { "\r\n" };
            string[] array = oldText.Split(plit, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < array.Length; i++)
            {
                double te = (double)array[i].Length / (double)len;
                if (te > 1.0)
                {
                    newString += ChangeString(array[i], len) + "\r\n";
                }
                else
                    newString += array[i] + "\r\n";
            }
            return newString;
        }

        public string GetPlitStringN(string oldText, int len)
        {
            string newString = "";
            string[] plit = { "\r\n" };
            string[] array = oldText.Split(plit, StringSplitOptions.None);
            for (int i = 0; i < array.Length; i++)
            {
                double te = (double)array[i].Length / (double)len;
                if (te > 1.0)
                {
                    newString += ChangeString(array[i], len) + "\r\n";
                }
                else
                    newString += array[i] + "\r\n";
            }
            return newString;
        }


        public int GetStringLen(string _str, int count)
        {
            int len = 0;
            string[] plit = { "\r\n" };
            string[] array = _str.Split(plit, StringSplitOptions.None);
            for (int i = 0; i < count; i++)
            {
                len += array[i].Length + 2;
            }
            return len;
        }
        public int GetRows(string newString)
        {
            string[] plit = { "\r\n" };
            return newString.Split(plit, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public string ChangeString(string arrayText, int len)
        {
            string newArray = "";
            bool first = true;
            int real = 0; double temp = 0.0;
            for (int i = 0; i < arrayText.Length; i++)
            {
                Regex r = new Regex(@"[^\x00-\xff]");
                Match m = r.Match(arrayText[i].ToString());
                int l = 1;
                if (m.Success)
                    l = 2;
                if (l != 2)// && (char.IsDigit(arrayText[i]) || arrayText[i] == '#' || arrayText[i] == 'V' || char.IsLower(arrayText[i]) || char.IsWhiteSpace(arrayText[i])))
                {
                    //if(!first)
                    //    temp+=1;
                    //else
                    temp += 0.5;
                    first = true;
                }
                else
                {
                    first = false;
                    temp += 1;
                }
                real += 1;
                newArray += char.ToString(arrayText[i]);
                if ((int)(temp + 0.5) == len)
                {
                    if (i != arrayText.Length - 1)
                        ChangeNum(arrayText[i + 1], ref newArray, ref i);
                    newArray += "\r\n";
                    temp = 0.0;
                }
            }
            return newArray;
        }
        public bool IsHanzi(char c)
        {
            Regex rx = new Regex("^[\u4e00-\u9fa5，。、]$");
            if (rx.IsMatch(c.ToString()))
                return true;
            else
                return false;
        }

        public void ChangeNum(char nextStr, ref string oldStr, ref int oldI)
        {
            int pos = oldStr.Length;
            int k = oldI;
            int i = 0;
            if (!IsHanzi(nextStr))
            {
                for (int j = oldStr.Length - 1; j >= 0; j--)
                {
                    if (i == 5)
                    { oldI = k; break; }
                    if (!IsHanzi(oldStr[j]))
                    {
                        pos--;
                        oldI--;
                    }
                    else
                    {
                        oldStr = oldStr.Substring(0, pos);
                        break;
                    }
                    i++;
                }
            }
        }
        public static string ReplaceEmpty(string[] arry)
        {           
            string strNew="";
            for (int i = 0; i < arry.Length;i++ )
            {
                if (!string.IsNullOrEmpty(arry[i]))
                {
                    if (string.IsNullOrEmpty(strNew))
                    {
                        strNew = arry[i];
                    }
                    else
                    {
                        strNew += "|" + arry[i];
                    }
                }                
            }            
            
            return strNew;
        }
        public int GetFristLen(string str, int end)
        {
            if (str.Length <= end)
                return end;
            string arrayText = str;
            int real = 0; double temp = 0.0;
            for (int i = 0; i < arrayText.Length; i++)
            {
                Regex r = new Regex(@"[^\x00-\xff]");
                Match m = r.Match(arrayText[i].ToString());
                int l = 1;
                if (m.Success)
                    l = 2;
                if (l != 2)// && (char.IsDigit(arrayText[i]) || arrayText[i] == '#' || arrayText[i] == 'V' || char.IsLower(arrayText[i]) || char.IsWhiteSpace(arrayText[i])))
                {
                    temp += 0.5;
                }
                else
                    temp += 1;
                if (end <= (int)(temp + 0.5))
                {
                    break;
                }
                real++;
            }

            string old = "";
            if (real + 1 >= arrayText.Length)
                return real;
                old = arrayText.Substring(0, real + 1);
           
            ChangeNum(arrayText[++real], ref old, ref real);
            return real;
        }
    }
}
