/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-4-18 15:15:40
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sdjl_04sgzayc]业务实体类
    ///对应表名:sdjl_04sgzayc
    /// </summary>
    [Serializable]
    public class sdjl_04sgzayc
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _fsdd=String.Empty; 
        private DateTime _tdsj=new DateTime(1900,1,1); 
        private DateTime _sdsj=new DateTime(1900,1,1); 
        private string _gtdsj=String.Empty; 
        private decimal _ssdl=0; 
        private string _clqk=String.Empty; 
        private string _yyfx=String.Empty; 
        private string _fzdc=String.Empty; 
        private string _zxr=String.Empty; 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1); 
        private string _gznrid=String.Empty; 
        private string _charman=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty; 
        private string _c4=String.Empty; 
        private string _c5=String.Empty;   
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
        /// 属性名称：fsdd
        /// 属性描述：发生地点
        /// 字段信息：[fsdd],nvarchar
        /// </summary>
        [DisplayNameAttribute("发生地点")]
        public string fsdd
        {
            get { return _fsdd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 150)
                throw new Exception("[发生地点]长度不能大于150!");
                if (_fsdd as object == null || !_fsdd.Equals(value))
                {
                    _fsdd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdsj
        /// 属性描述：停电时间
        /// 字段信息：[tdsj],datetime
        /// </summary>
        [DisplayNameAttribute("停电时间")]
        public DateTime tdsj
        {
            get { return _tdsj; }
            set
            {			
                if (_tdsj as object == null || !_tdsj.Equals(value))
                {
                    _tdsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdsj
        /// 属性描述：送电时间
        /// 字段信息：[sdsj],datetime
        /// </summary>
        [DisplayNameAttribute("送电时间")]
        public DateTime sdsj
        {
            get { return _sdsj; }
            set
            {			
                if (_sdsj as object == null || !_sdsj.Equals(value))
                {
                    _sdsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtdsj
        /// 属性描述：共停电时间（时分）
        /// 字段信息：[gtdsj],nvarchar
        /// </summary>
        [DisplayNameAttribute("共停电时间（时分）")]
        public string gtdsj
        {
            get { return _gtdsj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[共停电时间（时分）]长度不能大于50!");
                if (_gtdsj as object == null || !_gtdsj.Equals(value))
                {
                    _gtdsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ssdl
        /// 属性描述：损失电量
        /// 字段信息：[ssdl],decimal
        /// </summary>
        [DisplayNameAttribute("损失电量")]
        public decimal ssdl
        {
            get { return _ssdl; }
            set
            {			
                if (_ssdl as object == null || !_ssdl.Equals(value))
                {
                    _ssdl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：clqk
        /// 属性描述：事故情况及处理经过
        /// 字段信息：[clqk],nvarchar
        /// </summary>
        [DisplayNameAttribute("事故情况及处理经过")]
        public string clqk
        {
            get { return _clqk; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 4000)
                throw new Exception("[事故情况及处理经过]长度不能大于4000!");
                if (_clqk as object == null || !_clqk.Equals(value))
                {
                    _clqk = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：yyfx
        /// 属性描述：主要原因分析
        /// 字段信息：[yyfx],nvarchar
        /// </summary>
        [DisplayNameAttribute("主要原因分析")]
        public string yyfx
        {
            get { return _yyfx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 4000)
                throw new Exception("[主要原因分析]长度不能大于4000!");
                if (_yyfx as object == null || !_yyfx.Equals(value))
                {
                    _yyfx = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fzdc
        /// 属性描述：今后防止对策
        /// 字段信息：[fzdc],nvarchar
        /// </summary>
        [DisplayNameAttribute("今后防止对策")]
        public string fzdc
        {
            get { return _fzdc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[今后防止对策]长度不能大于500!");
                if (_fzdc as object == null || !_fzdc.Equals(value))
                {
                    _fzdc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zxr
        /// 属性描述：防止对策执行人
        /// 字段信息：[zxr],nvarchar
        /// </summary>
        [DisplayNameAttribute("防止对策执行人")]
        public string zxr
        {
            get { return _zxr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[防止对策执行人]长度不能大于50!");
                if (_zxr as object == null || !_zxr.Equals(value))
                {
                    _zxr = value;
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
        /// 属性名称：charMan
        /// 属性描述：处理人
        /// 字段信息：[charMan],nvarchar
        /// </summary>
        [DisplayNameAttribute("处理人")]
        public string charMan
        {
            get { return _charman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[处理人]长度不能大于50!");
                if (_charman as object == null || !_charman.Equals(value))
                {
                    _charman = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c1
        /// 属性描述：备用字段1
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段1")]
        public string c1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段1]长度不能大于500!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c2
        /// 属性描述：备用字段2
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段2")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段2]长度不能大于500!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c3
        /// 属性描述：备用字段3
        /// 字段信息：[c3],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段3")]
        public string c3
        {
            get { return _c3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段3]长度不能大于500!");
                if (_c3 as object == null || !_c3.Equals(value))
                {
                    _c3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c4
        /// 属性描述：备用字段4
        /// 字段信息：[c4],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段4")]
        public string c4
        {
            get { return _c4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段4]长度不能大于500!");
                if (_c4 as object == null || !_c4.Equals(value))
                {
                    _c4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c5
        /// 属性描述：备用字段5
        /// 字段信息：[c5],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段5")]
        public string c5
        {
            get { return _c5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段5]长度不能大于500!");
                if (_c5 as object == null || !_c5.Equals(value))
                {
                    _c5 = value;
                }
            }			 
        }
  
        #endregion 
  
        #region 方法
        public static string Newid(){
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        public string CreateID(){
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        #endregion		
    }	
}
