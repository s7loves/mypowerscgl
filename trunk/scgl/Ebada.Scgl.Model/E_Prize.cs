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
    ///[E_Prize]业务实体类
    ///对应表名:E_Prize
    /// </summary>
    [Serializable]
    public class E_Prize
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _prizename=String.Empty; 
        private string _desc=String.Empty; 
        private string _type=String.Empty; 
        private string _selectchar=String.Empty; 
        private int _price=0; 
        private byte[] _image=new byte[]{}; 
        private int _sequence=0; 
        private int _allnum=0; 
        private int _currentnum=0; 
        private DateTime _begindate=new DateTime(1900,1,1); 
        private DateTime _enddate=new DateTime(1900,1,1); 
        private string _other=String.Empty; 
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
        /// 属性名称：PrizeName
        /// 属性描述：奖品名称
        /// 字段信息：[PrizeName],nvarchar
        /// </summary>
        [DisplayNameAttribute("奖品名称")]
        public string PrizeName
        {
            get { return _prizename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[奖品名称]长度不能大于50!");
                if (_prizename as object == null || !_prizename.Equals(value))
                {
                    _prizename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Desc
        /// 属性描述：说明
        /// 字段信息：[Desc],nchar
        /// </summary>
        [DisplayNameAttribute("说明")]
        public string Desc
        {
            get { return _desc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[说明]长度不能大于200!");
                if (_desc as object == null || !_desc.Equals(value))
                {
                    _desc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Type
        /// 属性描述：分类
        /// 字段信息：[Type],nvarchar
        /// </summary>
        [DisplayNameAttribute("分类")]
        public string Type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[分类]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SelectChar
        /// 属性描述：关键字
        /// 字段信息：[SelectChar],nvarchar
        /// </summary>
        [DisplayNameAttribute("关键字")]
        public string SelectChar
        {
            get { return _selectchar; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[关键字]长度不能大于500!");
                if (_selectchar as object == null || !_selectchar.Equals(value))
                {
                    _selectchar = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Price
        /// 属性描述：兑换分数
        /// 字段信息：[Price],int
        /// </summary>
        [DisplayNameAttribute("兑换分数")]
        public int Price
        {
            get { return _price; }
            set
            {			
                if (_price as object == null || !_price.Equals(value))
                {
                    _price = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Image
        /// 属性描述：图片
        /// 字段信息：[Image],image
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("图片")]
        public byte[] Image
        {
            get { return _image; }
            set
            {			
                if (_image as object == null || !_image.Equals(value))
                {
                    _image = value;
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
        /// 属性名称：AllNum
        /// 属性描述：总数量
        /// 字段信息：[AllNum],int
        /// </summary>
        [DisplayNameAttribute("总数量")]
        public int AllNum
        {
            get { return _allnum; }
            set
            {			
                if (_allnum as object == null || !_allnum.Equals(value))
                {
                    _allnum = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CurrentNum
        /// 属性描述：剩余数量
        /// 字段信息：[CurrentNum],int
        /// </summary>
        [DisplayNameAttribute("剩余数量")]
        public int CurrentNum
        {
            get { return _currentnum; }
            set
            {			
                if (_currentnum as object == null || !_currentnum.Equals(value))
                {
                    _currentnum = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BeginDate
        /// 属性描述：启始日期
        /// 字段信息：[BeginDate],datetime
        /// </summary>
        [DisplayNameAttribute("启始日期")]
        public DateTime BeginDate
        {
            get { return _begindate; }
            set
            {			
                if (_begindate as object == null || !_begindate.Equals(value))
                {
                    _begindate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：EndDate
        /// 属性描述：结束日期
        /// 字段信息：[EndDate],datetime
        /// </summary>
        [DisplayNameAttribute("结束日期")]
        public DateTime EndDate
        {
            get { return _enddate; }
            set
            {			
                if (_enddate as object == null || !_enddate.Equals(value))
                {
                    _enddate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Other
        /// 属性描述：领取说明
        /// 字段信息：[Other],nvarchar
        /// </summary>
        [DisplayNameAttribute("领取说明")]
        public string Other
        {
            get { return _other; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[领取说明]长度不能大于50!");
                if (_other as object == null || !_other.Equals(value))
                {
                    _other = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BySCol1
        /// 属性描述：备用1
        /// 字段信息：[BySCol1],nvarchar
        /// </summary>
        [Browsable(false)]
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
        [Browsable(false)]
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
        [Browsable(false)]
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
        [Browsable(false)]
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
        [Browsable(false)]
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
        [Browsable(false)]
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
