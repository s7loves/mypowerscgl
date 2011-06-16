/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-6 10:21:15
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_SubWorkFlow]业务实体类
    ///对应表名:PS_SubWorkFlow
    /// </summary>
    [Serializable]
    public class PS_SubWorkFlow
    {
        
        #region Private 成员
        private string _subid=Newid(); 
        private string _workflowid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _subworkflowid=String.Empty; 
        private string _subworkflowcaption=String.Empty; 
        private string _substarttaskid=String.Empty; 
        private string _description=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：subId
        /// 属性描述：
        /// 字段信息：[subId],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string subId
        {
            get { return _subid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_subid as object == null || !_subid.Equals(value))
                {
                    _subid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkflowId
        /// 属性描述：
        /// 字段信息：[WorkflowId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorkflowId
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
        /// 属性名称：subWorkflowId
        /// 属性描述：
        /// 字段信息：[subWorkflowId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string subWorkflowId
        {
            get { return _subworkflowid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_subworkflowid as object == null || !_subworkflowid.Equals(value))
                {
                    _subworkflowid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：subWorkflowCaption
        /// 属性描述：
        /// 字段信息：[subWorkflowCaption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string subWorkflowCaption
        {
            get { return _subworkflowcaption; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_subworkflowcaption as object == null || !_subworkflowcaption.Equals(value))
                {
                    _subworkflowcaption = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：subStartTaskId
        /// 属性描述：
        /// 字段信息：[subStartTaskId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string subStartTaskId
        {
            get { return _substarttaskid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_substarttaskid as object == null || !_substarttaskid.Equals(value))
                {
                    _substarttaskid = value;
                }
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
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_description as object == null || !_description.Equals(value))
                {
                    _description = value;
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
