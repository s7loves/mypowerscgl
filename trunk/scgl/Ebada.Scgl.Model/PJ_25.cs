/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-10 14:57:59
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_25]业务实体类
    ///对应表名:PJ_25
    /// </summary>
    [Serializable]
    public class PJ_25
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _cqdw=String.Empty; 
        private DateTime _qdrq=new DateTime(1900,1,1); 
        private string _remark=String.Empty; 
        private string _gzrjid=String.Empty; 
        private string _createman=String.Empty;
        private string _bszz = String.Empty;
        private string _fzcs = String.Empty; 
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
        /// 属性名称：cqdw
        /// 属性描述：产权单位
        /// 字段信息：[cqdw],nvarchar
        /// </summary>
        [DisplayNameAttribute("产权单位")]
        public string cqdw
        {
            get { return _cqdw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[产权单位]长度不能大于50!");
                if (_cqdw as object == null || !_cqdw.Equals(value))
                {
                    _cqdw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qdrq
        /// 属性描述：签订日期
        /// 字段信息：[qdrq],datetime
        /// </summary>
        [DisplayNameAttribute("签订日期")]
        public DateTime qdrq
        {
            get { return _qdrq; }
            set
            {			
                if (_qdrq as object == null || !_qdrq.Equals(value))
                {
                    _qdrq = value;
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
        /// 属性名称：bszz
        /// 属性描述：闭锁装置
        /// 字段信息：[bszz],nvarchar
        /// </summary>
        [DisplayNameAttribute("闭锁装置")]
        public string bszz
        {
            get { return _bszz; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[操作员]长度不能大于10!");
                if (_bszz as object == null || !_bszz.Equals(value))
                {
                    _bszz = value;
                }
            }
        }
        /// <summary>
        /// 属性名称：fzcs
        /// 属性描述：防倒送电措施
        /// 字段信息：[fzcs],nvarchar
        /// </summary>
        [DisplayNameAttribute("防倒送电措施")]
        public string fzcs
        {
            get { return _fzcs; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 100)
                    throw new Exception("[备注]长度不能大于100!");
                if (_fzcs as object == null || !_fzcs.Equals(value))
                {
                    _fzcs = value;
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
