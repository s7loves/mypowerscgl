/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-10-25 17:06:29
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[WF_TableFieldValueView]业务实体类
    ///对应表名:WF_TableFieldValueView
    /// </summary>
    [Serializable]
    public class WF_TableFieldValueView
    {
        
        #region Private 成员
        private string _id = "";
        private byte[] _doccontent;
        private string _kind = "";
        private string _flowcaption = "";
        private byte[] _signimg;
        private byte[] _imageattachment;
        private int _sortid;
        private string _createtime = "";
        private string _lastchangetime = "";
        private string _status = "";
        private string _number = "";
        private string _orgname = "";
        private string _workflowid = "";
        private string _workflowinsid = "";
        private string _worktaskid = "";
        private string _worktaskinsid = "";
        private string _fieldid = "";
        private string _fieldname = "";
        private string _controlvalue = "";
        private string _usercontrolid = "";
        private int _xexcelpos;
        private int _yexcelpos;
        private string _excelsheetname = "";
        private string _isexplorer = "";
	
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ID
        {
            get { return _id; }
            set
            {			
		_id=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：DocContent
        /// 属性描述：
        /// 字段信息：[DocContent],image
        /// </summary>
        [DisplayNameAttribute("")]
        public byte[] DocContent
        {
            get { return _doccontent; }
            set
            {			
		_doccontent=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：Kind
        /// 属性描述：
        /// 字段信息：[Kind],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Kind
        {
            get { return _kind; }
            set
            {			
		_kind=value;	
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
		_flowcaption=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：SignImg
        /// 属性描述：
        /// 字段信息：[SignImg],image
        /// </summary>
        [DisplayNameAttribute("")]
        public byte[] SignImg
        {
            get { return _signimg; }
            set
            {			
		_signimg=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：ImageAttachment
        /// 属性描述：
        /// 字段信息：[ImageAttachment],image
        /// </summary>
        [DisplayNameAttribute("")]
        public byte[] ImageAttachment
        {
            get { return _imageattachment; }
            set
            {			
		_imageattachment=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：SortID
        /// 属性描述：
        /// 字段信息：[SortID],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int SortID
        {
            get { return _sortid; }
            set
            {			
		_sortid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateTime
        /// 属性描述：
        /// 字段信息：[CreateTime],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string CreateTime
        {
            get { return _createtime; }
            set
            {			
		_createtime=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：LastChangeTime
        /// 属性描述：
        /// 字段信息：[LastChangeTime],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string LastChangeTime
        {
            get { return _lastchangetime; }
            set
            {			
		_lastchangetime=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：Status
        /// 属性描述：
        /// 字段信息：[Status],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Status
        {
            get { return _status; }
            set
            {			
		_status=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：Number
        /// 属性描述：
        /// 字段信息：[Number],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Number
        {
            get { return _number; }
            set
            {			
		_number=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgName
        /// 属性描述：
        /// 字段信息：[OrgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string OrgName
        {
            get { return _orgname; }
            set
            {			
		_orgname=value;	
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
		_workflowid=value;	
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
		_workflowinsid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkTaskId
        /// 属性描述：
        /// 字段信息：[WorkTaskId],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorkTaskId
        {
            get { return _worktaskid; }
            set
            {			
		_worktaskid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkTaskInsId
        /// 属性描述：
        /// 字段信息：[WorkTaskInsId],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string WorkTaskInsId
        {
            get { return _worktaskinsid; }
            set
            {			
		_worktaskinsid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：FieldId
        /// 属性描述：
        /// 字段信息：[FieldId],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string FieldId
        {
            get { return _fieldid; }
            set
            {			
		_fieldid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：FieldName
        /// 属性描述：
        /// 字段信息：[FieldName],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string FieldName
        {
            get { return _fieldname; }
            set
            {			
		_fieldname=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：ControlValue
        /// 属性描述：
        /// 字段信息：[ControlValue],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ControlValue
        {
            get { return _controlvalue; }
            set
            {			
		_controlvalue=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserControlId
        /// 属性描述：
        /// 字段信息：[UserControlId],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string UserControlId
        {
            get { return _usercontrolid; }
            set
            {			
		_usercontrolid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：XExcelPos
        /// 属性描述：
        /// 字段信息：[XExcelPos],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int XExcelPos
        {
            get { return _xexcelpos; }
            set
            {			
		_xexcelpos=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：YExcelPos
        /// 属性描述：
        /// 字段信息：[YExcelPos],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int YExcelPos
        {
            get { return _yexcelpos; }
            set
            {			
		_yexcelpos=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：ExcelSheetName
        /// 属性描述：
        /// 字段信息：[ExcelSheetName],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ExcelSheetName
        {
            get { return _excelsheetname; }
            set
            {			
		_excelsheetname=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：isExplorer
        /// 属性描述：
        /// 字段信息：[isExplorer],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string isExplorer
        {
            get { return _isexplorer; }
            set
            {			
		_isexplorer=value;	
            }			 
        }
  
        #endregion 
  		
    }	
}
