/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-17 22:06:07
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_tq]业务实体类
    ///对应表名:PS_tq
    /// </summary>
    [Serializable]
    public class PS_tq
    {
        
        #region Private 成员
        private string _gtid=String.Empty; 
        private string _tqid=Newid(); 
        private string _tqcode=String.Empty; 
        private string _tqname=String.Empty; 
        private string _remark=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：gtID
        /// 属性描述：杆塔ID
        /// 字段信息：[gtID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("杆塔ID")]
        public string gtID
        {
            get { return _gtid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[杆塔ID]长度不能大于50!");
                if (_gtid as object == null || !_gtid.Equals(value))
                {
                    _gtid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tqID
        /// 属性描述：台区ID
        /// 字段信息：[tqID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("台区ID")]
        public string tqID
        {
            get { return _tqid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[台区ID]长度不能大于50!");
                if (_tqid as object == null || !_tqid.Equals(value))
                {
                    _tqid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tqCode
        /// 属性描述：台区编号
        /// 字段信息：[tqCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("台区编号")]
        public string tqCode
        {
            get { return _tqcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[台区编号]长度不能大于50!");
                if (_tqcode as object == null || !_tqcode.Equals(value))
                {
                    _tqcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tqName
        /// 属性描述：台区名称
        /// 字段信息：[tqName],nvarchar
        /// </summary>
        [DisplayNameAttribute("台区名称")]
        public string tqName
        {
            get { return _tqname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[台区名称]长度不能大于50!");
                if (_tqname as object == null || !_tqname.Equals(value))
                {
                    _tqname = value;
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
                if( value.ToString().Length > 250)
                throw new Exception("[备注]长度不能大于250!");
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
