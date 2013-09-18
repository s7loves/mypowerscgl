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
    ///[E_ExamAnswerResult]业务实体类
    ///对应表名:E_ExamAnswerResult
    /// </summary>
    [Serializable]
    public class E_ExamAnswerResult
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _examqueston_id=String.Empty; 
        private string _answer=String.Empty; 
        private bool _isright=false; 
        private string _randomid=String.Empty; 
        private string _examquestontype=String.Empty; 
        private string _appraise=String.Empty;
        private double _scoure = 0; 
        private string _comment=String.Empty; 
        private int _sequence=0; 
        private string _byscol1=String.Empty; 
        private string _byscol2=String.Empty; 
        private string _byscol3=String.Empty; 
        private string _byscol4=String.Empty; 
        private string _byscol5=String.Empty; 
        private string _remark=String.Empty; 
        private byte[] _rowversion=new byte[]{}; 
        private string _e_id=String.Empty; 
        private string _ep_id=String.Empty; 
        private string _userid=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：记录ID
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("记录ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[记录ID]长度不能大于200!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ExamQueston_ID
        /// 属性描述：考试试题编号
        /// 字段信息：[ExamQueston_ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("考试试题编号")]
        public string ExamQueston_ID
        {
            get { return _examqueston_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[考试试题编号]长度不能大于50!");
                if (_examqueston_id as object == null || !_examqueston_id.Equals(value))
                {
                    _examqueston_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Answer
        /// 属性描述：答案
        /// 字段信息：[Answer],nvarchar
        /// </summary>
        [DisplayNameAttribute("答案")]
        public string Answer
        {
            get { return _answer; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[答案]长度不能大于50!");
                if (_answer as object == null || !_answer.Equals(value))
                {
                    _answer = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：IsRight
        /// 属性描述：是否正确
        /// 字段信息：[IsRight],bit
        /// </summary>
        [DisplayNameAttribute("是否正确")]
        public bool IsRight
        {
            get { return _isright; }
            set
            {			
                if (_isright as object == null || !_isright.Equals(value))
                {
                    _isright = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RandomID
        /// 属性描述：随机试题号
        /// 字段信息：[RandomID],nvarchar
        /// </summary>
        [DisplayNameAttribute("随机试题号")]
        public string RandomID
        {
            get { return _randomid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[随机试题号]长度不能大于50!");
                if (_randomid as object == null || !_randomid.Equals(value))
                {
                    _randomid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ExamQuestonType
        /// 属性描述：试题类型
        /// 字段信息：[ExamQuestonType],nvarchar
        /// </summary>
        [DisplayNameAttribute("试题类型")]
        public string ExamQuestonType
        {
            get { return _examquestontype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[试题类型]长度不能大于50!");
                if (_examquestontype as object == null || !_examquestontype.Equals(value))
                {
                    _examquestontype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Appraise
        /// 属性描述：评价
        /// 字段信息：[Appraise],nvarchar
        /// </summary>
        [DisplayNameAttribute("评价")]
        public string Appraise
        {
            get { return _appraise; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[评价]长度不能大于1073741823!");
                if (_appraise as object == null || !_appraise.Equals(value))
                {
                    _appraise = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：scoure
        /// 属性描述：得分
        /// 字段信息：[scoure],int
        /// </summary>
        [DisplayNameAttribute("得分")]
        public double scoure
        {
            get { return _scoure; }
            set
            {			
                if (_scoure as object == null || !_scoure.Equals(value))
                {
                    _scoure = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Comment
        /// 属性描述：评语
        /// 字段信息：[Comment],nvarchar
        /// </summary>
        [DisplayNameAttribute("评语")]
        public string Comment
        {
            get { return _comment; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[评语]长度不能大于1073741823!");
                if (_comment as object == null || !_comment.Equals(value))
                {
                    _comment = value;
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
  
        /// <summary>
        /// 属性名称：E_ID
        /// 属性描述：考试ID
        /// 字段信息：[E_ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("考试ID")]
        public string E_ID
        {
            get { return _e_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[考试ID]长度不能大于50!");
                if (_e_id as object == null || !_e_id.Equals(value))
                {
                    _e_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：EP_ID
        /// 属性描述：试卷ID
        /// 字段信息：[EP_ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("试卷ID")]
        public string EP_ID
        {
            get { return _ep_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[试卷ID]长度不能大于50!");
                if (_ep_id as object == null || !_ep_id.Equals(value))
                {
                    _ep_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserID
        /// 属性描述：考试人员
        /// 字段信息：[UserID],nvarchar
        /// </summary>
        [DisplayNameAttribute("考试人员")]
        public string UserID
        {
            get { return _userid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[考试人员]长度不能大于50!");
                if (_userid as object == null || !_userid.Equals(value))
                {
                    _userid = value;
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
