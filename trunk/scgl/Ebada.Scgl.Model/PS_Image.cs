/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-7-29 22:15:46
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_Image]业务实体类
    ///对应表名:PS_Image
    /// </summary>
    [Serializable]
    public class PS_Image
    {
        
        #region Private 成员
        private string _imageid=Newid(); 
        private string _imagename=String.Empty; 
        private string _remark=String.Empty; 
        private string _imagetype=String.Empty; 
        private byte[] _imagedata=new byte[]{};   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ImageID
        /// 属性描述：设备ID
        /// 字段信息：[ImageID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("设备ID")]
        public string ImageID
        {
            get { return _imageid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备ID]长度不能大于50!");
                if (_imageid as object == null || !_imageid.Equals(value))
                {
                    _imageid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ImageName
        /// 属性描述：图片名称
        /// 字段信息：[ImageName],nvarchar
        /// </summary>
        [DisplayNameAttribute("图片名称")]
        public string ImageName
        {
            get { return _imagename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[图片名称]长度不能大于50!");
                if (_imagename as object == null || !_imagename.Equals(value))
                {
                    _imagename = value;
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
                if( value.ToString().Length > 150)
                throw new Exception("[备注]长度不能大于150!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ImageType
        /// 属性描述：分类
        /// 字段信息：[ImageType],nvarchar
        /// </summary>
        [DisplayNameAttribute("分类")]
        public string ImageType
        {
            get { return _imagetype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[分类]长度不能大于50!");
                if (_imagetype as object == null || !_imagetype.Equals(value))
                {
                    _imagetype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ImageData
        /// 属性描述：图片
        /// 字段信息：[ImageData],image
        /// </summary>
        [DisplayNameAttribute("图片")]
        public byte[] ImageData
        {
            get { return _imagedata; }
            set
            {			
                if (_imagedata as object == null || !_imagedata.Equals(value))
                {
                    _imagedata = value;
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
