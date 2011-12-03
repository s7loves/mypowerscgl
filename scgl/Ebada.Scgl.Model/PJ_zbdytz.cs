/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-12-3 20:52:13
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_zbdytz]业务实体类
    ///对应表名:PJ_zbdytz
    /// </summary>
    [Serializable]
    public class PJ_zbdytz
    {
        
        #region Private 成员
        private string _id = Newid();
        private string _khmc = String.Empty;
        private string _khdd = String.Empty;
        private string _zdyorgname = String.Empty;
        private string _zdylinename = String.Empty;
        private string _zdykgmodle = String.Empty;
        private string _zbdytype = String.Empty;
        private string _zbdymodle = String.Empty;
        private string _zbdyrl = String.Empty;
        private string _kgfs = String.Empty;
        private string _remark = String.Empty;
        private string _zbr = String.Empty;
        private string _chargeman = String.Empty;   
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
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：khmc
        /// 属性描述：
        /// 字段信息：[khmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("客户名称")]
        public string khmc
        {
            get { return _khmc; }
            set
            {			
                if (_khmc as object == null || !_khmc.Equals(value))
                {
                    _khmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：khdd
        /// 属性描述：
        /// 字段信息：[khdd],nvarchar
        /// </summary>
        [DisplayNameAttribute("客户地址")]
        public string khdd
        {
            get { return _khdd; }
            set
            {			
                if (_khdd as object == null || !_khdd.Equals(value))
                {
                    _khdd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zdyOrgName
        /// 属性描述：
        /// 字段信息：[zdyOrgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("主电源所属变电所")]
        public string zdyOrgName
        {
            get { return _zdyorgname; }
            set
            {			
                if (_zdyorgname as object == null || !_zdyorgname.Equals(value))
                {
                    _zdyorgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zdyLineName
        /// 属性描述：
        /// 字段信息：[zdyLineName],nvarchar
        /// </summary>
        [DisplayNameAttribute("主电源所属线路")]
        public string zdyLineName
        {
            get { return _zdylinename; }
            set
            {			
                if (_zdylinename as object == null || !_zdylinename.Equals(value))
                {
                    _zdylinename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zdykgModle
        /// 属性描述：
        /// 字段信息：[zdykgModle],nvarchar
        /// </summary>
        [DisplayNameAttribute("副电源开关型号")]
        public string zdykgModle
        {
            get { return _zdykgmodle; }
            set
            {			
                if (_zdykgmodle as object == null || !_zdykgmodle.Equals(value))
                {
                    _zdykgmodle = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zbdytype
        /// 属性描述：自备电源类型
        /// 字段信息：[zbdytype],nvarchar
        /// </summary>
        [DisplayNameAttribute("自备电源类型")]
        public string zbdytype
        {
            get { return _zbdytype; }
            set
            {			
                if (_zbdytype as object == null || !_zbdytype.Equals(value))
                {
                    _zbdytype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zbdyModle
        /// 属性描述：自备电源型号
        /// 字段信息：[zbdyModle],nvarchar
        /// </summary>
        [DisplayNameAttribute("自备电源型号")]
        public string zbdyModle
        {
            get { return _zbdymodle; }
            set
            {			
                if (_zbdymodle as object == null || !_zbdymodle.Equals(value))
                {
                    _zbdymodle = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zbdyrl
        /// 属性描述：自备电源容量
        /// 字段信息：[zbdyrl],nvarchar
        /// </summary>
        [DisplayNameAttribute("自备电源容量")]
        public string zbdyrl
        {
            get { return _zbdyrl; }
            set
            {			
                if (_zbdyrl as object == null || !_zbdyrl.Equals(value))
                {
                    _zbdyrl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgfs
        /// 属性描述：
        /// 字段信息：[kgfs],nvarchar
        /// </summary>
        [DisplayNameAttribute("双电源开关与电网电源开关是否互锁")]
        public string kgfs
        {
            get { return _kgfs; }
            set
            {			
                if (_kgfs as object == null || !_kgfs.Equals(value))
                {
                    _kgfs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zbr
        /// 属性描述：填表人
        /// 字段信息：[zbr],nvarchar
        /// </summary>
        [DisplayNameAttribute("填表人")]
        public string zbr
        {
            get { return _zbr; }
            set
            {			
                if (_zbr as object == null || !_zbr.Equals(value))
                {
                    _zbr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：chargeman
        /// 属性描述：审核人
        /// 字段信息：[chargeman],nvarchar
        /// </summary>
        [DisplayNameAttribute("审核人")]
        public string chargeman
        {
            get { return _chargeman; }
            set
            {			
                if (_chargeman as object == null || !_chargeman.Equals(value))
                {
                    _chargeman = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：Remark
        /// 属性描述：
        /// 字段信息：[Remark],nvarchar
        /// </summary>
        [DisplayNameAttribute("备注")]
        public string Remark
        {
            get { return _remark; }
            set
            {
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
