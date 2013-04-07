/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-4-7 10:59:29
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[bdjl_sgzayc]业务实体类
    ///对应表名:bdjl_sgzayc
    /// </summary>
    [Serializable]
    public class bdjl_sgzayc
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _fssj=String.Empty; 
        private string _xz=String.Empty; 
        private string _jt=String.Empty; 
        private string _fsjg=String.Empty; 
        private string _sgsxqk=String.Empty; 
        private string _yyjfzfx=String.Empty; 
        private string _dc=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty;   
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
        /// 属性名称：OrgCode
        /// 属性描述：单位代码
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位代码")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位代码]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fssj
        /// 属性描述：发生时间
        /// 字段信息：[fssj],nvarchar
        /// </summary>
        [DisplayNameAttribute("发生时间")]
        public string fssj
        {
            get { return _fssj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[发生时间]长度不能大于50!");
                if (_fssj as object == null || !_fssj.Equals(value))
                {
                    _fssj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xz
        /// 属性描述：性质
        /// 字段信息：[xz],nvarchar
        /// </summary>
        [DisplayNameAttribute("性质")]
        public string xz
        {
            get { return _xz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[性质]长度不能大于50!");
                if (_xz as object == null || !_xz.Equals(value))
                {
                    _xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jt
        /// 属性描述：简题
        /// 字段信息：[jt],nvarchar
        /// </summary>
        [DisplayNameAttribute("简题")]
        public string jt
        {
            get { return _jt; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[简题]长度不能大于50!");
                if (_jt as object == null || !_jt.Equals(value))
                {
                    _jt = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fsjg
        /// 属性描述：发生经过
        /// 字段信息：[fsjg],nvarchar
        /// </summary>
        [DisplayNameAttribute("发生经过")]
        public string fsjg
        {
            get { return _fsjg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[发生经过]长度不能大于500!");
                if (_fsjg as object == null || !_fsjg.Equals(value))
                {
                    _fsjg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sgsxqk
        /// 属性描述：事故损失情况(少送电量)
        /// 字段信息：[sgsxqk],nvarchar
        /// </summary>
        [DisplayNameAttribute("事故损失情况(少送电量)")]
        public string sgsxqk
        {
            get { return _sgsxqk; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[事故损失情况(少送电量)]长度不能大于500!");
                if (_sgsxqk as object == null || !_sgsxqk.Equals(value))
                {
                    _sgsxqk = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：yyjfzfx
        /// 属性描述：原因及负责分析
        /// 字段信息：[yyjfzfx],nvarchar
        /// </summary>
        [DisplayNameAttribute("原因及负责分析")]
        public string yyjfzfx
        {
            get { return _yyjfzfx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[原因及负责分析]长度不能大于500!");
                if (_yyjfzfx as object == null || !_yyjfzfx.Equals(value))
                {
                    _yyjfzfx = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dc
        /// 属性描述：对策
        /// 字段信息：[dc],nvarchar
        /// </summary>
        [DisplayNameAttribute("对策")]
        public string dc
        {
            get { return _dc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[对策]长度不能大于500!");
                if (_dc as object == null || !_dc.Equals(value))
                {
                    _dc = value;
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
