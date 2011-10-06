/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-10-6 10:57:48
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_lcspyj]业务实体类
    ///对应表名:PJ_lcspyj
    /// </summary>
    [Serializable]
    public class PJ_lcspyj
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _recordid=String.Empty; 
        private string _taskid=String.Empty; 
        private string _spyj=String.Empty; 
        private string _charman=String.Empty; 
        private DateTime _creattime=new DateTime(1900,1,1); 
        private string _reserve1=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RecordID
        /// 属性描述：
        /// 字段信息：[RecordID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string RecordID
        {
            get { return _recordid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_recordid as object == null || !_recordid.Equals(value))
                {
                    _recordid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：taskID
        /// 属性描述：填写审批意见的流程节点实例ID
        /// 字段信息：[taskID],nvarchar
        /// </summary>
        [DisplayNameAttribute("填写审批意见的流程节点实例ID")]
        public string taskID
        {
            get { return _taskid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[填写审批意见的流程节点实例ID]长度不能大于50!");
                if (_taskid as object == null || !_taskid.Equals(value))
                {
                    _taskid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Spyj
        /// 属性描述：审批意见
        /// 字段信息：[Spyj],nvarchar
        /// </summary>
        [DisplayNameAttribute("审批意见")]
        public string Spyj
        {
            get { return _spyj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[审批意见]长度不能大于1073741823!");
                if (_spyj as object == null || !_spyj.Equals(value))
                {
                    _spyj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Charman
        /// 属性描述：填写人
        /// 字段信息：[Charman],nvarchar
        /// </summary>
        [DisplayNameAttribute("填写人")]
        public string Charman
        {
            get { return _charman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[填写人]长度不能大于50!");
                if (_charman as object == null || !_charman.Equals(value))
                {
                    _charman = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Creattime
        /// 属性描述：审批时间
        /// 字段信息：[Creattime],datetime
        /// </summary>
        [DisplayNameAttribute("审批时间")]
        public DateTime Creattime
        {
            get { return _creattime; }
            set
            {			
                if (_creattime as object == null || !_creattime.Equals(value))
                {
                    _creattime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Reserve1
        /// 属性描述：备用字段1
        /// 字段信息：[Reserve1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段1")]
        public string Reserve1
        {
            get { return _reserve1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用字段1]长度不能大于50!");
                if (_reserve1 as object == null || !_reserve1.Equals(value))
                {
                    _reserve1 = value;
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
