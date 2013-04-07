/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-4-7 10:59:30
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[bdjl_yxgzjlb]业务实体类
    ///对应表名:bdjl_yxgzjlb
    /// </summary>
    [Serializable]
    public class bdjl_yxgzjlb
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _jbfzr=String.Empty; 
        private string _jbry=String.Empty; 
        private string _jbfzry=String.Empty; 
        private string _jbryy=String.Empty; 
        private string _rq=String.Empty; 
        private string _tq=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：ID
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
        /// 属性名称：OrgCode
        /// 属性描述：单位代码
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位代码")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位代码]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jbfzr
        /// 属性描述：交班负责人
        /// 字段信息：[jbfzr],nvarchar
        /// </summary>
        [DisplayNameAttribute("交班负责人")]
        public string jbfzr
        {
            get { return _jbfzr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[交班负责人]长度不能大于50!");
                if (_jbfzr as object == null || !_jbfzr.Equals(value))
                {
                    _jbfzr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jbry
        /// 属性描述：交班人员
        /// 字段信息：[jbry],nvarchar
        /// </summary>
        [DisplayNameAttribute("交班人员")]
        public string jbry
        {
            get { return _jbry; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[交班人员]长度不能大于50!");
                if (_jbry as object == null || !_jbry.Equals(value))
                {
                    _jbry = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jbfzry
        /// 属性描述：接班负责人
        /// 字段信息：[jbfzry],nvarchar
        /// </summary>
        [DisplayNameAttribute("接班负责人")]
        public string jbfzry
        {
            get { return _jbfzry; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[接班负责人]长度不能大于50!");
                if (_jbfzry as object == null || !_jbfzry.Equals(value))
                {
                    _jbfzry = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jbryy
        /// 属性描述：接班人员
        /// 字段信息：[jbryy],nvarchar
        /// </summary>
        [DisplayNameAttribute("接班人员")]
        public string jbryy
        {
            get { return _jbryy; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[接班人员]长度不能大于50!");
                if (_jbryy as object == null || !_jbryy.Equals(value))
                {
                    _jbryy = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：rq
        /// 属性描述：日期
        /// 字段信息：[rq],nvarchar
        /// </summary>
        [DisplayNameAttribute("日期")]
        public string rq
        {
            get { return _rq; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[日期]长度不能大于50!");
                if (_rq as object == null || !_rq.Equals(value))
                {
                    _rq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tq
        /// 属性描述：天气
        /// 字段信息：[tq],nvarchar
        /// </summary>
        [DisplayNameAttribute("天气")]
        public string tq
        {
            get { return _tq; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[天气]长度不能大于50!");
                if (_tq as object == null || !_tq.Equals(value))
                {
                    _tq = value;
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
