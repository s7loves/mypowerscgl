/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-6 20:35:05
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[WF_WorkTaskLinkView]业务实体类
    ///对应表名:PS_WorkTaskLinkView
    /// </summary>
    [Serializable]
    public class WF_WorkTaskLinkView
    {
        
        #region Private 成员
        private string _starttaskid=String.Empty; 
        private string _endtaskid=String.Empty; 
        private string _endtasktypeid=String.Empty; 
        private string _starttasktypeid=String.Empty; 
        private string _commandname=String.Empty; 
        private string _condition=String.Empty; 
        private string _description=String.Empty; 
        private int _priority=0; 
        private string _workflowid=String.Empty; 
        private string _worklinkid=String.Empty; 
        private string _endoperrule=String.Empty; 
        private string _endtaskcaption=String.Empty; 
        private string _starttaskcaption=String.Empty; 
        private string _startoperrule=String.Empty; 
        private string _endtasktypeandor=String.Empty; 
        private string _starttasktypeandor=String.Empty; 
        private int _endtaskx=0; 
        private int _endtasky=0; 
        private int _starttaskx=0; 
        private int _starttasky=0; 
        private string _breakx=String.Empty; 
        private string _breaky=String.Empty; 
        private bool _isjumpself=false;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：StartTaskId
        /// 属性描述：
        /// 字段信息：[StartTaskId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string StartTaskId
        {
            get { return _starttaskid; }
            set
            {			
		_starttaskid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：EndTaskId
        /// 属性描述：
        /// 字段信息：[EndTaskId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string EndTaskId
        {
            get { return _endtaskid; }
            set
            {			
		_endtaskid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：EndTaskTypeId
        /// 属性描述：
        /// 字段信息：[EndTaskTypeId],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string EndTaskTypeId
        {
            get { return _endtasktypeid; }
            set
            {			
		_endtasktypeid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：StartTaskTypeId
        /// 属性描述：
        /// 字段信息：[StartTaskTypeId],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string StartTaskTypeId
        {
            get { return _starttasktypeid; }
            set
            {			
		_starttasktypeid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：CommandName
        /// 属性描述：
        /// 字段信息：[CommandName],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string CommandName
        {
            get { return _commandname; }
            set
            {			
		_commandname=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：Condition
        /// 属性描述：
        /// 字段信息：[Condition],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Condition
        {
            get { return _condition; }
            set
            {			
		_condition=value;	
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
        /// 属性名称：Priority
        /// 属性描述：
        /// 字段信息：[Priority],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int Priority
        {
            get { return _priority; }
            set
            {			
		_priority=value;	
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
        /// 属性名称：WorkLinkId
        /// 属性描述：
        /// 字段信息：[WorkLinkId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorkLinkId
        {
            get { return _worklinkid; }
            set
            {			
		_worklinkid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：endOperRule
        /// 属性描述：
        /// 字段信息：[endOperRule],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string endOperRule
        {
            get { return _endoperrule; }
            set
            {			
		_endoperrule=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：endTaskCaption
        /// 属性描述：
        /// 字段信息：[endTaskCaption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string endTaskCaption
        {
            get { return _endtaskcaption; }
            set
            {			
		_endtaskcaption=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：startTaskCaption
        /// 属性描述：
        /// 字段信息：[startTaskCaption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string startTaskCaption
        {
            get { return _starttaskcaption; }
            set
            {			
		_starttaskcaption=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：startOperRule
        /// 属性描述：
        /// 字段信息：[startOperRule],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string startOperRule
        {
            get { return _startoperrule; }
            set
            {			
		_startoperrule=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：endTaskTypeAndOr
        /// 属性描述：
        /// 字段信息：[endTaskTypeAndOr],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string endTaskTypeAndOr
        {
            get { return _endtasktypeandor; }
            set
            {			
		_endtasktypeandor=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：startTaskTypeAndOr
        /// 属性描述：
        /// 字段信息：[startTaskTypeAndOr],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string startTaskTypeAndOr
        {
            get { return _starttasktypeandor; }
            set
            {			
		_starttasktypeandor=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：endtaskX
        /// 属性描述：
        /// 字段信息：[endtaskX],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int endtaskX
        {
            get { return _endtaskx; }
            set
            {			
		_endtaskx=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：endtaskY
        /// 属性描述：
        /// 字段信息：[endtaskY],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int endtaskY
        {
            get { return _endtasky; }
            set
            {			
		_endtasky=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：starttaskX
        /// 属性描述：
        /// 字段信息：[starttaskX],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int starttaskX
        {
            get { return _starttaskx; }
            set
            {			
		_starttaskx=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：starttaskY
        /// 属性描述：
        /// 字段信息：[starttaskY],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int starttaskY
        {
            get { return _starttasky; }
            set
            {			
		_starttasky=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：BreakX
        /// 属性描述：
        /// 字段信息：[BreakX],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string BreakX
        {
            get { return _breakx; }
            set
            {			
		_breakx=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：BreakY
        /// 属性描述：
        /// 字段信息：[BreakY],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string BreakY
        {
            get { return _breaky; }
            set
            {			
		_breaky=value;	
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
  
        #endregion 
  		
    }	
}
