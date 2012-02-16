/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012/2/12 15:53:26
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_XLSec]业务实体类
    ///对应表名:PS_XLSec
    /// </summary>
    [Serializable]
    public class PS_XLSec
    {
        
        #region Private 成员
        private string _id = Newid();
        private string _startgt=String.Empty; 
        private string _endgt=String.Empty; 
        private string _linetype=String.Empty;   
        #endregion
  
  
        #region Public 成员
        /// <summary>
        /// 属性名称：id
        /// 属性描述：ID
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("ID")]
        public string ID
        {
            get { return _id; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }
        }
        /// <summary>
        /// 属性名称：StartGT
        /// 属性描述：起始杆塔编号
        /// 字段信息：[StartGT],nvarchar
        /// </summary>
        [DisplayNameAttribute("起始杆塔编号")]
        public string StartGT
        {
            get { return _startgt; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[起始杆塔编号]长度不能大于50!");
                if (_startgt as object == null || !_startgt.Equals(value))
                {
                    _startgt = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：EndGT
        /// 属性描述：结束杆塔编号
        /// 字段信息：[EndGT],nvarchar
        /// </summary>
        [DisplayNameAttribute("结束杆塔编号")]
        public string EndGT
        {
            get { return _endgt; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[结束杆塔编号]长度不能大于50!");
                if (_endgt as object == null || !_endgt.Equals(value))
                {
                    _endgt = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineType
        /// 属性描述：导线型号
        /// 字段信息：[LineType],nvarchar
        /// </summary>
        [DisplayNameAttribute("导线型号")]
        public string LineType
        {
            get { return _linetype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[导线型号]长度不能大于50!");
                if (_linetype as object == null || !_linetype.Equals(value))
                {
                    _linetype = value;
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
