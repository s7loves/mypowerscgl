/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-3-11 9:59:45
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sd_tsqy]业务实体类
    ///对应表名:sd_tsqy
    /// </summary>
    [Serializable]
    public class sd_tsqy
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _zldm=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _lineid=String.Empty; 
        private string _gtbegin=String.Empty; 
        private string _gtend=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1); 
        private string _createman=String.Empty; 
        private string _a1=String.Empty; 
        private string _a2=String.Empty; 
        private string _a3=String.Empty; 
        private string _a4=String.Empty; 
        private string _a5=String.Empty; 
        private string _a6=String.Empty; 
        private string _a7=String.Empty; 
        private string _a8=String.Empty; 
        private string _a9=String.Empty; 
        private string _a10=String.Empty; 
        private string _a11=String.Empty; 
        private string _a12=String.Empty; 
        private string _a13=String.Empty; 
        private string _a14=String.Empty; 
        private string _a15=String.Empty; 
        private string _a16=String.Empty; 
        private string _a17=String.Empty; 
        private string _a18=String.Empty; 
        private string _a19=String.Empty; 
        private string _a20=String.Empty; 
        private string _a21=String.Empty; 
        private string _a22=String.Empty; 
        private string _a23=String.Empty; 
        private string _a24=String.Empty; 
        private string _a25=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zldm
        /// 属性描述：种类代码
        /// 字段信息：[zldm],nvarchar
        /// </summary>
        [DisplayNameAttribute("种类代码")]
        public string zldm
        {
            get { return _zldm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[种类代码]长度不能大于50!");
                if (_zldm as object == null || !_zldm.Equals(value))
                {
                    _zldm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("OrgCode")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[OrgCode]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineID
        /// 属性描述：
        /// 字段信息：[LineID],nvarchar
        /// </summary>
        [DisplayNameAttribute("LineID")]
        public string LineID
        {
            get { return _lineid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[LineID]长度不能大于50!");
                if (_lineid as object == null || !_lineid.Equals(value))
                {
                    _lineid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtbegin
        /// 属性描述：
        /// 字段信息：[gtbegin],nvarchar
        /// </summary>
        [DisplayNameAttribute("gtbegin")]
        public string gtbegin
        {
            get { return _gtbegin; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[gtbegin]长度不能大于50!");
                if (_gtbegin as object == null || !_gtbegin.Equals(value))
                {
                    _gtbegin = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtend
        /// 属性描述：
        /// 字段信息：[gtend],nvarchar
        /// </summary>
        [DisplayNameAttribute("gtend")]
        public string gtend
        {
            get { return _gtend; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[gtend]长度不能大于50!");
                if (_gtend as object == null || !_gtend.Equals(value))
                {
                    _gtend = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：createdate
        /// 属性描述：
        /// 字段信息：[createdate],datetime
        /// </summary>
        [DisplayNameAttribute("createdate")]
        public DateTime createdate
        {
            get { return _createdate; }
            set
            {			
                if (_createdate as object == null || !_createdate.Equals(value))
                {
                    _createdate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：createman
        /// 属性描述：
        /// 字段信息：[createman],nvarchar
        /// </summary>
        [DisplayNameAttribute("createman")]
        public string createman
        {
            get { return _createman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[createman]长度不能大于50!");
                if (_createman as object == null || !_createman.Equals(value))
                {
                    _createman = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a1
        /// 属性描述：
        /// 字段信息：[a1],nvarchar
        /// </summary>
        [DisplayNameAttribute("a1")]
        public string a1
        {
            get { return _a1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a1]长度不能大于500!");
                if (_a1 as object == null || !_a1.Equals(value))
                {
                    _a1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a2
        /// 属性描述：
        /// 字段信息：[a2],nvarchar
        /// </summary>
        [DisplayNameAttribute("a2")]
        public string a2
        {
            get { return _a2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a2]长度不能大于500!");
                if (_a2 as object == null || !_a2.Equals(value))
                {
                    _a2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a3
        /// 属性描述：
        /// 字段信息：[a3],nvarchar
        /// </summary>
        [DisplayNameAttribute("a3")]
        public string a3
        {
            get { return _a3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a3]长度不能大于500!");
                if (_a3 as object == null || !_a3.Equals(value))
                {
                    _a3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a4
        /// 属性描述：
        /// 字段信息：[a4],nvarchar
        /// </summary>
        [DisplayNameAttribute("a4")]
        public string a4
        {
            get { return _a4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a4]长度不能大于500!");
                if (_a4 as object == null || !_a4.Equals(value))
                {
                    _a4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a5
        /// 属性描述：
        /// 字段信息：[a5],nvarchar
        /// </summary>
        [DisplayNameAttribute("a5")]
        public string a5
        {
            get { return _a5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a5]长度不能大于500!");
                if (_a5 as object == null || !_a5.Equals(value))
                {
                    _a5 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a6
        /// 属性描述：
        /// 字段信息：[a6],nvarchar
        /// </summary>
        [DisplayNameAttribute("a6")]
        public string a6
        {
            get { return _a6; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a6]长度不能大于500!");
                if (_a6 as object == null || !_a6.Equals(value))
                {
                    _a6 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a7
        /// 属性描述：
        /// 字段信息：[a7],nvarchar
        /// </summary>
        [DisplayNameAttribute("a7")]
        public string a7
        {
            get { return _a7; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a7]长度不能大于500!");
                if (_a7 as object == null || !_a7.Equals(value))
                {
                    _a7 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a8
        /// 属性描述：
        /// 字段信息：[a8],nvarchar
        /// </summary>
        [DisplayNameAttribute("a8")]
        public string a8
        {
            get { return _a8; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a8]长度不能大于500!");
                if (_a8 as object == null || !_a8.Equals(value))
                {
                    _a8 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a9
        /// 属性描述：
        /// 字段信息：[a9],nvarchar
        /// </summary>
        [DisplayNameAttribute("a9")]
        public string a9
        {
            get { return _a9; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a9]长度不能大于500!");
                if (_a9 as object == null || !_a9.Equals(value))
                {
                    _a9 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a10
        /// 属性描述：
        /// 字段信息：[a10],nvarchar
        /// </summary>
        [DisplayNameAttribute("a10")]
        public string a10
        {
            get { return _a10; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a10]长度不能大于500!");
                if (_a10 as object == null || !_a10.Equals(value))
                {
                    _a10 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a11
        /// 属性描述：
        /// 字段信息：[a11],nvarchar
        /// </summary>
        [DisplayNameAttribute("a11")]
        public string a11
        {
            get { return _a11; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a11]长度不能大于500!");
                if (_a11 as object == null || !_a11.Equals(value))
                {
                    _a11 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a12
        /// 属性描述：
        /// 字段信息：[a12],nvarchar
        /// </summary>
        [DisplayNameAttribute("a12")]
        public string a12
        {
            get { return _a12; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a12]长度不能大于500!");
                if (_a12 as object == null || !_a12.Equals(value))
                {
                    _a12 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a13
        /// 属性描述：
        /// 字段信息：[a13],nvarchar
        /// </summary>
        [DisplayNameAttribute("a13")]
        public string a13
        {
            get { return _a13; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a13]长度不能大于500!");
                if (_a13 as object == null || !_a13.Equals(value))
                {
                    _a13 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a14
        /// 属性描述：
        /// 字段信息：[a14],nvarchar
        /// </summary>
        [DisplayNameAttribute("a14")]
        public string a14
        {
            get { return _a14; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a14]长度不能大于500!");
                if (_a14 as object == null || !_a14.Equals(value))
                {
                    _a14 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a15
        /// 属性描述：
        /// 字段信息：[a15],nvarchar
        /// </summary>
        [DisplayNameAttribute("a15")]
        public string a15
        {
            get { return _a15; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a15]长度不能大于500!");
                if (_a15 as object == null || !_a15.Equals(value))
                {
                    _a15 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a16
        /// 属性描述：
        /// 字段信息：[a16],nvarchar
        /// </summary>
        [DisplayNameAttribute("a16")]
        public string a16
        {
            get { return _a16; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a16]长度不能大于500!");
                if (_a16 as object == null || !_a16.Equals(value))
                {
                    _a16 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a17
        /// 属性描述：
        /// 字段信息：[a17],nvarchar
        /// </summary>
        [DisplayNameAttribute("a17")]
        public string a17
        {
            get { return _a17; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a17]长度不能大于500!");
                if (_a17 as object == null || !_a17.Equals(value))
                {
                    _a17 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a18
        /// 属性描述：
        /// 字段信息：[a18],nvarchar
        /// </summary>
        [DisplayNameAttribute("a18")]
        public string a18
        {
            get { return _a18; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a18]长度不能大于500!");
                if (_a18 as object == null || !_a18.Equals(value))
                {
                    _a18 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a19
        /// 属性描述：
        /// 字段信息：[a19],nvarchar
        /// </summary>
        [DisplayNameAttribute("a19")]
        public string a19
        {
            get { return _a19; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a19]长度不能大于500!");
                if (_a19 as object == null || !_a19.Equals(value))
                {
                    _a19 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a20
        /// 属性描述：
        /// 字段信息：[a20],nvarchar
        /// </summary>
        [DisplayNameAttribute("a20")]
        public string a20
        {
            get { return _a20; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a20]长度不能大于500!");
                if (_a20 as object == null || !_a20.Equals(value))
                {
                    _a20 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a21
        /// 属性描述：
        /// 字段信息：[a21],nvarchar
        /// </summary>
        [DisplayNameAttribute("a21")]
        public string a21
        {
            get { return _a21; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a21]长度不能大于500!");
                if (_a21 as object == null || !_a21.Equals(value))
                {
                    _a21 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a22
        /// 属性描述：
        /// 字段信息：[a22],nvarchar
        /// </summary>
        [DisplayNameAttribute("a22")]
        public string a22
        {
            get { return _a22; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a22]长度不能大于500!");
                if (_a22 as object == null || !_a22.Equals(value))
                {
                    _a22 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a23
        /// 属性描述：
        /// 字段信息：[a23],nvarchar
        /// </summary>
        [DisplayNameAttribute("a23")]
        public string a23
        {
            get { return _a23; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a23]长度不能大于500!");
                if (_a23 as object == null || !_a23.Equals(value))
                {
                    _a23 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a24
        /// 属性描述：
        /// 字段信息：[a24],nvarchar
        /// </summary>
        [DisplayNameAttribute("a24")]
        public string a24
        {
            get { return _a24; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a24]长度不能大于500!");
                if (_a24 as object == null || !_a24.Equals(value))
                {
                    _a24 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a25
        /// 属性描述：
        /// 字段信息：[a25],nvarchar
        /// </summary>
        [DisplayNameAttribute("a25")]
        public string a25
        {
            get { return _a25; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[a25]长度不能大于500!");
                if (_a25 as object == null || !_a25.Equals(value))
                {
                    _a25 = value;
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
