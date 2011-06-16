/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-2 19:29:04
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[WFModul]业务实体类
    ///对应表名:WFModul
    /// </summary>
    [Serializable]
    public class WFModul
    {
        
        #region Private 成员
        private string _selfcode=Newid(); 
        private string _fathercode=String.Empty; 
        private string _caption=String.Empty; 
        private string _memo=String.Empty; 
        private string _nodetype=String.Empty; 
        private int _leverl=0; 
        private string _fullposition=String.Empty; 
        private bool _isvisable=false; 
        private string _dllfilename=String.Empty; 
        private string _dllclassname=String.Empty; 
        private string _dllmethodname=String.Empty; 
        private string _formname=String.Empty; 
        private bool _blankwindows=false; 
        private bool _mouseisclick=false; 
        private int _imageindex=0; 
        private bool _sdiwindows=false;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：SelfCode
        /// 属性描述：
        /// 字段信息：[SelfCode],varchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string SelfCode
        {
            get { return _selfcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_selfcode as object == null || !_selfcode.Equals(value))
                {
                    _selfcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FatherCode
        /// 属性描述：
        /// 字段信息：[FatherCode],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string FatherCode
        {
            get { return _fathercode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_fathercode as object == null || !_fathercode.Equals(value))
                {
                    _fathercode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Caption
        /// 属性描述：
        /// 字段信息：[Caption],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Caption
        {
            get { return _caption; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_caption as object == null || !_caption.Equals(value))
                {
                    _caption = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Memo
        /// 属性描述：
        /// 字段信息：[Memo],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Memo
        {
            get { return _memo; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[]长度不能大于200!");
                if (_memo as object == null || !_memo.Equals(value))
                {
                    _memo = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：NodeType
        /// 属性描述：
        /// 字段信息：[NodeType],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string NodeType
        {
            get { return _nodetype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_nodetype as object == null || !_nodetype.Equals(value))
                {
                    _nodetype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Leverl
        /// 属性描述：
        /// 字段信息：[Leverl],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int Leverl
        {
            get { return _leverl; }
            set
            {			
                if (_leverl as object == null || !_leverl.Equals(value))
                {
                    _leverl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FullPosition
        /// 属性描述：
        /// 字段信息：[FullPosition],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string FullPosition
        {
            get { return _fullposition; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 256)
                throw new Exception("[]长度不能大于256!");
                if (_fullposition as object == null || !_fullposition.Equals(value))
                {
                    _fullposition = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：IsVisable
        /// 属性描述：
        /// 字段信息：[IsVisable],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool IsVisable
        {
            get { return _isvisable; }
            set
            {			
                if (_isvisable as object == null || !_isvisable.Equals(value))
                {
                    _isvisable = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：DllFileName
        /// 属性描述：
        /// 字段信息：[DllFileName],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string DllFileName
        {
            get { return _dllfilename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 128)
                throw new Exception("[]长度不能大于128!");
                if (_dllfilename as object == null || !_dllfilename.Equals(value))
                {
                    _dllfilename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：DllClassName
        /// 属性描述：
        /// 字段信息：[DllClassName],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string DllClassName
        {
            get { return _dllclassname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 128)
                throw new Exception("[]长度不能大于128!");
                if (_dllclassname as object == null || !_dllclassname.Equals(value))
                {
                    _dllclassname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：DllMethodName
        /// 属性描述：
        /// 字段信息：[DllMethodName],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string DllMethodName
        {
            get { return _dllmethodname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_dllmethodname as object == null || !_dllmethodname.Equals(value))
                {
                    _dllmethodname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：FormName
        /// 属性描述：
        /// 字段信息：[FormName],varchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string FormName
        {
            get { return _formname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_formname as object == null || !_formname.Equals(value))
                {
                    _formname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BlankWindows
        /// 属性描述：
        /// 字段信息：[BlankWindows],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool BlankWindows
        {
            get { return _blankwindows; }
            set
            {			
                if (_blankwindows as object == null || !_blankwindows.Equals(value))
                {
                    _blankwindows = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：MouseIsClick
        /// 属性描述：
        /// 字段信息：[MouseIsClick],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool MouseIsClick
        {
            get { return _mouseisclick; }
            set
            {			
                if (_mouseisclick as object == null || !_mouseisclick.Equals(value))
                {
                    _mouseisclick = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ImageIndex
        /// 属性描述：
        /// 字段信息：[ImageIndex],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int ImageIndex
        {
            get { return _imageindex; }
            set
            {			
                if (_imageindex as object == null || !_imageindex.Equals(value))
                {
                    _imageindex = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SDIWindows
        /// 属性描述：
        /// 字段信息：[SDIWindows],bit
        /// </summary>
        [DisplayNameAttribute("")]
        public bool SDIWindows
        {
            get { return _sdiwindows; }
            set
            {			
                if (_sdiwindows as object == null || !_sdiwindows.Equals(value))
                {
                    _sdiwindows = value;
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
