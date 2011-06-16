/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-10 9:50:48
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_WorkTaskInstanceView]业务实体类
    ///对应表名:PS_WorkTaskInstanceView
    /// </summary>
    [Serializable]
    public class WF_WorkTaskInstanceView
    {
        
        #region Private 成员
        private string _priority=String.Empty; 
        private string _workflowno=String.Empty;
        private DateTime _taskstarttime = DateTime.Now; 
        private string _taskinscaption=String.Empty; 
        private string _flowinscaption=String.Empty; 
        private string _opercontent=String.Empty; 
        private string _flowcaption=String.Empty; 
        private string _taskcaption=String.Empty; 
        private string _userid=String.Empty; 
        private string _operatorinsid=String.Empty; 
        private string _workflowid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _workflowinsid=String.Empty; 
        private string _worktaskinsid=String.Empty; 
        private int _opertype=0; 
        private string _tasktypeid=String.Empty; 
        private bool _issubworkflow=false; 
        private string _mainworktaskid=String.Empty; 
        private string _mainworkflowinsid=String.Empty; 
        private string _operateddes=String.Empty;
        private DateTime _operdatetime = DateTime.Now;
        private DateTime _taskendtime = DateTime.Now;
        private DateTime _flowstarttime = DateTime.Now;
        private DateTime _flowendtime = DateTime.Now; 
        private string _poperateddes=String.Empty; 
        private string _description=String.Empty; 
        private string _operstatus=String.Empty; 
        private string _status=String.Empty; 
        private string _flstatus=String.Empty; 
        private string _previoustaskid=String.Empty; 
        private string _opercontenttext=String.Empty; 
        private string _taskinstype=String.Empty; 
        private string _successmsg=String.Empty; 
        private string _changeoperator=String.Empty; 
        private string _taskinsdescription=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：Priority
        /// 属性描述：
        /// 字段信息：[Priority],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string Priority
        {
            get { return _priority; }
            set
            {			
		_priority=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkFlowNo
        /// 属性描述：
        /// 字段信息：[WorkFlowNo],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorkFlowNo
        {
            get { return _workflowno; }
            set
            {			
		_workflowno=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：taskStartTime
        /// 属性描述：
        /// 字段信息：[taskStartTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime taskStartTime
        {
            get { return _taskstarttime; }
            set
            {			
		_taskstarttime=value;	
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
		_taskinscaption=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：FlowInsCaption
        /// 属性描述：
        /// 字段信息：[FlowInsCaption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string FlowInsCaption
        {
            get { return _flowinscaption; }
            set
            {			
		_flowinscaption=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：OperContent
        /// 属性描述：
        /// 字段信息：[OperContent],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string OperContent
        {
            get { return _opercontent; }
            set
            {			
		_opercontent=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：FlowCaption
        /// 属性描述：
        /// 字段信息：[FlowCaption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string FlowCaption
        {
            get { return _flowcaption; }
            set
            {			
		_flowcaption=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：TaskCaption
        /// 属性描述：
        /// 字段信息：[TaskCaption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string TaskCaption
        {
            get { return _taskcaption; }
            set
            {			
		_taskcaption=value;	
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
		_userid=value;	
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
		_operatorinsid=value;	
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
		_workflowid=value;	
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
		_worktaskid=value;	
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
		_workflowinsid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkTaskInsId
        /// 属性描述：
        /// 字段信息：[WorkTaskInsId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorkTaskInsId
        {
            get { return _worktaskinsid; }
            set
            {			
		_worktaskinsid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：OperType
        /// 属性描述：
        /// 字段信息：[OperType],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int OperType
        {
            get { return _opertype; }
            set
            {			
		_opertype=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：TaskTypeId
        /// 属性描述：
        /// 字段信息：[TaskTypeId],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string TaskTypeId
        {
            get { return _tasktypeid; }
            set
            {			
		_tasktypeid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：isSubWorkflow
        /// 属性描述：
        /// 字段信息：[isSubWorkflow],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool isSubWorkflow
        {
            get { return _issubworkflow; }
            set
            {			
		_issubworkflow=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：MainWorktaskId
        /// 属性描述：
        /// 字段信息：[MainWorktaskId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string MainWorktaskId
        {
            get { return _mainworktaskid; }
            set
            {			
		_mainworktaskid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：MainWorkflowInsId
        /// 属性描述：
        /// 字段信息：[MainWorkflowInsId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string MainWorkflowInsId
        {
            get { return _mainworkflowinsid; }
            set
            {			
		_mainworkflowinsid=value;	
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
		_operateddes=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：OperDateTime
        /// 属性描述：
        /// 字段信息：[OperDateTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime OperDateTime
        {
            get { return _operdatetime; }
            set
            {			
		_operdatetime=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：taskEndTime
        /// 属性描述：
        /// 字段信息：[taskEndTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime taskEndTime
        {
            get { return _taskendtime; }
            set
            {			
		_taskendtime=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：flowStartTime
        /// 属性描述：
        /// 字段信息：[flowStartTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime flowStartTime
        {
            get { return _flowstarttime; }
            set
            {			
		_flowstarttime=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：flowEndTime
        /// 属性描述：
        /// 字段信息：[flowEndTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime flowEndTime
        {
            get { return _flowendtime; }
            set
            {			
		_flowendtime=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：pOperatedDes
        /// 属性描述：
        /// 字段信息：[pOperatedDes],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string pOperatedDes
        {
            get { return _poperateddes; }
            set
            {			
		_poperateddes=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：Description
        /// 属性描述：
        /// 字段信息：[Description],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Description
        {
            get { return _description; }
            set
            {			
		_description=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：OperStatus
        /// 属性描述：
        /// 字段信息：[OperStatus],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string OperStatus
        {
            get { return _operstatus; }
            set
            {			
		_operstatus=value;	
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
		_status=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：flStatus
        /// 属性描述：
        /// 字段信息：[flStatus],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string flStatus
        {
            get { return _flstatus; }
            set
            {			
		_flstatus=value;	
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
		_previoustaskid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：OperContentText
        /// 属性描述：
        /// 字段信息：[OperContentText],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string OperContentText
        {
            get { return _opercontenttext; }
            set
            {			
		_opercontenttext=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：taskInsType
        /// 属性描述：
        /// 字段信息：[taskInsType],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string taskInsType
        {
            get { return _taskinstype; }
            set
            {			
		_taskinstype=value;	
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
		_successmsg=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：ChangeOperator
        /// 属性描述：
        /// 字段信息：[ChangeOperator],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ChangeOperator
        {
            get { return _changeoperator; }
            set
            {			
		_changeoperator=value;	
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
		_taskinsdescription=value;	
            }			 
        }
  
        #endregion 
  		
    }	
}
