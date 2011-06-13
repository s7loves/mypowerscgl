/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-13 16:45:22
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_22]业务实体类
    ///对应表名:PJ_22
    /// </summary>
    [Serializable]
    public class PJ_22
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _ph=String.Empty; 
        private DateTime _bxsj=new DateTime(1900,1,1); 
        private string _bxdd=String.Empty; 
        private string _xlfzr=String.Empty; 
        private string _xlry=String.Empty; 
        private string _zbslr=String.Empty; 
        private string _bggzqc=String.Empty; 
        private string _bgfs=String.Empty; 
        private string _bxrxm=String.Empty; 
        private string _lxdh=String.Empty; 
        private string _sjgzqc=String.Empty; 
        private string _sycl=String.Empty; 
        private DateTime _dsj=new DateTime(1900,1,1); 
        private DateTime _wsj=new DateTime(1900,1,1); 
        private string _jhry=String.Empty; 
        private string _czry=String.Empty; 
        private string _yhqm=String.Empty; 
        private DateTime _tdsj=new DateTime(1900,1,1); 
        private DateTime _sdsj=new DateTime(1900,1,1); 
        private string _tdxl=String.Empty; 
        private string _czxm=String.Empty; 
        private string _ddsb=String.Empty; 
        private string _wxd=String.Empty; 
        private string _cljg=String.Empty; 
        private string _remark=String.Empty; 
        private string _gzrjid=String.Empty; 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1);   
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
        /// 属性描述：ParentID
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("ParentID")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[ParentID]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
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
        /// 属性名称：OrgName
        /// 属性描述：供电所名称
        /// 字段信息：[OrgName],nvarchar
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
        /// 属性名称：ph
        /// 属性描述：票号
        /// 字段信息：[ph],nvarchar
        /// </summary>
        [DisplayNameAttribute("票号")]
        public string ph
        {
            get { return _ph; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[票号]长度不能大于50!");
                if (_ph as object == null || !_ph.Equals(value))
                {
                    _ph = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bxsj
        /// 属性描述：报修时期时间
        /// 字段信息：[bxsj],datetime
        /// </summary>
        [DisplayNameAttribute("报修时期时间")]
        public DateTime bxsj
        {
            get { return _bxsj; }
            set
            {			
                if (_bxsj as object == null || !_bxsj.Equals(value))
                {
                    _bxsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bxdd
        /// 属性描述：报修地点
        /// 字段信息：[bxdd],nvarchar
        /// </summary>
        [DisplayNameAttribute("报修地点")]
        public string bxdd
        {
            get { return _bxdd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[报修地点]长度不能大于50!");
                if (_bxdd as object == null || !_bxdd.Equals(value))
                {
                    _bxdd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xlfzr
        /// 属性描述：修理负责人
        /// 字段信息：[xlfzr],nvarchar
        /// </summary>
        [DisplayNameAttribute("修理负责人")]
        public string xlfzr
        {
            get { return _xlfzr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[修理负责人]长度不能大于50!");
                if (_xlfzr as object == null || !_xlfzr.Equals(value))
                {
                    _xlfzr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xlry
        /// 属性描述：修理人员
        /// 字段信息：[xlry],nvarchar
        /// </summary>
        [DisplayNameAttribute("修理人员")]
        public string xlry
        {
            get { return _xlry; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[修理人员]长度不能大于50!");
                if (_xlry as object == null || !_xlry.Equals(value))
                {
                    _xlry = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zbslr
        /// 属性描述：值班受理人
        /// 字段信息：[zbslr],nvarchar
        /// </summary>
        [DisplayNameAttribute("值班受理人")]
        public string zbslr
        {
            get { return _zbslr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[值班受理人]长度不能大于50!");
                if (_zbslr as object == null || !_zbslr.Equals(value))
                {
                    _zbslr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bggzqc
        /// 属性描述：报修故障情况
        /// 字段信息：[bggzqc],nvarchar
        /// </summary>
        [DisplayNameAttribute("报修故障情况")]
        public string bggzqc
        {
            get { return _bggzqc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[报修故障情况]长度不能大于50!");
                if (_bggzqc as object == null || !_bggzqc.Equals(value))
                {
                    _bggzqc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bgfs
        /// 属性描述：报告方式
        /// 字段信息：[bgfs],nvarchar
        /// </summary>
        [DisplayNameAttribute("报告方式")]
        public string bgfs
        {
            get { return _bgfs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[报告方式]长度不能大于50!");
                if (_bgfs as object == null || !_bgfs.Equals(value))
                {
                    _bgfs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bxrxm
        /// 属性描述：报修人姓名
        /// 字段信息：[bxrxm],nvarchar
        /// </summary>
        [DisplayNameAttribute("报修人姓名")]
        public string bxrxm
        {
            get { return _bxrxm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[报修人姓名]长度不能大于50!");
                if (_bxrxm as object == null || !_bxrxm.Equals(value))
                {
                    _bxrxm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lxdh
        /// 属性描述：联系电话
        /// 字段信息：[lxdh],nvarchar
        /// </summary>
        [DisplayNameAttribute("联系电话")]
        public string lxdh
        {
            get { return _lxdh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[联系电话]长度不能大于50!");
                if (_lxdh as object == null || !_lxdh.Equals(value))
                {
                    _lxdh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sjgzqc
        /// 属性描述：实际故障情况
        /// 字段信息：[sjgzqc],nvarchar
        /// </summary>
        [DisplayNameAttribute("实际故障情况")]
        public string sjgzqc
        {
            get { return _sjgzqc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[实际故障情况]长度不能大于50!");
                if (_sjgzqc as object == null || !_sjgzqc.Equals(value))
                {
                    _sjgzqc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sycl
        /// 属性描述：所有材料
        /// 字段信息：[sycl],nvarchar
        /// </summary>
        [DisplayNameAttribute("所有材料")]
        public string sycl
        {
            get { return _sycl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[所有材料]长度不能大于50!");
                if (_sycl as object == null || !_sycl.Equals(value))
                {
                    _sycl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dsj
        /// 属性描述：到现场时间
        /// 字段信息：[dsj],datetime
        /// </summary>
        [DisplayNameAttribute("到现场时间")]
        public DateTime dsj
        {
            get { return _dsj; }
            set
            {			
                if (_dsj as object == null || !_dsj.Equals(value))
                {
                    _dsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wsj
        /// 属性描述：处理完毕时间
        /// 字段信息：[wsj],datetime
        /// </summary>
        [DisplayNameAttribute("处理完毕时间")]
        public DateTime wsj
        {
            get { return _wsj; }
            set
            {			
                if (_wsj as object == null || !_wsj.Equals(value))
                {
                    _wsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jhry
        /// 属性描述：监护人
        /// 字段信息：[jhry],nvarchar
        /// </summary>
        [DisplayNameAttribute("监护人")]
        public string jhry
        {
            get { return _jhry; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[监护人]长度不能大于50!");
                if (_jhry as object == null || !_jhry.Equals(value))
                {
                    _jhry = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：czry
        /// 属性描述：操作人
        /// 字段信息：[czry],nvarchar
        /// </summary>
        [DisplayNameAttribute("操作人")]
        public string czry
        {
            get { return _czry; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[操作人]长度不能大于50!");
                if (_czry as object == null || !_czry.Equals(value))
                {
                    _czry = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：yhqm
        /// 属性描述：用户签名
        /// 字段信息：[yhqm],nvarchar
        /// </summary>
        [DisplayNameAttribute("用户签名")]
        public string yhqm
        {
            get { return _yhqm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[用户签名]长度不能大于50!");
                if (_yhqm as object == null || !_yhqm.Equals(value))
                {
                    _yhqm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdsj
        /// 属性描述：停电时间
        /// 字段信息：[tdsj],datetime
        /// </summary>
        [DisplayNameAttribute("停电时间")]
        public DateTime tdsj
        {
            get { return _tdsj; }
            set
            {			
                if (_tdsj as object == null || !_tdsj.Equals(value))
                {
                    _tdsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdsj
        /// 属性描述：送电时间
        /// 字段信息：[sdsj],datetime
        /// </summary>
        [DisplayNameAttribute("送电时间")]
        public DateTime sdsj
        {
            get { return _sdsj; }
            set
            {			
                if (_sdsj as object == null || !_sdsj.Equals(value))
                {
                    _sdsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdxl
        /// 属性描述：停电线路杆号
        /// 字段信息：[tdxl],nvarchar
        /// </summary>
        [DisplayNameAttribute("停电线路杆号")]
        public string tdxl
        {
            get { return _tdxl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[停电线路杆号]长度不能大于50!");
                if (_tdxl as object == null || !_tdxl.Equals(value))
                {
                    _tdxl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：czxm
        /// 属性描述：操作项目
        /// 字段信息：[czxm],nvarchar
        /// </summary>
        [DisplayNameAttribute("操作项目")]
        public string czxm
        {
            get { return _czxm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 150)
                throw new Exception("[操作项目]长度不能大于150!");
                if (_czxm as object == null || !_czxm.Equals(value))
                {
                    _czxm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ddsb
        /// 属性描述：临近带电设备
        /// 字段信息：[ddsb],nvarchar
        /// </summary>
        [DisplayNameAttribute("临近带电设备")]
        public string ddsb
        {
            get { return _ddsb; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 150)
                throw new Exception("[临近带电设备]长度不能大于150!");
                if (_ddsb as object == null || !_ddsb.Equals(value))
                {
                    _ddsb = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wxd
        /// 属性描述：危险点及安措
        /// 字段信息：[wxd],nvarchar
        /// </summary>
        [DisplayNameAttribute("危险点及安措")]
        public string wxd
        {
            get { return _wxd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[危险点及安措]长度不能大于500!");
                if (_wxd as object == null || !_wxd.Equals(value))
                {
                    _wxd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cljg
        /// 属性描述：故障处理经过及结果
        /// 字段信息：[cljg],nvarchar
        /// </summary>
        [DisplayNameAttribute("故障处理经过及结果")]
        public string cljg
        {
            get { return _cljg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[故障处理经过及结果]长度不能大于500!");
                if (_cljg as object == null || !_cljg.Equals(value))
                {
                    _cljg = value;
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
        /// 属性名称：gzrjID
        /// 属性描述：gzrjID
        /// 字段信息：[gzrjID],nvarchar
        /// </summary>
        [DisplayNameAttribute("gzrjID")]
        public string gzrjID
        {
            get { return _gzrjid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[gzrjID]长度不能大于50!");
                if (_gzrjid as object == null || !_gzrjid.Equals(value))
                {
                    _gzrjid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateMan
        /// 属性描述：操作员
        /// 字段信息：[CreateMan],nvarchar
        /// </summary>
        [DisplayNameAttribute("操作员")]
        public string CreateMan
        {
            get { return _createman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[操作员]长度不能大于10!");
                if (_createman as object == null || !_createman.Equals(value))
                {
                    _createman = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateDate
        /// 属性描述：生成日期
        /// 字段信息：[CreateDate],datetime
        /// </summary>
        [DisplayNameAttribute("生成日期")]
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
