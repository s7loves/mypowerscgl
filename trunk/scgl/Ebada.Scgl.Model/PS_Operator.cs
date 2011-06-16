/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-5 15:13:54
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_Operator]业务实体类
    ///对应表名:PS_Operator
    /// </summary>
    [Serializable]
    public class PS_Operator
    {
        
        #region Private 成员
        private string _operatorid=Newid(); 
        private string _workflowid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _nexttype=String.Empty; 
        private int _opertype=0; 
        private string _opercontent=String.Empty; 
        private int _relation=0; 
        private string _description=String.Empty; 
        private bool _inorexclude=false; 
        private string _operdisplay=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：OperatorId
        /// 属性描述：
        /// 字段信息：[OperatorId],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string OperatorId
        {
            get { return _operatorid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_operatorid as object == null || !_operatorid.Equals(value))
                {
                    _operatorid = value;
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
        /// 属性名称：NextType
        /// 属性描述：
        /// 字段信息：[NextType],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string NextType
        {
            get { return _nexttype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_nexttype as object == null || !_nexttype.Equals(value))
                {
                    _nexttype = value;
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
        /// 属性名称：Relation
        /// 属性描述：
        /// 字段信息：[Relation],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int Relation
        {
            get { return _relation; }
            set
            {			
                if (_relation as object == null || !_relation.Equals(value))
                {
                    _relation = value;
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
                if( value.ToString().Length > 256)
                throw new Exception("[]长度不能大于256!");
                if (_description as object == null || !_description.Equals(value))
                {
                    _description = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：InorExclude
        /// 属性描述：
        /// 字段信息：[InorExclude],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool InorExclude
        {
            get { return _inorexclude; }
            set
            {			
                if (_inorexclude as object == null || !_inorexclude.Equals(value))
                {
                    _inorexclude = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OperDisplay
        /// 属性描述：
        /// 字段信息：[OperDisplay],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string OperDisplay
        {
            get { return _operdisplay; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 256)
                throw new Exception("[]长度不能大于256!");
                if (_operdisplay as object == null || !_operdisplay.Equals(value))
                {
                    _operdisplay = value;
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
