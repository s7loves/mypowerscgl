/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-1-2 21:44:35
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_cqcssqk]业务实体类
    ///对应表名:PJ_cqcssqk
    /// </summary>
    [Serializable]
    public class PJ_cqcssqk
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgname=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _jclx=String.Empty; 
        private DateTime _ssrq=new DateTime(1900,1,1); 
        private string _kzlr=String.Empty; 
        private string _zcr=String.Empty; 
        private string _cjr=String.Empty; 
        private string _js=String.Empty; 
        private string _s1=String.Empty; 
        private string _s2=String.Empty; 
        private string _s3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：唯一ID
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("唯一ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[唯一ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
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
        /// 属性名称：jclx
        /// 属性描述：检查类型
        /// 字段信息：[jclx],nvarchar
        /// </summary>
        [DisplayNameAttribute("检查类型")]
        public string jclx
        {
            get { return _jclx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[检查类型]长度不能大于50!");
                if (_jclx as object == null || !_jclx.Equals(value))
                {
                    _jclx = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ssrq
        /// 属性描述：实施日期
        /// 字段信息：[ssrq],datetime
        /// </summary>
        [DisplayNameAttribute("实施日期")]
        public DateTime ssrq
        {
            get { return _ssrq; }
            set
            {			
                if (_ssrq as object == null || !_ssrq.Equals(value))
                {
                    _ssrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kzlr
        /// 属性描述：开展内容
        /// 字段信息：[kzlr],nvarchar
        /// </summary>
        [DisplayNameAttribute("开展内容")]
        public string kzlr
        {
            get { return _kzlr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[开展内容]长度不能大于500!");
                if (_kzlr as object == null || !_kzlr.Equals(value))
                {
                    _kzlr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zcr
        /// 属性描述：主持人
        /// 字段信息：[zcr],nvarchar
        /// </summary>
        [DisplayNameAttribute("主持人")]
        public string zcr
        {
            get { return _zcr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[主持人]长度不能大于50!");
                if (_zcr as object == null || !_zcr.Equals(value))
                {
                    _zcr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cjr
        /// 属性描述：参加人
        /// 字段信息：[cjr],nvarchar
        /// </summary>
        [DisplayNameAttribute("参加人")]
        public string cjr
        {
            get { return _cjr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[参加人]长度不能大于500!");
                if (_cjr as object == null || !_cjr.Equals(value))
                {
                    _cjr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：js
        /// 属性描述：记事
        /// 字段信息：[js],nvarchar
        /// </summary>
        [DisplayNameAttribute("记事")]
        public string js
        {
            get { return _js; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[记事]长度不能大于500!");
                if (_js as object == null || !_js.Equals(value))
                {
                    _js = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S1
        /// 属性描述：
        /// 字段信息：[S1],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string S1
        {
            get { return _s1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_s1 as object == null || !_s1.Equals(value))
                {
                    _s1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S2
        /// 属性描述：
        /// 字段信息：[S2],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string S2
        {
            get { return _s2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_s2 as object == null || !_s2.Equals(value))
                {
                    _s2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S3
        /// 属性描述：
        /// 字段信息：[S3],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string S3
        {
            get { return _s3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_s3 as object == null || !_s3.Equals(value))
                {
                    _s3 = value;
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
