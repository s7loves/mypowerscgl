/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-6-5 8:54:04
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[xxgx_aqxpj]业务实体类
    ///对应表名:xxgx_aqxpj
    /// </summary>
    [Serializable]
    public class xxgx_aqxpj
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _year=String.Empty; 
        private string _filename=String.Empty; 
        private string _scsj=String.Empty; 
        private string _scry=String.Empty; 
        private byte[] _filedata=new byte[]{}; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：id
        /// 属性描述：
        /// 字段信息：[id],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("id")]
        public string id
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[id]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：orgcode
        /// 属性描述：
        /// 字段信息：[orgcode],nvarchar
        /// </summary>
        [DisplayNameAttribute("orgcode")]
        public string orgcode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[orgcode]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：year
        /// 属性描述：
        /// 字段信息：[year],nvarchar
        /// </summary>
        [DisplayNameAttribute("year")]
        public string year
        {
            get { return _year; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[year]长度不能大于50!");
                if (_year as object == null || !_year.Equals(value))
                {
                    _year = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：filename
        /// 属性描述：文件名
        /// 字段信息：[filename],nvarchar
        /// </summary>
        [DisplayNameAttribute("文件名")]
        public string filename
        {
            get { return _filename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[文件名]长度不能大于50!");
                if (_filename as object == null || !_filename.Equals(value))
                {
                    _filename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：scsj
        /// 属性描述：上传时间
        /// 字段信息：[scsj],nvarchar
        /// </summary>
        [DisplayNameAttribute("上传时间")]
        public string scsj
        {
            get { return _scsj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[上传时间]长度不能大于50!");
                if (_scsj as object == null || !_scsj.Equals(value))
                {
                    _scsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：scry
        /// 属性描述：上传人
        /// 字段信息：[scry],nvarchar
        /// </summary>
        [DisplayNameAttribute("上传人")]
        public string scry
        {
            get { return _scry; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[上传人]长度不能大于50!");
                if (_scry as object == null || !_scry.Equals(value))
                {
                    _scry = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：filedata
        /// 属性描述：
        /// 字段信息：[filedata],image
        /// </summary>
        [DisplayNameAttribute("filedata")]
        public byte[] filedata
        {
            get { return _filedata; }
            set
            {			
                if (_filedata as object == null || !_filedata.Equals(value))
                {
                    _filedata = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c1
        /// 属性描述：
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [DisplayNameAttribute("c1")]
        public string c1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[c1]长度不能大于50!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c2
        /// 属性描述：
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [DisplayNameAttribute("c2")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[c2]长度不能大于50!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c3
        /// 属性描述：
        /// 字段信息：[c3],nvarchar
        /// </summary>
        [DisplayNameAttribute("c3")]
        public string c3
        {
            get { return _c3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[c3]长度不能大于50!");
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
