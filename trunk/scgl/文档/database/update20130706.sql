USE [ebadascgl]

ALTER TABLE dbo.bdjl_xdctzjlb alter column bzdcdy nvarchar(500)
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sdjls_sbpjb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sdjls_sbpjb](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[OrgName] [nvarchar](50) NULL,
	[LineCode] [nvarchar](50) NULL,
	[LineName] [nvarchar](50) NULL,
	[pjrq] [datetime] NULL,
	[pddj] [nvarchar](50) NULL,
	[pjfzr] [nvarchar](50) NULL,
	[BigData] [image] NULL,
	[Remark] [nvarchar](500) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_SDJLS_SBPJB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjls_sbpjb', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjls_sbpjb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjls_sbpjb', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjls_sbpjb', @level2type=N'COLUMN', @level2name=N'LineCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjls_sbpjb', @level2type=N'COLUMN', @level2name=N'LineName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评级日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjls_sbpjb', @level2type=N'COLUMN', @level2name=N'pjrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评定等级' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjls_sbpjb', @level2type=N'COLUMN', @level2name=N'pddj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评级负责人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjls_sbpjb', @level2type=N'COLUMN', @level2name=N'pjfzr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生成文档' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjls_sbpjb', @level2type=N'COLUMN', @level2name=N'BigData'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjls_sbpjb', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjls_sbpjb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjls_sbpjb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjls_sbpjb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjls_sbpjb', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjls_sbpjb', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电线路设备评级表' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sdjls_sbpjb'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_ksnr]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_ksnr](
	[ID] [nvarchar](50) NOT NULL,
	[ParentID] [nvarchar](50) NULL,
	[th] [nvarchar](50) NULL,
	[nr] [nvarchar](2000) NULL,
	[pj] [nvarchar](500) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
 CONSTRAINT [PK_BDJL_KSNR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksnr', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父表ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksnr', @level2type=N'COLUMN', @level2name=N'ParentID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'题号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksnr', @level2type=N'COLUMN', @level2name=N'th'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksnr', @level2type=N'COLUMN', @level2name=N'nr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评价' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksnr', @level2type=N'COLUMN', @level2name=N'pj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksnr', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksnr', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksnr', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksnr', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksnr', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksnr'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_ksjl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_ksjl](
	[ID] [nvarchar](50) NOT NULL,
	[Ksrq] [datetime] NULL,
	[Sequence] [nvarchar](50) NOT NULL,
	[Orgcode] [nvarchar](50) NULL,
	[Orgname] [nvarchar](50) NULL,
	[Ksxm] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[PostName] [nvarchar](50) NULL,
	[PostAge] [nvarchar](50) NULL,
	[LastExamTime] [datetime] NULL,
	[ExamStartTime] [nvarchar](50) NULL,
	[ExamEndTime] [nvarchar](50) NULL,
	[TotalEvaluate] [nvarchar](500) NULL,
	[Kswyhjl] [nvarchar](50) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[c4] [nvarchar](500) NULL,
	[c5] [nvarchar](500) NULL,
	[Bkrqz] [nvarchar](50) NULL,
	[Kswyhzr] [nvarchar](50) NULL,
	[Wy] [nvarchar](50) NULL,
 CONSTRAINT [PK_BDJL_KSJL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'Ksrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'Sequence'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'Orgcode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'Orgname'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试项目' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'Ksxm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'UserName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'PostName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本职位工龄' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'PostAge'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最近一次考试日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'LastExamTime'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试开始时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'ExamStartTime'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试结束时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'ExamEndTime'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总评价' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'TotalEvaluate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试委员会结论' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'Kswyhjl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'被考人签字' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'Bkrqz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试委员会主任(签章写明职称)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'Kswyhzr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'委员' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl', @level2type=N'COLUMN', @level2name=N'Wy'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变电考试记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ksjl'

GO

