/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-10 15:22:10
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_WorkFlowInstance]业务实体类
    ///对应表名:PS_WorkFlowInstance
    /// </summary>
    [Serializable]
    public class WF_WorkFlowInstance
    {
        
        #region Private 成员
        private string _workflowinsid=Newid(); 
        private string _workflowid=String.Empty; 
        private string _workflowno=String.Empty; 
        private string _flowinscaption=String.Empty; 
        private string _description=String.Empty; 
        private string _priority=String.Empty; 
        private string _status=String.Empty; 
        private string _nowtaskid=String.Empty; 
        private DateTime _starttime=  DateTime.Now; 
        private DateTime _endtime=  DateTime.Now; 
        private DateTime _suspendtime= DateTime.Now; 
        private string _suspendstaus=String.Empty; 
        private int _suspendtotalseconds=0; 
        private bool _issubworkflow=false; 
        private string _mainworkflowinsid=String.Empty; 
        private string _mainworktaskinsid=String.Empty; 
        private string _mainworktaskid=String.Empty; 
        private string _mainworkflowid=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：WorkFlowInsId
        /// 属性描述：
        /// 字段信息：[WorkFlowInsId],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string WorkFlowInsId
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
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_workflowid as object == null || !_workflowid.Equals(value))
                {
                    _workflowid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkFlowNo
        /// 属性描述：
        /// 字段信息：[WorkFlowNo],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorkFlowNo
        {
            get { return _workflowno; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 128)
                throw new Exception("[]长度不能大于128!");
                if (_workflowno as object == null || !_workflowno.Equals(value))
                {
                    _workflowno = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FlowInsCaption
        /// 属性描述：
        /// 字段信息：[FlowInsCaption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string FlowInsCaption
        {
            get { return _flowinscaption; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 128)
                throw new Exception("[]长度不能大于128!");
                if (_flowinscaption as object == null || !_flowinscaption.Equals(value))
                {
                    _flowinscaption = value;
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
        /// 属性名称：Priority
        /// 属性描述：
        /// 字段信息：[Priority],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string Priority
        {
            get { return _priority; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1)
                throw new Exception("[]长度不能大于1!");
                if (_priority as object == null || !_priority.Equals(value))
                {
                    _priority = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Status
        /// 属性描述：
        /// 字段信息：[Status],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string Status
        {
            get { return _status; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1)
                throw new Exception("[]长度不能大于1!");
                if (_status as object == null || !_status.Equals(value))
                {
                    _status = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：NowTaskId
        /// 属性描述：
        /// 字段信息：[NowTaskId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string NowTaskId
        {
            get { return _nowtaskid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_nowtaskid as object == null || !_nowtaskid.Equals(value))
                {
                    _nowtaskid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：StartTime
        /// 属性描述：
        /// 字段信息：[StartTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime StartTime
        {
            get { return _starttime; }
            set
            {			
                if (_starttime as object == null || !_starttime.Equals(value))
                {
                    _starttime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：EndTime
        /// 属性描述：
        /// 字段信息：[EndTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime EndTime
        {
            get { return _endtime; }
            set
            {			
                if (_endtime as object == null || !_endtime.Equals(value))
                {
                    _endtime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SuspendTime
        /// 属性描述：
        /// 字段信息：[SuspendTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime SuspendTime
        {
            get { return _suspendtime; }
            set
            {			
                if (_suspendtime as object == null || !_suspendtime.Equals(value))
                {
                    _suspendtime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SuspendStaus
        /// 属性描述：
        /// 字段信息：[SuspendStaus],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string SuspendStaus
        {
            get { return _suspendstaus; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1)
                throw new Exception("[]长度不能大于1!");
                if (_suspendstaus as object == null || !_suspendstaus.Equals(value))
                {
                    _suspendstaus = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SuspendTotalSeconds
        /// 属性描述：
        /// 字段信息：[SuspendTotalSeconds],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int SuspendTotalSeconds
        {
            get { return _suspendtotalseconds; }
            set
            {			
                if (_suspendtotalseconds as object == null || !_suspendtotalseconds.Equals(value))
                {
                    _suspendtotalseconds = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：isSubWorkflow
        /// 属性描述：
        /// 字段信息：[isSubWorkflow],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool isSubWorkflow
        {
            get { return _issubworkflow; }
            set
            {			
                if (_issubworkflow as object == null || !_issubworkflow.Equals(value))
                {
                    _issubworkflow = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：MainWorkflowInsId
        /// 属性描述：
        /// 字段信息：[MainWorkflowInsId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string MainWorkflowInsId
        {
            get { return _mainworkflowinsid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_mainworkflowinsid as object == null || !_mainworkflowinsid.Equals(value))
                {
                    _mainworkflowinsid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：MainWorktaskInsId
        /// 属性描述：
        /// 字段信息：[MainWorktaskInsId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string MainWorktaskInsId
        {
            get { return _mainworktaskinsid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_mainworktaskinsid as object == null || !_mainworktaskinsid.Equals(value))
                {
                    _mainworktaskinsid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：MainWorktaskId
        /// 属性描述：
        /// 字段信息：[MainWorktaskId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string MainWorktaskId
        {
            get { return _mainworktaskid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_mainworktaskid as object == null || !_mainworktaskid.Equals(value))
                {
                    _mainworktaskid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：MainWorkflowId
        /// 属性描述：
        /// 字段信息：[MainWorkflowId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string MainWorkflowId
        {
            get { return _mainworkflowid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_mainworkflowid as object == null || !_mainworkflowid.Equals(value))
                {
                    _mainworkflowid = value;
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
