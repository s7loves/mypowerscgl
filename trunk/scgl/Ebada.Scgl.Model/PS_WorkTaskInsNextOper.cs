/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-10 15:13:30
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_WorkTaskInsNextOper]业务实体类
    ///对应表名:PS_WorkTaskInsNextOper
    /// </summary>
    [Serializable]
    public class PS_WorkTaskInsNextOper
    {
        
        #region Private 成员
        private string _nextoperid=Newid(); 
        private string _userid=String.Empty; 
        private string _username=String.Empty; 
        private string _workflowid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _workflowinsid=String.Empty; 
        private string _worktaskinsid=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：NextOperId
        /// 属性描述：
        /// 字段信息：[NextOperId],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string NextOperId
        {
            get { return _nextoperid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_nextoperid as object == null || !_nextoperid.Equals(value))
                {
                    _nextoperid = value;
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
        /// 属性名称：UserName
        /// 属性描述：
        /// 字段信息：[UserName],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string UserName
        {
            get { return _username; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_username as object == null || !_username.Equals(value))
                {
                    _username = value;
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
        /// 属性名称：WorktaskInsId
        /// 属性描述：
        /// 字段信息：[WorktaskInsId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorktaskInsId
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
