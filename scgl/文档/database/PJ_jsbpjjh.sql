USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_jsbpjjh]    脚本日期: 12/27/2011 21:43:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_jsbpjjh](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[gzxm] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[wcsj] [datetime] NULL,
	[lsr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[dbr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[lsyq] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[S1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_jsbpjjh] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作项目' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_jsbpjjh', @level2type=N'COLUMN', @level2name=N'gzxm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'完成时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_jsbpjjh', @level2type=N'COLUMN', @level2name=N'wcsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'落实人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_jsbpjjh', @level2type=N'COLUMN', @level2name=N'lsr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'督办人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_jsbpjjh', @level2type=N'COLUMN', @level2name=N'dbr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'落实要求' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_jsbpjjh', @level2type=N'COLUMN', @level2name=N'lsyq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_jsbpjjh', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'局设备评级计划' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_jsbpjjh'
