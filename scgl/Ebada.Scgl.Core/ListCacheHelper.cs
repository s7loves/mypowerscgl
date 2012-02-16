using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Core {
    public class ListCacheHelper {
        private static char[] charSplit1 = new char[]{'|'};
        private static char[] charSplit2 = new char[] {','};
        public static IList<PS_XLSec> GetXLSecList(string strXLSec)
        {
            IList<PS_XLSec> secList = new List<PS_XLSec>();
            if (!string.IsNullOrEmpty(strXLSec))
            {
                IList<string> strList = strXLSec.Split(charSplit1);
                foreach (string str in strList)
                {
                    string[] element = str.Split(charSplit2);
                    if (element.Length>=4)
                    {
                        PS_XLSec xlSec = new PS_XLSec();
                        xlSec.ID = element[0];
                        xlSec.StartGT = element[1];
                        xlSec.EndGT = element[2];
                        xlSec.LineType = element[3];
                        secList.Add(xlSec);
                    }
                }
            }     
            return secList;
        }
        public static string GetXLSecString(IList<PS_XLSec> xlSecList)
        {
            string strSec = null;
            foreach (PS_XLSec xlSec in xlSecList)
            {
                if (string.IsNullOrEmpty(strSec))
                {
                    strSec += xlSec.ID + "," + xlSec.StartGT + ","+ xlSec.EndGT + "," + xlSec.LineType;
                }
                else
                {
                    strSec += "|" + xlSec.ID + "," + xlSec.StartGT + "," + xlSec.EndGT + "," + xlSec.LineType;
                }
               
            }
            return strSec;
        }
    }
}
