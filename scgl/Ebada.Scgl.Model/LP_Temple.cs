/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-7-7 21:51:32
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[LP_Temple]业务实体类
    ///对应表名:LP_Temple
    /// </summary>
    [Serializable]
    public class LP_Temple
    {
        
        #region Private 成员
        private string _lpid=Newid(); 
        private string _parentid=String.Empty; 
        private string _ctrltype=String.Empty; 
        private string _ctrllocation=String.Empty; 
        private string _ctrlsize=String.Empty; 
        private string _cellname=String.Empty; 
        private string _cellpos=String.Empty; 
        private string _wordcount=String.Empty; 
        private string _eventname=String.Empty; 
        private int _isautoexecute=0; 
        private string _workflowpos=String.Empty; 
        private string _sqlsentence=String.Empty; 
        private string _sqlcolname=String.Empty; 
        private string _affectlpid=String.Empty; 
        private string _affectevent=String.Empty; 
        private string _relatelpid=String.Empty; 
        private byte[] _doccontent=new byte[]{}; 
        private byte[] _imageattachment=new byte[]{}; 
        private byte[] _signimg=new byte[]{}; 
        private string _kind=String.Empty; 
        private int _sortid=0; 
        private int _isvisible=0; 
        private string _columnname=String.Empty; 
        private string _status=String.Empty; 
        private string _comboxitem=String.Empty; 
        private string _extraword=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：LPID
        /// 属性描述：主ID
        /// 字段信息：[LPID],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("主ID")]
        public string LPID
        {
            get { return _lpid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[主ID]长度不能大于50!");
                if (_lpid as object == null || !_lpid.Equals(value))
                {
                    _lpid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ParentID
        /// 属性描述：父ID
        /// 字段信息：[ParentID],varchar
        /// </summary>
        [DisplayNameAttribute("父ID")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[父ID]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CtrlType
        /// 属性描述：控件类型
        /// 字段信息：[CtrlType],varchar
        /// </summary>
        [DisplayNameAttribute("控件类型")]
        public string CtrlType
        {
            get { return _ctrltype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[控件类型]长度不能大于200!");
                if (_ctrltype as object == null || !_ctrltype.Equals(value))
                {
                    _ctrltype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CtrlLocation
        /// 属性描述：控件位置（严格控制格式），如：100,100
        /// 字段信息：[CtrlLocation],varchar
        /// </summary>
        [DisplayNameAttribute("控件位置（严格控制格式），如：100")]
        public string CtrlLocation
        {
            get { return _ctrllocation; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[控件位置（严格控制格式），如：100]长度不能大于50!");
                if (_ctrllocation as object == null || !_ctrllocation.Equals(value))
                {
                    _ctrllocation = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CtrlSize
        /// 属性描述：控件大小（严格控制格式），如：100,100
        /// 字段信息：[CtrlSize],varchar
        /// </summary>
        [DisplayNameAttribute("控件大小（严格控制格式），如：100")]
        public string CtrlSize
        {
            get { return _ctrlsize; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[控件大小（严格控制格式），如：100]长度不能大于50!");
                if (_ctrlsize as object == null || !_ctrlsize.Equals(value))
                {
                    _ctrlsize = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CellName
        /// 属性描述：单元格名字，可能有多个，用|号分开
        /// 字段信息：[CellName],varchar
        /// </summary>
        [DisplayNameAttribute("单元格名字，可能有多个，用|号分开")]
        public string CellName
        {
            get { return _cellname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单元格名字，可能有多个，用|号分开]长度不能大于50!");
                if (_cellname as object == null || !_cellname.Equals(value))
                {
                    _cellname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CellPos
        /// 属性描述：单元格位置，与CellName顺序对应
        /// 字段信息：[CellPos],varchar
        /// </summary>
        [DisplayNameAttribute("单元格位置，与CellName顺序对应")]
        public string CellPos
        {
            get { return _cellpos; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单元格位置，与CellName顺序对应]长度不能大于50!");
                if (_cellpos as object == null || !_cellpos.Equals(value))
                {
                    _cellpos = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WordCount
        /// 属性描述：单元格对应的字数，与CellName和CellPos对应
        /// 字段信息：[WordCount],varchar
        /// </summary>
        [DisplayNameAttribute("单元格对应的字数，与CellName和CellPos对应")]
        public string WordCount
        {
            get { return _wordcount; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单元格对应的字数，与CellName和CellPos对应]长度不能大于50!");
                if (_wordcount as object == null || !_wordcount.Equals(value))
                {
                    _wordcount = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：EventName
        /// 属性描述：确定控件内容事件，一般用tab或enter
        /// 字段信息：[EventName],varchar
        /// </summary>
        [DisplayNameAttribute("确定控件内容事件，一般用tab或enter")]
        public string EventName
        {
            get { return _eventname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[确定控件内容事件，一般用tab或enter]长度不能大于50!");
                if (_eventname as object == null || !_eventname.Equals(value))
                {
                    _eventname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：IsAutoExecute
        /// 属性描述：是否自动执行填充excel单元格数据
        /// 字段信息：[IsAutoExecute],int
        /// </summary>
        [DisplayNameAttribute("是否自动执行填充excel单元格数据")]
        public int IsAutoExecute
        {
            get { return _isautoexecute; }
            set
            {			
                if (_isautoexecute as object == null || !_isautoexecute.Equals(value))
                {
                    _isautoexecute = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkflowPos
        /// 属性描述：所属流程位置
        /// 字段信息：[WorkflowPos],varchar
        /// </summary>
        [DisplayNameAttribute("所属流程位置")]
        public string WorkflowPos
        {
            get { return _workflowpos; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[所属流程位置]长度不能大于50!");
                if (_workflowpos as object == null || !_workflowpos.Equals(value))
                {
                    _workflowpos = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SqlSentence
        /// 属性描述：sql语句，用于从数据库中取数据，如果受其他控件影响，用@号表示控件值，与RelateLPID顺序对应
        /// 字段信息：[SqlSentence],varchar
        /// </summary>
        [DisplayNameAttribute("sql语句，用于从数据库中取数据，如果受其他控件影响，用@号表示控件值，与RelateLPID顺序对应")]
        public string SqlSentence
        {
            get { return _sqlsentence; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[sql语句，用于从数据库中取数据，如果受其他控件影响，用@号表示控件值，与RelateLPID顺序对应]长度不能大于200!");
                if (_sqlsentence as object == null || !_sqlsentence.Equals(value))
                {
                    _sqlsentence = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SqlColName
        /// 属性描述：要查找的表的列名
        /// 字段信息：[SqlColName],varchar
        /// </summary>
        [DisplayNameAttribute("要查找的表的列名")]
        public string SqlColName
        {
            get { return _sqlcolname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[要查找的表的列名]长度不能大于50!");
                if (_sqlcolname as object == null || !_sqlcolname.Equals(value))
                {
                    _sqlcolname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：AffectLPID
        /// 属性描述：受此控件影响的其他控件，用|号分开，用于联动事件
        /// 字段信息：[AffectLPID],varchar
        /// </summary>
        [DisplayNameAttribute("受此控件影响的其他控件，用|号分开，用于联动事件")]
        public string AffectLPID
        {
            get { return _affectlpid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[受此控件影响的其他控件，用|号分开，用于联动事件]长度不能大于200!");
                if (_affectlpid as object == null || !_affectlpid.Equals(value))
                {
                    _affectlpid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：AffectEvent
        /// 属性描述：关联触发事件，用|号分开，与AffectLPID对应，用于联动事件
        /// 字段信息：[AffectEvent],varchar
        /// </summary>
        [DisplayNameAttribute("关联触发事件，用|号分开，与AffectLPID对应，用于联动事件")]
        public string AffectEvent
        {
            get { return _affectevent; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[关联触发事件，用|号分开，与AffectLPID对应，用于联动事件]长度不能大于200!");
                if (_affectevent as object == null || !_affectevent.Equals(value))
                {
                    _affectevent = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RelateLPID
        /// 属性描述：影响到此控件的控件ID，用于联动事件，可能有多个，用‘|’号隔开，用于取那些控件的值
        /// 字段信息：[RelateLPID],varchar
        /// </summary>
        [DisplayNameAttribute("影响到此控件的控件ID，用于联动事件，可能有多个，用‘|’号隔开，用于取那些控件的值")]
        public string RelateLPID
        {
            get { return _relatelpid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[影响到此控件的控件ID，用于联动事件，可能有多个，用‘|’号隔开，用于取那些控件的值]长度不能大于200!");
                if (_relatelpid as object == null || !_relatelpid.Equals(value))
                {
                    _relatelpid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：DocContent
        /// 属性描述：excel模板内容
        /// 字段信息：[DocContent],image
        /// </summary>
        [DisplayNameAttribute("excel模板内容")]
        public byte[] DocContent
        {
            get { return _doccontent; }
            set
            {			
                if (_doccontent as object == null || !_doccontent.Equals(value))
                {
                    _doccontent = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ImageAttachment
        /// 属性描述：附图
        /// 字段信息：[ImageAttachment],image
        /// </summary>
        [DisplayNameAttribute("附图")]
        public byte[] ImageAttachment
        {
            get { return _imageattachment; }
            set
            {			
                if (_imageattachment as object == null || !_imageattachment.Equals(value))
                {
                    _imageattachment = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SignImg
        /// 属性描述：签名图片
        /// 字段信息：[SignImg],image
        /// </summary>
        [DisplayNameAttribute("签名图片")]
        public byte[] SignImg
        {
            get { return _signimg; }
            set
            {			
                if (_signimg as object == null || !_signimg.Equals(value))
                {
                    _signimg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Kind
        /// 属性描述：票的种类
        /// 字段信息：[Kind],varchar
        /// </summary>
        [DisplayNameAttribute("票的种类")]
        public string Kind
        {
            get { return _kind; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[票的种类]长度不能大于50!");
                if (_kind as object == null || !_kind.Equals(value))
                {
                    _kind = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SortID
        /// 属性描述：排序ID
        /// 字段信息：[SortID],int
        /// </summary>
        [DisplayNameAttribute("排序ID")]
        public int SortID
        {
            get { return _sortid; }
            set
            {			
                if (_sortid as object == null || !_sortid.Equals(value))
                {
                    _sortid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：IsVisible
        /// 属性描述：是否可见
        /// 字段信息：[IsVisible],int
        /// </summary>
        [DisplayNameAttribute("是否可见")]
        public int IsVisible
        {
            get { return _isvisible; }
            set
            {			
                if (_isvisible as object == null || !_isvisible.Equals(value))
                {
                    _isvisible = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ColumnName
        /// 属性描述：excel中表格的列名，用|线分开，如：工作地点|工作内容
        /// 字段信息：[ColumnName],varchar
        /// </summary>
        [DisplayNameAttribute("excel中表格的列名，用|线分开，如：工作地点|工作内容")]
        public string ColumnName
        {
            get { return _columnname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[excel中表格的列名，用|线分开，如：工作地点|工作内容]长度不能大于50!");
                if (_columnname as object == null || !_columnname.Equals(value))
                {
                    _columnname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Status
        /// 属性描述：状态
        /// 字段信息：[Status],varchar
        /// </summary>
        [DisplayNameAttribute("状态")]
        public string Status
        {
            get { return _status; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[状态]长度不能大于200!");
                if (_status as object == null || !_status.Equals(value))
                {
                    _status = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ComBoxItem
        /// 属性描述：combox集合
        /// 字段信息：[ComBoxItem],varchar
        /// </summary>
        [DisplayNameAttribute("combox集合")]
        public string ComBoxItem
        {
            get { return _comboxitem; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[combox集合]长度不能大于200!");
                if (_comboxitem as object == null || !_comboxitem.Equals(value))
                {
                    _comboxitem = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ExtraWord
        /// 属性描述：额外字段
        /// 字段信息：[ExtraWord],varchar
        /// </summary>
        [DisplayNameAttribute("额外字段")]
        public string ExtraWord
        {
            get { return _extraword; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[额外字段]长度不能大于200!");
                if (_extraword as object == null || !_extraword.Equals(value))
                {
                    _extraword = value;
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
