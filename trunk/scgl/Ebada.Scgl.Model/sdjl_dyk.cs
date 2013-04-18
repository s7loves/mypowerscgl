/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-4-18 15:15:41
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sdjl_dyk]业务实体类
    ///对应表名:sdjl_dyk
    /// </summary>
    [Serializable]
    public class sdjl_dyk
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _dx=String.Empty; 
        private string _sx=String.Empty; 
        private string _bh=String.Empty; 
        private string _zjm=String.Empty; 
        private string _nr4=String.Empty; 
        private string _nr=String.Empty; 
        private string _nr2=String.Empty; 
        private string _nr3=String.Empty; 
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
        /// 属性名称：ParentID
        /// 属性描述：ParentID
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("ParentID")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[ParentID]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
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
        /// 属性名称：zjm
        /// 属性描述：助记码
        /// 字段信息：[zjm],nvarchar
        /// </summary>
        [DisplayNameAttribute("助记码")]
        public string zjm
        {
            get { return _zjm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[助记码]长度不能大于50!");
                if (_zjm as object == null || !_zjm.Equals(value))
                {
                    _zjm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：nr4
        /// 属性描述：短语内容
        /// 字段信息：[nr4],nvarchar
        /// </summary>
        [DisplayNameAttribute("短语内容")]
        public string nr4
        {
            get { return _nr4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 2000)
                throw new Exception("[短语内容]长度不能大于2000!");
                if (_nr4 as object == null || !_nr4.Equals(value))
                {
                    _nr4 = value;
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
  
        /// <summary>
        /// 属性名称：nr2
        /// 属性描述：短语内容
        /// 字段信息：[nr2],nvarchar
        /// </summary>
        [DisplayNameAttribute("短语内容")]
        public string nr2
        {
            get { return _nr2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 2000)
                throw new Exception("[短语内容]长度不能大于2000!");
                if (_nr2 as object == null || !_nr2.Equals(value))
                {
                    _nr2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：nr3
        /// 属性描述：短语内容
        /// 字段信息：[nr3],nvarchar
        /// </summary>
        [DisplayNameAttribute("短语内容")]
        public string nr3
        {
            get { return _nr3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 2000)
                throw new Exception("[短语内容]长度不能大于2000!");
                if (_nr3 as object == null || !_nr3.Equals(value))
                {
                    _nr3 = value;
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
