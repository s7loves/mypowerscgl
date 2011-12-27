/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-12-26 20:53:32
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_18gysbpjmx]业务实体类
    ///对应表名:PJ_18gysbpjmx
    /// </summary>
    [Serializable]
    public class PJ_18gysbpjmx
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _pj_id=String.Empty; 
        private int _xh=0; 
        private string _sbdy=String.Empty; 
        private int _one=0; 
        private int _two=0; 
        private int _three=0; 
        private decimal _whl=0; 
        private string _qxlb=String.Empty; 
        private string _qxnr=String.Empty; 
        private string _fzdw=String.Empty; 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1);   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：记录ID
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("记录ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[记录ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：PJ_ID
        /// 属性描述：记录ID
        /// 字段信息：[PJ_ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("记录ID")]
        public string PJ_ID
        {
            get { return _pj_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[记录ID]长度不能大于50!");
                if (_pj_id as object == null || !_pj_id.Equals(value))
                {
                    _pj_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xh
        /// 属性描述：序号
        /// 字段信息：[xh],int
        /// </summary>
        [DisplayNameAttribute("序号")]
        public int xh
        {
            get { return _xh; }
            set
            {			
                if (_xh as object == null || !_xh.Equals(value))
                {
                    _xh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbdy
        /// 属性描述：设备单元名称
        /// 字段信息：[sbdy],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备单元名称")]
        public string sbdy
        {
            get { return _sbdy; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备单元名称]长度不能大于50!");
                if (_sbdy as object == null || !_sbdy.Equals(value))
                {
                    _sbdy = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：one
        /// 属性描述：一类数量
        /// 字段信息：[one],int
        /// </summary>
        [DisplayNameAttribute("一类数量")]
        public int one
        {
            get { return _one; }
            set
            {			
                if (_one as object == null || !_one.Equals(value))
                {
                    _one = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：two
        /// 属性描述：二类数量
        /// 字段信息：[two],int
        /// </summary>
        [DisplayNameAttribute("二类数量")]
        public int two
        {
            get { return _two; }
            set
            {			
                if (_two as object == null || !_two.Equals(value))
                {
                    _two = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：three
        /// 属性描述：三类数量
        /// 字段信息：[three],int
        /// </summary>
        [DisplayNameAttribute("三类数量")]
        public int three
        {
            get { return _three; }
            set
            {			
                if (_three as object == null || !_three.Equals(value))
                {
                    _three = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：whl
        /// 属性描述：完好率
        /// 字段信息：[whl],decimal
        /// </summary>
        [DisplayNameAttribute("完好率")]
        public decimal whl
        {
            get { return _whl; }
            set
            {			
                if (_whl as object == null || !_whl.Equals(value))
                {
                    _whl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qxlb
        /// 属性描述：缺陷类别
        /// 字段信息：[qxlb],nvarchar
        /// </summary>
        [DisplayNameAttribute("缺陷类别")]
        public string qxlb
        {
            get { return _qxlb; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[缺陷类别]长度不能大于50!");
                if (_qxlb as object == null || !_qxlb.Equals(value))
                {
                    _qxlb = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qxnr
        /// 属性描述：缺陷内容
        /// 字段信息：[qxnr],nvarchar
        /// </summary>
        [DisplayNameAttribute("缺陷内容")]
        public string qxnr
        {
            get { return _qxnr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[缺陷内容]长度不能大于250!");
                if (_qxnr as object == null || !_qxnr.Equals(value))
                {
                    _qxnr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fzdw
        /// 属性描述：负责单位
        /// 字段信息：[fzdw],nvarchar
        /// </summary>
        [DisplayNameAttribute("负责单位")]
        public string fzdw
        {
            get { return _fzdw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[负责单位]长度不能大于50!");
                if (_fzdw as object == null || !_fzdw.Equals(value))
                {
                    _fzdw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateMan
        /// 属性描述：填写人
        /// 字段信息：[CreateMan],nvarchar
        /// </summary>
        [DisplayNameAttribute("填写人")]
        public string CreateMan
        {
            get { return _createman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[填写人]长度不能大于10!");
                if (_createman as object == null || !_createman.Equals(value))
                {
                    _createman = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateDate
        /// 属性描述：填写日期
        /// 字段信息：[CreateDate],datetime
        /// </summary>
        [DisplayNameAttribute("填写日期")]
        public DateTime CreateDate
        {
            get { return _createdate; }
            set
            {			
                if (_createdate as object == null || !_createdate.Equals(value))
                {
                    _createdate = value;
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
