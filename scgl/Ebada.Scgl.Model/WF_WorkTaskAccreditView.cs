/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-10 9:13:40
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_WorkTaskAccreditView]业务实体类
    ///对应表名:PS_WorkTaskAccreditView
    /// </summary>
    [Serializable]
    public class WF_WorkTaskAccreditView
    {
        
        #region Private 成员
        private string _accreditfromuserid=String.Empty; 
        private string _accredittouserid=String.Empty; 
        private string _accreditstatus=String.Empty; 
        private string _wfclassid=String.Empty; 
        private string _flowcaption=String.Empty; 
        private string _caption=String.Empty; 
        private string _workflowid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _fatherid=String.Empty; 
        private string _mgrurl=String.Empty; 
        private int _cllevel=0; 
        private string _taskcaption=String.Empty; 
        private string _tasktypeid=String.Empty; 
        private string _taskinstype=String.Empty; 
        private string _auserid=String.Empty; 
        private string _username=String.Empty; 
        private string _fromusername=String.Empty; 
        private string _clmgrurl=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：AccreditFromUserId
        /// 属性描述：
        /// 字段信息：[AccreditFromUserId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string AccreditFromUserId
        {
            get { return _accreditfromuserid; }
            set
            {			
		_accreditfromuserid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：AccreditToUserId
        /// 属性描述：
        /// 字段信息：[AccreditToUserId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string AccreditToUserId
        {
            get { return _accredittouserid; }
            set
            {			
		_accredittouserid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：AccreditStatus
        /// 属性描述：
        /// 字段信息：[AccreditStatus],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string AccreditStatus
        {
            get { return _accreditstatus; }
            set
            {			
		_accreditstatus=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：WFClassId
        /// 属性描述：
        /// 字段信息：[WFClassId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WFClassId
        {
            get { return _wfclassid; }
            set
            {			
		_wfclassid=value;	
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
        /// 属性名称：Caption
        /// 属性描述：
        /// 字段信息：[Caption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Caption
        {
            get { return _caption; }
            set
            {			
		_caption=value;	
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
        /// 属性名称：FatherId
        /// 属性描述：
        /// 字段信息：[FatherId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string FatherId
        {
            get { return _fatherid; }
            set
            {			
		_fatherid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：MgrUrl
        /// 属性描述：
        /// 字段信息：[MgrUrl],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string MgrUrl
        {
            get { return _mgrurl; }
            set
            {			
		_mgrurl=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：clLevel
        /// 属性描述：
        /// 字段信息：[clLevel],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int clLevel
        {
            get { return _cllevel; }
            set
            {			
		_cllevel=value;	
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
        /// 属性名称：AUserId
        /// 属性描述：
        /// 字段信息：[AUserId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string AUserId
        {
            get { return _auserid; }
            set
            {			
		_auserid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserName
        /// 属性描述：
        /// 字段信息：[UserName],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string UserName
        {
            get { return _username; }
            set
            {			
		_username=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：fromUserName
        /// 属性描述：
        /// 字段信息：[fromUserName],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string fromUserName
        {
            get { return _fromusername; }
            set
            {			
		_fromusername=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：clMgrUrl
        /// 属性描述：
        /// 字段信息：[clMgrUrl],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string clMgrUrl
        {
            get { return _clmgrurl; }
            set
            {			
		_clmgrurl=value;	
            }			 
        }
  
        #endregion 
  		
    }	
}
