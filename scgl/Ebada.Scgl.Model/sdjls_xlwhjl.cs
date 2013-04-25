/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-4-25 9:39:20
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sdjls_xlwhjl]业务实体类
    ///对应表名:sdjls_xlwhjl
    /// </summary>
    [Serializable]
    public class sdjls_xlwhjl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _linecode=String.Empty; 
        private string _linename=String.Empty; 
        private string _linevol=String.Empty; 
        private string _whqd=String.Empty; 
        private string _wyxz=String.Empty; 
        private string _whdj=String.Empty; 
        private string _gx=String.Empty; 
        private string _jyzxh=String.Empty; 
        private string _xlbj=String.Empty; 
        private string _bz=String.Empty; 
        private string _zhfs=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty; 
        private string _c4=String.Empty; 
        private string _c5=String.Empty;   
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
        /// 属性名称：OrgCode
        /// 属性描述：单位编号
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位编号")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位编号]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgName
        /// 属性描述：单位名称
        /// 字段信息：[OrgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位名称")]
        public string OrgName
        {
            get { return _orgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位名称]长度不能大于50!");
                if (_orgname as object == null || !_orgname.Equals(value))
                {
                    _orgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineCode
        /// 属性描述：线路编号
        /// 字段信息：[LineCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路编号")]
        public string LineCode
        {
            get { return _linecode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路编号]长度不能大于50!");
                if (_linecode as object == null || !_linecode.Equals(value))
                {
                    _linecode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineName
        /// 属性描述：线路名称
        /// 字段信息：[LineName],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路名称")]
        public string LineName
        {
            get { return _linename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路名称]长度不能大于50!");
                if (_linename as object == null || !_linename.Equals(value))
                {
                    _linename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineVol
        /// 属性描述：线路电压
        /// 字段信息：[LineVol],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路电压")]
        public string LineVol
        {
            get { return _linevol; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路电压]长度不能大于50!");
                if (_linevol as object == null || !_linevol.Equals(value))
                {
                    _linevol = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：whqd
        /// 属性描述：污秽区段 
        /// 字段信息：[whqd],nvarchar
        /// </summary>
        [DisplayNameAttribute("污秽区段 ")]
        public string whqd
        {
            get { return _whqd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[污秽区段 ]长度不能大于50!");
                if (_whqd as object == null || !_whqd.Equals(value))
                {
                    _whqd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wyxz
        /// 属性描述：污源性质
        /// 字段信息：[wyxz],nvarchar
        /// </summary>
        [DisplayNameAttribute("污源性质")]
        public string wyxz
        {
            get { return _wyxz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[污源性质]长度不能大于50!");
                if (_wyxz as object == null || !_wyxz.Equals(value))
                {
                    _wyxz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：whdj
        /// 属性描述：污秽等级
        /// 字段信息：[whdj],nvarchar
        /// </summary>
        [DisplayNameAttribute("污秽等级")]
        public string whdj
        {
            get { return _whdj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[污秽等级]长度不能大于50!");
                if (_whdj as object == null || !_whdj.Equals(value))
                {
                    _whdj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gx
        /// 属性描述：杆型
        /// 字段信息：[gx],nvarchar
        /// </summary>
        [DisplayNameAttribute("杆型")]
        public string gx
        {
            get { return _gx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[杆型]长度不能大于50!");
                if (_gx as object == null || !_gx.Equals(value))
                {
                    _gx = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jyzxh
        /// 属性描述：绝缘子型号
        /// 字段信息：[jyzxh],nvarchar
        /// </summary>
        [DisplayNameAttribute("绝缘子型号")]
        public string jyzxh
        {
            get { return _jyzxh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[绝缘子型号]长度不能大于50!");
                if (_jyzxh as object == null || !_jyzxh.Equals(value))
                {
                    _jyzxh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xlbj
        /// 属性描述：泄露比距(cm/kV)
        /// 字段信息：[xlbj],nvarchar
        /// </summary>
        [DisplayNameAttribute("泄露比距(cm/kV)")]
        public string xlbj
        {
            get { return _xlbj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[泄露比距(cm/kV)]长度不能大于50!");
                if (_xlbj as object == null || !_xlbj.Equals(value))
                {
                    _xlbj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bz
        /// 属性描述：备注
        /// 字段信息：[bz],nvarchar
        /// </summary>
        [DisplayNameAttribute("备注")]
        public string bz
        {
            get { return _bz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备注]长度不能大于500!");
                if (_bz as object == null || !_bz.Equals(value))
                {
                    _bz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zhfs
        /// 属性描述：绝缘子组合方式
        /// 字段信息：[zhfs],nvarchar
        /// </summary>
        [DisplayNameAttribute("绝缘子组合方式")]
        public string zhfs
        {
            get { return _zhfs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[绝缘子组合方式]长度不能大于50!");
                if (_zhfs as object == null || !_zhfs.Equals(value))
                {
                    _zhfs = value;
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
  
        /// <summary>
        /// 属性名称：c4
        /// 属性描述：备用字段4
        /// 字段信息：[c4],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段4")]
        public string c4
        {
            get { return _c4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段4]长度不能大于500!");
                if (_c4 as object == null || !_c4.Equals(value))
                {
                    _c4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c5
        /// 属性描述：备用字段5
        /// 字段信息：[c5],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段5")]
        public string c5
        {
            get { return _c5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段5]长度不能大于500!");
                if (_c5 as object == null || !_c5.Equals(value))
                {
                    _c5 = value;
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
