/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-2-27 16:51:06
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[DB_SBTZ_SX]业务实体类
    ///对应表名:DB_SBTZ_SX
    /// </summary>
    [Serializable]
    public class DB_SBTZ_SX
    {
        
        #region Private 成员
        private int _id=0; 
        private string _zldm=String.Empty; 
        private string _sxcol=String.Empty; 
        private string _sxname=String.Empty; 
        private string _sxtype=String.Empty; 
        private string _norder=String.Empty; 
        private string _isvisible=("是"); 
        private string _defaultvalue=String.Empty; 
        private string _boxtype=("value"); 
        private string _boxvalue=String.Empty; 
        private string _isdel=("是"); 
        private string _isedit=("是"); 
        private string _c1=String.Empty; 
        private string _c2=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：id
        /// 属性描述：
        /// 字段信息：[id],int
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("id")]
        public int id
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
        /// 属性名称：zldm
        /// 属性描述：
        /// 字段信息：[zldm],nvarchar
        /// </summary>
        [DisplayNameAttribute("zldm")]
        public string zldm
        {
            get { return _zldm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[zldm]长度不能大于50!");
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
        /// 属性描述：属性名
        /// 字段信息：[sxname],nvarchar
        /// </summary>
        [DisplayNameAttribute("属性名")]
        public string sxname
        {
            get { return _sxname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[属性名]长度不能大于50!");
                if (_sxname as object == null || !_sxname.Equals(value))
                {
                    _sxname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sxtype
        /// 属性描述：属性类型,0-文本 1-下拉列表 2-日期
        /// 字段信息：[sxtype],nvarchar
        /// </summary>
        [DisplayNameAttribute("属性类型")]
        public string sxtype
        {
            get { return _sxtype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[属性类型]长度不能大于50!");
                if (_sxtype as object == null || !_sxtype.Equals(value))
                {
                    _sxtype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：norder
        /// 属性描述：显示顺序
        /// 字段信息：[norder],nvarchar
        /// </summary>
        [DisplayNameAttribute("显示顺序")]
        public string norder
        {
            get { return _norder; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[显示顺序]长度不能大于50!");
                if (_norder as object == null || !_norder.Equals(value))
                {
                    _norder = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：isvisible
        /// 属性描述：是否显示
        /// 字段信息：[isvisible],nvarchar
        /// </summary>
        [DisplayNameAttribute("是否显示")]
        public string isvisible
        {
            get { return _isvisible; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[是否显示]长度不能大于50!");
                if (_isvisible as object == null || !_isvisible.Equals(value))
                {
                    _isvisible = value;
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
                if( value.ToString().Length > 50)
                throw new Exception("[默认值]长度不能大于50!");
                if (_defaultvalue as object == null || !_defaultvalue.Equals(value))
                {
                    _defaultvalue = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：boxtype
        /// 属性描述：下拉列表取值方式,value-字符串|分割,sql-查询语句
        /// 字段信息：[boxtype],nvarchar
        /// </summary>
        [DisplayNameAttribute("下拉列表取值方式")]
        public string boxtype
        {
            get { return _boxtype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[下拉列表取值方式]长度不能大于50!");
                if (_boxtype as object == null || !_boxtype.Equals(value))
                {
                    _boxtype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：boxvalue
        /// 属性描述：下拉列表数据集
        /// 字段信息：[boxvalue],nvarchar
        /// </summary>
        [DisplayNameAttribute("下拉列表数据集")]
        public string boxvalue
        {
            get { return _boxvalue; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[下拉列表数据集]长度不能大于50!");
                if (_boxvalue as object == null || !_boxvalue.Equals(value))
                {
                    _boxvalue = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：isdel
        /// 属性描述：是否可删除
        /// 字段信息：[isdel],nvarchar
        /// </summary>
        [DisplayNameAttribute("是否可删除")]
        public string isdel
        {
            get { return _isdel; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[是否可删除]长度不能大于50!");
                if (_isdel as object == null || !_isdel.Equals(value))
                {
                    _isdel = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：isedit
        /// 属性描述：是否可修改
        /// 字段信息：[isedit],nvarchar
        /// </summary>
        [DisplayNameAttribute("是否可修改")]
        public string isedit
        {
            get { return _isedit; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[是否可修改]长度不能大于50!");
                if (_isedit as object == null || !_isedit.Equals(value))
                {
                    _isedit = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c1
        /// 属性描述：
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [DisplayNameAttribute("c1")]
        public string c1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[c1]长度不能大于50!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c2
        /// 属性描述：
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [DisplayNameAttribute("c2")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[c2]长度不能大于50!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
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
