/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-5 16:30:14
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_WorkTaskPower]业务实体类
    ///对应表名:PS_WorkTaskPower
    /// </summary>
    [Serializable]
    public class WF_WorkTaskPower
    {
        
        #region Private 成员
        private string _powerid=Newid(); 
        private string _powername=String.Empty; 
        private string _status=String.Empty; 
        private string _workflowid=String.Empty; 
        private string _worktaskid=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：Powerid
        /// 属性描述：
        /// 字段信息：[Powerid],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string Powerid
        {
            get { return _powerid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_powerid as object == null || !_powerid.Equals(value))
                {
                    _powerid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：PowerName
        /// 属性描述：
        /// 字段信息：[PowerName],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string PowerName
        {
            get { return _powername; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 256)
                throw new Exception("[]长度不能大于256!");
                if (_powername as object == null || !_powername.Equals(value))
                {
                    _powername = value;
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
