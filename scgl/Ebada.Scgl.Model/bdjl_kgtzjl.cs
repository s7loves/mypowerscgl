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
    ///[bdjl_kgtzjl]业务实体类
    ///对应表名:bdjl_kgtzjl
    /// </summary>
    [Serializable]
    public class bdjl_kgtzjl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _linecode=String.Empty; 
        private string _kgmc=String.Empty; 
        private DateTime _tzrq=new DateTime(1900,1,1); 
        private DateTime _tzsj=new DateTime(1900,1,1); 
        private string _kgms=String.Empty; 
        private int _dlqyxgztzcs=0; 
        private int _sgtzcs=0; 
        private int _sdfzcs=0; 
        private string _jlr=String.Empty; 
        private string _bhzhzzdqk=String.Empty; 
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
        /// 属性名称：lineCode
        /// 属性描述：线路代码
        /// 字段信息：[lineCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路代码")]
        public string lineCode
        {
            get { return _linecode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路代码]长度不能大于50!");
                if (_linecode as object == null || !_linecode.Equals(value))
                {
                    _linecode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgmc
        /// 属性描述：开关名称
        /// 字段信息：[kgmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("开关名称")]
        public string kgmc
        {
            get { return _kgmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[开关名称]长度不能大于50!");
                if (_kgmc as object == null || !_kgmc.Equals(value))
                {
                    _kgmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tzrq
        /// 属性描述：跳闸日期
        /// 字段信息：[tzrq],datetime
        /// </summary>
        [DisplayNameAttribute("跳闸日期")]
        public DateTime tzrq
        {
            get { return _tzrq; }
            set
            {			
                if (_tzrq as object == null || !_tzrq.Equals(value))
                {
                    _tzrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tzsj
        /// 属性描述：跳闸时间
        /// 字段信息：[tzsj],datetime
        /// </summary>
        [DisplayNameAttribute("跳闸时间")]
        public DateTime tzsj
        {
            get { return _tzsj; }
            set
            {			
                if (_tzsj as object == null || !_tzsj.Equals(value))
                {
                    _tzsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgms
        /// 属性描述：开关模式
        /// 字段信息：[kgms],nvarchar
        /// </summary>
        [DisplayNameAttribute("开关模式")]
        public string kgms
        {
            get { return _kgms; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[开关模式]长度不能大于50!");
                if (_kgms as object == null || !_kgms.Equals(value))
                {
                    _kgms = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dlqyxgztzcs
        /// 属性描述：断路器允许故障跳闸次数
        /// 字段信息：[dlqyxgztzcs],int
        /// </summary>
        [DisplayNameAttribute("断路器允许故障跳闸次数")]
        public int dlqyxgztzcs
        {
            get { return _dlqyxgztzcs; }
            set
            {			
                if (_dlqyxgztzcs as object == null || !_dlqyxgztzcs.Equals(value))
                {
                    _dlqyxgztzcs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sgtzcs
        /// 属性描述：事故跳闸次数
        /// 字段信息：[sgtzcs],int
        /// </summary>
        [DisplayNameAttribute("事故跳闸次数")]
        public int sgtzcs
        {
            get { return _sgtzcs; }
            set
            {			
                if (_sgtzcs as object == null || !_sgtzcs.Equals(value))
                {
                    _sgtzcs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdfzcs
        /// 属性描述：手动分闸次数
        /// 字段信息：[sdfzcs],int
        /// </summary>
        [DisplayNameAttribute("手动分闸次数")]
        public int sdfzcs
        {
            get { return _sdfzcs; }
            set
            {			
                if (_sdfzcs as object == null || !_sdfzcs.Equals(value))
                {
                    _sdfzcs = value;
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
        /// 属性名称：bhzhzzdqk
        /// 属性描述：保护、重合闸动作情况及跳闸原因
        /// 字段信息：[bhzhzzdqk],nvarchar
        /// </summary>
        [DisplayNameAttribute("保护、重合闸动作情况及跳闸原因")]
        public string bhzhzzdqk
        {
            get { return _bhzhzzdqk; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[保护、重合闸动作情况及跳闸原因]长度不能大于500!");
                if (_bhzhzzdqk as object == null || !_bhzhzzdqk.Equals(value))
                {
                    _bhzhzzdqk = value;
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
