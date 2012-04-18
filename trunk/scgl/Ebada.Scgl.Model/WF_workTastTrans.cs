/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-4-18 23:42:57
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[WF_workTastTrans]业务实体类
    ///对应表名:WF_workTastTrans
    /// </summary>
    [Serializable]
    public class WF_WorkTastTrans
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _slcmcid=String.Empty; 
        private string _slcjdid=String.Empty; 
        private string _slcjdzd=String.Empty; 
        private string _ssql=String.Empty; 
        private string _tlcmcid=String.Empty; 
        private string _tlcjdid=String.Empty; 
        private string _tlcjdzd=String.Empty; 
        private string _cdfs=String.Empty; 
        private string _tsql=String.Empty; 
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
        /// 属性名称：slcmcid
        /// 属性描述：源流程ID
        /// 字段信息：[slcmcid],nvarchar
        /// </summary>
        [DisplayNameAttribute("源流程ID")]
        public string slcmcid
        {
            get { return _slcmcid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[源流程ID]长度不能大于50!");
                if (_slcmcid as object == null || !_slcmcid.Equals(value))
                {
                    _slcmcid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：slcjdid
        /// 属性描述：源流程节点ID
        /// 字段信息：[slcjdid],nvarchar
        /// </summary>
        [DisplayNameAttribute("源流程节点ID")]
        public string slcjdid
        {
            get { return _slcjdid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[源流程节点ID]长度不能大于50!");
                if (_slcjdid as object == null || !_slcjdid.Equals(value))
                {
                    _slcjdid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：slcjdzd
        /// 属性描述：源流程节点字段
        /// 字段信息：[slcjdzd],nvarchar
        /// </summary>
        [DisplayNameAttribute("源流程节点字段")]
        public string slcjdzd
        {
            get { return _slcjdzd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[源流程节点字段]长度不能大于50!");
                if (_slcjdzd as object == null || !_slcjdzd.Equals(value))
                {
                    _slcjdzd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sSQL
        /// 属性描述：源SQL
        /// 字段信息：[sSQL],nvarchar
        /// </summary>
        [DisplayNameAttribute("源SQL")]
        public string sSQL
        {
            get { return _ssql; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[源SQL]长度不能大于1073741823!");
                if (_ssql as object == null || !_ssql.Equals(value))
                {
                    _ssql = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tlcmcid
        /// 属性描述：目标流程ID
        /// 字段信息：[tlcmcid],nvarchar
        /// </summary>
        [DisplayNameAttribute("目标流程ID")]
        public string tlcmcid
        {
            get { return _tlcmcid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[目标流程ID]长度不能大于50!");
                if (_tlcmcid as object == null || !_tlcmcid.Equals(value))
                {
                    _tlcmcid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tlcjdid
        /// 属性描述：目标流程节点ID
        /// 字段信息：[tlcjdid],nvarchar
        /// </summary>
        [DisplayNameAttribute("目标流程节点ID")]
        public string tlcjdid
        {
            get { return _tlcjdid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[目标流程节点ID]长度不能大于50!");
                if (_tlcjdid as object == null || !_tlcjdid.Equals(value))
                {
                    _tlcjdid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tlcjdzd
        /// 属性描述：目标流程节点字段ID
        /// 字段信息：[tlcjdzd],nvarchar
        /// </summary>
        [DisplayNameAttribute("目标流程节点字段ID")]
        public string tlcjdzd
        {
            get { return _tlcjdzd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[目标流程节点字段ID]长度不能大于50!");
                if (_tlcjdzd as object == null || !_tlcjdzd.Equals(value))
                {
                    _tlcjdzd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cdfs
        /// 属性描述：传递方式
        /// 字段信息：[cdfs],nvarchar
        /// </summary>
        [DisplayNameAttribute("传递方式")]
        public string cdfs
        {
            get { return _cdfs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[传递方式]长度不能大于50!");
                if (_cdfs as object == null || !_cdfs.Equals(value))
                {
                    _cdfs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tSQL
        /// 属性描述：目标SQL
        /// 字段信息：[tSQL],nvarchar
        /// </summary>
        [DisplayNameAttribute("目标SQL")]
        public string tSQL
        {
            get { return _tsql; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[目标SQL]长度不能大于1073741823!");
                if (_tsql as object == null || !_tsql.Equals(value))
                {
                    _tsql = value;
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
                if( value.ToString().Length > 1073741823)
                throw new Exception("[]长度不能大于1073741823!");
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
                if( value.ToString().Length > 1073741823)
                throw new Exception("[]长度不能大于1073741823!");
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
                if( value.ToString().Length > 1073741823)
                throw new Exception("[]长度不能大于1073741823!");
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
