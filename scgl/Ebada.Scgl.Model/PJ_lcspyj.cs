/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-10-4 19:13:31
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_lcspyj]业务实体类
    ///对应表名:PJ_lcspyj
    /// </summary>
    [Serializable]
    public class PJ_lcspyj
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _recordid=String.Empty; 
        private string _spyj=String.Empty; 
        private DateTime _sptime=new DateTime(1900,1,1); 
        private string _reserve1=String.Empty; 
        private string _reserve2=String.Empty;   
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
        /// 属性名称：RecordID
        /// 属性描述：
        /// 字段信息：[RecordID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string RecordID
        {
            get { return _recordid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_recordid as object == null || !_recordid.Equals(value))
                {
                    _recordid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Spyj
        /// 属性描述：审批意见
        /// 字段信息：[Spyj],nvarchar
        /// </summary>
        [DisplayNameAttribute("审批意见")]
        public string Spyj
        {
            get { return _spyj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[审批意见]长度不能大于1073741823!");
                if (_spyj as object == null || !_spyj.Equals(value))
                {
                    _spyj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Sptime
        /// 属性描述：审批时间
        /// 字段信息：[Sptime],datetime
        /// </summary>
        [DisplayNameAttribute("审批时间")]
        public DateTime Sptime
        {
            get { return _sptime; }
            set
            {			
                if (_sptime as object == null || !_sptime.Equals(value))
                {
                    _sptime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Reserve1
        /// 属性描述：备用字段1
        /// 字段信息：[Reserve1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段1")]
        public string Reserve1
        {
            get { return _reserve1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用字段1]长度不能大于50!");
                if (_reserve1 as object == null || !_reserve1.Equals(value))
                {
                    _reserve1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Reserve2
        /// 属性描述：备用字段1
        /// 字段信息：[Reserve2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段1")]
        public string Reserve2
        {
            get { return _reserve2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用字段1]长度不能大于50!");
                if (_reserve2 as object == null || !_reserve2.Equals(value))
                {
                    _reserve2 = value;
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
