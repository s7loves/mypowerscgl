/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-7-5 13:32:42
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[bdjl_ksjl]业务实体类
    ///对应表名:bdjl_ksjl
    /// </summary>
    [Serializable]
    public class bdjl_ksjl
    {
        
        #region Private 成员
        private string _id=Newid();
        private DateTime _ksrq = new DateTime(1900, 1, 1); 
        private int _sequence=0; 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _ksxm=String.Empty; 
        private string _username=String.Empty; 
        private string _postname=String.Empty; 
        private string _postage=String.Empty; 
        private DateTime _lastexamtime=new DateTime(1900,1,1); 
        private string _examstarttime=String.Empty; 
        private string _examendtime=String.Empty; 
        private string _totalevaluate=String.Empty; 
        private string _kswyhjl=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty; 
        private string _c4=String.Empty; 
        private string _c5=String.Empty; 
        private string _bkrqz=String.Empty; 
        private string _kswyhzr=String.Empty; 
        private string _wy=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：主键
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("主键")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[主键]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Ksrq
        /// 属性描述：考试日期
        /// 字段信息：[Ksrq],nvarchar
        /// </summary>
        [DisplayNameAttribute("考试日期")]
        public DateTime Ksrq
        {
            get { return _ksrq; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[考试日期]长度不能大于50!");
                if (_ksrq as object == null || !_ksrq.Equals(value))
                {
                    _ksrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Sequence
        /// 属性描述：序号
        /// 字段信息：[Sequence],nvarchar
        /// </summary>
        [DisplayNameAttribute("序号")]
        public int Sequence
        {
            get { return _sequence; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[序号]长度不能大于50!");
                if (_sequence as object == null || !_sequence.Equals(value))
                {
                    _sequence = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Orgcode
        /// 属性描述：供电所代码
        /// 字段信息：[Orgcode],nvarchar
        /// </summary>
        [DisplayNameAttribute("供电所代码")]
        public string Orgcode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[供电所代码]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Orgname
        /// 属性描述：供电所名称
        /// 字段信息：[Orgname],nvarchar
        /// </summary>
        [DisplayNameAttribute("供电所名称")]
        public string Orgname
        {
            get { return _orgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[供电所名称]长度不能大于50!");
                if (_orgname as object == null || !_orgname.Equals(value))
                {
                    _orgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Ksxm
        /// 属性描述：考试项目
        /// 字段信息：[Ksxm],nvarchar
        /// </summary>
        [DisplayNameAttribute("考试项目")]
        public string Ksxm
        {
            get { return _ksxm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[考试项目]长度不能大于50!");
                if (_ksxm as object == null || !_ksxm.Equals(value))
                {
                    _ksxm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserName
        /// 属性描述：姓名
        /// 字段信息：[UserName],nvarchar
        /// </summary>
        [DisplayNameAttribute("姓名")]
        public string UserName
        {
            get { return _username; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[姓名]长度不能大于50!");
                if (_username as object == null || !_username.Equals(value))
                {
                    _username = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：PostName
        /// 属性描述：职称
        /// 字段信息：[PostName],nvarchar
        /// </summary>
        [DisplayNameAttribute("职称")]
        public string PostName
        {
            get { return _postname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[职称]长度不能大于50!");
                if (_postname as object == null || !_postname.Equals(value))
                {
                    _postname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：PostAge
        /// 属性描述：本职位工龄
        /// 字段信息：[PostAge],nvarchar
        /// </summary>
        [DisplayNameAttribute("本职位工龄")]
        public string PostAge
        {
            get { return _postage; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[本职位工龄]长度不能大于50!");
                if (_postage as object == null || !_postage.Equals(value))
                {
                    _postage = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LastExamTime
        /// 属性描述：最近一次考试日期
        /// 字段信息：[LastExamTime],datetime
        /// </summary>
        [DisplayNameAttribute("最近一次考试日期")]
        public DateTime LastExamTime
        {
            get { return _lastexamtime; }
            set
            {			
                if (_lastexamtime as object == null || !_lastexamtime.Equals(value))
                {
                    _lastexamtime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ExamStartTime
        /// 属性描述：考试开始时间
        /// 字段信息：[ExamStartTime],datetime
        /// </summary>
        [DisplayNameAttribute("考试开始时间")]
        public string ExamStartTime
        {
            get { return _examstarttime; }
            set
            {			
                if (_examstarttime as object == null || !_examstarttime.Equals(value))
                {
                    _examstarttime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ExamEndTime
        /// 属性描述：考试结束时间
        /// 字段信息：[ExamEndTime],datetime
        /// </summary>
        [DisplayNameAttribute("考试结束时间")]
        public string ExamEndTime
        {
            get { return _examendtime; }
            set
            {			
                if (_examendtime as object == null || !_examendtime.Equals(value))
                {
                    _examendtime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TotalEvaluate
        /// 属性描述：总评价
        /// 字段信息：[TotalEvaluate],nvarchar
        /// </summary>
        [DisplayNameAttribute("总评价")]
        public string TotalEvaluate
        {
            get { return _totalevaluate; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[总评价]长度不能大于500!");
                if (_totalevaluate as object == null || !_totalevaluate.Equals(value))
                {
                    _totalevaluate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Kswyhjl
        /// 属性描述：考试委员会结论
        /// 字段信息：[Kswyhjl],nvarchar
        /// </summary>
        [DisplayNameAttribute("考试委员会结论")]
        public string Kswyhjl
        {
            get { return _kswyhjl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[考试委员会结论]长度不能大于50!");
                if (_kswyhjl as object == null || !_kswyhjl.Equals(value))
                {
                    _kswyhjl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c1
        /// 属性描述：备用字段1
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段1")]
        public string c1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段1]长度不能大于500!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c2
        /// 属性描述：备用字段2
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段2")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段2]长度不能大于500!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c3
        /// 属性描述：备用字段3
        /// 字段信息：[c3],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段3")]
        public string c3
        {
            get { return _c3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段3]长度不能大于500!");
                if (_c3 as object == null || !_c3.Equals(value))
                {
                    _c3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c4
        /// 属性描述：备用字段4
        /// 字段信息：[c4],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段4")]
        public string c4
        {
            get { return _c4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段4]长度不能大于500!");
                if (_c4 as object == null || !_c4.Equals(value))
                {
                    _c4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c5
        /// 属性描述：备用字段5
        /// 字段信息：[c5],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段5")]
        public string c5
        {
            get { return _c5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段5]长度不能大于500!");
                if (_c5 as object == null || !_c5.Equals(value))
                {
                    _c5 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Bkrqz
        /// 属性描述：被考人签字
        /// 字段信息：[Bkrqz],nvarchar
        /// </summary>
        [DisplayNameAttribute("被考人签字")]
        public string Bkrqz
        {
            get { return _bkrqz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[被考人签字]长度不能大于50!");
                if (_bkrqz as object == null || !_bkrqz.Equals(value))
                {
                    _bkrqz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Kswyhzr
        /// 属性描述：考试委员会主任(签章写明职称)
        /// 字段信息：[Kswyhzr],nvarchar
        /// </summary>
        [DisplayNameAttribute("考试委员会主任(签章写明职称)")]
        public string Kswyhzr
        {
            get { return _kswyhzr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[考试委员会主任(签章写明职称)]长度不能大于50!");
                if (_kswyhzr as object == null || !_kswyhzr.Equals(value))
                {
                    _kswyhzr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Wy
        /// 属性描述：委员
        /// 字段信息：[Wy],nvarchar
        /// </summary>
        [DisplayNameAttribute("委员")]
        public string Wy
        {
            get { return _wy; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[委员]长度不能大于50!");
                if (_wy as object == null || !_wy.Equals(value))
                {
                    _wy = value;
                }
            }			 
        }
  
        #endregion 
  
        #region 方法
        public static string Newid(){
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        public string CreateID(){
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        #endregion		
    }	
}
