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
    ///[bdjl_sbjxjl]业务实体类
    ///对应表名:bdjl_sbjxjl
    /// </summary>
    [Serializable]
    public class bdjl_sbjxjl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _linecode=String.Empty; 
        private DateTime _jxrq=new DateTime(1900,1,1); 
        private string _sbmc=String.Empty; 
        private string _jxxz=String.Empty; 
        private string _jxfzr=String.Empty; 
        private string _ysr=String.Empty; 
        private string _jxxm=String.Empty; 
        private string _ysyj=String.Empty; 
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
        /// 属性名称：jxrq
        /// 属性描述：检修日期
        /// 字段信息：[jxrq],datetime
        /// </summary>
        [DisplayNameAttribute("检修日期")]
        public DateTime jxrq
        {
            get { return _jxrq; }
            set
            {			
                if (_jxrq as object == null || !_jxrq.Equals(value))
                {
                    _jxrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbmc
        /// 属性描述：设备名称
        /// 字段信息：[sbmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备名称")]
        public string sbmc
        {
            get { return _sbmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备名称]长度不能大于50!");
                if (_sbmc as object == null || !_sbmc.Equals(value))
                {
                    _sbmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jxxz
        /// 属性描述：检修性质
        /// 字段信息：[jxxz],nvarchar
        /// </summary>
        [DisplayNameAttribute("检修性质")]
        public string jxxz
        {
            get { return _jxxz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[检修性质]长度不能大于50!");
                if (_jxxz as object == null || !_jxxz.Equals(value))
                {
                    _jxxz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jxfzr
        /// 属性描述：检修负责人
        /// 字段信息：[jxfzr],nvarchar
        /// </summary>
        [DisplayNameAttribute("检修负责人")]
        public string jxfzr
        {
            get { return _jxfzr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[检修负责人]长度不能大于50!");
                if (_jxfzr as object == null || !_jxfzr.Equals(value))
                {
                    _jxfzr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ysr
        /// 属性描述：验收人
        /// 字段信息：[ysr],nvarchar
        /// </summary>
        [DisplayNameAttribute("验收人")]
        public string ysr
        {
            get { return _ysr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[验收人]长度不能大于50!");
                if (_ysr as object == null || !_ysr.Equals(value))
                {
                    _ysr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jxxm
        /// 属性描述：检修项目
        /// 字段信息：[jxxm],nvarchar
        /// </summary>
        [DisplayNameAttribute("检修项目")]
        public string jxxm
        {
            get { return _jxxm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[检修项目]长度不能大于50!");
                if (_jxxm as object == null || !_jxxm.Equals(value))
                {
                    _jxxm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ysyj
        /// 属性描述：验收意见
        /// 字段信息：[ysyj],nvarchar
        /// </summary>
        [DisplayNameAttribute("验收意见")]
        public string ysyj
        {
            get { return _ysyj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[验收意见]长度不能大于50!");
                if (_ysyj as object == null || !_ysyj.Equals(value))
                {
                    _ysyj = value;
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
