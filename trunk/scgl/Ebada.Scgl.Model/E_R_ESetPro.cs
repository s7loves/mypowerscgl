/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:农电信息管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-8-24 10:15:24
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[E_R_ESetPro]业务实体类
    ///对应表名:E_R_ESetPro
    /// </summary>
    [Serializable]
    public class E_R_ESetPro
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _esetid=String.Empty; 
        private string _proid=String.Empty; 
        private string _byscol1=String.Empty; 
        private string _byscol2=String.Empty; 
        private string _byscol3=String.Empty; 
        private string _byscol4=String.Empty; 
        private string _byscol5=String.Empty; 
        private string _remark=String.Empty; 
        private byte[] _rowversion=new byte[]{}; 
        private int _selectnum=0; 
        private int _muselectnum=0; 
        private int _judgenum=0;   
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
        /// 属性名称：ESETID
        /// 属性描述：设置
        /// 字段信息：[ESETID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("设置")]
        public string ESETID
        {
            get { return _esetid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设置]长度不能大于50!");
                if (_esetid as object == null || !_esetid.Equals(value))
                {
                    _esetid = value;
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
        [Browsable(false)]
        [DisplayNameAttribute("备用1")]
        public string BySCol1
        {
            get { return _byscol1; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 200)
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
        [Browsable(false)]
        [DisplayNameAttribute("备用2")]
        public string BySCol2
        {
            get { return _byscol2; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 200)
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
        [Browsable(false)]
        [DisplayNameAttribute("备用3")]
        public string BySCol3
        {
            get { return _byscol3; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 200)
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
        [Browsable(false)]
        [DisplayNameAttribute("备用4")]
        public string BySCol4
        {
            get { return _byscol4; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 200)
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
        [Browsable(false)]
        [DisplayNameAttribute("备用5")]
        public string BySCol5
        {
            get { return _byscol5; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 200)
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
        [Browsable(false)]
        [DisplayNameAttribute("备注")]
        public string Remark
        {
            get { return _remark; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 200)
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
        /// <summary>
        /// 属性名称：JudgeNUM
        /// 属性描述：判断题数
        /// 字段信息：[JudgeNUM],int
        /// </summary>
        [DisplayNameAttribute("判断题数")]
        public int JudgeNUM
        {
            get { return _judgenum; }
            set
            {
                if (_judgenum as object == null || !_judgenum.Equals(value))
                {
                    _judgenum = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：SelectNUM
        /// 属性描述：单选题数量
        /// 字段信息：[SelectNUM],int
        /// </summary>
        [DisplayNameAttribute("单选题数量")]
        public int SelectNUM
        {
            get { return _selectnum; }
            set
            {			
                if (_selectnum as object == null || !_selectnum.Equals(value))
                {
                    _selectnum = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：MuSelectNUM
        /// 属性描述：多选题数量
        /// 字段信息：[MuSelectNUM],int
        /// </summary>
        [DisplayNameAttribute("多选题数量")]
        public int MuSelectNUM
        {
            get { return _muselectnum; }
            set
            {			
                if (_muselectnum as object == null || !_muselectnum.Equals(value))
                {
                    _muselectnum = value;
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
