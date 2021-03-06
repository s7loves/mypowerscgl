USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[WF_ModleUsedFunc]    脚本日期: 10/08/2011 21:29:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WF_ModleUsedFunc](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[WorkflowId] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[WorktaskId] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Modu_ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[FunCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[FunName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[FunID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_WF_ModleUsedFunc] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流程ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleUsedFunc', @level2type=N'COLUMN',@level2name=N'WorkflowId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'节点ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleUsedFunc', @level2type=N'COLUMN',@level2name=N'WorktaskId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleUsedFunc', @level2type=N'COLUMN',@level2name=N'Modu_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleUsedFunc', @level2type=N'COLUMN',@level2name=N'FunCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleUsedFunc', @level2type=N'COLUMN',@level2name=N'FunName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleUsedFunc', @level2type=N'COLUMN',@level2name=N'FunID'