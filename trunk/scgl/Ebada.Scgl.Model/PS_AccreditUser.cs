/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-10 8:43:24
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_AccreditUser]业务实体类
    ///对应表名:PS_AccreditUser
    /// </summary>
    [Serializable]
    public class PS_AccreditUser
    {
        
        #region Private 成员
        private string _auserid=Newid(); 
        private string _accreditfromuserid=String.Empty; 
        private string _accredittouserid=String.Empty; 
        private DateTime _accreditdatetime=new DateTime(1900,1,1); 
        private string _accreditstatus=String.Empty; 
        private string _acworkflowid=String.Empty; 
        private string _acworktaskid=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：AUserId
        /// 属性描述：
        /// 字段信息：[AUserId],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string AUserId
        {
            get { return _auserid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_auserid as object == null || !_auserid.Equals(value))
                {
                    _auserid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：AccreditFromUserId
        /// 属性描述：
        /// 字段信息：[AccreditFromUserId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string AccreditFromUserId
        {
            get { return _accreditfromuserid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[]长度不能大于10!");
                if (_accreditfromuserid as object == null || !_accreditfromuserid.Equals(value))
                {
                    _accreditfromuserid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：AccreditToUserId
        /// 属性描述：
        /// 字段信息：[AccreditToUserId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string AccreditToUserId
        {
            get { return _accredittouserid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[]长度不能大于10!");
                if (_accredittouserid as object == null || !_accredittouserid.Equals(value))
                {
                    _accredittouserid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：AccreditDateTime
        /// 属性描述：
        /// 字段信息：[AccreditDateTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime AccreditDateTime
        {
            get { return _accreditdatetime; }
            set
            {			
                if (_accreditdatetime as object == null || !_accreditdatetime.Equals(value))
                {
                    _accreditdatetime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：AccreditStatus
        /// 属性描述：
        /// 字段信息：[AccreditStatus],char
        /// </summary>
        [DisplayNameAttribute("")]
        public string AccreditStatus
        {
            get { return _accreditstatus; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1)
                throw new Exception("[]长度不能大于1!");
                if (_accreditstatus as object == null || !_accreditstatus.Equals(value))
                {
                    _accreditstatus = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：AcWorkflowId
        /// 属性描述：
        /// 字段信息：[AcWorkflowId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string AcWorkflowId
        {
            get { return _acworkflowid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_acworkflowid as object == null || !_acworkflowid.Equals(value))
                {
                    _acworkflowid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：AcWorktaskId
        /// 属性描述：
        /// 字段信息：[AcWorktaskId],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string AcWorktaskId
        {
            get { return _acworktaskid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_acworktaskid as object == null || !_acworktaskid.Equals(value))
                {
                    _acworktaskid = value;
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
