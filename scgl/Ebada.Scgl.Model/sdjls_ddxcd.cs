/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-4-25 9:39:18
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sdjls_ddxcd]业务实体类
    ///对应表名:sdjls_ddxcd
    /// </summary>
    [Serializable]
    public class sdjls_ddxcd
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _linecode=String.Empty; 
        private string _linename=String.Empty; 
        private string _linevol=String.Empty; 
        private string _nzdgh=String.Empty; 
        private string _cldgh=String.Empty; 
        private DateTime _clrq=new DateTime(1900,1,1); 
        private string _wd=String.Empty; 
        private string _dxscz=String.Empty; 
        private string _dxsczz=String.Empty; 
        private string _dxsczy=String.Empty; 
        private string _dxbzz=String.Empty; 
        private string _dxwcz=String.Empty; 
        private string _dxwczz=String.Empty; 
        private string _dxwcy=String.Empty; 
        private string _dxxh=String.Empty; 
        private string _ddxxh=String.Empty; 
        private string _ddxscz=String.Empty; 
        private string _ddxsczy=String.Empty; 
        private string _ddxbzz=String.Empty; 
        private string _ddwcz=String.Empty; 
        private string _ddwcy=String.Empty; 
        private string _dxjl=String.Empty; 
        private string _ddxjl=String.Empty; 
        private string _clr=String.Empty; 
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
        /// 属性描述：线路代码
        /// 字段信息：[LineCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路代码")]
        public string LineCode
        {
            get { return _linecode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路代码]长度不能大于50!");
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
        /// 属性名称：nzdgh
        /// 属性描述：耐张段杆号
        /// 字段信息：[nzdgh],nvarchar
        /// </summary>
        [DisplayNameAttribute("耐张段杆号")]
        public string nzdgh
        {
            get { return _nzdgh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[耐张段杆号]长度不能大于50!");
                if (_nzdgh as object == null || !_nzdgh.Equals(value))
                {
                    _nzdgh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cldgh
        /// 属性描述：测量档杆号
        /// 字段信息：[cldgh],nvarchar
        /// </summary>
        [DisplayNameAttribute("测量档杆号")]
        public string cldgh
        {
            get { return _cldgh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[测量档杆号]长度不能大于50!");
                if (_cldgh as object == null || !_cldgh.Equals(value))
                {
                    _cldgh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：clrq
        /// 属性描述：测量日期
        /// 字段信息：[clrq],datetime
        /// </summary>
        [DisplayNameAttribute("测量日期")]
        public DateTime clrq
        {
            get { return _clrq; }
            set
            {			
                if (_clrq as object == null || !_clrq.Equals(value))
                {
                    _clrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wd
        /// 属性描述：温度
        /// 字段信息：[wd],nvarchar
        /// </summary>
        [DisplayNameAttribute("温度")]
        public string wd
        {
            get { return _wd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[温度]长度不能大于50!");
                if (_wd as object == null || !_wd.Equals(value))
                {
                    _wd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dxscz
        /// 属性描述：导线实测值左
        /// 字段信息：[dxscz],nvarchar
        /// </summary>
        [DisplayNameAttribute("导线实测值左")]
        public string dxscz
        {
            get { return _dxscz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[导线实测值左]长度不能大于50!");
                if (_dxscz as object == null || !_dxscz.Equals(value))
                {
                    _dxscz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dxsczz
        /// 属性描述：导线实测值中
        /// 字段信息：[dxsczz],nvarchar
        /// </summary>
        [DisplayNameAttribute("导线实测值中")]
        public string dxsczz
        {
            get { return _dxsczz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[导线实测值中]长度不能大于50!");
                if (_dxsczz as object == null || !_dxsczz.Equals(value))
                {
                    _dxsczz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dxsczy
        /// 属性描述：导线实测值右
        /// 字段信息：[dxsczy],nvarchar
        /// </summary>
        [DisplayNameAttribute("导线实测值右")]
        public string dxsczy
        {
            get { return _dxsczy; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[导线实测值右]长度不能大于50!");
                if (_dxsczy as object == null || !_dxsczy.Equals(value))
                {
                    _dxsczy = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dxbzz
        /// 属性描述：导线标准值
        /// 字段信息：[dxbzz],nvarchar
        /// </summary>
        [DisplayNameAttribute("导线标准值")]
        public string dxbzz
        {
            get { return _dxbzz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[导线标准值]长度不能大于50!");
                if (_dxbzz as object == null || !_dxbzz.Equals(value))
                {
                    _dxbzz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dxwcz
        /// 属性描述：导线误差左
        /// 字段信息：[dxwcz],nvarchar
        /// </summary>
        [DisplayNameAttribute("导线误差左")]
        public string dxwcz
        {
            get { return _dxwcz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[导线误差左]长度不能大于50!");
                if (_dxwcz as object == null || !_dxwcz.Equals(value))
                {
                    _dxwcz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dxwczz
        /// 属性描述：导线误差中
        /// 字段信息：[dxwczz],nvarchar
        /// </summary>
        [DisplayNameAttribute("导线误差中")]
        public string dxwczz
        {
            get { return _dxwczz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[导线误差中]长度不能大于50!");
                if (_dxwczz as object == null || !_dxwczz.Equals(value))
                {
                    _dxwczz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dxwcy
        /// 属性描述：导线误差右
        /// 字段信息：[dxwcy],nvarchar
        /// </summary>
        [DisplayNameAttribute("导线误差右")]
        public string dxwcy
        {
            get { return _dxwcy; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[导线误差右]长度不能大于50!");
                if (_dxwcy as object == null || !_dxwcy.Equals(value))
                {
                    _dxwcy = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dxxh
        /// 属性描述：导线型号
        /// 字段信息：[dxxh],nvarchar
        /// </summary>
        [DisplayNameAttribute("导线型号")]
        public string dxxh
        {
            get { return _dxxh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[导线型号]长度不能大于50!");
                if (_dxxh as object == null || !_dxxh.Equals(value))
                {
                    _dxxh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ddxxh
        /// 属性描述：地线型号
        /// 字段信息：[ddxxh],nvarchar
        /// </summary>
        [DisplayNameAttribute("地线型号")]
        public string ddxxh
        {
            get { return _ddxxh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[地线型号]长度不能大于50!");
                if (_ddxxh as object == null || !_ddxxh.Equals(value))
                {
                    _ddxxh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ddxscz
        /// 属性描述：地线实测值左
        /// 字段信息：[ddxscz],nvarchar
        /// </summary>
        [DisplayNameAttribute("地线实测值左")]
        public string ddxscz
        {
            get { return _ddxscz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[地线实测值左]长度不能大于50!");
                if (_ddxscz as object == null || !_ddxscz.Equals(value))
                {
                    _ddxscz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ddxsczy
        /// 属性描述：地线实测值右
        /// 字段信息：[ddxsczy],nvarchar
        /// </summary>
        [DisplayNameAttribute("地线实测值右")]
        public string ddxsczy
        {
            get { return _ddxsczy; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[地线实测值右]长度不能大于50!");
                if (_ddxsczy as object == null || !_ddxsczy.Equals(value))
                {
                    _ddxsczy = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ddxbzz
        /// 属性描述：地线标准值
        /// 字段信息：[ddxbzz],nvarchar
        /// </summary>
        [DisplayNameAttribute("地线标准值")]
        public string ddxbzz
        {
            get { return _ddxbzz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[地线标准值]长度不能大于50!");
                if (_ddxbzz as object == null || !_ddxbzz.Equals(value))
                {
                    _ddxbzz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ddwcz
        /// 属性描述：地线误差左
        /// 字段信息：[ddwcz],nvarchar
        /// </summary>
        [DisplayNameAttribute("地线误差左")]
        public string ddwcz
        {
            get { return _ddwcz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[地线误差左]长度不能大于50!");
                if (_ddwcz as object == null || !_ddwcz.Equals(value))
                {
                    _ddwcz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ddwcy
        /// 属性描述：地线误差右
        /// 字段信息：[ddwcy],nvarchar
        /// </summary>
        [DisplayNameAttribute("地线误差右")]
        public string ddwcy
        {
            get { return _ddwcy; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[地线误差右]长度不能大于50!");
                if (_ddwcy as object == null || !_ddwcy.Equals(value))
                {
                    _ddwcy = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dxjl
        /// 属性描述：导线结论
        /// 字段信息：[dxjl],nvarchar
        /// </summary>
        [DisplayNameAttribute("导线结论")]
        public string dxjl
        {
            get { return _dxjl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[导线结论]长度不能大于50!");
                if (_dxjl as object == null || !_dxjl.Equals(value))
                {
                    _dxjl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ddxjl
        /// 属性描述：地线结论
        /// 字段信息：[ddxjl],nvarchar
        /// </summary>
        [DisplayNameAttribute("地线结论")]
        public string ddxjl
        {
            get { return _ddxjl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[地线结论]长度不能大于50!");
                if (_ddxjl as object == null || !_ddxjl.Equals(value))
                {
                    _ddxjl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：clr
        /// 属性描述：测量人
        /// 字段信息：[clr],nvarchar
        /// </summary>
        [DisplayNameAttribute("测量人")]
        public string clr
        {
            get { return _clr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[测量人]长度不能大于50!");
                if (_clr as object == null || !_clr.Equals(value))
                {
                    _clr = value;
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
