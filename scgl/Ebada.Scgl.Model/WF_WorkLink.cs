/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-5 20:06:11
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_WorkLink]业务实体类
    ///对应表名:PS_WorkLink
    /// </summary>
    [Serializable]
    public class WF_WorkLink
    {
        
        #region Private 成员
        private string _worklinkid=Newid(); 
        private string _workflowid=String.Empty; 
        private string _starttaskid=String.Empty; 
        private string _endtaskid=String.Empty; 
        private string _condition=String.Empty; 
        private string _description=String.Empty; 
        private string _breakx=String.Empty; 
        private string _breaky=String.Empty; 
        private string _commandname=String.Empty; 
        private int _priority=0;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：WorkLinkId
        /// 属性描述：
        /// 字段信息：[WorkLinkId],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string WorkLinkId
        {
            get { return _worklinkid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 36)
                throw new Exception("[]长度不能大于36!");
                if (_worklinkid as object == null || !_worklinkid.Equals(value))
                {
                    _worklinkid = value;
                }
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
                if(value==null)return;
                if( value.ToString().Length > 36)
                throw new Exception("[]长度不能大于36!");
                if (_workflowid as object == null || !_workflowid.Equals(value))
                {
                    _workflowid = value;
                }
            }			 
        }
  
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
                if(value==null)return;
                if( value.ToString().Length > 36)
                throw new Exception("[]长度不能大于36!");
                if (_starttaskid as object == null || !_starttaskid.Equals(value))
                {
                    _starttaskid = value;
                }
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
                if(value==null)return;
                if( value.ToString().Length > 36)
                throw new Exception("[]长度不能大于36!");
                if (_endtaskid as object == null || !_endtaskid.Equals(value))
                {
                    _endtaskid = value;
                }
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
                if(value==null)return;
                if( value.ToString().Length > 1024)
                throw new Exception("[]长度不能大于1024!");
                if (_condition as object == null || !_condition.Equals(value))
                {
                    _condition = value;
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
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_breakx as object == null || !_breakx.Equals(value))
                {
                    _breakx = value;
                }
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
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_breaky as object == null || !_breaky.Equals(value))
                {
                    _breaky = value;
                }
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
                if(value==null)return;
                if( value.ToString().Length > 128)
                throw new Exception("[]长度不能大于128!");
                if (_commandname as object == null || !_commandname.Equals(value))
                {
                    _commandname = value;
                }
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
                if (_priority as object == null || !_priority.Equals(value))
                {
                    _priority = value;
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
