/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-20 9:00:51
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[mPost]业务实体类
    ///对应表名:mPost
    /// </summary>
    [Serializable]
    public class mPost
    {
        
        #region Private 成员
        private string _postid=Newid(); 
        private string _postcode=String.Empty; 
        private string _postname=String.Empty; 
        private string _posttype=String.Empty; 
        private string _parentid=String.Empty; 
        private string _remark=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：PostID
        /// 属性描述：岗位ID
        /// 字段信息：[PostID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("岗位ID")]
        public string PostID
        {
            get { return _postid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[岗位ID]长度不能大于50!");
                if (_postid as object == null || !_postid.Equals(value))
                {
                    _postid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：PostCode
        /// 属性描述：岗位编号
        /// 字段信息：[PostCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("岗位编号")]
        public string PostCode
        {
            get { return _postcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[岗位编号]长度不能大于50!");
                if (_postcode as object == null || !_postcode.Equals(value))
                {
                    _postcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：PostName
        /// 属性描述：岗位名称
        /// 字段信息：[PostName],nvarchar
        /// </summary>
        [DisplayNameAttribute("岗位名称")]
        public string PostName
        {
            get { return _postname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[岗位名称]长度不能大于50!");
                if (_postname as object == null || !_postname.Equals(value))
                {
                    _postname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：PostType
        /// 属性描述：岗位分类
        /// 字段信息：[PostType],nvarchar
        /// </summary>
        [DisplayNameAttribute("岗位分类")]
        public string PostType
        {
            get { return _posttype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[岗位分类]长度不能大于50!");
                if (_posttype as object == null || !_posttype.Equals(value))
                {
                    _posttype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ParentID
        /// 属性描述：上级岗位
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("上级岗位")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[上级岗位]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
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
