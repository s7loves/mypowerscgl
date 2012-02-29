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
                //if (gdsDic == null) {
                if (gdsDic == null||gdsDic.LinkCount  == 1 )
                {
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

        static RepositoryItem gdsDic2;
        /// <summary>
        /// 添加绥化电业局选项
        /// </summary>
        public static RepositoryItem GdsDic2 {
            get
            {
                //if (gdsDic == null) {
                if (gdsDic2 == null || gdsDic2.LinkCount == 1)
                {
                    IList<ViewGds> list = Client.ClientHelper.PlatformSqlMap.GetList<ViewGds>("");
                    IList<DicType> dic = new List<DicType>();
                    dic.Add(new DicType("0", "所有供电所"));
                    foreach (ViewGds gds in list)
                    {
                        dic.Add(new DicType(gds.OrgCode, gds.OrgName));
                    }
                    gdsDic2 = new LookUpDicType(dic);
                }
                return DicTypeHelper.gdsDic2;
            }
        }

        static RepositoryItem gdsDic3;
        /// <summary>
        /// 添加生产部门
        /// </summary>
        public static RepositoryItem GdsDic3
        {
            get
            {
                IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<mOrg>("where c1='是' order by orgcode");
                //if (gdsDic == null) {
                if (gdsDic3 == null ||list.Count > gdsDic3.LinkCount)
                {
                    
                    IList<DicType> dic = new List<DicType>();
                    dic.Add(new DicType("0", "选择生产部门"));
                    foreach (mOrg gds in list)
                    {
                        dic.Add(new DicType(gds.OrgCode, gds.OrgName));
                    }
                    gdsDic3 = new LookUpDicType(dic);
                }
                return DicTypeHelper.gdsDic3;
            }
        }

        static RepositoryItem tjDic;
        /// <summary>
        /// 添加统计方式
        /// </summary>
        public static RepositoryItem TjDic
        {
            get
            {
                //if (gdsDic == null) {
                if (tjDic == null || tjDic.LinkCount == 1)
                {
                    //IList<ViewGds> list = Client.ClientHelper.PlatformSqlMap.GetList<ViewGds>("");
                    IList<DicType> dic = new List<DicType>();
                    dic.Add(new DicType("0","按局"));
                    dic.Add(new DicType("1", "按供电所"));
                    dic.Add(new DicType("2", "按线路"));
                    tjDic = new LookUpDicType(dic);
                }
                return DicTypeHelper.tjDic;
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
        static RepositoryItem sbcs2Dic;
        /// <summary>
        /// 获取设备小类列表
        /// </summary>
        public static RepositoryItem Pssbcs2Dic {
            get {
                if (orgDic == null) {
                    IList<PS_sbcs> list = Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>("where len(bh)=5 order by bh");
                    IList<DicType> dic = new List<DicType>();
                    foreach (PS_sbcs obj in list) {
                        dic.Add(new DicType(obj.bh, obj.mc));
                    }
                    orgDic = new LookUpDicType(dic);
                }
                return DicTypeHelper.orgDic;
            }
        }
    }
}
