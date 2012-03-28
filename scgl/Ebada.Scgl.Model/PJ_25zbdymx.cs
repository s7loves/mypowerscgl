/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-3-28 10:06:48
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_25zbdymx]业务实体类
    ///对应表名:PJ_25zbdymx
    /// </summary>
    [Serializable]
    public class PJ_25zbdymx
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _type=String.Empty; 
        private string _xh=String.Empty; 
        private double _gl=0; 
        private int _ts=0; 
        private int _dy=0; 
        private DateTime _azrq=new DateTime(1900,1,1); 
        private string _sccj=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1);   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ParentID
        /// 属性描述：
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Type
        /// 属性描述：类型
        /// 字段信息：[Type],nvarchar
        /// </summary>
        [DisplayNameAttribute("类型")]
        public string Type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[类型]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xh
        /// 属性描述：型号
        /// 字段信息：[xh],nvarchar
        /// </summary>
        [DisplayNameAttribute("型号")]
        public string xh
        {
            get { return _xh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[型号]长度不能大于50!");
                if (_xh as object == null || !_xh.Equals(value))
                {
                    _xh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gl
        /// 属性描述：功率
        /// 字段信息：[gl],float
        /// </summary>
        [DisplayNameAttribute("功率")]
        public double gl
        {
            get { return _gl; }
            set
            {			
                if (_gl as object == null || !_gl.Equals(value))
                {
                    _gl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ts
        /// 属性描述：台数
        /// 字段信息：[ts],int
        /// </summary>
        [DisplayNameAttribute("台数")]
        public int ts
        {
            get { return _ts; }
            set
            {			
                if (_ts as object == null || !_ts.Equals(value))
                {
                    _ts = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dy
        /// 属性描述：电压
        /// 字段信息：[dy],int
        /// </summary>
        [DisplayNameAttribute("电压")]
        public int dy
        {
            get { return _dy; }
            set
            {			
                if (_dy as object == null || !_dy.Equals(value))
                {
                    _dy = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：azrq
        /// 属性描述：安装日期
        /// 字段信息：[azrq],datetime
        /// </summary>
        [DisplayNameAttribute("安装日期")]
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
        /// 属性名称：sccj
        /// 属性描述：生产厂家
        /// 字段信息：[sccj],nvarchar
        /// </summary>
        [DisplayNameAttribute("生产厂家")]
        public string sccj
        {
            get { return _sccj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[生产厂家]长度不能大于50!");
                if (_sccj as object == null || !_sccj.Equals(value))
                {
                    _sccj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Createdate
        /// 属性描述：
        /// 字段信息：[Createdate],datetime
        /// </summary>‘
		[Browsable(false)]
        [DisplayNameAttribute("")]
        public DateTime Createdate
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
