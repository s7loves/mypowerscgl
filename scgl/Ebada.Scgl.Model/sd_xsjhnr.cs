/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-3-22 8:59:47
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sd_xsjhnr]业务实体类
    ///对应表名:sd_xsjhnr
    /// </summary>
    [Serializable]
    public class sd_xsjhnr
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _gtid=String.Empty; 
        private string _gtbh=String.Empty; 
        private string _flag1=String.Empty; 
        private string _lng=String.Empty; 
        private string _lat=String.Empty; 
        private string _flag2=String.Empty; 
        private string _xssj=String.Empty; 
        private string _qxnr=String.Empty; 
        private int _norder=0; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty; 
        private string _c4=String.Empty; 
        private string _c5=String.Empty;   
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
        /// 属性名称：ParentID
        /// 属性描述：
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
        /// 属性名称：gtid
        /// 属性描述：设备ID
        /// 字段信息：[gtid],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备ID")]
        public string gtid
        {
            get { return _gtid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备ID]长度不能大于50!");
                if (_gtid as object == null || !_gtid.Equals(value))
                {
                    _gtid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtbh
        /// 属性描述：杆塔编号
        /// 字段信息：[gtbh],nvarchar
        /// </summary>
        [DisplayNameAttribute("杆塔编号")]
        public string gtbh
        {
            get { return _gtbh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[杆塔编号]长度不能大于50!");
                if (_gtbh as object == null || !_gtbh.Equals(value))
                {
                    _gtbh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：flag1
        /// 属性描述：缺陷状态
        /// 字段信息：[flag1],nvarchar
        /// </summary>
        [DisplayNameAttribute("缺陷状态")]
        public string flag1
        {
            get { return _flag1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[缺陷状态]长度不能大于50!");
                if (_flag1 as object == null || !_flag1.Equals(value))
                {
                    _flag1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lng
        /// 属性描述：经度
        /// 字段信息：[lng],nvarchar
        /// </summary>
        [DisplayNameAttribute("经度")]
        public string lng
        {
            get { return _lng; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[经度]长度不能大于50!");
                if (_lng as object == null || !_lng.Equals(value))
                {
                    _lng = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lat
        /// 属性描述：纬度
        /// 字段信息：[lat],nvarchar
        /// </summary>
        [DisplayNameAttribute("纬度")]
        public string lat
        {
            get { return _lat; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[纬度]长度不能大于50!");
                if (_lat as object == null || !_lat.Equals(value))
                {
                    _lat = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：flag2
        /// 属性描述：巡视状态
        /// 字段信息：[flag2],nvarchar
        /// </summary>
        [DisplayNameAttribute("巡视状态")]
        public string flag2
        {
            get { return _flag2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[巡视状态]长度不能大于50!");
                if (_flag2 as object == null || !_flag2.Equals(value))
                {
                    _flag2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xssj
        /// 属性描述：巡视时间
        /// 字段信息：[xssj],nvarchar
        /// </summary>
        [DisplayNameAttribute("巡视时间")]
        public string xssj
        {
            get { return _xssj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[巡视时间]长度不能大于50!");
                if (_xssj as object == null || !_xssj.Equals(value))
                {
                    _xssj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qxnr
        /// 属性描述：缺陷内容
        /// 字段信息：[qxnr],nvarchar
        /// </summary>
        [DisplayNameAttribute("缺陷内容")]
        public string qxnr
        {
            get { return _qxnr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[缺陷内容]长度不能大于50!");
                if (_qxnr as object == null || !_qxnr.Equals(value))
                {
                    _qxnr = value;
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
        /// 属性描述：备
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c3
        /// 属性描述：备
        /// 字段信息：[c3],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c3
        {
            get { return _c3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c3 as object == null || !_c3.Equals(value))
                {
                    _c3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c4
        /// 属性描述：备
        /// 字段信息：[c4],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c4
        {
            get { return _c4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c4 as object == null || !_c4.Equals(value))
                {
                    _c4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c5
        /// 属性描述：备
        /// 字段信息：[c5],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c5
        {
            get { return _c5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
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
