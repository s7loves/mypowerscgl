/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-26 20:54:00
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_tqsb]业务实体类
    ///对应表名:PS_tqsb
    /// </summary>
    [Serializable]
    public class PS_tj
    {
        
        #region Private 成员
        private string _smorg = String.Empty;
        private string _sbowner = String.Empty;
        private string _sbname=String.Empty;
        private string _sbtype = String.Empty;
        private int _sbnumber = 0;
        #endregion
  
  
        #region Public 成员
        /// <summary>
        /// 属性名称：单位
        /// 属性描述：所属单位
        /// 字段信息：[_smorg],nvarchar
        /// </summary>
        //[Browsable(false)]
        [DisplayNameAttribute("所属单位")]
        public string SmOrg
        {
            get { return _smorg; }
            set
            {
                if (value == null) return;
                if (_smorg as object == null || !_smorg.Equals(value))
                {
                    _smorg = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：所属设备
        /// 属性描述：线路/台区
        /// 字段信息：[_sbowner],nvarchar
        /// </summary>
        //[Browsable(false)]
        [DisplayNameAttribute("线路/台区")]
        public string SbOwner
        {
            get { return _sbowner; }
            set
            {
                if (value == null) return;
                if (_sbowner as object == null || !_sbowner.Equals(value))
                {
                    _sbowner = value;
                }
            }
        }
   
        /// <summary>
        /// 属性名称：名称
        /// 属性描述：设备名称
        /// 字段信息：[_sbname],nvarchar
        /// </summary>
        //[Browsable(false)]
        [DisplayNameAttribute("设备名称")]
        public string SbName
        {
            get { return _sbname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("设备名称长度不能大于50!");
                if (_sbname as object == null || !_sbname.Equals(value))
                {
                    _sbname = value;
                }
            }			 
        }

        /// <summary>
        /// 属性名称：型号
        /// 属性描述：设备型号
        /// 字段信息：[_sbtype],nvarchar
        /// </summary>
        //[Browsable(false)]
        [DisplayNameAttribute("设备型号")]
        public string SbType
        {
            get { return _sbtype; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("设备型号长度不能大于50!");
                if (_sbtype as object == null || !_sbtype.Equals(value))
                {
                    _sbtype = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：数量
        /// 属性描述：变压器数量
        /// 字段信息：[_byqnumber],int
        /// </summary>
        //[Browsable(false)]
        [DisplayNameAttribute("设备数量")]
        public int SBNumber
        {
            get { return _sbnumber; }
            set
            {
                _sbnumber = value;               
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
