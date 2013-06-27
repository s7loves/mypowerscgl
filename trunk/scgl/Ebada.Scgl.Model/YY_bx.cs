/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada物流企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-6-26 15:40:31
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[YY_bx]业务实体类
    ///对应表名:YY_bx
    /// </summary>
    [Serializable]
    public class YY_bx
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _tqcode=String.Empty; 
        private string _bxcode=String.Empty; 
        private string _type=String.Empty; 
        private string _xb=String.Empty; 
        private string _address=String.Empty; 
        private string _byscol1=String.Empty; 
        private string _byscol2=String.Empty; 
        private string _byscol3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TqCode
        /// 属性描述：台区编号
        /// 字段信息：[TqCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("台区编号")]
        public string TqCode
        {
            get { return _tqcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[台区编号]长度不能大于50!");
                if (_tqcode as object == null || !_tqcode.Equals(value))
                {
                    _tqcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BxCode
        /// 属性描述：表箱编号
        /// 字段信息：[BxCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("表箱编号")]
        public string BxCode
        {
            get { return _bxcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[表箱编号]长度不能大于50!");
                if (_bxcode as object == null || !_bxcode.Equals(value))
                {
                    _bxcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Type
        /// 属性描述：类型
        /// 字段信息：[Type],nvarchar
        /// </summary>
        [DisplayNameAttribute("类型")]
        public string Type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[类型]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：XB
        /// 属性描述：相别
        /// 字段信息：[XB],nvarchar
        /// </summary>
        [DisplayNameAttribute("相别")]
        public string XB
        {
            get { return _xb; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[相别]长度不能大于50!");
                if (_xb as object == null || !_xb.Equals(value))
                {
                    _xb = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Address
        /// 属性描述：安装位置
        /// 字段信息：[Address],nvarchar
        /// </summary>
        [DisplayNameAttribute("安装位置")]
        public string Address
        {
            get { return _address; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[安装位置]长度不能大于50!");
                if (_address as object == null || !_address.Equals(value))
                {
                    _address = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ByScol1
        /// 属性描述：备用1
        /// 字段信息：[ByScol1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用1")]
        public string ByScol1
        {
            get { return _byscol1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用1]长度不能大于50!");
                if (_byscol1 as object == null || !_byscol1.Equals(value))
                {
                    _byscol1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ByScol2
        /// 属性描述：备用2
        /// 字段信息：[ByScol2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用2")]
        public string ByScol2
        {
            get { return _byscol2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用2]长度不能大于50!");
                if (_byscol2 as object == null || !_byscol2.Equals(value))
                {
                    _byscol2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ByScol3
        /// 属性描述：备用3
        /// 字段信息：[ByScol3],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用3")]
        public string ByScol3
        {
            get { return _byscol3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用3]长度不能大于50!");
                if (_byscol3 as object == null || !_byscol3.Equals(value))
                {
                    _byscol3 = value;
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
