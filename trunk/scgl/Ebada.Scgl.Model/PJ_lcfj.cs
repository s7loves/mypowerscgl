/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-10-6 10:57:47
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_lcfj]业务实体类
    ///对应表名:PJ_lcfj
    /// </summary>
    [Serializable]
    public class PJ_lcfj
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _recordid=String.Empty; 
        private string _filename=String.Empty; 
        private long _filesize=0; 
        private string _filerelativepath=String.Empty; 
        private DateTime _creattime=new DateTime(1900,1,1);   
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
        /// 属性名称：RecordID
        /// 属性描述：对应记录ID
        /// 字段信息：[RecordID],nvarchar
        /// </summary>
        [DisplayNameAttribute("对应记录ID")]
        public string RecordID
        {
            get { return _recordid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[对应记录ID]长度不能大于50!");
                if (_recordid as object == null || !_recordid.Equals(value))
                {
                    _recordid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Filename
        /// 属性描述：文件名
        /// 字段信息：[Filename],nvarchar
        /// </summary>
        [DisplayNameAttribute("文件名")]
        public string Filename
        {
            get { return _filename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[文件名]长度不能大于250!");
                if (_filename as object == null || !_filename.Equals(value))
                {
                    _filename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FileSize
        /// 属性描述：文件大小
        /// 字段信息：[FileSize],bigint
        /// </summary>
        [DisplayNameAttribute("文件大小")]
        public long FileSize
        {
            get { return _filesize; }
            set
            {			
                if (_filesize as object == null || !_filesize.Equals(value))
                {
                    _filesize = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FileRelativePath
        /// 属性描述：文件服务器相对路径
        /// 字段信息：[FileRelativePath],nvarchar
        /// </summary>
        [DisplayNameAttribute("文件服务器相对路径")]
        public string FileRelativePath
        {
            get { return _filerelativepath; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[文件服务器相对路径]长度不能大于250!");
                if (_filerelativepath as object == null || !_filerelativepath.Equals(value))
                {
                    _filerelativepath = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Creattime
        /// 属性描述：创建时间
        /// 字段信息：[Creattime],datetime
        /// </summary>
        [DisplayNameAttribute("创建时间")]
        public DateTime Creattime
        {
            get { return _creattime; }
            set
            {			
                if (_creattime as object == null || !_creattime.Equals(value))
                {
                    _creattime = value;
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
