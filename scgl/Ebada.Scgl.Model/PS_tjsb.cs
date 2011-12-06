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
    public class PS_tjsb
    {
        
        #region Private 成员
        private string _sbname=String.Empty;
        private int _byqnumber = 0;
        private decimal _byqcapcity = 0;
        private decimal _radius = 0;
        private decimal _lengthsum = 0;
        private decimal _linenumber = 0;
        private decimal _lengthmain = 0;
        private decimal _lengthlow = 0;
        private decimal _lengthbranch = 0;
        private int _numbergthigh = 0;
        private int _numbergtlow = 0; 
        private int _numberbt = 0;
        private int _numberbureau = 0;  
        private decimal _capcitybureau = 0; 
        private int _numberperson = 0;  
        private int _capcityperson = 0;
        #endregion
  
  
        #region Public 成员
   
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
        /// 属性名称：数量
        /// 属性描述：变压器数量
        /// 字段信息：[_byqnumber],int
        /// </summary>
        //[Browsable(false)]
        [DisplayNameAttribute("变压器总数量")]
        public int ByqNumber
        {
            get { return _byqnumber; }
            set
            {
                _byqnumber = value;               
            }
        }

        /// <summary>
        /// 属性名称：容量
        /// 属性描述：变压器容量
        /// 字段信息：[_byqcapcity],decimal
        /// </summary>
        [DisplayNameAttribute("变压器总容量")]
        public decimal ByqCapcity
        {
            get { return _byqcapcity; }
            set { _byqcapcity = value; }
        }


        /// <summary>
        /// 属性名称：供电半径
        /// 属性描述：供电半径
        /// 字段信息：[_radius],decimal
        /// </summary>
        [DisplayNameAttribute("供电半径")]
        public decimal Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        /// <summary>
        /// 属性名称：长度
        /// 属性描述：10kv线路总长度
        /// 字段信息：[_lengthsum],decimal
        /// </summary>
        [DisplayNameAttribute("10Kv线路总长度")]
        public decimal Lengthsum
        {
            get { return _lengthsum; }
            set { _lengthsum = value; }
        }

        /// <summary>
        /// 属性名称：数量
        /// 属性描述：10kv线路分支数
        /// 字段信息：[_linenumber],decimal
        /// </summary>
        [DisplayNameAttribute("10Kv线路分支数")]
        public decimal LineNumber
        {
            get { return _linenumber; }
            set { _linenumber = value; }
        }

        /// <summary>
        /// 属性名称：长度
        /// 属性描述：10kv线路干线长度
        /// 字段信息：[_lengthmain],decimal
        /// </summary>
        [DisplayNameAttribute("10Kv线路干线长度")]
        public decimal LengthMain
        {
            get { return _lengthmain; }
            set { _lengthmain = value; }
        }

        /// <summary>
        /// 属性名称：长度
        /// 属性描述：0.4kv线路总长度
        /// 字段信息：[_lengthmain],decimal
        /// </summary>
        [DisplayNameAttribute("0.4Kv线路总长度")]
        public decimal LengthLow
        {
            get { return _lengthlow; }
            set { _lengthlow = value; }
        }

        /// <summary>
        /// 属性名称：长度
        /// 属性描述：10kv线路分支长度
        /// 字段信息：[_lengthmain],decimal
        /// </summary>
        [DisplayNameAttribute("10Kv线路分支长度")]
        public decimal LengthBranch
        {
            get { return _lengthbranch; }
            set { _lengthbranch = value; }
        }


        /// <summary>
        /// 属性名称：杆数
        /// 属性描述：高压杆数
        /// 字段信息：[_numbergthigh],int
        /// </summary>
        [DisplayNameAttribute("高压杆数")]
        public int NumbergtHigh
        {
            get { return _numbergthigh; }
            set { _numbergthigh = value; }
        }

        /// <summary>
        /// 属性名称：杆数
        /// 属性描述：低压杆数
        /// 字段信息：[_numbergtlow],int
        /// </summary>
        [DisplayNameAttribute("低压杆数")]
        public int NumbergtLow
        {
            get { return _numbergtlow; }
            set { _numbergtlow = value; }
        }

        /// <summary>
        /// 属性名称：数量
        /// 属性描述：变台数量
        /// 字段信息：[_numberbt],int
        /// </summary>
        [DisplayNameAttribute("变台数量")]
        public int NumberBT
        {
            get { return _numberbt; }
            set { _numberbt = value; }
        }

        /// <summary>
        /// 属性名称：变台
        /// 属性描述：局属变台
        /// 字段信息：[_numberbureau],int
        /// </summary>
        [DisplayNameAttribute("局属变台")]
        public int NumberBureau
        {
            get { return _numberbureau; }
            set { _numberbureau = value; }
        }

        /// <summary>
        /// 属性名称：容量
        /// 属性描述：局属容量
        /// 字段信息：[_capcitybureau],int
        /// </summary>
        [DisplayNameAttribute("局属容量")]
        public decimal CapcityBureau
        {
            get { return _capcitybureau; }
            set { _capcitybureau = value; }
        }

        /// <summary>
        /// 属性名称：变台
        /// 属性描述：私属变台
        /// 字段信息：[_numberperson],int
        /// </summary>
        [DisplayNameAttribute("私属变台")]
        public int NumberPerson
        {
            get { return _numberperson; }
            set { _numberperson = value; }
        }

        /// <summary>
        /// 属性名称：容量
        /// 属性描述：私属容量
        /// 字段信息：[_capcityperson],decimal
        /// </summary>
        [DisplayNameAttribute("私属容量")]
        public int CapcityPerson
        {
            get { return _capcityperson; }
            set { _capcityperson = value; }
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
