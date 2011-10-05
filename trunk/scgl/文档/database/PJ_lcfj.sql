USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_lcfj]    脚本日期: 10/05/2011 21:04:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_lcfj](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[RecordID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Filename] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[FileSize] [bigint] NULL,
	[FileRelativePath] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[Creattime] [datetime] NULL,
 CONSTRAINT [PK_PJ_lcfj] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_lcfj', @level2type=N'COLUMN',@level2name=N'Creattime'