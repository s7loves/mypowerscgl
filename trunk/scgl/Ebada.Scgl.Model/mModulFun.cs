/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-17 22:06:06
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[mModulFun]业务实体类
    ///对应表名:mModulFun
    /// </summary>
    [Serializable]
    public class mModulFun
    {
        
        #region Private 成员
        private string _funid=Newid(); 
        private string _modu_id=String.Empty; 
        private string _funcode=String.Empty; 
        private string _funname=String.Empty; 
        private string _remark=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：FunID
        /// 属性描述：功能ID
        /// 字段信息：[FunID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("功能ID")]
        public string FunID
        {
            get { return _funid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[功能ID]长度不能大于50!");
                if (_funid as object == null || !_funid.Equals(value))
                {
                    _funid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Modu_ID
        /// 属性描述：Modu_ID
        /// 字段信息：[Modu_ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("Modu_ID")]
        public string Modu_ID
        {
            get { return _modu_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[Modu_ID]长度不能大于50!");
                if (_modu_id as object == null || !_modu_id.Equals(value))
                {
                    _modu_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FunCode
        /// 属性描述：功能编号
        /// 字段信息：[FunCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("功能编号")]
        public string FunCode
        {
            get { return _funcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[功能编号]长度不能大于50!");
                if (_funcode as object == null || !_funcode.Equals(value))
                {
                    _funcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FunName
        /// 属性描述：功能名称
        /// 字段信息：[FunName],nvarchar
        /// </summary>
        [DisplayNameAttribute("功能名称")]
        public string FunName
        {
            get { return _funname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[功能名称]长度不能大于50!");
                if (_funname as object == null || !_funname.Equals(value))
                {
                    _funname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Remark
        /// 属性描述：备注
        /// 字段信息：[Remark],nvarchar
        /// </summary>
        [DisplayNameAttribute("备注")]
        public string Remark
        {
            get { return _remark; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备注]长度不能大于50!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
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
