USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_bdsdldrqtz]    脚本日期: 12/21/2011 22:17:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_bdsdldrqtz](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[OrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zzdz] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[drqModle] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[edVol] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Capcity] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sbnum] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sbFactory] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[tqfs] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[inDate] [datetime] NULL,
	[Remark] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_bdsdldrqtz] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变电所' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bdsdldrqtz', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装置地点' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bdsdldrqtz', @level2type=N'COLUMN', @level2name=N'zzdz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电容器型号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bdsdldrqtz', @level2type=N'COLUMN', @level2name=N'drqModle'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'额定电压' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bdsdldrqtz', @level2type=N'COLUMN', @level2name=N'edVol'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'容量' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bdsdldrqtz', @level2type=N'COLUMN', @level2name=N'Capcity'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'台数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bdsdldrqtz', @level2type=N'COLUMN', @level2name=N'sbnum'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制造厂' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bdsdldrqtz', @level2type=N'COLUMN', @level2name=N'sbFactory'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'投切方式' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bdsdldrqtz', @level2type=N'COLUMN', @level2name=N'tqfs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'投运日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bdsdldrqtz', @level2type=N'COLUMN', @level2name=N'inDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bdsdldrqtz', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变电所电力电容器台帐' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_bdsdldrqtz'
