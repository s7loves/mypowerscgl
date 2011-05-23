/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-17 22:06:06
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_dyxl]业务实体类
    ///对应表名:PS_dyxl
    /// </summary>
    [Serializable]
    public class PS_dyxl
    {
        
        #region Private 成员
        private string _byqid=String.Empty; 
        private string _dyxlid=Newid(); 
        private string _dyxlcode=String.Empty; 
        private string _dyxlname=String.Empty; 
        private string _remark=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：byqID
        /// 属性描述：变台ID
        /// 字段信息：[byqID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("变台ID")]
        public string byqID
        {
            get { return _byqid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[变台ID]长度不能大于50!");
                if (_byqid as object == null || !_byqid.Equals(value))
                {
                    _byqid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dyxlID
        /// 属性描述：线路ID
        /// 字段信息：[dyxlID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("线路ID")]
        public string dyxlID
        {
            get { return _dyxlid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路ID]长度不能大于50!");
                if (_dyxlid as object == null || !_dyxlid.Equals(value))
                {
                    _dyxlid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dyxlCode
        /// 属性描述：线路编号
        /// 字段信息：[dyxlCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路编号")]
        public string dyxlCode
        {
            get { return _dyxlcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路编号]长度不能大于50!");
                if (_dyxlcode as object == null || !_dyxlcode.Equals(value))
                {
                    _dyxlcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dyxlName
        /// 属性描述：线路名称
        /// 字段信息：[dyxlName],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路名称")]
        public string dyxlName
        {
            get { return _dyxlname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路名称]长度不能大于50!");
                if (_dyxlname as object == null || !_dyxlname.Equals(value))
                {
                    _dyxlname = value;
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
                if( value.ToString().Length > 250)
                throw new Exception("[备注]长度不能大于250!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
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
