/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Itop隐患排查
模块:系统平台
Itop.com 版权所有
生成者：Rabbit
生成时间:2011-12-19 17:01:33
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Itop.YHPC.Model
{
    /// <summary>
    ///[TX_Project]业务实体类
    ///对应表名:TX_Project
    /// </summary>
    [Serializable]
    public class TX_Project
    {
        
        #region Private 成员
        private string _proid=Newid(); 
        private string _parentid=String.Empty; 
        private string _projectname=String.Empty; 
        private string _projectcode=String.Empty; 
        private string _description=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1); 
        private string _createman=String.Empty; 
        private string _exattribute=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ProID
        /// 属性描述：
        /// 字段信息：[ProID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string ProID
        {
            get { return _proid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_proid as object == null || !_proid.Equals(value))
                {
                    _proid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ParentID
        /// 属性描述：
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ProjectName
        /// 属性描述：
        /// 字段信息：[ProjectName],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ProjectName
        {
            get { return _projectname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 150)
                throw new Exception("[]长度不能大于150!");
                if (_projectname as object == null || !_projectname.Equals(value))
                {
                    _projectname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ProjectCode
        /// 属性描述：
        /// 字段信息：[ProjectCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ProjectCode
        {
            get { return _projectcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_projectcode as object == null || !_projectcode.Equals(value))
                {
                    _projectcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Description
        /// 属性描述：
        /// 字段信息：[Description],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Description
        {
            get { return _description; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[]长度不能大于250!");
                if (_description as object == null || !_description.Equals(value))
                {
                    _description = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateDate
        /// 属性描述：
        /// 字段信息：[CreateDate],datetime
        /// </summary>
        [DisplayNameAttribute("")]
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
        /// 属性名称：CreateMan
        /// 属性描述：
        /// 字段信息：[CreateMan],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string CreateMan
        {
            get { return _createman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_createman as object == null || !_createman.Equals(value))
                {
                    _createman = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ExAttribute
        /// 属性描述：
        /// 字段信息：[ExAttribute],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ExAttribute
        {
            get { return _exattribute; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 4000)
                throw new Exception("[]长度不能大于4000!");
                if (_exattribute as object == null || !_exattribute.Equals(value))
                {
                    _exattribute = value;
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
