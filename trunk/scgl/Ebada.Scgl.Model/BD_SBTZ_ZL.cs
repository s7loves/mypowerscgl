/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-2-27 16:51:06
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[BD_SBTZ_ZL]业务实体类
    ///对应表名:BD_SBTZ_ZL
    /// </summary>
    [Serializable]
    public class BD_SBTZ_ZL
    {
        
        #region Private 成员
        private int _id=0; 
        private string _dm=String.Empty; 
        private string _mc=String.Empty; 
        private string _jxzq=String.Empty; 
        private string _pdm=String.Empty; 
        private string _type=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：id
        /// 属性描述：
        /// 字段信息：[id],int
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("id")]
        public int id
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
        /// 属性名称：dm
        /// 属性描述：种类代码
        /// 字段信息：[dm],nvarchar
        /// </summary>
        [DisplayNameAttribute("种类代码")]
        public string dm
        {
            get { return _dm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[种类代码]长度不能大于50!");
                if (_dm as object == null || !_dm.Equals(value))
                {
                    _dm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：mc
        /// 属性描述：种类名称
        /// 字段信息：[mc],nvarchar
        /// </summary>
        [DisplayNameAttribute("种类名称")]
        public string mc
        {
            get { return _mc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[种类名称]长度不能大于50!");
                if (_mc as object == null || !_mc.Equals(value))
                {
                    _mc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jxzq
        /// 属性描述：检修周期
        /// 字段信息：[jxzq],nvarchar
        /// </summary>
        [DisplayNameAttribute("检修周期")]
        public string jxzq
        {
            get { return _jxzq; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[检修周期]长度不能大于50!");
                if (_jxzq as object == null || !_jxzq.Equals(value))
                {
                    _jxzq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：pdm
        /// 属性描述：上级代码
        /// 字段信息：[pdm],nvarchar
        /// </summary>
        [DisplayNameAttribute("上级代码")]
        public string pdm
        {
            get { return _pdm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[上级代码]长度不能大于50!");
                if (_pdm as object == null || !_pdm.Equals(value))
                {
                    _pdm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：type
        /// 属性描述：类型
        /// 字段信息：[type],nvarchar
        /// </summary>
        [DisplayNameAttribute("类型")]
        public string type
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
        /// 属性名称：c1
        /// 属性描述：
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [DisplayNameAttribute("c1")]
        public string c1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[c1]长度不能大于50!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c2
        /// 属性描述：
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [DisplayNameAttribute("c2")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[c2]长度不能大于50!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
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
