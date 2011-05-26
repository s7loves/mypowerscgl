/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-26 21:04:37
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_12kgsy]业务实体类
    ///对应表名:PJ_12kgsy
    /// </summary>
    [Serializable]
    public class PJ_12kgsy
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _kgid=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private DateTime _azrq=new DateTime(1900,1,1); 
        private string _azdd=String.Empty; 
        private string _gtbh=String.Empty; 
        private string _a_bco=String.Empty; 
        private string _b_cao=String.Empty; 
        private string _c_abo=String.Empty; 
        private string _a_bco2=String.Empty; 
        private string _b_cao2=String.Empty; 
        private string _c_abo2=String.Empty; 
        private string _dy=String.Empty; 
        private string _dysj=String.Empty; 
        private string _dl=String.Empty; 
        private string _dlsj=String.Empty; 
        private string _dza=String.Empty; 
        private string _dzb=String.Empty; 
        private string _dzc=String.Empty; 
        private string _tqjc=String.Empty; 
        private string _wgjc=String.Empty; 
        private string _syjl=String.Empty; 
        private string _syz=String.Empty; 
        private string _gznrid=String.Empty; 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1);   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：记录ID
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("记录ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[记录ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgID
        /// 属性描述：开关ID
        /// 字段信息：[kgID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("开关ID")]
        public string kgID
        {
            get { return _kgid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[开关ID]长度不能大于50!");
                if (_kgid as object == null || !_kgid.Equals(value))
                {
                    _kgid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：供电所代码
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("供电所代码")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[供电所代码]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgName
        /// 属性描述：供电所名称
        /// 字段信息：[OrgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("供电所名称")]
        public string OrgName
        {
            get { return _orgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[供电所名称]长度不能大于50!");
                if (_orgname as object == null || !_orgname.Equals(value))
                {
                    _orgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：azrq
        /// 属性描述：日期
        /// 字段信息：[azrq],datetime
        /// </summary>
        [DisplayNameAttribute("日期")]
        public DateTime azrq
        {
            get { return _azrq; }
            set
            {			
                if (_azrq as object == null || !_azrq.Equals(value))
                {
                    _azrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：azdd
        /// 属性描述：天气
        /// 字段信息：[azdd],nvarchar
        /// </summary>
        [DisplayNameAttribute("天气")]
        public string azdd
        {
            get { return _azdd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[天气]长度不能大于50!");
                if (_azdd as object == null || !_azdd.Equals(value))
                {
                    _azdd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtbh
        /// 属性描述：温度
        /// 字段信息：[gtbh],nvarchar
        /// </summary>
        [DisplayNameAttribute("温度")]
        public string gtbh
        {
            get { return _gtbh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[温度]长度不能大于50!");
                if (_gtbh as object == null || !_gtbh.Equals(value))
                {
                    _gtbh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：A_BCO
        /// 属性描述：A-BCO
        /// 字段信息：[A_BCO],nvarchar
        /// </summary>
        [DisplayNameAttribute("A-BCO")]
        public string A_BCO
        {
            get { return _a_bco; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[A-BCO]长度不能大于50!");
                if (_a_bco as object == null || !_a_bco.Equals(value))
                {
                    _a_bco = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：B_CAO
        /// 属性描述：B-CAO
        /// 字段信息：[B_CAO],nvarchar
        /// </summary>
        [DisplayNameAttribute("B-CAO")]
        public string B_CAO
        {
            get { return _b_cao; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[B-CAO]长度不能大于50!");
                if (_b_cao as object == null || !_b_cao.Equals(value))
                {
                    _b_cao = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C_ABO
        /// 属性描述：C-ABO
        /// 字段信息：[C_ABO],nvarchar
        /// </summary>
        [DisplayNameAttribute("C-ABO")]
        public string C_ABO
        {
            get { return _c_abo; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[C-ABO]长度不能大于50!");
                if (_c_abo as object == null || !_c_abo.Equals(value))
                {
                    _c_abo = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：A_BCO2
        /// 属性描述：A-BCO2
        /// 字段信息：[A_BCO2],nvarchar
        /// </summary>
        [DisplayNameAttribute("A-BCO2")]
        public string A_BCO2
        {
            get { return _a_bco2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[A-BCO2]长度不能大于50!");
                if (_a_bco2 as object == null || !_a_bco2.Equals(value))
                {
                    _a_bco2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：B_CAO2
        /// 属性描述：B-CAO2
        /// 字段信息：[B_CAO2],nvarchar
        /// </summary>
        [DisplayNameAttribute("B-CAO2")]
        public string B_CAO2
        {
            get { return _b_cao2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[B-CAO2]长度不能大于50!");
                if (_b_cao2 as object == null || !_b_cao2.Equals(value))
                {
                    _b_cao2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C_ABO2
        /// 属性描述：C-ABO2
        /// 字段信息：[C_ABO2],nvarchar
        /// </summary>
        [DisplayNameAttribute("C-ABO2")]
        public string C_ABO2
        {
            get { return _c_abo2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[C-ABO2]长度不能大于50!");
                if (_c_abo2 as object == null || !_c_abo2.Equals(value))
                {
                    _c_abo2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dy
        /// 属性描述：电压(KV)
        /// 字段信息：[dy],nvarchar
        /// </summary>
        [DisplayNameAttribute("电压(KV)")]
        public string dy
        {
            get { return _dy; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电压(KV)]长度不能大于50!");
                if (_dy as object == null || !_dy.Equals(value))
                {
                    _dy = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dysj
        /// 属性描述：时间(min)
        /// 字段信息：[dysj],nvarchar
        /// </summary>
        [DisplayNameAttribute("时间(min)")]
        public string dysj
        {
            get { return _dysj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[时间(min)]长度不能大于50!");
                if (_dysj as object == null || !_dysj.Equals(value))
                {
                    _dysj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dl
        /// 属性描述：电流(A)
        /// 字段信息：[dl],nvarchar
        /// </summary>
        [DisplayNameAttribute("电流(A)")]
        public string dl
        {
            get { return _dl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电流(A)]长度不能大于50!");
                if (_dl as object == null || !_dl.Equals(value))
                {
                    _dl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dlsj
        /// 属性描述：时间(S)
        /// 字段信息：[dlsj],nvarchar
        /// </summary>
        [DisplayNameAttribute("时间(S)")]
        public string dlsj
        {
            get { return _dlsj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[时间(S)]长度不能大于50!");
                if (_dlsj as object == null || !_dlsj.Equals(value))
                {
                    _dlsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dzA
        /// 属性描述：A相(Ω)
        /// 字段信息：[dzA],nvarchar
        /// </summary>
        [DisplayNameAttribute("A相(Ω)")]
        public string dzA
        {
            get { return _dza; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[A相(Ω)]长度不能大于50!");
                if (_dza as object == null || !_dza.Equals(value))
                {
                    _dza = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dzB
        /// 属性描述：B相(Ω)
        /// 字段信息：[dzB],nvarchar
        /// </summary>
        [DisplayNameAttribute("B相(Ω)")]
        public string dzB
        {
            get { return _dzb; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[B相(Ω)]长度不能大于50!");
                if (_dzb as object == null || !_dzb.Equals(value))
                {
                    _dzb = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dzC
        /// 属性描述：C相(Ω)
        /// 字段信息：[dzC],nvarchar
        /// </summary>
        [DisplayNameAttribute("C相(Ω)")]
        public string dzC
        {
            get { return _dzc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[C相(Ω)]长度不能大于50!");
                if (_dzc as object == null || !_dzc.Equals(value))
                {
                    _dzc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tqjc
        /// 属性描述：同期检查情况
        /// 字段信息：[tqjc],nvarchar
        /// </summary>
        [DisplayNameAttribute("同期检查情况")]
        public string tqjc
        {
            get { return _tqjc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[同期检查情况]长度不能大于50!");
                if (_tqjc as object == null || !_tqjc.Equals(value))
                {
                    _tqjc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wgjc
        /// 属性描述：外观检查情况
        /// 字段信息：[wgjc],nvarchar
        /// </summary>
        [DisplayNameAttribute("外观检查情况")]
        public string wgjc
        {
            get { return _wgjc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[外观检查情况]长度不能大于50!");
                if (_wgjc as object == null || !_wgjc.Equals(value))
                {
                    _wgjc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：syjl
        /// 属性描述：实验结论
        /// 字段信息：[syjl],nvarchar
        /// </summary>
        [DisplayNameAttribute("实验结论")]
        public string syjl
        {
            get { return _syjl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[实验结论]长度不能大于50!");
                if (_syjl as object == null || !_syjl.Equals(value))
                {
                    _syjl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：syz
        /// 属性描述：试验者
        /// 字段信息：[syz],nvarchar
        /// </summary>
        [DisplayNameAttribute("试验者")]
        public string syz
        {
            get { return _syz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[试验者]长度不能大于50!");
                if (_syz as object == null || !_syz.Equals(value))
                {
                    _syz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gznrID
        /// 属性描述：gznrID
        /// 字段信息：[gznrID],nvarchar
        /// </summary>
        [DisplayNameAttribute("gznrID")]
        public string gznrID
        {
            get { return _gznrid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[gznrID]长度不能大于50!");
                if (_gznrid as object == null || !_gznrid.Equals(value))
                {
                    _gznrid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateMan
        /// 属性描述：填写人
        /// 字段信息：[CreateMan],nvarchar
        /// </summary>
        [DisplayNameAttribute("填写人")]
        public string CreateMan
        {
            get { return _createman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[填写人]长度不能大于10!");
                if (_createman as object == null || !_createman.Equals(value))
                {
                    _createman = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateDate
        /// 属性描述：填写日期
        /// 字段信息：[CreateDate],datetime
        /// </summary>
        [DisplayNameAttribute("填写日期")]
        public DateTime CreateDate
        {
            get { return _createdate; }
            set
            {			
                if (_createdate as object == null || !_createdate.Equals(value))
                {
                    _createdate = value;
                }
            }			 
        }
  
        #endregion 
  
        #region 方法
        public static string Newid(){
            return DateTime.Now.ToString("yyyyMMddHHmmssffffff");
        }
        public string CreateID(){
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            return DateTime.Now.ToString("yyyyMMddHHmmssffffff");
        }
        #endregion		
    }	
}
