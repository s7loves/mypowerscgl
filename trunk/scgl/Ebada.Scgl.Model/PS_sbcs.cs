/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-6-3 16:43:30
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_sbcs]业务实体类
    ///对应表名:PS_sbcs
    /// </summary>
    [Serializable]
    public class PS_sbcs
    {
        
        #region Private 成员
        private string _bh=String.Empty; 
        private string _mc=String.Empty; 
        private string _xh=String.Empty; 
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：bh
        /// 属性描述：种类编号
        /// 字段信息：[bh],nvarchar
        /// </summary>
        [DisplayNameAttribute("种类编号")]
        public string bh
        {
            get { return _bh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[种类编号]长度不能大于50!");
                if (_bh as object == null || !_bh.Equals(value))
                {
                    _bh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：mc
        /// 属性描述：种类名称
        /// 字段信息：[mc],nvarchar
        /// </summary>
        [DisplayNameAttribute("种类名称")]
        public string mc
        {
            get { return _mc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[种类名称]长度不能大于50!");
                if (_mc as object == null || !_mc.Equals(value))
                {
                    _mc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xh
        /// 属性描述：设备型号
        /// 字段信息：[xh],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备型号")]
        public string xh
        {
            get { return _xh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备型号]长度不能大于50!");
                if (_xh as object == null || !_xh.Equals(value))
                {
                    _xh = value;
                }
            }			 
        }
  
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
        /// 属性名称：c1
        /// 属性描述：分类,设备、材料
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [DisplayNameAttribute("分类")]
        public string c1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[分类]长度不能大于50!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c2
        /// 属性描述：预留
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [DisplayNameAttribute("预留")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[预留]长度不能大于50!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c3
        /// 属性描述：预留
        /// 字段信息：[c3],nvarchar
        /// </summary>
        [DisplayNameAttribute("预留")]
        public string c3
        {
            get { return _c3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[预留]长度不能大于50!");
                if (_c3 as object == null || !_c3.Equals(value))
                {
                    _c3 = value;
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
