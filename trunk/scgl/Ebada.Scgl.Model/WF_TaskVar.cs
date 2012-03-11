/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-5 15:26:29
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_TaskVar]业务实体类
    ///对应表名:PS_TaskVar
    /// </summary>
    [Serializable]
    public class WF_TaskVar
    {
        
        #region Private 成员
        private string _taskvarid=Newid(); 
        private string _workflowid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _varname=String.Empty; 
        private string _vartype=String.Empty; 
        private string _varmodule=String.Empty; 
        private string _databasename=String.Empty; 
        private string _tablename=String.Empty; 
        private string _tablefield=String.Empty; 
        private string _initvalue=String.Empty; 
        private string _accesstype=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：TaskVarId
        /// 属性描述：
        /// 字段信息：[TaskVarId],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string TaskVarId
        {
            get { return _taskvarid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_taskvarid as object == null || !_taskvarid.Equals(value))
                {
                    _taskvarid = value;
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
        /// 属性名称：VarName
        /// 属性描述：
        /// 字段信息：[VarName],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string VarName
        {
            get { return _varname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 128)
                throw new Exception("[]长度不能大于128!");
                if (_varname as object == null || !_varname.Equals(value))
                {
                    _varname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：VarType
        /// 属性描述：
        /// 字段信息：[VarType],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string VarType
        {
            get { return _vartype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_vartype as object == null || !_vartype.Equals(value))
                {
                    _vartype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：VarModule
        /// 属性描述：
        /// 字段信息：[VarModule],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string VarModule
        {
            get { return _varmodule; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[]长度不能大于10!");
                if (_varmodule as object == null || !_varmodule.Equals(value))
                {
                    _varmodule = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：DataBaseName
        /// 属性描述：
        /// 字段信息：[DataBaseName],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string DataBaseName
        {
            get { return _databasename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 128)
                throw new Exception("[]长度不能大于128!");
                if (_databasename as object == null || !_databasename.Equals(value))
                {
                    _databasename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TableName
        /// 属性描述：
        /// 字段信息：[TableName],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string TableName
        {
            get { return _tablename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 128)
                throw new Exception("[]长度不能大于128!");
                if (_tablename as object == null || !_tablename.Equals(value))
                {
                    _tablename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TableField
        /// 属性描述：
        /// 字段信息：[TableField],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string TableField
        {
            get { return _tablefield; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 128)
                throw new Exception("[]长度不能大于128!");
                if (_tablefield as object == null || !_tablefield.Equals(value))
                {
                    _tablefield = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：InitValue
        /// 属性描述：
        /// 字段信息：[InitValue],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string InitValue
        {
            get { return _initvalue; }
            set
            {			
                if(value==null)return;
               
                if (_initvalue as object == null || !_initvalue.Equals(value))
                {
                    _initvalue = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：AccessType
        /// 属性描述：
        /// 字段信息：[AccessType],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string AccessType
        {
            get { return _accesstype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_accesstype as object == null || !_accesstype.Equals(value))
                {
                    _accesstype = value;
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
