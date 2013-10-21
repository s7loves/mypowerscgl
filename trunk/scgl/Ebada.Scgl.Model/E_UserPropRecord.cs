/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada物流企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013/10/21 21:29:43
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[E_UserPropRecord]业务实体类
    ///对应表名:E_UserPropRecord
    /// </summary>
    [Serializable]
    public class E_UserPropRecord
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _userid=String.Empty; 
        private string _propid=String.Empty; 
        private int _num=0; 
        private int _usednum=0; 
        private int _canusenum=0; 
        private DateTime _buytime=new DateTime(1900,1,1); 
        private string _userecord=String.Empty; 
        private int _sequence=0; 
        private string _byscol1=String.Empty; 
        private string _byscol2=String.Empty; 
        private string _byscol3=String.Empty; 
        private string _byscol4=String.Empty; 
        private string _byscol5=String.Empty; 
        private string _remark=String.Empty; 
        private byte[] _rowversion=new byte[]{};   
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
                if( value.ToString().Length > 200)
                throw new Exception("[]长度不能大于200!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserID
        /// 属性描述：考生
        /// 字段信息：[UserID],nchar
        /// </summary>
        [DisplayNameAttribute("考生")]
        public string UserID
        {
            get { return _userid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[考生]长度不能大于10!");
                if (_userid as object == null || !_userid.Equals(value))
                {
                    _userid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：PropID
        /// 属性描述：道具名
        /// 字段信息：[PropID],nvarchar
        /// </summary>
        [DisplayNameAttribute("道具名")]
        public string PropID
        {
            get { return _propid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[道具名]长度不能大于50!");
                if (_propid as object == null || !_propid.Equals(value))
                {
                    _propid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Num
        /// 属性描述：购买数量
        /// 字段信息：[Num],int
        /// </summary>
        [DisplayNameAttribute("购买数量")]
        public int Num
        {
            get { return _num; }
            set
            {			
                if (_num as object == null || !_num.Equals(value))
                {
                    _num = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UsedNum
        /// 属性描述：已用数量
        /// 字段信息：[UsedNum],int
        /// </summary>
        [DisplayNameAttribute("已用数量")]
        public int UsedNum
        {
            get { return _usednum; }
            set
            {			
                if (_usednum as object == null || !_usednum.Equals(value))
                {
                    _usednum = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CanUseNum
        /// 属性描述：剩余数量
        /// 字段信息：[CanUseNum],int
        /// </summary>
        [DisplayNameAttribute("剩余数量")]
        public int CanUseNum
        {
            get { return _canusenum; }
            set
            {			
                if (_canusenum as object == null || !_canusenum.Equals(value))
                {
                    _canusenum = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BuyTime
        /// 属性描述：购买日期
        /// 字段信息：[BuyTime],datetime
        /// </summary>
        [DisplayNameAttribute("购买日期")]
        public DateTime BuyTime
        {
            get { return _buytime; }
            set
            {			
                if (_buytime as object == null || !_buytime.Equals(value))
                {
                    _buytime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UseRecord
        /// 属性描述：使用记录
        /// 字段信息：[UseRecord],nvarchar
        /// </summary>
        [DisplayNameAttribute("使用记录")]
        public string UseRecord
        {
            get { return _userecord; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[使用记录]长度不能大于500!");
                if (_userecord as object == null || !_userecord.Equals(value))
                {
                    _userecord = value;
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
        /// 属性名称：BySCol1
        /// 属性描述：备用1
        /// 字段信息：[BySCol1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用1")]
        public string BySCol1
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
        /// 属性名称：BySCol2
        /// 属性描述：备用2
        /// 字段信息：[BySCol2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用2")]
        public string BySCol2
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
        /// 属性名称：BySCol3
        /// 属性描述：备用3
        /// 字段信息：[BySCol3],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用3")]
        public string BySCol3
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
        /// 属性名称：BySCol4
        /// 属性描述：备用4
        /// 字段信息：[BySCol4],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用4")]
        public string BySCol4
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
        /// 属性名称：BySCol5
        /// 属性描述：备用5
        /// 字段信息：[BySCol5],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用5")]
        public string BySCol5
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
        /// 属性名称：RowVersion
        /// 属性描述：时间戳
        /// 字段信息：[RowVersion],timestamp
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("时间戳")]
        public byte[] RowVersion
        {
            get { return _rowversion; }
            set
            {			
                if (_rowversion as object == null || !_rowversion.Equals(value))
                {
                    _rowversion = value;
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
