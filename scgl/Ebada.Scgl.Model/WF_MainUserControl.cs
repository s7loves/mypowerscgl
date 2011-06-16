/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-6 10:33:22
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_MainUserControl]业务实体类
    ///对应表名:PS_MainUserControl
    /// </summary>
    [Serializable]
    public class WF_MainUserControl
    {
        
        #region Private 成员
        private string _mainuserctrlid=Newid(); 
        private string _muccaption=String.Empty; 
        private string _mucdescription=String.Empty; 
        private string _muctype=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：MainUserCtrlId
        /// 属性描述：
        /// 字段信息：[MainUserCtrlId],varchar
        /// </summary>
        [Browsable(false)]
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
        /// 属性名称：mucCaption
        /// 属性描述：
        /// 字段信息：[mucCaption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string mucCaption
        {
            get { return _muccaption; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_muccaption as object == null || !_muccaption.Equals(value))
                {
                    _muccaption = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：mucDescription
        /// 属性描述：
        /// 字段信息：[mucDescription],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string mucDescription
        {
            get { return _mucdescription; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_mucdescription as object == null || !_mucdescription.Equals(value))
                {
                    _mucdescription = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：mucType
        /// 属性描述：
        /// 字段信息：[mucType],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string mucType
        {
            get { return _muctype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_muctype as object == null || !_muctype.Equals(value))
                {
                    _muctype = value;
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
