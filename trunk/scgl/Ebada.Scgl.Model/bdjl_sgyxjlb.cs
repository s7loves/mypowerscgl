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
    ///[bdjl_sgyxjlb]业务实体类
    ///对应表名:bdjl_sgyxjlb
    /// </summary>
    [Serializable]
    public class bdjl_sgyxjlb
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _tq=String.Empty; 
        private string _cjry=String.Empty; 
        private string _dsyxfs=String.Empty; 
        private string _yxtm=String.Empty; 
        private string _sgxx=String.Empty; 
        private string _clbz=String.Empty; 
        private string _shyj=String.Empty; 
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
        /// 属性名称：tq
        /// 属性描述：天气
        /// 字段信息：[tq],nvarchar
        /// </summary>
        [DisplayNameAttribute("天气")]
        public string tq
        {
            get { return _tq; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[天气]长度不能大于50!");
                if (_tq as object == null || !_tq.Equals(value))
                {
                    _tq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cjry
        /// 属性描述：参加人员
        /// 字段信息：[cjry],nvarchar
        /// </summary>
        [DisplayNameAttribute("参加人员")]
        public string cjry
        {
            get { return _cjry; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[参加人员]长度不能大于50!");
                if (_cjry as object == null || !_cjry.Equals(value))
                {
                    _cjry = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dsyxfs
        /// 属性描述：当时运行方式
        /// 字段信息：[dsyxfs],nvarchar
        /// </summary>
        [DisplayNameAttribute("当时运行方式")]
        public string dsyxfs
        {
            get { return _dsyxfs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[当时运行方式]长度不能大于50!");
                if (_dsyxfs as object == null || !_dsyxfs.Equals(value))
                {
                    _dsyxfs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：yxtm
        /// 属性描述：预想题目
        /// 字段信息：[yxtm],nvarchar
        /// </summary>
        [DisplayNameAttribute("预想题目")]
        public string yxtm
        {
            get { return _yxtm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[预想题目]长度不能大于500!");
                if (_yxtm as object == null || !_yxtm.Equals(value))
                {
                    _yxtm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sgxx
        /// 属性描述：事故现象
        /// 字段信息：[sgxx],nvarchar
        /// </summary>
        [DisplayNameAttribute("事故现象")]
        public string sgxx
        {
            get { return _sgxx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[事故现象]长度不能大于500!");
                if (_sgxx as object == null || !_sgxx.Equals(value))
                {
                    _sgxx = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：clbz
        /// 属性描述：处理步骤
        /// 字段信息：[clbz],nvarchar
        /// </summary>
        [DisplayNameAttribute("处理步骤")]
        public string clbz
        {
            get { return _clbz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[处理步骤]长度不能大于500!");
                if (_clbz as object == null || !_clbz.Equals(value))
                {
                    _clbz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：shyj
        /// 属性描述：审核意见
        /// 字段信息：[shyj],nvarchar
        /// </summary>
        [DisplayNameAttribute("审核意见")]
        public string shyj
        {
            get { return _shyj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[审核意见]长度不能大于500!");
                if (_shyj as object == null || !_shyj.Equals(value))
                {
                    _shyj = value;
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
