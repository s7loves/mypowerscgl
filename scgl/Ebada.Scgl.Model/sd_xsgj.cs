/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-3-22 8:59:47
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sd_xsgj]业务实体类
    ///对应表名:sd_xsgj
    /// </summary>
    [Serializable]
    public class sd_xsgj
    {
        
        #region Private 成员
        private long _id=0; 
        private string _rwid=String.Empty; 
        private DateTime _sj=new DateTime(1900,1,1); 
        private double _jd=0; 
        private double _wd=0;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],bigint
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("ID")]
        public long ID
        {
            get { return _id; }
            set
            {			
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：rwID
        /// 属性描述：任务ID
        /// 字段信息：[rwID],nvarchar
        /// </summary>
        [DisplayNameAttribute("任务ID")]
        public string rwID
        {
            get { return _rwid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 30)
                throw new Exception("[任务ID]长度不能大于30!");
                if (_rwid as object == null || !_rwid.Equals(value))
                {
                    _rwid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sj
        /// 属性描述：时间
        /// 字段信息：[sj],datetime
        /// </summary>
        [DisplayNameAttribute("时间")]
        public DateTime sj
        {
            get { return _sj; }
            set
            {			
                if (_sj as object == null || !_sj.Equals(value))
                {
                    _sj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jd
        /// 属性描述：经度
        /// 字段信息：[jd],float
        /// </summary>
        [DisplayNameAttribute("经度")]
        public double jd
        {
            get { return _jd; }
            set
            {			
                if (_jd as object == null || !_jd.Equals(value))
                {
                    _jd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wd
        /// 属性描述：纬度
        /// 字段信息：[wd],float
        /// </summary>
        [DisplayNameAttribute("纬度")]
        public double wd
        {
            get { return _wd; }
            set
            {			
                if (_wd as object == null || !_wd.Equals(value))
                {
                    _wd = value;
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
