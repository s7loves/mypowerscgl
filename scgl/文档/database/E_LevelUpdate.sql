USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[E_HonoraryTitle]    脚本日期: 10/21/2013 21:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_HonoraryTitle](
	[ID] [nvarchar](200) NOT NULL,
	[HonoraryTitle] [nvarchar](50) NULL,
	[Desc] [nvarchar](500) NULL,
	[StartScore] [int] NULL,
	[EndScore] [int] NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_HonoraryTitle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'荣誉称号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_HonoraryTitle', @level2type=N'COLUMN',@level2name=N'HonoraryTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_HonoraryTitle', @level2type=N'COLUMN',@level2name=N'Desc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'起始分数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_HonoraryTitle', @level2type=N'COLUMN',@level2name=N'StartScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上限分数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_HonoraryTitle', @level2type=N'COLUMN',@level2name=N'EndScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_HonoraryTitle', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_HonoraryTitle', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_HonoraryTitle', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_HonoraryTitle', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_HonoraryTitle', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_HonoraryTitle', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_HonoraryTitle', @level2type=N'COLUMN',@level2name=N'RowVersion'


USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[E_Level]    脚本日期: 10/21/2013 21:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Level](
	[ID] [nvarchar](200) NOT NULL,
	[SeasonID] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Desc] [nvarchar](500) NULL,
	[Sequence] [int] NULL,
	[StopNum] [int] NULL,
	[ExChange] [int] NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_Level] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'季名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Level', @level2type=N'COLUMN',@level2name=N'SeasonID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关卡名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Level', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Level', @level2type=N'COLUMN',@level2name=N'Desc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Level', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'站数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Level', @level2type=N'COLUMN',@level2name=N'StopNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'积分系数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Level', @level2type=N'COLUMN',@level2name=N'ExChange'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Level', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Level', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Level', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Level', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Level', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Level', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Level', @level2type=N'COLUMN',@level2name=N'RowVersion'


USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[E_LevelSeason]    脚本日期: 10/21/2013 21:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_LevelSeason](
	[ID] [nvarchar](200) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Desc] [nvarchar](500) NULL,
	[Sequence] [int] NULL,
	[LevelNum] [int] NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_LevelSeason] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'季名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelSeason', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelSeason', @level2type=N'COLUMN',@level2name=N'Desc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelSeason', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关卡数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelSeason', @level2type=N'COLUMN',@level2name=N'LevelNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelSeason', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelSeason', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelSeason', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelSeason', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelSeason', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelSeason', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelSeason', @level2type=N'COLUMN',@level2name=N'RowVersion'


USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[E_LevelStop]    脚本日期: 10/21/2013 21:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_LevelStop](
	[ID] [nvarchar](200) NOT NULL,
	[SeasonID] [nvarchar](50) NULL,
	[LevelID] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Desc] [nvarchar](500) NULL,
	[Sequence] [int] NULL,
	[QuestionAllNUM] [int] NULL,
	[PdNumAndLevel] [nvarchar](50) NULL,
	[DxNumAndLevel] [nvarchar](50) NULL,
	[DDxNumAndLevel] [nvarchar](50) NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_LevelStop] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'季名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelStop', @level2type=N'COLUMN',@level2name=N'SeasonID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关卡' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelStop', @level2type=N'COLUMN',@level2name=N'LevelID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'站点名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelStop', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelStop', @level2type=N'COLUMN',@level2name=N'Desc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelStop', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'试题总数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelStop', @level2type=N'COLUMN',@level2name=N'QuestionAllNUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'判断题数与难度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelStop', @level2type=N'COLUMN',@level2name=N'PdNumAndLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单选题数与难度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelStop', @level2type=N'COLUMN',@level2name=N'DxNumAndLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'多选题数与难度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelStop', @level2type=N'COLUMN',@level2name=N'DDxNumAndLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelStop', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelStop', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelStop', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelStop', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelStop', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelStop', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelStop', @level2type=N'COLUMN',@level2name=N'RowVersion'

USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[E_LevelTryRecord]    脚本日期: 10/21/2013 21:55:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_LevelTryRecord](
	[ID] [nvarchar](200) NOT NULL,
	[UserID] [nvarchar](50) NULL,
	[SeasonID] [nvarchar](50) NULL,
	[LevelID] [nvarchar](50) NULL,
	[PassDate] [datetime] NULL,
	[TryTimes] [int] NULL,
	[UseTime] [int] NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_LevelTryRecord] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考生' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelTryRecord', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'季名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelTryRecord', @level2type=N'COLUMN',@level2name=N'SeasonID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关卡名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelTryRecord', @level2type=N'COLUMN',@level2name=N'LevelID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通过时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelTryRecord', @level2type=N'COLUMN',@level2name=N'PassDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'闯关次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelTryRecord', @level2type=N'COLUMN',@level2name=N'TryTimes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最短时间（秒）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelTryRecord', @level2type=N'COLUMN',@level2name=N'UseTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelTryRecord', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelTryRecord', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelTryRecord', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelTryRecord', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelTryRecord', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelTryRecord', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_LevelTryRecord', @level2type=N'COLUMN',@level2name=N'RowVersion'

USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[E_Prize]    脚本日期: 10/21/2013 21:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Prize](
	[ID] [nvarchar](200) NOT NULL,
	[PrizeName] [nvarchar](50) NULL,
	[Desc] [nchar](10) NULL,
	[Type] [nvarchar](50) NULL,
	[SelectChar] [nvarchar](500) NULL,
	[Price] [int] NULL,
	[Image] [image] NULL,
	[Sequence] [int] NULL,
	[AllNum] [int] NULL,
	[CurrentNum] [int] NULL,
	[BeginDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Other] [nvarchar](50) NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_Prize] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'奖品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'PrizeName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'Desc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关键字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'SelectChar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'兑换分数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'Image'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'AllNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'剩余数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'CurrentNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启始日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领取说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'Other'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prize', @level2type=N'COLUMN',@level2name=N'RowVersion'

USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[E_Prop]    脚本日期: 10/21/2013 21:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Prop](
	[ID] [nvarchar](200) NOT NULL,
	[PropName] [nvarchar](50) NULL,
	[Function] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[Sequence] [int] NULL,
	[Price] [int] NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_Prop] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'道具名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prop', @level2type=N'COLUMN',@level2name=N'PropName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prop', @level2type=N'COLUMN',@level2name=N'Function'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prop', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prop', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prop', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prop', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prop', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prop', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prop', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prop', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prop', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_Prop', @level2type=N'COLUMN',@level2name=N'RowVersion'

USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[E_UserPrizeRecord]    脚本日期: 10/21/2013 21:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_UserPrizeRecord](
	[ID] [nvarchar](200) NOT NULL,
	[UserID] [nvarchar](50) NULL,
	[PrizeID] [nvarchar](50) NULL,
	[SendTime] [datetime] NULL,
	[PrizeNum] [int] NULL,
	[Sequence] [int] NULL,
	[HasFinished] [bit] NULL,
	[Handler] [nvarchar](50) NULL,
	[ExchangeTime] [datetime] NULL,
	[Record] [nvarchar](200) NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_UserPrizeRecord] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考生' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPrizeRecord', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'奖品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPrizeRecord', @level2type=N'COLUMN',@level2name=N'PrizeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提交日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPrizeRecord', @level2type=N'COLUMN',@level2name=N'SendTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'兑换数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPrizeRecord', @level2type=N'COLUMN',@level2name=N'PrizeNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPrizeRecord', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否支付将品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPrizeRecord', @level2type=N'COLUMN',@level2name=N'HasFinished'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经办人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPrizeRecord', @level2type=N'COLUMN',@level2name=N'Handler'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'兑换日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPrizeRecord', @level2type=N'COLUMN',@level2name=N'ExchangeTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'兑换记事' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPrizeRecord', @level2type=N'COLUMN',@level2name=N'Record'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPrizeRecord', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPrizeRecord', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPrizeRecord', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPrizeRecord', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPrizeRecord', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPrizeRecord', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPrizeRecord', @level2type=N'COLUMN',@level2name=N'RowVersion'

USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[E_UserPropRecord]    脚本日期: 10/21/2013 21:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_UserPropRecord](
	[ID] [nvarchar](200) NOT NULL,
	[UserID] [nchar](10) NULL,
	[PropID] [nvarchar](50) NULL,
	[Num] [int] NULL,
	[UsedNum] [int] NULL,
	[CanUseNum] [int] NULL,
	[BuyTime] [datetime] NULL,
	[UseRecord] [nvarchar](500) NULL,
	[Sequence] [int] NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_UserPropRecord] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考生' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'道具名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'PropID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'购买数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'Num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'已用数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'UsedNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'剩余数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'CanUseNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'购买日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'BuyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用记录' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'UseRecord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'RowVersion'

USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[E_UserScore]    脚本日期: 10/21/2013 21:56:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_UserScore](
	[ID] [nvarchar](200) NOT NULL,
	[UserID] [nvarchar](50) NULL,
	[AllScore] [int] NULL,
	[CurrtenScore] [int] NULL,
	[UpdateTime] [datetime] NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_UserScore] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考生' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScore', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总得分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScore', @level2type=N'COLUMN',@level2name=N'AllScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前分数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScore', @level2type=N'COLUMN',@level2name=N'CurrtenScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScore', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScore', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScore', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScore', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScore', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScore', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScore', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScore', @level2type=N'COLUMN',@level2name=N'RowVersion'

USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[E_UserScoreRecord]    脚本日期: 10/21/2013 21:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_UserScoreRecord](
	[ID] [nvarchar](200) NOT NULL,
	[UserID] [nvarchar](50) NULL,
	[Flag] [nvarchar](50) NULL,
	[Score] [int] NULL,
	[CreateTime] [datetime] NULL,
	[Reason] [nvarchar](200) NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_UserScoreRecord] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考生' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScoreRecord', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收入/支出' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScoreRecord', @level2type=N'COLUMN',@level2name=N'Flag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScoreRecord', @level2type=N'COLUMN',@level2name=N'Score'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScoreRecord', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事由' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScoreRecord', @level2type=N'COLUMN',@level2name=N'Reason'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScoreRecord', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScoreRecord', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScoreRecord', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScoreRecord', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScoreRecord', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScoreRecord', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserScoreRecord', @level2type=N'COLUMN',@level2name=N'RowVersion'