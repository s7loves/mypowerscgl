USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_sbxsqd]    脚本日期: 07/19/2011 10:32:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_sbxsqd](
	[LineCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[XsqdName] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[XSR1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[XSR2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
 CONSTRAINT [PK_PJ_sbxsqd] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_sbxsqd', @level2type=N'COLUMN',@level2name=N'LineCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视区段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_sbxsqd', @level2type=N'COLUMN',@level2name=N'XsqdName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视人1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_sbxsqd', @level2type=N'COLUMN',@level2name=N'XSR1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视人2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_sbxsqd', @level2type=N'COLUMN',@level2name=N'XSR2'