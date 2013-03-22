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
    ///[sd_xsimage]业务实体类
    ///对应表名:sd_xsimage
    /// </summary>
    [Serializable]
    public class sd_xsimage
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _gtid=String.Empty; 
        private int _norder=0; 
        private string _des=String.Empty; 
        private byte[] _data=new byte[]{}; 
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
        /// 属性名称：ParentID
        /// 属性描述：任务ID
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("任务ID")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[任务ID]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtID
        /// 属性描述：
        /// 字段信息：[gtID],nvarchar
        /// </summary>
        [DisplayNameAttribute("gtID")]
        public string gtID
        {
            get { return _gtid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[gtID]长度不能大于50!");
                if (_gtid as object == null || !_gtid.Equals(value))
                {
                    _gtid = value;
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
        /// 属性名称：des
        /// 属性描述：描述
        /// 字段信息：[des],nvarchar
        /// </summary>
        [DisplayNameAttribute("描述")]
        public string des
        {
            get { return _des; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[描述]长度不能大于50!");
                if (_des as object == null || !_des.Equals(value))
                {
                    _des = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：data
        /// 属性描述：照片
        /// 字段信息：[data],image
        /// </summary>
        [DisplayNameAttribute("照片")]
        public byte[] data
        {
            get { return _data; }
            set
            {			
                if (_data as object == null || !_data.Equals(value))
                {
                    _data = value;
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
