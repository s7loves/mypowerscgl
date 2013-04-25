/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-2-8 15:35:11
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[JH_weekmant]业务实体类
    ///对应表名:JH_weekmant
    /// </summary>
    [Serializable]
    public class JH_weekmant
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _单位代码=String.Empty; 
        private string _单位名称=String.Empty; 
        private DateTime _开始日期=new DateTime(1900,1,1); 
        private DateTime _结束日期=new DateTime(1900,1,1); 
        private string _标题=String.Empty; 
        private string _年月周=String.Empty; 
        private string _姓名=String.Empty; 
        private string _职务=String.Empty; 
        private string _考核人=String.Empty; 
        private string _考核结果=String.Empty; 
        private string _考核时间=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty;
        private string _月合计;


        private string _年合计;

        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ParentID
        /// 属性描述：
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("ParentID")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[ParentID]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：单位代码
        /// 属性描述：
        /// 字段信息：[单位代码],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位代码")]
        public string 单位代码
        {
            get { return _单位代码; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位代码]长度不能大于50!");
                if (_单位代码 as object == null || !_单位代码.Equals(value))
                {
                    _单位代码 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：单位名称
        /// 属性描述：
        /// 字段信息：[单位名称],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位名称")]
        public string 单位名称
        {
            get { return _单位名称; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位名称]长度不能大于50!");
                if (_单位名称 as object == null || !_单位名称.Equals(value))
                {
                    _单位名称 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：开始日期
        /// 属性描述：
        /// 字段信息：[开始日期],datetime
        /// </summary>
        [DisplayNameAttribute("开始日期")]
        public DateTime 开始日期
        {
            get { return _开始日期; }
            set
            {			
                if (_开始日期 as object == null || !_开始日期.Equals(value))
                {
                    _开始日期 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：结束日期
        /// 属性描述：
        /// 字段信息：[结束日期],datetime
        /// </summary>
        [DisplayNameAttribute("结束日期")]
        public DateTime 结束日期
        {
            get { return _结束日期; }
            set
            {			
                if (_结束日期 as object == null || !_结束日期.Equals(value))
                {
                    _结束日期 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：标题
        /// 属性描述：
        /// 字段信息：[标题],nvarchar
        /// </summary>
        [DisplayNameAttribute("标题")]
        public string 标题
        {
            get { return _标题; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[标题]长度不能大于50!");
                if (_标题 as object == null || !_标题.Equals(value))
                {
                    _标题 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：年月周
        /// 属性描述：
        /// 字段信息：[年月周],nvarchar
        /// </summary>
        [DisplayNameAttribute("年月周")]
        public string 年月周
        {
            get { return _年月周; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[年月周]长度不能大于50!");
                if (_年月周 as object == null || !_年月周.Equals(value))
                {
                    _年月周 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：姓名
        /// 属性描述：
        /// 字段信息：[姓名],nvarchar
        /// </summary>
        [DisplayNameAttribute("姓名")]
        public string 姓名
        {
            get { return _姓名; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[姓名]长度不能大于50!");
                if (_姓名 as object == null || !_姓名.Equals(value))
                {
                    _姓名 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：职务
        /// 属性描述：
        /// 字段信息：[职务],nvarchar
        /// </summary>
        [DisplayNameAttribute("职务")]
        public string 职务
        {
            get { return _职务; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[职务]长度不能大于50!");
                if (_职务 as object == null || !_职务.Equals(value))
                {
                    _职务 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：考核人
        /// 属性描述：
        /// 字段信息：[考核人],nvarchar
        /// </summary>
        [DisplayNameAttribute("考核人")]
        public string 考核人
        {
            get { return _考核人; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[考核人]长度不能大于50!");
                if (_考核人 as object == null || !_考核人.Equals(value))
                {
                    _考核人 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：考核结果
        /// 属性描述：
        /// 字段信息：[考核结果],nvarchar
        /// </summary>
        [DisplayNameAttribute("考核结果")]
        public string 考核结果
        {
            get { return _考核结果; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[考核结果]长度不能大于50!");
                if (_考核结果 as object == null || !_考核结果.Equals(value))
                {
                    _考核结果 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：考核时间
        /// 属性描述：
        /// 字段信息：[考核时间],nvarchar
        /// </summary>
        [DisplayNameAttribute("考核时间")]
        public string 考核时间
        {
            get { return _考核时间; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[考核时间]长度不能大于50!");
                if (_考核时间 as object == null || !_考核时间.Equals(value))
                {
                    _考核时间 = value;
                }
            }			 
        }
        public string 月总分 {
            get { return _月合计; }
            set { _月合计 = value; }
        }
        public string 年总分 {
            get { return _年合计; }
            set { _年合计 = value; }
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
            return DateTime.Now.ToString("yyyyMMddHHmmssffffff");
        }
        public string CreateID(){
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            return DateTime.Now.ToString("yyyyMMddHHmmssffffff");
        }
        #endregion		
    }	
}
