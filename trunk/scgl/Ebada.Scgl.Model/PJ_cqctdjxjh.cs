/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-12-28 22:01:45
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_cqctdjxjh]业务实体类
    ///对应表名:PJ_cqctdjxjh
    /// </summary>
    [Serializable]
    public class PJ_cqctdjxjh
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _sqorgname=String.Empty; 
        private string _jxsb=String.Empty; 
        private string _jxnr=String.Empty; 
        private DateTime _tdtime=new DateTime(1900,1,1); 
        private DateTime _sdtime=new DateTime(1900,1,1); 
        private string _assorgname=String.Empty; 
        private string _remark=String.Empty; 
        private string _s1=String.Empty; 
        private string _s2=String.Empty; 
        private string _s3=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1);   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：填写单位代码
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("填写单位代码")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[填写单位代码]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgName
        /// 属性描述：填写单位
        /// 字段信息：[OrgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("填写单位")]
        public string OrgName
        {
            get { return _orgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[填写单位]长度不能大于50!");
                if (_orgname as object == null || !_orgname.Equals(value))
                {
                    _orgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SQOrgname
        /// 属性描述：申请单位
        /// 字段信息：[SQOrgname],nvarchar
        /// </summary>
        [DisplayNameAttribute("申请单位")]
        public string SQOrgname
        {
            get { return _sqorgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[申请单位]长度不能大于50!");
                if (_sqorgname as object == null || !_sqorgname.Equals(value))
                {
                    _sqorgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：JXSB
        /// 属性描述：停电检修设备
        /// 字段信息：[JXSB],nvarchar
        /// </summary>
        [DisplayNameAttribute("停电检修设备")]
        public string JXSB
        {
            get { return _jxsb; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 150)
                throw new Exception("[停电检修设备]长度不能大于150!");
                if (_jxsb as object == null || !_jxsb.Equals(value))
                {
                    _jxsb = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：JXNR
        /// 属性描述：检修内容
        /// 字段信息：[JXNR],nvarchar
        /// </summary>
        [DisplayNameAttribute("检修内容")]
        public string JXNR
        {
            get { return _jxnr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 150)
                throw new Exception("[检修内容]长度不能大于150!");
                if (_jxnr as object == null || !_jxnr.Equals(value))
                {
                    _jxnr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TDtime
        /// 属性描述：停电时间
        /// 字段信息：[TDtime],datetime
        /// </summary>
        [DisplayNameAttribute("停电时间")]
        public DateTime TDtime
        {
            get { return _tdtime; }
            set
            {			
                if (_tdtime as object == null || !_tdtime.Equals(value))
                {
                    _tdtime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SDtime
        /// 属性描述：送电时间
        /// 字段信息：[SDtime],datetime
        /// </summary>
        [DisplayNameAttribute("送电时间")]
        public DateTime SDtime
        {
            get { return _sdtime; }
            set
            {			
                if (_sdtime as object == null || !_sdtime.Equals(value))
                {
                    _sdtime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ASSOrgname
        /// 属性描述：配合检修单位
        /// 字段信息：[ASSOrgname],nvarchar
        /// </summary>
        [DisplayNameAttribute("配合检修单位")]
        public string ASSOrgname
        {
            get { return _assorgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[配合检修单位]长度不能大于250!");
                if (_assorgname as object == null || !_assorgname.Equals(value))
                {
                    _assorgname = value;
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
                if( value.ToString().Length > 1073741823)
                throw new Exception("[备注]长度不能大于1073741823!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S1
        /// 属性描述：检查方式（春查、秋查）
        /// 字段信息：[S1],nvarchar
        /// </summary>
        [DisplayNameAttribute("检查方式（春查、秋查）")]
        public string S1
        {
            get { return _s1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[检查方式（春查、秋查）]长度不能大于250!");
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
                if( value.ToString().Length > 250)
                throw new Exception("[]长度不能大于250!");
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
                if( value.ToString().Length > 250)
                throw new Exception("[]长度不能大于250!");
                if (_s3 as object == null || !_s3.Equals(value))
                {
                    _s3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateDate
        /// 属性描述：创建时间
        /// 字段信息：[CreateDate],datetime
        /// </summary>
        [DisplayNameAttribute("创建时间")]
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
