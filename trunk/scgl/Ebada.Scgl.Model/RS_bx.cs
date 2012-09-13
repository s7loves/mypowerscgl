/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-9-12 22:15:15
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[RS_bx]业务实体类
    ///对应表名:RS_bx
    /// </summary>
    [Serializable]
    public class RS_bx
    {
        
        #region Private 成员
        private long _id=0; 
        private string _year=String.Empty; 
        private string _month=String.Empty; 
        private string _type=String.Empty; 
        private string _保险编号=String.Empty; 
        private string _身份证号=String.Empty; 
        private decimal _缴费工资=0; 
        private decimal _职工合计=0; 
        private decimal _职工单位缴费=0; 
        private decimal _职工个人应缴=0; 
        private string _姓名=String.Empty; 
        private string _参保类别=String.Empty; 
        private decimal _单位缴纳大额=0; 
        private decimal _个人缴纳大额=0; 
        private decimal _单位入个人=0; 
        private decimal _生育保险=0; 
        private decimal _补充保险=0; 
        private decimal _合计金额=0; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty; 
        private string _c4=String.Empty; 
        private byte[] _rowversion=new byte[]{};   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],bigint
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("ID")]
        public long ID
        {
            get { return _id; }
            set
            {			
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：year
        /// 属性描述：
        /// 字段信息：[year],varchar
        /// </summary>
        [DisplayNameAttribute("年")]
        public string year
        {
            get { return _year; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[year]长度不能大于10!");
                if (_year as object == null || !_year.Equals(value))
                {
                    _year = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：month
        /// 属性描述：
        /// 字段信息：[month],varchar
        /// </summary>
        [DisplayNameAttribute("月")]
        public string month
        {
            get { return _month; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[month]长度不能大于10!");
                if (_month as object == null || !_month.Equals(value))
                {
                    _month = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：type
        /// 属性描述：
        /// 字段信息：[type],varchar
        /// </summary>
        [DisplayNameAttribute("分类")]
        public string type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[type]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：保险编号
        /// 属性描述：
        /// 字段信息：[保险编号],nvarchar
        /// </summary>
        [DisplayNameAttribute("保险编号")]
        public string 保险编号
        {
            get { return _保险编号; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 20)
                throw new Exception("[保险编号]长度不能大于20!");
                if (_保险编号 as object == null || !_保险编号.Equals(value))
                {
                    _保险编号 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：身份证号
        /// 属性描述：
        /// 字段信息：[身份证号],nvarchar
        /// </summary>
        [DisplayNameAttribute("身份证号")]
        public string 身份证号
        {
            get { return _身份证号; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 20)
                throw new Exception("[身份证号]长度不能大于20!");
                if (_身份证号 as object == null || !_身份证号.Equals(value))
                {
                    _身份证号 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：缴费工资
        /// 属性描述：
        /// 字段信息：[缴费工资],money
        /// </summary>
        [DisplayNameAttribute("缴费工资")]
        public decimal 缴费工资
        {
            get { return _缴费工资; }
            set
            {			
                if (_缴费工资 as object == null || !_缴费工资.Equals(value))
                {
                    _缴费工资 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：职工合计
        /// 属性描述：
        /// 字段信息：[职工合计],money
        /// </summary>
        [DisplayNameAttribute("职工合计")]
        public decimal 职工合计
        {
            get { return _职工合计; }
            set
            {			
                if (_职工合计 as object == null || !_职工合计.Equals(value))
                {
                    _职工合计 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：职工单位缴费
        /// 属性描述：
        /// 字段信息：[职工单位缴费],money
        /// </summary>
        [DisplayNameAttribute("职工单位缴费")]
        public decimal 职工单位缴费
        {
            get { return _职工单位缴费; }
            set
            {			
                if (_职工单位缴费 as object == null || !_职工单位缴费.Equals(value))
                {
                    _职工单位缴费 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：职工个人应缴
        /// 属性描述：
        /// 字段信息：[职工个人应缴],money
        /// </summary>
        [DisplayNameAttribute("职工个人应缴")]
        public decimal 职工个人应缴
        {
            get { return _职工个人应缴; }
            set
            {			
                if (_职工个人应缴 as object == null || !_职工个人应缴.Equals(value))
                {
                    _职工个人应缴 = value;
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
                if( value.ToString().Length > 10)
                throw new Exception("[姓名]长度不能大于10!");
                if (_姓名 as object == null || !_姓名.Equals(value))
                {
                    _姓名 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：参保类别
        /// 属性描述：
        /// 字段信息：[参保类别],nvarchar
        /// </summary>
        [DisplayNameAttribute("参保类别")]
        public string 参保类别
        {
            get { return _参保类别; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[参保类别]长度不能大于10!");
                if (_参保类别 as object == null || !_参保类别.Equals(value))
                {
                    _参保类别 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：单位缴纳大额
        /// 属性描述：
        /// 字段信息：[单位缴纳大额],money
        /// </summary>
        [DisplayNameAttribute("单位缴纳大额")]
        public decimal 单位缴纳大额
        {
            get { return _单位缴纳大额; }
            set
            {			
                if (_单位缴纳大额 as object == null || !_单位缴纳大额.Equals(value))
                {
                    _单位缴纳大额 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：个人缴纳大额
        /// 属性描述：
        /// 字段信息：[个人缴纳大额],money
        /// </summary>
        [DisplayNameAttribute("个人缴纳大额")]
        public decimal 个人缴纳大额
        {
            get { return _个人缴纳大额; }
            set
            {			
                if (_个人缴纳大额 as object == null || !_个人缴纳大额.Equals(value))
                {
                    _个人缴纳大额 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：单位入个人
        /// 属性描述：
        /// 字段信息：[单位入个人],money
        /// </summary>
        [DisplayNameAttribute("单位入个人")]
        public decimal 单位入个人
        {
            get { return _单位入个人; }
            set
            {			
                if (_单位入个人 as object == null || !_单位入个人.Equals(value))
                {
                    _单位入个人 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：生育保险
        /// 属性描述：
        /// 字段信息：[生育保险],money
        /// </summary>
        [DisplayNameAttribute("生育保险")]
        public decimal 生育保险
        {
            get { return _生育保险; }
            set
            {			
                if (_生育保险 as object == null || !_生育保险.Equals(value))
                {
                    _生育保险 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：补充保险
        /// 属性描述：
        /// 字段信息：[补充保险],money
        /// </summary>
        [DisplayNameAttribute("补充保险")]
        public decimal 补充保险
        {
            get { return _补充保险; }
            set
            {			
                if (_补充保险 as object == null || !_补充保险.Equals(value))
                {
                    _补充保险 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：合计金额
        /// 属性描述：
        /// 字段信息：[合计金额],money
        /// </summary>
        [DisplayNameAttribute("合计金额")]
        public decimal 合计金额
        {
            get { return _合计金额; }
            set
            {			
                if (_合计金额 as object == null || !_合计金额.Equals(value))
                {
                    _合计金额 = value;
                }
            }			 
        }
        [DisplayNameAttribute("显示总金额")]
        public decimal 显示总金额 {
            get { return 职工个人应缴 + 单位入个人; }
            set { }
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
        /// 属性名称：rowversion
        /// 属性描述：
        /// 字段信息：[rowversion],timestamp
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("rowversion")]
        public byte[] rowversion
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
