/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-26 20:53:58
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_05jcky]业务实体类
    ///对应表名:PJ_05jcky
    /// </summary>
    [Serializable]
    public class PJ_05jcky
    {
        
        #region Private 成员
        private string _jckyid=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _lineid=String.Empty; 
        private string _gtid=String.Empty; 
        private string _kywz=String.Empty; 
        private string _kygh=String.Empty; 
        private string _kymc=String.Empty; 
        private string _ssdw=String.Empty; 
        private string _jb=String.Empty; 
        private decimal _gdjl=0; 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1);   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：jckyID
        /// 属性描述：记录ID
        /// 字段信息：[jckyID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("记录ID")]
        public string jckyID
        {
            get { return _jckyid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[记录ID]长度不能大于50!");
                if (_jckyid as object == null || !_jckyid.Equals(value))
                {
                    _jckyid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：供电所代码
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("供电所代码")]
        public string OrgCode
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
        /// 属性名称：OrgName
        /// 属性描述：供电所名称
        /// 字段信息：[OrgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("供电所名称")]
        public string OrgName
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
        /// 属性名称：LineID
        /// 属性描述：线路ID
        /// 字段信息：[LineID],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路ID")]
        public string LineID
        {
            get { return _lineid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路ID]长度不能大于50!");
                if (_lineid as object == null || !_lineid.Equals(value))
                {
                    _lineid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtID
        /// 属性描述：杆塔ID
        /// 字段信息：[gtID],nvarchar
        /// </summary>
        [DisplayNameAttribute("杆塔ID")]
        public string gtID
        {
            get { return _gtid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[杆塔ID]长度不能大于50!");
                if (_gtid as object == null || !_gtid.Equals(value))
                {
                    _gtid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kywz
        /// 属性描述：交叉跨越位置
        /// 字段信息：[kywz],nvarchar
        /// </summary>
        [DisplayNameAttribute("交叉跨越位置")]
        public string kywz
        {
            get { return _kywz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[交叉跨越位置]长度不能大于50!");
                if (_kywz as object == null || !_kywz.Equals(value))
                {
                    _kywz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kygh
        /// 属性描述：跨越杆号
        /// 字段信息：[kygh],nvarchar
        /// </summary>
        [DisplayNameAttribute("跨越杆号")]
        public string kygh
        {
            get { return _kygh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[跨越杆号]长度不能大于50!");
                if (_kygh as object == null || !_kygh.Equals(value))
                {
                    _kygh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kymc
        /// 属性描述：被跨越物名称
        /// 字段信息：[kymc],nvarchar
        /// </summary>
        [DisplayNameAttribute("被跨越物名称")]
        public string kymc
        {
            get { return _kymc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[被跨越物名称]长度不能大于50!");
                if (_kymc as object == null || !_kymc.Equals(value))
                {
                    _kymc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ssdw
        /// 属性描述：所属单位
        /// 字段信息：[ssdw],nvarchar
        /// </summary>
        [DisplayNameAttribute("所属单位")]
        public string ssdw
        {
            get { return _ssdw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[所属单位]长度不能大于50!");
                if (_ssdw as object == null || !_ssdw.Equals(value))
                {
                    _ssdw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jb
        /// 属性描述：级别
        /// 字段信息：[jb],nvarchar
        /// </summary>
        [DisplayNameAttribute("级别")]
        public string jb
        {
            get { return _jb; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[级别]长度不能大于50!");
                if (_jb as object == null || !_jb.Equals(value))
                {
                    _jb = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gdjl
        /// 属性描述：规定距离不小于
        /// 字段信息：[gdjl],decimal
        /// </summary>
        [DisplayNameAttribute("规定距离不小于")]
        public decimal gdjl
        {
            get { return _gdjl; }
            set
            {			
                if (_gdjl as object == null || !_gdjl.Equals(value))
                {
                    _gdjl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateMan
        /// 属性描述：创建人
        /// 字段信息：[CreateMan],nvarchar
        /// </summary>
        [DisplayNameAttribute("创建人")]
        public string CreateMan
        {
            get { return _createman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[创建人]长度不能大于10!");
                if (_createman as object == null || !_createman.Equals(value))
                {
                    _createman = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateDate
        /// 属性描述：创建日期
        /// 字段信息：[CreateDate],datetime
        /// </summary>
        [DisplayNameAttribute("创建日期")]
        public DateTime CreateDate
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
