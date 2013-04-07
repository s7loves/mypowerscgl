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
    ///[bdjl_xdctzjlb]业务实体类
    ///对应表名:bdjl_xdctzjlb
    /// </summary>
    [Serializable]
    public class bdjl_xdctzjlb
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private DateTime _sj=new DateTime(1900,1,1); 
        private string _dcdy=String.Empty; 
        private string _dl=String.Empty; 
        private string _trdcgs=String.Empty; 
        private string _bzdcdy=String.Empty; 
        private string _jcr=String.Empty; 
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
        /// 属性名称：sj
        /// 属性描述：时间
        /// 字段信息：[sj],datetime
        /// </summary>
        [DisplayNameAttribute("时间")]
        public DateTime sj
        {
            get { return _sj; }
            set
            {			
                if (_sj as object == null || !_sj.Equals(value))
                {
                    _sj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dcdy
        /// 属性描述：电池电压(伏)
        /// 字段信息：[dcdy],nvarchar
        /// </summary>
        [DisplayNameAttribute("电池电压(伏)")]
        public string dcdy
        {
            get { return _dcdy; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电池电压(伏)]长度不能大于50!");
                if (_dcdy as object == null || !_dcdy.Equals(value))
                {
                    _dcdy = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dl
        /// 属性描述：电流(安)
        /// 字段信息：[dl],nvarchar
        /// </summary>
        [DisplayNameAttribute("电流(安)")]
        public string dl
        {
            get { return _dl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电流(安)]长度不能大于50!");
                if (_dl as object == null || !_dl.Equals(value))
                {
                    _dl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：trdcgs
        /// 属性描述：投入电池个数
        /// 字段信息：[trdcgs],nvarchar
        /// </summary>
        [DisplayNameAttribute("投入电池个数")]
        public string trdcgs
        {
            get { return _trdcgs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[投入电池个数]长度不能大于50!");
                if (_trdcgs as object == null || !_trdcgs.Equals(value))
                {
                    _trdcgs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bzdcdy
        /// 属性描述：标准电池电压(伏)
        /// 字段信息：[bzdcdy],nvarchar
        /// </summary>
        [DisplayNameAttribute("标准电池电压(伏)")]
        public string bzdcdy
        {
            get { return _bzdcdy; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[标准电池电压(伏)]长度不能大于50!");
                if (_bzdcdy as object == null || !_bzdcdy.Equals(value))
                {
                    _bzdcdy = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jcr
        /// 属性描述：检测人
        /// 字段信息：[jcr],nvarchar
        /// </summary>
        [DisplayNameAttribute("检测人")]
        public string jcr
        {
            get { return _jcr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[检测人]长度不能大于50!");
                if (_jcr as object == null || !_jcr.Equals(value))
                {
                    _jcr = value;
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
