using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraTreeList;
using System.Data;
using DBATLLib;
using DevExpress.XtraGrid;

namespace Ebada.Scgl.Outer {
    class DBATLLibHelper {
        
        static DBATLLib.DataCommClass RealDB = null;
        static DBATLLibHelper() {
            
        }
        public static string dbServer = "127.0.0.1";
        public static int dbAreaNo = 30;
        public static int dbKgNo = 4;
        
        public void Dispose() {
            if (RealDB != null) {
                if (RealDB.IsOpen())
                    RealDB.Close();

                RealDB = null;
            }
        }
        public DBATLLibHelper() {
            if (RealDB == null)
                RealDB = new DBATLLib.DataCommClass();//(DBATLLib.DataCommClass)Application["RealDB"];
            
            tagValues = new Dictionary<string, DataRow>();
        }
        public void open() {
            if (!RealDB.IsOpen())
                RealDB.Open(dbServer);
        }
        public bool IsOpen {
            get {
                return RealDB.IsOpen();
            }
        }
        public void close() {
            if (RealDB.IsOpen()) {
                RealDB.Close();
            }
        }
        public event _IDataCommEvents_OnDataChangedEventHandler OnDataChanged {
            add {
                RealDB.OnDataChanged += value;
            }
            remove {
                RealDB.OnDataChanged -= value;
            }
        }
        public void initkgtree(TreeList treeList) {
            close();
            open();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("名称", typeof(string));
            dt1.Columns.Add("id", typeof(string));
            dt1.Columns.Add("parentid", typeof(string));
            treeList.DataSource = dt1;
            treeList.KeyFieldName = "id";
            treeList.ParentFieldName = "parentid";
            int areaNo = dbAreaNo;
            int kindNo = 0;
            int count = RealDB.GetTagCount(areaNo, kindNo);

            string tagName = "";
            string desc = "";
            string pid = "";
            int n1 = 0;
            int n2 = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++) {
                tagName = RealDB.GetTagName(areaNo, kindNo, i);
                desc = RealDB.GetTagDesc(tagName);
                n1 = int.Parse(tagName.Substring(1));
                n2 = int.Parse(tagName.Substring(6));
                if (n1 == 0) {
                    pid = "";
                } else if(n2==0) {
                    pid = "s000000000";
                } else if (n2 > 0) {
                    pid = "s" + tagName.Substring(1, 5) + "0000";
                    if (!desc.Contains("开关")) continue;//只显示开关
                }                
                dt1.Rows.Add(desc, tagName, pid);
            }

        }
        public Dictionary<string, DataRow> tagValues;
        public void initKgcs(string sbid, GridControl gc) {

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("属性", typeof(string));
            dt1.Columns.Add("值", typeof(string));
            dt1.Columns.Add("key", typeof(string));
            gc.DataSource = dt1;
            int areaNo = dbKgNo;
            int kindNo = 0;
            int count = RealDB.GetTagCount(areaNo, kindNo);

            string tagName = "";
            string desc = "";
            string pid = "";
            int n1 = 0;
            int n2 = 0;
            StringBuilder sb = new StringBuilder();
            tagValues.Clear();
            for (int i = 0; i < count; i++) {
                tagName = RealDB.GetTagName(areaNo, kindNo, i);
                desc = RealDB.GetTagDesc(tagName);

                string[] ss = tagName.Split('_');
                if (ss.Length != 2) continue;

                if (ss[0] == sbid) {

                    DataRow row=dt1.Rows.Add(desc,"", tagName);
                    tagValues.Add(tagName + ".PV", row);
                    sb.Append(tagName + ".PV,");
                }
            }
            RealDB.Register(sb.ToString(), 0);
        }
    }
}
