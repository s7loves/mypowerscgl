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
                    //IList<ViewGds> list=Client.ClientHelper.PlatformSqlMap.GetList<ViewGds>("");
                    //IList<DicType> dic = new List<DicType>();
                    //foreach (ViewGds gds in list) {
                    //    dic.Add(new DicType(gds.OrgCode, gds.OrgName));
                    //}
                    //gdsDic = new LookUpDicType(dic); 

                    IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where c1='是' order by orgcode");
                    IList<DicType> dic = new List<DicType>();
                    foreach (mOrg gds in list)
                    {
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
                    dic.Add(new DicType("001", "全局"));
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
        static RepositoryItem gdsDic4;

        public static RepositoryItem GdsDic4
        {
            get
            {
                //if (gdsDic == null) {
                if (gdsDic4 == null || gdsDic4.LinkCount == 1)
                {
                    IList<ViewGds> list = Client.ClientHelper.PlatformSqlMap.GetList<ViewGds>("");
                    IList<DicType> dic = new List<DicType>();
                    foreach (ViewGds gds in list)
                    {
                        dic.Add(new DicType(gds.OrgCode, gds.OrgName));
                    }
                    gdsDic4 = new LookUpDicType(dic); 

                   
                }
                return DicTypeHelper.gdsDic4;
            }
        }
        static RepositoryItem gdsDic5;

        public static RepositoryItem GdsDic5
        {
            get
            {
                //if (gdsDic == null) {
                if (gdsDic4 == null || gdsDic4.LinkCount == 1)
                {
                    IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where OrgType='2' order by orgcode");
                    IList<DicType> dic = new List<DicType>();
                    foreach (mOrg gds in list)
                    {
                        dic.Add(new DicType(gds.OrgCode, gds.OrgName));
                    }
                    gdsDic5 = new LookUpDicType(dic);


                }
                return DicTypeHelper.gdsDic5;
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

        static RepositoryItem eProDic;

        public static RepositoryItem E_proDic
        {
            get
            {
                

                    IList<E_Professional> list = Client.ClientHelper.PlatformSqlMap.GetList<E_Professional>(" ");
                    IList<DicType> dic = new List<DicType>();
                    foreach (E_Professional pro in list)
                    {
                        dic.Add(new DicType(pro.ID, pro.PName));
                    }
                    eProDic = new LookUpDicType(dic);
                
                return DicTypeHelper.eProDic;
            }
        }
        static RepositoryItem eProDicTB;
        public static RepositoryItem E_proDicTB
        {
            get
            {
                

                IList<E_Professional> list = Client.ClientHelper.PlatformSqlMap.GetList<E_Professional>(" ");
                IList<DicType> dic = new List<DicType>();
                foreach (E_Professional pro in list)
                {
                    dic.Add(new DicType(pro.ID, pro.PName));
                }
                dic.Add(new DicType("010101", "试题合计"));
                eProDicTB = new LookUpDicType(dic);
               
                return DicTypeHelper.eProDicTB;
            }
        }
        static IList<DicType> _SettingDic;
        public static IList<DicType> SettingDic
        {
            get
            {
                
                   IList<E_ExamSetting> list = Client.ClientHelper.PlatformSqlMap.GetList<E_ExamSetting>(" ");
                    IList<DicType> dic = new List<DicType>();
                    foreach (E_ExamSetting pro in list)
                    {
                        string des="(判断 "+pro.JudgeNUM+"个;  单选"+pro.SelectNUM+"个;  多选 "+pro.MuSelectNUM+"个;总分 "+pro.TotalScore+"分)";
                        dic.Add(new DicType(pro.ID, pro.SettingName+des));
                    }
                    _SettingDic = dic;
                
                return _SettingDic;
            }
            set
            {
                _SettingDic=value;
            }
        }
        static RepositoryItem esetting;

        public static RepositoryItem E_Setting
        {
            get
            {
                

                    IList<E_ExamSetting> list = Client.ClientHelper.PlatformSqlMap.GetList<E_ExamSetting>(" ");
                    IList<DicType> dic = new List<DicType>();
                    foreach (E_ExamSetting pro in list)
                    {
                        string des = "(判断 " + pro.JudgeNUM + "个;  单选" + pro.SelectNUM + "个;  多选 " + pro.MuSelectNUM + "个;总分 " + pro.TotalScore + "分)";
                        dic.Add(new DicType(pro.ID, pro.SettingName + des));
                    }
                    esetting = new LookUpDicType(dic);
               
                return DicTypeHelper.esetting;
            }
        }

        static  IList<DicType> dicee = new List<DicType>();
       
        public static IList<DicType> GetE_QuDicList()
        {
            if (dicee.Count==0)
            {
                dicee.Add(new DicType("1", "☆"));
                dicee.Add(new DicType("2", "☆☆"));
                dicee.Add(new DicType("3", "☆☆☆"));
                dicee.Add(new DicType("4", "☆☆☆☆"));
                dicee.Add(new DicType("5", "☆☆☆☆☆"));
            }
            return dicee;
        }
        //题的难道系数
        static RepositoryItem eQuestionBankDic;
        public static RepositoryItem E_QuestionBankDic
        {
            get
            {
               
                    
                    IList<DicType> dic = new List<DicType>();
                   
                    dic.Add(new DicType("1", "☆"));
                    dic.Add(new DicType("2", "☆☆"));
                    dic.Add(new DicType("3", "☆☆☆"));
                    dic.Add(new DicType("4", "☆☆☆☆"));
                    dic.Add(new DicType("5", "☆☆☆☆☆"));
                    eQuestionBankDic = new LookUpDicType(dic);
                
                return DicTypeHelper.eQuestionBankDic;
            }
        }
        static RepositoryItem equbank;

        public static RepositoryItem E_QBank
        {
            get
            {
                

                    IList<E_QBank> list = Client.ClientHelper.PlatformSqlMap.GetList<E_QBank>(" ");
                    IList<DicType> dic = new List<DicType>();
                    foreach (E_QBank pro in list)
                    {
                        dic.Add(new DicType(pro.ID, pro.TKName));
                    }
                    equbank = new LookUpDicType(dic);
                
                return DicTypeHelper.equbank;
            }
        }

        static IList<DicType> _EbankDiclist;
        public static IList<DicType> EbankDicList
        {
            get
            {
                
                    IList<E_QBank> list = Client.ClientHelper.PlatformSqlMap.GetList<E_QBank>(" ");
                    IList<DicType> dic = new List<DicType>();
                    foreach (E_QBank pro in list)
                    {
                        dic.Add(new DicType(pro.ID, pro.TKName));
                    }
                    _EbankDiclist = dic;
                
                return _EbankDiclist;
            }
            set
            {
                _EbankDiclist = value;
            }
        }

        static IList<DicType> _ExPaperDic;
        public static IList<DicType> ExPaperDic
        {
            get
            {
                
                    IList<E_ExaminationPaper> list = Client.ClientHelper.PlatformSqlMap.GetList<E_ExaminationPaper>(" ");
                    IList<DicType> dic = new List<DicType>();
                    foreach (E_ExaminationPaper pro in list)
                    {
                        dic.Add(new DicType(pro.ID, pro.EP_Name));
                    }

                    _ExPaperDic = dic;
               
                return _ExPaperDic;
            }
            set
            {
                _SettingDic = value;
            }
        }

        static RepositoryItem _ExPaper;

        public static RepositoryItem E_Paper
        {
            get
            {
 
                    IList<E_ExaminationPaper> list = Client.ClientHelper.PlatformSqlMap.GetList<E_ExaminationPaper>(" ");
                    IList<DicType> dic = new List<DicType>();
                    foreach (E_ExaminationPaper pro in list)
                    {
                        dic.Add(new DicType(pro.ID, pro.EP_Name));
                    }

                    _ExPaper = new LookUpDicType(dic);
               
                return DicTypeHelper._ExPaper;
            }
        }

        static RepositoryItem _ExExam;

        public static RepositoryItem E_Exam
        {
            get
            {
               

                IList<E_Examination> list = Client.ClientHelper.PlatformSqlMap.GetList<E_Examination>(" order by EndTime desc ");
                IList<DicType> dic = new List<DicType>();
                foreach (E_Examination pro in list)
                {
                    dic.Add(new DicType(pro.ID, pro.E_Name));
                }

                _ExExam = new LookUpDicType(dic);
               
                return DicTypeHelper._ExExam;
            }
        }

        static RepositoryItem _E_LevelSeason;

        public static RepositoryItem E_LevelSeason
        {
            get
            {


                IList<E_LevelSeason> list = Client.ClientHelper.PlatformSqlMap.GetList<E_LevelSeason>(" order by Sequence asc ");
                IList<DicType> dic = new List<DicType>();
                foreach (E_LevelSeason pro in list)
                {
                    dic.Add(new DicType(pro.ID, pro.Name));
                }

                _E_LevelSeason = new LookUpDicType(dic);

                return DicTypeHelper._E_LevelSeason;
            }
        }


        static RepositoryItem _E_Level;

        public static RepositoryItem E_Level
        {
            get
            {


                IList<E_Level> list = Client.ClientHelper.PlatformSqlMap.GetList<E_Level>(" order by Sequence asc ");
                IList<DicType> dic = new List<DicType>();
                foreach (E_Level pro in list)
                {
                    dic.Add(new DicType(pro.ID, pro.Name));
                }

                _E_Level = new LookUpDicType(dic);

                return DicTypeHelper._E_Level;
            }
        }


        static RepositoryItem _user;

        public static RepositoryItem UserDic
        {
            get
            {
                if (_user == null || _user.LinkCount == 1)
                {
                    IList<mUser> list = Client.ClientHelper.PlatformSqlMap.GetList<mUser>(" ");
                    IList<DicType> dic = new List<DicType>();
                    foreach (mUser pro in list)
                    {
                        dic.Add(new DicType(pro.UserID, pro.UserName));
                    }
                     _user = new LookUpDicType(dic);
                }
                return DicTypeHelper._user;
            }
        }
    }
}
