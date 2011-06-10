/**********************************************
系统:企业ERP
模块:通用组件
作者:Rabbit
创建时间:2011-5-19
最后一次修改:2011-5-25
***********************************************/
using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using Ebada.Scgl.Model;
using System.Collections;
namespace Ebada.Scgl.Core {
    public class LookUpDicType:RepositoryItemLookUpEdit {
        public LookUpDicType(IList<DicType> datasource) {
            this.Columns.Add(new LookUpColumnInfo("Key","", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default));
            this.Columns.Add(new LookUpColumnInfo("Value",""));
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
        static RepositoryItem ownerdic;
        public static RepositoryItem OwnerDic {
            get {
                if (ownerdic == null) {
                    IList<DicType> list = new List<DicType>();
                    list.Add(new DicType("局属", "局属"));
                    list.Add(new DicType("自备", "自备"));
                    LookUpDicType ri = new LookUpDicType(list);
                    ownerdic = ri;
                }
                return ownerdic;
            }
        }
        static RepositoryItem runState;
        public static RepositoryItem RunState {
            get {
                if (runState == null) {
                    IList<DicType> list = new List<DicType>();
                    list.Add(new DicType("运行", "运行"));
                    list.Add(new DicType("停运", "停运"));
                    LookUpDicType ri = new LookUpDicType(list);
                    runState = ri;
                }
                return runState;
            }
        }
        static RepositoryItem gdsDic;

        public static RepositoryItem GdsDic {
            get {
                if (gdsDic == null) {
                    IList<ViewGds> list=Client.ClientHelper.PlatformSqlMap.GetList<ViewGds>("");
                    IList<DicType> dic = new List<DicType>();
                    foreach (ViewGds gds in list) {
                        dic.Add(new DicType(gds.OrgCode, gds.OrgName));
                    }
                    gdsDic = new LookUpDicType(dic); 
                }
                return DicTypeHelper.gdsDic; 
            }
        }
        static RepositoryItem bdsDic;

        public static RepositoryItem BdsDic {
            get {
                if (bdsDic == null) {
                    IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<mOrg>(" where Orgtype='2'");
                    IList<DicType> dic = new List<DicType>();
                    foreach (mOrg gds in list) {
                        dic.Add(new DicType(gds.OrgCode, gds.OrgName));
                    }
                    bdsDic = new LookUpDicType(dic);
                }
                return DicTypeHelper.bdsDic;
            }
        }
        static RepositoryItem orgDic;
        public static RepositoryItem OrgDic
        {
            get
            {
                if (orgDic == null)
                {
                    IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("");
                    IList<DicType> dic = new List<DicType>();
                    foreach (mOrg gds in list)
                    {
                        dic.Add(new DicType(gds.OrgCode, gds.OrgName));
                    }
                    orgDic = new LookUpDicType(dic);
                }
                return DicTypeHelper.orgDic;
            }
        }
    }
}
