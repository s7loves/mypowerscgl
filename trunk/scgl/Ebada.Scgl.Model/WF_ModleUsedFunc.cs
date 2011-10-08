/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-10-8 18:01:37
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[WF_ModleUsedFunc]业务实体类
    ///对应表名:WF_ModleUsedFunc
    /// </summary>
    [Serializable]
    public class WF_ModleUsedFunc
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _workflowid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _modu_id=String.Empty; 
        private string _funcode=String.Empty; 
        private string _funname=String.Empty; 
        private string _funid=String.Empty;   
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
        /// 属性名称：Modu_ID
        /// 属性描述：模块ID
        /// 字段信息：[Modu_ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("模块ID")]
        public string Modu_ID
        {
            get { return _modu_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[模块ID]长度不能大于50!");
                if (_modu_id as object == null || !_modu_id.Equals(value))
                {
                    _modu_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FunCode
        /// 属性描述：功能编号
        /// 字段信息：[FunCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("功能编号")]
        public string FunCode
        {
            get { return _funcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[功能编号]长度不能大于50!");
                if (_funcode as object == null || !_funcode.Equals(value))
                {
                    _funcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FunName
        /// 属性描述：功能名称
        /// 字段信息：[FunName],nvarchar
        /// </summary>
        [DisplayNameAttribute("功能名称")]
        public string FunName
        {
            get { return _funname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[功能名称]长度不能大于50!");
                if (_funname as object == null || !_funname.Equals(value))
                {
                    _funname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FunID
        /// 属性描述：功能ID
        /// 字段信息：[FunID],nvarchar
        /// </summary>
        [DisplayNameAttribute("功能ID")]
        public string FunID
        {
            get { return _funid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[功能ID]长度不能大于50!");
                if (_funid as object == null || !_funid.Equals(value))
                {
                    _funid = value;
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
