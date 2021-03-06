USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[WF_ModleRecordWorkTaskIns]    脚本日期: 10/23/2011 11:54:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WF_ModleRecordWorkTaskIns](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[RecordID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ModleRecordID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ModleTableName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[WorkFlowId] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[WorkFlowInsId] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[WorkTaskId] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[WorkTaskInsId] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[CreatTime] [datetime] NULL,
 CONSTRAINT [PK_WF_ModleRecordWorkTaskIns] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'票记录ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleRecordWorkTaskIns', @level2type=N'COLUMN',@level2name=N'RecordID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块记录ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleRecordWorkTaskIns', @level2type=N'COLUMN',@level2name=N'ModleRecordID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块记录的名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleRecordWorkTaskIns', @level2type=N'COLUMN',@level2name=N'ModleTableName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作流名称ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleRecordWorkTaskIns', @level2type=N'COLUMN',@level2name=N'WorkFlowId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作流实例ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleRecordWorkTaskIns', @level2type=N'COLUMN',@level2name=N'WorkFlowInsId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作流节点ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleRecordWorkTaskIns', @level2type=N'COLUMN',@level2name=N'WorkTaskId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作流节点实例ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleRecordWorkTaskIns', @level2type=N'COLUMN',@level2name=N'WorkTaskInsId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_ModleRecordWorkTaskIns', @level2type=N'COLUMN',@level2name=N'CreatTime'