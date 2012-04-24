using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Xml;

namespace Ebada.Scgl.Outer {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            treeList1.OptionsBehavior.Editable = false;
        }
        static DBATLLib.DataCommClass RealDB = null;
        DataTable dt1 = null;
        private void Form1_Load(object sender, EventArgs e) {
            
            if (RealDB == null)
                RealDB = new DBATLLib.DataCommClass();//(DBATLLib.DataCommClass)Application["RealDB"];
            if (!RealDB.IsOpen())
                RealDB.Open("127.0.0.1");
            RealDB.OnDataChanged += new DBATLLib._IDataCommEvents_OnDataChangedEventHandler(RealDB_OnDataChanged);

            //
            dt1 = new DataTable();
            dt1.Columns.Add("tagname", typeof(string));
            dt1.Columns.Add("id", typeof(string));
            dt1.Columns.Add("parentid", typeof(string));
            treeList1.DataSource = dt1;
        }

        void RealDB_OnDataChanged(int num, string Name, object Data) {
            listBoxControl1.Items.Insert(0, String.Format("{0},{1},{2}",num,Name,Data));
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            
            int count = RealDB.GetTagCount(0,0);

            string str = "";
            for (int i = 0; i < count; i++) {
                str = RealDB.GetTagName(0, 0, i) ;
                dt1.Rows.Add(str, "", "");
            }
            initdata();
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            if(treeList1.FocusedNode==null)return;
            if (listBoxControl2.SelectedIndex == -1) return;
            string tagname= treeList1.FocusedNode["tagname"].ToString();
            string dataname = listBoxControl2.SelectedItem.ToString().Split('\t')[0];
            string value=RealDB.GetDataDirect(tagname+".pv");
            listBoxControl1.Items.Insert(0, String.Format("{0},{1},{2}", tagname,"pv",  value));

        }
        private void initdata() {
            listBoxControl2.Items.Clear();
            Stream fs = Assembly.GetExecutingAssembly().GetManifestResourceStream("Ebada.Scgl.Outer.dataName.xml");
            XmlDocument xml = new XmlDocument();
            xml.Load(fs);
            string text=xml.DocumentElement.InnerText;
            string[] array=text.Split('\r','\n');
            foreach (string str in array) {
                if (string.IsNullOrEmpty(str)) continue;
                listBoxControl2.Items.Add(str);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e) {
            int count = RealDB.GetDeviceCount();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++) {
                sb.AppendLine(RealDB.GetDeviceName(i));
                
            }
            count = RealDB.GetDeviceTagCount(0);
            string str = "";
            for (int i = 0; i < count; i++) {
                str = RealDB.GetDeviceTagName(0, i);
                dt1.Rows.Add(str, "", "");
            }
            memoEdit1.Text = sb.ToString();
        }
    }
}
