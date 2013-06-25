/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada物流企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-6-24 10:08:38
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[WarnSet]业务实体类
    ///对应表名:WarnSet
    /// </summary>
    [Serializable]
    public class WarnSet
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _type=String.Empty; 
        private string _typename=String.Empty; 
        private int _sequence=0; 
        private string _tablename=String.Empty; 
        private string _tablecnname=String.Empty; 
        private string _fieldname=String.Empty; 
        private string _fieldcnname=String.Empty; 
        private string _warntype=String.Empty; 
        private string _warntypename=String.Empty; 
        private int _orderdays=0; 
        private int _spacedays=0; 
        private int _beforedays=0; 
        private int _afterdays=0; 
        private int _warntimes=0; 
        private string _orgfield=String.Empty; 
        private string _setuserid=String.Empty; 
        private DateTime _settime=new DateTime(1900,1,1); 
        private string _remark=String.Empty; 
        private bool _isuse=false; 
        private string _linkid=String.Empty; 
        private string _linkname=String.Empty; 
        private string _byscol1=String.Empty; 
        private string _byscol2=String.Empty; 
        private string _byscol3=String.Empty; 
        private string _byscol4=String.Empty; 
        private string _byscol5=String.Empty;   
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
        /// 属性名称：Type
        /// 属性描述：类型
        /// 字段信息：[Type],nvarchar
        /// </summary>
        [DisplayNameAttribute("类型")]
        public string Type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[类型]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TypeName
        /// 属性描述：类型明称
        /// 字段信息：[TypeName],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("类型明称")]
        public string TypeName
        {
            get { return _typename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 100)
                throw new Exception("[类型明称]长度不能大于100!");
                if (_typename as object == null || !_typename.Equals(value))
                {
                    _typename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Sequence
        /// 属性描述：序号
        /// 字段信息：[Sequence],int
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("序号")]
        public int Sequence
        {
            get { return _sequence; }
            set
            {			
                if (_sequence as object == null || !_sequence.Equals(value))
                {
                    _sequence = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TableName
        /// 属性描述：表名
        /// 字段信息：[TableName],nvarchar
        /// </summary>
        [DisplayNameAttribute("表名")]
        public string TableName
        {
            get { return _tablename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[表名]长度不能大于50!");
                if (_tablename as object == null || !_tablename.Equals(value))
                {
                    _tablename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TableCNName
        /// 属性描述：表中文名
        /// 字段信息：[TableCNName],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("表中文名")]
        public string TableCNName
        {
            get { return _tablecnname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[表中文名]长度不能大于50!");
                if (_tablecnname as object == null || !_tablecnname.Equals(value))
                {
                    _tablecnname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FieldName
        /// 属性描述：字段名
        /// 字段信息：[FieldName],nvarchar
        /// </summary>
        [DisplayNameAttribute("字段名")]
        public string FieldName
        {
            get { return _fieldname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[字段名]长度不能大于50!");
                if (_fieldname as object == null || !_fieldname.Equals(value))
                {
                    _fieldname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FieldCNName
        /// 属性描述：字段中文名
        /// 字段信息：[FieldCNName],nchar
        /// </summary>
        [DisplayNameAttribute("字段中文名")]
        public string FieldCNName
        {
            get { return _fieldcnname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[字段中文名]长度不能大于50!");
                if (_fieldcnname as object == null || !_fieldcnname.Equals(value))
                {
                    _fieldcnname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WarnType
        /// 属性描述：提醒类型
        /// 字段信息：[WarnType],nvarchar
        /// </summary>
        [DisplayNameAttribute("提醒类型")]
        public string WarnType
        {
            get { return _warntype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[提醒类型]长度不能大于50!");
                if (_warntype as object == null || !_warntype.Equals(value))
                {
                    _warntype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WarnTypeName
        /// 属性描述：提醒类型名称
        /// 字段信息：[WarnTypeName],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("提醒类型名称")]
        public string WarnTypeName
        {
            get { return _warntypename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[提醒类型名称]长度不能大于50!");
                if (_warntypename as object == null || !_warntypename.Equals(value))
                {
                    _warntypename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrderDays
        /// 属性描述：顺序天数
        /// 字段信息：[OrderDays],int
        /// </summary>
        [DisplayNameAttribute("顺序天数")]
        public int OrderDays
        {
            get { return _orderdays; }
            set
            {			
                if (_orderdays as object == null || !_orderdays.Equals(value))
                {
                    _orderdays = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SpaceDays
        /// 属性描述：间隔天数
        /// 字段信息：[SpaceDays],int
        /// </summary>
        [DisplayNameAttribute("间隔天数")]
        public int SpaceDays
        {
            get { return _spacedays; }
            set
            {			
                if (_spacedays as object == null || !_spacedays.Equals(value))
                {
                    _spacedays = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BeforeDays
        /// 属性描述： 提前几天提醒
        /// 字段信息：[BeforeDays],int
        /// </summary>
        [DisplayNameAttribute(" 提前几天提醒")]
        public int BeforeDays
        {
            get { return _beforedays; }
            set
            {			
                if (_beforedays as object == null || !_beforedays.Equals(value))
                {
                    _beforedays = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：AfterDays
        /// 属性描述：延后几天提醒
        /// 字段信息：[AfterDays],int
        /// </summary>
        [DisplayNameAttribute("延后几天提醒")]
        public int AfterDays
        {
            get { return _afterdays; }
            set
            {			
                if (_afterdays as object == null || !_afterdays.Equals(value))
                {
                    _afterdays = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WarnTimes
        /// 属性描述：提醒往次数
        /// 字段信息：[WarnTimes],int
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("提醒往次数")]
        public int WarnTimes
        {
            get { return _warntimes; }
            set
            {			
                if (_warntimes as object == null || !_warntimes.Equals(value))
                {
                    _warntimes = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgField
        /// 属性描述：单位字段
        /// 字段信息：[OrgField],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位字段")]
        public string OrgField
        {
            get { return _orgfield; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位字段]长度不能大于50!");
                if (_orgfield as object == null || !_orgfield.Equals(value))
                {
                    _orgfield = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SetUserID
        /// 属性描述：设置人
        /// 字段信息：[SetUserID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("设置人")]
        public string SetUserID
        {
            get { return _setuserid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设置人]长度不能大于50!");
                if (_setuserid as object == null || !_setuserid.Equals(value))
                {
                    _setuserid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SetTime
        /// 属性描述：设置时间
        /// 字段信息：[SetTime],datetime
        /// </summary>
        [DisplayNameAttribute("设置时间")]
        public DateTime SetTime
        {
            get { return _settime; }
            set
            {			
                if (_settime as object == null || !_settime.Equals(value))
                {
                    _settime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Remark
        /// 属性描述：备注
        /// 字段信息：[Remark],nvarchar
        /// </summary>
        [DisplayNameAttribute("备注")]
        public string Remark
        {
            get { return _remark; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备注]长度不能大于200!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：IsUse
        /// 属性描述：启用
        /// 字段信息：[IsUse],bit
        /// </summary>
        [DisplayNameAttribute("启用")]
        public bool IsUse
        {
            get { return _isuse; }
            set
            {			
                if (_isuse as object == null || !_isuse.Equals(value))
                {
                    _isuse = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LinkID
        /// 属性描述：链接ID
        /// 字段信息：[LinkID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("链接ID")]
        public string LinkID
        {
            get { return _linkid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[链接ID]长度不能大于200!");
                if (_linkid as object == null || !_linkid.Equals(value))
                {
                    _linkid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LinkName
        /// 属性描述：链接名称
        /// 字段信息：[LinkName],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("链接名称")]
        public string LinkName
        {
            get { return _linkname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[链接名称]长度不能大于200!");
                if (_linkname as object == null || !_linkname.Equals(value))
                {
                    _linkname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BYScol1
        /// 属性描述：备用1
        /// 字段信息：[BYScol1],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备用1")]
        public string BYScol1
        {
            get { return _byscol1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备用1]长度不能大于200!");
                if (_byscol1 as object == null || !_byscol1.Equals(value))
                {
                    _byscol1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BYScol2
        /// 属性描述：备用2
        /// 字段信息：[BYScol2],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备用2")]
        public string BYScol2
        {
            get { return _byscol2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备用2]长度不能大于200!");
                if (_byscol2 as object == null || !_byscol2.Equals(value))
                {
                    _byscol2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BYScol3
        /// 属性描述：备用3
        /// 字段信息：[BYScol3],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备用3")]
        public string BYScol3
        {
            get { return _byscol3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备用3]长度不能大于200!");
                if (_byscol3 as object == null || !_byscol3.Equals(value))
                {
                    _byscol3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BYScol4
        /// 属性描述：备用4
        /// 字段信息：[BYScol4],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备用4")]
        public string BYScol4
        {
            get { return _byscol4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备用4]长度不能大于200!");
                if (_byscol4 as object == null || !_byscol4.Equals(value))
                {
                    _byscol4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BYScol5
        /// 属性描述：备用5
        /// 字段信息：[BYScol5],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备用5")]
        public string BYScol5
        {
            get { return _byscol5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备用5]长度不能大于200!");
                if (_byscol5 as object == null || !_byscol5.Equals(value))
                {
                    _byscol5 = value;
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
