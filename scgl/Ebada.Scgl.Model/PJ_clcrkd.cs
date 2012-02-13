/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-2-11 20:53:21
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_clcrkd]业务实体类
    ///对应表名:PJ_clcrkd
    /// </summary>
    [Serializable]
    public class PJ_clcrkd
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgname=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _wpmc=String.Empty; 
        private string _wpgg=String.Empty; 
        private string _wpdw=String.Empty; 
        private string _wpsl=String.Empty; 
        private DateTime _indate=new DateTime(1900,1,1); 
        private string _remark=String.Empty; 
        private string _type=String.Empty;   
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
        /// 属性名称：wpmc
        /// 属性描述：物品名称
        /// 字段信息：[wpmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("物品名称")]
        public string wpmc
        {
            get { return _wpmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[物品名称]长度不能大于50!");
                if (_wpmc as object == null || !_wpmc.Equals(value))
                {
                    _wpmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wpgg
        /// 属性描述：物品规格
        /// 字段信息：[wpgg],nvarchar
        /// </summary>
        [DisplayNameAttribute("物品规格")]
        public string wpgg
        {
            get { return _wpgg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[物品规格]长度不能大于50!");
                if (_wpgg as object == null || !_wpgg.Equals(value))
                {
                    _wpgg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wpdw
        /// 属性描述：物品单位
        /// 字段信息：[wpdw],nvarchar
        /// </summary>
        [DisplayNameAttribute("物品单位")]
        public string wpdw
        {
            get { return _wpdw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[物品单位]长度不能大于50!");
                if (_wpdw as object == null || !_wpdw.Equals(value))
                {
                    _wpdw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wpsl
        /// 属性描述：数量
        /// 字段信息：[wpsl],nvarchar
        /// </summary>
        [DisplayNameAttribute("数量")]
        public string wpsl
        {
            get { return _wpsl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[数量]长度不能大于50!");
                if (_wpsl as object == null || !_wpsl.Equals(value))
                {
                    _wpsl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：indate
        /// 属性描述：入库时间
        /// 字段信息：[indate],datetime
        /// </summary>
        [DisplayNameAttribute("入库时间")]
        public DateTime indate
        {
            get { return _indate; }
            set
            {			
                if (_indate as object == null || !_indate.Equals(value))
                {
                    _indate = value;
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
                if( value.ToString().Length > 50)
                throw new Exception("[备注]长度不能大于50!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
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
