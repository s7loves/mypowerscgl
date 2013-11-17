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
namespace Itop.Frame.Model
{
    /// <summary>
    ///[E_LevelTryRecord]业务实体类
    ///对应表名:E_LevelTryRecord
    /// </summary>
    [Serializable]
    public class E_LevelTryRecord
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _userid=String.Empty; 
        private string _seasonid=String.Empty; 
        private string _levelid=String.Empty; 
        private DateTime _passdate=new DateTime(1900,1,1); 
        private int _trytimes=0; 
        private int _usetime=0; 
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
        /// 属性名称：SeasonID
        /// 属性描述：季名
        /// 字段信息：[SeasonID],nvarchar
        /// </summary>
        [DisplayNameAttribute("季名")]
        public string SeasonID
        {
            get { return _seasonid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[季名]长度不能大于50!");
                if (_seasonid as object == null || !_seasonid.Equals(value))
                {
                    _seasonid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LevelID
        /// 属性描述：关卡名
        /// 字段信息：[LevelID],nvarchar
        /// </summary>
        [DisplayNameAttribute("关卡名")]
        public string LevelID
        {
            get { return _levelid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[关卡名]长度不能大于50!");
                if (_levelid as object == null || !_levelid.Equals(value))
                {
                    _levelid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：PassDate
        /// 属性描述：通过时间
        /// 字段信息：[PassDate],datetime
        /// </summary>
        [DisplayNameAttribute("通过时间")]
        public DateTime PassDate
        {
            get { return _passdate; }
            set
            {			
                if (_passdate as object == null || !_passdate.Equals(value))
                {
                    _passdate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TryTimes
        /// 属性描述：闯关次数
        /// 字段信息：[TryTimes],int
        /// </summary>
        [DisplayNameAttribute("闯关次数")]
        public int TryTimes
        {
            get { return _trytimes; }
            set
            {			
                if (_trytimes as object == null || !_trytimes.Equals(value))
                {
                    _trytimes = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UseTime
        /// 属性描述：最短时间（秒）
        /// 字段信息：[UseTime],int
        /// </summary>
        [DisplayNameAttribute("最短时间（秒）")]
        public int UseTime
        {
            get { return _usetime; }
            set
            {			
                if (_usetime as object == null || !_usetime.Equals(value))
                {
                    _usetime = value;
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
