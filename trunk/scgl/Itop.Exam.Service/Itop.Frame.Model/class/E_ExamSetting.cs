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
    ///[E_ExamSetting]业务实体类
    ///对应表名:E_ExamSetting
    /// </summary>
    [Serializable]
    public class E_ExamSetting
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _settingname=String.Empty; 
        private string _eqbid=String.Empty; 
        private bool _isused=false; 
        private int _selectnum=0; 
        private int _selectlevel=0;
        private double _selectscore = 0; 
        private int _muselectnum=0; 
        private int _muselectlevel=0;
        private double _muselectscore = 0; 
        private int _judgenum=0; 
        private int _judgelevel=0;
        private double _judgescore = 0; 
        private int _waittime=0;
        private double _passscore = 0;
        private double _totalscore = 0; 
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
        /// 属性描述：设置ID
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("设置ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设置ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SettingName
        /// 属性描述：设置名称
        /// 字段信息：[SettingName],nvarchar
        /// </summary>
        [DisplayNameAttribute("设置名称")]
        public string SettingName
        {
            get { return _settingname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设置名称]长度不能大于50!");
                if (_settingname as object == null || !_settingname.Equals(value))
                {
                    _settingname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：EQBID
        /// 属性描述：题库
        /// 字段信息：[EQBID],nvarchar
        /// </summary>
        [DisplayNameAttribute("题库")]
        public string EQBID
        {
            get { return _eqbid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[题库]长度不能大于50!");
                if (_eqbid as object == null || !_eqbid.Equals(value))
                {
                    _eqbid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：IsUsed
        /// 属性描述：是否启用
        /// 字段信息：[IsUsed],bit
        /// </summary>
        [DisplayNameAttribute("是否启用")]
        public bool IsUsed
        {
            get { return _isused; }
            set
            {			
                if (_isused as object == null || !_isused.Equals(value))
                {
                    _isused = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SelectNUM
        /// 属性描述：单选题数量
        /// 字段信息：[SelectNUM],int
        /// </summary>
        [DisplayNameAttribute("单选题数量")]
        public int SelectNUM
        {
            get { return _selectnum; }
            set
            {			
                if (_selectnum as object == null || !_selectnum.Equals(value))
                {
                    _selectnum = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SelectLevel
        /// 属性描述：单选难度
        /// 字段信息：[SelectLevel],int
        /// </summary>
        [DisplayNameAttribute("单选难度")]
        public int SelectLevel
        {
            get { return _selectlevel; }
            set
            {			
                if (_selectlevel as object == null || !_selectlevel.Equals(value))
                {
                    _selectlevel = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SelectScore
        /// 属性描述：单选每题分数
        /// 字段信息：[SelectScore],int
        /// </summary>
        [DisplayNameAttribute("单选每题分数")]
        public double SelectScore
        {
            get { return _selectscore; }
            set
            {			
                if (_selectscore as object == null || !_selectscore.Equals(value))
                {
                    _selectscore = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：MuSelectNUM
        /// 属性描述：多选题数量
        /// 字段信息：[MuSelectNUM],int
        /// </summary>
        [DisplayNameAttribute("多选题数量")]
        public int MuSelectNUM
        {
            get { return _muselectnum; }
            set
            {			
                if (_muselectnum as object == null || !_muselectnum.Equals(value))
                {
                    _muselectnum = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：MuSelectLevel
        /// 属性描述：多选难度
        /// 字段信息：[MuSelectLevel],int
        /// </summary>
        [DisplayNameAttribute("多选难度")]
        public int MuSelectLevel
        {
            get { return _muselectlevel; }
            set
            {			
                if (_muselectlevel as object == null || !_muselectlevel.Equals(value))
                {
                    _muselectlevel = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：MuSelectScore
        /// 属性描述：多选每题分数
        /// 字段信息：[MuSelectScore],int
        /// </summary>
        [DisplayNameAttribute("多选每题分数")]
        public double MuSelectScore
        {
            get { return _muselectscore; }
            set
            {			
                if (_muselectscore as object == null || !_muselectscore.Equals(value))
                {
                    _muselectscore = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：JudgeNUM
        /// 属性描述：判断题数
        /// 字段信息：[JudgeNUM],int
        /// </summary>
        [DisplayNameAttribute("判断题数")]
        public int JudgeNUM
        {
            get { return _judgenum; }
            set
            {			
                if (_judgenum as object == null || !_judgenum.Equals(value))
                {
                    _judgenum = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：JudgeLevel
        /// 属性描述：判断难度
        /// 字段信息：[JudgeLevel],int
        /// </summary>
        [DisplayNameAttribute("判断难度")]
        public int JudgeLevel
        {
            get { return _judgelevel; }
            set
            {			
                if (_judgelevel as object == null || !_judgelevel.Equals(value))
                {
                    _judgelevel = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：JudgeScore
        /// 属性描述：判断每题分数
        /// 字段信息：[JudgeScore],int
        /// </summary>
        [DisplayNameAttribute("判断每题分数")]
        public double JudgeScore
        {
            get { return _judgescore; }
            set
            {			
                if (_judgescore as object == null || !_judgescore.Equals(value))
                {
                    _judgescore = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WaitTime
        /// 属性描述：答题时间
        /// 字段信息：[WaitTime],int
        /// </summary>
        [DisplayNameAttribute("答题时间")]
        public int WaitTime
        {
            get { return _waittime; }
            set
            {			
                if (_waittime as object == null || !_waittime.Equals(value))
                {
                    _waittime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：PassScore
        /// 属性描述：合格成绩
        /// 字段信息：[PassScore],int
        /// </summary>
        [DisplayNameAttribute("合格成绩")]
        public double PassScore
        {
            get { return _passscore; }
            set
            {			
                if (_passscore as object == null || !_passscore.Equals(value))
                {
                    _passscore = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TotalScore
        /// 属性描述：总分
        /// 字段信息：[TotalScore],int
        /// </summary>
        [DisplayNameAttribute("总分")]
        public double TotalScore
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
