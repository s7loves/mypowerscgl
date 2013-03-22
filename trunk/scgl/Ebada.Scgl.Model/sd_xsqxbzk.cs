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
    ///[sd_xsqxbzk]业务实体类
    ///对应表名:sd_xsqxbzk
    /// </summary>
    [Serializable]
    public class sd_xsqxbzk
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private int _norder=0; 
        private string _sbzl=String.Empty; 
        private string _qxzl=String.Empty; 
        private string _qxnr=String.Empty; 
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
        /// 属性名称：sbzl
        /// 属性描述：设备种类
        /// 字段信息：[sbzl],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备种类")]
        public string sbzl
        {
            get { return _sbzl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备种类]长度不能大于50!");
                if (_sbzl as object == null || !_sbzl.Equals(value))
                {
                    _sbzl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qxzl
        /// 属性描述：缺陷种类
        /// 字段信息：[qxzl],nvarchar
        /// </summary>
        [DisplayNameAttribute("缺陷种类")]
        public string qxzl
        {
            get { return _qxzl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[缺陷种类]长度不能大于50!");
                if (_qxzl as object == null || !_qxzl.Equals(value))
                {
                    _qxzl = value;
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
                if( value.ToString().Length > 150)
                throw new Exception("[缺陷内容]长度不能大于150!");
                if (_qxnr as object == null || !_qxnr.Equals(value))
                {
                    _qxnr = value;
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
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        public string CreateID(){
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        #endregion		
    }	
}
