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
    ///[PJ_dyk]业务实体类
    ///对应表名:PJ_dyk
    /// </summary>
    [Serializable]
    public class PJ_dyk
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _dx=String.Empty; 
        private string _sx=String.Empty; 
        private string _bh=String.Empty; 
        private string _nr=String.Empty;   
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
        /// 属性名称：dx
        /// 属性描述：对象
        /// 字段信息：[dx],nvarchar
        /// </summary>
        [DisplayNameAttribute("对象")]
        public string dx
        {
            get { return _dx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[对象]长度不能大于50!");
                if (_dx as object == null || !_dx.Equals(value))
                {
                    _dx = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sx
        /// 属性描述：属性
        /// 字段信息：[sx],nvarchar
        /// </summary>
        [DisplayNameAttribute("属性")]
        public string sx
        {
            get { return _sx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[属性]长度不能大于50!");
                if (_sx as object == null || !_sx.Equals(value))
                {
                    _sx = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bh
        /// 属性描述：短语编号
        /// 字段信息：[bh],nvarchar
        /// </summary>
        [DisplayNameAttribute("短语编号")]
        public string bh
        {
            get { return _bh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[短语编号]长度不能大于50!");
                if (_bh as object == null || !_bh.Equals(value))
                {
                    _bh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：nr
        /// 属性描述：短语内容
        /// 字段信息：[nr],nvarchar
        /// </summary>
        [DisplayNameAttribute("短语内容")]
        public string nr
        {
            get { return _nr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 2000)
                throw new Exception("[短语内容]长度不能大于2000!");
                if (_nr as object == null || !_nr.Equals(value))
                {
                    _nr = value;
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
