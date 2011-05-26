/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-26 20:54:00
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_gzrjnr]业务实体类
    ///对应表名:PJ_gzrjnr
    /// </summary>
    [Serializable]
    public class PJ_gzrjnr
    {
        
        #region Private 成员
        private string _gznrid=Newid(); 
        private string _gzrjid=String.Empty; 
        private DateTime _fssj=new DateTime(1900,1,1); 
        private int _seq=0; 
        private string _gznr=String.Empty; 
        private string _fzr=String.Empty; 
        private string _cjry=String.Empty; 
        private string _parentid=String.Empty; 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1);   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：gznrID
        /// 属性描述：内容ID
        /// 字段信息：[gznrID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("内容ID")]
        public string gznrID
        {
            get { return _gznrid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[内容ID]长度不能大于50!");
                if (_gznrid as object == null || !_gznrid.Equals(value))
                {
                    _gznrid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gzrjID
        /// 属性描述：工作日记ID
        /// 字段信息：[gzrjID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("工作日记ID")]
        public string gzrjID
        {
            get { return _gzrjid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[工作日记ID]长度不能大于50!");
                if (_gzrjid as object == null || !_gzrjid.Equals(value))
                {
                    _gzrjid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fssj
        /// 属性描述：发生时间
        /// 字段信息：[fssj],datetime
        /// </summary>
        [DisplayNameAttribute("发生时间")]
        public DateTime fssj
        {
            get { return _fssj; }
            set
            {			
                if (_fssj as object == null || !_fssj.Equals(value))
                {
                    _fssj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：seq
        /// 属性描述：序号
        /// 字段信息：[seq],int
        /// </summary>
        [DisplayNameAttribute("序号")]
        public int seq
        {
            get { return _seq; }
            set
            {			
                if (_seq as object == null || !_seq.Equals(value))
                {
                    _seq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gznr
        /// 属性描述：工作内容
        /// 字段信息：[gznr],nvarchar
        /// </summary>
        [DisplayNameAttribute("工作内容")]
        public string gznr
        {
            get { return _gznr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[工作内容]长度不能大于500!");
                if (_gznr as object == null || !_gznr.Equals(value))
                {
                    _gznr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fzr
        /// 属性描述：负责人
        /// 字段信息：[fzr],nvarchar
        /// </summary>
        [DisplayNameAttribute("负责人")]
        public string fzr
        {
            get { return _fzr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[负责人]长度不能大于50!");
                if (_fzr as object == null || !_fzr.Equals(value))
                {
                    _fzr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cjry
        /// 属性描述：参加人员
        /// 字段信息：[cjry],nvarchar
        /// </summary>
        [DisplayNameAttribute("参加人员")]
        public string cjry
        {
            get { return _cjry; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[参加人员]长度不能大于200!");
                if (_cjry as object == null || !_cjry.Equals(value))
                {
                    _cjry = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ParentID
        /// 属性描述：关联记录
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("关联记录")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[关联记录]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateMan
        /// 属性描述：填写人
        /// 字段信息：[CreateMan],nvarchar
        /// </summary>
        [DisplayNameAttribute("填写人")]
        public string CreateMan
        {
            get { return _createman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[填写人]长度不能大于10!");
                if (_createman as object == null || !_createman.Equals(value))
                {
                    _createman = value;
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
