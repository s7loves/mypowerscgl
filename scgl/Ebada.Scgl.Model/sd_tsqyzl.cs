/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-3-11 9:59:45
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sd_tsqyzl]业务实体类
    ///对应表名:sd_tsqyzl
    /// </summary>
    [Serializable]
    public class sd_tsqyzl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _zldm=String.Empty; 
        private string _zlmc=String.Empty; 
        private string _isuse=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
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
        /// 属性名称：zldm
        /// 属性描述：种类代码
        /// 字段信息：[zldm],nvarchar
        /// </summary>
        [DisplayNameAttribute("种类代码")]
        public string zldm
        {
            get { return _zldm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[种类代码]长度不能大于50!");
                if (_zldm as object == null || !_zldm.Equals(value))
                {
                    _zldm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zlmc
        /// 属性描述：种类名称
        /// 字段信息：[zlmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("种类名称")]
        public string zlmc
        {
            get { return _zlmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[种类名称]长度不能大于50!");
                if (_zlmc as object == null || !_zlmc.Equals(value))
                {
                    _zlmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：isuse
        /// 属性描述：启用
        /// 字段信息：[isuse],nvarchar
        /// </summary>
        [DisplayNameAttribute("启用")]
        public string isuse
        {
            get { return _isuse; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[启用]长度不能大于50!");
                if (_isuse as object == null || !_isuse.Equals(value))
                {
                    _isuse = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c1
        /// 属性描述：备
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c2
        /// 属性描述：备2
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备2")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备2]长度不能大于50!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        #endregion 
  
        #region 方法
        public static string Newid(){
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        public string CreateID(){
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        #endregion		
    }	
}
