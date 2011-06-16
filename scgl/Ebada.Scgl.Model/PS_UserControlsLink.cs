/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-6 10:50:22
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_UserControlsLink]业务实体类
    ///对应表名:PS_UserControlsLink
    /// </summary>
    [Serializable]
    public class PS_UserControlsLink
    {
        
        #region Private 成员
        private string _muclinkid=Newid(); 
        private string _usercontrolid=String.Empty; 
        private string _mainuserctrlid=String.Empty; 
        private int _ctrlordernbr=0; 
        private string _ctrlstate=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：mucLinkId
        /// 属性描述：
        /// 字段信息：[mucLinkId],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string mucLinkId
        {
            get { return _muclinkid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_muclinkid as object == null || !_muclinkid.Equals(value))
                {
                    _muclinkid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserControlId
        /// 属性描述：
        /// 字段信息：[UserControlId],varchar
        /// </summary>
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
        /// 属性名称：MainUserCtrlId
        /// 属性描述：
        /// 字段信息：[MainUserCtrlId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string MainUserCtrlId
        {
            get { return _mainuserctrlid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_mainuserctrlid as object == null || !_mainuserctrlid.Equals(value))
                {
                    _mainuserctrlid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CtrlOrderNbr
        /// 属性描述：
        /// 字段信息：[CtrlOrderNbr],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int CtrlOrderNbr
        {
            get { return _ctrlordernbr; }
            set
            {			
                if (_ctrlordernbr as object == null || !_ctrlordernbr.Equals(value))
                {
                    _ctrlordernbr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CtrlState
        /// 属性描述：
        /// 字段信息：[CtrlState],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string CtrlState
        {
            get { return _ctrlstate; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_ctrlstate as object == null || !_ctrlstate.Equals(value))
                {
                    _ctrlstate = value;
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
