USE [EbadaScgl]
GO

/****** Object:  Table [dbo].[PS_kgjctj]    Script Date: 12/06/2012 12:16:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PS_kgjctj](
	[ID] [nvarchar](50) NOT NULL,
	[kgID] [nvarchar](50) NULL,
	[OrgCode] [nvarchar](50) NULL,
	[OrgName] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[pdcxmc] [nvarchar](50) NULL,
	[xdfw] [nvarchar](50) NULL,
	[kgModel] [nvarchar](50) NULL,
	[iscxkg] [bit] NULL,
	[kgCode] [nvarchar](50) NULL,
	[jkdxcd] [nvarchar](50) NULL,
	[dlxlcd] [nvarchar](50) NULL,
	[publicusercount] [int] NULL,
	[publicbtcount] [int] NULL,
	[publicbtrlcount] [int] NULL,
	[zyusercount] [int] NULL,
	[zybtcount] [int] NULL,
	[zybtrlcount] [int] NULL,
	[sdyusercount] [int] NULL,
	[sdyrlcount] [int] NULL,
	[zyuserqtsbcount] [int] NULL,
	[drqcount] [int] NULL,
	[drqrl] [nvarchar](50) NULL,
	[zyuserqtsbrlcount] [int] NULL,
 CONSTRAINT [PK_PS_kgjctj_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开关ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'kgID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备管理单位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'OrgCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备管理单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'OrgName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统计日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配电出线名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'pdcxmc'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线段范围' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'xdfw'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开关型号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'kgModel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否出线开关' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'iscxkg'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开关编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'kgCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'架空导线长度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'jkdxcd'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电缆线路长度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'dlxlcd'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公用用户数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'publicusercount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公用变台数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'publicbtcount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公用变台总容量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'publicbtrlcount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'专用用户数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'zyusercount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'专用变台数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'zybtcount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'专用变台总容量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'zybtrlcount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'双电源用户数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'sdyusercount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'双电源容量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'sdyrlcount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'专用户其它设备台数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'zyuserqtsbcount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电容器台数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'drqcount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电容器容量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'drqrl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'专用户其它设备容量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_kgjctj', @level2type=N'COLUMN',@level2name=N'zyuserqtsbrlcount'
GO


