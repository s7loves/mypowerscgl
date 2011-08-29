/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-8-29 21:08:15
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_yfsyhcjl]业务实体类
    ///对应表名:PJ_yfsyhcjl
    /// </summary>
    [Serializable]
    public class PJ_yfsyhcjl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private int _xh=0; 
        private DateTime _sj=new DateTime(1900,1,1); 
        private string _yssbname=String.Empty; 
        private string _xhclname=String.Empty; 
        private string _sbmodle=String.Empty; 
        private string _dw=String.Empty; 
        private int _sl=0; 
        private string _syman=String.Empty; 
        private string _yxdwman=String.Empty; 
        private string _remark=String.Empty;   
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
        /// 属性名称：OrgCode
        /// 属性描述：单位编码
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位编码")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位编码]长度不能大于50!");
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
        /// 属性名称：xh
        /// 属性描述：序号
        /// 字段信息：[xh],int
        /// </summary>
        [DisplayNameAttribute("序号")]
        public int xh
        {
            get { return _xh; }
            set
            {			
                if (_xh as object == null || !_xh.Equals(value))
                {
                    _xh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sj
        /// 属性描述：时间
        /// 字段信息：[sj],datetime
        /// </summary>
        [DisplayNameAttribute("时间")]
        public DateTime sj
        {
            get { return _sj; }
            set
            {			
                if (_sj as object == null || !_sj.Equals(value))
                {
                    _sj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：yssbName
        /// 属性描述：预试设备名称
        /// 字段信息：[yssbName],nvarchar
        /// </summary>
        [DisplayNameAttribute("预试设备名称")]
        public string yssbName
        {
            get { return _yssbname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[预试设备名称]长度不能大于50!");
                if (_yssbname as object == null || !_yssbname.Equals(value))
                {
                    _yssbname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xhclName
        /// 属性描述：消耗材料名称
        /// 字段信息：[xhclName],nvarchar
        /// </summary>
        [DisplayNameAttribute("消耗材料名称")]
        public string xhclName
        {
            get { return _xhclname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[消耗材料名称]长度不能大于50!");
                if (_xhclname as object == null || !_xhclname.Equals(value))
                {
                    _xhclname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbModle
        /// 属性描述：规格型号
        /// 字段信息：[sbModle],nvarchar
        /// </summary>
        [DisplayNameAttribute("规格型号")]
        public string sbModle
        {
            get { return _sbmodle; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[规格型号]长度不能大于50!");
                if (_sbmodle as object == null || !_sbmodle.Equals(value))
                {
                    _sbmodle = value;
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
        /// 属性名称：syMan
        /// 属性描述：预试人员
        /// 字段信息：[syMan],nvarchar
        /// </summary>
        [DisplayNameAttribute("预试人员")]
        public string syMan
        {
            get { return _syman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[预试人员]长度不能大于50!");
                if (_syman as object == null || !_syman.Equals(value))
                {
                    _syman = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：yxdwMan
        /// 属性描述：运行单位人员
        /// 字段信息：[yxdwMan],nvarchar
        /// </summary>
        [DisplayNameAttribute("运行单位人员")]
        public string yxdwMan
        {
            get { return _yxdwman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[运行单位人员]长度不能大于50!");
                if (_yxdwman as object == null || !_yxdwman.Equals(value))
                {
                    _yxdwman = value;
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
