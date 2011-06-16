/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-10 9:25:49
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_OperatorInstance]业务实体类
    ///对应表名:PS_OperatorInstance
    /// </summary>
    [Serializable]
    public class PS_OperatorInstance
    {
        
        #region Private 成员
        private string _operatorinsid=Newid(); 
        private string _workflowid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _workflowinsid=String.Empty; 
        private string _worktaskinsid=String.Empty; 
        private string _userid=String.Empty; 
        private int _opertype=0; 
        private int _operrealtion=0; 
        private string _opercontent=String.Empty; 
        private string _opercontenttext=String.Empty; 
        private string _operstatus=String.Empty; 
        private DateTime _operdatetime= DateTime.Now; 
        private string _changeoperator=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：OperatorInsId
        /// 属性描述：
        /// 字段信息：[OperatorInsId],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string OperatorInsId
        {
            get { return _operatorinsid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_operatorinsid as object == null || !_operatorinsid.Equals(value))
                {
                    _operatorinsid = value;
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
        /// 属性名称：WorkFlowInsId
        /// 属性描述：
        /// 字段信息：[WorkFlowInsId],varchar
        /// </summary>
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
        /// 属性名称：WorkTaskInsId
        /// 属性描述：
        /// 字段信息：[WorkTaskInsId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorkTaskInsId
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
        /// 属性名称：UserId
        /// 属性描述：
        /// 字段信息：[UserId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string UserId
        {
            get { return _userid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_userid as object == null || !_userid.Equals(value))
                {
                    _userid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OperType
        /// 属性描述：
        /// 字段信息：[OperType],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int OperType
        {
            get { return _opertype; }
            set
            {			
                if (_opertype as object == null || !_opertype.Equals(value))
                {
                    _opertype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OperRealtion
        /// 属性描述：
        /// 字段信息：[OperRealtion],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int OperRealtion
        {
            get { return _operrealtion; }
            set
            {			
                if (_operrealtion as object == null || !_operrealtion.Equals(value))
                {
                    _operrealtion = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OperContent
        /// 属性描述：
        /// 字段信息：[OperContent],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string OperContent
        {
            get { return _opercontent; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 256)
                throw new Exception("[]长度不能大于256!");
                if (_opercontent as object == null || !_opercontent.Equals(value))
                {
                    _opercontent = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OperContentText
        /// 属性描述：
        /// 字段信息：[OperContentText],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string OperContentText
        {
            get { return _opercontenttext; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 256)
                throw new Exception("[]长度不能大于256!");
                if (_opercontenttext as object == null || !_opercontenttext.Equals(value))
                {
                    _opercontenttext = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OperStatus
        /// 属性描述：
        /// 字段信息：[OperStatus],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string OperStatus
        {
            get { return _operstatus; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1)
                throw new Exception("[]长度不能大于1!");
                if (_operstatus as object == null || !_operstatus.Equals(value))
                {
                    _operstatus = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OperDateTime
        /// 属性描述：
        /// 字段信息：[OperDateTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime OperDateTime
        {
            get { return _operdatetime; }
            set
            {			
                if (_operdatetime as object == null || !_operdatetime.Equals(value))
                {
                    _operdatetime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ChangeOperator
        /// 属性描述：
        /// 字段信息：[ChangeOperator],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ChangeOperator
        {
            get { return _changeoperator; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 256)
                throw new Exception("[]长度不能大于256!");
                if (_changeoperator as object == null || !_changeoperator.Equals(value))
                {
                    _changeoperator = value;
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
