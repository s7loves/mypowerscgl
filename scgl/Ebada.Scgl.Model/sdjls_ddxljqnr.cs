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
    ///[sdjls_ddxljqnr]业务实体类
    ///对应表名:sdjls_ddxljqnr
    /// </summary>
    [Serializable]
    public class sdjls_ddxljqnr
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _gth=String.Empty; 
        private string _dj=String.Empty; 
        private string _xb=String.Empty; 
        private string _ljxs=String.Empty; 
        private string _djzwz=String.Empty; 
        private string _ddxxh=String.Empty; 
        private string _ljqxh=String.Empty; 
        private string _sccj=String.Empty; 
        private string _qw=String.Empty; 
        private string _bz=String.Empty; 
        private string _cwsssdl=String.Empty; 
        private string _jcr=String.Empty; 
        private string _jl=String.Empty; 
        private string _gw=String.Empty; 
        private string _xw=String.Empty; 
        private string _dzx=String.Empty; 
        private string _dzg=String.Empty; 
        private string _dzb=String.Empty; 
        private string _bdzq=String.Empty; 
        private string _bdzh=String.Empty; 
        private string _bdzb=String.Empty; 
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
        /// 属性名称：ParentID
        /// 属性描述：父表ID
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("父表ID")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[父表ID]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gth
        /// 属性描述：杆塔号
        /// 字段信息：[gth],nvarchar
        /// </summary>
        [DisplayNameAttribute("杆塔号")]
        public string gth
        {
            get { return _gth; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[杆塔号]长度不能大于50!");
                if (_gth as object == null || !_gth.Equals(value))
                {
                    _gth = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dj
        /// 属性描述：档距(米)
        /// 字段信息：[dj],nvarchar
        /// </summary>
        [DisplayNameAttribute("档距(米)")]
        public string dj
        {
            get { return _dj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[档距(米)]长度不能大于50!");
                if (_dj as object == null || !_dj.Equals(value))
                {
                    _dj = value;
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
                if( value.ToString().Length > 50)
                throw new Exception("[相别]长度不能大于50!");
                if (_xb as object == null || !_xb.Equals(value))
                {
                    _xb = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ljxs
        /// 属性描述：连接型式
        /// 字段信息：[ljxs],nvarchar
        /// </summary>
        [DisplayNameAttribute("连接型式")]
        public string ljxs
        {
            get { return _ljxs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[连接型式]长度不能大于50!");
                if (_ljxs as object == null || !_ljxs.Equals(value))
                {
                    _ljxs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：djzwz
        /// 属性描述：档距中位置
        /// 字段信息：[djzwz],nvarchar
        /// </summary>
        [DisplayNameAttribute("档距中位置")]
        public string djzwz
        {
            get { return _djzwz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[档距中位置]长度不能大于50!");
                if (_djzwz as object == null || !_djzwz.Equals(value))
                {
                    _djzwz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ddxxh
        /// 属性描述：导(地)线型号
        /// 字段信息：[ddxxh],nvarchar
        /// </summary>
        [DisplayNameAttribute("导(地)线型号")]
        public string ddxxh
        {
            get { return _ddxxh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[导(地)线型号]长度不能大于50!");
                if (_ddxxh as object == null || !_ddxxh.Equals(value))
                {
                    _ddxxh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ljqxh
        /// 属性描述：连接器型号
        /// 字段信息：[ljqxh],nvarchar
        /// </summary>
        [DisplayNameAttribute("连接器型号")]
        public string ljqxh
        {
            get { return _ljqxh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[连接器型号]长度不能大于50!");
                if (_ljqxh as object == null || !_ljqxh.Equals(value))
                {
                    _ljqxh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sccj
        /// 属性描述：生产厂家
        /// 字段信息：[sccj],nvarchar
        /// </summary>
        [DisplayNameAttribute("生产厂家")]
        public string sccj
        {
            get { return _sccj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[生产厂家]长度不能大于50!");
                if (_sccj as object == null || !_sccj.Equals(value))
                {
                    _sccj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qw
        /// 属性描述：气温
        /// 字段信息：[qw],nvarchar
        /// </summary>
        [DisplayNameAttribute("气温")]
        public string qw
        {
            get { return _qw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[气温]长度不能大于50!");
                if (_qw as object == null || !_qw.Equals(value))
                {
                    _qw = value;
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
                if( value.ToString().Length > 50)
                throw new Exception("[备注]长度不能大于50!");
                if (_bz as object == null || !_bz.Equals(value))
                {
                    _bz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cwsssdl
        /// 属性描述：测温时输送电流
        /// 字段信息：[cwsssdl],nvarchar
        /// </summary>
        [DisplayNameAttribute("测温时输送电流")]
        public string cwsssdl
        {
            get { return _cwsssdl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[测温时输送电流]长度不能大于50!");
                if (_cwsssdl as object == null || !_cwsssdl.Equals(value))
                {
                    _cwsssdl = value;
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
        /// 属性名称：jl
        /// 属性描述：结论
        /// 字段信息：[jl],nvarchar
        /// </summary>
        [DisplayNameAttribute("结论")]
        public string jl
        {
            get { return _jl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[结论]长度不能大于50!");
                if (_jl as object == null || !_jl.Equals(value))
                {
                    _jl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gw
        /// 属性描述：管温
        /// 字段信息：[gw],nvarchar
        /// </summary>
        [DisplayNameAttribute("管温")]
        public string gw
        {
            get { return _gw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[管温]长度不能大于50!");
                if (_gw as object == null || !_gw.Equals(value))
                {
                    _gw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xw
        /// 属性描述：线温
        /// 字段信息：[xw],nvarchar
        /// </summary>
        [DisplayNameAttribute("线温")]
        public string xw
        {
            get { return _xw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线温]长度不能大于50!");
                if (_xw as object == null || !_xw.Equals(value))
                {
                    _xw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dzx
        /// 属性描述：线
        /// 字段信息：[dzx],nvarchar
        /// </summary>
        [DisplayNameAttribute("线")]
        public string dzx
        {
            get { return _dzx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线]长度不能大于50!");
                if (_dzx as object == null || !_dzx.Equals(value))
                {
                    _dzx = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dzg
        /// 属性描述：管
        /// 字段信息：[dzg],nvarchar
        /// </summary>
        [DisplayNameAttribute("管")]
        public string dzg
        {
            get { return _dzg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[管]长度不能大于50!");
                if (_dzg as object == null || !_dzg.Equals(value))
                {
                    _dzg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dzb
        /// 属性描述：比
        /// 字段信息：[dzb],nvarchar
        /// </summary>
        [DisplayNameAttribute("比")]
        public string dzb
        {
            get { return _dzb; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[比]长度不能大于50!");
                if (_dzb as object == null || !_dzb.Equals(value))
                {
                    _dzb = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bdzq
        /// 属性描述：前
        /// 字段信息：[bdzq],nvarchar
        /// </summary>
        [DisplayNameAttribute("前")]
        public string bdzq
        {
            get { return _bdzq; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[前]长度不能大于50!");
                if (_bdzq as object == null || !_bdzq.Equals(value))
                {
                    _bdzq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bdzh
        /// 属性描述：后
        /// 字段信息：[bdzh],nvarchar
        /// </summary>
        [DisplayNameAttribute("后")]
        public string bdzh
        {
            get { return _bdzh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[后]长度不能大于50!");
                if (_bdzh as object == null || !_bdzh.Equals(value))
                {
                    _bdzh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bdzb
        /// 属性描述：比
        /// 字段信息：[bdzb],nvarchar
        /// </summary>
        [DisplayNameAttribute("比")]
        public string bdzb
        {
            get { return _bdzb; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[比]长度不能大于50!");
                if (_bdzb as object == null || !_bdzb.Equals(value))
                {
                    _bdzb = value;
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
