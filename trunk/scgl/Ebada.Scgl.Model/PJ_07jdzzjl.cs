/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-26 20:53:59
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_07jdzzjl]业务实体类
    ///对应表名:PJ_07jdzzjl
    /// </summary>
    [Serializable]
    public class PJ_07jdzzjl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _jdzzid=String.Empty; 
        private DateTime _clrq=new DateTime(1900,1,1); 
        private string _tq=String.Empty; 
        private decimal _scz=0; 
        private decimal _hsz=0; 
        private string _jcqk=String.Empty; 
        private string _jr=String.Empty; 
        private string _jcr=String.Empty; 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1); 
        private string _gzrjid=String.Empty;   
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
        /// 属性名称：jdzzID
        /// 属性描述：接地装置ID
        /// 字段信息：[jdzzID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("接地装置ID")]
        public string jdzzID
        {
            get { return _jdzzid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[接地装置ID]长度不能大于50!");
                if (_jdzzid as object == null || !_jdzzid.Equals(value))
                {
                    _jdzzid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：clrq
        /// 属性描述：测量日期
        /// 字段信息：[clrq],datetime
        /// </summary>
        [DisplayNameAttribute("测量日期")]
        public DateTime clrq
        {
            get { return _clrq; }
            set
            {			
                if (_clrq as object == null || !_clrq.Equals(value))
                {
                    _clrq = value;
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
        /// 属性名称：scz
        /// 属性描述：实测值
        /// 字段信息：[scz],decimal
        /// </summary>
        [DisplayNameAttribute("实测值")]
        public decimal scz
        {
            get { return _scz; }
            set
            {			
                if (_scz as object == null || !_scz.Equals(value))
                {
                    _scz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：hsz
        /// 属性描述：换算值
        /// 字段信息：[hsz],decimal
        /// </summary>
        [DisplayNameAttribute("换算值")]
        public decimal hsz
        {
            get { return _hsz; }
            set
            {			
                if (_hsz as object == null || !_hsz.Equals(value))
                {
                    _hsz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jcqk
        /// 属性描述：检测情况
        /// 字段信息：[jcqk],nvarchar
        /// </summary>
        [DisplayNameAttribute("检测情况")]
        public string jcqk
        {
            get { return _jcqk; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[检测情况]长度不能大于50!");
                if (_jcqk as object == null || !_jcqk.Equals(value))
                {
                    _jcqk = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jr
        /// 属性描述：结论
        /// 字段信息：[jr],nvarchar
        /// </summary>
        [DisplayNameAttribute("结论")]
        public string jr
        {
            get { return _jr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[结论]长度不能大于50!");
                if (_jr as object == null || !_jr.Equals(value))
                {
                    _jr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jcr
        /// 属性描述：检测人
        /// 字段信息：[jcr],nvarchar
        /// </summary>
        [DisplayNameAttribute("检测人")]
        public string jcr
        {
            get { return _jcr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[检测人]长度不能大于10!");
                if (_jcr as object == null || !_jcr.Equals(value))
                {
                    _jcr = value;
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
        /// 属性名称：gzrjID
        /// 属性描述：gzrjID
        /// 字段信息：[gzrjID],nvarchar
        /// </summary>
        [DisplayNameAttribute("gzrjID")]
        public string gzrjID
        {
            get { return _gzrjid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[gzrjID]长度不能大于50!");
                if (_gzrjid as object == null || !_gzrjid.Equals(value))
                {
                    _gzrjid = value;
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
