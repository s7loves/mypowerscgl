/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-4-7 10:59:28
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[bdjl_aqhdjlb]业务实体类
    ///对应表名:bdjl_aqhdjlb
    /// </summary>
    [Serializable]
    public class bdjl_aqhdjlb
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _zcr=String.Empty; 
        private string _hdkssj=String.Empty; 
        private string _hdjssj=String.Empty; 
        private string _cxry=String.Empty; 
        private string _qxry=String.Empty; 
        private string _hdnr=String.Empty; 
        private string _hdxj=String.Empty; 
        private string _ldjcpy=String.Empty; 
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
        /// 属性名称：hdkssj
        /// 属性描述：活动开始时间
        /// 字段信息：[hdkssj],nvarchar
        /// </summary>
        [DisplayNameAttribute("活动开始时间")]
        public string hdkssj
        {
            get { return _hdkssj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[活动开始时间]长度不能大于50!");
                if (_hdkssj as object == null || !_hdkssj.Equals(value))
                {
                    _hdkssj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：hdjssj
        /// 属性描述：活动结束时间
        /// 字段信息：[hdjssj],nvarchar
        /// </summary>
        [DisplayNameAttribute("活动结束时间")]
        public string hdjssj
        {
            get { return _hdjssj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[活动结束时间]长度不能大于50!");
                if (_hdjssj as object == null || !_hdjssj.Equals(value))
                {
                    _hdjssj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cxry
        /// 属性描述：出席人员
        /// 字段信息：[cxry],nvarchar
        /// </summary>
        [DisplayNameAttribute("出席人员")]
        public string cxry
        {
            get { return _cxry; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[出席人员]长度不能大于500!");
                if (_cxry as object == null || !_cxry.Equals(value))
                {
                    _cxry = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qxry
        /// 属性描述：缺席人员
        /// 字段信息：[qxry],nvarchar
        /// </summary>
        [DisplayNameAttribute("缺席人员")]
        public string qxry
        {
            get { return _qxry; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[缺席人员]长度不能大于500!");
                if (_qxry as object == null || !_qxry.Equals(value))
                {
                    _qxry = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：hdnr
        /// 属性描述：活动内容
        /// 字段信息：[hdnr],nvarchar
        /// </summary>
        [DisplayNameAttribute("活动内容")]
        public string hdnr
        {
            get { return _hdnr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[活动内容]长度不能大于500!");
                if (_hdnr as object == null || !_hdnr.Equals(value))
                {
                    _hdnr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：hdxj
        /// 属性描述：活动小结
        /// 字段信息：[hdxj],nvarchar
        /// </summary>
        [DisplayNameAttribute("活动小结")]
        public string hdxj
        {
            get { return _hdxj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[活动小结]长度不能大于500!");
                if (_hdxj as object == null || !_hdxj.Equals(value))
                {
                    _hdxj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ldjcpy
        /// 属性描述：领导检查评语
        /// 字段信息：[ldjcpy],nvarchar
        /// </summary>
        [DisplayNameAttribute("领导检查评语")]
        public string ldjcpy
        {
            get { return _ldjcpy; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[领导检查评语]长度不能大于500!");
                if (_ldjcpy as object == null || !_ldjcpy.Equals(value))
                {
                    _ldjcpy = value;
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
