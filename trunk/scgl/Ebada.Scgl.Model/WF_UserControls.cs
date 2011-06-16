/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-6 11:09:16
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_UserControls]业务实体类
    ///对应表名:PS_UserControls
    /// </summary>
    [Serializable]
    public class WF_UserControls
    {
        
        #region Private 成员
        private string _usercontrolid=Newid(); 
        private string _uccaption=String.Empty; 
        private string _ucpath=String.Empty; 
        private string _ucid=String.Empty; 
        private string _ucdescription=String.Empty; 
        private string _uctype=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：UserControlId
        /// 属性描述：
        /// 字段信息：[UserControlId],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string UserControlId
        {
            get { return _usercontrolid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_usercontrolid as object == null || !_usercontrolid.Equals(value))
                {
                    _usercontrolid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ucCaption
        /// 属性描述：
        /// 字段信息：[ucCaption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ucCaption
        {
            get { return _uccaption; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_uccaption as object == null || !_uccaption.Equals(value))
                {
                    _uccaption = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ucPath
        /// 属性描述：
        /// 字段信息：[ucPath],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ucPath
        {
            get { return _ucpath; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_ucpath as object == null || !_ucpath.Equals(value))
                {
                    _ucpath = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ucID
        /// 属性描述：
        /// 字段信息：[ucID],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ucID
        {
            get { return _ucid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_ucid as object == null || !_ucid.Equals(value))
                {
                    _ucid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ucDescription
        /// 属性描述：
        /// 字段信息：[ucDescription],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ucDescription
        {
            get { return _ucdescription; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_ucdescription as object == null || !_ucdescription.Equals(value))
                {
                    _ucdescription = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ucType
        /// 属性描述：
        /// 字段信息：[ucType],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ucType
        {
            get { return _uctype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_uctype as object == null || !_uctype.Equals(value))
                {
                    _uctype = value;
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
