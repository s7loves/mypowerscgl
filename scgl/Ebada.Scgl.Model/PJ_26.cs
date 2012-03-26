/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-12-13 14:08:38
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_26]业务实体类
    ///对应表名:PJ_26
    /// </summary>
    [Serializable]
    public class PJ_26
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _xybh=String.Empty; 
        private string _tzdw=String.Empty; 
        private DateTime _tzrq=new DateTime(1900,1,1); 
        private string _linevol=String.Empty; 
        private string _fxwt=String.Empty; 
        private string _clcs=String.Empty; 
        private string _remark=String.Empty; 
        private string _gzrjid=String.Empty; 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1); 
        private byte[] _bigdata=new byte[]{};   
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
        /// 属性名称：ParentID
        /// 属性描述：ParentID
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("ParentID")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[ParentID]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xybh
        /// 属性描述：协议编号
        /// 字段信息：[xybh],nvarchar
        /// </summary>
        [DisplayNameAttribute("协议编号")]
        public string xybh
        {
            get { return _xybh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_xybh as object == null || !_xybh.Equals(value))
                {
                    _xybh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tzdw
        /// 属性描述：通知单位
        /// 字段信息：[tzdw],nvarchar
        /// </summary>
        [DisplayNameAttribute("通知单位")]
        public string tzdw
        {
            get { return _tzdw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[通知单位]长度不能大于50!");
                if (_tzdw as object == null || !_tzdw.Equals(value))
                {
                    _tzdw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tzrq
        /// 属性描述：通知日期
        /// 字段信息：[tzrq],datetime
        /// </summary>
        [DisplayNameAttribute("通知日期")]
        public DateTime tzrq
        {
            get { return _tzrq; }
            set
            {			
                if (_tzrq as object == null || !_tzrq.Equals(value))
                {
                    _tzrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lineVol
        /// 属性描述：线路电压
        /// 字段信息：[lineVol],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路电压")]
        public string lineVol
        {
            get { return _linevol; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路电压]长度不能大于50!");
                if (_linevol as object == null || !_linevol.Equals(value))
                {
                    _linevol = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fxwt
        /// 属性描述：发现问题
        /// 字段信息：[fxwt],nvarchar
        /// </summary>
        [DisplayNameAttribute("发现问题")]
        public string fxwt
        {
            get { return _fxwt; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[发现问题]长度不能大于500!");
                if (_fxwt as object == null || !_fxwt.Equals(value))
                {
                    _fxwt = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：clcs
        /// 属性描述：处理措施
        /// 字段信息：[clcs],nvarchar
        /// </summary>
        [DisplayNameAttribute("处理措施")]
        public string clcs
        {
            get { return _clcs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[处理措施]长度不能大于500!");
                if (_clcs as object == null || !_clcs.Equals(value))
                {
                    _clcs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Remark
        /// 属性描述：备注
        /// 字段信息：[Remark],nvarchar
        /// </summary>
        [DisplayNameAttribute("备注")]
        public string Remark
        {
            get { return _remark; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备注]长度不能大于50!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
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
  
        /// <summary>
        /// 属性名称：CreateMan
        /// 属性描述：操作员
        /// 字段信息：[CreateMan],nvarchar
        /// </summary>
        [DisplayNameAttribute("操作员")]
        public string CreateMan
        {
            get { return _createman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[操作员]长度不能大于10!");
                if (_createman as object == null || !_createman.Equals(value))
                {
                    _createman = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateDate
        /// 属性描述：生成日期
        /// 字段信息：[CreateDate],datetime
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("生成日期")]
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
        /// 属性名称：BigData
        /// 属性描述：生成文档
        /// 字段信息：[BigData],image
        /// </summary>
        [DisplayNameAttribute("生成文档")]
        public byte[] BigData
        {
            get { return _bigdata; }
            set
            {			
                if (_bigdata as object == null || !_bigdata.Equals(value))
                {
                    _bigdata = value;
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
