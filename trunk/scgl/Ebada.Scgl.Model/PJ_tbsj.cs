/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada物流企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012/3/24 13:16:11
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_tbsj]业务实体类
    ///对应表名:PJ_tbsj
    /// </summary>
    [Serializable]
    public class PJ_tbsj
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _picname=String.Empty; 
        private byte[] _picimage=new byte[]{}; 
        private string _remark=String.Empty; 
        private string _s1=String.Empty; 
        private string _s2=String.Empty; 
        private string _s3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：唯一标示
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("唯一标示")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[唯一标示]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：picName
        /// 属性描述：图标名称
        /// 字段信息：[picName],nvarchar
        /// </summary>
        [DisplayNameAttribute("图标名称")]
        public string picName
        {
            get { return _picname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[图标名称]长度不能大于50!");
                if (_picname as object == null || !_picname.Equals(value))
                {
                    _picname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：picImage
        /// 属性描述：图标数据
        /// 字段信息：[picImage],image
        /// </summary>
        [DisplayNameAttribute("图标数据")]
        public byte[] picImage
        {
            get { return _picimage; }
            set
            {			
                if (_picimage as object == null || !_picimage.Equals(value))
                {
                    _picimage = value;
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
                if( value.ToString().Length > 500)
                throw new Exception("[备注]长度不能大于500!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S1
        /// 属性描述：备用1
        /// 字段信息：[S1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用1")]
        public string S1
        {
            get { return _s1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用1]长度不能大于50!");
                if (_s1 as object == null || !_s1.Equals(value))
                {
                    _s1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S2
        /// 属性描述：备用2
        /// 字段信息：[S2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用2")]
        public string S2
        {
            get { return _s2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用2]长度不能大于50!");
                if (_s2 as object == null || !_s2.Equals(value))
                {
                    _s2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S3
        /// 属性描述：备用3
        /// 字段信息：[S3],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用3")]
        public string S3
        {
            get { return _s3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用3]长度不能大于50!");
                if (_s3 as object == null || !_s3.Equals(value))
                {
                    _s3 = value;
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
