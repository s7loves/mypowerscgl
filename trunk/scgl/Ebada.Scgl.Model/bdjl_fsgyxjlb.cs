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
    ///[bdjl_fsgyxjlb]业务实体类
    ///对应表名:bdjl_fsgyxjlb
    /// </summary>
    [Serializable]
    public class bdjl_fsgyxjlb
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _yxdd=String.Empty; 
        private string _yxtm=String.Empty; 
        private string _yxkssj=String.Empty; 
        private string _yxjssj=String.Empty; 
        private string _cjry=String.Empty; 
        private string _cljg=String.Empty; 
        private string _wtjcs=String.Empty; 
        private string _jljpj=String.Empty; 
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
        /// 属性名称：yxdd
        /// 属性描述：演习地点
        /// 字段信息：[yxdd],nvarchar
        /// </summary>
        [DisplayNameAttribute("演习地点")]
        public string yxdd
        {
            get { return _yxdd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[演习地点]长度不能大于50!");
                if (_yxdd as object == null || !_yxdd.Equals(value))
                {
                    _yxdd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：yxtm
        /// 属性描述：演习题目
        /// 字段信息：[yxtm],nvarchar
        /// </summary>
        [DisplayNameAttribute("演习题目")]
        public string yxtm
        {
            get { return _yxtm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[演习题目]长度不能大于50!");
                if (_yxtm as object == null || !_yxtm.Equals(value))
                {
                    _yxtm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：yxkssj
        /// 属性描述：演习开始时间
        /// 字段信息：[yxkssj],nvarchar
        /// </summary>
        [DisplayNameAttribute("演习开始时间")]
        public string yxkssj
        {
            get { return _yxkssj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[演习开始时间]长度不能大于50!");
                if (_yxkssj as object == null || !_yxkssj.Equals(value))
                {
                    _yxkssj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：yxjssj
        /// 属性描述：演习结束时间
        /// 字段信息：[yxjssj],nvarchar
        /// </summary>
        [DisplayNameAttribute("演习结束时间")]
        public string yxjssj
        {
            get { return _yxjssj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[演习结束时间]长度不能大于50!");
                if (_yxjssj as object == null || !_yxjssj.Equals(value))
                {
                    _yxjssj = value;
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
        /// 属性名称：cljg
        /// 属性描述：处理经过
        /// 字段信息：[cljg],nvarchar
        /// </summary>
        [DisplayNameAttribute("处理经过")]
        public string cljg
        {
            get { return _cljg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[处理经过]长度不能大于500!");
                if (_cljg as object == null || !_cljg.Equals(value))
                {
                    _cljg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wtjcs
        /// 属性描述：发现问题及今后采取的措施
        /// 字段信息：[wtjcs],nvarchar
        /// </summary>
        [DisplayNameAttribute("发现问题及今后采取的措施")]
        public string wtjcs
        {
            get { return _wtjcs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[发现问题及今后采取的措施]长度不能大于500!");
                if (_wtjcs as object == null || !_wtjcs.Equals(value))
                {
                    _wtjcs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jljpj
        /// 属性描述：结论及评价
        /// 字段信息：[jljpj],nvarchar
        /// </summary>
        [DisplayNameAttribute("结论及评价")]
        public string jljpj
        {
            get { return _jljpj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[结论及评价]长度不能大于500!");
                if (_jljpj as object == null || !_jljpj.Equals(value))
                {
                    _jljpj = value;
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
