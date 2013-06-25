/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada物流企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-6-25 9:58:02
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[WarnRecord]业务实体类
    ///对应表名:WarnRecord
    /// </summary>
    [Serializable]
    public class WarnRecord
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _type=String.Empty; 
        private int _sequence=0; 
        private string _tablename=String.Empty; 
        private string _fieldname=String.Empty; 
        private string _warntype=String.Empty; 
        private int _times=0; 
        private DateTime _writtime=new DateTime(1900,1,1); 
        private string _linkid=String.Empty; 
        private string _remark=String.Empty; 
        private string _des=String.Empty;   
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
        /// 属性名称：Sequence
        /// 属性描述：序号
        /// 字段信息：[Sequence],int
        /// </summary>
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
        /// 属性名称：Times
        /// 属性描述：次数
        /// 字段信息：[Times],int
        /// </summary>
        [DisplayNameAttribute("次数")]
        public int Times
        {
            get { return _times; }
            set
            {			
                if (_times as object == null || !_times.Equals(value))
                {
                    _times = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WritTime
        /// 属性描述：需要填写日期
        /// 字段信息：[WritTime],datetime
        /// </summary>
        [DisplayNameAttribute("需要填写日期")]
        public DateTime WritTime
        {
            get { return _writtime; }
            set
            {			
                if (_writtime as object == null || !_writtime.Equals(value))
                {
                    _writtime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LinkID
        /// 属性描述：快速进入
        /// 字段信息：[LinkID],nvarchar
        /// </summary>
        [DisplayNameAttribute("快速进入")]
        public string LinkID
        {
            get { return _linkid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[快速进入]长度不能大于50!");
                if (_linkid as object == null || !_linkid.Equals(value))
                {
                    _linkid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Remark
        /// 属性描述：
        /// 字段信息：[Remark],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Remark
        {
            get { return _remark; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[]长度不能大于200!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Des
        /// 属性描述：说明
        /// 字段信息：[Des],nvarchar
        /// </summary>
        [DisplayNameAttribute("说明")]
        public string Des
        {
            get { return _des; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[说明]长度不能大于200!");
                if (_des as object == null || !_des.Equals(value))
                {
                    _des = value;
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
