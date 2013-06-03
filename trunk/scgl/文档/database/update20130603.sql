USE [ebadascgl]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_21]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_21](
	[ID] [nvarchar](50) NOT NULL,
	[ParentID] [nvarchar](50) NULL,
	[OrgCode] [nvarchar](50) NULL,
	[OrgName] [nvarchar](50) NULL,
	[LineCode] [nvarchar](50) NULL,
	[LineName] [nvarchar](50) NULL,
	[Remark] [nvarchar](50) NULL,
	[gzrjID] [nvarchar](50) NULL,
	[CreateMan] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[BigData] [image] NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_17] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ParentID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21', @level2type=N'COLUMN', @level2name=N'ParentID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21', @level2type=N'COLUMN', @level2name=N'LineCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21', @level2type=N'COLUMN', @level2name=N'LineName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gzrjID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21', @level2type=N'COLUMN', @level2name=N'gzrjID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作员' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生成日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生成文档' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21', @level2type=N'COLUMN', @level2name=N'BigData'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电线路条图' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_21'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_02aqhd]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_02aqhd](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[OrgName] [nvarchar](50) NULL,
	[zcr] [nvarchar](50) NULL,
	[kssj] [datetime] NULL,
	[jssj] [datetime] NULL,
	[hydd] [nvarchar](50) NULL,
	[cjry] [nvarchar](500) NULL,
	[qxry] [nvarchar](150) NULL,
	[hdnr] [nvarchar](4000) NULL,
	[hdxj] [nvarchar](4000) NULL,
	[fyjyjl] [nvarchar](4000) NULL,
	[py] [nvarchar](500) NULL,
	[qz] [nvarchar](50) NULL,
	[qzrq] [datetime] NULL,
	[gznrID] [nvarchar](50) NULL,
	[CreateMan] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_02AQHD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主持人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'zcr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'kssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'jssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会议地点' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'hydd'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参加人员' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'cjry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺席人员' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'qxry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'hdnr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动小结' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'hdxj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发言简要记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'fyjyjl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评语' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'py'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签字' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'qz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签字日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'qzrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gznrID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'gznrID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电安全活动记录 ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_02aqhd'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_gzrjnr]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_gzrjnr](
	[gznrID] [nvarchar](50) NOT NULL,
	[gzrjID] [nvarchar](50) NULL,
	[fssj] [datetime] NULL,
	[seq] [int] NULL,
	[gznr] [nvarchar](500) NULL,
	[fzr] [nvarchar](50) NULL,
	[cjry] [nvarchar](200) NULL,
	[ParentID] [nvarchar](50) NULL,
	[CreateMan] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_GZRJNR] PRIMARY KEY CLUSTERED 
(
	[gznrID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gzrjnr', @level2type=N'COLUMN', @level2name=N'gznrID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作日记ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gzrjnr', @level2type=N'COLUMN', @level2name=N'gzrjID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发生时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gzrjnr', @level2type=N'COLUMN', @level2name=N'fssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gzrjnr', @level2type=N'COLUMN', @level2name=N'seq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gzrjnr', @level2type=N'COLUMN', @level2name=N'gznr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'负责人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gzrjnr', @level2type=N'COLUMN', @level2name=N'fzr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参加人员' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gzrjnr', @level2type=N'COLUMN', @level2name=N'cjry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gzrjnr', @level2type=N'COLUMN', @level2name=N'ParentID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gzrjnr', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gzrjnr', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gzrjnr', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gzrjnr', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gzrjnr', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gzrjnr', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gzrjnr', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电工作内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gzrjnr'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_01gzrj]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_01gzrj](
	[gzrjID] [nvarchar](50) NOT NULL,
	[GdsCode] [nvarchar](50) NULL,
	[GdsName] [nvarchar](50) NULL,
	[rq] [datetime] NULL,
	[xq] [nvarchar](50) NULL,
	[tq] [nvarchar](50) NULL,
	[qqry] [nvarchar](500) NULL,
	[rsaqts] [int] NULL,
	[sbaqts] [int] NULL,
	[js] [nvarchar](500) NULL,
	[py] [nvarchar](500) NULL,
	[qz] [nvarchar](50) NULL,
	[qzrq] [datetime] NULL,
	[CreateMan] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_01GZRJ] PRIMARY KEY CLUSTERED 
(
	[gzrjID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'gzrjID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'GdsCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'GdsName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'rq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'星期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'xq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'天气' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'tq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺勤情况' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'qqry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人身安全天数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'rsaqts'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备安全天数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'sbaqts'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记事' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'js'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评语' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'py'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签字' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'qz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签字日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'qzrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电01工作日记' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_01gzrj'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_04sgzayc]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_04sgzayc](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[OrgName] [nvarchar](50) NULL,
	[fsdd] [nvarchar](150) NULL,
	[tdsj] [datetime] NULL,
	[sdsj] [datetime] NULL,
	[gtdsj] [nvarchar](50) NULL,
	[ssdl] [decimal](8, 0) NULL,
	[clqk] [nvarchar](4000) NULL,
	[yyfx] [nvarchar](4000) NULL,
	[fzdc] [nvarchar](500) NULL,
	[zxr] [nvarchar](50) NULL,
	[CreateMan] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[gznrID] [nvarchar](50) NULL,
	[charMan] [nvarchar](50) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_04SGZAYC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发生地点' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'fsdd'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停电时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'tdsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'sdsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'共停电时间（时分）' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'gtdsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'损失电量' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'ssdl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事故情况及处理经过' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'clqk'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主要原因分析' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'yyfx'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'今后防止对策' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'fzdc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'防止对策执行人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'zxr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gznrID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'gznrID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'charMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电事故障碍异常记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_04sgzayc'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_05jcky]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_05jcky](
	[jckyID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[OrgName] [nvarchar](50) NULL,
	[LineID] [nvarchar](50) NULL,
	[gtID] [nvarchar](50) NULL,
	[kywz] [nvarchar](50) NULL,
	[kygh] [nvarchar](50) NULL,
	[kymc] [nvarchar](50) NULL,
	[ssdw] [nvarchar](50) NULL,
	[jb] [nvarchar](50) NULL,
	[gdjl] [decimal](5, 1) NULL,
	[CreateMan] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_05JCKY] PRIMARY KEY CLUSTERED 
(
	[jckyID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'jckyID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'LineID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'杆塔ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'gtID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交叉跨越位置' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'kywz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'跨越杆号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'kygh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'被跨越物名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'kymc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属单位' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'ssdw'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'级别' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'jb'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规定距离不小于' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'gdjl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电交叉跨越' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jcky'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_05jckyjl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_05jckyjl](
	[ID] [nvarchar](50) NOT NULL,
	[jckyID] [nvarchar](50) NULL,
	[clrq] [datetime] NULL,
	[scz] [decimal](5, 1) NULL,
	[qw] [nvarchar](50) NULL,
	[clrqz] [nvarchar](50) NULL,
	[jr] [nvarchar](50) NULL,
	[CreateMan] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[gzrjID] [nvarchar](50) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
	[xlid] [nvarchar](50) NULL,
	[byqid] [nvarchar](50) NULL,
	[tqid] [nvarchar](50) NULL,
	[kgid] [nvarchar](50) NULL,
	[xlname] [nvarchar](50) NULL,
	[byqname] [nvarchar](50) NULL,
	[tqname] [nvarchar](50) NULL,
	[kgname] [nvarchar](50) NULL,
	[gdstemp] [nvarchar](50) NULL,
	[linetemp] [nvarchar](50) NULL,
	[othertemp] [nvarchar](50) NULL,
 CONSTRAINT [PK_SDJL_05JCKYJL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交叉跨越ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'jckyID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'测量日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'clrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实测值' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'scz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'气温' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'qw'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'测量人签字' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'clrqz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结论' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'jr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gzrjID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'gzrjID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'xlid'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变压器ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'byqid'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'天气ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'tqid'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开关ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'kgid'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'xlname'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变压器' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'byqname'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'台区' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'tqname'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开关' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'kgname'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所临时' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'gdstemp'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路临时' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'linetemp'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他临时' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl', @level2type=N'COLUMN', @level2name=N'othertemp'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交叉跨越及对地距离测量记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_05jckyjl'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_06sbxs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_06sbxs](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[OrgName] [nvarchar](50) NULL,
	[LineID] [nvarchar](50) NULL,
	[LineName] [nvarchar](50) NULL,
	[xlqd] [nvarchar](50) NULL,
	[xssj] [datetime] NULL,
	[xsr] [nvarchar](50) NULL,
	[qxnr] [nvarchar](500) NULL,
	[qxlb] [nvarchar](50) NULL,
	[xcr] [nvarchar](50) NULL,
	[xcrq] [datetime] NULL,
	[CreateMan] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[gzrjID] [nvarchar](50) NULL,
	[xcqx] [nvarchar](50) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_06SBXS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'LineID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'LineName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视区段' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'xlqd'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'xssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'xsr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'qxnr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷类别' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'qxlb'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消除人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'xcr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消除日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'xcrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gzrjID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'gzrjID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消缺期限' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'xcqx'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电设备巡视及缺陷消除记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxs'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_dyk]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_dyk](
	[ID] [nvarchar](50) NOT NULL,
	[ParentID] [nvarchar](50) NULL,
	[dx] [nvarchar](50) NULL,
	[sx] [nvarchar](50) NULL,
	[bh] [nvarchar](50) NULL,
	[zjm] [nvarchar](50) NULL,
	[nr4] [nvarchar](2000) NULL,
	[nr] [nvarchar](2000) NULL,
	[nr2] [nvarchar](2000) NULL,
	[nr3] [nvarchar](2000) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_DYK] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_dyk', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ParentID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_dyk', @level2type=N'COLUMN', @level2name=N'ParentID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对象' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_dyk', @level2type=N'COLUMN', @level2name=N'dx'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属性' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_dyk', @level2type=N'COLUMN', @level2name=N'sx'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'短语编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_dyk', @level2type=N'COLUMN', @level2name=N'bh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'助记码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_dyk', @level2type=N'COLUMN', @level2name=N'zjm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'短语内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_dyk', @level2type=N'COLUMN', @level2name=N'nr4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'短语内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_dyk', @level2type=N'COLUMN', @level2name=N'nr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'短语内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_dyk', @level2type=N'COLUMN', @level2name=N'nr2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'短语内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_dyk', @level2type=N'COLUMN', @level2name=N'nr3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_dyk', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_dyk', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_dyk', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_dyk', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_dyk', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维护记录相关的短语库，为了提高录入效率' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_dyk'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_06sbxsmx]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_06sbxsmx](
	[ID] [nvarchar](50) NOT NULL,
	[ParentID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[OrgName] [nvarchar](50) NULL,
	[LineID] [nvarchar](50) NULL,
	[LineName] [nvarchar](50) NULL,
	[xlqd] [nvarchar](50) NULL,
	[xssj] [datetime] NULL,
	[xsr] [nvarchar](50) NULL,
	[qxnr] [nvarchar](500) NULL,
	[qxlb] [nvarchar](50) NULL,
	[xcr] [nvarchar](50) NULL,
	[xcrq] [datetime] NULL,
	[CreateMan] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[gzrjID] [nvarchar](50) NULL,
	[xcqx] [nvarchar](50) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
	[xlid] [nvarchar](50) NULL,
	[byqid] [nvarchar](50) NULL,
	[tqid] [nvarchar](50) NULL,
	[kgid] [nvarchar](50) NULL,
	[xlname] [nvarchar](50) NULL,
	[byqname] [nvarchar](50) NULL,
	[tqname] [nvarchar](50) NULL,
	[kgname] [nvarchar](50) NULL,
	[gdstemp] [nvarchar](50) NULL,
	[linetemp] [nvarchar](50) NULL,
	[othertemp] [nvarchar](50) NULL,
 CONSTRAINT [PK_SDJL_06SBXSMX] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ParentID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'ParentID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'LineID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'LineName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视区段' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'xlqd'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'xssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'xsr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'qxnr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷类别' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'qxlb'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消除人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'xcr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消除日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'xcrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gzrjID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'gzrjID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消缺期限' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'xcqx'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'xlid'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变压器ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'byqid'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'天气ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'tqid'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开关ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'kgid'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'xlname'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变压器' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'byqname'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'台区' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'tqname'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开关' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'kgname'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所临时' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'gdstemp'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路临时 ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'linetemp'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他临时' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx', @level2type=N'COLUMN', @level2name=N'othertemp'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备巡视及缺陷消除记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_06sbxsmx'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_14aqgjsy]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_14aqgjsy](
	[ID] [nvarchar](50) NOT NULL,
	[sbID] [nvarchar](50) NULL,
	[OrgCode] [nvarchar](50) NULL,
	[OrgName] [nvarchar](50) NULL,
	[rq] [datetime] NULL,
	[jr] [nvarchar](250) NULL,
	[sjr] [nvarchar](10) NULL,
	[syr] [nvarchar](10) NULL,
	[ajqz] [nvarchar](50) NULL,
	[xcsyrq] [datetime] NULL,
	[gznrID] [nvarchar](50) NULL,
	[CreateMan] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_14AQGJSY] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'sbID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'rq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结 论' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'jr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送检人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'sjr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'试验人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'syr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'安监签字' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'ajqz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下次试验日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'xcsyrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gznrID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'gznrID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电安全工器具检查试记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_14aqgjsy'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_07jdzz]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_07jdzz](
	[jdzzID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[OrgName] [nvarchar](50) NULL,
	[LineID] [nvarchar](50) NULL,
	[LineName] [nvarchar](50) NULL,
	[gth] [nvarchar](50) NULL,
	[gzwz] [nvarchar](50) NULL,
	[sbmc] [nvarchar](50) NULL,
	[xhgg] [nvarchar](50) NULL,
	[jddz] [decimal](5, 2) NULL,
	[tz] [nvarchar](500) NULL,
	[trdzr] [decimal](5, 2) NULL,
	[CreateMan] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[sbID] [nvarchar](50) NULL,
	[fzxl] [nvarchar](50) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_07JDZZ] PRIMARY KEY CLUSTERED 
(
	[jdzzID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'jdzzID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'LineID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'LineName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'杆号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'gth'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'安装位置' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'gzwz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保护设备名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'sbmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'型号规格' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'xhgg'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接地电阻不大于(Ω)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'jddz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'土质' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'tz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'土壤电阻率(Ω.m)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'trdzr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联设备ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'sbID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分支线路' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'fzxl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电接地装置' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzz'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_07jdzzjl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_07jdzzjl](
	[ID] [nvarchar](50) NOT NULL,
	[jdzzID] [nvarchar](50) NULL,
	[clrq] [datetime] NULL,
	[tq] [nvarchar](50) NULL,
	[scz] [decimal](5, 2) NULL,
	[hsz] [decimal](5, 2) NULL,
	[jcqk] [nvarchar](50) NULL,
	[jr] [nvarchar](50) NULL,
	[jcr] [nvarchar](10) NULL,
	[CreateMan] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[gzrjID] [nvarchar](50) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
	[xlid] [nvarchar](50) NULL,
	[byqid] [nvarchar](50) NULL,
	[tqid] [nvarchar](50) NULL,
	[kgid] [nvarchar](50) NULL,
	[xlname] [nvarchar](50) NULL,
	[byqname] [nvarchar](50) NULL,
	[tqname] [nvarchar](50) NULL,
	[kgname] [nvarchar](50) NULL,
	[gdstemp] [nvarchar](50) NULL,
	[linetemp] [nvarchar](50) NULL,
	[othertemp] [nvarchar](50) NULL,
 CONSTRAINT [PK_SDJL_07JDZZJL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接地装置ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'jdzzID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'测量日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'clrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'天气' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'tq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实测值' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'scz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'换算值' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'hsz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检测情况' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'jcqk'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结论' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'jr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检测人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'jcr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gzrjID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'gzrjID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'xlid'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变压器ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'byqid'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'台区ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'tqid'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开关ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'kgid'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'xlname'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变压器' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'byqname'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'台区' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'tqname'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开关' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'kgname'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所临时' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'gdstemp'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'临时线路' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'linetemp'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他临时' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl', @level2type=N'COLUMN', @level2name=N'othertemp'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电地装置检测记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_07jdzzjl'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_aqgj]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_aqgj](
	[sbID] [nvarchar](50) NOT NULL,
	[OrgID] [nvarchar](50) NULL,
	[sbCode] [nvarchar](50) NULL,
	[sbName] [nvarchar](50) NULL,
	[syzq] [nvarchar](50) NULL,
	[syxm] [nvarchar](50) NULL,
	[syrq] [datetime] NULL,
	[syrq2] [datetime] NULL,
	[sbType] [nvarchar](50) NULL,
	[sbModle] [nvarchar](50) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_AQGJ] PRIMARY KEY CLUSTERED 
(
	[sbID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_aqgj', @level2type=N'COLUMN', @level2name=N'sbID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_aqgj', @level2type=N'COLUMN', @level2name=N'OrgID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_aqgj', @level2type=N'COLUMN', @level2name=N'sbCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_aqgj', @level2type=N'COLUMN', @level2name=N'sbName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'试验周期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_aqgj', @level2type=N'COLUMN', @level2name=N'syzq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'试验项目' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_aqgj', @level2type=N'COLUMN', @level2name=N'syxm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'试验日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_aqgj', @level2type=N'COLUMN', @level2name=N'syrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下次试验日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_aqgj', @level2type=N'COLUMN', @level2name=N'syrq2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备种类' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_aqgj', @level2type=N'COLUMN', @level2name=N'sbType'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备型号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_aqgj', @level2type=N'COLUMN', @level2name=N'sbModle'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_aqgj', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_aqgj', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_aqgj', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_aqgj', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_aqgj', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电安全工器具' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_aqgj'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_gjyb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_gjyb](
	[sbID] [nvarchar](50) NOT NULL,
	[OrgID] [nvarchar](50) NULL,
	[sbCode] [nvarchar](50) NULL,
	[sbName] [nvarchar](50) NULL,
	[jdgg] [nvarchar](50) NULL,
	[dw] [nvarchar](50) NULL,
	[sl] [int] NULL,
	[cj] [nvarchar](50) NULL,
	[lqsj] [datetime] NULL,
	[Remark] [nvarchar](50) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_GJYB] PRIMARY KEY CLUSTERED 
(
	[sbID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gjyb', @level2type=N'COLUMN', @level2name=N'sbID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gjyb', @level2type=N'COLUMN', @level2name=N'OrgID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gjyb', @level2type=N'COLUMN', @level2name=N'sbCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gjyb', @level2type=N'COLUMN', @level2name=N'sbName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规格精度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gjyb', @level2type=N'COLUMN', @level2name=N'jdgg'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gjyb', @level2type=N'COLUMN', @level2name=N'dw'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gjyb', @level2type=N'COLUMN', @level2name=N'sl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制造厂家' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gjyb', @level2type=N'COLUMN', @level2name=N'cj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领取时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gjyb', @level2type=N'COLUMN', @level2name=N'lqsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gjyb', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gjyb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gjyb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gjyb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gjyb', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gjyb', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电力安全工器具、仪表' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_gjyb'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_23]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_23](
	[ID] [nvarchar](50) NOT NULL,
	[ParentID] [nvarchar](50) NULL,
	[cqfw] [nvarchar](250) NULL,
	[cqdw] [nvarchar](50) NULL,
	[qdrq] [datetime] NULL,
	[Remark] [nvarchar](50) NULL,
	[gzrjID] [nvarchar](50) NULL,
	[CreateMan] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[BigData] [image] NULL,
	[qxydd] [nvarchar](50) NULL,
	[xybh] [nvarchar](50) NULL,
	[linename] [nvarchar](50) NULL,
	[fzlinename] [nvarchar](50) NULL,
	[gh] [nvarchar](50) NULL,
	[jf] [nvarchar](50) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_23] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ParentID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'ParentID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产权范围' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'cqfw'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产权单位' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'cqdw'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签订日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'qdrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gzrjID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'gzrjID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作员' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生成日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生成文档' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'BigData'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签协议地点' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'qxydd'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'协议编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'xybh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'linename'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分支' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'fzlinename'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'杆号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'gh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'甲方' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'jf'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电力设备产权、维护范围协议书' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_23'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_26]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_26](
	[ID] [nvarchar](50) NOT NULL,
	[ParentID] [nvarchar](50) NULL,
	[tzdw] [nvarchar](50) NULL,
	[tzrq] [datetime] NULL,
	[Remark] [nvarchar](50) NULL,
	[gzrjID] [nvarchar](50) NULL,
	[CreateMan] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[BigData] [image] NULL,
	[xybh] [nvarchar](50) NULL,
	[lineVol] [nvarchar](50) NULL,
	[fxwt] [nvarchar](50) NULL,
	[clcs] [nvarchar](50) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_26] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ParentID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'ParentID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通知单位' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'tzdw'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通知日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'tzrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gzrjID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'gzrjID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作员' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生成日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生成文档' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'BigData'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'协议编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'xybh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路电压' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'lineVol'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发现问题' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'fxwt'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理措施' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'clcs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电电力线路防护通知书' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_26'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_tbsj]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_tbsj](
	[ID] [nvarchar](50) NOT NULL,
	[picName] [nvarchar](50) NULL,
	[picImage] [image] NULL,
	[Remark] [nvarchar](500) NULL,
	[S1] [nvarchar](50) NULL,
	[S2] [nvarchar](50) NULL,
	[S3] [nvarchar](50) NULL,
 CONSTRAINT [PK_SDJL_TBSJ] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一标示' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_tbsj', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_tbsj', @level2type=N'COLUMN', @level2name=N'picName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标数据' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_tbsj', @level2type=N'COLUMN', @level2name=N'picImage'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_tbsj', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_tbsj', @level2type=N'COLUMN', @level2name=N'S1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_tbsj', @level2type=N'COLUMN', @level2name=N'S2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_tbsj', @level2type=N'COLUMN', @level2name=N'S3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电图标数据' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_tbsj'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_09pxjl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_09pxjl](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[OrgName] [nvarchar](50) NULL,
	[rq] [datetime] NULL,
	[hydd] [nvarchar](50) NULL,
	[xxss] [nvarchar](50) NULL,
	[cjrs] [nvarchar](50) NULL,
	[zcr] [nvarchar](50) NULL,
	[zjr] [nvarchar](50) NULL,
	[tm] [nvarchar](250) NULL,
	[nr] [nvarchar](4000) NULL,
	[py] [nvarchar](200) NULL,
	[qz] [nvarchar](50) NULL,
	[qzrq] [datetime] NULL,
	[gznrID] [nvarchar](50) NULL,
	[CreateMan] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_09PXJL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'rq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会议地点' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'hydd'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学习时数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'xxss'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参加人数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'cjrs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主持人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'zcr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主讲人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'zjr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'题目' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'tm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'nr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评语' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'py'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签字' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'qz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签字日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'qzrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gznrID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'gznrID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电培训记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_09pxjl'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_03yxfx]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_03yxfx](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[OrgName] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
	[zcr] [nvarchar](50) NULL,
	[rq] [datetime] NULL,
	[hydd] [nvarchar](50) NULL,
	[cjry] [nvarchar](500) NULL,
	[zt] [nvarchar](500) NULL,
	[jy] [nvarchar](4000) NULL,
	[jr] [nvarchar](4000) NULL,
	[py] [nvarchar](500) NULL,
	[qz] [nvarchar](50) NULL,
	[qzrq] [datetime] NULL,
	[gznrID] [nvarchar](50) NULL,
	[CreateMan] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_03YXFX] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会议类型,定期,专题' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'type'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主持人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'zcr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'rq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会议地点' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'hydd'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参加人员' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'cjry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主题' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'zt'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纪要' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'jy'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结论及对策' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'jr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评语' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'py'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签字' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'qz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签字日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'qzrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gznrID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'gznrID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'CreateDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电03运行分析记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_03yxfx'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjl_sbxsqd]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjl_sbxsqd](
	[LineCode] [nvarchar](50) NULL,
	[XsqdName] [nvarchar](100) NULL,
	[XSR1] [nvarchar](50) NULL,
	[XSR2] [nvarchar](50) NULL,
	[ID] [nvarchar](50) NOT NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJL_SBXSQD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_sbxsqd', @level2type=N'COLUMN', @level2name=N'LineCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视区段' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_sbxsqd', @level2type=N'COLUMN', @level2name=N'XsqdName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视人1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_sbxsqd', @level2type=N'COLUMN', @level2name=N'XSR1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视人2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_sbxsqd', @level2type=N'COLUMN', @level2name=N'XSR2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_sbxsqd', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_sbxsqd', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_sbxsqd', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_sbxsqd', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_sbxsqd', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电设备巡视区段' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjl_sbxsqd'

