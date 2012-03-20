using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.IO;
using System.Xml;
using DevExpress.XtraTreeList.Columns;

namespace Ebada.Scgl.Sbgl
{
    
    public class DeviceType{
        string id;

        public string Id {
            get { return id; }
            set { id = value; }
        }
        string typeName;

        public string TypeName {
            get { return typeName; }
            set { typeName = value; }
        }
        string typeClass;

        public string TypeClass {
            get { return typeClass; }
            set { typeClass = value; }
        }
        string parentId;

        public string ParentId {
            get { return parentId; }
            set { parentId = value; }
        }
        public static DataTable GetDeviceTypes() {
            Stream fs = Assembly.GetExecutingAssembly().GetManifestResourceStream("Ebada.Scgl.Sbgl.devicetypes.xml");
            XmlDocument xml = new XmlDocument();
            xml.Load(fs);
            XmlNodeList nodes = xml.DocumentElement.ChildNodes;
            DataTable table =new DataTable();
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("TypeName", typeof(string));
            table.Columns.Add("TypeClass", typeof(string));
            table.Columns.Add("ParentId", typeof(string));
            foreach (XmlNode node in nodes) {
                DataRow row = table.NewRow();
                row["Id"] = node.Attributes["id"].Value;
                row["TypeName"] = node.Attributes["name"].Value;
                row["TypeClass"] = node.Attributes["class"].Value;
                row["ParentId"] = node.Attributes["parentid"].Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static void InitDeviceTypes(DevExpress.XtraTreeList.TreeList treeList1) {
            TreeListColumn column = new TreeListColumn();
            column.Caption = "设备种类";
            column.FieldName = "TypeName";
            column.VisibleIndex = 0;
            column.Width = 180;
            column.OptionsColumn.AllowEdit = false;
            column.OptionsColumn.AllowSort = false;
            treeList1.Columns.AddRange(new TreeListColumn[] {
            column});
            treeList1.KeyFieldName = "Id";
            treeList1.ParentFieldName = "ParentId";
            treeList1.DataSource = GetDeviceTypes();
        }
        
    }
}
