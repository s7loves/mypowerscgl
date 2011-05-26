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
    ///[PS_gjyb]业务实体类
    ///对应表名:PS_gjyb
    /// </summary>
    [Serializable]
    public class PS_gjyb
    {
        
        #region Private 成员
        private string _sbid=Newid(); 
        private string _orgid=String.Empty; 
        private string _sbcode=String.Empty; 
        private string _sbname=String.Empty; 
        private string _jdgg=String.Empty; 
        private string _dw=String.Empty; 
        private int _sl=0; 
        private string _cj=String.Empty; 
        private DateTime _lqsj=new DateTime(1900,1,1); 
        private string _remark=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：sbID
        /// 属性描述：设备ID
        /// 字段信息：[sbID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("设备ID")]
        public string sbID
        {
            get { return _sbid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备ID]长度不能大于50!");
                if (_sbid as object == null || !_sbid.Equals(value))
                {
                    _sbid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgID
        /// 属性描述：部门ID
        /// 字段信息：[OrgID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("部门ID")]
        public string OrgID
        {
            get { return _orgid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[部门ID]长度不能大于50!");
                if (_orgid as object == null || !_orgid.Equals(value))
                {
                    _orgid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbCode
        /// 属性描述：设备编号
        /// 字段信息：[sbCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备编号")]
        public string sbCode
        {
            get { return _sbcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备编号]长度不能大于50!");
                if (_sbcode as object == null || !_sbcode.Equals(value))
                {
                    _sbcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbName
        /// 属性描述：设备名称
        /// 字段信息：[sbName],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备名称")]
        public string sbName
        {
            get { return _sbname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备名称]长度不能大于50!");
                if (_sbname as object == null || !_sbname.Equals(value))
                {
                    _sbname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jdgg
        /// 属性描述：规格精度
        /// 字段信息：[jdgg],nvarchar
        /// </summary>
        [DisplayNameAttribute("规格精度")]
        public string jdgg
        {
            get { return _jdgg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[规格精度]长度不能大于50!");
                if (_jdgg as object == null || !_jdgg.Equals(value))
                {
                    _jdgg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dw
        /// 属性描述：单位
        /// 字段信息：[dw],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位")]
        public string dw
        {
            get { return _dw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位]长度不能大于50!");
                if (_dw as object == null || !_dw.Equals(value))
                {
                    _dw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sl
        /// 属性描述：数量
        /// 字段信息：[sl],int
        /// </summary>
        [DisplayNameAttribute("数量")]
        public int sl
        {
            get { return _sl; }
            set
            {			
                if (_sl as object == null || !_sl.Equals(value))
                {
                    _sl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cj
        /// 属性描述：制造厂家
        /// 字段信息：[cj],nvarchar
        /// </summary>
        [DisplayNameAttribute("制造厂家")]
        public string cj
        {
            get { return _cj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[制造厂家]长度不能大于50!");
                if (_cj as object == null || !_cj.Equals(value))
                {
                    _cj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lqsj
        /// 属性描述：领取时间
        /// 字段信息：[lqsj],datetime
        /// </summary>
        [DisplayNameAttribute("领取时间")]
        public DateTime lqsj
        {
            get { return _lqsj; }
            set
            {			
                if (_lqsj as object == null || !_lqsj.Equals(value))
                {
                    _lqsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Remark
        /// 属性描述：备注
        /// 字段信息：[Remark],nvarchar
        /// </summary>
        [DisplayNameAttribute("备注")]
        public string Remark
        {
            get { return _remark; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备注]长度不能大于50!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
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
