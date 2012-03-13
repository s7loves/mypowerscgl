/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-3-13 10:43:23
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_znts]业务实体类
    ///对应表名:PJ_znts
    /// </summary>
    [Serializable]
    public class PJ_znts
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _szdx=String.Empty; 
        private string _sql=String.Empty; 
        private string _tjsql=String.Empty; 
        private string _xsgs=String.Empty; 
        private string _type=String.Empty; 
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
        /// 属性名称：szdx
        /// 属性描述：标题
        /// 字段信息：[szdx],nvarchar
        /// </summary>
        [DisplayNameAttribute("标题")]
        public string szdx
        {
            get { return _szdx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[标题]长度不能大于500!");
                if (_szdx as object == null || !_szdx.Equals(value))
                {
                    _szdx = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sql
        /// 属性描述：SQL信息
        /// 字段信息：[sql],nvarchar
        /// </summary>
        [DisplayNameAttribute("SQL信息")]
        public string sql
        {
            get { return _sql; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[SQL信息]长度不能大于1073741823!");
                if (_sql as object == null || !_sql.Equals(value))
                {
                    _sql = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tjsql
        /// 属性描述：条件SQL
        /// 字段信息：[tjsql],nvarchar
        /// </summary>
        [DisplayNameAttribute("条件SQL")]
        public string tjsql
        {
            get { return _tjsql; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[条件SQL]长度不能大于1073741823!");
                if (_tjsql as object == null || !_tjsql.Equals(value))
                {
                    _tjsql = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xsgs
        /// 属性描述：显示形式
        /// 字段信息：[xsgs],nvarchar
        /// </summary>
        [DisplayNameAttribute("显示形式")]
        public string xsgs
        {
            get { return _xsgs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[显示形式]长度不能大于1073741823!");
                if (_xsgs as object == null || !_xsgs.Equals(value))
                {
                    _xsgs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：type
        /// 属性描述：类型
        /// 字段信息：[type],nvarchar
        /// </summary>
        [DisplayNameAttribute("类型")]
        public string type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[类型]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S1
        /// 属性描述：备用
        /// 字段信息：[S1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用")]
        public string S1
        {
            get { return _s1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用]长度不能大于50!");
                if (_s1 as object == null || !_s1.Equals(value))
                {
                    _s1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S2
        /// 属性描述：备用
        /// 字段信息：[S2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用")]
        public string S2
        {
            get { return _s2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用]长度不能大于50!");
                if (_s2 as object == null || !_s2.Equals(value))
                {
                    _s2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S3
        /// 属性描述：备用
        /// 字段信息：[S3],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用")]
        public string S3
        {
            get { return _s3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用]长度不能大于50!");
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
