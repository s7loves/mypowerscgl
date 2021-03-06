USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_lcfxwtjzgls]    脚本日期: 01/02/2012 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_lcfxwtjzgls](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[OrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[jclx] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ccwt] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[zgcs] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[jhwcsj] [datetime] NULL,
	[lszgsj] [datetime] NULL,
	[lsqk] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[lsr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[dbr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[S1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_lcfxwt] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfxwtjzgls', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfxwtjzgls', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfxwtjzgls', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检查类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfxwtjzgls', @level2type=N'COLUMN', @level2name=N'jclx'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查出的问题' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfxwtjzgls', @level2type=N'COLUMN', @level2name=N'ccwt'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'整改措施' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfxwtjzgls', @level2type=N'COLUMN', @level2name=N'zgcs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划完成时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfxwtjzgls', @level2type=N'COLUMN', @level2name=N'jhwcsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'落实整改时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfxwtjzgls', @level2type=N'COLUMN', @level2name=N'lszgsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'落实情况' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfxwtjzgls', @level2type=N'COLUMN', @level2name=N'lsqk'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'落实人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfxwtjzgls', @level2type=N'COLUMN', @level2name=N'lsr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'督办人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfxwtjzgls', @level2type=N'COLUMN', @level2name=N'dbr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfxwtjzgls', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'春秋查内查发现问题及整改落实情况记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfxwtjzgls'
