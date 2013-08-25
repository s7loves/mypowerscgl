/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ftpa辅助系统
模块:系统平台
Ftpa.com 版权所有
生成者：Rabbit
生成时间:2013-8-24 16:30:08
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Itop.Frame.Model
{
    /// <summary>
    ///[E_QuestionBank]业务实体类
    ///对应表名:E_QuestionBank
    /// </summary>
    [Serializable]
    public class E_QuestionBank
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _type=String.Empty; 
        private string _title=String.Empty; 
        private string _querytext=String.Empty; 
        private string _option=String.Empty; 
        private string _answer=String.Empty; 
        private string _explain=String.Empty; 
        private int _difficultylevel=0; 
        private int _scorenum=0; 
        private string _professional=String.Empty; 
        private int _sequence=0; 
        private DateTime _intime=new DateTime(1900,1,1); 
        private string _inuser=String.Empty; 
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
        /// 属性描述：试题ID
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("试题ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[试题ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Type
        /// 属性描述：题型
        /// 字段信息：[Type],nvarchar
        /// </summary>
        [DisplayNameAttribute("题型")]
        public string Type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[题型]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Title
        /// 属性描述：题目
        /// 字段信息：[Title],nvarchar
        /// </summary>
        [DisplayNameAttribute("题目")]
        public string Title
        {
            get { return _title; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[题目]长度不能大于500!");
                if (_title as object == null || !_title.Equals(value))
                {
                    _title = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：QueryText
        /// 属性描述：查询
        /// 字段信息：[QueryText],nvarchar
        /// </summary>
        [DisplayNameAttribute("查询")]
        public string QueryText
        {
            get { return _querytext; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[查询]长度不能大于1073741823!");
                if (_querytext as object == null || !_querytext.Equals(value))
                {
                    _querytext = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Option
        /// 属性描述：选项
        /// 字段信息：[Option],nvarchar
        /// </summary>
        [DisplayNameAttribute("选项")]
        public string Option
        {
            get { return _option; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[选项]长度不能大于1073741823!");
                if (_option as object == null || !_option.Equals(value))
                {
                    _option = value;
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
        /// 属性名称：Explain
        /// 属性描述：解释
        /// 字段信息：[Explain],nvarchar
        /// </summary>
        [DisplayNameAttribute("解释")]
        public string Explain
        {
            get { return _explain; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[解释]长度不能大于1073741823!");
                if (_explain as object == null || !_explain.Equals(value))
                {
                    _explain = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：DifficultyLevel
        /// 属性描述：难度级别
        /// 字段信息：[DifficultyLevel],int
        /// </summary>
        [DisplayNameAttribute("难度级别")]
        public int DifficultyLevel
        {
            get { return _difficultylevel; }
            set
            {			
                if (_difficultylevel as object == null || !_difficultylevel.Equals(value))
                {
                    _difficultylevel = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ScoreNum
        /// 属性描述：分数
        /// 字段信息：[ScoreNum],int
        /// </summary>
        [DisplayNameAttribute("分数")]
        public int ScoreNum
        {
            get { return _scorenum; }
            set
            {			
                if (_scorenum as object == null || !_scorenum.Equals(value))
                {
                    _scorenum = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Professional
        /// 属性描述：专业
        /// 字段信息：[Professional],nvarchar
        /// </summary>
        [DisplayNameAttribute("专业")]
        public string Professional
        {
            get { return _professional; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[专业]长度不能大于50!");
                if (_professional as object == null || !_professional.Equals(value))
                {
                    _professional = value;
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
        /// 属性名称：InTime
        /// 属性描述：录入时间
        /// 字段信息：[InTime],datetime
        /// </summary>
        [DisplayNameAttribute("录入时间")]
        public DateTime InTime
        {
            get { return _intime; }
            set
            {			
                if (_intime as object == null || !_intime.Equals(value))
                {
                    _intime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：InUser
        /// 属性描述：录入人
        /// 字段信息：[InUser],nvarchar
        /// </summary>
        [DisplayNameAttribute("录入人")]
        public string InUser
        {
            get { return _inuser; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[录入人]长度不能大于50!");
                if (_inuser as object == null || !_inuser.Equals(value))
                {
                    _inuser = value;
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
