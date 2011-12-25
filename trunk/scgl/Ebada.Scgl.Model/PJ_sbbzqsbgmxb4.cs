/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-12-24 16:33:28
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_sbbzqsbgmxb4]业务实体类
    ///对应表名:PJ_sbbzqsbgmxb4
    /// </summary>
    [Serializable]
    public class PJ_sbbzqsbgmxb4
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgname=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _sssbmc=String.Empty; 
        private string _sssswz=String.Empty; 
        private string _sssbbh=String.Empty; 
        private string _statuts=String.Empty; 
        private string _xw=String.Empty; 
        private string _hj=String.Empty; 
        private string _remark=String.Empty; 
        private string _s1=String.Empty; 
        private string _s2=String.Empty; 
        private string _s3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：唯一标识
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("唯一标识")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[唯一标识]长度不能大于50!");
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
        /// 属性名称：sssbmc
        /// 属性描述：所属设备名称
        /// 字段信息：[sssbmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("所属设备名称")]
        public string sssbmc
        {
            get { return _sssbmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[所属设备名称]长度不能大于500!");
                if (_sssbmc as object == null || !_sssbmc.Equals(value))
                {
                    _sssbmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sssswz
        /// 属性描述：所属设备位置
        /// 字段信息：[sssswz],nvarchar
        /// </summary>
        [DisplayNameAttribute("所属设备位置")]
        public string sssswz
        {
            get { return _sssswz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[所属设备位置]长度不能大于500!");
                if (_sssswz as object == null || !_sssswz.Equals(value))
                {
                    _sssswz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sssbbh
        /// 属性描述：所属设备编号
        /// 字段信息：[sssbbh],nvarchar
        /// </summary>
        [DisplayNameAttribute("所属设备编号")]
        public string sssbbh
        {
            get { return _sssbbh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[所属设备编号]长度不能大于50!");
                if (_sssbbh as object == null || !_sssbbh.Equals(value))
                {
                    _sssbbh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：statuts
        /// 属性描述：状态
        /// 字段信息：[statuts],nvarchar
        /// </summary>
        [DisplayNameAttribute("状态")]
        public string statuts
        {
            get { return _statuts; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[状态]长度不能大于50!");
                if (_statuts as object == null || !_statuts.Equals(value))
                {
                    _statuts = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xw
        /// 属性描述：相位
        /// 字段信息：[xw],nvarchar
        /// </summary>
        [DisplayNameAttribute("相位")]
        public string xw
        {
            get { return _xw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[相位]长度不能大于50!");
                if (_xw as object == null || !_xw.Equals(value))
                {
                    _xw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：hj
        /// 属性描述：合计
        /// 字段信息：[hj],nvarchar
        /// </summary>
        [DisplayNameAttribute("合计")]
        public string hj
        {
            get { return _hj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[合计]长度不能大于500!");
                if (_hj as object == null || !_hj.Equals(value))
                {
                    _hj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Remark
        /// 属性描述：
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
                throw new Exception("[]长度不能大于500!");
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
