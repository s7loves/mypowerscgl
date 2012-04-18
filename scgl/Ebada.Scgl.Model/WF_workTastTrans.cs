/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-4-19 5:00:41
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[WF_WorkTastTrans]业务实体类
    ///对应表名:WF_WorkTastTrans
    /// </summary>
    [Serializable]
    public class WF_WorkTastTrans
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _workflowid=String.Empty; 
        private string _slcid=String.Empty; 
        private string _slcmc=String.Empty; 
        private string _slcjdid=String.Empty; 
        private string _slcjdmc=String.Empty; 
        private string _slcjdzdid=String.Empty; 
        private string _slcjdzdmc=String.Empty; 
        private string _slcjdzdlx=String.Empty; 
        private string _slcjdzdbid=String.Empty; 
        private string _ssql=String.Empty; 
        private string _cdfs=String.Empty; 
        private string _tlcid=String.Empty; 
        private string _tlcmc=String.Empty; 
        private string _tlcjdid=String.Empty; 
        private string _tlcjdmc=String.Empty; 
        private string _tlcjdzdid=String.Empty; 
        private string _tlcjdzdbid=String.Empty; 
        private string _tlcjdzdmc=String.Empty; 
        private string _tlcjdzdlx=String.Empty; 
        private string _tsql=String.Empty; 
        private string _s1=String.Empty; 
        private string _s2=String.Empty; 
        private string _s3=String.Empty; 
        private string _s4=String.Empty; 
        private string _s5=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：记录ID
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("记录ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[记录ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WorkFlowID
        /// 属性描述：设置的流程ID
        /// 字段信息：[WorkFlowID],nvarchar
        /// </summary>
        [DisplayNameAttribute("设置的流程ID")]
        public string WorkFlowID
        {
            get { return _workflowid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设置的流程ID]长度不能大于50!");
                if (_workflowid as object == null || !_workflowid.Equals(value))
                {
                    _workflowid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：slcid
        /// 属性描述：源流程ID
        /// 字段信息：[slcid],nvarchar
        /// </summary>
        [DisplayNameAttribute("源流程ID")]
        public string slcid
        {
            get { return _slcid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[源流程ID]长度不能大于50!");
                if (_slcid as object == null || !_slcid.Equals(value))
                {
                    _slcid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：slcmc
        /// 属性描述：源流程名称
        /// 字段信息：[slcmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("源流程名称")]
        public string slcmc
        {
            get { return _slcmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[源流程名称]长度不能大于50!");
                if (_slcmc as object == null || !_slcmc.Equals(value))
                {
                    _slcmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：slcjdid
        /// 属性描述：源流程节点ID
        /// 字段信息：[slcjdid],nvarchar
        /// </summary>
        [DisplayNameAttribute("源流程节点ID")]
        public string slcjdid
        {
            get { return _slcjdid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[源流程节点ID]长度不能大于50!");
                if (_slcjdid as object == null || !_slcjdid.Equals(value))
                {
                    _slcjdid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：slcjdmc
        /// 属性描述：源流程节点名称
        /// 字段信息：[slcjdmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("源流程节点名称")]
        public string slcjdmc
        {
            get { return _slcjdmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[源流程节点名称]长度不能大于50!");
                if (_slcjdmc as object == null || !_slcjdmc.Equals(value))
                {
                    _slcjdmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：slcjdzdid
        /// 属性描述：源流程节点字段ID
        /// 字段信息：[slcjdzdid],nvarchar
        /// </summary>
        [DisplayNameAttribute("源流程节点字段ID")]
        public string slcjdzdid
        {
            get { return _slcjdzdid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[源流程节点字段ID]长度不能大于50!");
                if (_slcjdzdid as object == null || !_slcjdzdid.Equals(value))
                {
                    _slcjdzdid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：slcjdzdmc
        /// 属性描述：源流程节点字段名称
        /// 字段信息：[slcjdzdmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("源流程节点字段名称")]
        public string slcjdzdmc
        {
            get { return _slcjdzdmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[源流程节点字段名称]长度不能大于50!");
                if (_slcjdzdmc as object == null || !_slcjdzdmc.Equals(value))
                {
                    _slcjdzdmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：slcjdzdlx
        /// 属性描述：源流程节点字段类型
        /// 字段信息：[slcjdzdlx],nvarchar
        /// </summary>
        [DisplayNameAttribute("源流程节点字段类型")]
        public string slcjdzdlx
        {
            get { return _slcjdzdlx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[源流程节点字段类型]长度不能大于50!");
                if (_slcjdzdlx as object == null || !_slcjdzdlx.Equals(value))
                {
                    _slcjdzdlx = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：slcjdzdbid
        /// 属性描述：源流程节点字段表ID
        /// 字段信息：[slcjdzdbid],nvarchar
        /// </summary>
        [DisplayNameAttribute("源流程节点字段表ID")]
        public string slcjdzdbid
        {
            get { return _slcjdzdbid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[源流程节点字段表ID]长度不能大于50!");
                if (_slcjdzdbid as object == null || !_slcjdzdbid.Equals(value))
                {
                    _slcjdzdbid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sSQL
        /// 属性描述：源SQL
        /// 字段信息：[sSQL],nvarchar
        /// </summary>
        [DisplayNameAttribute("源SQL")]
        public string sSQL
        {
            get { return _ssql; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[源SQL]长度不能大于1073741823!");
                if (_ssql as object == null || !_ssql.Equals(value))
                {
                    _ssql = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cdfs
        /// 属性描述：传递方式
        /// 字段信息：[cdfs],nvarchar
        /// </summary>
        [DisplayNameAttribute("传递方式")]
        public string cdfs
        {
            get { return _cdfs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[传递方式]长度不能大于50!");
                if (_cdfs as object == null || !_cdfs.Equals(value))
                {
                    _cdfs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tlcid
        /// 属性描述：目标流程ID
        /// 字段信息：[tlcid],nvarchar
        /// </summary>
        [DisplayNameAttribute("目标流程ID")]
        public string tlcid
        {
            get { return _tlcid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[目标流程ID]长度不能大于50!");
                if (_tlcid as object == null || !_tlcid.Equals(value))
                {
                    _tlcid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tlcmc
        /// 属性描述：目标流程名称
        /// 字段信息：[tlcmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("目标流程名称")]
        public string tlcmc
        {
            get { return _tlcmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[目标流程名称]长度不能大于50!");
                if (_tlcmc as object == null || !_tlcmc.Equals(value))
                {
                    _tlcmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tlcjdid
        /// 属性描述：目标流程节点ID
        /// 字段信息：[tlcjdid],nvarchar
        /// </summary>
        [DisplayNameAttribute("目标流程节点ID")]
        public string tlcjdid
        {
            get { return _tlcjdid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[目标流程节点ID]长度不能大于50!");
                if (_tlcjdid as object == null || !_tlcjdid.Equals(value))
                {
                    _tlcjdid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tlcjdmc
        /// 属性描述：目标流程节点名称
        /// 字段信息：[tlcjdmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("目标流程节点名称")]
        public string tlcjdmc
        {
            get { return _tlcjdmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[目标流程节点名称]长度不能大于50!");
                if (_tlcjdmc as object == null || !_tlcjdmc.Equals(value))
                {
                    _tlcjdmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tlcjdzdid
        /// 属性描述：目标流程节点字段ID
        /// 字段信息：[tlcjdzdid],nvarchar
        /// </summary>
        [DisplayNameAttribute("目标流程节点字段ID")]
        public string tlcjdzdid
        {
            get { return _tlcjdzdid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[目标流程节点字段ID]长度不能大于50!");
                if (_tlcjdzdid as object == null || !_tlcjdzdid.Equals(value))
                {
                    _tlcjdzdid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tlcjdzdbid
        /// 属性描述：目标流程节点字段表ID
        /// 字段信息：[tlcjdzdbid],nvarchar
        /// </summary>
        [DisplayNameAttribute("目标流程节点字段表ID")]
        public string tlcjdzdbid
        {
            get { return _tlcjdzdbid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[目标流程节点字段表ID]长度不能大于50!");
                if (_tlcjdzdbid as object == null || !_tlcjdzdbid.Equals(value))
                {
                    _tlcjdzdbid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tlcjdzdmc
        /// 属性描述：目标流程节点字段名称
        /// 字段信息：[tlcjdzdmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("目标流程节点字段名称")]
        public string tlcjdzdmc
        {
            get { return _tlcjdzdmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[目标流程节点字段名称]长度不能大于50!");
                if (_tlcjdzdmc as object == null || !_tlcjdzdmc.Equals(value))
                {
                    _tlcjdzdmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tlcjdzdlx
        /// 属性描述：目标流程节点字段类型
        /// 字段信息：[tlcjdzdlx],nvarchar
        /// </summary>
        [DisplayNameAttribute("目标流程节点字段类型")]
        public string tlcjdzdlx
        {
            get { return _tlcjdzdlx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[目标流程节点字段类型]长度不能大于50!");
                if (_tlcjdzdlx as object == null || !_tlcjdzdlx.Equals(value))
                {
                    _tlcjdzdlx = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tSQL
        /// 属性描述：目标SQL
        /// 字段信息：[tSQL],nvarchar
        /// </summary>
        [DisplayNameAttribute("目标SQL")]
        public string tSQL
        {
            get { return _tsql; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[目标SQL]长度不能大于1073741823!");
                if (_tsql as object == null || !_tsql.Equals(value))
                {
                    _tsql = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S1
        /// 属性描述：S1
        /// 字段信息：[S1],nvarchar
        /// </summary>
        [DisplayNameAttribute("S1")]
        public string S1
        {
            get { return _s1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[S1]长度不能大于1073741823!");
                if (_s1 as object == null || !_s1.Equals(value))
                {
                    _s1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S2
        /// 属性描述：S2
        /// 字段信息：[S2],nvarchar
        /// </summary>
        [DisplayNameAttribute("S2")]
        public string S2
        {
            get { return _s2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[S2]长度不能大于1073741823!");
                if (_s2 as object == null || !_s2.Equals(value))
                {
                    _s2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S3
        /// 属性描述：S3
        /// 字段信息：[S3],nvarchar
        /// </summary>
        [DisplayNameAttribute("S3")]
        public string S3
        {
            get { return _s3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[S3]长度不能大于1073741823!");
                if (_s3 as object == null || !_s3.Equals(value))
                {
                    _s3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S4
        /// 属性描述：S4
        /// 字段信息：[S4],nvarchar
        /// </summary>
        [DisplayNameAttribute("S4")]
        public string S4
        {
            get { return _s4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[S4]长度不能大于1073741823!");
                if (_s4 as object == null || !_s4.Equals(value))
                {
                    _s4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S5
        /// 属性描述：S5
        /// 字段信息：[S5],nvarchar
        /// </summary>
        [DisplayNameAttribute("S5")]
        public string S5
        {
            get { return _s5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[S5]长度不能大于1073741823!");
                if (_s5 as object == null || !_s5.Equals(value))
                {
                    _s5 = value;
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
