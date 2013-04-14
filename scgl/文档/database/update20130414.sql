--送电线路巡视相关数据表
USE [ebadascgl]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sd_xsjh]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sd_xsjh](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[LineID] [nvarchar](50) NULL,
	[LineName] [nvarchar](50) NULL,
	[vol] [nvarchar](50) NULL,
	[xslb] [nvarchar](50) NULL,
	[xsnr] [nvarchar](50) NULL,
	[sxr] [nvarchar](50) NULL,
	[jhsj] [datetime] NULL,
	[xskssj] [datetime] NULL,
	[xswcsj] [datetime] NULL,
	[wcbj] [nvarchar](50) NULL,
	[qxnr] [nvarchar](500) NULL,
	[flag] [nvarchar](50) NULL,
	[cjr] [nvarchar](50) NULL,
	[fbr] [nvarchar](50) NULL,
	[fbsj] [datetime] NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
	[c3] [nvarchar](50) NULL,
	[c4] [nvarchar](50) NULL,
	[c5] [nvarchar](50) NULL,
 CONSTRAINT [PK_SD_XSJH] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'LineID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'LineName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电压等级' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'vol'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视类别' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'xslb'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'xsnr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视人员' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'sxr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'jhsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视开始时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'xskssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视完成时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'xswcsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否完成' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'wcbj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'qxnr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务状态,新建-发布-下载-完成' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'flag'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'cjr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'fbr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'fbsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视计划' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjh'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sd_xsjhnr]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sd_xsjhnr](
	[ID] [nvarchar](50) NOT NULL,
	[ParentID] [nvarchar](50) NULL,
	[gtid] [nvarchar](50) NULL,
	[gtbh] [nvarchar](50) NULL,
	[flag1] [nvarchar](50) NULL,
	[lng] [nvarchar](50) NULL,
	[lat] [nvarchar](50) NULL,
	[flag2] [nvarchar](50) NULL,
	[xssj] [nvarchar](50) NULL,
	[qxnr] [nvarchar](50) NULL,
	[norder] [int] NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
	[c3] [nvarchar](50) NULL,
	[c4] [nvarchar](50) NULL,
	[c5] [nvarchar](50) NULL,
 CONSTRAINT [PK_SD_XSJHNR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjhnr', @level2type=N'COLUMN', @level2name=N'gtid'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'杆塔编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjhnr', @level2type=N'COLUMN', @level2name=N'gtbh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷状态' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjhnr', @level2type=N'COLUMN', @level2name=N'flag1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjhnr', @level2type=N'COLUMN', @level2name=N'lng'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纬度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjhnr', @level2type=N'COLUMN', @level2name=N'lat'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视状态' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjhnr', @level2type=N'COLUMN', @level2name=N'flag2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjhnr', @level2type=N'COLUMN', @level2name=N'xssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjhnr', @level2type=N'COLUMN', @level2name=N'qxnr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjhnr', @level2type=N'COLUMN', @level2name=N'norder'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjhnr', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjhnr', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjhnr', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjhnr', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjhnr', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'详细任务列表' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsjhnr'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sd_xsxm]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sd_xsxm](
	[ID] [nvarchar](50) NOT NULL,
	[ParentID] [nvarchar](50) NULL,
	[zl] [nvarchar](50) NULL,
	[mc] [nvarchar](50) NULL,
	[flag] [nvarchar](50) NULL,
	[xssj] [datetime] NULL,
	[norder] [int] NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
	[c3] [nvarchar](50) NULL,
 CONSTRAINT [PK_SD_XSXM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目种类' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsxm', @level2type=N'COLUMN', @level2name=N'zl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsxm', @level2type=N'COLUMN', @level2name=N'mc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视状态' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsxm', @level2type=N'COLUMN', @level2name=N'flag'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsxm', @level2type=N'COLUMN', @level2name=N'xssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsxm', @level2type=N'COLUMN', @level2name=N'norder'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsxm', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsxm', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsxm', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡检项目' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsxm'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sd_xsimage]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sd_xsimage](
	[ID] [nvarchar](50) NOT NULL,
	[ParentID] [nvarchar](50) NULL,
	[gtID] [nvarchar](50) NULL,
	[norder] [int] NULL,
	[des] [nvarchar](50) NULL,
	[data] [image] NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
 CONSTRAINT [PK_SD_XSIMAGE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsimage', @level2type=N'COLUMN', @level2name=N'ParentID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsimage', @level2type=N'COLUMN', @level2name=N'norder'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsimage', @level2type=N'COLUMN', @level2name=N'des'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'照片' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsimage', @level2type=N'COLUMN', @level2name=N'data'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsimage', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsimage', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视照片' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsimage'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sd_xsgj]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sd_xsgj](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[rwID] [nvarchar](30) NULL,
	[sj] [datetime] NULL,
	[jd] [float] NULL,
	[wd] [float] NULL,
 CONSTRAINT [PK_SD_XSGJ] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[sd_xsgj]') AND name = N'Index_1')
CREATE NONCLUSTERED INDEX [Index_1] ON [dbo].[sd_xsgj] 
(
	[rwID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsgj', @level2type=N'COLUMN', @level2name=N'rwID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsgj', @level2type=N'COLUMN', @level2name=N'sj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsgj', @level2type=N'COLUMN', @level2name=N'jd'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纬度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsgj', @level2type=N'COLUMN', @level2name=N'wd'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视轨迹' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsgj'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sd_xsqxbzk]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sd_xsqxbzk](
	[ID] [nvarchar](50) NOT NULL,
	[norder] [int] NULL,
	[sbzl] [nvarchar](50) NULL,
	[qxzl] [nvarchar](50) NULL,
	[qxnr] [nvarchar](150) NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
 CONSTRAINT [PK_SD_XSQXBZK] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsqxbzk', @level2type=N'COLUMN', @level2name=N'norder'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备种类' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsqxbzk', @level2type=N'COLUMN', @level2name=N'sbzl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷种类' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsqxbzk', @level2type=N'COLUMN', @level2name=N'qxzl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsqxbzk', @level2type=N'COLUMN', @level2name=N'qxnr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷标准库' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xsqxbzk'

