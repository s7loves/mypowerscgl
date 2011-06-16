/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-5 10:36:43
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_WorkTask]业务实体类
    ///对应表名:PS_WorkTask
    /// </summary>
    [Serializable]
    public class WF_WorkTask
    {
        
        #region Private 成员
        private string _worktaskid=Newid(); 
        private string _workflowid=String.Empty; 
        private string _tasktypeid=String.Empty; 
        private string _tasktypeandor=String.Empty; 
        private string _taskcaption=String.Empty; 
        private int _ixposition=0; 
        private int _iyposition=0; 
        private string _description=String.Empty; 
        private string _commands=String.Empty; 
        private string _operrule=String.Empty; 
        private bool _isjumpself=false;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：WorkTaskId
        /// 属性描述：
        /// 字段信息：[WorkTaskId],varchar
        /// </summary>
        [Browsable(false)]
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
        /// 属性名称：TaskTypeId
        /// 属性描述：
        /// 字段信息：[TaskTypeId],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string TaskTypeId
        {
            get { return _tasktypeid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1)
                throw new Exception("[]长度不能大于1!");
                if (_tasktypeid as object == null || !_tasktypeid.Equals(value))
                {
                    _tasktypeid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TaskTypeAndOr
        /// 属性描述：
        /// 字段信息：[TaskTypeAndOr],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string TaskTypeAndOr
        {
            get { return _tasktypeandor; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_tasktypeandor as object == null || !_tasktypeandor.Equals(value))
                {
                    _tasktypeandor = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TaskCaption
        /// 属性描述：
        /// 字段信息：[TaskCaption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string TaskCaption
        {
            get { return _taskcaption; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 128)
                throw new Exception("[]长度不能大于128!");
                if (_taskcaption as object == null || !_taskcaption.Equals(value))
                {
                    _taskcaption = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：iXPosition
        /// 属性描述：
        /// 字段信息：[iXPosition],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int iXPosition
        {
            get { return _ixposition; }
            set
            {			
                if (_ixposition as object == null || !_ixposition.Equals(value))
                {
                    _ixposition = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：iYPosition
        /// 属性描述：
        /// 字段信息：[iYPosition],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int iYPosition
        {
            get { return _iyposition; }
            set
            {			
                if (_iyposition as object == null || !_iyposition.Equals(value))
                {
                    _iyposition = value;
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
        /// 属性名称：Commands
        /// 属性描述：
        /// 字段信息：[Commands],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Commands
        {
            get { return _commands; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_commands as object == null || !_commands.Equals(value))
                {
                    _commands = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OperRule
        /// 属性描述：
        /// 字段信息：[OperRule],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string OperRule
        {
            get { return _operrule; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1)
                throw new Exception("[]长度不能大于1!");
                if (_operrule as object == null || !_operrule.Equals(value))
                {
                    _operrule = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：IsJumpSelf
        /// 属性描述：
        /// 字段信息：[IsJumpSelf],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool IsJumpSelf
        {
            get { return _isjumpself; }
            set
            {			
                if (_isjumpself as object == null || !_isjumpself.Equals(value))
                {
                    _isjumpself = value;
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
