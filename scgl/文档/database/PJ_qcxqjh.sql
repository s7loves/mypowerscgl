USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_qcxqjh]    脚本日期: 01/01/2012 16:13:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_qcxqjh](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[OrgCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[xqlr] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[xqbz] [nvarchar](1000) COLLATE Chinese_PRC_CI_AS NULL,
	[qxlb] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[wcsj] [datetime] NULL,
	[lsr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_qcxqjh] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_qcxqjh', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_qcxqjh', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_qcxqjh', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消缺工作内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_qcxqjh', @level2type=N'COLUMN', @level2name=N'xqlr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'措施、步骤及要求' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_qcxqjh', @level2type=N'COLUMN', @level2name=N'xqbz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷类别' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_qcxqjh', @level2type=N'COLUMN', @level2name=N'qxlb'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'完成时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_qcxqjh', @level2type=N'COLUMN', @level2name=N'wcsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'落实人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_qcxqjh', @level2type=N'COLUMN', @level2name=N'lsr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_qcxqjh', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所秋查消缺计划' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_qcxqjh'
