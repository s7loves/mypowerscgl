/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-5 18:37:16
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_WorkTaskView]业务实体类
    ///对应表名:PS_WorkTaskView
    /// </summary>
    [Serializable]
    public class PS_WorkTaskView
    {
        
        #region Private 成员
        private string _flowcaption=String.Empty; 
        private string _wfclassid=String.Empty; 
        private string _tasktypeid=String.Empty; 
        private string _taskcaption=String.Empty; 
        private string _opercontent=String.Empty; 
        private int _opertype=0; 
        private string _status=String.Empty; 
        private string _workflowid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _operdisplay=String.Empty; 
        private string _caption=String.Empty; 
        private string _fatherid=String.Empty; 
        private int _cllevel=0; 
        private string _mgrurl=String.Empty; 
        private bool _isjumpself=false; 
        private bool _inorexclude=false; 
        private string _clmgrurl=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
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
        /// 属性名称：OperDisplay
        /// 属性描述：
        /// 字段信息：[OperDisplay],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string OperDisplay
        {
            get { return _operdisplay; }
            set
            {			
		_operdisplay=value;	
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
        /// 属性名称：IsJumpSelf
        /// 属性描述：
        /// 字段信息：[IsJumpSelf],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool IsJumpSelf
        {
            get { return _isjumpself; }
            set
            {			
		_isjumpself=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：InorExclude
        /// 属性描述：
        /// 字段信息：[InorExclude],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool InorExclude
        {
            get { return _inorexclude; }
            set
            {			
		_inorexclude=value;	
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
