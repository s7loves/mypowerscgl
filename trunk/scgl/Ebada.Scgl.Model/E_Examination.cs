/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:农电信息管理系统
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-8-24 16:12:39
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[E_Examination]业务实体类
    ///对应表名:E_Examination
    /// </summary>
    [Serializable]
    public class E_Examination
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _e_name=String.Empty; 
        private string _usertype=String.Empty; 
        private string _userids=String.Empty; 
        private DateTime _starttime=new DateTime(1900,1,1); 
        private DateTime _endtime=new DateTime(1900,1,1); 
        private string _ep_id=String.Empty; 
        private string _orgids=String.Empty; 
        private bool _showresult=false; 
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
                if(value==null)return;
                if( value.ToString().Length > 50)
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
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[考试名称]长度不能大于50!");
                if (_e_name as object == null || !_e_name.Equals(value))
                {
                    _e_name = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserType
        /// 属性描述：考生类型(单位,个人)
        /// 字段信息：[UserType],nvarchar
        /// </summary>
        [DisplayNameAttribute("考生类型(单位")]
        public string UserType
        {
            get { return _usertype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[考生类型(单位]长度不能大于50!");
                if (_usertype as object == null || !_usertype.Equals(value))
                {
                    _usertype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserIDS
        /// 属性描述：考生
        /// 字段信息：[UserIDS],nvarchar
        /// </summary>
        [DisplayNameAttribute("考生")]
        public string UserIDS
        {
            get { return _userids; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[考生]长度不能大于1073741823!");
                if (_userids as object == null || !_userids.Equals(value))
                {
                    _userids = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：StartTime
        /// 属性描述：开时时间
        /// 字段信息：[StartTime],datetime
        /// </summary>
        [DisplayNameAttribute("开时时间")]
        public DateTime StartTime
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
        public DateTime EndTime
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
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[使用试卷]长度不能大于50!");
                if (_ep_id as object == null || !_ep_id.Equals(value))
                {
                    _ep_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgIDS
        /// 属性描述：考生机构
        /// 字段信息：[OrgIDS],nvarchar
        /// </summary>
        [DisplayNameAttribute("考生机构")]
        public string OrgIDS
        {
            get { return _orgids; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[考生机构]长度不能大于1073741823!");
                if (_orgids as object == null || !_orgids.Equals(value))
                {
                    _orgids = value;
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
