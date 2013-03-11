/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-3-11 9:59:45
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sd_tsqyzlsx]业务实体类
    ///对应表名:sd_tsqyzlsx
    /// </summary>
    [Serializable]
    public class sd_tsqyzlsx
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _zldm=String.Empty; 
        private string _sxcol=String.Empty; 
        private string _sxname=String.Empty; 
        private int _norder=0; 
        private string _vtype=String.Empty; 
        private string _ctype=String.Empty; 
        private string _defaultvalue=String.Empty; 
        private string _inittype=String.Empty; 
        private string _initsql=String.Empty; 
        private string _isdel=String.Empty; 
        private string _isedit=String.Empty; 
        private string _isuse=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
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
        /// 属性名称：zldm
        /// 属性描述：种类代码
        /// 字段信息：[zldm],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("种类代码")]
        public string zldm
        {
            get { return _zldm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[种类代码]长度不能大于50!");
                if (_zldm as object == null || !_zldm.Equals(value))
                {
                    _zldm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sxcol
        /// 属性描述：属性列
        /// 字段信息：[sxcol],nvarchar
        /// </summary>
        [DisplayNameAttribute("属性列")]
        public string sxcol
        {
            get { return _sxcol; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[属性列]长度不能大于50!");
                if (_sxcol as object == null || !_sxcol.Equals(value))
                {
                    _sxcol = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sxname
        /// 属性描述：属性名称
        /// 字段信息：[sxname],nvarchar
        /// </summary>
        [DisplayNameAttribute("属性名称")]
        public string sxname
        {
            get { return _sxname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[属性名称]长度不能大于50!");
                if (_sxname as object == null || !_sxname.Equals(value))
                {
                    _sxname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：norder
        /// 属性描述：序号
        /// 字段信息：[norder],int
        /// </summary>
        [DisplayNameAttribute("序号")]
        public int norder
        {
            get { return _norder; }
            set
            {			
                if (_norder as object == null || !_norder.Equals(value))
                {
                    _norder = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：vtype
        /// 属性描述：值类型
        /// 字段信息：[vtype],nvarchar
        /// </summary>
        [DisplayNameAttribute("值类型")]
        public string vtype
        {
            get { return _vtype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[值类型]长度不能大于50!");
                if (_vtype as object == null || !_vtype.Equals(value))
                {
                    _vtype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ctype
        /// 属性描述：控件类型
        /// 字段信息：[ctype],nvarchar
        /// </summary>
        [DisplayNameAttribute("控件类型")]
        public string ctype
        {
            get { return _ctype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[控件类型]长度不能大于50!");
                if (_ctype as object == null || !_ctype.Equals(value))
                {
                    _ctype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：defaultvalue
        /// 属性描述：默认值
        /// 字段信息：[defaultvalue],nvarchar
        /// </summary>
        [DisplayNameAttribute("默认值")]
        public string defaultvalue
        {
            get { return _defaultvalue; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[默认值]长度不能大于1073741823!");
                if (_defaultvalue as object == null || !_defaultvalue.Equals(value))
                {
                    _defaultvalue = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：inittype
        /// 属性描述：初始方式
        /// 字段信息：[inittype],nvarchar
        /// </summary>
        [DisplayNameAttribute("初始方式")]
        public string inittype
        {
            get { return _inittype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[初始方式]长度不能大于50!");
                if (_inittype as object == null || !_inittype.Equals(value))
                {
                    _inittype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：initsql
        /// 属性描述：初始查询
        /// 字段信息：[initsql],nvarchar
        /// </summary>
        [DisplayNameAttribute("初始查询")]
        public string initsql
        {
            get { return _initsql; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[初始查询]长度不能大于1073741823!");
                if (_initsql as object == null || !_initsql.Equals(value))
                {
                    _initsql = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：isdel
        /// 属性描述：可删除
        /// 字段信息：[isdel],nvarchar
        /// </summary>
        [DisplayNameAttribute("可删除")]
        public string isdel
        {
            get { return _isdel; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[可删除]长度不能大于50!");
                if (_isdel as object == null || !_isdel.Equals(value))
                {
                    _isdel = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：isedit
        /// 属性描述：可编辑
        /// 字段信息：[isedit],nvarchar
        /// </summary>
        [DisplayNameAttribute("可编辑")]
        public string isedit
        {
            get { return _isedit; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[可编辑]长度不能大于50!");
                if (_isedit as object == null || !_isedit.Equals(value))
                {
                    _isedit = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：isuse
        /// 属性描述：启用
        /// 字段信息：[isuse],nvarchar
        /// </summary>
        [DisplayNameAttribute("启用")]
        public string isuse
        {
            get { return _isuse; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[启用]长度不能大于50!");
                if (_isuse as object == null || !_isuse.Equals(value))
                {
                    _isuse = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c1
        /// 属性描述：备
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c2
        /// 属性描述：备2
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备2")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备2]长度不能大于50!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
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
