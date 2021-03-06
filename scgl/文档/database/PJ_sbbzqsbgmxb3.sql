USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_sbbzqsbgmxb3]    脚本日期: 12/25/2011 15:05:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_sbbzqsbgmxb3](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[OrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sssbmc] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[sssswz] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[sssbbh] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[statuts] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[S1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_sbbzqsbgmxb3] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一标识' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbbzqsbgmxb3', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbbzqsbgmxb3', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbbzqsbgmxb3', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属设备名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbbzqsbgmxb3', @level2type=N'COLUMN', @level2name=N'sssbmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属设备位置' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbbzqsbgmxb3', @level2type=N'COLUMN', @level2name=N'sssswz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属设备编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbbzqsbgmxb3', @level2type=N'COLUMN', @level2name=N'sssbbh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbbzqsbgmxb3', @level2type=N'COLUMN', @level2name=N'statuts'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbbzqsbgmxb3', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备标志缺失变更明细表三（警告牌）' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbbzqsbgmxb3'
