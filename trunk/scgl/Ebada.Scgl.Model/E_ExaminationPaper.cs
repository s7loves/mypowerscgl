/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:农电信息管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-8-24 10:15:23
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[E_ExaminationPaper]业务实体类
    ///对应表名:E_ExaminationPaper
    /// </summary>
    [Serializable]
    public class E_ExaminationPaper
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _ep_name=String.Empty; 
        private string _settingid=String.Empty; 
        private bool _orderrandom=false; 
        private int _totalscore=0; 
        private DateTime _createtime=new DateTime(1900,1,1); 
        private string _createman=String.Empty; 
        private string _paper_type=String.Empty; 
        private string _professionalid=String.Empty; 
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
        /// 属性描述：试卷编号
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("试卷编号")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[试卷编号]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：EP_Name
        /// 属性描述：试卷名称
        /// 字段信息：[EP_Name],nvarchar
        /// </summary>
        [DisplayNameAttribute("试卷名称")]
        public string EP_Name
        {
            get { return _ep_name; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[试卷名称]长度不能大于50!");
                if (_ep_name as object == null || !_ep_name.Equals(value))
                {
                    _ep_name = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SettingID
        /// 属性描述：设置ID
        /// 字段信息：[SettingID],nvarchar
        /// </summary>
        [DisplayNameAttribute("设置")]
        public string SettingID
        {
            get { return _settingid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设置ID]长度不能大于50!");
                if (_settingid as object == null || !_settingid.Equals(value))
                {
                    _settingid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrderRandom
        /// 属性描述：试题顺序随机
        /// 字段信息：[OrderRandom],bit
        /// </summary>
        [DisplayNameAttribute("试题顺序随机")]
        public bool OrderRandom
        {
            get { return _orderrandom; }
            set
            {			
                if (_orderrandom as object == null || !_orderrandom.Equals(value))
                {
                    _orderrandom = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TotalScore
        /// 属性描述：总分
        /// 字段信息：[TotalScore],int
        /// </summary>
        [DisplayNameAttribute("总分")]
        public int TotalScore
        {
            get { return _totalscore; }
            set
            {			
                if (_totalscore as object == null || !_totalscore.Equals(value))
                {
                    _totalscore = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateTime
        /// 属性描述：出题时间
        /// 字段信息：[CreateTime],datetime
        /// </summary>
        [DisplayNameAttribute("出题时间")]
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
        /// 属性名称：CreateMan
        /// 属性描述：出题人
        /// 字段信息：[CreateMan],nvarchar
        /// </summary>
        [DisplayNameAttribute("出题人")]
        public string CreateMan
        {
            get { return _createman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[出题人]长度不能大于50!");
                if (_createman as object == null || !_createman.Equals(value))
                {
                    _createman = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Paper_Type
        /// 属性描述：试卷类型(指定,随机)
        /// 字段信息：[Paper_Type],nvarchar
        /// </summary>
        [DisplayNameAttribute("试卷类型(指定")]
        public string Paper_Type
        {
            get { return _paper_type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[试卷类型(指定]长度不能大于50!");
                if (_paper_type as object == null || !_paper_type.Equals(value))
                {
                    _paper_type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ProfessionalID
        /// 属性描述：试卷专业
        /// 字段信息：[ProfessionalID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("试卷专业")]
        public string ProfessionalID
        {
            get { return _professionalid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[试卷专业]长度不能大于50!");
                if (_professionalid as object == null || !_professionalid.Equals(value))
                {
                    _professionalid = value;
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
