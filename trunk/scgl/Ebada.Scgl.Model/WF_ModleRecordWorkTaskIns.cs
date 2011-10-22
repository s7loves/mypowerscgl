/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-10-10 12:19:05
***********************************************/
using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
	/// <summary>
	/// 实体类WF_ModleRecordWorkTaskIns 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class WF_ModleRecordWorkTaskIns
	{
		public WF_ModleRecordWorkTaskIns()
		{}
		#region 字段
        private string _id = Newid(); 
		private string _recordid="";
		private string _modlerecordid="";
		private string _modletablename="";
		private string _workflowid="";
		private string _workflowinsid="";
		private string _worktaskid="";
		private string _worktaskinsid="";
		#endregion 字段

		#region 属性
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
        /// </summary>
        [DisplayNameAttribute("记录ID")]
		public string RecordID
		{
			set{ _recordid=value;}
			get{return _recordid;}
		}
		/// <summary>
		/// 
        /// </summary>
        [DisplayNameAttribute("模块记录ID")]
		public string ModleRecordID
		{
			set{ _modlerecordid=value;}
			get{return _modlerecordid;}
		}
		/// <summary>
		/// 
        /// </summary>
        [DisplayNameAttribute("模块记录的名称")]
		public string ModleTableName
		{
			set{ _modletablename=value;}
			get{return _modletablename;}
		}
		/// <summary>
		/// 
        /// </summary>
        [DisplayNameAttribute("工作流名称ID")]
		public string WorkFlowId
		{
			set{ _workflowid=value;}
			get{return _workflowid;}
		}
		/// <summary>
		/// 
        /// </summary>
        [DisplayNameAttribute("工作流实例ID")]
		public string WorkFlowInsId
		{
			set{ _workflowinsid=value;}
			get{return _workflowinsid;}
		}
		/// <summary>
		/// 
        /// </summary>
        [DisplayNameAttribute("工作流节点ID")]
		public string WorkTaskId
		{
			set{ _worktaskid=value;}
			get{return _worktaskid;}
		}
		/// <summary>
		/// 
        /// </summary>
        [DisplayNameAttribute("工作流节点实例ID")]
		public string WorkTaskInsId
		{
			set{ _worktaskinsid=value;}
			get{return _worktaskinsid;}
		}
		#endregion 属性
        #region 方法
        public static string Newid()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssffffff");
        }
        public string CreateID()
        {
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            return DateTime.Now.ToString("yyyyMMddHHmmssffffff");
        }
        #endregion		
	}
}

