USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_bpbjjhb]    脚本日期: 12/15/2011 22:15:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_bpbjjhb](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[OrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[clmc] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[clgg] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[cldw] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[clsl] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Status] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[cfdd] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[jhnf] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zrr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[CreateDate] [datetime] NULL,
	[Remark] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_bpbjjhb] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一标识' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'材料名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb', @level2type=N'COLUMN', @level2name=N'clmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'材料规格' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb', @level2type=N'COLUMN', @level2name=N'clgg'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'材料单位' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb', @level2type=N'COLUMN', @level2name=N'cldw'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'材料数量' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb', @level2type=N'COLUMN', @level2name=N'clsl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb', @level2type=N'COLUMN', @level2name=N'Status'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存放地点' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb', @level2type=N'COLUMN', @level2name=N'cfdd'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划年份' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb', @level2type=N'COLUMN', @level2name=N'jhnf'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'责任人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb', @level2type=N'COLUMN', @level2name=N'zrr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb', @level2type=N'COLUMN', @level2name=N'S1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb', @level2type=N'COLUMN', @level2name=N'S2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb', @level2type=N'COLUMN', @level2name=N'S3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备品备件计划表' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bpbjjhb'
