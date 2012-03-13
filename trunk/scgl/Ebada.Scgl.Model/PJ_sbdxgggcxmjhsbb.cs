/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-3-13 21:44:13
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_sbdxgggcxmjhsbb]业务实体类
    ///对应表名:PJ_sbdxgggcxmjhsbb
    /// </summary>
    [Serializable]
    public class PJ_sbdxgggcxmjhsbb
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _xsjmc=String.Empty; 
        private string _gcmc=String.Empty; 
        private string _zybr=String.Empty; 
        private string _wcsj=String.Empty; 
        private string _dgzj=String.Empty; 
        private string _qtzj=String.Empty; 
        private string _sxzjsum=String.Empty; 
        private string _dsjfzr=String.Empty; 
        private string _xsjfzr=String.Empty; 
        private string _shr=String.Empty; 
        private string _tbr=String.Empty; 
        private DateTime _tbrq=new DateTime(1900,1,1); 
        private string _remark=String.Empty; 
        private string _s1=String.Empty; 
        private string _s2=String.Empty; 
        private string _s3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xsjmc
        /// 属性描述：县（市）局
        /// 字段信息：[xsjmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("县（市）局")]
        public string xsjmc
        {
            get { return _xsjmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[县（市）局]长度不能大于50!");
                if (_xsjmc as object == null || !_xsjmc.Equals(value))
                {
                    _xsjmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gcmc
        /// 属性描述：工程项目名称
        /// 字段信息：[gcmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("工程项目名称")]
        public string gcmc
        {
            get { return _gcmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[工程项目名称]长度不能大于500!");
                if (_gcmc as object == null || !_gcmc.Equals(value))
                {
                    _gcmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zybr
        /// 属性描述：主要内容及措施
        /// 字段信息：[zybr],nvarchar
        /// </summary>
        [DisplayNameAttribute("主要内容及措施")]
        public string zybr
        {
            get { return _zybr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[主要内容及措施]长度不能大于500!");
                if (_zybr as object == null || !_zybr.Equals(value))
                {
                    _zybr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wcsj
        /// 属性描述：完成时间
        /// 字段信息：[wcsj],nvarchar
        /// </summary>
        [DisplayNameAttribute("完成时间")]
        public string wcsj
        {
            get { return _wcsj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[完成时间]长度不能大于50!");
                if (_wcsj as object == null || !_wcsj.Equals(value))
                {
                    _wcsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dgzj
        /// 属性描述：所需资金（万元）大改资金
        /// 字段信息：[dgzj],nvarchar
        /// </summary>
        [DisplayNameAttribute("所需资金（万元）大改资金")]
        public string dgzj
        {
            get { return _dgzj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[所需资金（万元）大改资金]长度不能大于50!");
                if (_dgzj as object == null || !_dgzj.Equals(value))
                {
                    _dgzj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qtzj
        /// 属性描述：所需资金（万元）其他
        /// 字段信息：[qtzj],nvarchar
        /// </summary>
        [DisplayNameAttribute("所需资金（万元）其他")]
        public string qtzj
        {
            get { return _qtzj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[所需资金（万元）其他]长度不能大于50!");
                if (_qtzj as object == null || !_qtzj.Equals(value))
                {
                    _qtzj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sxzjsum
        /// 属性描述：所需资金（万元）合计
        /// 字段信息：[sxzjsum],nvarchar
        /// </summary>
        [DisplayNameAttribute("所需资金（万元）合计")]
        public string sxzjsum
        {
            get { return _sxzjsum; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[所需资金（万元）合计]长度不能大于50!");
                if (_sxzjsum as object == null || !_sxzjsum.Equals(value))
                {
                    _sxzjsum = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dsjfzr
        /// 属性描述：地（市）局负责人
        /// 字段信息：[dsjfzr],nvarchar
        /// </summary>
        [DisplayNameAttribute("地（市）局负责人")]
        public string dsjfzr
        {
            get { return _dsjfzr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[地（市）局负责人]长度不能大于50!");
                if (_dsjfzr as object == null || !_dsjfzr.Equals(value))
                {
                    _dsjfzr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xsjfzr
        /// 属性描述：县（市）局负责人
        /// 字段信息：[xsjfzr],nvarchar
        /// </summary>
        [DisplayNameAttribute("县（市）局负责人")]
        public string xsjfzr
        {
            get { return _xsjfzr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[县（市）局负责人]长度不能大于50!");
                if (_xsjfzr as object == null || !_xsjfzr.Equals(value))
                {
                    _xsjfzr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：shr
        /// 属性描述：审核人
        /// 字段信息：[shr],nvarchar
        /// </summary>
        [DisplayNameAttribute("审核人")]
        public string shr
        {
            get { return _shr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[审核人]长度不能大于50!");
                if (_shr as object == null || !_shr.Equals(value))
                {
                    _shr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tbr
        /// 属性描述：填报人
        /// 字段信息：[tbr],nvarchar
        /// </summary>
        [DisplayNameAttribute("填报人")]
        public string tbr
        {
            get { return _tbr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[填报人]长度不能大于50!");
                if (_tbr as object == null || !_tbr.Equals(value))
                {
                    _tbr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tbrq
        /// 属性描述：填报日期
        /// 字段信息：[tbrq],datetime
        /// </summary>
        [DisplayNameAttribute("填报日期")]
        public DateTime tbrq
        {
            get { return _tbrq; }
            set
            {			
                if (_tbrq as object == null || !_tbrq.Equals(value))
                {
                    _tbrq = value;
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
                if( value.ToString().Length > 500)
                throw new Exception("[备注]长度不能大于500!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S1
        /// 属性描述：
        /// 字段信息：[S1],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string S1
        {
            get { return _s1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_s1 as object == null || !_s1.Equals(value))
                {
                    _s1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S2
        /// 属性描述：
        /// 字段信息：[S2],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string S2
        {
            get { return _s2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_s2 as object == null || !_s2.Equals(value))
                {
                    _s2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S3
        /// 属性描述：
        /// 字段信息：[S3],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string S3
        {
            get { return _s3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_s3 as object == null || !_s3.Equals(value))
                {
                    _s3 = value;
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
