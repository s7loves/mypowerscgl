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
    ///[sd_xsxm]业务实体类
    ///对应表名:sd_xsxm
    /// </summary>
    [Serializable]
    public class sd_xsxm
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _zl=String.Empty; 
        private string _mc=String.Empty; 
        private string _flag=String.Empty; 
        private DateTime _xssj=new DateTime(1900,1,1); 
        private int _norder=0; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty;   
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
        /// 属性名称：zl
        /// 属性描述：项目种类
        /// 字段信息：[zl],nvarchar
        /// </summary>
        [DisplayNameAttribute("项目种类")]
        public string zl
        {
            get { return _zl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[项目种类]长度不能大于50!");
                if (_zl as object == null || !_zl.Equals(value))
                {
                    _zl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：mc
        /// 属性描述：项目内容
        /// 字段信息：[mc],nvarchar
        /// </summary>
        [DisplayNameAttribute("项目内容")]
        public string mc
        {
            get { return _mc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[项目内容]长度不能大于50!");
                if (_mc as object == null || !_mc.Equals(value))
                {
                    _mc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：flag
        /// 属性描述：巡视状态
        /// 字段信息：[flag],nvarchar
        /// </summary>
        [DisplayNameAttribute("巡视状态")]
        public string flag
        {
            get { return _flag; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[巡视状态]长度不能大于50!");
                if (_flag as object == null || !_flag.Equals(value))
                {
                    _flag = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xssj
        /// 属性描述：巡视时间
        /// 字段信息：[xssj],datetime
        /// </summary>
        [DisplayNameAttribute("巡视时间")]
        public DateTime xssj
        {
            get { return _xssj; }
            set
            {			
                if (_xssj as object == null || !_xssj.Equals(value))
                {
                    _xssj = value;
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
