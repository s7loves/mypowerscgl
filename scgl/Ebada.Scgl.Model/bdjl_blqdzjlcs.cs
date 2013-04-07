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
    ///[bdjl_blqdzjlcs]业务实体类
    ///对应表名:bdjl_blqdzjlcs
    /// </summary>
    [Serializable]
    public class bdjl_blqdzjlcs
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _blqmc=String.Empty; 
        private DateTime _dzrq=new DateTime(1900,1,1); 
        private DateTime _dzsj=new DateTime(1900,1,1); 
        private string _axjsqzss=String.Empty; 
        private string _bxjsqzss=String.Empty; 
        private string _cxjsqzss=String.Empty; 
        private string _jlr=String.Empty; 
        private string _dzyy=String.Empty; 
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
        /// 属性名称：blqmc
        /// 属性描述：避雷器名称
        /// 字段信息：[blqmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("避雷器名称")]
        public string blqmc
        {
            get { return _blqmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[避雷器名称]长度不能大于50!");
                if (_blqmc as object == null || !_blqmc.Equals(value))
                {
                    _blqmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dzrq
        /// 属性描述：动作日期
        /// 字段信息：[dzrq],datetime
        /// </summary>
        [DisplayNameAttribute("动作日期")]
        public DateTime dzrq
        {
            get { return _dzrq; }
            set
            {			
                if (_dzrq as object == null || !_dzrq.Equals(value))
                {
                    _dzrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dzsj
        /// 属性描述：动作时间
        /// 字段信息：[dzsj],datetime
        /// </summary>
        [DisplayNameAttribute("动作时间")]
        public DateTime dzsj
        {
            get { return _dzsj; }
            set
            {			
                if (_dzsj as object == null || !_dzsj.Equals(value))
                {
                    _dzsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Axjsqzss
        /// 属性描述：A相计数器指示数
        /// 字段信息：[Axjsqzss],nvarchar
        /// </summary>
        [DisplayNameAttribute("A相计数器指示数")]
        public string Axjsqzss
        {
            get { return _axjsqzss; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[A相计数器指示数]长度不能大于50!");
                if (_axjsqzss as object == null || !_axjsqzss.Equals(value))
                {
                    _axjsqzss = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Bxjsqzss
        /// 属性描述：B相计数器指示数
        /// 字段信息：[Bxjsqzss],nvarchar
        /// </summary>
        [DisplayNameAttribute("B相计数器指示数")]
        public string Bxjsqzss
        {
            get { return _bxjsqzss; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[B相计数器指示数]长度不能大于50!");
                if (_bxjsqzss as object == null || !_bxjsqzss.Equals(value))
                {
                    _bxjsqzss = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Cxjsqzss
        /// 属性描述：C相计数器指示数
        /// 字段信息：[Cxjsqzss],nvarchar
        /// </summary>
        [DisplayNameAttribute("C相计数器指示数")]
        public string Cxjsqzss
        {
            get { return _cxjsqzss; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[C相计数器指示数]长度不能大于50!");
                if (_cxjsqzss as object == null || !_cxjsqzss.Equals(value))
                {
                    _cxjsqzss = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jlr
        /// 属性描述：记录人
        /// 字段信息：[jlr],nvarchar
        /// </summary>
        [DisplayNameAttribute("记录人")]
        public string jlr
        {
            get { return _jlr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[记录人]长度不能大于50!");
                if (_jlr as object == null || !_jlr.Equals(value))
                {
                    _jlr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dzyy
        /// 属性描述：动作原因
        /// 字段信息：[dzyy],nvarchar
        /// </summary>
        [DisplayNameAttribute("动作原因")]
        public string dzyy
        {
            get { return _dzyy; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[动作原因]长度不能大于500!");
                if (_dzyy as object == null || !_dzyy.Equals(value))
                {
                    _dzyy = value;
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
