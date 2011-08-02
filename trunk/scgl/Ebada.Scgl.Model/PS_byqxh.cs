/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-7-25 20:33:52
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_byqxh]业务实体类
    ///对应表名:PS_byqxh
    /// </summary>
    [Serializable]
    public class PS_byqxh
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _byqmodle=String.Empty; 
        private string _byqvol=String.Empty; 
        private int _byqcapcity=0; 
        private decimal _loss1=0; 
        private decimal _loss2=0; 
        private decimal _ratedcurrent=0;   
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
        /// 属性名称：byqModle
        /// 属性描述：变压器型号
        /// 字段信息：[byqModle],nvarchar
        /// </summary>
        [DisplayNameAttribute("变压器型号")]
        public string byqModle
        {
            get { return _byqmodle; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[变压器型号]长度不能大于50!");
                if (_byqmodle as object == null || !_byqmodle.Equals(value))
                {
                    _byqmodle = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqVol
        /// 属性描述：电压等级
        /// 字段信息：[byqVol],nvarchar
        /// </summary>
        [DisplayNameAttribute("电压等级")]
        public string byqVol
        {
            get { return _byqvol; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电压等级]长度不能大于50!");
                if (_byqvol as object == null || !_byqvol.Equals(value))
                {
                    _byqvol = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqCapcity
        /// 属性描述：容量
        /// 字段信息：[byqCapcity],int
        /// </summary>
        [DisplayNameAttribute("容量")]
        public int byqCapcity
        {
            get { return _byqcapcity; }
            set
            {			
                if (_byqcapcity as object == null || !_byqcapcity.Equals(value))
                {
                    _byqcapcity = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Loss1
        /// 属性描述：短路损耗
        /// 字段信息：[Loss1],decimal
        /// </summary>
        [DisplayNameAttribute("短路损耗")]
        public decimal Loss1
        {
            get { return _loss1; }
            set
            {			
                if (_loss1 as object == null || !_loss1.Equals(value))
                {
                    _loss1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Loss2
        /// 属性描述：开路损耗
        /// 字段信息：[Loss2],decimal
        /// </summary>
        [DisplayNameAttribute("开路损耗")]
        public decimal Loss2
        {
            get { return _loss2; }
            set
            {			
                if (_loss2 as object == null || !_loss2.Equals(value))
                {
                    _loss2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Ratedcurrent
        /// 属性描述：额定电流
        /// 字段信息：[Ratedcurrent],decimal
        /// </summary>
        [DisplayNameAttribute("额定电流")]
        public decimal Ratedcurrent
        {
            get { return _ratedcurrent; }
            set
            {			
                if (_ratedcurrent as object == null || !_ratedcurrent.Equals(value))
                {
                    _ratedcurrent = value;
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
