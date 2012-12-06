/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-12-6 12:21:45
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_kgjctj]业务实体类
    ///对应表名:PS_kgjctj
    /// </summary>
    [Serializable]
    public class PS_kgjctj
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _kgid=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private DateTime _createtime=new DateTime(1900,1,1); 
        private string _pdcxmc=String.Empty; 
        private string _xdfw=String.Empty; 
        private string _kgmodel=String.Empty; 
        private bool _iscxkg=false; 
        private string _kgcode=String.Empty; 
        private string _jkdxcd=String.Empty; 
        private string _dlxlcd=String.Empty; 
        private int _publicusercount=0; 
        private int _publicbtcount=0; 
        private int _publicbtrlcount=0; 
        private int _zyusercount=0; 
        private int _zybtcount=0; 
        private int _zybtrlcount=0; 
        private int _sdyusercount=0; 
        private int _sdyrlcount=0; 
        private int _zyuserqtsbcount=0; 
        private int _drqcount=0; 
        private string _drqrl=String.Empty; 
        private int _zyuserqtsbrlcount=0;   
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
        /// 属性名称：kgID
        /// 属性描述：开关ID
        /// 字段信息：[kgID],nvarchar
        /// </summary>
        [DisplayNameAttribute("开关ID")]
        public string kgID
        {
            get { return _kgid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[开关ID]长度不能大于50!");
                if (_kgid as object == null || !_kgid.Equals(value))
                {
                    _kgid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：设备管理单位编号
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备管理单位编号")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备管理单位编号]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgName
        /// 属性描述：设备管理单位
        /// 字段信息：[OrgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备管理单位")]
        public string OrgName
        {
            get { return _orgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备管理单位]长度不能大于50!");
                if (_orgname as object == null || !_orgname.Equals(value))
                {
                    _orgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateTime
        /// 属性描述：统计日期
        /// 字段信息：[CreateTime],datetime
        /// </summary>
        [DisplayNameAttribute("统计日期")]
        public DateTime CreateTime
        {
            get { return _createtime; }
            set
            {			
                if (_createtime as object == null || !_createtime.Equals(value))
                {
                    _createtime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：pdcxmc
        /// 属性描述：配电出线名称
        /// 字段信息：[pdcxmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("配电出线名称")]
        public string pdcxmc
        {
            get { return _pdcxmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[配电出线名称]长度不能大于50!");
                if (_pdcxmc as object == null || !_pdcxmc.Equals(value))
                {
                    _pdcxmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xdfw
        /// 属性描述：线段范围
        /// 字段信息：[xdfw],nvarchar
        /// </summary>
        [DisplayNameAttribute("线段范围")]
        public string xdfw
        {
            get { return _xdfw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线段范围]长度不能大于50!");
                if (_xdfw as object == null || !_xdfw.Equals(value))
                {
                    _xdfw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgModel
        /// 属性描述：开关型号
        /// 字段信息：[kgModel],nvarchar
        /// </summary>
        [DisplayNameAttribute("开关型号")]
        public string kgModel
        {
            get { return _kgmodel; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[开关型号]长度不能大于50!");
                if (_kgmodel as object == null || !_kgmodel.Equals(value))
                {
                    _kgmodel = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：iscxkg
        /// 属性描述：是否出线开关
        /// 字段信息：[iscxkg],bit
        /// </summary>
        [DisplayNameAttribute("是否出线开关")]
        public bool iscxkg
        {
            get { return _iscxkg; }
            set
            {			
                if (_iscxkg as object == null || !_iscxkg.Equals(value))
                {
                    _iscxkg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgCode
        /// 属性描述：开关编号
        /// 字段信息：[kgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("开关编号")]
        public string kgCode
        {
            get { return _kgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[开关编号]长度不能大于50!");
                if (_kgcode as object == null || !_kgcode.Equals(value))
                {
                    _kgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jkdxcd
        /// 属性描述：架空导线长度
        /// 字段信息：[jkdxcd],nvarchar
        /// </summary>
        [DisplayNameAttribute("架空导线长度")]
        public string jkdxcd
        {
            get { return _jkdxcd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[架空导线长度]长度不能大于50!");
                if (_jkdxcd as object == null || !_jkdxcd.Equals(value))
                {
                    _jkdxcd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dlxlcd
        /// 属性描述：电缆线路长度
        /// 字段信息：[dlxlcd],nvarchar
        /// </summary>
        [DisplayNameAttribute("电缆线路长度")]
        public string dlxlcd
        {
            get { return _dlxlcd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电缆线路长度]长度不能大于50!");
                if (_dlxlcd as object == null || !_dlxlcd.Equals(value))
                {
                    _dlxlcd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：publicusercount
        /// 属性描述：公用用户数
        /// 字段信息：[publicusercount],int
        /// </summary>
        [DisplayNameAttribute("公用用户数")]
        public int publicusercount
        {
            get { return _publicusercount; }
            set
            {			
                if (_publicusercount as object == null || !_publicusercount.Equals(value))
                {
                    _publicusercount = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：publicbtcount
        /// 属性描述：公用变台数
        /// 字段信息：[publicbtcount],int
        /// </summary>
        [DisplayNameAttribute("公用变台数")]
        public int publicbtcount
        {
            get { return _publicbtcount; }
            set
            {			
                if (_publicbtcount as object == null || !_publicbtcount.Equals(value))
                {
                    _publicbtcount = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：publicbtrlcount
        /// 属性描述：公用变台总容量
        /// 字段信息：[publicbtrlcount],int
        /// </summary>
        [DisplayNameAttribute("公用变台总容量")]
        public int publicbtrlcount
        {
            get { return _publicbtrlcount; }
            set
            {			
                if (_publicbtrlcount as object == null || !_publicbtrlcount.Equals(value))
                {
                    _publicbtrlcount = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zyusercount
        /// 属性描述：专用用户数
        /// 字段信息：[zyusercount],int
        /// </summary>
        [DisplayNameAttribute("专用用户数")]
        public int zyusercount
        {
            get { return _zyusercount; }
            set
            {			
                if (_zyusercount as object == null || !_zyusercount.Equals(value))
                {
                    _zyusercount = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zybtcount
        /// 属性描述：专用变台数
        /// 字段信息：[zybtcount],int
        /// </summary>
        [DisplayNameAttribute("专用变台数")]
        public int zybtcount
        {
            get { return _zybtcount; }
            set
            {			
                if (_zybtcount as object == null || !_zybtcount.Equals(value))
                {
                    _zybtcount = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zybtrlcount
        /// 属性描述：专用变台总容量
        /// 字段信息：[zybtrlcount],int
        /// </summary>
        [DisplayNameAttribute("专用变台总容量")]
        public int zybtrlcount
        {
            get { return _zybtrlcount; }
            set
            {			
                if (_zybtrlcount as object == null || !_zybtrlcount.Equals(value))
                {
                    _zybtrlcount = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdyusercount
        /// 属性描述：双电源用户数
        /// 字段信息：[sdyusercount],int
        /// </summary>
        [DisplayNameAttribute("双电源用户数")]
        public int sdyusercount
        {
            get { return _sdyusercount; }
            set
            {			
                if (_sdyusercount as object == null || !_sdyusercount.Equals(value))
                {
                    _sdyusercount = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdyrlcount
        /// 属性描述：双电源容量
        /// 字段信息：[sdyrlcount],int
        /// </summary>
        [DisplayNameAttribute("双电源容量")]
        public int sdyrlcount
        {
            get { return _sdyrlcount; }
            set
            {			
                if (_sdyrlcount as object == null || !_sdyrlcount.Equals(value))
                {
                    _sdyrlcount = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zyuserqtsbcount
        /// 属性描述：专用户其它设备台数
        /// 字段信息：[zyuserqtsbcount],int
        /// </summary>
        [DisplayNameAttribute("专用户其它设备台数")]
        public int zyuserqtsbcount
        {
            get { return _zyuserqtsbcount; }
            set
            {			
                if (_zyuserqtsbcount as object == null || !_zyuserqtsbcount.Equals(value))
                {
                    _zyuserqtsbcount = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：drqcount
        /// 属性描述：电容器台数
        /// 字段信息：[drqcount],int
        /// </summary>
        [DisplayNameAttribute("电容器台数")]
        public int drqcount
        {
            get { return _drqcount; }
            set
            {			
                if (_drqcount as object == null || !_drqcount.Equals(value))
                {
                    _drqcount = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：drqrl
        /// 属性描述：电容器容量
        /// 字段信息：[drqrl],nvarchar
        /// </summary>
        [DisplayNameAttribute("电容器容量")]
        public string drqrl
        {
            get { return _drqrl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电容器容量]长度不能大于50!");
                if (_drqrl as object == null || !_drqrl.Equals(value))
                {
                    _drqrl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zyuserqtsbrlcount
        /// 属性描述：专用户其它设备容量
        /// 字段信息：[zyuserqtsbrlcount],int
        /// </summary>
        [DisplayNameAttribute("专用户其它设备容量")]
        public int zyuserqtsbrlcount
        {
            get { return _zyuserqtsbrlcount; }
            set
            {			
                if (_zyuserqtsbrlcount as object == null || !_zyuserqtsbrlcount.Equals(value))
                {
                    _zyuserqtsbrlcount = value;
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
