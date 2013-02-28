/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-2-27 16:51:06
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[BD_SBTZ]业务实体类
    ///对应表名:BD_SBTZ
    /// </summary>
    [Serializable]
    public class BD_SBTZ
    {
        
        #region Private 成员
        private string _sb_id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _sbvol=String.Empty; 
        private string _a1=String.Empty; 
        private string _a2=String.Empty; 
        private string _a3=String.Empty; 
        private string _a4=String.Empty; 
        private string _a5=String.Empty; 
        private string _a6=String.Empty; 
        private string _a7=String.Empty; 
        private string _a8=String.Empty; 
        private string _a9=String.Empty; 
        private string _a10=String.Empty; 
        private string _a11=String.Empty; 
        private string _a13=String.Empty; 
        private string _a12=String.Empty; 
        private string _a14=String.Empty; 
        private string _a15=String.Empty; 
        private string _a16=String.Empty; 
        private string _a17=String.Empty; 
        private string _a18=String.Empty; 
        private string _a19=String.Empty; 
        private string _a20=String.Empty; 
        private string _a21=String.Empty; 
        private string _a22=String.Empty; 
        private string _a23=String.Empty; 
        private string _a24=String.Empty; 
        private string _a25=String.Empty; 
        private string _a26=String.Empty; 
        private string _a27=String.Empty; 
        private string _a28=String.Empty; 
        private string _a29=String.Empty; 
        private string _a30=String.Empty; 
        private string _a31=String.Empty; 
        private string _a32=String.Empty; 
        private string _a33=String.Empty; 
        private string _a34=String.Empty; 
        private string _a35=String.Empty; 
        private string _a36=String.Empty; 
        private string _a37=String.Empty; 
        private string _a38=String.Empty; 
        private string _a39=String.Empty; 
        private string _a40=String.Empty; 
        private string _a41=String.Empty; 
        private string _a42=String.Empty; 
        private string _a43=String.Empty; 
        private string _a44=String.Empty; 
        private string _a45=String.Empty; 
        private string _a46=String.Empty; 
        private string _a47=String.Empty; 
        private string _a48=String.Empty; 
        private string _a49=String.Empty; 
        private string _a50=String.Empty; 
        private string _a51=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：sb_id
        /// 属性描述：
        /// 字段信息：[sb_id],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("sb_id")]
        public string sb_id
        {
            get { return _sb_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[sb_id]长度不能大于50!");
                if (_sb_id as object == null || !_sb_id.Equals(value))
                {
                    _sb_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：变电站代码
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("变电站代码")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[变电站代码]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbvol
        /// 属性描述：电压等级
        /// 字段信息：[sbvol],nvarchar
        /// </summary>
        [DisplayNameAttribute("电压等级")]
        public string sbvol
        {
            get { return _sbvol; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电压等级]长度不能大于50!");
                if (_sbvol as object == null || !_sbvol.Equals(value))
                {
                    _sbvol = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a1
        /// 属性描述：设备种类
        /// 字段信息：[a1],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备种类")]
        public string a1
        {
            get { return _a1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备种类]长度不能大于50!");
                if (_a1 as object == null || !_a1.Equals(value))
                {
                    _a1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a2
        /// 属性描述：设备名称
        /// 字段信息：[a2],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备名称")]
        public string a2
        {
            get { return _a2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备名称]长度不能大于50!");
                if (_a2 as object == null || !_a2.Equals(value))
                {
                    _a2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a3
        /// 属性描述：设备型号
        /// 字段信息：[a3],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备型号")]
        public string a3
        {
            get { return _a3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备型号]长度不能大于50!");
                if (_a3 as object == null || !_a3.Equals(value))
                {
                    _a3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a4
        /// 属性描述：序列号
        /// 字段信息：[a4],nvarchar
        /// </summary>
        [DisplayNameAttribute("序列号")]
        public string a4
        {
            get { return _a4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[序列号]长度不能大于50!");
                if (_a4 as object == null || !_a4.Equals(value))
                {
                    _a4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a5
        /// 属性描述：出产日期
        /// 字段信息：[a5],nvarchar
        /// </summary>
        [DisplayNameAttribute("出产日期")]
        public string a5
        {
            get { return _a5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[出产日期]长度不能大于50!");
                if (_a5 as object == null || !_a5.Equals(value))
                {
                    _a5 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a6
        /// 属性描述：投产日期
        /// 字段信息：[a6],nvarchar
        /// </summary>
        [DisplayNameAttribute("投产日期")]
        public string a6
        {
            get { return _a6; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[投产日期]长度不能大于50!");
                if (_a6 as object == null || !_a6.Equals(value))
                {
                    _a6 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a7
        /// 属性描述：生产厂家
        /// 字段信息：[a7],nvarchar
        /// </summary>
        [DisplayNameAttribute("生产厂家")]
        public string a7
        {
            get { return _a7; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[生产厂家]长度不能大于50!");
                if (_a7 as object == null || !_a7.Equals(value))
                {
                    _a7 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a8
        /// 属性描述：大修日期
        /// 字段信息：[a8],nvarchar
        /// </summary>
        [DisplayNameAttribute("大修日期")]
        public string a8
        {
            get { return _a8; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[大修日期]长度不能大于50!");
                if (_a8 as object == null || !_a8.Equals(value))
                {
                    _a8 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a9
        /// 属性描述：
        /// 字段信息：[a9],nvarchar
        /// </summary>
        [DisplayNameAttribute("a9")]
        public string a9
        {
            get { return _a9; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a9]长度不能大于50!");
                if (_a9 as object == null || !_a9.Equals(value))
                {
                    _a9 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a10
        /// 属性描述：
        /// 字段信息：[a10],nvarchar
        /// </summary>
        [DisplayNameAttribute("a10")]
        public string a10
        {
            get { return _a10; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a10]长度不能大于50!");
                if (_a10 as object == null || !_a10.Equals(value))
                {
                    _a10 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a11
        /// 属性描述：
        /// 字段信息：[a11],nvarchar
        /// </summary>
        [DisplayNameAttribute("a11")]
        public string a11
        {
            get { return _a11; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a11]长度不能大于50!");
                if (_a11 as object == null || !_a11.Equals(value))
                {
                    _a11 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a13
        /// 属性描述：
        /// 字段信息：[a13],nvarchar
        /// </summary>
        [DisplayNameAttribute("a13")]
        public string a13
        {
            get { return _a13; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a13]长度不能大于50!");
                if (_a13 as object == null || !_a13.Equals(value))
                {
                    _a13 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a12
        /// 属性描述：
        /// 字段信息：[a12],nvarchar
        /// </summary>
        [DisplayNameAttribute("a12")]
        public string a12
        {
            get { return _a12; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a12]长度不能大于50!");
                if (_a12 as object == null || !_a12.Equals(value))
                {
                    _a12 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a14
        /// 属性描述：
        /// 字段信息：[a14],nvarchar
        /// </summary>
        [DisplayNameAttribute("a14")]
        public string a14
        {
            get { return _a14; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a14]长度不能大于50!");
                if (_a14 as object == null || !_a14.Equals(value))
                {
                    _a14 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a15
        /// 属性描述：
        /// 字段信息：[a15],nvarchar
        /// </summary>
        [DisplayNameAttribute("a15")]
        public string a15
        {
            get { return _a15; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a15]长度不能大于50!");
                if (_a15 as object == null || !_a15.Equals(value))
                {
                    _a15 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a16
        /// 属性描述：
        /// 字段信息：[a16],nvarchar
        /// </summary>
        [DisplayNameAttribute("a16")]
        public string a16
        {
            get { return _a16; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a16]长度不能大于50!");
                if (_a16 as object == null || !_a16.Equals(value))
                {
                    _a16 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a17
        /// 属性描述：
        /// 字段信息：[a17],nvarchar
        /// </summary>
        [DisplayNameAttribute("a17")]
        public string a17
        {
            get { return _a17; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a17]长度不能大于50!");
                if (_a17 as object == null || !_a17.Equals(value))
                {
                    _a17 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a18
        /// 属性描述：
        /// 字段信息：[a18],nvarchar
        /// </summary>
        [DisplayNameAttribute("a18")]
        public string a18
        {
            get { return _a18; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a18]长度不能大于50!");
                if (_a18 as object == null || !_a18.Equals(value))
                {
                    _a18 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a19
        /// 属性描述：
        /// 字段信息：[a19],nvarchar
        /// </summary>
        [DisplayNameAttribute("a19")]
        public string a19
        {
            get { return _a19; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a19]长度不能大于50!");
                if (_a19 as object == null || !_a19.Equals(value))
                {
                    _a19 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a20
        /// 属性描述：
        /// 字段信息：[a20],nvarchar
        /// </summary>
        [DisplayNameAttribute("a20")]
        public string a20
        {
            get { return _a20; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a20]长度不能大于50!");
                if (_a20 as object == null || !_a20.Equals(value))
                {
                    _a20 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a21
        /// 属性描述：
        /// 字段信息：[a21],nvarchar
        /// </summary>
        [DisplayNameAttribute("a21")]
        public string a21
        {
            get { return _a21; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a21]长度不能大于50!");
                if (_a21 as object == null || !_a21.Equals(value))
                {
                    _a21 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a22
        /// 属性描述：
        /// 字段信息：[a22],nvarchar
        /// </summary>
        [DisplayNameAttribute("a22")]
        public string a22
        {
            get { return _a22; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a22]长度不能大于50!");
                if (_a22 as object == null || !_a22.Equals(value))
                {
                    _a22 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a23
        /// 属性描述：
        /// 字段信息：[a23],nvarchar
        /// </summary>
        [DisplayNameAttribute("a23")]
        public string a23
        {
            get { return _a23; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a23]长度不能大于50!");
                if (_a23 as object == null || !_a23.Equals(value))
                {
                    _a23 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a24
        /// 属性描述：
        /// 字段信息：[a24],nvarchar
        /// </summary>
        [DisplayNameAttribute("a24")]
        public string a24
        {
            get { return _a24; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a24]长度不能大于50!");
                if (_a24 as object == null || !_a24.Equals(value))
                {
                    _a24 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a25
        /// 属性描述：
        /// 字段信息：[a25],nvarchar
        /// </summary>
        [DisplayNameAttribute("a25")]
        public string a25
        {
            get { return _a25; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a25]长度不能大于50!");
                if (_a25 as object == null || !_a25.Equals(value))
                {
                    _a25 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a26
        /// 属性描述：
        /// 字段信息：[a26],nvarchar
        /// </summary>
        [DisplayNameAttribute("a26")]
        public string a26
        {
            get { return _a26; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a26]长度不能大于50!");
                if (_a26 as object == null || !_a26.Equals(value))
                {
                    _a26 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a27
        /// 属性描述：
        /// 字段信息：[a27],nvarchar
        /// </summary>
        [DisplayNameAttribute("a27")]
        public string a27
        {
            get { return _a27; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a27]长度不能大于50!");
                if (_a27 as object == null || !_a27.Equals(value))
                {
                    _a27 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a28
        /// 属性描述：
        /// 字段信息：[a28],nvarchar
        /// </summary>
        [DisplayNameAttribute("a28")]
        public string a28
        {
            get { return _a28; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a28]长度不能大于50!");
                if (_a28 as object == null || !_a28.Equals(value))
                {
                    _a28 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a29
        /// 属性描述：
        /// 字段信息：[a29],nvarchar
        /// </summary>
        [DisplayNameAttribute("a29")]
        public string a29
        {
            get { return _a29; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a29]长度不能大于50!");
                if (_a29 as object == null || !_a29.Equals(value))
                {
                    _a29 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a30
        /// 属性描述：
        /// 字段信息：[a30],nvarchar
        /// </summary>
        [DisplayNameAttribute("a30")]
        public string a30
        {
            get { return _a30; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a30]长度不能大于50!");
                if (_a30 as object == null || !_a30.Equals(value))
                {
                    _a30 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a31
        /// 属性描述：
        /// 字段信息：[a31],nvarchar
        /// </summary>
        [DisplayNameAttribute("a31")]
        public string a31
        {
            get { return _a31; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a31]长度不能大于50!");
                if (_a31 as object == null || !_a31.Equals(value))
                {
                    _a31 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a32
        /// 属性描述：
        /// 字段信息：[a32],nvarchar
        /// </summary>
        [DisplayNameAttribute("a32")]
        public string a32
        {
            get { return _a32; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a32]长度不能大于50!");
                if (_a32 as object == null || !_a32.Equals(value))
                {
                    _a32 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a33
        /// 属性描述：
        /// 字段信息：[a33],nvarchar
        /// </summary>
        [DisplayNameAttribute("a33")]
        public string a33
        {
            get { return _a33; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a33]长度不能大于50!");
                if (_a33 as object == null || !_a33.Equals(value))
                {
                    _a33 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a34
        /// 属性描述：
        /// 字段信息：[a34],nvarchar
        /// </summary>
        [DisplayNameAttribute("a34")]
        public string a34
        {
            get { return _a34; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a34]长度不能大于50!");
                if (_a34 as object == null || !_a34.Equals(value))
                {
                    _a34 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a35
        /// 属性描述：
        /// 字段信息：[a35],nvarchar
        /// </summary>
        [DisplayNameAttribute("a35")]
        public string a35
        {
            get { return _a35; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a35]长度不能大于50!");
                if (_a35 as object == null || !_a35.Equals(value))
                {
                    _a35 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a36
        /// 属性描述：
        /// 字段信息：[a36],nvarchar
        /// </summary>
        [DisplayNameAttribute("a36")]
        public string a36
        {
            get { return _a36; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a36]长度不能大于50!");
                if (_a36 as object == null || !_a36.Equals(value))
                {
                    _a36 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a37
        /// 属性描述：
        /// 字段信息：[a37],nvarchar
        /// </summary>
        [DisplayNameAttribute("a37")]
        public string a37
        {
            get { return _a37; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a37]长度不能大于50!");
                if (_a37 as object == null || !_a37.Equals(value))
                {
                    _a37 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a38
        /// 属性描述：
        /// 字段信息：[a38],nvarchar
        /// </summary>
        [DisplayNameAttribute("a38")]
        public string a38
        {
            get { return _a38; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a38]长度不能大于50!");
                if (_a38 as object == null || !_a38.Equals(value))
                {
                    _a38 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a39
        /// 属性描述：
        /// 字段信息：[a39],nvarchar
        /// </summary>
        [DisplayNameAttribute("a39")]
        public string a39
        {
            get { return _a39; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a39]长度不能大于50!");
                if (_a39 as object == null || !_a39.Equals(value))
                {
                    _a39 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a40
        /// 属性描述：
        /// 字段信息：[a40],nvarchar
        /// </summary>
        [DisplayNameAttribute("a40")]
        public string a40
        {
            get { return _a40; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a40]长度不能大于50!");
                if (_a40 as object == null || !_a40.Equals(value))
                {
                    _a40 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a41
        /// 属性描述：
        /// 字段信息：[a41],nvarchar
        /// </summary>
        [DisplayNameAttribute("a41")]
        public string a41
        {
            get { return _a41; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a41]长度不能大于50!");
                if (_a41 as object == null || !_a41.Equals(value))
                {
                    _a41 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a42
        /// 属性描述：
        /// 字段信息：[a42],nvarchar
        /// </summary>
        [DisplayNameAttribute("a42")]
        public string a42
        {
            get { return _a42; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a42]长度不能大于50!");
                if (_a42 as object == null || !_a42.Equals(value))
                {
                    _a42 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a43
        /// 属性描述：
        /// 字段信息：[a43],nvarchar
        /// </summary>
        [DisplayNameAttribute("a43")]
        public string a43
        {
            get { return _a43; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a43]长度不能大于50!");
                if (_a43 as object == null || !_a43.Equals(value))
                {
                    _a43 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a44
        /// 属性描述：
        /// 字段信息：[a44],nvarchar
        /// </summary>
        [DisplayNameAttribute("a44")]
        public string a44
        {
            get { return _a44; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a44]长度不能大于50!");
                if (_a44 as object == null || !_a44.Equals(value))
                {
                    _a44 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a45
        /// 属性描述：
        /// 字段信息：[a45],nvarchar
        /// </summary>
        [DisplayNameAttribute("a45")]
        public string a45
        {
            get { return _a45; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a45]长度不能大于50!");
                if (_a45 as object == null || !_a45.Equals(value))
                {
                    _a45 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a46
        /// 属性描述：
        /// 字段信息：[a46],nvarchar
        /// </summary>
        [DisplayNameAttribute("a46")]
        public string a46
        {
            get { return _a46; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a46]长度不能大于50!");
                if (_a46 as object == null || !_a46.Equals(value))
                {
                    _a46 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a47
        /// 属性描述：
        /// 字段信息：[a47],nvarchar
        /// </summary>
        [DisplayNameAttribute("a47")]
        public string a47
        {
            get { return _a47; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a47]长度不能大于50!");
                if (_a47 as object == null || !_a47.Equals(value))
                {
                    _a47 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a48
        /// 属性描述：
        /// 字段信息：[a48],nvarchar
        /// </summary>
        [DisplayNameAttribute("a48")]
        public string a48
        {
            get { return _a48; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a48]长度不能大于50!");
                if (_a48 as object == null || !_a48.Equals(value))
                {
                    _a48 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a49
        /// 属性描述：
        /// 字段信息：[a49],nvarchar
        /// </summary>
        [DisplayNameAttribute("a49")]
        public string a49
        {
            get { return _a49; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a49]长度不能大于50!");
                if (_a49 as object == null || !_a49.Equals(value))
                {
                    _a49 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a50
        /// 属性描述：
        /// 字段信息：[a50],nvarchar
        /// </summary>
        [DisplayNameAttribute("a50")]
        public string a50
        {
            get { return _a50; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a50]长度不能大于50!");
                if (_a50 as object == null || !_a50.Equals(value))
                {
                    _a50 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a51
        /// 属性描述：
        /// 字段信息：[a51],nvarchar
        /// </summary>
        [DisplayNameAttribute("a51")]
        public string a51
        {
            get { return _a51; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[a51]长度不能大于50!");
                if (_a51 as object == null || !_a51.Equals(value))
                {
                    _a51 = value;
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
