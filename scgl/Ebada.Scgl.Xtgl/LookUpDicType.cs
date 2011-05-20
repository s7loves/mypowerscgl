/**********************************************
系统:企业ERP
模块:通用组件
作者:Rabbit
创建时间:2011-5-19
最后一次修改:2011-5-19
***********************************************/
using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
namespace Ebada.Scgl.Xtgl {
    public class LookUpDicType:RepositoryItemLookUpEdit {
        public LookUpDicType(IList<DicType> datasource) {
            this.Columns.Add(new LookUpColumnInfo("Key","", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default));
            this.Columns.Add(new LookUpColumnInfo("Value","种类"));
            this.DataSource = datasource;
            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.Properties.DisplayMember = "Value";
            this.Properties.ValueMember = "Key";
            this.Properties.NullText = "";
        }
    }
    public class DicType {
        string _key;

        public string Key {
            get { return _key; }
            set { _key = value; }
        }
        string _value;

        public string Value {
            get { return _value; }
            set { _value = value; }
        }
        public DicType(string key, string value) {
            _key = key;
            _value = value;
        }
    }
    public static class DicTypeHelper {
        static RepositoryItem orgtype;
        public static RepositoryItem OrgTypeDic {
            get {
                if (orgtype == null) {
                    IList<DicType> list = new List<DicType>();
                    list.Add(new DicType("0", "机构"));
                    list.Add(new DicType("1", "供电所"));
                    list.Add(new DicType("2", "变电所"));
                    LookUpDicType ri = new LookUpDicType(list);
                    orgtype = ri;
                }
                return orgtype;            
            }
        }
    }
}
