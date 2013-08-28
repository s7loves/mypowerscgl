using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Threading;

namespace Itop.WebFrame
{
    #region 业务对象
    public class TurnE_Examination
    {

        #region Private 成员
        private string _id = String.Empty;
        private string _e_name = String.Empty;
        private string _starttime = String.Empty;
        private string _endtime = String.Empty;
        private string _ep_id = String.Empty;
        private bool _showresult = false;
        private string _time = String.Empty;
        #endregion


        #region Public 成员

        /// <summary>
        /// 属性名称：ID
        /// 属性描述：考试编号
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("考试编号")]
        public string ID
        {
            get { return _id; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[考试编号]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：E_Name
        /// 属性描述：考试名称
        /// 字段信息：[E_Name],nvarchar
        /// </summary>
        [DisplayNameAttribute("考试名称")]
        public string E_Name
        {
            get { return _e_name; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[考试名称]长度不能大于50!");
                if (_e_name as object == null || !_e_name.Equals(value))
                {
                    _e_name = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：StartTime
        /// 属性描述：开时时间
        /// 字段信息：[StartTime],datetime
        /// </summary>
        [DisplayNameAttribute("开时时间")]
        public string StartTime
        {
            get { return _starttime; }
            set
            {
                if (_starttime as object == null || !_starttime.Equals(value))
                {
                    _starttime = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：EndTime
        /// 属性描述：结束时间
        /// 字段信息：[EndTime],datetime
        /// </summary>
        [DisplayNameAttribute("结束时间")]
        public string EndTime
        {
            get { return _endtime; }
            set
            {
                if (_endtime as object == null || !_endtime.Equals(value))
                {
                    _endtime = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：EP_ID
        /// 属性描述：使用试卷
        /// 字段信息：[EP_ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("使用试卷")]
        public string EP_ID
        {
            get { return _ep_id; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[使用试卷]长度不能大于50!");
                if (_ep_id as object == null || !_ep_id.Equals(value))
                {
                    _ep_id = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：ShowResult
        /// 属性描述：显示成绩
        /// 字段信息：[ShowResult],bit
        /// </summary>
        [DisplayNameAttribute("显示成绩")]
        public bool ShowResult
        {
            get { return _showresult; }
            set
            {
                if (_showresult as object == null || !_showresult.Equals(value))
                {
                    _showresult = value;
                }
            }
        }


        /// <summary>
        /// 属性名称：BySCol1
        /// 属性描述：备用1
        /// 字段信息：[BySCol1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用1")]
        public string Time
        {
            get { return _time; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 200)
                    throw new Exception("[备用1]长度不能大于200!");
                if (_time as object == null || !_time.Equals(value))
                {
                    _time = value;
                }
            }
        }

        #endregion

        #region 方法

        #endregion
    }

    /// <summary>
    ///[E_QuestionBank]业务实体类
    ///对应表名:E_QuestionBank
    /// </summary>
    [Serializable]
    public class TurnE_QuestionBank
    {

        #region Private 成员
        private string _id = String.Empty;
        private string _type = String.Empty;
        private string _title = String.Empty;
        private string _option = String.Empty;
        private string _answer = String.Empty;
        private string _explain = String.Empty;
        private int _difficultylevel = 0;
        private string _professional = String.Empty;
        private int _sequence = 0;

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
                if (value == null) return;
                if (value.ToString().Length > 50)
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
                if (value == null) return;
                if (value.ToString().Length > 50)
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
                if (value == null) return;
                if (value.ToString().Length > 500)
                    throw new Exception("[题目]长度不能大于500!");
                if (_title as object == null || !_title.Equals(value))
                {
                    _title = value;
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
                if (value == null) return;
                if (value.ToString().Length > 1073741823)
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
                if (value == null) return;
                if (value.ToString().Length > 50)
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
                if (value == null) return;
                if (value.ToString().Length > 1073741823)
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
                if (value == null) return;
                if (value.ToString().Length > 50)
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

        #endregion

        #region 方法
        
        #endregion
    }	

    #endregion


    #region 其他辅助

    public class ResponseResult
    {

        public string Details { get; set; }

        public int Status { get; set; }

    }

    public class PdaAnswer
    {
        [DisplayNameAttribute("考试ID")]
        public string E_ID { get; set; }

        [DisplayNameAttribute("试卷ID")]
        public string EP_ID { get; set; }

        [DisplayNameAttribute("考试试题编号")]
        public string ExamQueston_ID { get; set; }

        [DisplayNameAttribute("答案")]
        public string Answer { get; set; }

        [DisplayNameAttribute("随机试题号")]
        public string RandomID { get; set; }

        [DisplayNameAttribute("试题类型")]
        public string ExamQuestonType { get; set; }

        [DisplayNameAttribute("考试人员")]
        public string UserID { get; set; }

    }

    public class PdaExamResult
    {
        [DisplayNameAttribute("考试分数")]
        public int Score { get; set; }

        [DisplayNameAttribute("是否通过")]
        public bool Pass { get; set; }

    }

    public class SysTime
    {
        [DisplayNameAttribute("系统时间")]
        public string  Time { get; set; }

    }

    public class SysRemainingTime
    {
        [DisplayNameAttribute("剩余时间")]
        public int  Seconds { get; set; }
    }

    #endregion


    public class Helper
    {
        /// <summary>
        /// 给定一个数，反回一个该数的随机顺序数组
        /// </summary>
        /// <param name="randomnum"></param>
        /// <returns></returns>
        public static int[] OrderINT(int randomnum)
        {
            Random rand = new Random();
            Dictionary<int, int> intdic = new Dictionary<int, int>();
            for (int i = 0; i < randomnum; i++)
            {
                bool has = false;
                while (!has)
                {
                    int tempint = rand.Next(randomnum);
                    if (!intdic.ContainsKey(tempint))
                    {
                        intdic.Add(tempint, tempint);
                        has = true;
                    }
                }

            }
            int[] order = new int[ randomnum ];
            int index = 0;
            foreach (int key in intdic.Keys)
            {
                order[index] = key;
                index++;
            }
            return order;
        }
    }
   

}