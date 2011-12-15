/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-12-15 20:42:03
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_bpbjjhb]业务实体类
    ///对应表名:PJ_bpbjjhb
    /// </summary>
    [Serializable]
    public class PJ_bpbjjhb
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgname=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _clmc=String.Empty; 
        private string _clgg=String.Empty; 
        private string _cldw=String.Empty; 
        private string _clsl=String.Empty; 
        private string _status=String.Empty; 
        private string _cfdd=String.Empty; 
        private string _jhnf=String.Empty; 
        private string _zrr=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1); 
        private string _remark=String.Empty; 
        private string _s1=String.Empty; 
        private string _s2=String.Empty; 
        private string _s3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：唯一标识
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("唯一标识")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[唯一标识]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgName
        /// 属性描述：供电所名称
        /// 字段信息：[OrgName],nchar
        /// </summary>
        [DisplayNameAttribute("供电所名称")]
        public string OrgName
        {
            get { return _orgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                    throw new Exception("[供电所名称]长度不能大于50!");
                if (_orgname as object == null || !_orgname.Equals(value))
                {
                    _orgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：供电所代码
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("供电所代码")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[供电所代码]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：clmc
        /// 属性描述：材料名称
        /// 字段信息：[clmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("材料名称")]
        public string clmc
        {
            get { return _clmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[材料名称]长度不能大于250!");
                if (_clmc as object == null || !_clmc.Equals(value))
                {
                    _clmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：clgg
        /// 属性描述：材料规格
        /// 字段信息：[clgg],nvarchar
        /// </summary>
        [DisplayNameAttribute("材料规格")]
        public string clgg
        {
            get { return _clgg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[材料规格]长度不能大于50!");
                if (_clgg as object == null || !_clgg.Equals(value))
                {
                    _clgg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cldw
        /// 属性描述：材料单位
        /// 字段信息：[cldw],nvarchar
        /// </summary>
        [DisplayNameAttribute("材料单位")]
        public string cldw
        {
            get { return _cldw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[材料单位]长度不能大于50!");
                if (_cldw as object == null || !_cldw.Equals(value))
                {
                    _cldw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：clsl
        /// 属性描述：材料数量
        /// 字段信息：[clsl],nvarchar
        /// </summary>
        [DisplayNameAttribute("材料数量")]
        public string clsl
        {
            get { return _clsl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[材料数量]长度不能大于50!");
                if (_clsl as object == null || !_clsl.Equals(value))
                {
                    _clsl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Status
        /// 属性描述：状态
        /// 字段信息：[Status],nvarchar
        /// </summary>
        [DisplayNameAttribute("状态")]
        public string Status
        {
            get { return _status; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[状态]长度不能大于50!");
                if (_status as object == null || !_status.Equals(value))
                {
                    _status = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cfdd
        /// 属性描述：存放地点
        /// 字段信息：[cfdd],nvarchar
        /// </summary>
        [DisplayNameAttribute("存放地点")]
        public string cfdd
        {
            get { return _cfdd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[存放地点]长度不能大于250!");
                if (_cfdd as object == null || !_cfdd.Equals(value))
                {
                    _cfdd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jhnf
        /// 属性描述：计划年份
        /// 字段信息：[jhnf],nvarchar
        /// </summary>
        [DisplayNameAttribute("计划年份")]
        public string jhnf
        {
            get { return _jhnf; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[计划年份]长度不能大于50!");
                if (_jhnf as object == null || !_jhnf.Equals(value))
                {
                    _jhnf = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zrr
        /// 属性描述：责任人
        /// 字段信息：[zrr],nvarchar
        /// </summary>
        [DisplayNameAttribute("责任人")]
        public string zrr
        {
            get { return _zrr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[责任人]长度不能大于50!");
                if (_zrr as object == null || !_zrr.Equals(value))
                {
                    _zrr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateDate
        /// 属性描述：填写日期
        /// 字段信息：[CreateDate],datetime
        /// </summary>
        [DisplayNameAttribute("填写日期")]
        public DateTime CreateDate
        {
            get { return _createdate; }
            set
            {			
                if (_createdate as object == null || !_createdate.Equals(value))
                {
                    _createdate = value;
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
  
        /// <summary>
        /// 属性名称：S1
        /// 属性描述：备用
        /// 字段信息：[S1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用")]
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
        /// 属性描述：备用
        /// 字段信息：[S2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用")]
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
