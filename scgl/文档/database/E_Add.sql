USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[E_BusinesInfo]    脚本日期: 09/27/2013 21:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_BusinesInfo](
	[ID] [nvarchar](200) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Content] [nvarchar](500) NULL,
	[OrgID] [nvarchar](50) NULL,
	[Other] [nvarchar](50) NULL,
	[UserID] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[Sequence] [int] NULL,
	[WordData] [image] NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_BusinesInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_BusinesInfo', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_BusinesInfo', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机构' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_BusinesInfo', @level2type=N'COLUMN',@level2name=N'OrgID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其它' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_BusinesInfo', @level2type=N'COLUMN',@level2name=N'Other'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_BusinesInfo', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_BusinesInfo', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_BusinesInfo', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_BusinesInfo', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_BusinesInfo', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_BusinesInfo', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_BusinesInfo', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_BusinesInfo', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_BusinesInfo', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_BusinesInfo', @level2type=N'COLUMN',@level2name=N'RowVersion'


USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[E_ExamSet]    脚本日期: 09/27/2013 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_ExamSet](
	[ID] [nvarchar](200) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[Value] [float] NULL,
	[CreateMan] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[Sequence] [int] NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_ExamSet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamSet', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamSet', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamSet', @level2type=N'COLUMN',@level2name=N'Value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamSet', @level2type=N'COLUMN',@level2name=N'CreateMan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamSet', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamSet', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamSet', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamSet', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamSet', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamSet', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamSet', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamSet', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamSet', @level2type=N'COLUMN',@level2name=N'RowVersion'

USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[E_ExamUserRecord]    脚本日期: 09/27/2013 21:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_ExamUserRecord](
	[ID] [nvarchar](50) NOT NULL,
	[OrgName] [nvarchar](50) NULL,
	[OrgCode] [nvarchar](50) NULL,
	[Name] [nvarchar](500) NULL,
	[Post] [nvarchar](100) NULL,
	[CreateMan] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[BigData] [image] NULL,
	[WordData] [image] NULL,
	[Sequence] [int] NULL,
	[ExamRecord] [nvarchar](max) NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_ExamUserRecord] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamUserRecord', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamUserRecord', @level2type=N'COLUMN',@level2name=N'OrgName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamUserRecord', @level2type=N'COLUMN',@level2name=N'OrgCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamUserRecord', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamUserRecord', @level2type=N'COLUMN',@level2name=N'Post'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamUserRecord', @level2type=N'COLUMN',@level2name=N'CreateMan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamUserRecord', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamUserRecord', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试记录' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamUserRecord', @level2type=N'COLUMN',@level2name=N'ExamRecord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamUserRecord', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamUserRecord', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamUserRecord', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamUserRecord', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamUserRecord', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamUserRecord', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ExamUserRecord', @level2type=N'COLUMN',@level2name=N'RowVersion'


USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[E_ScoreSummary]    脚本日期: 09/27/2013 21:42:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_ScoreSummary](
	[ID] [nvarchar](200) NOT NULL,
	[ExmaID] [nvarchar](50) NULL,
	[ExamName] [nvarchar](50) NULL,
	[AverageSocre] [float] NULL,
	[NeedExamUserNum] [int] NULL,
	[RealExamUseNum] [int] NULL,
	[PassNum] [int] NULL,
	[PassPercent] [float] NULL,
	[NoPassNum] [int] NULL,
	[NoPassPercent] [float] NULL,
	[GoodPercent] [float] NULL,
	[CreateTime] [datetime] NULL,
	[Sequence] [int] NULL,
	[ByInt1] [int] NULL,
	[ByInt2] [int] NULL,
	[ByFloat1] [float] NULL,
	[ByFloat2] [float] NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_ScoreSummary] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'ExmaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'ExamName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平均分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'AverageSocre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应考人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'NeedExamUserNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实考人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'RealExamUseNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'及格人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'PassNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通过率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'PassPercent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'不通过人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'NoPassNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'不通过率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'NoPassPercent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'优秀率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'GoodPercent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用整型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'ByInt1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用整型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'ByInt2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用实型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'ByFloat1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用实型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'ByFloat2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_ScoreSummary', @level2type=N'COLUMN',@level2name=N'RowVersion'