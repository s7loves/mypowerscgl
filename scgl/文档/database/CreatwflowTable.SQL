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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkTask]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_WorkTask](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_Operator]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_Operator](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_TaskVar]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_TaskVar](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkTaskCommands]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_WorkTaskCommands](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkTaskPower]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_WorkTaskPower](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkTaskControls]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_WorkTaskControls](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkFlowClass]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_WorkFlowClass](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkFlow]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_WorkFlow](
	[WorkFlowId] [varchar](50) NOT NULL,
	[FlowCaption] [varchar](128) NULL,
	[WFClassId] [varchar](50) NULL,
	[Version] [varchar](50) NULL,
	[Status] [char](1) NULL,
	[CreateUserId] [varchar](50) NULL,
	[CreateDateTime] [datetime] NULL,
	[IsSignOut] [varchar](50) NULL,
	[SignOutUserId] [varchar](50) NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkTaskInstance]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_WorkTaskInstance](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_MainUserControl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_MainUserControl](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_UserControlsLink]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_UserControlsLink](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_UserControls]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_UserControls](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkLink]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_WorkLink](
	[WorkLinkId] [varchar](50) NOT NULL,
	[WorkFlowId] [varchar](50) NOT NULL,
	[StartTaskId] [varchar](50) NOT NULL,
	[EndTaskId] [varchar](50) NOT NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkOutTime]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_WorkOutTime](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkFlowEvent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_WorkFlowEvent](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_SubWorkFlow]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_SubWorkFlow](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_AccreditUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_AccreditUser](
	[AUserId] [varchar](50) NOT NULL,
	[AccreditFromUserId] [varchar](50) NULL,
	[AccreditToUserId] [varchar](50) NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_OperatorInstance]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_OperatorInstance](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkFlowInstance]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_WorkFlowInstance](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkServiceMessage]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_WorkServiceMessage](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkTaskInsNextOper]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_WorkTaskInsNextOper](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkflowAbnormal]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_WorkflowAbnormal](
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_FrmworkParamer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WF_FrmworkParamer](
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
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkTaskLinkView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[WF_WorkTaskLinkView]
AS
SELECT     dbo.WF_WorkLink.StartTaskId, dbo.WF_WorkLink.EndTaskId, EndTask.TaskTypeId AS EndTaskTypeId, StartTask.TaskTypeId AS StartTaskTypeId, 
                      dbo.WF_WorkLink.CommandName, dbo.WF_WorkLink.Condition, dbo.WF_WorkLink.Description, dbo.WF_WorkLink.Priority, 
                      dbo.WF_WorkLink.WorkFlowId, dbo.WF_WorkLink.WorkLinkId, EndTask.OperRule AS endOperRule, EndTask.TaskCaption AS endTaskCaption, 
                      StartTask.TaskCaption AS startTaskCaption, StartTask.OperRule AS startOperRule, EndTask.TaskTypeAndOr AS endTaskTypeAndOr, 
                      StartTask.TaskTypeAndOr AS startTaskTypeAndOr, EndTask.iXPosition AS endtaskX, EndTask.iYPosition AS endtaskY, 
                      StartTask.iXPosition AS starttaskX, StartTask.iYPosition AS starttaskY, dbo.WF_WorkLink.BreakX, dbo.WF_WorkLink.BreakY, 
                      EndTask.IsJumpSelf
FROM         dbo.WF_WorkLink LEFT OUTER JOIN
                      dbo.WF_WorkTask AS EndTask ON dbo.WF_WorkLink.EndTaskId = EndTask.WorkTaskId LEFT OUTER JOIN
                      dbo.WF_WorkTask AS StartTask ON dbo.WF_WorkLink.StartTaskId = StartTask.WorkTaskId
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'WF_WorkTaskLinkView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "WF_WorkLink"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 193
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EndTask"
            Begin Extent = 
               Top = 6
               Left = 231
               Bottom = 121
               Right = 389
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "StartTask"
            Begin Extent = 
               Top = 6
               Left = 427
               Bottom = 121
               Right = 585
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WF_WorkTaskLinkView'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'WF_WorkTaskLinkView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WF_WorkTaskLinkView'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkTaskInstanceView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[WF_WorkTaskInstanceView]
AS
SELECT     wfIns.Priority, wfIns.WorkFlowNo, taskIns.StartTime AS taskStartTime, taskIns.TaskInsCaption, wfIns.FlowInsCaption, operIns.OperContent, 
                      wf.FlowCaption, wt.TaskCaption, operIns.UserId, operIns.OperatorInsId, taskIns.WorkFlowId, taskIns.WorkTaskId, taskIns.WorkFlowInsId, 
                      taskIns.WorkTaskInsId, operIns.OperType, wt.TaskTypeId, wfIns.isSubWorkflow, wfIns.MainWorktaskId, wfIns.MainWorkflowInsId, 
                      taskIns.OperatedDes, operIns.OperDateTime, taskIns.EndTime AS taskEndTime, wfIns.StartTime AS flowStartTime, wfIns.EndTime AS flowEndTime, 
                      PtaskIns.OperatedDes AS pOperatedDes, wfIns.Description, operIns.OperStatus, taskIns.Status, wfIns.Status AS flStatus, taskIns.PreviousTaskId, 
                      operIns.OperContentText, ''0'' AS taskInsType, PtaskIns.SuccessMsg, operIns.ChangeOperator, taskIns.TaskInsDescription
FROM         dbo.WF_WorkTaskInstance AS taskIns LEFT OUTER JOIN
                      dbo.WF_WorkTaskInstance AS PtaskIns ON taskIns.PreviousTaskId = PtaskIns.WorkTaskInsId LEFT OUTER JOIN
                      dbo.WF_WorkFlow AS wf ON taskIns.WorkFlowId = wf.WorkFlowId LEFT OUTER JOIN
                      dbo.WF_WorkTask AS wt ON taskIns.WorkTaskId = wt.WorkTaskId LEFT OUTER JOIN
                      dbo.WF_OperatorInstance AS operIns ON taskIns.WorkTaskInsId = operIns.WorkTaskInsId LEFT OUTER JOIN
                      dbo.WF_WorkFlowInstance AS wfIns ON taskIns.WorkFlowInsId = wfIns.WorkFlowInsId
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'WF_WorkTaskInstanceView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "taskIns"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 209
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PtaskIns"
            Begin Extent = 
               Top = 6
               Left = 247
               Bottom = 121
               Right = 418
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "wf"
            Begin Extent = 
               Top = 6
               Left = 456
               Bottom = 121
               Right = 615
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "wt"
            Begin Extent = 
               Top = 6
               Left = 653
               Bottom = 121
               Right = 811
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "operIns"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 241
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "wfIns"
            Begin Extent = 
               Top = 126
               Left = 242
               Bottom = 241
               Right = 428
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
       ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WF_WorkTaskInstanceView'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane2' , N'SCHEMA',N'dbo', N'VIEW',N'WF_WorkTaskInstanceView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WF_WorkTaskInstanceView'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'WF_WorkTaskInstanceView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WF_WorkTaskInstanceView'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkTaskControlsView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[WF_WorkTaskControlsView]
AS
SELECT     dbo.WF_WorkTaskControls.WorktaskId, dbo.WF_WorkTask.TaskCaption, dbo.WF_UserControls.ucPath, dbo.WF_UserControls.ucCaption, 
                      dbo.WF_UserControlsLink.MainUserCtrlId, dbo.WF_MainUserControl.mucCaption, dbo.WF_WorkTaskControls.UserControlId, 
                      dbo.WF_UserControlsLink.CtrlOrderNbr, dbo.WF_UserControlsLink.CtrlState, dbo.WF_UserControls.ucID
FROM         dbo.WF_MainUserControl RIGHT OUTER JOIN
                      dbo.WF_UserControlsLink ON dbo.WF_MainUserControl.MainUserCtrlId = dbo.WF_UserControlsLink.MainUserCtrlId LEFT OUTER JOIN
                      dbo.WF_UserControls ON dbo.WF_UserControlsLink.UserControlId = dbo.WF_UserControls.UserControlId RIGHT OUTER JOIN
                      dbo.WF_WorkTaskControls ON dbo.WF_UserControlsLink.MainUserCtrlId = dbo.WF_WorkTaskControls.UserControlId LEFT OUTER JOIN
                      dbo.WF_WorkTask ON dbo.WF_WorkTaskControls.WorktaskId = dbo.WF_WorkTask.WorkTaskId
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'WF_WorkTaskControlsView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "WF_MainUserControl"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 191
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WF_UserControlsLink"
            Begin Extent = 
               Top = 6
               Left = 229
               Bottom = 121
               Right = 381
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WF_UserControls"
            Begin Extent = 
               Top = 6
               Left = 419
               Bottom = 121
               Right = 567
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WF_WorkTaskControls"
            Begin Extent = 
               Top = 6
               Left = 605
               Bottom = 121
               Right = 753
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WF_WorkTask"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 241
               Right = 196
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WF_WorkTaskControlsView'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane2' , N'SCHEMA',N'dbo', N'VIEW',N'WF_WorkTaskControlsView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WF_WorkTaskControlsView'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'WF_WorkTaskControlsView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WF_WorkTaskControlsView'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkTaskView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[WF_WorkTaskView]
AS
SELECT     dbo.WF_WorkFlow.FlowCaption, dbo.WF_WorkFlow.WFClassId, dbo.WF_WorkTask.TaskTypeId, dbo.WF_WorkTask.TaskCaption, 
                      dbo.WF_Operator.OperContent, dbo.WF_Operator.OperType, dbo.WF_WorkFlow.Status, dbo.WF_WorkFlow.WorkFlowId, 
                      dbo.WF_WorkTask.WorkTaskId, dbo.WF_Operator.OperDisplay, dbo.WF_WorkFlowClass.Caption, dbo.WF_WorkFlowClass.FatherId, 
                      dbo.WF_WorkFlowClass.clLevel, dbo.WF_WorkFlow.MgrUrl, dbo.WF_WorkTask.IsJumpSelf, dbo.WF_Operator.InorExclude, 
                      dbo.WF_WorkFlowClass.clMgrUrl
FROM         dbo.WF_WorkFlowClass RIGHT OUTER JOIN
                      dbo.WF_WorkFlow ON dbo.WF_WorkFlowClass.WFClassId = dbo.WF_WorkFlow.WFClassId RIGHT OUTER JOIN
                      dbo.WF_Operator RIGHT OUTER JOIN
                      dbo.WF_WorkTask ON dbo.WF_Operator.WorkTaskId = dbo.WF_WorkTask.WorkTaskId ON 
                      dbo.WF_WorkFlow.WorkFlowId = dbo.WF_WorkTask.WorkFlowId
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'WF_WorkTaskView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "WF_WorkFlowClass"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 172
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WF_WorkFlow"
            Begin Extent = 
               Top = 6
               Left = 210
               Bottom = 121
               Right = 369
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WF_Operator"
            Begin Extent = 
               Top = 6
               Left = 407
               Bottom = 121
               Right = 551
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WF_WorkTask"
            Begin Extent = 
               Top = 6
               Left = 589
               Bottom = 121
               Right = 747
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WF_WorkTaskView'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'WF_WorkTaskView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WF_WorkTaskView'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[WF_UserControlsView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[WF_UserControlsView]
AS
SELECT     dbo.WF_UserControlsLink.UserControlId, dbo.WF_UserControlsLink.MainUserCtrlId, dbo.WF_MainUserControl.mucCaption, 
                      dbo.WF_UserControls.ucCaption, dbo.WF_UserControls.ucPath, dbo.WF_MainUserControl.mucDescription, dbo.WF_UserControls.ucDescription, 
                      dbo.WF_UserControlsLink.CtrlOrderNbr, dbo.WF_UserControlsLink.CtrlState, dbo.WF_UserControls.ucID
FROM         dbo.WF_UserControls RIGHT OUTER JOIN
                      dbo.WF_UserControlsLink ON dbo.WF_UserControls.UserControlId = dbo.WF_UserControlsLink.UserControlId LEFT OUTER JOIN
                      dbo.WF_MainUserControl ON dbo.WF_UserControlsLink.MainUserCtrlId = dbo.WF_MainUserControl.MainUserCtrlId
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'WF_UserControlsView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "WF_UserControls"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 186
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WF_UserControlsLink"
            Begin Extent = 
               Top = 6
               Left = 224
               Bottom = 121
               Right = 376
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WF_MainUserControl"
            Begin Extent = 
               Top = 6
               Left = 414
               Bottom = 121
               Right = 567
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WF_UserControlsView'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'WF_UserControlsView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WF_UserControlsView'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[WF_UserRoleView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[WF_UserRoleView]
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
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkTaskAccreditView]'))
EXEC dbo.sp_executesql @statement = N'/*
被授权启动流程的人

*/
CREATE VIEW [dbo].[WF_WorkTaskAccreditView]
AS
SELECT     dbo.WF_AccreditUser.AccreditFromUserId, dbo.WF_AccreditUser.AccreditToUserId, dbo.WF_AccreditUser.AccreditStatus, 
                      dbo.WF_WorkTaskView.WFClassId, dbo.WF_WorkTaskView.FlowCaption, dbo.WF_WorkTaskView.Caption, dbo.WF_WorkTaskView.WorkFlowId, 
                      dbo.WF_WorkTaskView.WorkTaskId, dbo.WF_WorkTaskView.FatherId, dbo.WF_WorkTaskView.MgrUrl, dbo.WF_WorkTaskView.clLevel, 
                      dbo.WF_WorkTaskView.TaskCaption, dbo.WF_WorkTaskView.TaskTypeId, ''1'' AS taskInsType, dbo.WF_AccreditUser.AUserId, fromUser.UserName, 
                      fromUser.UserName AS fromUserName, dbo.WF_WorkTaskView.clMgrUrl
FROM         dbo.WF_WorkTaskView RIGHT OUTER JOIN
                      dbo.WF_AccreditUser ON dbo.WF_WorkTaskView.WorkFlowId = dbo.WF_AccreditUser.AcWorkflowId AND 
                      dbo.WF_WorkTaskView.WorkTaskId = dbo.WF_AccreditUser.AcWorktaskId LEFT OUTER JOIN
                      dbo.mUser AS fromUser ON dbo.WF_AccreditUser.AccreditFromUserId = fromUser.UserID LEFT OUTER JOIN
                      dbo.mUser AS toUser ON dbo.WF_AccreditUser.AccreditToUserId = toUser.UserID
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'WF_WorkTaskAccreditView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "fromUser"
            Begin Extent = 
               Top = 66
               Left = 38
               Bottom = 181
               Right = 169
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "toUser"
            Begin Extent = 
               Top = 66
               Left = 207
               Bottom = 181
               Right = 338
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WF_WorkTaskView"
            Begin Extent = 
               Top = 6
               Left = 376
               Bottom = 121
               Right = 520
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WF_AccreditUser"
            Begin Extent = 
               Top = 6
               Left = 558
               Bottom = 121
               Right = 734
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WF_WorkTaskAccreditView'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'WF_WorkTaskAccreditView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WF_WorkTaskAccreditView'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[WF_OperContentView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[WF_OperContentView]
AS
SELECT     TOP (100) PERCENT operContent, UserID, operContentType
FROM         (SELECT     UserID AS operContent, UserID, 1 AS operContentType
                       FROM          dbo.mUser
                       UNION
                       SELECT     RoleID, UserID, 2 AS Expr1
                       FROM         dbo.rUserRole
                       UNION
                       SELECT     RoleID, UserID, 3 AS Expr1
                       FROM         dbo.WF_UserRoleView) AS a
ORDER BY operContentType
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'WF_OperContentView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[31] 4[5] 2[46] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 106
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WF_OperContentView'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'WF_OperContentView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WF_OperContentView'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[WF_WorkTaskInsAccreditView]'))
EXEC dbo.sp_executesql @statement = N'/*
被授权启动流程的人







*/
CREATE VIEW [dbo].[WF_WorkTaskInsAccreditView]
AS
SELECT dbo.WF_AccreditUser.AccreditFromUserId, dbo.WF_AccreditUser.AccreditToUserId, 
      dbo.WF_AccreditUser.AccreditStatus, dbo.WF_WorkTaskView.WFClassId, 
      dbo.WF_WorkTaskView.FlowCaption, dbo.WF_WorkTaskView.Caption, 
      dbo.WF_WorkTaskView.WorkFlowId, dbo.WF_WorkTaskView.WorkTaskId, 
      dbo.WF_WorkTaskView.FatherId, dbo.WF_WorkTaskView.MgrUrl, dbo.WF_WorkTaskView.clLevel, 
      dbo.WF_WorkTaskView.TaskCaption, dbo.WF_WorkTaskView.TaskTypeId, 
      dbo.WF_WorkTaskInstanceView.Priority, dbo.WF_WorkTaskInstanceView.WorkFlowNo, 
      dbo.WF_WorkTaskInstanceView.taskStartTime, 
      dbo.WF_WorkTaskInstanceView.FlowInsCaption, 
      dbo.WF_WorkTaskInstanceView.TaskInsCaption, 
      dbo.WF_WorkTaskInstanceView.WorkFlowInsId, 
      dbo.WF_WorkTaskInstanceView.WorkTaskInsId, dbo.WF_WorkTaskInstanceView.OperatedDes, 
      dbo.WF_WorkTaskInstanceView.pOperatedDes, dbo.WF_WorkTaskInstanceView.OperatorInsId, 
      dbo.WF_WorkTaskInstanceView.OperType, dbo.WF_WorkTaskInstanceView.UserId, 
      dbo.WF_WorkTaskInstanceView.OperContent, dbo.WF_WorkTaskInstanceView.OperDateTime, 
      dbo.WF_WorkTaskInstanceView.taskEndTime, dbo.WF_WorkTaskInstanceView.flowStartTime, 
      dbo.WF_WorkTaskInstanceView.flowEndTime, dbo.WF_WorkTaskInstanceView.Description, 
      dbo.WF_WorkTaskInstanceView.OperStatus, ''1'' AS taskInsType, 
      dbo.WF_AccreditUser.AUserId, fromUser.UserName, dbo.WF_WorkTaskInstanceView.Status, 
      fromUser.UserName AS fromUserName, 
      dbo.WF_WorkTaskInstanceView.TaskInsDescription
FROM dbo.mUser toUser RIGHT OUTER JOIN
      dbo.WF_WorkTaskInstanceView INNER JOIN
      dbo.WF_AccreditUser ON dbo.WF_WorkTaskInstanceView.OperContent IN
          (SELECT OperContent
         FROM WF_OperContentView
         WHERE UserId = dbo.WF_AccreditUser.AccreditFromUserId) LEFT OUTER JOIN
      dbo.WF_WorkTaskView ON 
      dbo.WF_AccreditUser.AcWorkflowId = dbo.WF_WorkTaskView.WorkFlowId AND 
      dbo.WF_AccreditUser.AcWorktaskId = dbo.WF_WorkTaskView.WorkTaskId LEFT OUTER JOIN
      dbo.mUser fromUser ON 
      dbo.WF_AccreditUser.AccreditFromUserId = fromUser.UserId ON 
      toUser.UserId = dbo.WF_AccreditUser.AccreditToUserId
' 
