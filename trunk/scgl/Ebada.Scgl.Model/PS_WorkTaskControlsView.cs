/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-5 19:54:19
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_WorkTaskControlsView]业务实体类
    ///对应表名:PS_WorkTaskControlsView
    /// </summary>
    [Serializable]
    public class PS_WorkTaskControlsView
    {
        
        #region Private 成员
        private string _worktaskid=String.Empty; 
        private string _taskcaption=String.Empty; 
        private string _ucpath=String.Empty; 
        private string _uccaption=String.Empty; 
        private string _mainuserctrlid=String.Empty; 
        private string _muccaption=String.Empty; 
        private string _usercontrolid=String.Empty; 
        private int _ctrlordernbr=0; 
        private string _ctrlstate=String.Empty; 
        private string _ucid=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：WorktaskId
        /// 属性描述：
        /// 字段信息：[WorktaskId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorktaskId
        {
            get { return _worktaskid; }
            set
            {			
		_worktaskid=value;	
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
        /// 属性名称：ucPath
        /// 属性描述：
        /// 字段信息：[ucPath],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ucPath
        {
            get { return _ucpath; }
            set
            {			
		_ucpath=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：ucCaption
        /// 属性描述：
        /// 字段信息：[ucCaption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ucCaption
        {
            get { return _uccaption; }
            set
            {			
		_uccaption=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：MainUserCtrlId
        /// 属性描述：
        /// 字段信息：[MainUserCtrlId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string MainUserCtrlId
        {
            get { return _mainuserctrlid; }
            set
            {			
		_mainuserctrlid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：mucCaption
        /// 属性描述：
        /// 字段信息：[mucCaption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string mucCaption
        {
            get { return _muccaption; }
            set
            {			
		_muccaption=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserControlId
        /// 属性描述：
        /// 字段信息：[UserControlId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string UserControlId
        {
            get { return _usercontrolid; }
            set
            {			
		_usercontrolid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：CtrlOrderNbr
        /// 属性描述：
        /// 字段信息：[CtrlOrderNbr],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int CtrlOrderNbr
        {
            get { return _ctrlordernbr; }
            set
            {			
		_ctrlordernbr=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：CtrlState
        /// 属性描述：
        /// 字段信息：[CtrlState],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string CtrlState
        {
            get { return _ctrlstate; }
            set
            {			
		_ctrlstate=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：ucID
        /// 属性描述：
        /// 字段信息：[ucID],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ucID
        {
            get { return _ucid; }
            set
            {			
		_ucid=value;	
            }			 
        }
  
        #endregion 
  		
    }	
}
