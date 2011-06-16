USE [EbadaScgl]
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WFModul]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WFModul](
	[SelfCode] [varchar](50) NOT NULL,
	[FatherCode] [varchar](50) NULL,
	[Caption] [varchar](50) NULL,
	[Memo] [varchar](200) NULL,
	[NodeType] [varchar](50) NULL,
	[Leverl] [int] NULL,
	[FullPosition] [varchar](256) NULL,
	[IsVisable] [bit] NULL CONSTRAINT [DF_WFModul_IsVisable]  DEFAULT ((1)),
	[DllFileName] [varchar](128) NULL,
	[DllClassName] [varchar](128) NULL,
	[DllMethodName] [varchar](50) NULL,
	[FormName] [varchar](50) NULL,
	[BlankWindows] [bit] NULL,
	[MouseIsClick] [bit] NULL,
	[ImageIndex] [int] NULL CONSTRAINT [DF_WFModul_ImageIndex]  DEFAULT ((0)),
	[SDIWindows] [bit] NULL,
 CONSTRAINT [PK_FrmworkTree] PRIMARY KEY CLUSTERED 
(
	[SelfCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkTask]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_WorkTask](
	[WorkTaskId] [varchar](50) NOT NULL,
	[WorkFlowId] [varchar](50) NULL,
	[TaskTypeId] [char](1) NULL,
	[TaskTypeAndOr] [varchar](50) NULL,
	[TaskCaption] [varchar](128) NULL,
	[iXPosition] [int] NULL,
	[iYPosition] [int] NULL,
	[Description] [varchar](512) NULL,
	[Commands] [varchar](512) NULL,
	[OperRule] [char](1) NULL,
	[IsJumpSelf] [bit] NOT NULL,
 CONSTRAINT [PK_WorkTask] PRIMARY KEY CLUSTERED 
(
	[WorkTaskId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_Operator]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_Operator](
	[OperatorId] [varchar](50) NOT NULL,
	[WorkFlowId] [varchar](50) NULL,
	[WorkTaskId] [varchar](50) NULL,
	[NextType] [varchar](50) NULL,
	[OperType] [int] NULL,
	[OperContent] [varchar](256) NULL,
	[Relation] [int] NULL,
	[Description] [varchar](256) NULL,
	[InorExclude] [bit] NULL,
	[OperDisplay] [varchar](256) NULL,
 CONSTRAINT [PK_PS_Operator] PRIMARY KEY CLUSTERED 
(
	[OperatorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_TaskVar]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_TaskVar](
	[TaskVarId] [varchar](50) NOT NULL,
	[WorkFlowId] [varchar](50) NULL,
	[WorkTaskId] [varchar](50) NULL,
	[VarName] [varchar](128) NULL,
	[VarType] [varchar](50) NULL,
	[VarModule] [varchar](10) NULL,
	[DataBaseName] [varchar](128) NULL,
	[TableName] [varchar](128) NULL,
	[TableField] [varchar](128) NULL,
	[InitValue] [varchar](128) NULL,
	[AccessType] [varchar](50) NULL,
 CONSTRAINT [PK_PS_TaskVar] PRIMARY KEY CLUSTERED 
(
	[TaskVarId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkTaskCommands]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_WorkTaskCommands](
	[CommandId] [varchar](50) NOT NULL,
	[WorkFlowId] [varchar](50) NULL,
	[WorkTaskId] [varchar](50) NULL,
	[CommandName] [varchar](50) NULL,
	[Description] [varchar](512) NULL,
 CONSTRAINT [PK_PS_WorkTaskCommands] PRIMARY KEY CLUSTERED 
(
	[CommandId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkTaskPower]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_WorkTaskPower](
	[Powerid] [varchar](50) NOT NULL,
	[PowerName] [varchar](256) NULL,
	[Status] [char](1) NULL,
	[WorkFlowId] [varchar](50) NULL,
	[WorkTaskId] [varchar](50) NULL,
 CONSTRAINT [PK_PS_WorkTaskPower] PRIMARY KEY CLUSTERED 
(
	[Powerid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkTaskControls]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_WorkTaskControls](
	[taskControlId] [varchar](50) NOT NULL,
	[WorkflowId] [varchar](50) NULL,
	[UserControlId] [varchar](50) NULL,
	[WorktaskId] [varchar](50) NULL,
	[ControlType] [varchar](50) NULL,
 CONSTRAINT [PK_PS_WorkTaskControls] PRIMARY KEY CLUSTERED 
(
	[taskControlId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkFlowClass]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_WorkFlowClass](
	[WFClassId] [varchar](50) NOT NULL,
	[Caption] [varchar](128) NULL,
	[FatherId] [varchar](50) NULL,
	[Description] [varchar](512) NULL,
	[clLevel] [int] NULL,
	[clMgrUrl] [varchar](512) NULL,
 CONSTRAINT [PK_PS_WorkFlowClass] PRIMARY KEY CLUSTERED 
(
	[WFClassId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkFlow]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_WorkFlow](
	[WorkFlowId] [varchar](50) NOT NULL,
	[FlowCaption] [varchar](128) NULL,
	[WFClassId] [varchar](50) NULL,
	[Version] [varchar](50) NULL,
	[Status] [char](1) NULL,
	[CreateUserId] [varchar](10) NULL,
	[CreateDateTime] [datetime] NULL,
	[IsSignOut] [varchar](50) NULL,
	[SignOutUserId] [varchar](10) NULL,
	[WorkCalendarId] [varchar](50) NULL,
	[Description] [varchar](512) NULL,
	[MgrUrl] [varchar](512) NULL,
 CONSTRAINT [PK_PS_WorkFlow] PRIMARY KEY CLUSTERED 
(
	[WorkFlowId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkTaskInstance]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_WorkTaskInstance](
	[WorkTaskInsId] [varchar](50) NOT NULL,
	[WorkFlowId] [varchar](50) NULL,
	[WorkTaskId] [varchar](50) NULL,
	[WorkFlowInsId] [varchar](50) NULL,
	[PreviousTaskId] [varchar](50) NULL,
	[TaskInsCaption] [varchar](128) NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NULL,
	[Status] [char](1) NULL,
	[OperatedDes] [varchar](256) NULL,
	[OperatorInsId] [varchar](50) NULL,
	[SuccessMsg] [varchar](512) NULL,
	[OutTimeed] [bit] NULL,
	[Reminded] [bit] NULL,
	[TaskInsDescription] [varchar](256) NULL,
 CONSTRAINT [PK_PS_WorkTaskInstance] PRIMARY KEY CLUSTERED 
(
	[WorkTaskInsId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_MainUserControl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_MainUserControl](
	[MainUserCtrlId] [varchar](50) NOT NULL,
	[mucCaption] [varchar](512) NULL,
	[mucDescription] [varchar](512) NULL,
	[mucType] [varchar](50) NULL,
 CONSTRAINT [PK_PS_MainUserControl] PRIMARY KEY CLUSTERED 
(
	[MainUserCtrlId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_UserControlsLink]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_UserControlsLink](
	[mucLinkId] [varchar](50) NOT NULL,
	[UserControlId] [varchar](50) NULL,
	[MainUserCtrlId] [varchar](50) NULL,
	[CtrlOrderNbr] [int] NULL,
	[CtrlState] [varchar](50) NULL,
 CONSTRAINT [PK_PS_UserControlsLink] PRIMARY KEY CLUSTERED 
(
	[mucLinkId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_UserControls]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_UserControls](
	[UserControlId] [varchar](50) NOT NULL,
	[ucCaption] [varchar](512) NULL,
	[ucPath] [varchar](512) NULL,
	[ucID] [varchar](50) NULL,
	[ucDescription] [varchar](512) NULL,
	[ucType] [varchar](50) NULL,
 CONSTRAINT [PK_PS_UserControls] PRIMARY KEY CLUSTERED 
(
	[UserControlId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkLink]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_WorkLink](
	[WorkLinkId] [varchar](36) NOT NULL,
	[WorkFlowId] [varchar](36) NOT NULL,
	[StartTaskId] [varchar](36) NOT NULL,
	[EndTaskId] [varchar](36) NOT NULL,
	[Condition] [varchar](1024) NOT NULL,
	[Description] [varchar](512) NULL,
	[BreakX] [varchar](512) NULL,
	[BreakY] [varchar](512) NULL,
	[CommandName] [varchar](128) NOT NULL,
	[Priority] [int] NULL,
 CONSTRAINT [PK_PS_WorkLink] PRIMARY KEY CLUSTERED 
(
	[WorkLinkId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkOutTime]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_WorkOutTime](
	[Guid] [varchar](50) NOT NULL,
	[WorkFlowId] [varchar](50) NULL,
	[WorkTaskId] [varchar](50) NULL,
	[Name] [varchar](128) NULL,
	[Days] [int] NULL,
	[Hours] [int] NULL,
	[Minutes] [int] NULL,
	[Days1] [int] NULL,
	[Hours1] [int] NULL,
	[Minutes1] [int] NULL,
	[Days2] [int] NULL,
	[Hours2] [int] NULL,
	[Minutes2] [int] NULL,
	[Done] [char](1) NULL,
 CONSTRAINT [PK_PS_WorkOutTime] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkFlowEvent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_WorkFlowEvent](
	[Guid] [varchar](50) NOT NULL,
	[WorkFlowId] [varchar](50) NULL,
	[WorkTaskId] [varchar](50) NULL,
	[Remark] [varchar](256) NULL,
	[OtSms] [bit] NULL,
	[OtMsg] [bit] NULL,
	[OtEmail] [bit] NULL,
	[RmSms] [bit] NULL,
	[RmMsg] [bit] NULL,
	[RmEmail] [bit] NULL,
	[OtToUsers] [varchar](512) NULL,
	[RmToUsers] [varchar](512) NULL,
 CONSTRAINT [PK_PS_WorkFlowEvent] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_SubWorkFlow]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_SubWorkFlow](
	[subId] [varchar](50) NOT NULL,
	[WorkflowId] [varchar](50) NULL,
	[WorkTaskId] [varchar](50) NULL,
	[subWorkflowId] [varchar](50) NOT NULL,
	[subWorkflowCaption] [varchar](50) NULL,
	[subStartTaskId] [varchar](50) NULL,
	[Description] [varchar](512) NULL,
 CONSTRAINT [PK_PS_SubWorkFlow] PRIMARY KEY CLUSTERED 
(
	[subId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_AccreditUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_AccreditUser](
	[AUserId] [varchar](50) NOT NULL,
	[AccreditFromUserId] [varchar](10) NULL,
	[AccreditToUserId] [varchar](10) NULL,
	[AccreditDateTime] [datetime] NULL,
	[AccreditStatus] [char](1) NULL,
	[AcWorkflowId] [varchar](50) NULL,
	[AcWorktaskId] [varchar](50) NULL,
 CONSTRAINT [PK_PS_AccreditUser] PRIMARY KEY CLUSTERED 
(
	[AUserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_OperatorInstance]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_OperatorInstance](
	[OperatorInsId] [varchar](50) NOT NULL,
	[WorkFlowId] [varchar](50) NULL,
	[WorkTaskId] [varchar](50) NULL,
	[WorkFlowInsId] [varchar](50) NULL,
	[WorkTaskInsId] [varchar](50) NULL,
	[UserId] [varchar](50) NULL,
	[OperType] [int] NULL,
	[OperRealtion] [int] NULL,
	[OperContent] [varchar](256) NULL,
	[OperContentText] [varchar](256) NULL,
	[OperStatus] [char](1) NULL,
	[OperDateTime] [datetime] NULL,
	[ChangeOperator] [varchar](256) NULL,
 CONSTRAINT [PK_PS_OperatorInstance] PRIMARY KEY CLUSTERED 
(
	[OperatorInsId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkFlowInstance]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_WorkFlowInstance](
	[WorkFlowInsId] [varchar](50) NOT NULL,
	[WorkFlowId] [varchar](50) NULL,
	[WorkFlowNo] [varchar](128) NULL,
	[FlowInsCaption] [varchar](128) NULL,
	[Description] [varchar](512) NULL,
	[Priority] [char](1) NULL,
	[Status] [char](1) NULL,
	[NowTaskId] [varchar](50) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[SuspendTime] [datetime] NULL,
	[SuspendStaus] [char](1) NULL,
	[SuspendTotalSeconds] [int] NULL,
	[isSubWorkflow] [bit] NULL,
	[MainWorkflowInsId] [varchar](50) NULL,
	[MainWorktaskInsId] [varchar](50) NULL,
	[MainWorktaskId] [varchar](50) NULL,
	[MainWorkflowId] [varchar](50) NULL,
 CONSTRAINT [PK_PS_WorkFlowInstance] PRIMARY KEY CLUSTERED 
(
	[WorkFlowInsId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkServiceMessage]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_WorkServiceMessage](
	[MessageId] [varchar](50) NOT NULL,
	[WorkflowId] [varchar](50) NULL,
	[WorktaskId] [varchar](50) NULL,
	[WorkflowInsId] [varchar](50) NULL,
	[WorktaskInsId] [varchar](50) NULL,
	[Content] [varchar](512) NULL,
	[SendTime1] [datetime] NULL,
	[SendTime2] [datetime] NULL,
	[SendTime3] [datetime] NULL,
	[DoneFlag1] [int] NULL,
	[DoneFlag2] [int] NULL,
	[DoneFlag3] [int] NULL,
	[MsgType] [varchar](50) NULL,
	[Users1] [varchar](512) NULL,
	[Users2] [varchar](512) NULL,
	[Users3] [varchar](512) NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_PS_WorkServiceMessage] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkTaskInsNextOper]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_WorkTaskInsNextOper](
	[NextOperId] [varchar](50) NOT NULL,
	[UserId] [varchar](50) NULL,
	[UserName] [varchar](50) NULL,
	[WorkflowId] [varchar](50) NULL,
	[WorktaskId] [varchar](50) NULL,
	[WorkflowInsId] [varchar](50) NULL,
	[WorktaskInsId] [varchar](50) NULL,
 CONSTRAINT [PK_PS_WorkTaskInsNextOper] PRIMARY KEY CLUSTERED 
(
	[NextOperId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkflowAbnormal]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_WorkflowAbnormal](
	[AbnormalId] [varchar](50) NOT NULL,
	[WorkflowInsId] [varchar](50) NULL,
	[UserId] [varchar](50) NULL,
	[AbnormalMsg] [varchar](512) NULL,
	[AbnormalTime] [datetime] NULL,
 CONSTRAINT [PK_PS_WorkflowAbnormal] PRIMARY KEY CLUSTERED 
(
	[AbnormalId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PS_FrmworkParamer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PS_FrmworkParamer](
	[DBId] [char](6) NOT NULL,
	[FlagCode] [varchar](50) NULL,
	[FlagText] [varchar](50) NULL,
	[FlagValue] [varchar](50) NULL,
	[Memo] [varchar](100) NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_PS_FrmworkParamer] PRIMARY KEY CLUSTERED 
(
	[DBId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[testWorkFlow]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[testWorkFlow](
	[count] [int] NULL,
	[Guid] [nvarchar](50) NOT NULL,
	[workflowId] [varchar](50) NULL,
	[workflowInsId] [varchar](50) NULL,
	[worktaskId] [varchar](50) NULL,
	[worktaskInsId] [varchar](50) NULL,
 CONSTRAINT [PK_testWorkFlow] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[PS_UserRoleView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[PS_UserRoleView]
AS
SELECT dbo.rUserRole.RoleID, dbo.rUserRole.UserID, 
      dbo.mUser.UserName, dbo.mUser.Sex, dbo.mUser.Password, 
      dbo.mUser.OrgName , dbo.mUser.Mail , dbo.mUser.Tel , 
       
      dbo.mUser.PostName , dbo.mRole.RoleName, 
      dbo.mRole.RoleType
FROM dbo.mRole INNER JOIN
      dbo.rUserRole ON 
      dbo.mRole.RoleID = dbo.rUserRole.RoleID INNER JOIN
      dbo.mUser ON dbo.rUserRole.UserID= dbo.mUser.UserID' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkTaskLinkView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[PS_WorkTaskLinkView]
AS
SELECT dbo.PS_WorkLink.StartTaskId, dbo.PS_WorkLink.EndTaskId, 
      EndTask.TaskTypeId AS EndTaskTypeId, StartTask.TaskTypeId AS StartTaskTypeId, 
      dbo.PS_WorkLink.CommandName, dbo.PS_WorkLink.Condition, dbo.PS_WorkLink.Description, 
      dbo.PS_WorkLink.Priority, dbo.PS_WorkLink.WorkFlowId, dbo.PS_WorkLink.WorkLinkId, 
      EndTask.OperRule AS endOperRule, EndTask.TaskCaption AS endTaskCaption, 
      StartTask.TaskCaption AS startTaskCaption, StartTask.OperRule AS startOperRule, 
      EndTask.TaskTypeAndOr AS endTaskTypeAndOr, 
      StartTask.TaskTypeAndOr AS startTaskTypeAndOr, EndTask.iXPosition AS endtaskX, 
      EndTask.iYPosition AS endtaskY, StartTask.iXPosition AS starttaskX, 
      StartTask.iYPosition AS starttaskY, dbo.PS_WorkLink.BreakX, dbo.PS_WorkLink.BreakY, 
      EndTask.IsJumpSelf
FROM dbo.PS_WorkLink LEFT OUTER JOIN
      dbo.PS_WorkTask EndTask ON 
      dbo.PS_WorkLink.EndTaskId = EndTask.WorkTaskId LEFT OUTER JOIN
      dbo.PS_WorkTask StartTask ON dbo.PS_WorkLink.StartTaskId = StartTask.WorkTaskId' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkTaskInstanceView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[PS_WorkTaskInstanceView]
AS
SELECT wfIns.Priority, wfIns.WorkFlowNo, taskIns.StartTime AS taskStartTime, 
      taskIns.TaskInsCaption, wfIns.FlowInsCaption, operIns.OperContent, wf.FlowCaption, 
      wt.TaskCaption, operIns.UserId, operIns.OperatorInsId, taskIns.WorkFlowId, 
      taskIns.WorkTaskId, taskIns.WorkFlowInsId, taskIns.WorkTaskInsId, 
      operIns.OperType, wt.TaskTypeId, wfIns.isSubWorkflow, wfIns.MainWorktaskId, 
      wfIns.MainWorkflowInsId, taskIns.OperatedDes, operIns.OperDateTime, 
      taskIns.EndTime AS taskEndTime, wfIns.StartTime AS flowStartTime, 
      wfIns.EndTime AS flowEndTime, PtaskIns.OperatedDes AS pOperatedDes, 
      wfIns.Description, operIns.OperStatus, taskIns.Status, wfIns.Status AS flStatus, 
      taskIns.PreviousTaskId, operIns.OperContentText, ''0'' AS taskInsType, 
      PtaskIns.SuccessMsg, operIns.ChangeOperator, taskIns.TaskInsDescription
FROM dbo.PS_WorkTaskInstance taskIns LEFT OUTER JOIN
      dbo.PS_WorkTaskInstance PtaskIns ON 
      taskIns.PreviousTaskId = PtaskIns.WorkTaskInsId LEFT OUTER JOIN
      dbo.PS_WorkFlow wf ON taskIns.WorkFlowId = wf.WorkFlowId LEFT OUTER JOIN
      dbo.PS_WorkTask wt ON taskIns.WorkTaskId = wt.WorkTaskId LEFT OUTER JOIN
      dbo.PS_OperatorInstance operIns ON 
      taskIns.WorkTaskInsId = operIns.WorkTaskInsId LEFT OUTER JOIN
      dbo.PS_WorkFlowInstance wfIns ON taskIns.WorkFlowInsId = wfIns.WorkFlowInsId

' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkTaskControlsView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[PS_WorkTaskControlsView]
AS
SELECT dbo.PS_WorkTaskControls.WorktaskId, dbo.PS_WorkTask.TaskCaption,
      dbo.PS_UserControls.ucPath, dbo.PS_UserControls.ucCaption, 
      dbo.PS_UserControlsLink.MainUserCtrlId, dbo.PS_MainUserControl.mucCaption, 
      dbo.PS_WorkTaskControls.UserControlId, dbo.PS_UserControlsLink.CtrlOrderNbr, 
      dbo.PS_UserControlsLink.CtrlState, dbo.PS_UserControls.ucID
FROM dbo.PS_MainUserControl RIGHT OUTER JOIN
      dbo.PS_UserControlsLink ON 
      dbo.PS_MainUserControl.MainUserCtrlId = dbo.PS_UserControlsLink.MainUserCtrlId LEFT OUTER
       JOIN
      dbo.PS_UserControls ON 
      dbo.PS_UserControlsLink.UserControlId = dbo.PS_UserControls.UserControlId RIGHT OUTER JOIN
      dbo.PS_WorkTaskControls ON 
      dbo.PS_UserControlsLink.MainUserCtrlId = dbo.PS_WorkTaskControls.UserControlId LEFT OUTER
       JOIN
      dbo.PS_WorkTask ON dbo.PS_WorkTaskControls.WorktaskId = dbo.PS_WorkTask.WorkTaskId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkTaskView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[PS_WorkTaskView]
AS
SELECT dbo.PS_WorkFlow.FlowCaption, dbo.PS_WorkFlow.WFClassId, dbo.PS_WorkTask.TaskTypeId, 
      dbo.PS_WorkTask.TaskCaption, dbo.PS_Operator.OperContent, dbo.PS_Operator.OperType, 
      dbo.PS_WorkFlow.Status, dbo.PS_WorkFlow.WorkFlowId, dbo.PS_WorkTask.WorkTaskId, 
      dbo.PS_Operator.OperDisplay, dbo.PS_WorkFlowClass.Caption, dbo.PS_WorkFlowClass.FatherId, 
      dbo.PS_WorkFlowClass.clLevel, dbo.PS_WorkFlow.MgrUrl, dbo.PS_WorkTask.IsJumpSelf, 
      dbo.PS_Operator.InorExclude, dbo.PS_WorkFlowClass.clMgrUrl
FROM dbo.PS_WorkFlowClass RIGHT OUTER JOIN
      dbo.PS_WorkFlow ON 
      dbo.PS_WorkFlowClass.WFClassId = dbo.PS_WorkFlow.WFClassId RIGHT OUTER JOIN
      dbo.PS_Operator RIGHT OUTER JOIN
      dbo.PS_WorkTask ON dbo.PS_Operator.WorkTaskId = dbo.PS_WorkTask.WorkTaskId ON 
      dbo.PS_WorkFlow.WorkFlowId = dbo.PS_WorkTask.WorkFlowId' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[PS_UserControlsView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[PS_UserControlsView]
AS
SELECT dbo.PS_UserControlsLink.UserControlId, dbo.PS_UserControlsLink.MainUserCtrlId, 
      dbo.PS_MainUserControl.mucCaption, dbo.PS_UserControls.ucCaption, 
      dbo.PS_UserControls.ucPath, dbo.PS_MainUserControl.mucDescription, 
      dbo.PS_UserControls.ucDescription, dbo.PS_UserControlsLink.CtrlOrderNbr, 
      dbo.PS_UserControlsLink.CtrlState, dbo.PS_UserControls.ucID
FROM dbo.PS_UserControls RIGHT OUTER JOIN
      dbo.PS_UserControlsLink ON 
      dbo.PS_UserControls.UserControlId = dbo.PS_UserControlsLink.UserControlId LEFT OUTER JOIN
      dbo.PS_MainUserControl ON 
      dbo.PS_UserControlsLink.MainUserCtrlId = dbo.PS_MainUserControl.MainUserCtrlId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkTaskAccreditView]'))
EXEC dbo.sp_executesql @statement = N'/*
被授权启动流程的人

*/
CREATE VIEW [dbo].[PS_WorkTaskAccreditView]
AS
SELECT dbo.PS_AccreditUser.AccreditFromUserId, dbo.PS_AccreditUser.AccreditToUserId, 
      dbo.PS_AccreditUser.AccreditStatus, dbo.PS_WorkTaskView.WFClassId, 
      dbo.PS_WorkTaskView.FlowCaption, dbo.PS_WorkTaskView.Caption, 
      dbo.PS_WorkTaskView.WorkFlowId, dbo.PS_WorkTaskView.WorkTaskId, 
      dbo.PS_WorkTaskView.FatherId, dbo.PS_WorkTaskView.MgrUrl, dbo.PS_WorkTaskView.clLevel, 
      dbo.PS_WorkTaskView.TaskCaption, dbo.PS_WorkTaskView.TaskTypeId, ''1'' AS taskInsType, 
      dbo.PS_AccreditUser.AUserId, fromUser.UserName, 
      fromUser.UserName AS fromUserName, dbo.PS_WorkTaskView.clMgrUrl
FROM dbo.PS_WorkTaskView RIGHT OUTER JOIN
      dbo.PS_AccreditUser ON 
      dbo.PS_WorkTaskView.WorkFlowId = dbo.PS_AccreditUser.AcWorkflowId AND 
      dbo.PS_WorkTaskView.WorkTaskId = dbo.PS_AccreditUser.AcWorktaskId LEFT OUTER JOIN
      dbo.mUser fromUser ON 
      dbo.PS_AccreditUser.AccreditFromUserId = fromUser.UserId LEFT OUTER JOIN
      dbo.mUser toUser ON dbo.PS_AccreditUser.AccreditToUserId = toUser.UserId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[PS_OperContentView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[PS_OperContentView]
AS
SELECT TOP 100 PERCENT operContent, UserId, operContentType
FROM (SELECT UserID AS operContent, UserID, 1 AS operContentType
        FROM mUser
        UNION
        SELECT RoleID, UserId, 2
        FROM rUserRole
        UNION
        SELECT RoleID, UserID, 3
        FROM PS_UserRoleView) a
ORDER BY operContentType' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[PS_WorkTaskInsAccreditView]'))
EXEC dbo.sp_executesql @statement = N'/*
被授权启动流程的人







*/
CREATE VIEW [dbo].[PS_WorkTaskInsAccreditView]
AS
SELECT dbo.PS_AccreditUser.AccreditFromUserId, dbo.PS_AccreditUser.AccreditToUserId, 
      dbo.PS_AccreditUser.AccreditStatus, dbo.PS_WorkTaskView.WFClassId, 
      dbo.PS_WorkTaskView.FlowCaption, dbo.PS_WorkTaskView.Caption, 
      dbo.PS_WorkTaskView.WorkFlowId, dbo.PS_WorkTaskView.WorkTaskId, 
      dbo.PS_WorkTaskView.FatherId, dbo.PS_WorkTaskView.MgrUrl, dbo.PS_WorkTaskView.clLevel, 
      dbo.PS_WorkTaskView.TaskCaption, dbo.PS_WorkTaskView.TaskTypeId, 
      dbo.PS_WorkTaskInstanceView.Priority, dbo.PS_WorkTaskInstanceView.WorkFlowNo, 
      dbo.PS_WorkTaskInstanceView.taskStartTime, 
      dbo.PS_WorkTaskInstanceView.FlowInsCaption, 
      dbo.PS_WorkTaskInstanceView.TaskInsCaption, 
      dbo.PS_WorkTaskInstanceView.WorkFlowInsId, 
      dbo.PS_WorkTaskInstanceView.WorkTaskInsId, dbo.PS_WorkTaskInstanceView.OperatedDes, 
      dbo.PS_WorkTaskInstanceView.pOperatedDes, dbo.PS_WorkTaskInstanceView.OperatorInsId, 
      dbo.PS_WorkTaskInstanceView.OperType, dbo.PS_WorkTaskInstanceView.UserId, 
      dbo.PS_WorkTaskInstanceView.OperContent, dbo.PS_WorkTaskInstanceView.OperDateTime, 
      dbo.PS_WorkTaskInstanceView.taskEndTime, dbo.PS_WorkTaskInstanceView.flowStartTime, 
      dbo.PS_WorkTaskInstanceView.flowEndTime, dbo.PS_WorkTaskInstanceView.Description, 
      dbo.PS_WorkTaskInstanceView.OperStatus, ''1'' AS taskInsType, 
      dbo.PS_AccreditUser.AUserId, fromUser.UserName, dbo.PS_WorkTaskInstanceView.Status, 
      fromUser.UserName AS fromUserName, 
      dbo.PS_WorkTaskInstanceView.TaskInsDescription
FROM dbo.mUser toUser RIGHT OUTER JOIN
      dbo.PS_WorkTaskInstanceView INNER JOIN
      dbo.PS_AccreditUser ON dbo.PS_WorkTaskInstanceView.OperContent IN
          (SELECT OperContent
         FROM PS_OperContentView
         WHERE UserId = dbo.PS_AccreditUser.AccreditFromUserId) LEFT OUTER JOIN
      dbo.PS_WorkTaskView ON 
      dbo.PS_AccreditUser.AcWorkflowId = dbo.PS_WorkTaskView.WorkFlowId AND 
      dbo.PS_AccreditUser.AcWorktaskId = dbo.PS_WorkTaskView.WorkTaskId LEFT OUTER JOIN
      dbo.mUser fromUser ON 
      dbo.PS_AccreditUser.AccreditFromUserId = fromUser.UserId ON 
      toUser.UserId = dbo.PS_AccreditUser.AccreditToUserId
' 
