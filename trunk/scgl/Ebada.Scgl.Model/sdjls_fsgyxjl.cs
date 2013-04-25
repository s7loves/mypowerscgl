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
    ///[sdjls_fsgyxjl]业务实体类
    ///对应表名:sdjls_fsgyxjl
    /// </summary>
    [Serializable]
    public class sdjls_fsgyxjl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private DateTime _yxrq=new DateTime(1900,1,1); 
        private DateTime _kssj=new DateTime(1900,1,1); 
        private DateTime _jssj=new DateTime(1900,1,1); 
        private string _yxdw=String.Empty; 
        private string _yxdd=String.Empty; 
        private string _yxtmid=String.Empty; 
        private string _yxtm=String.Empty; 
        private string _ldr=String.Empty; 
        private string _jhr=String.Empty; 
        private string _jljpj=String.Empty; 
        private string _ndcs=String.Empty; 
        private string _zxr=String.Empty; 
        private DateTime _zgxq=new DateTime(1900,1,1); 
        private string _qzldr=String.Empty; 
        private string _qzjhr=String.Empty; 
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
        /// 属性名称：OrgName
        /// 属性描述：单位名称
        /// 字段信息：[OrgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位名称")]
        public string OrgName
        {
            get { return _orgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位名称]长度不能大于50!");
                if (_orgname as object == null || !_orgname.Equals(value))
                {
                    _orgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：yxrq
        /// 属性描述：演习日期
        /// 字段信息：[yxrq],datetime
        /// </summary>
        [DisplayNameAttribute("演习日期")]
        public DateTime yxrq
        {
            get { return _yxrq; }
            set
            {			
                if (_yxrq as object == null || !_yxrq.Equals(value))
                {
                    _yxrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kssj
        /// 属性描述：开始时间
        /// 字段信息：[kssj],datetime
        /// </summary>
        [DisplayNameAttribute("开始时间")]
        public DateTime kssj
        {
            get { return _kssj; }
            set
            {			
                if (_kssj as object == null || !_kssj.Equals(value))
                {
                    _kssj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jssj
        /// 属性描述：结束时间
        /// 字段信息：[jssj],datetime
        /// </summary>
        [DisplayNameAttribute("结束时间")]
        public DateTime jssj
        {
            get { return _jssj; }
            set
            {			
                if (_jssj as object == null || !_jssj.Equals(value))
                {
                    _jssj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：yxdw
        /// 属性描述：演习单位
        /// 字段信息：[yxdw],nvarchar
        /// </summary>
        [DisplayNameAttribute("演习单位")]
        public string yxdw
        {
            get { return _yxdw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[演习单位]长度不能大于50!");
                if (_yxdw as object == null || !_yxdw.Equals(value))
                {
                    _yxdw = value;
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
        /// 属性名称：yxtmID
        /// 属性描述：演习题目ID
        /// 字段信息：[yxtmID],nvarchar
        /// </summary>
        [DisplayNameAttribute("演习题目ID")]
        public string yxtmID
        {
            get { return _yxtmid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[演习题目ID]长度不能大于50!");
                if (_yxtmid as object == null || !_yxtmid.Equals(value))
                {
                    _yxtmid = value;
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
                if( value.ToString().Length > 500)
                throw new Exception("[演习题目]长度不能大于500!");
                if (_yxtm as object == null || !_yxtm.Equals(value))
                {
                    _yxtm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ldr
        /// 属性描述：领导人
        /// 字段信息：[ldr],nvarchar
        /// </summary>
        [DisplayNameAttribute("领导人")]
        public string ldr
        {
            get { return _ldr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[领导人]长度不能大于50!");
                if (_ldr as object == null || !_ldr.Equals(value))
                {
                    _ldr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jhr
        /// 属性描述：监护人
        /// 字段信息：[jhr],nvarchar
        /// </summary>
        [DisplayNameAttribute("监护人")]
        public string jhr
        {
            get { return _jhr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[监护人]长度不能大于50!");
                if (_jhr as object == null || !_jhr.Equals(value))
                {
                    _jhr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jljpj
        /// 属性描述：结论及对参加演习人的评价
        /// 字段信息：[jljpj],nvarchar
        /// </summary>
        [DisplayNameAttribute("结论及对参加演习人的评价")]
        public string jljpj
        {
            get { return _jljpj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 2000)
                throw new Exception("[结论及对参加演习人的评价]长度不能大于2000!");
                if (_jljpj as object == null || !_jljpj.Equals(value))
                {
                    _jljpj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ndcs
        /// 属性描述：根据演习结果拟定的措施
        /// 字段信息：[ndcs],nvarchar
        /// </summary>
        [DisplayNameAttribute("根据演习结果拟定的措施")]
        public string ndcs
        {
            get { return _ndcs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[根据演习结果拟定的措施]长度不能大于500!");
                if (_ndcs as object == null || !_ndcs.Equals(value))
                {
                    _ndcs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zxr
        /// 属性描述：执行人
        /// 字段信息：[zxr],nvarchar
        /// </summary>
        [DisplayNameAttribute("执行人")]
        public string zxr
        {
            get { return _zxr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[执行人]长度不能大于50!");
                if (_zxr as object == null || !_zxr.Equals(value))
                {
                    _zxr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zgxq
        /// 属性描述：整改期限
        /// 字段信息：[zgxq],datetime
        /// </summary>
        [DisplayNameAttribute("整改期限")]
        public DateTime zgxq
        {
            get { return _zgxq; }
            set
            {			
                if (_zgxq as object == null || !_zgxq.Equals(value))
                {
                    _zgxq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qzldr
        /// 属性描述：签字领导人
        /// 字段信息：[qzldr],nvarchar
        /// </summary>
        [DisplayNameAttribute("签字领导人")]
        public string qzldr
        {
            get { return _qzldr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[签字领导人]长度不能大于50!");
                if (_qzldr as object == null || !_qzldr.Equals(value))
                {
                    _qzldr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qzjhr
        /// 属性描述：签字监护人
        /// 字段信息：[qzjhr],nvarchar
        /// </summary>
        [DisplayNameAttribute("签字监护人")]
        public string qzjhr
        {
            get { return _qzjhr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[签字监护人]长度不能大于50!");
                if (_qzjhr as object == null || !_qzjhr.Equals(value))
                {
                    _qzjhr = value;
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
