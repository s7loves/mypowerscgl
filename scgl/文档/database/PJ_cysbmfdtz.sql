USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_cysbmfdtz]    脚本日期: 12/08/2011 17:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_cysbmfdtz](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[OrgCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sbmc] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[InstallPlace] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sbModle] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sbCapcity] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[cysbmc] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[cysbFactory] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[inDate] [datetime] NULL,
	[changeDate] [datetime] NULL,
	[mfStatus] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[jcr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[jcDate] [datetime] NULL,
	[remark] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[S1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_cysbmfdtz] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cysbmfdtz', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cysbmfdtz', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cysbmfdtz', @level2type=N'COLUMN', @level2name=N'sbmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'安装地点' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cysbmfdtz', @level2type=N'COLUMN', @level2name=N'InstallPlace'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'型号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cysbmfdtz', @level2type=N'COLUMN', @level2name=N'sbModle'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'容量' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cysbmfdtz', @level2type=N'COLUMN', @level2name=N'sbCapcity'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'充油部件名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cysbmfdtz', @level2type=N'COLUMN', @level2name=N'cysbmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装设日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cysbmfdtz', @level2type=N'COLUMN', @level2name=N'inDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下次更换日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cysbmfdtz', @level2type=N'COLUMN', @level2name=N'changeDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密封点状况' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cysbmfdtz', @level2type=N'COLUMN', @level2name=N'mfStatus'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检查人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cysbmfdtz', @level2type=N'COLUMN', @level2name=N'jcr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检查日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cysbmfdtz', @level2type=N'COLUMN', @level2name=N'jcDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cysbmfdtz', @level2type=N'COLUMN', @level2name=N'remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'充油设备密封点台帐' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_cysbmfdtz'
