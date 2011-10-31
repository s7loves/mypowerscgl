using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace Ebada.SCGL.WFlow.Tool
{
    ///// <summary>
    ///// 选择项类，用于ComboBox或者ListBox添加项
    ///// </summary>
    //public class ExListItem
    //{
    //    private string _value = string.Empty;
    //    private string _text = string.Empty;
    //    public ExListItem(string sname, string sid)
    //    {
    //        Value = sid;
    //        Text = sname;
    //    }
    //    public override string ToString()
    //    {
    //        return this._text;
    //    }
    //    public string Value
    //    {
    //        get
    //        {
    //            return this._value;
    //        }
    //        set
    //        {
    //            this._value = value;
    //        }
    //    }
    //    public string Text
    //    {
    //        get
    //        {
    //            return this._text;
    //        }
    //        set
    //        {
    //            this._text = value;
    //        }
    //    }
    //}

    public  class WinFormFun
    {
        public static void LoadComboBox(ComboBox cb, DataTable dt, string valueMember, string displayMember)
        {
            LoadComboBox(cb, dt, valueMember, displayMember,  "");
        }
        public static void LoadComboBox(ComboBox cb, DataTable dt, string valueMember, string displayMember, string focusID)
        {
            string text = "";
            string value = "";
            cb.Items.Clear();
            ListItem l = new ListItem("###", "请选择");
            cb.Items.Add(l);
            int focusindex = -1,i=1;
            foreach (DataRow dr in dt.Rows)
            {
                text = dr[displayMember].ToString();
                value = dr[valueMember].ToString();
                l = new ListItem(value, text);
                cb.Items.Add(l);
                if (focusID!=""&&value == focusID)
                {
                    focusindex = i;
                }
                i++;
            }
            cb.DisplayMember = "name";
            cb.ValueMember = "id";
            if (focusindex > -1)
            {
                cb.SelectedIndex = focusindex;
            }
            else
            {
                cb.SelectedIndex = 0;
            }
        }
        public static bool ExistsListView(string listViewText, ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Text == listViewText)
                {
                    return true;
                }
            }
            return false;
        }

 

       
    }
}
