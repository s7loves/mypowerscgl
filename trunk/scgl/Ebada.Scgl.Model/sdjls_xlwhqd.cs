/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-4-25 9:39:20
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sdjls_xlwhqd]业务实体类
    ///对应表名:sdjls_xlwhqd
    /// </summary>
    [Serializable]
    public class sdjls_xlwhqd
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _linecode=String.Empty; 
        private string _linename=String.Empty; 
        private string _whqd=String.Empty; 
        private string _qdxx=String.Empty; 
        private string _whxz=String.Empty; 
        private string _whdj=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty; 
        private string _c4=String.Empty; 
        private string _c5=String.Empty;   
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
        /// 属性名称：LineCode
        /// 属性描述：线路编号
        /// 字段信息：[LineCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路编号")]
        public string LineCode
        {
            get { return _linecode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路编号]长度不能大于50!");
                if (_linecode as object == null || !_linecode.Equals(value))
                {
                    _linecode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineName
        /// 属性描述：线路名称
        /// 字段信息：[LineName],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路名称")]
        public string LineName
        {
            get { return _linename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路名称]长度不能大于50!");
                if (_linename as object == null || !_linename.Equals(value))
                {
                    _linename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：whqd
        /// 属性描述：污秽区段
        /// 字段信息：[whqd],nvarchar
        /// </summary>
        [DisplayNameAttribute("污秽区段")]
        public string whqd
        {
            get { return _whqd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[污秽区段]长度不能大于50!");
                if (_whqd as object == null || !_whqd.Equals(value))
                {
                    _whqd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qdxx
        /// 属性描述：区段信息
        /// 字段信息：[qdxx],nvarchar
        /// </summary>
        [DisplayNameAttribute("区段信息")]
        public string qdxx
        {
            get { return _qdxx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[区段信息]长度不能大于500!");
                if (_qdxx as object == null || !_qdxx.Equals(value))
                {
                    _qdxx = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：whxz
        /// 属性描述：污秽性质
        /// 字段信息：[whxz],nvarchar
        /// </summary>
        [DisplayNameAttribute("污秽性质")]
        public string whxz
        {
            get { return _whxz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[污秽性质]长度不能大于50!");
                if (_whxz as object == null || !_whxz.Equals(value))
                {
                    _whxz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：whdj
        /// 属性描述：污秽等级
        /// 字段信息：[whdj],nvarchar
        /// </summary>
        [DisplayNameAttribute("污秽等级")]
        public string whdj
        {
            get { return _whdj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[污秽等级]长度不能大于50!");
                if (_whdj as object == null || !_whdj.Equals(value))
                {
                    _whdj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c1
        /// 属性描述：备用字段1
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段1")]
        public string c1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段1]长度不能大于500!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c2
        /// 属性描述：备用字段2
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段2")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段2]长度不能大于500!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c3
        /// 属性描述：备用字段3
        /// 字段信息：[c3],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段3")]
        public string c3
        {
            get { return _c3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段3]长度不能大于500!");
                if (_c3 as object == null || !_c3.Equals(value))
                {
                    _c3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c4
        /// 属性描述：备用字段4
        /// 字段信息：[c4],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段4")]
        public string c4
        {
            get { return _c4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段4]长度不能大于500!");
                if (_c4 as object == null || !_c4.Equals(value))
                {
                    _c4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c5
        /// 属性描述：备用字段5
        /// 字段信息：[c5],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段5")]
        public string c5
        {
            get { return _c5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段5]长度不能大于500!");
                if (_c5 as object == null || !_c5.Equals(value))
                {
                    _c5 = value;
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
