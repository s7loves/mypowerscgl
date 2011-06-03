/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-20 9:00:50
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[mOrg]业务实体类
    ///对应表名:mOrg
    /// </summary>
    [Serializable]
    public class mOrg
    {
        
        #region Private 成员

        private string _orgid=Newid(); 
        private string _parentid=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _orgcode2=String.Empty; 
        private string _orgtype=String.Empty; 
        private DateTime _psafetime=new DateTime(1900,1,1); 
        private DateTime _dsafetime=new DateTime(1900,1,1); 
        private string _remark=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty; 
        private string _c4=String.Empty; 
        private string _c5=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
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
        /// 属性名称：ParentID
        /// 属性描述：上级部门
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("上级部门")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[上级部门]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：部门编号
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("部门编号")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[部门编号]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgName
        /// 属性描述：部门名称
        /// 字段信息：[OrgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("部门名称")]
        public string OrgName
        {
            get { return _orgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[部门名称]长度不能大于50!");
                if (_orgname as object == null || !_orgname.Equals(value))
                {
                    _orgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgCode2
        /// 属性描述：部门原编号
        /// 字段信息：[OrgCode2],nvarchar
        /// </summary>
        [DisplayNameAttribute("部门原编号")]
        public string OrgCode2
        {
            get { return _orgcode2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[部门原编号]长度不能大于50!");
                if (_orgcode2 as object == null || !_orgcode2.Equals(value))
                {
                    _orgcode2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgType
        /// 属性描述：部门种类
        /// 字段信息：[OrgType],nvarchar
        /// </summary>
        [DisplayNameAttribute("部门种类")]
        public string OrgType
        {
            get { return _orgtype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[部门种类]长度不能大于50!");
                if (_orgtype as object == null || !_orgtype.Equals(value))
                {
                    _orgtype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：PSafeTime
        /// 属性描述：人生安全启始时间
        /// 字段信息：[PSafeTime],datetime
        /// </summary>
        [DisplayNameAttribute("人生安全启始时间")]
        public DateTime PSafeTime
        {
            get { return _psafetime; }
            set
            {			
                if (_psafetime as object == null || !_psafetime.Equals(value))
                {
                    _psafetime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：DSafeTime
        /// 属性描述：设备安全启始时间
        /// 字段信息：[DSafeTime],datetime
        /// </summary>
        [DisplayNameAttribute("设备安全启始时间")]
        public DateTime DSafeTime
        {
            get { return _dsafetime; }
            set
            {			
                if (_dsafetime as object == null || !_dsafetime.Equals(value))
                {
                    _dsafetime = value;
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
                if( value.ToString().Length > 200)
                throw new Exception("[备注]长度不能大于200!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C1
        /// 属性描述：未定义
        /// 字段信息：[C1],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("未定义")]
        public string C1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[未定义]长度不能大于200!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C2
        /// 属性描述：未定义2
        /// 字段信息：[C2],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("未定义2")]
        public string C2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[未定义2]长度不能大于200!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C3
        /// 属性描述：未定义3
        /// 字段信息：[C3],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("未定义3")]
        public string C3
        {
            get { return _c3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[未定义3]长度不能大于200!");
                if (_c3 as object == null || !_c3.Equals(value))
                {
                    _c3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C4
        /// 属性描述：未定义4
        /// 字段信息：[C4],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("未定义4")]
        public string C4
        {
            get { return _c4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[未定义4]长度不能大于200!");
                if (_c4 as object == null || !_c4.Equals(value))
                {
                    _c4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C5
        /// 属性描述：未定义5
        /// 字段信息：[C5],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("未定义5")]
        public string C5
        {
            get { return _c5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[未定义5]长度不能大于200!");
                if (_c5 as object == null || !_c5.Equals(value))
                {
                    _c5 = value;
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
