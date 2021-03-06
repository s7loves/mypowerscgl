USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[WF_WorkTaskModle]    脚本日期: 10/08/2011 21:31:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WF_WorkTaskModle](
	[taskControlId] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[WorkflowId] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Modu_ID] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[WorktaskId] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ControlType] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PS_WF_WorkTaskModle] PRIMARY KEY CLUSTERED 
(
	[taskControlId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流程ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_WorkTaskModle', @level2type=N'COLUMN',@level2name=N'WorkflowId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_WorkTaskModle', @level2type=N'COLUMN',@level2name=N'Modu_ID'