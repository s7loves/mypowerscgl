using System;

namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// 系统常量
	/// </summary>
    public class WorkConst
	{
		/// <summary>
        /// 添加状态
		/// </summary>
		public  const  string STATE_ADD = "新建";
        /// <summary>
        ///修改状态
        /// </summary>
		public  const  string STATE_MOD = "修改";
        /// <summary>
        ///查询状态
        /// </summary>
        public const string STATE_VIEW = "查看";
        /// <summary>
        /// 弹出界面交互
        /// </summary>
		public  const  string TREENODE_TYPE_WIN="Window";
        /// <summary>
        /// 执行功能
        /// </summary>
		public  const  string TREENODE_TYPE_FUN="Function";
        /// <summary>
        /// 工作流分类标志
        /// </summary>
        public const   string WORKFLOW_CLASS = "WorkFlowClass";
        /// <summary>
        /// 工作流标志
        /// </summary>
        public const string WORKFLOW_FLOW = "WorkFlow";
        /// <summary>
        /// 公司
        /// </summary>
        public const string ARCHITECTURE_COMPANY = "公司";
        /// <summary>
        /// 组织机构
        /// </summary>
        public const string ARCHITECTURE_ARCH = "部门";
        /// <summary>
        /// 用户
        /// </summary>
        public const string ARCHITECTURE_USER = "User";
        /// <summary>
        /// 岗位职务
        /// </summary>
        public const string ARCHITECTURE_DUTY = "岗位";
        /// <summary>
        /// 岗位级别
        /// </summary>
        public const string ARCHITECTURE_DUTYLevel = "岗位级别";
        /// <summary>
        /// 与命令
        /// </summary>
        public const string Command_And = "and";
        /// <summary>
        /// 或命令
        /// </summary>
        public const string Command_Or = "or";
        /// <summary>
        /// 共有类型
        /// </summary>
        public const string Access_Public = "public";
        /// <summary>
        /// 私有类型
        /// </summary>
        public const string Access_Private = "private";
        /// <summary>
        ///主表单
        /// </summary>
        public const string UserControl_Main = "MainUserControl";
        /// <summary>
        /// 子表单
        /// </summary>
        public const string UserControl_Child = "ChildUserControl";
        /// <summary>
        /// 绑定表单内容
        /// </summary>
        public const string WorkTask_BindTable = "绑定表单内容"; /// <summary>
        /// <summary>
        /// 基于节点内容
        /// </summary>
        public const string WorkTask_BindTask = "基于节点内容"; /// <summary>
        /// <summary>
        /// 任务退回
        /// </summary>
        public const string WorkTask_Return = "退回"; /// <summary>
        /// 任务附件
        /// </summary>
        public const string WorkTask_FuJian = "附件";
        /// 任务审批意见
        /// </summary>
        public const string WorkTask_SPYJ = "审批意见";
        /// <summary>
        /// 任务指派
        /// </summary>
        public const string WorkTask_Assign = "指派";
        /// <summary>
        /// 工作日志
        /// </summary>
        public const string WorkTask_WorkRiZhi = "工作日志";
        /// <summary>
        /// 允许导出
        /// </summary>
        public const string WorkTask_WorkExplore = "允许导出";
        /// <summary>
        /// 允许所有人导出
        /// </summary>
        public const string WorkTask_WorkAllExplore = "允许所有人导出";
        /// 任务审批意见
        /// </summary>
        public const string WorkTask_FlowEndExplore = "流程结束后允许导出";
        /// <summary>
        /// 允许所有人导出
        /// </summary>
        public const string WorkTask_WorkFollow = "全程跟踪";
        /// <summary>
        /// 动态指定一下任务处理人
        /// </summary>
        public const string WorkTask_DyAssignNext = "动态指定";

        public  string[] FlowPriority ={ "普通", "紧急", "特急" };
        
		
	}
}
