/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-10-22 20:36:46
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[WF_ModleRecordWorkTaskIns]业务实体类
    ///对应表名:WF_ModleRecordWorkTaskIns
    /// </summary>
    [Serializable]
    public class WF_ModleRecordWorkTaskIns
    {
        
        #region Private 成员
        private string _id=Newid();
        private string _recordid = String.Empty;
        private string _modlerecordid = String.Empty;
        private string _modletablename = String.Empty;
        private string _workflowid = String.Empty;
        private string _workflowinsid = String.Empty;
        private string _worktaskid = String.Empty;
        private string _worktaskinsid = String.Empty; 
        private DateTime _creattime = new DateTime(1900, 1, 1);  
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RecordID
        /// 属性描述：票记录ID
        /// 字段信息：[RecordID],nvarchar
        /// </summary>
        [DisplayNameAttribute("票记录ID")]
        public string RecordID
        {
            get { return _recordid; }
            set
            {			
                if (_recordid as object == null || !_recordid.Equals(value))
                {
                    _recordid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ModleRecordID
        /// 属性描述：模块记录ID
        /// 字段信息：[ModleRecordID],nvarchar
        /// </summary>
        [DisplayNameAttribute("模块记录ID")]
        public string ModleRecordID
        {
            get { return _modlerecordid; }
            set
            {			
                if (_modlerecordid as object == null || !_modlerecordid.Equals(value))
                {
                    _modlerecordid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ModleTableName
        /// 属性描述：模块记录的名称
        /// 字段信息：[ModleTableName],nvarchar
        /// </summary>
        [DisplayNameAttribute("模块记录的名称")]
        public string ModleTableName
        {
            get { return _modletablename; }
            set
            {			
                if (_modletablename as object == null || !_modletablename.Equals(value))
                {
                    _modletablename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkFlowId
        /// 属性描述：工作流名称ID
        /// 字段信息：[WorkFlowId],nvarchar
        /// </summary>
        [DisplayNameAttribute("工作流名称ID")]
        public string WorkFlowId
        {
            get { return _workflowid; }
            set
            {			
                if (_workflowid as object == null || !_workflowid.Equals(value))
                {
                    _workflowid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkFlowInsId
        /// 属性描述：工作流实例ID
        /// 字段信息：[WorkFlowInsId],nvarchar
        /// </summary>
        [DisplayNameAttribute("工作流实例ID")]
        public string WorkFlowInsId
        {
            get { return _workflowinsid; }
            set
            {			
                if (_workflowinsid as object == null || !_workflowinsid.Equals(value))
                {
                    _workflowinsid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkTaskId
        /// 属性描述：工作流节点ID
        /// 字段信息：[WorkTaskId],nvarchar
        /// </summary>
        [DisplayNameAttribute("工作流节点ID")]
        public string WorkTaskId
        {
            get { return _worktaskid; }
            set
            {			
                if (_worktaskid as object == null || !_worktaskid.Equals(value))
                {
                    _worktaskid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkTaskInsId
        /// 属性描述：工作流节点实例ID
        /// 字段信息：[WorkTaskInsId],nvarchar
        /// </summary>
        [DisplayNameAttribute("工作流节点实例ID")]
        public string WorkTaskInsId
        {
            get { return _worktaskinsid; }
            set
            {			
                if (_worktaskinsid as object == null || !_worktaskinsid.Equals(value))
                {
                    _worktaskinsid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreatTime
        /// 属性描述：创建时间
        /// 字段信息：[CreatTime],nvarchar
        /// </summary>
        [DisplayNameAttribute("创建时间")]
        public DateTime CreatTime
        {
            get { return _creattime; }
            set
            {			
                if (_creattime as object == null || !_creattime.Equals(value))
                {
                    _creattime = value;
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
