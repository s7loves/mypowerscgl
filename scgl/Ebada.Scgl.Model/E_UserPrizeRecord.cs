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
    ///[E_UserPrizeRecord]业务实体类
    ///对应表名:E_UserPrizeRecord
    /// </summary>
    [Serializable]
    public class E_UserPrizeRecord
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _userid=String.Empty; 
        private string _prizeid=String.Empty; 
        private DateTime _sendtime=new DateTime(1900,1,1); 
        private int _prizenum=0; 
        private int _sequence=0; 
        private bool _hasfinished=false; 
        private string _handler=String.Empty; 
        private DateTime _exchangetime=new DateTime(1900,1,1); 
        private string _record=String.Empty; 
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
        /// 字段信息：[UserID],nvarchar
        /// </summary>
        [DisplayNameAttribute("考生")]
        public string UserID
        {
            get { return _userid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[考生]长度不能大于50!");
                if (_userid as object == null || !_userid.Equals(value))
                {
                    _userid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：PrizeID
        /// 属性描述：奖品
        /// 字段信息：[PrizeID],nvarchar
        /// </summary>
        [DisplayNameAttribute("奖品")]
        public string PrizeID
        {
            get { return _prizeid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[奖品]长度不能大于50!");
                if (_prizeid as object == null || !_prizeid.Equals(value))
                {
                    _prizeid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SendTime
        /// 属性描述：提交日期
        /// 字段信息：[SendTime],datetime
        /// </summary>
        [DisplayNameAttribute("提交日期")]
        public DateTime SendTime
        {
            get { return _sendtime; }
            set
            {			
                if (_sendtime as object == null || !_sendtime.Equals(value))
                {
                    _sendtime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：PrizeNum
        /// 属性描述：兑换数量
        /// 字段信息：[PrizeNum],int
        /// </summary>
        [DisplayNameAttribute("兑换数量")]
        public int PrizeNum
        {
            get { return _prizenum; }
            set
            {			
                if (_prizenum as object == null || !_prizenum.Equals(value))
                {
                    _prizenum = value;
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
        /// 属性名称：HasFinished
        /// 属性描述：是否支付将品
        /// 字段信息：[HasFinished],bit
        /// </summary>
        [DisplayNameAttribute("是否支付将品")]
        public bool HasFinished
        {
            get { return _hasfinished; }
            set
            {			
                if (_hasfinished as object == null || !_hasfinished.Equals(value))
                {
                    _hasfinished = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Handler
        /// 属性描述：经办人
        /// 字段信息：[Handler],nvarchar
        /// </summary>
        [DisplayNameAttribute("经办人")]
        public string Handler
        {
            get { return _handler; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[经办人]长度不能大于50!");
                if (_handler as object == null || !_handler.Equals(value))
                {
                    _handler = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ExchangeTime
        /// 属性描述：兑换日期
        /// 字段信息：[ExchangeTime],datetime
        /// </summary>
        [DisplayNameAttribute("兑换日期")]
        public DateTime ExchangeTime
        {
            get { return _exchangetime; }
            set
            {			
                if (_exchangetime as object == null || !_exchangetime.Equals(value))
                {
                    _exchangetime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Record
        /// 属性描述：兑换记事
        /// 字段信息：[Record],nvarchar
        /// </summary>
        [DisplayNameAttribute("兑换记事")]
        public string Record
        {
            get { return _record; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[兑换记事]长度不能大于200!");
                if (_record as object == null || !_record.Equals(value))
                {
                    _record = value;
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
