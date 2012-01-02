/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-1-2 17:06:23
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_lcfxwtjzgls]业务实体类
    ///对应表名:PJ_lcfxwtjzgls
    /// </summary>
    [Serializable]
    public class PJ_lcfxwtjzgls
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgname=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _jclx=String.Empty; 
        private string _ccwt=String.Empty; 
        private string _zgcs=String.Empty; 
        private DateTime _jhwcsj=new DateTime(1900,1,1); 
        private DateTime _lszgsj=new DateTime(1900,1,1); 
        private string _lsqk=String.Empty; 
        private string _lsr=String.Empty; 
        private string _dbr=String.Empty; 
        private string _remark=String.Empty; 
        private string _s1=String.Empty; 
        private string _s2=String.Empty; 
        private string _s3=String.Empty;   
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
        /// 属性名称：ccwt
        /// 属性描述：查出的问题
        /// 字段信息：[ccwt],nvarchar
        /// </summary>
        [DisplayNameAttribute("查出的问题")]
        public string ccwt
        {
            get { return _ccwt; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[查出的问题]长度不能大于500!");
                if (_ccwt as object == null || !_ccwt.Equals(value))
                {
                    _ccwt = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zgcs
        /// 属性描述：整改措施
        /// 字段信息：[zgcs],nvarchar
        /// </summary>
        [DisplayNameAttribute("整改措施")]
        public string zgcs
        {
            get { return _zgcs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[整改措施]长度不能大于500!");
                if (_zgcs as object == null || !_zgcs.Equals(value))
                {
                    _zgcs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jhwcsj
        /// 属性描述：计划完成时间
        /// 字段信息：[jhwcsj],datetime
        /// </summary>
        [DisplayNameAttribute("计划完成时间")]
        public DateTime jhwcsj
        {
            get { return _jhwcsj; }
            set
            {			
                if (_jhwcsj as object == null || !_jhwcsj.Equals(value))
                {
                    _jhwcsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lszgsj
        /// 属性描述：落实整改时间
        /// 字段信息：[lszgsj],datetime
        /// </summary>
        [DisplayNameAttribute("落实整改时间")]
        public DateTime lszgsj
        {
            get { return _lszgsj; }
            set
            {			
                if (_lszgsj as object == null || !_lszgsj.Equals(value))
                {
                    _lszgsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lsqk
        /// 属性描述：落实情况
        /// 字段信息：[lsqk],nvarchar
        /// </summary>
        [DisplayNameAttribute("落实情况")]
        public string lsqk
        {
            get { return _lsqk; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[落实情况]长度不能大于50!");
                if (_lsqk as object == null || !_lsqk.Equals(value))
                {
                    _lsqk = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lsr
        /// 属性描述：落实人
        /// 字段信息：[lsr],nvarchar
        /// </summary>
        [DisplayNameAttribute("落实人")]
        public string lsr
        {
            get { return _lsr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[落实人]长度不能大于50!");
                if (_lsr as object == null || !_lsr.Equals(value))
                {
                    _lsr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dbr
        /// 属性描述：督办人
        /// 字段信息：[dbr],nvarchar
        /// </summary>
        [DisplayNameAttribute("督办人")]
        public string dbr
        {
            get { return _dbr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[督办人]长度不能大于50!");
                if (_dbr as object == null || !_dbr.Equals(value))
                {
                    _dbr = value;
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
