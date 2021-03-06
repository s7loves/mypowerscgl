USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[WF_ModleCheckTable]    脚本日期: 10/11/2011 17:00:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WF_ModleCheckTable](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[RecordId] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[WorkFlowId] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[WorkFlowInsId] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[WorkTaskId] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[WorkTaskInsId] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[DocContent] [image] NULL,
	[Creattime] [datetime] NULL,
 CONSTRAINT [PK_WF_ModleCheckTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleCheckTable', @level2type=N'COLUMN',@level2name=N'RecordId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流程ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleCheckTable', @level2type=N'COLUMN',@level2name=N'WorkFlowId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流程实例ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleCheckTable', @level2type=N'COLUMN',@level2name=N'WorkFlowInsId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'节点ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleCheckTable', @level2type=N'COLUMN',@level2name=N'WorkTaskId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'节点实例ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleCheckTable', @level2type=N'COLUMN',@level2name=N'WorkTaskInsId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前节点的内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleCheckTable', @level2type=N'COLUMN',@level2name=N'DocContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleCheckTable', @level2type=N'COLUMN',@level2name=N'Creattime'