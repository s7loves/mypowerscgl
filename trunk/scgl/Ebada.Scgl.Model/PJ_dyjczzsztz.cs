/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-12-21 20:16:19
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_dyjczzsztz]业务实体类
    ///对应表名:PJ_dyjczzsztz
    /// </summary>
    [Serializable]
    public class PJ_dyjczzsztz
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _zzszwz=String.Empty; 
        private string _zzvol=String.Empty; 
        private string _zzdlb=String.Empty; 
        private string _zzxh=String.Empty;  
        private string _zzfactory=String.Empty; 
        private DateTime _jddate = new DateTime(1900, 1, 1); 
        private string _zdz=String.Empty; 
        private string _cjfs=String.Empty; 
        private string _remark=String.Empty; 
        private string _s1=String.Empty; 
        private string _s2=String.Empty; 
        private string _s3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("唯一ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：
        /// 字段信息：[OrgCode],
        /// </summary>
        [DisplayNameAttribute("供电所代码")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgName
        /// 属性描述：
        /// 字段信息：[OrgName],
        /// </summary>
        [DisplayNameAttribute("供电所名称")]
        public string OrgName
        {
            get { return _orgname; }
            set
            {			
                if (_orgname as object == null || !_orgname.Equals(value))
                {
                    _orgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zzszwz
        /// 属性描述：
        /// 字段信息：[zzszwz],
        /// </summary>
        [DisplayNameAttribute("电压监测装置设置位置")]
        public string zzszwz
        {
            get { return _zzszwz; }
            set
            {			
                if (_zzszwz as object == null || !_zzszwz.Equals(value))
                {
                    _zzszwz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zzVol
        /// 属性描述：
        /// 字段信息：[zzVol],
        /// </summary>
        [DisplayNameAttribute("监测电压（KV）")]
        public string zzVol
        {
            get { return _zzvol; }
            set
            {			
                if (_zzvol as object == null || !_zzvol.Equals(value))
                {
                    _zzvol = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zzdlb
        /// 属性描述：
        /// 字段信息：[zzdlb],
        /// </summary>
        [DisplayNameAttribute("监测点类别")]
        public string zzdlb
        {
            get { return _zzdlb; }
            set
            {			
                if (_zzdlb as object == null || !_zzdlb.Equals(value))
                {
                    _zzdlb = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zzxh
        /// 属性描述：
        /// 字段信息：[zzxh],
        /// </summary>
        [DisplayNameAttribute("电压监测装置型号")]
        public string zzxh
        {
            get { return _zzxh; }
            set
            {			
                if (_zzxh as object == null || !_zzxh.Equals(value))
                {
                    _zzxh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zzFactory
        /// 属性描述：
        /// 字段信息：[zzFactory],
        /// </summary>
        [DisplayNameAttribute("制造厂")]
        public string zzFactory
        {
            get { return _zzfactory; }
            set
            {			
                if (_zzfactory as object == null || !_zzfactory.Equals(value))
                {
                    _zzfactory = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jddate
        /// 属性描述：
        /// 字段信息：[jddate],
        /// </summary>
        [DisplayNameAttribute("检定日期")]
        public DateTime jddate
        {
            get { return _jddate; }
            set
            {			
                if (_jddate as object == null || !_jddate.Equals(value))
                {
                    _jddate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zdz
        /// 属性描述：
        /// 字段信息：[zdz],
        /// </summary>
        [DisplayNameAttribute("整定值")]
        public string zdz
        {
            get { return _zdz; }
            set
            {			
                if (_zdz as object == null || !_zdz.Equals(value))
                {
                    _zdz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cjfs
        /// 属性描述：
        /// 字段信息：[cjfs],
        /// </summary>
        [DisplayNameAttribute("采集方式")]
        public string cjfs
        {
            get { return _cjfs; }
            set
            {			
                if (_cjfs as object == null || !_cjfs.Equals(value))
                {
                    _cjfs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Remark
        /// 属性描述：
        /// 字段信息：[Remark],
        /// </summary>
        [DisplayNameAttribute("备注")]
        public string Remark
        {
            get { return _remark; }
            set
            {			
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S1
        /// 属性描述：
        /// 字段信息：[S1],
        /// </summary>
        [DisplayNameAttribute("")]
        public string S1
        {
            get { return _s1; }
            set
            {			
                if (_s1 as object == null || !_s1.Equals(value))
                {
                    _s1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S2
        /// 属性描述：
        /// 字段信息：[S2],
        /// </summary>
        [DisplayNameAttribute("")]
        public string S2
        {
            get { return _s2; }
            set
            {			
                if (_s2 as object == null || !_s2.Equals(value))
                {
                    _s2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S3
        /// 属性描述：
        /// 字段信息：[S3],
        /// </summary>
        [DisplayNameAttribute("")]
        public string S3
        {
            get { return _s3; }
            set
            {			
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
