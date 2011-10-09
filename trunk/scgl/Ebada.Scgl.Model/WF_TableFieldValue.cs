/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-10-9 16:55:35
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[WF_TableFieldValue]业务实体类
    ///对应表名:WF_TableFieldValue
    /// </summary>
    [Serializable]
    public class WF_TableFieldValue
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _recordid=String.Empty; 
        private string _fieldid=String.Empty; 
        private string _workflowid=String.Empty; 
        private string _workflowinsid=String.Empty; 
        private string _worktaskid=String.Empty; 
        private string _worktaskinsid=String.Empty; 
        private string _controlvalue=String.Empty; 
        private string _usercontrolid=String.Empty; 
        private int _xexcelpos=0; 
        private int _yexcelpos=0; 
        private string _excelsheetname=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RecordId
        /// 属性描述：记录ID
        /// 字段信息：[RecordId],nvarchar
        /// </summary>
        [DisplayNameAttribute("记录ID")]
        public string RecordId
        {
            get { return _recordid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[记录ID]长度不能大于50!");
                if (_recordid as object == null || !_recordid.Equals(value))
                {
                    _recordid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FieldId
        /// 属性描述：表的字段ID
        /// 字段信息：[FieldId],nvarchar
        /// </summary>
        [DisplayNameAttribute("表的字段ID")]
        public string FieldId
        {
            get { return _fieldid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[表的字段ID]长度不能大于50!");
                if (_fieldid as object == null || !_fieldid.Equals(value))
                {
                    _fieldid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkFlowId
        /// 属性描述：流程ID
        /// 字段信息：[WorkFlowId],nvarchar
        /// </summary>
        [DisplayNameAttribute("流程ID")]
        public string WorkFlowId
        {
            get { return _workflowid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[流程ID]长度不能大于50!");
                if (_workflowid as object == null || !_workflowid.Equals(value))
                {
                    _workflowid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkFlowInsId
        /// 属性描述：流程实例ID
        /// 字段信息：[WorkFlowInsId],nvarchar
        /// </summary>
        [DisplayNameAttribute("流程实例ID")]
        public string WorkFlowInsId
        {
            get { return _workflowinsid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[流程实例ID]长度不能大于50!");
                if (_workflowinsid as object == null || !_workflowinsid.Equals(value))
                {
                    _workflowinsid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkTaskId
        /// 属性描述：节点ID
        /// 字段信息：[WorkTaskId],nvarchar
        /// </summary>
        [DisplayNameAttribute("节点ID")]
        public string WorkTaskId
        {
            get { return _worktaskid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[节点ID]长度不能大于50!");
                if (_worktaskid as object == null || !_worktaskid.Equals(value))
                {
                    _worktaskid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkTaskInsId
        /// 属性描述：节点实例ID
        /// 字段信息：[WorkTaskInsId],nvarchar
        /// </summary>
        [DisplayNameAttribute("节点实例ID")]
        public string WorkTaskInsId
        {
            get { return _worktaskinsid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[节点实例ID]长度不能大于50!");
                if (_worktaskinsid as object == null || !_worktaskinsid.Equals(value))
                {
                    _worktaskinsid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ControlValue
        /// 属性描述：字段输入的值
        /// 字段信息：[ControlValue],nvarchar
        /// </summary>
        [DisplayNameAttribute("字段输入的值")]
        public string ControlValue
        {
            get { return _controlvalue; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[字段输入的值]长度不能大于1073741823!");
                if (_controlvalue as object == null || !_controlvalue.Equals(value))
                {
                    _controlvalue = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserControlId
        /// 属性描述：表的ID
        /// 字段信息：[UserControlId],nvarchar
        /// </summary>
        [DisplayNameAttribute("表的ID")]
        public string UserControlId
        {
            get { return _usercontrolid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[表的ID]长度不能大于50!");
                if (_usercontrolid as object == null || !_usercontrolid.Equals(value))
                {
                    _usercontrolid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：XExcelPos
        /// 属性描述：所在Excel的行数
        /// 字段信息：[XExcelPos],int
        /// </summary>
        [DisplayNameAttribute("所在Excel的行数")]
        public int XExcelPos
        {
            get { return _xexcelpos; }
            set
            {			
                if (_xexcelpos as object == null || !_xexcelpos.Equals(value))
                {
                    _xexcelpos = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：YExcelPos
        /// 属性描述：所在Excel的列数
        /// 字段信息：[YExcelPos],int
        /// </summary>
        [DisplayNameAttribute("所在Excel的列数")]
        public int YExcelPos
        {
            get { return _yexcelpos; }
            set
            {			
                if (_yexcelpos as object == null || !_yexcelpos.Equals(value))
                {
                    _yexcelpos = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ExcelSheetName
        /// 属性描述：工作表的名字
        /// 字段信息：[ExcelSheetName],nvarchar
        /// </summary>
        [DisplayNameAttribute("工作表的名字")]
        public string ExcelSheetName
        {
            get { return _excelsheetname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 100)
                throw new Exception("[工作表的名字]长度不能大于100!");
                if (_excelsheetname as object == null || !_excelsheetname.Equals(value))
                {
                    _excelsheetname = value;
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
