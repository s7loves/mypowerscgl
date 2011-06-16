/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-10 18:25:09
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_FrmworkParamer]业务实体类
    ///对应表名:PS_FrmworkParamer
    /// </summary>
    [Serializable]
    public class PS_FrmworkParamer
    {
        
        #region Private 成员
        private string _dbid=Newid(); 
        private string _flagcode=String.Empty; 
        private string _flagtext=String.Empty; 
        private string _flagvalue=String.Empty; 
        private string _memo=String.Empty; 
        private DateTime _createtime=new DateTime(1900,1,1);   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：DBId
        /// 属性描述：
        /// 字段信息：[DBId],char
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string DBId
        {
            get { return _dbid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 6)
                throw new Exception("[]长度不能大于6!");
                if (_dbid as object == null || !_dbid.Equals(value))
                {
                    _dbid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FlagCode
        /// 属性描述：
        /// 字段信息：[FlagCode],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string FlagCode
        {
            get { return _flagcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_flagcode as object == null || !_flagcode.Equals(value))
                {
                    _flagcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FlagText
        /// 属性描述：
        /// 字段信息：[FlagText],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string FlagText
        {
            get { return _flagtext; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_flagtext as object == null || !_flagtext.Equals(value))
                {
                    _flagtext = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FlagValue
        /// 属性描述：
        /// 字段信息：[FlagValue],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string FlagValue
        {
            get { return _flagvalue; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_flagvalue as object == null || !_flagvalue.Equals(value))
                {
                    _flagvalue = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Memo
        /// 属性描述：
        /// 字段信息：[Memo],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Memo
        {
            get { return _memo; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 100)
                throw new Exception("[]长度不能大于100!");
                if (_memo as object == null || !_memo.Equals(value))
                {
                    _memo = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateTime
        /// 属性描述：
        /// 字段信息：[CreateTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime CreateTime
        {
            get { return _createtime; }
            set
            {			
                if (_createtime as object == null || !_createtime.Equals(value))
                {
                    _createtime = value;
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
