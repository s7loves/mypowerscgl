/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-10-7 19:07:06
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[WF_TableUsedField]业务实体类
    ///对应表名:WF_TableUsedField
    /// </summary>
    [Serializable]
    public class WF_TableUsedField
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _workflowid=String.Empty; 
        private string _usercontrolid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _fieldid=String.Empty; 
        private string _fieldname=String.Empty;   
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
        /// 属性名称：WorkflowId
        /// 属性描述：流程ID
        /// 字段信息：[WorkflowId],nvarchar
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
        /// 属性名称：UserControlId
        /// 属性描述：表的ID
        /// 字段信息：[UserControlId],nvarchar
        /// </summary>
        [DisplayNameAttribute("表的ID")]
        public string UserControlId
        {
            get { return _usercontrolid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[表的ID]长度不能大于50!");
                if (_usercontrolid as object == null || !_usercontrolid.Equals(value))
                {
                    _usercontrolid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorktaskId
        /// 属性描述：节点ID
        /// 字段信息：[WorktaskId],nvarchar
        /// </summary>
        [DisplayNameAttribute("节点ID")]
        public string WorktaskId
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
        /// 属性名称：FieldId
        /// 属性描述：字段ID
        /// 字段信息：[FieldId],nvarchar
        /// </summary>
        [DisplayNameAttribute("字段ID")]
        public string FieldId
        {
            get { return _fieldid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[字段ID]长度不能大于50!");
                if (_fieldid as object == null || !_fieldid.Equals(value))
                {
                    _fieldid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FieldName
        /// 属性描述：字段名称
        /// 字段信息：[FieldName],nvarchar
        /// </summary>
        [DisplayNameAttribute("字段名称")]
        public string FieldName
        {
            get { return _fieldname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[字段名称]长度不能大于50!");
                if (_fieldname as object == null || !_fieldname.Equals(value))
                {
                    _fieldname = value;
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
