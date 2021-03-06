USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_cqcssqk]    脚本日期: 01/02/2012 21:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_cqcssqk](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[OrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[jclx] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ssrq] [datetime] NULL,
	[kzlr] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[zcr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[cjr] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[js] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[S1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_cqcssqk] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cqcssqk', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cqcssqk', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cqcssqk', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检查类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cqcssqk', @level2type=N'COLUMN', @level2name=N'jclx'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实施日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cqcssqk', @level2type=N'COLUMN', @level2name=N'ssrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开展内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cqcssqk', @level2type=N'COLUMN', @level2name=N'kzlr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主持人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cqcssqk', @level2type=N'COLUMN', @level2name=N'zcr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参加人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cqcssqk', @level2type=N'COLUMN', @level2name=N'cjr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记事' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cqcssqk', @level2type=N'COLUMN', @level2name=N'js'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所春秋查实施情况记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cqcssqk'
