/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-10-7 19:01:12
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[WF_TableFieldValue]业务实体类
    ///对应表名:WF_TableFieldValue
    /// </summary>
    [Serializable]
    public class WF_TableFieldValue
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _recordid=String.Empty; 
        private string _fieldid=String.Empty; 
        private string _workflowid=String.Empty; 
        private string _workflowinsid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _worktaskinsid=String.Empty; 
        private string _controlvalue=String.Empty;   
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
        /// 属性名称：FieldId
        /// 属性描述：表的字段ID
        /// 字段信息：[FieldId],nvarchar
        /// </summary>
        [DisplayNameAttribute("表的字段ID")]
        public string FieldId
        {
            get { return _fieldid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[表的字段ID]长度不能大于50!");
                if (_fieldid as object == null || !_fieldid.Equals(value))
                {
                    _fieldid = value;
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
        /// 属性名称：ControlValue
        /// 属性描述：字段输入的值
        /// 字段信息：[ControlValue],nvarchar
        /// </summary>
        [DisplayNameAttribute("字段输入的值")]
        public string ControlValue
        {
            get { return _controlvalue; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[字段输入的值]长度不能大于1073741823!");
                if (_controlvalue as object == null || !_controlvalue.Equals(value))
                {
                    _controlvalue = value;
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
