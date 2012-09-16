/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-9-16 10:28:39
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[JH_weekks]业务实体类
    ///对应表名:JH_weekks
    /// </summary>
    [Serializable]
    public class JH_weekks
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _单位代码=String.Empty; 
        private string _单位名称=String.Empty; 
        private string _计划项目=String.Empty; 
        private string _实施内容=String.Empty; 
        private string _主要负责人=String.Empty; 
        private string _参加人员=String.Empty; 
        private DateTime _预计时间=new DateTime(1900,1,1); 
        private DateTime _预计时间2=new DateTime(1900,1,1); 
        private string _计划种类=String.Empty; 
        private string _计划分类=String.Empty; 
        private string _完成标记=String.Empty; 
        private DateTime _完成时间=new DateTime(1900,1,1); 
        private string _总结提升=String.Empty; 
        private string _未完成原因=String.Empty; 
        private string _可选标记=String.Empty; 
        private string _单位分类=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty; 
        private string _c4=String.Empty; 
        private string _c5=String.Empty;   
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
        /// 属性名称：计划项目
        /// 属性描述：
        /// 字段信息：[计划项目],nvarchar
        /// </summary>
        [DisplayNameAttribute("计划项目")]
        public string 计划项目
        {
            get { return _计划项目; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[计划项目]长度不能大于50!");
                if (_计划项目 as object == null || !_计划项目.Equals(value))
                {
                    _计划项目 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：实施内容
        /// 属性描述：
        /// 字段信息：[实施内容],nvarchar
        /// </summary>
        [DisplayNameAttribute("实施内容")]
        public string 实施内容
        {
            get { return _实施内容; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[实施内容]长度不能大于500!");
                if (_实施内容 as object == null || !_实施内容.Equals(value))
                {
                    _实施内容 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：主要负责人
        /// 属性描述：
        /// 字段信息：[主要负责人],nvarchar
        /// </summary>
        [DisplayNameAttribute("主要负责人")]
        public string 主要负责人
        {
            get { return _主要负责人; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[主要负责人]长度不能大于50!");
                if (_主要负责人 as object == null || !_主要负责人.Equals(value))
                {
                    _主要负责人 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：参加人员
        /// 属性描述：
        /// 字段信息：[参加人员],nvarchar
        /// </summary>
        [DisplayNameAttribute("参加人员")]
        public string 参加人员
        {
            get { return _参加人员; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 150)
                throw new Exception("[参加人员]长度不能大于150!");
                if (_参加人员 as object == null || !_参加人员.Equals(value))
                {
                    _参加人员 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：预计时间
        /// 属性描述：
        /// 字段信息：[预计时间],datetime
        /// </summary>
        [DisplayNameAttribute("预计时间")]
        public DateTime 预计时间
        {
            get { return _预计时间; }
            set
            {			
                if (_预计时间 as object == null || !_预计时间.Equals(value))
                {
                    _预计时间 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：预计时间2
        /// 属性描述：
        /// 字段信息：[预计时间2],datetime
        /// </summary>
        [DisplayNameAttribute("预计时间2")]
        public DateTime 预计时间2
        {
            get { return _预计时间2; }
            set
            {			
                if (_预计时间2 as object == null || !_预计时间2.Equals(value))
                {
                    _预计时间2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：计划种类
        /// 属性描述：
        /// 字段信息：[计划种类],nvarchar
        /// </summary>
        [DisplayNameAttribute("计划种类")]
        public string 计划种类
        {
            get { return _计划种类; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[计划种类]长度不能大于50!");
                if (_计划种类 as object == null || !_计划种类.Equals(value))
                {
                    _计划种类 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：计划分类
        /// 属性描述：
        /// 字段信息：[计划分类],nvarchar
        /// </summary>
        [DisplayNameAttribute("计划分类")]
        public string 计划分类
        {
            get { return _计划分类; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[计划分类]长度不能大于50!");
                if (_计划分类 as object == null || !_计划分类.Equals(value))
                {
                    _计划分类 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：完成标记
        /// 属性描述：
        /// 字段信息：[完成标记],nvarchar
        /// </summary>
        [DisplayNameAttribute("完成标记")]
        public string 完成标记
        {
            get { return _完成标记; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[完成标记]长度不能大于50!");
                if (_完成标记 as object == null || !_完成标记.Equals(value))
                {
                    _完成标记 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：完成时间
        /// 属性描述：
        /// 字段信息：[完成时间],datetime
        /// </summary>
        [DisplayNameAttribute("完成时间")]
        public DateTime 完成时间
        {
            get { return _完成时间; }
            set
            {			
                if (_完成时间 as object == null || !_完成时间.Equals(value))
                {
                    _完成时间 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：总结提升
        /// 属性描述：
        /// 字段信息：[总结提升],nvarchar
        /// </summary>
        [DisplayNameAttribute("总结提升")]
        public string 总结提升
        {
            get { return _总结提升; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[总结提升]长度不能大于500!");
                if (_总结提升 as object == null || !_总结提升.Equals(value))
                {
                    _总结提升 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：未完成原因
        /// 属性描述：
        /// 字段信息：[未完成原因],nvarchar
        /// </summary>
        [DisplayNameAttribute("未完成原因")]
        public string 未完成原因
        {
            get { return _未完成原因; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[未完成原因]长度不能大于500!");
                if (_未完成原因 as object == null || !_未完成原因.Equals(value))
                {
                    _未完成原因 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：可选标记
        /// 属性描述：
        /// 字段信息：[可选标记],nvarchar
        /// </summary>
        [DisplayNameAttribute("可选标记")]
        public string 可选标记
        {
            get { return _可选标记; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[可选标记]长度不能大于10!");
                if (_可选标记 as object == null || !_可选标记.Equals(value))
                {
                    _可选标记 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：单位分类
        /// 属性描述：
        /// 字段信息：[单位分类],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位分类")]
        public string 单位分类
        {
            get { return _单位分类; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[单位分类]长度不能大于10!");
                if (_单位分类 as object == null || !_单位分类.Equals(value))
                {
                    _单位分类 = value;
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
  
        /// <summary>
        /// 属性名称：c4
        /// 属性描述：
        /// 字段信息：[c4],nvarchar
        /// </summary>
        [DisplayNameAttribute("c4")]
        public string c4
        {
            get { return _c4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[c4]长度不能大于50!");
                if (_c4 as object == null || !_c4.Equals(value))
                {
                    _c4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c5
        /// 属性描述：
        /// 字段信息：[c5],nvarchar
        /// </summary>
        [DisplayNameAttribute("c5")]
        public string c5
        {
            get { return _c5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[c5]长度不能大于50!");
                if (_c5 as object == null || !_c5.Equals(value))
                {
                    _c5 = value;
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
