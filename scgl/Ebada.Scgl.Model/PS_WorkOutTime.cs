/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-6 9:28:25
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_WorkOutTime]业务实体类
    ///对应表名:PS_WorkOutTime
    /// </summary>
    [Serializable]
    public class PS_WorkOutTime
    {
        
        #region Private 成员
        private string _guid=Newid(); 
        private string _workflowid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _name=String.Empty; 
        private int _days=0; 
        private int _hours=0; 
        private int _minutes=0; 
        private int _days1=0; 
        private int _hours1=0; 
        private int _minutes1=0; 
        private int _days2=0; 
        private int _hours2=0; 
        private int _minutes2=0; 
        private string _done=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：Guid
        /// 属性描述：
        /// 字段信息：[Guid],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string Guid
        {
            get { return _guid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_guid as object == null || !_guid.Equals(value))
                {
                    _guid = value;
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
                if(value==null)return;
                if( value.ToString().Length > 128)
                throw new Exception("[]长度不能大于128!");
                if (_name as object == null || !_name.Equals(value))
                {
                    _name = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Days
        /// 属性描述：
        /// 字段信息：[Days],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int Days
        {
            get { return _days; }
            set
            {			
                if (_days as object == null || !_days.Equals(value))
                {
                    _days = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Hours
        /// 属性描述：
        /// 字段信息：[Hours],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int Hours
        {
            get { return _hours; }
            set
            {			
                if (_hours as object == null || !_hours.Equals(value))
                {
                    _hours = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Minutes
        /// 属性描述：
        /// 字段信息：[Minutes],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int Minutes
        {
            get { return _minutes; }
            set
            {			
                if (_minutes as object == null || !_minutes.Equals(value))
                {
                    _minutes = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Days1
        /// 属性描述：
        /// 字段信息：[Days1],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int Days1
        {
            get { return _days1; }
            set
            {			
                if (_days1 as object == null || !_days1.Equals(value))
                {
                    _days1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Hours1
        /// 属性描述：
        /// 字段信息：[Hours1],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int Hours1
        {
            get { return _hours1; }
            set
            {			
                if (_hours1 as object == null || !_hours1.Equals(value))
                {
                    _hours1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Minutes1
        /// 属性描述：
        /// 字段信息：[Minutes1],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int Minutes1
        {
            get { return _minutes1; }
            set
            {			
                if (_minutes1 as object == null || !_minutes1.Equals(value))
                {
                    _minutes1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Days2
        /// 属性描述：
        /// 字段信息：[Days2],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int Days2
        {
            get { return _days2; }
            set
            {			
                if (_days2 as object == null || !_days2.Equals(value))
                {
                    _days2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Hours2
        /// 属性描述：
        /// 字段信息：[Hours2],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int Hours2
        {
            get { return _hours2; }
            set
            {			
                if (_hours2 as object == null || !_hours2.Equals(value))
                {
                    _hours2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Minutes2
        /// 属性描述：
        /// 字段信息：[Minutes2],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int Minutes2
        {
            get { return _minutes2; }
            set
            {			
                if (_minutes2 as object == null || !_minutes2.Equals(value))
                {
                    _minutes2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Done
        /// 属性描述：
        /// 字段信息：[Done],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string Done
        {
            get { return _done; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1)
                throw new Exception("[]长度不能大于1!");
                if (_done as object == null || !_done.Equals(value))
                {
                    _done = value;
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
