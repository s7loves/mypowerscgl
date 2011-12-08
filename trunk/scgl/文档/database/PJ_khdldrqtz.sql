USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_khdldrqtz]    脚本日期: 12/08/2011 14:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_khdldrqtz](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zhm] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[hm] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[pdrl] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[drqModle] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Capcity] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sbnum] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sbsumFactory] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[tqfs] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[khVol] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[tyStatus] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Reamrk] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总户号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_khdldrqtz', @level2type=N'COLUMN', @level2name=N'zhm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'户号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_khdldrqtz', @level2type=N'COLUMN', @level2name=N'hm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配变容量（kVA）' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_khdldrqtz', @level2type=N'COLUMN', @level2name=N'pdrl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'容量' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_khdldrqtz', @level2type=N'COLUMN', @level2name=N'Capcity'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'台数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_khdldrqtz', @level2type=N'COLUMN', @level2name=N'sbnum'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总容量' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_khdldrqtz', @level2type=N'COLUMN', @level2name=N'sbsumFactory'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'投切方式' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_khdldrqtz', @level2type=N'COLUMN', @level2name=N'tqfs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户电压等级' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_khdldrqtz', @level2type=N'COLUMN', @level2name=N'khVol'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户电力电容器台帐' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_khdldrqtz'
