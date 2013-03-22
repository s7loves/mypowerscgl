/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-3-22 8:59:47
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sd_xsjh]业务实体类
    ///对应表名:sd_xsjh
    /// </summary>
    [Serializable]
    public class sd_xsjh
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _lineid=String.Empty; 
        private string _linename=String.Empty; 
        private string _vol=String.Empty; 
        private string _xslb=String.Empty; 
        private string _xsnr=String.Empty; 
        private string _sxr=String.Empty; 
        private DateTime _jhsj=new DateTime(1900,1,1); 
        private DateTime _xskssj=new DateTime(1900,1,1); 
        private DateTime _xswcsj=new DateTime(1900,1,1); 
        private string _wcbj=String.Empty; 
        private string _qxnr=String.Empty; 
        private string _flag=String.Empty; 
        private string _cjr=String.Empty; 
        private string _fbr=String.Empty; 
        private DateTime _fbsj=new DateTime(1900,1,1); 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty; 
        private string _c4=String.Empty; 
        private string _c5=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
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
        /// 属性名称：LineID
        /// 属性描述：线路ID
        /// 字段信息：[LineID],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路ID")]
        public string LineID
        {
            get { return _lineid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路ID]长度不能大于50!");
                if (_lineid as object == null || !_lineid.Equals(value))
                {
                    _lineid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineName
        /// 属性描述：线路名称
        /// 字段信息：[LineName],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路名称")]
        public string LineName
        {
            get { return _linename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路名称]长度不能大于50!");
                if (_linename as object == null || !_linename.Equals(value))
                {
                    _linename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：vol
        /// 属性描述：电压等级
        /// 字段信息：[vol],nvarchar
        /// </summary>
        [DisplayNameAttribute("电压等级")]
        public string vol
        {
            get { return _vol; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电压等级]长度不能大于50!");
                if (_vol as object == null || !_vol.Equals(value))
                {
                    _vol = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xslb
        /// 属性描述：巡视类别
        /// 字段信息：[xslb],nvarchar
        /// </summary>
        [DisplayNameAttribute("巡视类别")]
        public string xslb
        {
            get { return _xslb; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[巡视类别]长度不能大于50!");
                if (_xslb as object == null || !_xslb.Equals(value))
                {
                    _xslb = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xsnr
        /// 属性描述：巡视内容
        /// 字段信息：[xsnr],nvarchar
        /// </summary>
        [DisplayNameAttribute("巡视内容")]
        public string xsnr
        {
            get { return _xsnr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[巡视内容]长度不能大于50!");
                if (_xsnr as object == null || !_xsnr.Equals(value))
                {
                    _xsnr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sxr
        /// 属性描述：巡视人员
        /// 字段信息：[sxr],nvarchar
        /// </summary>
        [DisplayNameAttribute("巡视人员")]
        public string sxr
        {
            get { return _sxr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[巡视人员]长度不能大于50!");
                if (_sxr as object == null || !_sxr.Equals(value))
                {
                    _sxr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jhsj
        /// 属性描述：计划时间
        /// 字段信息：[jhsj],datetime
        /// </summary>
        [DisplayNameAttribute("计划时间")]
        public DateTime jhsj
        {
            get { return _jhsj; }
            set
            {			
                if (_jhsj as object == null || !_jhsj.Equals(value))
                {
                    _jhsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xskssj
        /// 属性描述：巡视开始时间
        /// 字段信息：[xskssj],datetime
        /// </summary>
        [DisplayNameAttribute("巡视开始时间")]
        public DateTime xskssj
        {
            get { return _xskssj; }
            set
            {			
                if (_xskssj as object == null || !_xskssj.Equals(value))
                {
                    _xskssj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xswcsj
        /// 属性描述：巡视完成时间
        /// 字段信息：[xswcsj],datetime
        /// </summary>
        [DisplayNameAttribute("巡视完成时间")]
        public DateTime xswcsj
        {
            get { return _xswcsj; }
            set
            {			
                if (_xswcsj as object == null || !_xswcsj.Equals(value))
                {
                    _xswcsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wcbj
        /// 属性描述：是否完成
        /// 字段信息：[wcbj],nvarchar
        /// </summary>
        [DisplayNameAttribute("是否完成")]
        public string wcbj
        {
            get { return _wcbj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[是否完成]长度不能大于50!");
                if (_wcbj as object == null || !_wcbj.Equals(value))
                {
                    _wcbj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qxnr
        /// 属性描述：缺陷内容
        /// 字段信息：[qxnr],nvarchar
        /// </summary>
        [DisplayNameAttribute("缺陷内容")]
        public string qxnr
        {
            get { return _qxnr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[缺陷内容]长度不能大于500!");
                if (_qxnr as object == null || !_qxnr.Equals(value))
                {
                    _qxnr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：flag
        /// 属性描述：任务状态,新建-发布-下载-完成
        /// 字段信息：[flag],nvarchar
        /// </summary>
        [DisplayNameAttribute("任务状态")]
        public string flag
        {
            get { return _flag; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[任务状态]长度不能大于50!");
                if (_flag as object == null || !_flag.Equals(value))
                {
                    _flag = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cjr
        /// 属性描述：创建人
        /// 字段信息：[cjr],nvarchar
        /// </summary>
        [DisplayNameAttribute("创建人")]
        public string cjr
        {
            get { return _cjr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[创建人]长度不能大于50!");
                if (_cjr as object == null || !_cjr.Equals(value))
                {
                    _cjr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fbr
        /// 属性描述：发布人
        /// 字段信息：[fbr],nvarchar
        /// </summary>
        [DisplayNameAttribute("发布人")]
        public string fbr
        {
            get { return _fbr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[发布人]长度不能大于50!");
                if (_fbr as object == null || !_fbr.Equals(value))
                {
                    _fbr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fbsj
        /// 属性描述：发布时间
        /// 字段信息：[fbsj],datetime
        /// </summary>
        [DisplayNameAttribute("发布时间")]
        public DateTime fbsj
        {
            get { return _fbsj; }
            set
            {			
                if (_fbsj as object == null || !_fbsj.Equals(value))
                {
                    _fbsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c1
        /// 属性描述：备
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c2
        /// 属性描述：备
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c3
        /// 属性描述：备
        /// 字段信息：[c3],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c3
        {
            get { return _c3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c3 as object == null || !_c3.Equals(value))
                {
                    _c3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c4
        /// 属性描述：备
        /// 字段信息：[c4],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c4
        {
            get { return _c4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c4 as object == null || !_c4.Equals(value))
                {
                    _c4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c5
        /// 属性描述：备
        /// 字段信息：[c5],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c5
        {
            get { return _c5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
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
