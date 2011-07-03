/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-7-2 11:14:49
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[mUserModule]业务实体类
    ///对应表名:mUserModule
    /// </summary>
    [Serializable]
    public class mUserModule
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _userid=String.Empty; 
        private string _mmouleid=String.Empty; 
        private int _sortid=0; 
        private string _mmoulename=String.Empty; 
        private string _mmouleparentid=String.Empty;   
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
        /// 属性名称：UserID
        /// 属性描述：
        /// 字段信息：[UserID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string UserID
        {
            get { return _userid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_userid as object == null || !_userid.Equals(value))
                {
                    _userid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：mMouleID
        /// 属性描述：
        /// 字段信息：[mMouleID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string mMouleID
        {
            get { return _mmouleid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_mmouleid as object == null || !_mmouleid.Equals(value))
                {
                    _mmouleid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SortID
        /// 属性描述：
        /// 字段信息：[SortID],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int SortID
        {
            get { return _sortid; }
            set
            {			
                if (_sortid as object == null || !_sortid.Equals(value))
                {
                    _sortid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：mMouleName
        /// 属性描述：
        /// 字段信息：[mMouleName],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string mMouleName
        {
            get { return _mmoulename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 100)
                throw new Exception("[]长度不能大于100!");
                if (_mmoulename as object == null || !_mmoulename.Equals(value))
                {
                    _mmoulename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：mMouleParentID
        /// 属性描述：
        /// 字段信息：[mMouleParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string mMouleParentID
        {
            get { return _mmouleparentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_mmouleparentid as object == null || !_mmouleparentid.Equals(value))
                {
                    _mmouleparentid = value;
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
