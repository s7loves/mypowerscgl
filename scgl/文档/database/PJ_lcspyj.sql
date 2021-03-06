USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_lcspyj]    脚本日期: 10/05/2011 21:10:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_lcspyj](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[RecordID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[taskID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Spyj] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[Creattime] [datetime] NULL,
	[Charman] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Reserve1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_lcspyj] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写审批意见的流程节点ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_lcspyj', @level2type=N'COLUMN',@level2name=N'taskID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审批意见' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_lcspyj', @level2type=N'COLUMN',@level2name=N'Spyj'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审批时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_lcspyj', @level2type=N'COLUMN',@level2name=N'Creattime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_lcspyj', @level2type=N'COLUMN',@level2name=N'Reserve1'