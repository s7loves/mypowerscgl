/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-3-30 20:10:43
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_gtsbclb]业务实体类
    ///对应表名:PS_gtsbclb
    /// </summary>
    [Serializable]
    public class PS_gtsbclb
    {
        
        #region Private 成员
        private string _bh=String.Empty; 
        private string _mc=String.Empty; 
        private string _xh=String.Empty; 
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _s1=String.Empty; 
        private string _s2=String.Empty; 
        private string _s3=String.Empty; 
        private string _zl=String.Empty; 
        private string _zlcode=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：bh
        /// 属性描述：种类编号
        /// 字段信息：[bh],nvarchar
        /// </summary>
        [DisplayNameAttribute("种类编号")]
        public string bh
        {
            get { return _bh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[种类编号]长度不能大于50!");
                if (_bh as object == null || !_bh.Equals(value))
                {
                    _bh = value;
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
        /// 属性名称：xh
        /// 属性描述：设备型号
        /// 字段信息：[xh],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备型号")]
        public string xh
        {
            get { return _xh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备型号]长度不能大于50!");
                if (_xh as object == null || !_xh.Equals(value))
                {
                    _xh = value;
                }
            }			 
        }
  
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
        /// 属性名称：S1
        /// 属性描述：单位
        /// 字段信息：[S1],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位")]
        public string S1
        {
            get { return _s1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用]长度不能大于50!");
                if (_s1 as object == null || !_s1.Equals(value))
                {
                    _s1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S2
        /// 属性描述：数量
        /// 字段信息：[S2],nvarchar
        /// </summary>
        [DisplayNameAttribute("数量")]
        public string S2
        {
            get { return _s2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用]长度不能大于50!");
                if (_s2 as object == null || !_s2.Equals(value))
                {
                    _s2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S3
        /// 属性描述：备用
        /// 字段信息：[S3],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用")]
        public string S3
        {
            get { return _s3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用]长度不能大于50!");
                if (_s3 as object == null || !_s3.Equals(value))
                {
                    _s3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zl
        /// 属性描述：种类
        /// 字段信息：[zl],nvarchar
        /// </summary>
        [DisplayNameAttribute("种类")]
        public string zl
        {
            get { return _zl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[种类]长度不能大于50!");
                if (_zl as object == null || !_zl.Equals(value))
                {
                    _zl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zlCode
        /// 属性描述：种类编号
        /// 字段信息：[zlCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("种类编号")]
        public string zlCode
        {
            get { return _zlcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[种类编号]长度不能大于50!");
                if (_zlcode as object == null || !_zlcode.Equals(value))
                {
                    _zlcode = value;
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
