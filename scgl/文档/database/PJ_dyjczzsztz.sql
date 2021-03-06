USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_dyjczzsztz]    脚本日期: 12/21/2011 22:18:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_dyjczzsztz](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[OrgCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zzszwz] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[zzVol] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zzdlb] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zzxh] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zzFactory] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[jddate] [datetime] NULL,
	[zdz] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[cjfs] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_dyjczzsztz] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_dyjczzsztz', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_dyjczzsztz', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_dyjczzsztz', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电压监测装置设置位置' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_dyjczzsztz', @level2type=N'COLUMN', @level2name=N'zzszwz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'监测电压（KV）' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_dyjczzsztz', @level2type=N'COLUMN', @level2name=N'zzVol'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'监测点类别' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_dyjczzsztz', @level2type=N'COLUMN', @level2name=N'zzdlb'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电压监测装置型号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_dyjczzsztz', @level2type=N'COLUMN', @level2name=N'zzxh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制造厂' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_dyjczzsztz', @level2type=N'COLUMN', @level2name=N'zzFactory'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检定日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_dyjczzsztz', @level2type=N'COLUMN', @level2name=N'jddate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'整定值' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_dyjczzsztz', @level2type=N'COLUMN', @level2name=N'zdz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采集方式' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_dyjczzsztz', @level2type=N'COLUMN', @level2name=N'cjfs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_dyjczzsztz', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电压监测装置设置台帐' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_dyjczzsztz'
