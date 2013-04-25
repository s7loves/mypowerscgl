/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-4-25 9:39:19
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sdjls_jyzcsjl]业务实体类
    ///对应表名:sdjls_jyzcsjl
    /// </summary>
    [Serializable]
    public class sdjls_jyzcsjl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _lineid=String.Empty; 
        private string _linename=String.Empty; 
        private string _parentid=String.Empty; 
        private DateTime _cssj=new DateTime(1900,1,1); 
        private string _gh=String.Empty; 
        private string _gx=String.Empty; 
        private string _jyzxh=String.Empty; 
        private string _lzjyzwz=String.Empty; 
        private string _syfzr=String.Empty; 
        private DateTime _clsj=new DateTime(1900,1,1); 
        private string _bz=String.Empty; 
        private string _cb=String.Empty; 
        private string _xb=String.Empty; 
        private string _zyc=String.Empty; 
        private string _jyzzzc=String.Empty; 
        private string _lhpwchdsq=String.Empty; 
        private string _lhps=String.Empty; 
        private DateTime _ghrq=new DateTime(1900,1,1); 
        private string _fzr=String.Empty; 
        private string _xghjyzxh=String.Empty; 
        private string _xghjyzzzc=String.Empty; 
        private DateTime _lhjyzccrq=new DateTime(1900,1,1); 
        private string _lhjyzyxnx=String.Empty; 
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
        /// 属性名称：LineID
        /// 属性描述：线路代码
        /// 字段信息：[LineID],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路代码")]
        public string LineID
        {
            get { return _lineid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路代码]长度不能大于50!");
                if (_lineid as object == null || !_lineid.Equals(value))
                {
                    _lineid = value;
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
        /// 属性名称：ParentID
        /// 属性描述：ParentID
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("ParentID")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[ParentID]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cssj
        /// 属性描述：测试时间
        /// 字段信息：[cssj],datetime
        /// </summary>
        [DisplayNameAttribute("测试时间")]
        public DateTime cssj
        {
            get { return _cssj; }
            set
            {			
                if (_cssj as object == null || !_cssj.Equals(value))
                {
                    _cssj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gh
        /// 属性描述：杆号
        /// 字段信息：[gh],nvarchar
        /// </summary>
        [DisplayNameAttribute("杆号")]
        public string gh
        {
            get { return _gh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[杆号]长度不能大于50!");
                if (_gh as object == null || !_gh.Equals(value))
                {
                    _gh = value;
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
        /// 属性名称：lzjyzwz
        /// 属性描述：零值绝缘子位置
        /// 字段信息：[lzjyzwz],nvarchar
        /// </summary>
        [DisplayNameAttribute("零值绝缘子位置")]
        public string lzjyzwz
        {
            get { return _lzjyzwz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[零值绝缘子位置]长度不能大于500!");
                if (_lzjyzwz as object == null || !_lzjyzwz.Equals(value))
                {
                    _lzjyzwz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：syfzr
        /// 属性描述：试验负责人
        /// 字段信息：[syfzr],nvarchar
        /// </summary>
        [DisplayNameAttribute("试验负责人")]
        public string syfzr
        {
            get { return _syfzr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[试验负责人]长度不能大于50!");
                if (_syfzr as object == null || !_syfzr.Equals(value))
                {
                    _syfzr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：clsj
        /// 属性描述：处理时间
        /// 字段信息：[clsj],datetime
        /// </summary>
        [DisplayNameAttribute("处理时间")]
        public DateTime clsj
        {
            get { return _clsj; }
            set
            {			
                if (_clsj as object == null || !_clsj.Equals(value))
                {
                    _clsj = value;
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
        /// 属性名称：cb
        /// 属性描述：侧别
        /// 字段信息：[cb],nvarchar
        /// </summary>
        [DisplayNameAttribute("侧别")]
        public string cb
        {
            get { return _cb; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[侧别]长度不能大于500!");
                if (_cb as object == null || !_cb.Equals(value))
                {
                    _cb = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xb
        /// 属性描述：相别
        /// 字段信息：[xb],nvarchar
        /// </summary>
        [DisplayNameAttribute("相别")]
        public string xb
        {
            get { return _xb; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[相别]长度不能大于500!");
                if (_xb as object == null || !_xb.Equals(value))
                {
                    _xb = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zyc
        /// 属性描述：左右串
        /// 字段信息：[zyc],nvarchar
        /// </summary>
        [DisplayNameAttribute("左右串")]
        public string zyc
        {
            get { return _zyc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[左右串]长度不能大于50!");
                if (_zyc as object == null || !_zyc.Equals(value))
                {
                    _zyc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jyzzzc
        /// 属性描述：绝缘子制造厂
        /// 字段信息：[jyzzzc],nvarchar
        /// </summary>
        [DisplayNameAttribute("绝缘子制造厂")]
        public string jyzzzc
        {
            get { return _jyzzzc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[绝缘子制造厂]长度不能大于50!");
                if (_jyzzzc as object == null || !_jyzzzc.Equals(value))
                {
                    _jyzzzc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lhpwchdsq
        /// 属性描述：劣化瓶位从横担算起
        /// 字段信息：[lhpwchdsq],nvarchar
        /// </summary>
        [DisplayNameAttribute("劣化瓶位从横担算起")]
        public string lhpwchdsq
        {
            get { return _lhpwchdsq; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[劣化瓶位从横担算起]长度不能大于500!");
                if (_lhpwchdsq as object == null || !_lhpwchdsq.Equals(value))
                {
                    _lhpwchdsq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lhps
        /// 属性描述：劣化片数
        /// 字段信息：[lhps],nvarchar
        /// </summary>
        [DisplayNameAttribute("劣化片数")]
        public string lhps
        {
            get { return _lhps; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[劣化片数]长度不能大于50!");
                if (_lhps as object == null || !_lhps.Equals(value))
                {
                    _lhps = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ghrq
        /// 属性描述：更换日期
        /// 字段信息：[ghrq],datetime
        /// </summary>
        [DisplayNameAttribute("更换日期")]
        public DateTime ghrq
        {
            get { return _ghrq; }
            set
            {			
                if (_ghrq as object == null || !_ghrq.Equals(value))
                {
                    _ghrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fzr
        /// 属性描述：负责人
        /// 字段信息：[fzr],nvarchar
        /// </summary>
        [DisplayNameAttribute("负责人")]
        public string fzr
        {
            get { return _fzr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[负责人]长度不能大于50!");
                if (_fzr as object == null || !_fzr.Equals(value))
                {
                    _fzr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xghjyzxh
        /// 属性描述：新更换绝缘子型号
        /// 字段信息：[xghjyzxh],nvarchar
        /// </summary>
        [DisplayNameAttribute("新更换绝缘子型号")]
        public string xghjyzxh
        {
            get { return _xghjyzxh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[新更换绝缘子型号]长度不能大于50!");
                if (_xghjyzxh as object == null || !_xghjyzxh.Equals(value))
                {
                    _xghjyzxh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xghjyzzzc
        /// 属性描述：新更换绝缘子制造厂
        /// 字段信息：[xghjyzzzc],nvarchar
        /// </summary>
        [DisplayNameAttribute("新更换绝缘子制造厂")]
        public string xghjyzzzc
        {
            get { return _xghjyzzzc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[新更换绝缘子制造厂]长度不能大于50!");
                if (_xghjyzzzc as object == null || !_xghjyzzzc.Equals(value))
                {
                    _xghjyzzzc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lhjyzccrq
        /// 属性描述：劣化绝缘子出厂日期
        /// 字段信息：[lhjyzccrq],datetime
        /// </summary>
        [DisplayNameAttribute("劣化绝缘子出厂日期")]
        public DateTime lhjyzccrq
        {
            get { return _lhjyzccrq; }
            set
            {			
                if (_lhjyzccrq as object == null || !_lhjyzccrq.Equals(value))
                {
                    _lhjyzccrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lhjyzyxnx
        /// 属性描述：劣化绝缘子运行年限
        /// 字段信息：[lhjyzyxnx],nvarchar
        /// </summary>
        [DisplayNameAttribute("劣化绝缘子运行年限")]
        public string lhjyzyxnx
        {
            get { return _lhjyzyxnx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[劣化绝缘子运行年限]长度不能大于50!");
                if (_lhjyzyxnx as object == null || !_lhjyzyxnx.Equals(value))
                {
                    _lhjyzyxnx = value;
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
