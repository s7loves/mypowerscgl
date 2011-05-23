/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-17 22:06:06
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[mModule]业务实体类
    ///对应表名:mModule
    /// </summary>
    [Serializable]
    public class mModule
    {
        
        #region Private 成员
        private string _modu_id=Newid(); 
        private string _modutypes=String.Empty; 
        private string _moduname=String.Empty; 
        private string _assemblyfilename=String.Empty; 
        private int _sequence=0; 
        private string _iscores=String.Empty; 
        private string _description=String.Empty; 
        private string _parentid=String.Empty; 
        private string _methodname=String.Empty; 
        private string _iconname=String.Empty; 
        private bool _activityflag=false; 
        private bool _visiableflag=false;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：Modu_ID
        /// 属性描述：模块标识
        /// 字段信息：[Modu_ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("模块标识")]
        public string Modu_ID
        {
            get { return _modu_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[模块标识]长度不能大于50!");
                if (_modu_id as object == null || !_modu_id.Equals(value))
                {
                    _modu_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ModuTypes
        /// 属性描述：模块类型
        /// 字段信息：[ModuTypes],nvarchar
        /// </summary>
        [DisplayNameAttribute("模块类型")]
        public string ModuTypes
        {
            get { return _modutypes; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[模块类型]长度不能大于250!");
                if (_modutypes as object == null || !_modutypes.Equals(value))
                {
                    _modutypes = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ModuName
        /// 属性描述：模块名称
        /// 字段信息：[ModuName],nvarchar
        /// </summary>
        [DisplayNameAttribute("模块名称")]
        public string ModuName
        {
            get { return _moduname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 100)
                throw new Exception("[模块名称]长度不能大于100!");
                if (_moduname as object == null || !_moduname.Equals(value))
                {
                    _moduname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：AssemblyFileName
        /// 属性描述：集合文件名
        /// 字段信息：[AssemblyFileName],nvarchar
        /// </summary>
        [DisplayNameAttribute("集合文件名")]
        public string AssemblyFileName
        {
            get { return _assemblyfilename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[集合文件名]长度不能大于200!");
                if (_assemblyfilename as object == null || !_assemblyfilename.Equals(value))
                {
                    _assemblyfilename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Sequence
        /// 属性描述：排序
        /// 字段信息：[Sequence],int
        /// </summary>
        [DisplayNameAttribute("排序")]
        public int Sequence
        {
            get { return _sequence; }
            set
            {			
                if (_sequence as object == null || !_sequence.Equals(value))
                {
                    _sequence = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：IsCores
        /// 属性描述：是否为核心
        /// 字段信息：[IsCores],nvarchar
        /// </summary>
        [DisplayNameAttribute("是否为核心")]
        public string IsCores
        {
            get { return _iscores; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[是否为核心]长度不能大于50!");
                if (_iscores as object == null || !_iscores.Equals(value))
                {
                    _iscores = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Description
        /// 属性描述：描述
        /// 字段信息：[Description],nvarchar
        /// </summary>
        [DisplayNameAttribute("描述")]
        public string Description
        {
            get { return _description; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[描述]长度不能大于500!");
                if (_description as object == null || !_description.Equals(value))
                {
                    _description = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ParentID
        /// 属性描述：父模块标识
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("父模块标识")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[父模块标识]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：MethodName
        /// 属性描述：方法
        /// 字段信息：[MethodName],nvarchar
        /// </summary>
        [DisplayNameAttribute("方法")]
        public string MethodName
        {
            get { return _methodname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[方法]长度不能大于50!");
                if (_methodname as object == null || !_methodname.Equals(value))
                {
                    _methodname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：IconName
        /// 属性描述：图标
        /// 字段信息：[IconName],nvarchar
        /// </summary>
        [DisplayNameAttribute("图标")]
        public string IconName
        {
            get { return _iconname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[图标]长度不能大于50!");
                if (_iconname as object == null || !_iconname.Equals(value))
                {
                    _iconname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ActivityFlag
        /// 属性描述：作业标记
        /// 字段信息：[ActivityFlag],bit
        /// </summary>
        [DisplayNameAttribute("作业标记")]
        public bool ActivityFlag
        {
            get { return _activityflag; }
            set
            {			
                if (_activityflag as object == null || !_activityflag.Equals(value))
                {
                    _activityflag = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：visiableFlag
        /// 属性描述：是否显示
        /// 字段信息：[visiableFlag],bit
        /// </summary>
        [DisplayNameAttribute("是否显示")]
        public bool visiableFlag
        {
            get { return _visiableflag; }
            set
            {			
                if (_visiableflag as object == null || !_visiableflag.Equals(value))
                {
                    _visiableflag = value;
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
