/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-5 20:40:46
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_WorkFlowClass]业务实体类
    ///对应表名:PS_WorkFlowClass
    /// </summary>
    [Serializable]
    public class PS_WorkFlowClass
    {
        
        #region Private 成员
        private string _wfclassid=Newid(); 
        private string _caption=String.Empty; 
        private string _fatherid=String.Empty; 
        private string _description=String.Empty; 
        private int _cllevel=0; 
        private string _clmgrurl=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：WFClassId
        /// 属性描述：
        /// 字段信息：[WFClassId],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string WFClassId
        {
            get { return _wfclassid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_wfclassid as object == null || !_wfclassid.Equals(value))
                {
                    _wfclassid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Caption
        /// 属性描述：
        /// 字段信息：[Caption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Caption
        {
            get { return _caption; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 128)
                throw new Exception("[]长度不能大于128!");
                if (_caption as object == null || !_caption.Equals(value))
                {
                    _caption = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FatherId
        /// 属性描述：
        /// 字段信息：[FatherId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string FatherId
        {
            get { return _fatherid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_fatherid as object == null || !_fatherid.Equals(value))
                {
                    _fatherid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Description
        /// 属性描述：
        /// 字段信息：[Description],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Description
        {
            get { return _description; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_description as object == null || !_description.Equals(value))
                {
                    _description = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：clLevel
        /// 属性描述：
        /// 字段信息：[clLevel],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int clLevel
        {
            get { return _cllevel; }
            set
            {			
                if (_cllevel as object == null || !_cllevel.Equals(value))
                {
                    _cllevel = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：clMgrUrl
        /// 属性描述：
        /// 字段信息：[clMgrUrl],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string clMgrUrl
        {
            get { return _clmgrurl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 512)
                throw new Exception("[]长度不能大于512!");
                if (_clmgrurl as object == null || !_clmgrurl.Equals(value))
                {
                    _clmgrurl = value;
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
