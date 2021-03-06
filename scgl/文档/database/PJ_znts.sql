USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_znts]    脚本日期: 03/14/2012 12:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_znts](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[szdx] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[sql] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[tjsql] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[xsgs] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[type] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_znts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_znts', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_znts', @level2type=N'COLUMN',@level2name=N'szdx'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_znts', @level2type=N'COLUMN',@level2name=N'sql'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条件SQL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_znts', @level2type=N'COLUMN',@level2name=N'tjsql'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示形式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_znts', @level2type=N'COLUMN',@level2name=N'xsgs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_znts', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_znts', @level2type=N'COLUMN',@level2name=N'S1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_znts', @level2type=N'COLUMN',@level2name=N'S2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_znts', @level2type=N'COLUMN',@level2name=N'S3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自定义提示' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_znts'