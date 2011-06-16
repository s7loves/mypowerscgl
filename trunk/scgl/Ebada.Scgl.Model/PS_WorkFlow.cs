/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-5 21:03:39
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_WorkFlow]业务实体类
    ///对应表名:PS_WorkFlow
    /// </summary>
    [Serializable]
    public class PS_WorkFlow
    {
        
        #region Private 成员
        private string _workflowid=Newid(); 
        private string _flowcaption=String.Empty; 
        private string _wfclassid=String.Empty; 
        private string _version=String.Empty; 
        private string _status=String.Empty; 
        private string _createuserid=String.Empty;
        private DateTime _createdatetime = DateTime.Now; 
        private string _issignout=String.Empty; 
        private string _signoutuserid=String.Empty; 
        private string _workcalendarid=String.Empty; 
        private string _description=String.Empty; 
        private string _mgrurl=String.Empty;
        private string _name = String.Empty; 
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：WorkFlowId
        /// 属性描述：
        /// 字段信息：[WorkFlowId],varchar
        /// </summary>
        [Browsable(false)]
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
        /// 属性名称：FlowCaption
        /// 属性描述：
        /// 字段信息：[FlowCaption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string FlowCaption
        {
            get { return _flowcaption; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 128)
                throw new Exception("[]长度不能大于128!");
                if (_flowcaption as object == null || !_flowcaption.Equals(value))
                {
                    _flowcaption = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WFClassId
        /// 属性描述：
        /// 字段信息：[WFClassId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WFClassId
        {
            get { return _wfclassid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_wfclassid as object == null || !_wfclassid.Equals(value))
                {
                    _wfclassid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Version
        /// 属性描述：
        /// 字段信息：[Version],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Version
        {
            get { return _version; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_version as object == null || !_version.Equals(value))
                {
                    _version = value;
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
        /// 属性名称：CreateUserId
        /// 属性描述：
        /// 字段信息：[CreateUserId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string CreateUserId
        {
            get { return _createuserid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[]长度不能大于10!");
                if (_createuserid as object == null || !_createuserid.Equals(value))
                {
                    _createuserid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateDateTime
        /// 属性描述：
        /// 字段信息：[CreateDateTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime CreateDateTime
        {
            get { return _createdatetime; }
            set
            {			
                if (_createdatetime as object == null || !_createdatetime.Equals(value))
                {
                    _createdatetime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：IsSignOut
        /// 属性描述：
        /// 字段信息：[IsSignOut],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string IsSignOut
        {
            get { return _issignout; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_issignout as object == null || !_issignout.Equals(value))
                {
                    _issignout = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SignOutUserId
        /// 属性描述：
        /// 字段信息：[SignOutUserId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string SignOutUserId
        {
            get { return _signoutuserid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[]长度不能大于10!");
                if (_signoutuserid as object == null || !_signoutuserid.Equals(value))
                {
                    _signoutuserid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkCalendarId
        /// 属性描述：
        /// 字段信息：[WorkCalendarId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorkCalendarId
        {
            get { return _workcalendarid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_workcalendarid as object == null || !_workcalendarid.Equals(value))
                {
                    _workcalendarid = value;
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
        /// 属性名称：MgrUrl
        /// 属性描述：
        /// 字段信息：[MgrUrl],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string MgrUrl
        {
            get { return _mgrurl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_mgrurl as object == null || !_mgrurl.Equals(value))
                {
                    _mgrurl = value;
                }
            }			 
        }
        /// <summary>
        /// 属性名称：Name
        /// 属性描述：
        /// 字段信息：[Name],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 512)
                    throw new Exception("[]长度不能大于512!");
                if (_name as object == null || !_name.Equals(value))
                {
                    _name = value;
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
