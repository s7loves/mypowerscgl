/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-10-8 18:37:12
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[WF_WorkTaskModle]业务实体类
    ///对应表名:WF_WorkTaskModle
    /// </summary>
    [Serializable]
    public class WF_WorkTaskModle
    {
        
        #region Private 成员
        private string _taskcontrolid=Newid(); 
        private string _workflowid=String.Empty; 
        private string _modu_id=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _controltype=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：taskControlId
        /// 属性描述：
        /// 字段信息：[taskControlId],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string taskControlId
        {
            get { return _taskcontrolid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_taskcontrolid as object == null || !_taskcontrolid.Equals(value))
                {
                    _taskcontrolid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkflowId
        /// 属性描述：流程ID
        /// 字段信息：[WorkflowId],varchar
        /// </summary>
        [DisplayNameAttribute("流程ID")]
        public string WorkflowId
        {
            get { return _workflowid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[流程ID]长度不能大于50!");
                if (_workflowid as object == null || !_workflowid.Equals(value))
                {
                    _workflowid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Modu_ID
        /// 属性描述：表的ID
        /// 字段信息：[Modu_ID],varchar
        /// </summary>
        [DisplayNameAttribute("表的ID")]
        public string Modu_ID
        {
            get { return _modu_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[表的ID]长度不能大于50!");
                if (_modu_id as object == null || !_modu_id.Equals(value))
                {
                    _modu_id = value;
                }
            }			 
        }
  
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
        /// 属性名称：ControlType
        /// 属性描述：
        /// 字段信息：[ControlType],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ControlType
        {
            get { return _controltype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_controltype as object == null || !_controltype.Equals(value))
                {
                    _controltype = value;
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
