/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-10-10 12:19:05
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[WF_ModleCheckTable]业务实体类
    ///对应表名:WF_ModleCheckTable
    /// </summary>
    [Serializable]
    public class WF_ModleCheckTable
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _recordid=String.Empty; 
        private string _workflowid=String.Empty; 
        private string _workflowinsid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _worktaskinsid=String.Empty; 
        private byte[] _doccontent=new byte[]{}; 
        private DateTime _creattime=new DateTime(1900,1,1);   
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
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RecordId
        /// 属性描述：记录ID
        /// 字段信息：[RecordId],nvarchar
        /// </summary>
        [DisplayNameAttribute("记录ID")]
        public string RecordId
        {
            get { return _recordid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[记录ID]长度不能大于50!");
                if (_recordid as object == null || !_recordid.Equals(value))
                {
                    _recordid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkFlowId
        /// 属性描述：流程ID
        /// 字段信息：[WorkFlowId],nvarchar
        /// </summary>
        [DisplayNameAttribute("流程ID")]
        public string WorkFlowId
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
        /// 属性名称：WorkFlowInsId
        /// 属性描述：流程实例ID
        /// 字段信息：[WorkFlowInsId],nvarchar
        /// </summary>
        [DisplayNameAttribute("流程实例ID")]
        public string WorkFlowInsId
        {
            get { return _workflowinsid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[流程实例ID]长度不能大于50!");
                if (_workflowinsid as object == null || !_workflowinsid.Equals(value))
                {
                    _workflowinsid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkTaskId
        /// 属性描述：节点ID
        /// 字段信息：[WorkTaskId],nvarchar
        /// </summary>
        [DisplayNameAttribute("节点ID")]
        public string WorkTaskId
        {
            get { return _worktaskid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[节点ID]长度不能大于50!");
                if (_worktaskid as object == null || !_worktaskid.Equals(value))
                {
                    _worktaskid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkTaskInsId
        /// 属性描述：节点实例ID
        /// 字段信息：[WorkTaskInsId],nvarchar
        /// </summary>
        [DisplayNameAttribute("节点实例ID")]
        public string WorkTaskInsId
        {
            get { return _worktaskinsid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[节点实例ID]长度不能大于50!");
                if (_worktaskinsid as object == null || !_worktaskinsid.Equals(value))
                {
                    _worktaskinsid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：DocContent
        /// 属性描述：当前节点的内容
        /// 字段信息：[DocContent],image
        /// </summary>
        [DisplayNameAttribute("当前节点的内容")]
        public byte[] DocContent
        {
            get { return _doccontent; }
            set
            {			
                if (_doccontent as object == null || !_doccontent.Equals(value))
                {
                    _doccontent = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Creattime
        /// 属性描述：创建时间
        /// 字段信息：[Creattime],datetime
        /// </summary>
        [DisplayNameAttribute("创建时间")]
        public DateTime Creattime
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
