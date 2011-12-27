/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-12-27 21:14:20
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_jsbpjjh]业务实体类
    ///对应表名:PJ_jsbpjjh
    /// </summary>
    [Serializable]
    public class PJ_jsbpjjh
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _gzxm=String.Empty; 
        private DateTime _wcsj=new DateTime(1900,1,1); 
        private string _lsr=String.Empty; 
        private string _dbr=String.Empty; 
        private string _lsyq=String.Empty; 
        private string _remark=String.Empty;   
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
        /// 属性名称：gzxm
        /// 属性描述：工作项目
        /// 字段信息：[gzxm],nvarchar
        /// </summary>
        [DisplayNameAttribute("工作项目")]
        public string gzxm
        {
            get { return _gzxm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[工作项目]长度不能大于500!");
                if (_gzxm as object == null || !_gzxm.Equals(value))
                {
                    _gzxm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wcsj
        /// 属性描述：完成时间
        /// 字段信息：[wcsj],datetime
        /// </summary>
        [DisplayNameAttribute("完成时间")]
        public DateTime wcsj
        {
            get { return _wcsj; }
            set
            {			
                if (_wcsj as object == null || !_wcsj.Equals(value))
                {
                    _wcsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lsr
        /// 属性描述：落实人
        /// 字段信息：[lsr],nvarchar
        /// </summary>
        [DisplayNameAttribute("落实人")]
        public string lsr
        {
            get { return _lsr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[落实人]长度不能大于50!");
                if (_lsr as object == null || !_lsr.Equals(value))
                {
                    _lsr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dbr
        /// 属性描述：督办人
        /// 字段信息：[dbr],nvarchar
        /// </summary>
        [DisplayNameAttribute("督办人")]
        public string dbr
        {
            get { return _dbr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[督办人]长度不能大于50!");
                if (_dbr as object == null || !_dbr.Equals(value))
                {
                    _dbr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lsyq
        /// 属性描述：落实要求
        /// 字段信息：[lsyq],nvarchar
        /// </summary>
        [DisplayNameAttribute("落实要求")]
        public string lsyq
        {
            get { return _lsyq; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[落实要求]长度不能大于500!");
                if (_lsyq as object == null || !_lsyq.Equals(value))
                {
                    _lsyq = value;
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
                if( value.ToString().Length > 500)
                throw new Exception("[备注]长度不能大于500!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
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
