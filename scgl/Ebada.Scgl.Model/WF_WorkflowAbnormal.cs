/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-10 18:11:02
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_WorkflowAbnormal]业务实体类
    ///对应表名:PS_WorkflowAbnormal
    /// </summary>
    [Serializable]
    public class WF_WorkflowAbnormal
    {
        
        #region Private 成员
        private string _abnormalid=Newid(); 
        private string _workflowinsid=String.Empty; 
        private string _userid=String.Empty; 
        private string _abnormalmsg=String.Empty;
        private DateTime _abnormaltime = DateTime.Now; 
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：AbnormalId
        /// 属性描述：
        /// 字段信息：[AbnormalId],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string AbnormalId
        {
            get { return _abnormalid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_abnormalid as object == null || !_abnormalid.Equals(value))
                {
                    _abnormalid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkflowInsId
        /// 属性描述：
        /// 字段信息：[WorkflowInsId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorkflowInsId
        {
            get { return _workflowinsid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_workflowinsid as object == null || !_workflowinsid.Equals(value))
                {
                    _workflowinsid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserId
        /// 属性描述：
        /// 字段信息：[UserId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string UserId
        {
            get { return _userid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_userid as object == null || !_userid.Equals(value))
                {
                    _userid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：AbnormalMsg
        /// 属性描述：
        /// 字段信息：[AbnormalMsg],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string AbnormalMsg
        {
            get { return _abnormalmsg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_abnormalmsg as object == null || !_abnormalmsg.Equals(value))
                {
                    _abnormalmsg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：AbnormalTime
        /// 属性描述：
        /// 字段信息：[AbnormalTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime AbnormalTime
        {
            get { return _abnormaltime; }
            set
            {			
                if (_abnormaltime as object == null || !_abnormaltime.Equals(value))
                {
                    _abnormaltime = value;
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
