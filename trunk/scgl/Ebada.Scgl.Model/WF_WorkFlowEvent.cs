/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-6 9:43:45
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_WorkFlowEvent]业务实体类
    ///对应表名:PS_WorkFlowEvent
    /// </summary>
    [Serializable]
    public class WF_WorkFlowEvent
    {
        
        #region Private 成员
        private string _guid=Newid(); 
        private string _workflowid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _remark=String.Empty; 
        private bool _otsms=false; 
        private bool _otmsg=false; 
        private bool _otemail=false; 
        private bool _rmsms=false; 
        private bool _rmmsg=false; 
        private bool _rmemail=false; 
        private string _ottousers=String.Empty; 
        private string _rmtousers=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：Guid
        /// 属性描述：
        /// 字段信息：[Guid],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string Guid
        {
            get { return _guid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_guid as object == null || !_guid.Equals(value))
                {
                    _guid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkFlowId
        /// 属性描述：
        /// 字段信息：[WorkFlowId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorkFlowId
        {
            get { return _workflowid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_workflowid as object == null || !_workflowid.Equals(value))
                {
                    _workflowid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkTaskId
        /// 属性描述：
        /// 字段信息：[WorkTaskId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorkTaskId
        {
            get { return _worktaskid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_worktaskid as object == null || !_worktaskid.Equals(value))
                {
                    _worktaskid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Remark
        /// 属性描述：
        /// 字段信息：[Remark],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Remark
        {
            get { return _remark; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 256)
                throw new Exception("[]长度不能大于256!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OtSms
        /// 属性描述：
        /// 字段信息：[OtSms],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool OtSms
        {
            get { return _otsms; }
            set
            {			
                if (_otsms as object == null || !_otsms.Equals(value))
                {
                    _otsms = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OtMsg
        /// 属性描述：
        /// 字段信息：[OtMsg],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool OtMsg
        {
            get { return _otmsg; }
            set
            {			
                if (_otmsg as object == null || !_otmsg.Equals(value))
                {
                    _otmsg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OtEmail
        /// 属性描述：
        /// 字段信息：[OtEmail],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool OtEmail
        {
            get { return _otemail; }
            set
            {			
                if (_otemail as object == null || !_otemail.Equals(value))
                {
                    _otemail = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RmSms
        /// 属性描述：
        /// 字段信息：[RmSms],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool RmSms
        {
            get { return _rmsms; }
            set
            {			
                if (_rmsms as object == null || !_rmsms.Equals(value))
                {
                    _rmsms = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RmMsg
        /// 属性描述：
        /// 字段信息：[RmMsg],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool RmMsg
        {
            get { return _rmmsg; }
            set
            {			
                if (_rmmsg as object == null || !_rmmsg.Equals(value))
                {
                    _rmmsg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RmEmail
        /// 属性描述：
        /// 字段信息：[RmEmail],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool RmEmail
        {
            get { return _rmemail; }
            set
            {			
                if (_rmemail as object == null || !_rmemail.Equals(value))
                {
                    _rmemail = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OtToUsers
        /// 属性描述：
        /// 字段信息：[OtToUsers],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string OtToUsers
        {
            get { return _ottousers; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_ottousers as object == null || !_ottousers.Equals(value))
                {
                    _ottousers = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RmToUsers
        /// 属性描述：
        /// 字段信息：[RmToUsers],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string RmToUsers
        {
            get { return _rmtousers; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_rmtousers as object == null || !_rmtousers.Equals(value))
                {
                    _rmtousers = value;
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
