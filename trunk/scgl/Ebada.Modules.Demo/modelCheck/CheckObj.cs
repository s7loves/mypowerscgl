using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
namespace Ebada.Modules.Demo
{
    public class CheckObj
    {
        string strText1 = string.Empty;
        DateTime date1 = DateTime.Now;
        int num1 = 0;

        public int Num1
        {
            get { return num1; }
            set { 
                if(value<1)
                    throw new ArgumentOutOfRangeException("Num1 数值不能小于1!", value, value.ToString());
                num1 = value; }
        }
        public DateTime Date1
        {
            get { return date1; }
            set { 
                if(value<DateTime.Now)
                    throw new ArgumentOutOfRangeException("Date1 日期不能小于系统时间!", value, value.ToString());
                date1 = value; }
        }

        public string StrText1
        {
            get { return strText1; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new WarningException("不能为空！", new Exception("不能为空"));
                }
                if (value.Length > 5) throw new ArgumentOutOfRangeException("StrText1 长度不能大于5!", value, value.ToString());
                    //throw new WarningException( "超过长度！",new Exception("超过长度"));
                strText1 = value; 
                  
            }
        }

    }
}
