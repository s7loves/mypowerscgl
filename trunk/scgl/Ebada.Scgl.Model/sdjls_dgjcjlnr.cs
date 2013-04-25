/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-4-25 9:39:19
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sdjls_dgjcjlnr]业务实体类
    ///对应表名:sdjls_dgjcjlnr
    /// </summary>
    [Serializable]
    public class sdjls_dgjcjlnr
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private DateTime _jcrq=new DateTime(1900,1,1); 
        private string _qsgtbh=String.Empty; 
        private string _zzgtbh=String.Empty; 
        private string _jcjg=String.Empty; 
        private string _jcr=String.Empty; 
        private string _bz=String.Empty; 
        private string _qxdj=String.Empty; 
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
        /// 属性描述：父表ID
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("父表ID")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[父表ID]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jcrq
        /// 属性描述：检查日期
        /// 字段信息：[jcrq],datetime
        /// </summary>
        [DisplayNameAttribute("检查日期")]
        public DateTime jcrq
        {
            get { return _jcrq; }
            set
            {			
                if (_jcrq as object == null || !_jcrq.Equals(value))
                {
                    _jcrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qsgtbh
        /// 属性描述：起始杆塔编号
        /// 字段信息：[qsgtbh],nvarchar
        /// </summary>
        [DisplayNameAttribute("起始杆塔编号")]
        public string qsgtbh
        {
            get { return _qsgtbh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[起始杆塔编号]长度不能大于50!");
                if (_qsgtbh as object == null || !_qsgtbh.Equals(value))
                {
                    _qsgtbh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zzgtbh
        /// 属性描述：终止杆塔编号
        /// 字段信息：[zzgtbh],nvarchar
        /// </summary>
        [DisplayNameAttribute("终止杆塔编号")]
        public string zzgtbh
        {
            get { return _zzgtbh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[终止杆塔编号]长度不能大于50!");
                if (_zzgtbh as object == null || !_zzgtbh.Equals(value))
                {
                    _zzgtbh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jcjg
        /// 属性描述：检查结果
        /// 字段信息：[jcjg],nvarchar
        /// </summary>
        [DisplayNameAttribute("检查结果")]
        public string jcjg
        {
            get { return _jcjg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[检查结果]长度不能大于500!");
                if (_jcjg as object == null || !_jcjg.Equals(value))
                {
                    _jcjg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jcr
        /// 属性描述：检查人
        /// 字段信息：[jcr],nvarchar
        /// </summary>
        [DisplayNameAttribute("检查人")]
        public string jcr
        {
            get { return _jcr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[检查人]长度不能大于50!");
                if (_jcr as object == null || !_jcr.Equals(value))
                {
                    _jcr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bz
        /// 属性描述：备注
        /// 字段信息：[bz],nvarchar
        /// </summary>
        [DisplayNameAttribute("备注")]
        public string bz
        {
            get { return _bz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备注]长度不能大于500!");
                if (_bz as object == null || !_bz.Equals(value))
                {
                    _bz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qxdj
        /// 属性描述：缺陷等级
        /// 字段信息：[qxdj],nvarchar
        /// </summary>
        [DisplayNameAttribute("缺陷等级")]
        public string qxdj
        {
            get { return _qxdj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[缺陷等级]长度不能大于50!");
                if (_qxdj as object == null || !_qxdj.Equals(value))
                {
                    _qxdj = value;
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
