/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-26 20:53:58
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_01gzrj]业务实体类
    ///对应表名:PJ_01gzrj
    /// </summary>
    [Serializable]
    public class PJ_01gzrj
    {
        
        #region Private 成员
        private string _gzrjid=Newid(); 
        private string _gdscode=String.Empty; 
        private string _gdsname=String.Empty; 
        private DateTime _rq=new DateTime(1900,1,1); 
        private string _xq=String.Empty; 
        private string _tq=String.Empty; 
        private string _qqry=String.Empty; 
        private int _rsaqts=0; 
        private int _sbaqts=0; 
        private string _js=String.Empty; 
        private string _py=String.Empty; 
        private string _qz=String.Empty; 
        private DateTime _qzrq=new DateTime(1900,1,1); 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1);   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：gzrjID
        /// 属性描述：记录ID
        /// 字段信息：[gzrjID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("记录ID")]
        public string gzrjID
        {
            get { return _gzrjid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[记录ID]长度不能大于50!");
                if (_gzrjid as object == null || !_gzrjid.Equals(value))
                {
                    _gzrjid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：GdsCode
        /// 属性描述：供电所代码
        /// 字段信息：[GdsCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("供电所代码")]
        public string GdsCode
        {
            get { return _gdscode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[供电所代码]长度不能大于50!");
                if (_gdscode as object == null || !_gdscode.Equals(value))
                {
                    _gdscode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：GdsName
        /// 属性描述：供电所名称
        /// 字段信息：[GdsName],nvarchar
        /// </summary>
        [DisplayNameAttribute("供电所名称")]
        public string GdsName
        {
            get { return _gdsname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[供电所名称]长度不能大于50!");
                if (_gdsname as object == null || !_gdsname.Equals(value))
                {
                    _gdsname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：rq
        /// 属性描述：日期
        /// 字段信息：[rq],datetime
        /// </summary>
        [DisplayNameAttribute("日期")]
        public DateTime rq
        {
            get { return _rq; }
            set
            {			
                if (_rq as object == null || !_rq.Equals(value))
                {
                    _rq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xq
        /// 属性描述：星期
        /// 字段信息：[xq],nvarchar
        /// </summary>
        [DisplayNameAttribute("星期")]
        public string xq
        {
            get { return _xq; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[星期]长度不能大于50!");
                if (_xq as object == null || !_xq.Equals(value))
                {
                    _xq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tq
        /// 属性描述：天气
        /// 字段信息：[tq],nvarchar
        /// </summary>
        [DisplayNameAttribute("天气")]
        public string tq
        {
            get { return _tq; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[天气]长度不能大于50!");
                if (_tq as object == null || !_tq.Equals(value))
                {
                    _tq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qqry
        /// 属性描述：缺勤情况
        /// 字段信息：[qqry],nvarchar
        /// </summary>
        [DisplayNameAttribute("缺勤情况")]
        public string qqry
        {
            get { return _qqry; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[缺勤情况]长度不能大于500!");
                if (_qqry as object == null || !_qqry.Equals(value))
                {
                    _qqry = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：rsaqts
        /// 属性描述：人身安全天数
        /// 字段信息：[rsaqts],int
        /// </summary>
        [DisplayNameAttribute("人身安全天数")]
        public int rsaqts
        {
            get { return _rsaqts; }
            set
            {			
                if (_rsaqts as object == null || !_rsaqts.Equals(value))
                {
                    _rsaqts = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbaqts
        /// 属性描述：设备安全天数
        /// 字段信息：[sbaqts],int
        /// </summary>
        [DisplayNameAttribute("设备安全天数")]
        public int sbaqts
        {
            get { return _sbaqts; }
            set
            {			
                if (_sbaqts as object == null || !_sbaqts.Equals(value))
                {
                    _sbaqts = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：js
        /// 属性描述：记事
        /// 字段信息：[js],nvarchar
        /// </summary>
        [DisplayNameAttribute("记事")]
        public string js
        {
            get { return _js; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[记事]长度不能大于500!");
                if (_js as object == null || !_js.Equals(value))
                {
                    _js = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：py
        /// 属性描述：评语
        /// 字段信息：[py],nvarchar
        /// </summary>
        [DisplayNameAttribute("评语")]
        public string py
        {
            get { return _py; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[评语]长度不能大于500!");
                if (_py as object == null || !_py.Equals(value))
                {
                    _py = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qz
        /// 属性描述：签字
        /// 字段信息：[qz],nvarchar
        /// </summary>
        [DisplayNameAttribute("签字")]
        public string qz
        {
            get { return _qz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[签字]长度不能大于50!");
                if (_qz as object == null || !_qz.Equals(value))
                {
                    _qz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qzrq
        /// 属性描述：签字日期
        /// 字段信息：[qzrq],datetime
        /// </summary>
        [DisplayNameAttribute("签字日期")]
        public DateTime qzrq
        {
            get { return _qzrq; }
            set
            {			
                if (_qzrq as object == null || !_qzrq.Equals(value))
                {
                    _qzrq = value;
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
        [Browsable(false)]
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
