/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada物流企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013/9/27 21:18:10
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[E_ScoreSummary]业务实体类
    ///对应表名:E_ScoreSummary
    /// </summary>
    [Serializable]
    public class E_ScoreSummary
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _exmaid=String.Empty; 
        private string _examname=String.Empty; 
        private double _averagesocre=0; 
        private int _needexamusernum=0; 
        private int _realexamusenum=0; 
        private int _passnum=0; 
        private double _passpercent=0; 
        private int _nopassnum=0; 
        private double _nopasspercent=0; 
        private double _goodpercent=0; 
        private DateTime _createtime=new DateTime(1900,1,1); 
        private int _sequence=0; 
        private int _byint1=0; 
        private int _byint2=0; 
        private double _byfloat1=0; 
        private double _byfloat2=0; 
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
        /// 属性名称：ExmaID
        /// 属性描述：考试
        /// 字段信息：[ExmaID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("考试")]
        public string ExmaID
        {
            get { return _exmaid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[考试]长度不能大于50!");
                if (_exmaid as object == null || !_exmaid.Equals(value))
                {
                    _exmaid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ExamName
        /// 属性描述：考试
        /// 字段信息：[ExamName],nvarchar
        /// </summary>
        [DisplayNameAttribute("考试")]
        public string ExamName
        {
            get { return _examname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[考试]长度不能大于50!");
                if (_examname as object == null || !_examname.Equals(value))
                {
                    _examname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：AverageSocre
        /// 属性描述：平均分
        /// 字段信息：[AverageSocre],float
        /// </summary>
        [DisplayNameAttribute("平均分")]
        public double AverageSocre
        {
            get { return _averagesocre; }
            set
            {			
                if (_averagesocre as object == null || !_averagesocre.Equals(value))
                {
                    _averagesocre = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：NeedExamUserNum
        /// 属性描述：应考人数
        /// 字段信息：[NeedExamUserNum],int
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("应考人数")]
        public int NeedExamUserNum
        {
            get { return _needexamusernum; }
            set
            {			
                if (_needexamusernum as object == null || !_needexamusernum.Equals(value))
                {
                    _needexamusernum = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RealExamUseNum
        /// 属性描述：实考人数
        /// 字段信息：[RealExamUseNum],int
        /// </summary>
        [DisplayNameAttribute("实考人数")]
        public int RealExamUseNum
        {
            get { return _realexamusenum; }
            set
            {			
                if (_realexamusenum as object == null || !_realexamusenum.Equals(value))
                {
                    _realexamusenum = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：PassNum
        /// 属性描述：及格人数
        /// 字段信息：[PassNum],int
        /// </summary>
        [DisplayNameAttribute("及格人数")]
        public int PassNum
        {
            get { return _passnum; }
            set
            {			
                if (_passnum as object == null || !_passnum.Equals(value))
                {
                    _passnum = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：PassPercent
        /// 属性描述：通过率
        /// 字段信息：[PassPercent],float
        /// </summary>
        [DisplayNameAttribute("通过率")]
        public double PassPercent
        {
            get { return _passpercent; }
            set
            {			
                if (_passpercent as object == null || !_passpercent.Equals(value))
                {
                    _passpercent = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：NoPassNum
        /// 属性描述：不通过人数
        /// 字段信息：[NoPassNum],int
        /// </summary>
        [DisplayNameAttribute("不通过人数")]
        public int NoPassNum
        {
            get { return _nopassnum; }
            set
            {			
                if (_nopassnum as object == null || !_nopassnum.Equals(value))
                {
                    _nopassnum = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：NoPassPercent
        /// 属性描述：不通过率
        /// 字段信息：[NoPassPercent],float
        /// </summary>
        [DisplayNameAttribute("不通过率")]
        public double NoPassPercent
        {
            get { return _nopasspercent; }
            set
            {			
                if (_nopasspercent as object == null || !_nopasspercent.Equals(value))
                {
                    _nopasspercent = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：GoodPercent
        /// 属性描述：优秀率
        /// 字段信息：[GoodPercent],float
        /// </summary>
        [DisplayNameAttribute("优秀率")]
        public double GoodPercent
        {
            get { return _goodpercent; }
            set
            {			
                if (_goodpercent as object == null || !_goodpercent.Equals(value))
                {
                    _goodpercent = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateTime
        /// 属性描述：发布时间
        /// 字段信息：[CreateTime],datetime
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("发布时间")]
        public DateTime CreateTime
        {
            get { return _createtime; }
            set
            {			
                if (_createtime as object == null || !_createtime.Equals(value))
                {
                    _createtime = value;
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
        /// 属性名称：ByInt1
        /// 属性描述：备用整型
        /// 字段信息：[ByInt1],int
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备用整型")]
        public int ByInt1
        {
            get { return _byint1; }
            set
            {			
                if (_byint1 as object == null || !_byint1.Equals(value))
                {
                    _byint1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ByInt2
        /// 属性描述：备用整型
        /// 字段信息：[ByInt2],int
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备用整型")]
        public int ByInt2
        {
            get { return _byint2; }
            set
            {			
                if (_byint2 as object == null || !_byint2.Equals(value))
                {
                    _byint2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ByFloat1
        /// 属性描述：备用实型
        /// 字段信息：[ByFloat1],float
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备用实型")]
        public double ByFloat1
        {
            get { return _byfloat1; }
            set
            {			
                if (_byfloat1 as object == null || !_byfloat1.Equals(value))
                {
                    _byfloat1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ByFloat2
        /// 属性描述：备用实型
        /// 字段信息：[ByFloat2],float
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备用实型")]
        public double ByFloat2
        {
            get { return _byfloat2; }
            set
            {			
                if (_byfloat2 as object == null || !_byfloat2.Equals(value))
                {
                    _byfloat2 = value;
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
                if (value == null) return;
                if (value.ToString().Length > 200)
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
                if (value == null) return;
                if (value.ToString().Length > 200)
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
                if (value == null) return;
                if (value.ToString().Length > 200)
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
                if (value == null) return;
                if (value.ToString().Length > 200)
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
                if (value == null) return;
                if (value.ToString().Length > 200)
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
                if (value == null) return;
                if (value.ToString().Length > 200)
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
