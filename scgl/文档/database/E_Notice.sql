USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[E_Notice]    脚本日期: 09/16/2013 19:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Notice](
	[ID] [nvarchar](200) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Content] [nvarchar](500) NULL,
	[OrgID] [nvarchar](50) NULL,
	[Other] [nvarchar](50) NULL,
	[UserID] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[Sequence] [int] NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_Notice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Notice', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Notice', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机构' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Notice', @level2type=N'COLUMN',@level2name=N'OrgID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其它' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Notice', @level2type=N'COLUMN',@level2name=N'Other'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Notice', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Notice', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Notice', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Notice', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Notice', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Notice', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Notice', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Notice', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Notice', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Notice', @level2type=N'COLUMN',@level2name=N'RowVersion'