/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-12-29 22:01:51
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_xlsbzrqhfmbb]业务实体类
    ///对应表名:PJ_xlsbzrqhfmbb
    /// </summary>
    [Serializable]
    public class PJ_xlsbzrqhfmbb
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _jsxl=String.Empty; 
        private string _zjxl=String.Empty; 
        private string _gytq=String.Empty; 
        private string _zytq=String.Empty; 
        private string _zrr=String.Empty; 
        private string _remark=String.Empty; 
        private DateTime _creattime=new DateTime(1900,1,1); 
        private string _s1=String.Empty; 
        private string _s2=String.Empty; 
        private string _s3=String.Empty;   
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
        /// 属性名称：jsxl
        /// 属性描述：局属线路
        /// 字段信息：[jsxl],nvarchar
        /// </summary>
        [DisplayNameAttribute("局属线路")]
        public string jsxl
        {
            get { return _jsxl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 100)
                throw new Exception("[局属线路]长度不能大于100!");
                if (_jsxl as object == null || !_jsxl.Equals(value))
                {
                    _jsxl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zjxl
        /// 属性描述：自建线路
        /// 字段信息：[zjxl],nvarchar
        /// </summary>
        [DisplayNameAttribute("自建线路")]
        public string zjxl
        {
            get { return _zjxl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 100)
                throw new Exception("[自建线路]长度不能大于100!");
                if (_zjxl as object == null || !_zjxl.Equals(value))
                {
                    _zjxl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gytq
        /// 属性描述：公用台区
        /// 字段信息：[gytq],nvarchar
        /// </summary>
        [DisplayNameAttribute("公用台区")]
        public string gytq
        {
            get { return _gytq; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 100)
                throw new Exception("[公用台区]长度不能大于100!");
                if (_gytq as object == null || !_gytq.Equals(value))
                {
                    _gytq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zytq
        /// 属性描述：专业台区
        /// 字段信息：[zytq],nvarchar
        /// </summary>
        [DisplayNameAttribute("专业台区")]
        public string zytq
        {
            get { return _zytq; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 100)
                throw new Exception("[专业台区]长度不能大于100!");
                if (_zytq as object == null || !_zytq.Equals(value))
                {
                    _zytq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zrr
        /// 属性描述：责任人
        /// 字段信息：[zrr],nvarchar
        /// </summary>
        [DisplayNameAttribute("责任人")]
        public string zrr
        {
            get { return _zrr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 100)
                throw new Exception("[责任人]长度不能大于100!");
                if (_zrr as object == null || !_zrr.Equals(value))
                {
                    _zrr = value;
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
                if( value.ToString().Length > 500)
                throw new Exception("[备注]长度不能大于500!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Creattime
        /// 属性描述：创建日期
        /// 字段信息：[Creattime],datetime
        /// </summary>
        [DisplayNameAttribute("创建日期")]
        public DateTime Creattime
        {
            get { return _creattime; }
            set
            {			
                if (_creattime as object == null || !_creattime.Equals(value))
                {
                    _creattime = value;
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
