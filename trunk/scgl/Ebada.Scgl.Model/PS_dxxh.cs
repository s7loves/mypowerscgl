/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-7-25 20:34:39
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_dxxh]业务实体类
    ///对应表名:PS_dxxh
    /// </summary>
    [Serializable]
    public class PS_dxxh
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _dydj=String.Empty; 
        private string _dxxh=String.Empty; 
        private decimal _dwdz=0; 
        private decimal _jmj=0;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：ID
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
        /// 属性名称：dydj
        /// 属性描述：电压等级
        /// 字段信息：[dydj],nvarchar
        /// </summary>
        [DisplayNameAttribute("电压等级")]
        public string dydj
        {
            get { return _dydj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电压等级]长度不能大于50!");
                if (_dydj as object == null || !_dydj.Equals(value))
                {
                    _dydj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dxxh
        /// 属性描述：导线型号
        /// 字段信息：[dxxh],nvarchar
        /// </summary>
        [DisplayNameAttribute("导线型号")]
        public string dxxh
        {
            get { return _dxxh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[导线型号]长度不能大于50!");
                if (_dxxh as object == null || !_dxxh.Equals(value))
                {
                    _dxxh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dwdz
        /// 属性描述：单位电阻
        /// 字段信息：[dwdz],decimal
        /// </summary>
        [DisplayNameAttribute("单位电阻")]
        public decimal dwdz
        {
            get { return _dwdz; }
            set
            {			
                if (_dwdz as object == null || !_dwdz.Equals(value))
                {
                    _dwdz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jmj
        /// 属性描述：载面积
        /// 字段信息：[jmj],decimal
        /// </summary>
        [DisplayNameAttribute("载面积")]
        public decimal jmj
        {
            get { return _jmj; }
            set
            {			
                if (_jmj as object == null || !_jmj.Equals(value))
                {
                    _jmj = value;
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
