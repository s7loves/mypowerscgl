/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-10 10:02:47
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_WorkServiceMessage]业务实体类
    ///对应表名:PS_WorkServiceMessage
    /// </summary>
    [Serializable]
    public class WF_WorkServiceMessage
    {
        
        #region Private 成员
        private string _messageid=Newid(); 
        private string _workflowid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _workflowinsid=String.Empty; 
        private string _worktaskinsid=String.Empty; 
        private string _content=String.Empty;
        private DateTime _sendtime1 = DateTime.Now;
        private DateTime _sendtime2 = DateTime.Now;
        private DateTime _sendtime3 = DateTime.Now; 
        private int _doneflag1=0; 
        private int _doneflag2=0; 
        private int _doneflag3=0; 
        private string _msgtype=String.Empty; 
        private string _users1=String.Empty; 
        private string _users2=String.Empty; 
        private string _users3=String.Empty;
        private DateTime _createtime = DateTime.Now; 
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：MessageId
        /// 属性描述：
        /// 字段信息：[MessageId],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string MessageId
        {
            get { return _messageid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_messageid as object == null || !_messageid.Equals(value))
                {
                    _messageid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkflowId
        /// 属性描述：
        /// 字段信息：[WorkflowId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorkflowId
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
        /// 属性名称：WorktaskId
        /// 属性描述：
        /// 字段信息：[WorktaskId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorktaskId
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
        /// 属性名称：WorkflowInsId
        /// 属性描述：
        /// 字段信息：[WorkflowInsId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorkflowInsId
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
        /// 属性名称：WorktaskInsId
        /// 属性描述：
        /// 字段信息：[WorktaskInsId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorktaskInsId
        {
            get { return _worktaskinsid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_worktaskinsid as object == null || !_worktaskinsid.Equals(value))
                {
                    _worktaskinsid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Content
        /// 属性描述：
        /// 字段信息：[Content],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Content
        {
            get { return _content; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_content as object == null || !_content.Equals(value))
                {
                    _content = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SendTime1
        /// 属性描述：
        /// 字段信息：[SendTime1],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime SendTime1
        {
            get { return _sendtime1; }
            set
            {			
                if (_sendtime1 as object == null || !_sendtime1.Equals(value))
                {
                    _sendtime1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SendTime2
        /// 属性描述：
        /// 字段信息：[SendTime2],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime SendTime2
        {
            get { return _sendtime2; }
            set
            {			
                if (_sendtime2 as object == null || !_sendtime2.Equals(value))
                {
                    _sendtime2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SendTime3
        /// 属性描述：
        /// 字段信息：[SendTime3],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime SendTime3
        {
            get { return _sendtime3; }
            set
            {			
                if (_sendtime3 as object == null || !_sendtime3.Equals(value))
                {
                    _sendtime3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：DoneFlag1
        /// 属性描述：
        /// 字段信息：[DoneFlag1],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int DoneFlag1
        {
            get { return _doneflag1; }
            set
            {			
                if (_doneflag1 as object == null || !_doneflag1.Equals(value))
                {
                    _doneflag1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：DoneFlag2
        /// 属性描述：
        /// 字段信息：[DoneFlag2],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int DoneFlag2
        {
            get { return _doneflag2; }
            set
            {			
                if (_doneflag2 as object == null || !_doneflag2.Equals(value))
                {
                    _doneflag2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：DoneFlag3
        /// 属性描述：
        /// 字段信息：[DoneFlag3],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int DoneFlag3
        {
            get { return _doneflag3; }
            set
            {			
                if (_doneflag3 as object == null || !_doneflag3.Equals(value))
                {
                    _doneflag3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：MsgType
        /// 属性描述：
        /// 字段信息：[MsgType],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string MsgType
        {
            get { return _msgtype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_msgtype as object == null || !_msgtype.Equals(value))
                {
                    _msgtype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Users1
        /// 属性描述：
        /// 字段信息：[Users1],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Users1
        {
            get { return _users1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_users1 as object == null || !_users1.Equals(value))
                {
                    _users1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Users2
        /// 属性描述：
        /// 字段信息：[Users2],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Users2
        {
            get { return _users2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_users2 as object == null || !_users2.Equals(value))
                {
                    _users2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Users3
        /// 属性描述：
        /// 字段信息：[Users3],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Users3
        {
            get { return _users3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_users3 as object == null || !_users3.Equals(value))
                {
                    _users3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateTime
        /// 属性描述：
        /// 字段信息：[CreateTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime CreateTime
        {
            get { return _createtime; }
            set
            {			
                if (_createtime as object == null || !_createtime.Equals(value))
                {
                    _createtime = value;
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
