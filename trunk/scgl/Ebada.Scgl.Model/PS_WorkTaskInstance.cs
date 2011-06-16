/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-5 19:35:57
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_WorkTaskInstance]业务实体类
    ///对应表名:PS_WorkTaskInstance
    /// </summary>
    [Serializable]
    public class PS_WorkTaskInstance
    {
        
        #region Private 成员
        private string _worktaskinsid=Newid(); 
        private string _workflowid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _workflowinsid=String.Empty; 
        private string _previoustaskid=String.Empty; 
        private string _taskinscaption=String.Empty; 
        private DateTime _starttime=  DateTime.Now;
        private DateTime _endtime = DateTime.Now; 
        private string _status=String.Empty; 
        private string _operateddes=String.Empty; 
        private string _operatorinsid=String.Empty; 
        private string _successmsg=String.Empty; 
        private bool _outtimeed=false; 
        private bool _reminded=false; 
        private string _taskinsdescription=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：WorkTaskInsId
        /// 属性描述：
        /// 字段信息：[WorkTaskInsId],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string WorkTaskInsId
        {
            get { return _worktaskinsid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_worktaskinsid as object == null || !_worktaskinsid.Equals(value))
                {
                    _worktaskinsid = value;
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
        /// 属性名称：WorkFlowInsId
        /// 属性描述：
        /// 字段信息：[WorkFlowInsId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorkFlowInsId
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
        /// 属性名称：PreviousTaskId
        /// 属性描述：
        /// 字段信息：[PreviousTaskId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string PreviousTaskId
        {
            get { return _previoustaskid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_previoustaskid as object == null || !_previoustaskid.Equals(value))
                {
                    _previoustaskid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TaskInsCaption
        /// 属性描述：
        /// 字段信息：[TaskInsCaption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string TaskInsCaption
        {
            get { return _taskinscaption; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 128)
                throw new Exception("[]长度不能大于128!");
                if (_taskinscaption as object == null || !_taskinscaption.Equals(value))
                {
                    _taskinscaption = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：StartTime
        /// 属性描述：
        /// 字段信息：[StartTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime StartTime
        {
            get { return _starttime; }
            set
            {			
                if (_starttime as object == null || !_starttime.Equals(value))
                {
                    _starttime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：EndTime
        /// 属性描述：
        /// 字段信息：[EndTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime EndTime
        {
            get { return _endtime; }
            set
            {			
                if (_endtime as object == null || !_endtime.Equals(value))
                {
                    _endtime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Status
        /// 属性描述：
        /// 字段信息：[Status],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string Status
        {
            get { return _status; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1)
                throw new Exception("[]长度不能大于1!");
                if (_status as object == null || !_status.Equals(value))
                {
                    _status = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OperatedDes
        /// 属性描述：
        /// 字段信息：[OperatedDes],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string OperatedDes
        {
            get { return _operateddes; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 256)
                throw new Exception("[]长度不能大于256!");
                if (_operateddes as object == null || !_operateddes.Equals(value))
                {
                    _operateddes = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OperatorInsId
        /// 属性描述：
        /// 字段信息：[OperatorInsId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string OperatorInsId
        {
            get { return _operatorinsid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_operatorinsid as object == null || !_operatorinsid.Equals(value))
                {
                    _operatorinsid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SuccessMsg
        /// 属性描述：
        /// 字段信息：[SuccessMsg],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string SuccessMsg
        {
            get { return _successmsg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_successmsg as object == null || !_successmsg.Equals(value))
                {
                    _successmsg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OutTimeed
        /// 属性描述：
        /// 字段信息：[OutTimeed],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool OutTimeed
        {
            get { return _outtimeed; }
            set
            {			
                if (_outtimeed as object == null || !_outtimeed.Equals(value))
                {
                    _outtimeed = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Reminded
        /// 属性描述：
        /// 字段信息：[Reminded],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool Reminded
        {
            get { return _reminded; }
            set
            {			
                if (_reminded as object == null || !_reminded.Equals(value))
                {
                    _reminded = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TaskInsDescription
        /// 属性描述：
        /// 字段信息：[TaskInsDescription],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string TaskInsDescription
        {
            get { return _taskinsdescription; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 256)
                throw new Exception("[]长度不能大于256!");
                if (_taskinsdescription as object == null || !_taskinsdescription.Equals(value))
                {
                    _taskinsdescription = value;
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
