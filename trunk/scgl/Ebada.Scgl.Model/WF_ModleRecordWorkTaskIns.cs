/**********************************************
���Ǵ����Զ����ɵģ�����������ɣ������ĸĶ����ᶪʧ
ϵͳ:Ebadaũ�����������
ģ��:ϵͳƽ̨
Ebada.com ��Ȩ����
�����ߣ�Rabbit
����ʱ��:2011-10-10 12:19:05
***********************************************/
using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
	/// <summary>
	/// ʵ����WF_ModleRecordWorkTaskIns ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class WF_ModleRecordWorkTaskIns
	{
		public WF_ModleRecordWorkTaskIns()
		{}
		#region �ֶ�
        private string _id = Newid(); 
		private string _recordid="";
		private string _modlerecordid="";
		private string _modletablename="";
		private string _workflowid="";
		private string _workflowinsid="";
		private string _worktaskid="";
		private string _worktaskinsid="";
		#endregion �ֶ�

		#region ����
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
        [DisplayNameAttribute("��¼ID")]
		public string RecordID
		{
			set{ _recordid=value;}
			get{return _recordid;}
		}
		/// <summary>
		/// 
        /// </summary>
        [DisplayNameAttribute("ģ���¼ID")]
		public string ModleRecordID
		{
			set{ _modlerecordid=value;}
			get{return _modlerecordid;}
		}
		/// <summary>
		/// 
        /// </summary>
        [DisplayNameAttribute("ģ���¼������")]
		public string ModleTableName
		{
			set{ _modletablename=value;}
			get{return _modletablename;}
		}
		/// <summary>
		/// 
        /// </summary>
        [DisplayNameAttribute("����������ID")]
		public string WorkFlowId
		{
			set{ _workflowid=value;}
			get{return _workflowid;}
		}
		/// <summary>
		/// 
        /// </summary>
        [DisplayNameAttribute("������ʵ��ID")]
		public string WorkFlowInsId
		{
			set{ _workflowinsid=value;}
			get{return _workflowinsid;}
		}
		/// <summary>
		/// 
        /// </summary>
        [DisplayNameAttribute("�������ڵ�ID")]
		public string WorkTaskId
		{
			set{ _worktaskid=value;}
			get{return _worktaskid;}
		}
		/// <summary>
		/// 
        /// </summary>
        [DisplayNameAttribute("�������ڵ�ʵ��ID")]
		public string WorkTaskInsId
		{
			set{ _worktaskinsid=value;}
			get{return _worktaskinsid;}
		}
		#endregion ����
        #region ����
        public static string Newid()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssffffff");
        }
        public string CreateID()
        {
            Thread.Sleep(new TimeSpan(100000));//0.1����
            return DateTime.Now.ToString("yyyyMMddHHmmssffffff");
        }
        #endregion		
	}
}

