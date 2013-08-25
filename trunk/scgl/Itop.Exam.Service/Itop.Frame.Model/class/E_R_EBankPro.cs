/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ftpa辅助系统
模块:系统平台
Ftpa.com 版权所有
生成者：Rabbit
生成时间:2013-8-24 16:30:08
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Itop.Frame.Model
{
    /// <summary>
    ///[E_R_EBankPro]业务实体类
    ///对应表名:E_R_EBankPro
    /// </summary>
    [Serializable]
    public class E_R_EBankPro
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _ebid=String.Empty; 
        private string _proid=String.Empty; 
        private string _byscol1=String.Empty; 
        private string _byscol2=String.Empty; 
        private string _byscol3=String.Empty; 
        private string _byscol4=String.Empty; 
        private string _byscol5=String.Empty; 
        private string _remark=String.Empty; 
        private byte[] _rowversion=new byte[]{};   
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
        /// 属性名称：EBID
        /// 属性描述：题库
        /// 字段信息：[EBID],nvarchar
        /// </summary>
        [DisplayNameAttribute("题库")]
        public string EBID
        {
            get { return _ebid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[题库]长度不能大于50!");
                if (_ebid as object == null || !_ebid.Equals(value))
                {
                    _ebid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：PROID
        /// 属性描述：专业
        /// 字段信息：[PROID],nvarchar
        /// </summary>
        [DisplayNameAttribute("专业")]
        public string PROID
        {
            get { return _proid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[专业]长度不能大于200!");
                if (_proid as object == null || !_proid.Equals(value))
                {
                    _proid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BySCol1
        /// 属性描述：备用1
        /// 字段信息：[BySCol1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用1")]
        public string BySCol1
        {
            get { return _byscol1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备用1]长度不能大于200!");
                if (_byscol1 as object == null || !_byscol1.Equals(value))
                {
                    _byscol1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BySCol2
        /// 属性描述：备用2
        /// 字段信息：[BySCol2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用2")]
        public string BySCol2
        {
            get { return _byscol2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备用2]长度不能大于200!");
                if (_byscol2 as object == null || !_byscol2.Equals(value))
                {
                    _byscol2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BySCol3
        /// 属性描述：备用3
        /// 字段信息：[BySCol3],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用3")]
        public string BySCol3
        {
            get { return _byscol3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备用3]长度不能大于200!");
                if (_byscol3 as object == null || !_byscol3.Equals(value))
                {
                    _byscol3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BySCol4
        /// 属性描述：备用4
        /// 字段信息：[BySCol4],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用4")]
        public string BySCol4
        {
            get { return _byscol4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备用4]长度不能大于200!");
                if (_byscol4 as object == null || !_byscol4.Equals(value))
                {
                    _byscol4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BySCol5
        /// 属性描述：备用5
        /// 字段信息：[BySCol5],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用5")]
        public string BySCol5
        {
            get { return _byscol5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备用5]长度不能大于200!");
                if (_byscol5 as object == null || !_byscol5.Equals(value))
                {
                    _byscol5 = value;
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
                if( value.ToString().Length > 200)
                throw new Exception("[备注]长度不能大于200!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RowVersion
        /// 属性描述：时间戳
        /// 字段信息：[RowVersion],timestamp
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("时间戳")]
        public byte[] RowVersion
        {
            get { return _rowversion; }
            set
            {			
                if (_rowversion as object == null || !_rowversion.Equals(value))
                {
                    _rowversion = value;
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
