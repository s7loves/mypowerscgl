/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-8-26 19:54:09
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_23]业务实体类
    ///对应表名:PJ_23
    /// </summary>
    [Serializable]
    public class PJ_23
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _cqfw=String.Empty; 
        private string _cqdw=String.Empty;
        private string _jf = String.Empty;
        private DateTime _qdrq=new DateTime(1900,1,1); 
        private string _qxydd=String.Empty; 
        private string _xybh=String.Empty; 
        private string _remark=String.Empty; 
        private string _gzrjid=String.Empty; 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1);
        private string _linename = String.Empty;
        private string _fzlinename = String.Empty;
        private string _gh = String.Empty; 
        private byte[] _bigdata=new byte[]{};   
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
        /// 属性名称：cqfw
        /// 属性描述：产权范围
        /// 字段信息：[cqfw],nvarchar
        /// </summary>
        [DisplayNameAttribute("产权范围")]
        public string cqfw
        {
            get { return _cqfw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[产权范围]长度不能大于250!");
                if (_cqfw as object == null || !_cqfw.Equals(value))
                {
                    _cqfw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cqdw
        /// 属性描述：产权单位
        /// 字段信息：[cqdw],nvarchar
        /// </summary>
        [DisplayNameAttribute("产权单位")]
        public string cqdw
        {
            get { return _cqdw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[产权单位]长度不能大于50!");
                if (_cqdw as object == null || !_cqdw.Equals(value))
                {
                    _cqdw = value;
                }
            }			 
        }
        /// <summary>
        /// 属性名称：cqdw
        /// 属性描述：产权单位
        /// 字段信息：[cqdw],nvarchar
        /// </summary>
        [DisplayNameAttribute("甲方")]
        public string jf
        {
            get { return _jf; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[产权单位]长度不能大于50!");
                if (_jf as object == null || !_jf.Equals(value))
                {
                    _jf = value;
                }
            }
        }
        /// <summary>
        /// 属性名称：qdrq
        /// 属性描述：签订日期
        /// 字段信息：[qdrq],datetime
        /// </summary>
        [DisplayNameAttribute("签订日期")]
        public DateTime qdrq
        {
            get { return _qdrq; }
            set
            {			
                if (_qdrq as object == null || !_qdrq.Equals(value))
                {
                    _qdrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qxydd
        /// 属性描述：签协议地点
        /// 字段信息：[qxydd],nvarchar
        /// </summary>
        [DisplayNameAttribute("签协议地点")]
        public string qxydd
        {
            get { return _qxydd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[签协议地点]长度不能大于50!");
                if (_qxydd as object == null || !_qxydd.Equals(value))
                {
                    _qxydd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xybh
        /// 属性描述：协议编号
        /// 字段信息：[xybh],nvarchar
        /// </summary>
        [DisplayNameAttribute("协议编号")]
        public string xybh
        {
            get { return _xybh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[协议编号]长度不能大于50!");
                if (_xybh as object == null || !_xybh.Equals(value))
                {
                    _xybh = value;
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
        /// 属性名称：linename
        /// 属性描述：线路
        /// 字段信息：[linename],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路")]
        public string linename
        {
            get { return _linename; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[备注]长度不能大于50!");
                if (_linename as object == null || !_linename.Equals(value))
                {
                    _linename = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：fzlinename
        /// 属性描述：分支
        /// 字段信息：[fzlinename],nvarchar
        /// </summary>
        [DisplayNameAttribute("分支")]
        public string fzlinename
        {
            get { return _fzlinename; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[gzrjID]长度不能大于50!");
                if (_fzlinename as object == null || !_fzlinename.Equals(value))
                {
                    _fzlinename = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：gh
        /// 属性描述：杆号
        /// 字段信息：[gh],nvarchar
        /// </summary>
        [DisplayNameAttribute("杆号")]
        public string gh
        {
            get { return _gh; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 10)
                    throw new Exception("[操作员]长度不能大于10!");
                if (_gh as object == null || !_gh.Equals(value))
                {
                    _gh = value;
                }
            }
        }
        /// <summary>
        /// 属性名称：BigData
        /// 属性描述：生成文档
        /// 字段信息：[BigData],image
        /// </summary>
        [DisplayNameAttribute("生成文档")]
        public byte[] BigData
        {
            get { return _bigdata; }
            set
            {			
                if (_bigdata as object == null || !_bigdata.Equals(value))
                {
                    _bigdata = value;
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
