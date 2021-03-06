USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_xlsbzrqhfmbb]    脚本日期: 01/31/2012 17:54:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_xlsbzrqhfmbb](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[OrgCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[jsxl] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[zjxl] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[gytq] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[zytq] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[zrr] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[Creattime] [datetime] NULL,
	[S1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_xlsbzrqhfmbb] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_xlsbzrqhfmbb', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_xlsbzrqhfmbb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写单位' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_xlsbzrqhfmbb', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'局属线路' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_xlsbzrqhfmbb', @level2type=N'COLUMN', @level2name=N'jsxl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自建线路' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_xlsbzrqhfmbb', @level2type=N'COLUMN', @level2name=N'zjxl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公用台区' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_xlsbzrqhfmbb', @level2type=N'COLUMN', @level2name=N'gytq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'专业台区' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_xlsbzrqhfmbb', @level2type=N'COLUMN', @level2name=N'zytq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'责任人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_xlsbzrqhfmbb', @level2type=N'COLUMN', @level2name=N'zrr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_xlsbzrqhfmbb', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_xlsbzrqhfmbb', @level2type=N'COLUMN', @level2name=N'Creattime'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路设备责任区划分明白表' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_xlsbzrqhfmbb'
