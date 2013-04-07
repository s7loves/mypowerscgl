/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-4-7 10:59:29
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[bdjl_ddzczl]业务实体类
    ///对应表名:bdjl_ddzczl
    /// </summary>
    [Serializable]
    public class bdjl_ddzczl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _lb=String.Empty; 
        private string _kssj=String.Empty; 
        private string _dd=String.Empty; 
        private string _bds=String.Empty; 
        private string _zlbh=String.Empty; 
        private string _nr=String.Empty; 
        private string _zzsj=String.Empty; 
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
        /// 属性名称：lb
        /// 属性描述：令别
        /// 字段信息：[lb],nvarchar
        /// </summary>
        [DisplayNameAttribute("令别")]
        public string lb
        {
            get { return _lb; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[令别]长度不能大于50!");
                if (_lb as object == null || !_lb.Equals(value))
                {
                    _lb = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kssj
        /// 属性描述：开始时间
        /// 字段信息：[kssj],nvarchar
        /// </summary>
        [DisplayNameAttribute("开始时间")]
        public string kssj
        {
            get { return _kssj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[开始时间]长度不能大于50!");
                if (_kssj as object == null || !_kssj.Equals(value))
                {
                    _kssj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dd
        /// 属性描述：调度
        /// 字段信息：[dd],nvarchar
        /// </summary>
        [DisplayNameAttribute("调度")]
        public string dd
        {
            get { return _dd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[调度]长度不能大于50!");
                if (_dd as object == null || !_dd.Equals(value))
                {
                    _dd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bds
        /// 属性描述：变电所
        /// 字段信息：[bds],nvarchar
        /// </summary>
        [DisplayNameAttribute("变电所")]
        public string bds
        {
            get { return _bds; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[变电所]长度不能大于50!");
                if (_bds as object == null || !_bds.Equals(value))
                {
                    _bds = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zlbh
        /// 属性描述：指令编号
        /// 字段信息：[zlbh],nvarchar
        /// </summary>
        [DisplayNameAttribute("指令编号")]
        public string zlbh
        {
            get { return _zlbh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[指令编号]长度不能大于50!");
                if (_zlbh as object == null || !_zlbh.Equals(value))
                {
                    _zlbh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：nr
        /// 属性描述：内容
        /// 字段信息：[nr],nvarchar
        /// </summary>
        [DisplayNameAttribute("内容")]
        public string nr
        {
            get { return _nr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[内容]长度不能大于500!");
                if (_nr as object == null || !_nr.Equals(value))
                {
                    _nr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zzsj
        /// 属性描述：终止时间
        /// 字段信息：[zzsj],nvarchar
        /// </summary>
        [DisplayNameAttribute("终止时间")]
        public string zzsj
        {
            get { return _zzsj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[终止时间]长度不能大于500!");
                if (_zzsj as object == null || !_zzsj.Equals(value))
                {
                    _zzsj = value;
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
