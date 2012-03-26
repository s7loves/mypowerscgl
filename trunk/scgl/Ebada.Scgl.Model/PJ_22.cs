/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-9-10 14:04:53
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
        private string _tdxlgt=String.Empty; 
        private string _czxm=String.Empty; 
        private string _ddsb=String.Empty; 
        private string _wxd=String.Empty; 
        private string _cljg=String.Empty; 
        private string _remark=String.Empty; 
        private string _gzrjid=String.Empty; 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1); 
        private bool _tdcz1xz=false; 
        private bool _tdcz1cz=false; 
        private bool _tdcz2xz=false; 
        private bool _tdcz2cz=false; 
        private bool _tdcz3xz=false; 
        private bool _tdcz3cz=false; 
        private bool _tdcz4xz=false; 
        private bool _tdcz4cz=false; 
        private bool _tdcz5xz=false; 
        private bool _tdcz5cz=false; 
        private bool _tdcz6xz=false; 
        private bool _tdcz6cz=false; 
        private bool _tdcz7xz=false; 
        private bool _tdcz7cz=false; 
        private bool _tdcz8xz=false; 
        private bool _tdcz8cz=false; 
        private string _tdczjxname1=String.Empty; 
        private string _tdczjxname2=String.Empty; 
        private string _tdczjxname3=String.Empty; 
        private bool _sdcz1xz=false; 
        private bool _sdcz1cz=false; 
        private bool _sdcz2xz=false; 
        private bool _sdcz2cz=false; 
        private bool _sdcz3xz=false; 
        private bool _sdcz3cz=false; 
        private bool _sdcz4xz=false; 
        private bool _sdcz4cz=false; 
        private bool _sdcz5xz=false; 
        private bool _sdcz5cz=false; 
        private bool _sdcz6xz=false; 
        private bool _sdcz6cz=false; 
        private bool _sdcz7xz=false; 
        private bool _sdcz7cz=false; 
        private bool _sdcz8xz=false; 
        private bool _sdcz8cz=false; 
        private string _sdczjxname1=String.Empty; 
        private string _sdczjxname2=String.Empty;   
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
        /// 属性描述：停电线路
        /// 字段信息：[tdxl],nvarchar
        /// </summary>
        [DisplayNameAttribute("停电线路")]
        public string tdxl
        {
            get { return _tdxl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[停电线路]长度不能大于50!");
                if (_tdxl as object == null || !_tdxl.Equals(value))
                {
                    _tdxl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdxlgt
        /// 属性描述：停电线路杆号
        /// 字段信息：[tdxlgt],nvarchar
        /// </summary>
        [DisplayNameAttribute("停电线路杆号")]
        public string tdxlgt
        {
            get { return _tdxlgt; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[停电线路杆号]长度不能大于50!");
                if (_tdxlgt as object == null || !_tdxlgt.Equals(value))
                {
                    _tdxlgt = value;
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
        [Browsable(false)]
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
  
        /// <summary>
        /// 属性名称：tdcz1xz
        /// 属性描述：拉开低压开关选择
        /// 字段信息：[tdcz1xz],bit
        /// </summary>
        [DisplayNameAttribute("拉开低压开关选择")]
        public bool tdcz1xz
        {
            get { return _tdcz1xz; }
            set
            {			
                if (_tdcz1xz as object == null || !_tdcz1xz.Equals(value))
                {
                    _tdcz1xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdcz1cz
        /// 属性描述：拉开低压开关操作
        /// 字段信息：[tdcz1cz],bit
        /// </summary>
        [DisplayNameAttribute("拉开低压开关操作")]
        public bool tdcz1cz
        {
            get { return _tdcz1cz; }
            set
            {			
                if (_tdcz1cz as object == null || !_tdcz1cz.Equals(value))
                {
                    _tdcz1cz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdcz2xz
        /// 属性描述：拉开低压刀闸（保险）选择
        /// 字段信息：[tdcz2xz],bit
        /// </summary>
        [DisplayNameAttribute("拉开低压刀闸（保险）选择")]
        public bool tdcz2xz
        {
            get { return _tdcz2xz; }
            set
            {			
                if (_tdcz2xz as object == null || !_tdcz2xz.Equals(value))
                {
                    _tdcz2xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdcz2cz
        /// 属性描述：拉开低压刀闸（保险）操作
        /// 字段信息：[tdcz2cz],bit
        /// </summary>
        [DisplayNameAttribute("拉开低压刀闸（保险）操作")]
        public bool tdcz2cz
        {
            get { return _tdcz2cz; }
            set
            {			
                if (_tdcz2cz as object == null || !_tdcz2cz.Equals(value))
                {
                    _tdcz2cz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdcz3xz
        /// 属性描述：拉开高压开关（跌落式熔断器）选择
        /// 字段信息：[tdcz3xz],bit
        /// </summary>
        [DisplayNameAttribute("拉开高压开关（跌落式熔断器）选择")]
        public bool tdcz3xz
        {
            get { return _tdcz3xz; }
            set
            {			
                if (_tdcz3xz as object == null || !_tdcz3xz.Equals(value))
                {
                    _tdcz3xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdcz3cz
        /// 属性描述：拉开高压开关（跌落式熔断器）操作
        /// 字段信息：[tdcz3cz],bit
        /// </summary>
        [DisplayNameAttribute("拉开高压开关（跌落式熔断器）操作")]
        public bool tdcz3cz
        {
            get { return _tdcz3cz; }
            set
            {			
                if (_tdcz3cz as object == null || !_tdcz3cz.Equals(value))
                {
                    _tdcz3cz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdcz4xz
        /// 属性描述：在变压器高压套管端子处验明三相确无电压选择
        /// 字段信息：[tdcz4xz],bit
        /// </summary>
        [DisplayNameAttribute("在变压器高压套管端子处验明三相确无电压选择")]
        public bool tdcz4xz
        {
            get { return _tdcz4xz; }
            set
            {			
                if (_tdcz4xz as object == null || !_tdcz4xz.Equals(value))
                {
                    _tdcz4xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdcz4cz
        /// 属性描述：在变压器高压套管端子处验明三相确无电压操作
        /// 字段信息：[tdcz4cz],bit
        /// </summary>
        [DisplayNameAttribute("在变压器高压套管端子处验明三相确无电压操作")]
        public bool tdcz4cz
        {
            get { return _tdcz4cz; }
            set
            {			
                if (_tdcz4cz as object == null || !_tdcz4cz.Equals(value))
                {
                    _tdcz4cz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdcz5xz
        /// 属性描述：在变压器高压套管端子处挂地#线一组选择
        /// 字段信息：[tdcz5xz],bit
        /// </summary>
        [DisplayNameAttribute("在变压器高压套管端子处挂地#线一组选择")]
        public bool tdcz5xz
        {
            get { return _tdcz5xz; }
            set
            {			
                if (_tdcz5xz as object == null || !_tdcz5xz.Equals(value))
                {
                    _tdcz5xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdcz5cz
        /// 属性描述：在变压器高压套管端子处挂地#线一组操作
        /// 字段信息：[tdcz5cz],bit
        /// </summary>
        [DisplayNameAttribute("在变压器高压套管端子处挂地#线一组操作")]
        public bool tdcz5cz
        {
            get { return _tdcz5cz; }
            set
            {			
                if (_tdcz5cz as object == null || !_tdcz5cz.Equals(value))
                {
                    _tdcz5cz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdcz6xz
        /// 属性描述：在低压侧验明三相确无电压选择
        /// 字段信息：[tdcz6xz],bit
        /// </summary>
        [DisplayNameAttribute("在低压侧验明三相确无电压选择")]
        public bool tdcz6xz
        {
            get { return _tdcz6xz; }
            set
            {			
                if (_tdcz6xz as object == null || !_tdcz6xz.Equals(value))
                {
                    _tdcz6xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdcz6cz
        /// 属性描述：在低压侧验明三相确无电压操作
        /// 字段信息：[tdcz6cz],bit
        /// </summary>
        [DisplayNameAttribute("在低压侧验明三相确无电压操作")]
        public bool tdcz6cz
        {
            get { return _tdcz6cz; }
            set
            {			
                if (_tdcz6cz as object == null || !_tdcz6cz.Equals(value))
                {
                    _tdcz6cz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdcz7xz
        /// 属性描述：在低压侧挂#地线一组选择
        /// 字段信息：[tdcz7xz],bit
        /// </summary>
        [DisplayNameAttribute("在低压侧挂#地线一组选择")]
        public bool tdcz7xz
        {
            get { return _tdcz7xz; }
            set
            {			
                if (_tdcz7xz as object == null || !_tdcz7xz.Equals(value))
                {
                    _tdcz7xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdcz7cz
        /// 属性描述：在低压侧挂#地线一组操作
        /// 字段信息：[tdcz7cz],bit
        /// </summary>
        [DisplayNameAttribute("在低压侧挂#地线一组操作")]
        public bool tdcz7cz
        {
            get { return _tdcz7cz; }
            set
            {			
                if (_tdcz7cz as object == null || !_tdcz7cz.Equals(value))
                {
                    _tdcz7cz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdcz8xz
        /// 属性描述：在工作地点挂#小地线选择
        /// 字段信息：[tdcz8xz],bit
        /// </summary>
        [DisplayNameAttribute("在工作地点挂#小地线选择")]
        public bool tdcz8xz
        {
            get { return _tdcz8xz; }
            set
            {			
                if (_tdcz8xz as object == null || !_tdcz8xz.Equals(value))
                {
                    _tdcz8xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdcz8cz
        /// 属性描述：在工作地点挂#小地线操作
        /// 字段信息：[tdcz8cz],bit
        /// </summary>
        [DisplayNameAttribute("在工作地点挂#小地线操作")]
        public bool tdcz8cz
        {
            get { return _tdcz8cz; }
            set
            {			
                if (_tdcz8cz as object == null || !_tdcz8cz.Equals(value))
                {
                    _tdcz8cz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdczjxname1
        /// 属性描述：在变压器高压套管端子处挂地#线名称
        /// 字段信息：[tdczjxname1],nvarchar
        /// </summary>
        [DisplayNameAttribute("在变压器高压套管端子处挂地#线名称")]
        public string tdczjxname1
        {
            get { return _tdczjxname1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[在变压器高压套管端子处挂地#线名称]长度不能大于50!");
                if (_tdczjxname1 as object == null || !_tdczjxname1.Equals(value))
                {
                    _tdczjxname1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdczjxname2
        /// 属性描述：在低压侧挂#地线名称
        /// 字段信息：[tdczjxname2],nvarchar
        /// </summary>
        [DisplayNameAttribute("在低压侧挂#地线名称")]
        public string tdczjxname2
        {
            get { return _tdczjxname2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[在低压侧挂#地线名称]长度不能大于50!");
                if (_tdczjxname2 as object == null || !_tdczjxname2.Equals(value))
                {
                    _tdczjxname2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tdczjxname3
        /// 属性描述：在工作地点挂#小地线名称
        /// 字段信息：[tdczjxname3],nvarchar
        /// </summary>
        [DisplayNameAttribute("在工作地点挂#小地线名称")]
        public string tdczjxname3
        {
            get { return _tdczjxname3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[在工作地点挂#小地线名称]长度不能大于50!");
                if (_tdczjxname3 as object == null || !_tdczjxname3.Equals(value))
                {
                    _tdczjxname3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdcz1xz
        /// 属性描述：检查相位是否正确选择
        /// 字段信息：[sdcz1xz],bit
        /// </summary>
        [DisplayNameAttribute("检查相位是否正确选择")]
        public bool sdcz1xz
        {
            get { return _sdcz1xz; }
            set
            {			
                if (_sdcz1xz as object == null || !_sdcz1xz.Equals(value))
                {
                    _sdcz1xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdcz1cz
        /// 属性描述：检查相位是否正确操作
        /// 字段信息：[sdcz1cz],bit
        /// </summary>
        [DisplayNameAttribute("检查相位是否正确操作")]
        public bool sdcz1cz
        {
            get { return _sdcz1cz; }
            set
            {			
                if (_sdcz1cz as object == null || !_sdcz1cz.Equals(value))
                {
                    _sdcz1cz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdcz2xz
        /// 属性描述：拆除工作地点小地线选择
        /// 字段信息：[sdcz2xz],bit
        /// </summary>
        [DisplayNameAttribute("拆除工作地点小地线选择")]
        public bool sdcz2xz
        {
            get { return _sdcz2xz; }
            set
            {			
                if (_sdcz2xz as object == null || !_sdcz2xz.Equals(value))
                {
                    _sdcz2xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdcz2cz
        /// 属性描述：拆除工作地点小地线操作
        /// 字段信息：[sdcz2cz],bit
        /// </summary>
        [DisplayNameAttribute("拆除工作地点小地线操作")]
        public bool sdcz2cz
        {
            get { return _sdcz2cz; }
            set
            {			
                if (_sdcz2cz as object == null || !_sdcz2cz.Equals(value))
                {
                    _sdcz2cz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdcz3xz
        /// 属性描述：拆出低压侧选择#线一组选择
        /// 字段信息：[sdcz3xz],bit
        /// </summary>
        [DisplayNameAttribute("拆出低压侧选择#线一组选择")]
        public bool sdcz3xz
        {
            get { return _sdcz3xz; }
            set
            {			
                if (_sdcz3xz as object == null || !_sdcz3xz.Equals(value))
                {
                    _sdcz3xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdcz3cz
        /// 属性描述：拆出低压侧选择#线一组操作
        /// 字段信息：[sdcz3cz],bit
        /// </summary>
        [DisplayNameAttribute("拆出低压侧选择#线一组操作")]
        public bool sdcz3cz
        {
            get { return _sdcz3cz; }
            set
            {			
                if (_sdcz3cz as object == null || !_sdcz3cz.Equals(value))
                {
                    _sdcz3cz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdcz4xz
        /// 属性描述：拆除变压器高压套管端子处#地线一组选择
        /// 字段信息：[sdcz4xz],bit
        /// </summary>
        [DisplayNameAttribute("拆除变压器高压套管端子处#地线一组选择")]
        public bool sdcz4xz
        {
            get { return _sdcz4xz; }
            set
            {			
                if (_sdcz4xz as object == null || !_sdcz4xz.Equals(value))
                {
                    _sdcz4xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdcz4cz
        /// 属性描述：拆除变压器高压套管端子处#地线一组操作
        /// 字段信息：[sdcz4cz],bit
        /// </summary>
        [DisplayNameAttribute("拆除变压器高压套管端子处#地线一组操作")]
        public bool sdcz4cz
        {
            get { return _sdcz4cz; }
            set
            {			
                if (_sdcz4cz as object == null || !_sdcz4cz.Equals(value))
                {
                    _sdcz4cz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdcz5xz
        /// 属性描述：合上高压开关（跌落式熔断器）选择
        /// 字段信息：[sdcz5xz],bit
        /// </summary>
        [DisplayNameAttribute("合上高压开关（跌落式熔断器）选择")]
        public bool sdcz5xz
        {
            get { return _sdcz5xz; }
            set
            {			
                if (_sdcz5xz as object == null || !_sdcz5xz.Equals(value))
                {
                    _sdcz5xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdcz5cz
        /// 属性描述：合上高压开关（跌落式熔断器）操作
        /// 字段信息：[sdcz5cz],bit
        /// </summary>
        [DisplayNameAttribute("合上高压开关（跌落式熔断器）操作")]
        public bool sdcz5cz
        {
            get { return _sdcz5cz; }
            set
            {			
                if (_sdcz5cz as object == null || !_sdcz5cz.Equals(value))
                {
                    _sdcz5cz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdcz6xz
        /// 属性描述：合上低压开关选择
        /// 字段信息：[sdcz6xz],bit
        /// </summary>
        [DisplayNameAttribute("合上低压开关选择")]
        public bool sdcz6xz
        {
            get { return _sdcz6xz; }
            set
            {			
                if (_sdcz6xz as object == null || !_sdcz6xz.Equals(value))
                {
                    _sdcz6xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdcz6cz
        /// 属性描述：合上低压开关操作
        /// 字段信息：[sdcz6cz],bit
        /// </summary>
        [DisplayNameAttribute("合上低压开关操作")]
        public bool sdcz6cz
        {
            get { return _sdcz6cz; }
            set
            {			
                if (_sdcz6cz as object == null || !_sdcz6cz.Equals(value))
                {
                    _sdcz6cz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdcz7xz
        /// 属性描述：合上低压刀闸（保险）选择
        /// 字段信息：[sdcz7xz],bit
        /// </summary>
        [DisplayNameAttribute("合上低压刀闸（保险）选择")]
        public bool sdcz7xz
        {
            get { return _sdcz7xz; }
            set
            {			
                if (_sdcz7xz as object == null || !_sdcz7xz.Equals(value))
                {
                    _sdcz7xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdcz7cz
        /// 属性描述：合上低压刀闸（保险）操作
        /// 字段信息：[sdcz7cz],bit
        /// </summary>
        [DisplayNameAttribute("合上低压刀闸（保险）操作")]
        public bool sdcz7cz
        {
            get { return _sdcz7cz; }
            set
            {			
                if (_sdcz7cz as object == null || !_sdcz7cz.Equals(value))
                {
                    _sdcz7cz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdcz8xz
        /// 属性描述：检查用户是否有电选择
        /// 字段信息：[sdcz8xz],bit
        /// </summary>
        [DisplayNameAttribute("检查用户是否有电选择")]
        public bool sdcz8xz
        {
            get { return _sdcz8xz; }
            set
            {			
                if (_sdcz8xz as object == null || !_sdcz8xz.Equals(value))
                {
                    _sdcz8xz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdcz8cz
        /// 属性描述：检查用户是否有电操作
        /// 字段信息：[sdcz8cz],bit
        /// </summary>
        [DisplayNameAttribute("检查用户是否有电操作")]
        public bool sdcz8cz
        {
            get { return _sdcz8cz; }
            set
            {			
                if (_sdcz8cz as object == null || !_sdcz8cz.Equals(value))
                {
                    _sdcz8cz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdczjxname1
        /// 属性描述：拆出低压侧选择#线名称
        /// 字段信息：[sdczjxname1],nvarchar
        /// </summary>
        [DisplayNameAttribute("拆出低压侧选择#线名称")]
        public string sdczjxname1
        {
            get { return _sdczjxname1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[拆出低压侧选择#线名称]长度不能大于50!");
                if (_sdczjxname1 as object == null || !_sdczjxname1.Equals(value))
                {
                    _sdczjxname1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdczjxname2
        /// 属性描述：拆除变压器高压套管端子处#地线名称
        /// 字段信息：[sdczjxname2],nvarchar
        /// </summary>
        [DisplayNameAttribute("拆除变压器高压套管端子处#地线名称")]
        public string sdczjxname2
        {
            get { return _sdczjxname2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[拆除变压器高压套管端子处#地线名称]长度不能大于50!");
                if (_sdczjxname2 as object == null || !_sdczjxname2.Equals(value))
                {
                    _sdczjxname2 = value;
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
