USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_yfsyjl]    脚本日期: 09/20/2011 15:36:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_yfsyjl](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[xh] [int] NULL,
	[type] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sbInstallAdress] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sbModle] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sbCapacity] [int] NULL,
	[sl] [int] NULL,
	[syProject] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[syPeriod] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[preExpTime] [datetime] NULL,
	[planExpTime] [datetime] NULL,
	[sjExpTime] [datetime] NULL,
	[gzrjID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[iswc] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[syjg] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[charMan] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[syMan] [nchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[CreateDate] [datetime] NULL,
	[Remark] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[wcRemark] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_yfsyjl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'xh'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'试验类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备安装位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'sbInstallAdress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'OrgCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'OrgName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备型号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'sbModle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备容量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'sbCapacity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'sl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'试验项目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'syProject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'试验周期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'syPeriod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次试验时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'preExpTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划试验时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'planExpTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'完成试验时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'sjExpTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'gzrjID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否完成' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'iswc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实验结果' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'syjg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'落实人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'charMan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实验人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'syMan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyjl', @level2type=N'COLUMN',@level2name=N'wcRemark'