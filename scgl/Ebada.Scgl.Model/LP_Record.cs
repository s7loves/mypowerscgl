/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-7-5 10:26:10
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[LP_Record]业务实体类
    ///对应表名:LP_Record
    /// </summary>
    [Serializable]
    public class LP_Record
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _content=String.Empty; 
        private byte[] _doccontent=new byte[]{}; 
        private string _kind=String.Empty; 
        private byte[] _signimg=new byte[]{}; 
        private byte[] _imageattachment=new byte[]{}; 
        private int _sortid=0; 
        private string _createtime=String.Empty; 
        private string _lastchangetime=String.Empty; 
        private string _status=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：唯一ID
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("唯一ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[唯一ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ParentID
        /// 属性描述：父ID
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("父ID")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[父ID]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Content
        /// 属性描述：所有控件上的内容，格式：控件ID，控件内容|
   
        /// 字段信息：[Content],nvarchar
        /// </summary>
        [DisplayNameAttribute("所有控件上的内容，格式：控件ID，控件内容|")]
        public string Content
        {
            get { return _content; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[所有控件上的内容，格式：控件ID，控件内容|]长度不能大于1073741823!");
                if (_content as object == null || !_content.Equals(value))
                {
                    _content = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：DocContent
        /// 属性描述：修改后的文档内容
        /// 字段信息：[DocContent],image
        /// </summary>
        [DisplayNameAttribute("修改后的文档内容")]
        public byte[] DocContent
        {
            get { return _doccontent; }
            set
            {			
                if (_doccontent as object == null || !_doccontent.Equals(value))
                {
                    _doccontent = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Kind
        /// 属性描述：票种
        /// 字段信息：[Kind],nvarchar
        /// </summary>
        [DisplayNameAttribute("票种")]
        public string Kind
        {
            get { return _kind; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[票种]长度不能大于50!");
                if (_kind as object == null || !_kind.Equals(value))
                {
                    _kind = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SignImg
        /// 属性描述：签名
        /// 字段信息：[SignImg],image
        /// </summary>
        [DisplayNameAttribute("签名")]
        public byte[] SignImg
        {
            get { return _signimg; }
            set
            {			
                if (_signimg as object == null || !_signimg.Equals(value))
                {
                    _signimg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ImageAttachment
        /// 属性描述：附件
        /// 字段信息：[ImageAttachment],image
        /// </summary>
        [DisplayNameAttribute("附件")]
        public byte[] ImageAttachment
        {
            get { return _imageattachment; }
            set
            {			
                if (_imageattachment as object == null || !_imageattachment.Equals(value))
                {
                    _imageattachment = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SortID
        /// 属性描述：排序ID
        /// 字段信息：[SortID],int
        /// </summary>
        [DisplayNameAttribute("排序ID")]
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
        /// 属性名称：CreateTime
        /// 属性描述：创建时间
        /// 字段信息：[CreateTime],nvarchar
        /// </summary>
        [DisplayNameAttribute("创建时间")]
        public string CreateTime
        {
            get { return _createtime; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[创建时间]长度不能大于50!");
                if (_createtime as object == null || !_createtime.Equals(value))
                {
                    _createtime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LastChangeTime
        /// 属性描述：上次修改时间
        /// 字段信息：[LastChangeTime],nvarchar
        /// </summary>
        [DisplayNameAttribute("上次修改时间")]
        public string LastChangeTime
        {
            get { return _lastchangetime; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[上次修改时间]长度不能大于50!");
                if (_lastchangetime as object == null || !_lastchangetime.Equals(value))
                {
                    _lastchangetime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Status
        /// 属性描述：
        /// 字段信息：[Status],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Status
        {
            get { return _status; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_status as object == null || !_status.Equals(value))
                {
                    _status = value;
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
