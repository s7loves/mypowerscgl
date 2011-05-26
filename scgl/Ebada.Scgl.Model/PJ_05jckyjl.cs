/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-26 20:53:59
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_05jckyjl]业务实体类
    ///对应表名:PJ_05jckyjl
    /// </summary>
    [Serializable]
    public class PJ_05jckyjl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _jckyid=String.Empty; 
        private DateTime _clrq=new DateTime(1900,1,1); 
        private decimal _scz=0; 
        private string _qw=String.Empty; 
        private string _clrqz=String.Empty; 
        private string _jr=String.Empty; 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1); 
        private string _gzrjid=String.Empty;   
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
                if( value.ToString().Length > 50)
                throw new Exception("[记录ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jckyID
        /// 属性描述：交叉跨越ID
        /// 字段信息：[jckyID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("交叉跨越ID")]
        public string jckyID
        {
            get { return _jckyid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[交叉跨越ID]长度不能大于50!");
                if (_jckyid as object == null || !_jckyid.Equals(value))
                {
                    _jckyid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：clrq
        /// 属性描述：测量日期
        /// 字段信息：[clrq],datetime
        /// </summary>
        [DisplayNameAttribute("测量日期")]
        public DateTime clrq
        {
            get { return _clrq; }
            set
            {			
                if (_clrq as object == null || !_clrq.Equals(value))
                {
                    _clrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：scz
        /// 属性描述：实测值
        /// 字段信息：[scz],decimal
        /// </summary>
        [DisplayNameAttribute("实测值")]
        public decimal scz
        {
            get { return _scz; }
            set
            {			
                if (_scz as object == null || !_scz.Equals(value))
                {
                    _scz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qw
        /// 属性描述：气温
        /// 字段信息：[qw],nvarchar
        /// </summary>
        [DisplayNameAttribute("气温")]
        public string qw
        {
            get { return _qw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[气温]长度不能大于50!");
                if (_qw as object == null || !_qw.Equals(value))
                {
                    _qw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：clrqz
        /// 属性描述：测量人签字
        /// 字段信息：[clrqz],nvarchar
        /// </summary>
        [DisplayNameAttribute("测量人签字")]
        public string clrqz
        {
            get { return _clrqz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[测量人签字]长度不能大于50!");
                if (_clrqz as object == null || !_clrqz.Equals(value))
                {
                    _clrqz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jr
        /// 属性描述：结论
        /// 字段信息：[jr],nvarchar
        /// </summary>
        [DisplayNameAttribute("结论")]
        public string jr
        {
            get { return _jr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[结论]长度不能大于50!");
                if (_jr as object == null || !_jr.Equals(value))
                {
                    _jr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateMan
        /// 属性描述：填写人
        /// 字段信息：[CreateMan],nvarchar
        /// </summary>
        [DisplayNameAttribute("填写人")]
        public string CreateMan
        {
            get { return _createman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[填写人]长度不能大于10!");
                if (_createman as object == null || !_createman.Equals(value))
                {
                    _createman = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateDate
        /// 属性描述：填写日期
        /// 字段信息：[CreateDate],datetime
        /// </summary>
        [DisplayNameAttribute("填写日期")]
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
  
        /// <summary>
        /// 属性名称：gzrjID
        /// 属性描述：gzrjID
        /// 字段信息：[gzrjID],nvarchar
        /// </summary>
        [DisplayNameAttribute("gzrjID")]
        public string gzrjID
        {
            get { return _gzrjid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[gzrjID]长度不能大于50!");
                if (_gzrjid as object == null || !_gzrjid.Equals(value))
                {
                    _gzrjid = value;
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
