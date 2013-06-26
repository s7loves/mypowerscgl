USE [ebadascgl]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WarnRecord]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WarnRecord](
	[ID] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[Sequence] [int] NULL,
	[TableName] [nvarchar](50) NULL,
	[FieldName] [nvarchar](50) NULL,
	[WarnType] [nvarchar](50) NULL,
	[Times] [int] NULL,
	[WritTime] [datetime] NULL,
	[LinkID] [nvarchar](50) NULL,
	[Remark] [nvarchar](200) NULL,
	[Des] [nvarchar](200) NULL,
 CONSTRAINT [PK_WarnRecord] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnRecord', @level2type=N'COLUMN', @level2name=N'Type'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnRecord', @level2type=N'COLUMN', @level2name=N'Sequence'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表名' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnRecord', @level2type=N'COLUMN', @level2name=N'TableName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段名' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnRecord', @level2type=N'COLUMN', @level2name=N'FieldName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提醒类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnRecord', @level2type=N'COLUMN', @level2name=N'WarnType'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'次数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnRecord', @level2type=N'COLUMN', @level2name=N'Times'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'需要填写日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnRecord', @level2type=N'COLUMN', @level2name=N'WritTime'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'快速进入' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnRecord', @level2type=N'COLUMN', @level2name=N'LinkID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnRecord', @level2type=N'COLUMN', @level2name=N'Des'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WarnSet]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WarnSet](
	[ID] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[TypeName] [nvarchar](100) NULL,
	[Sequence] [int] NULL,
	[TableName] [nvarchar](50) NULL,
	[TableCNName] [nvarchar](50) NULL,
	[FieldName] [nvarchar](50) NULL,
	[FieldCNName] [nvarchar](50) NULL,
	[WarnType] [nvarchar](50) NULL,
	[WarnTypeName] [nvarchar](50) NULL,
	[OrderDays] [int] NULL,
	[SpaceDays] [int] NULL,
	[BeforeDays] [int] NULL,
	[AfterDays] [int] NULL,
	[WarnTimes] [int] NULL,
	[OrgField] [nvarchar](50) NULL,
	[SetUserID] [nvarchar](50) NULL,
	[SetTime] [datetime] NULL,
	[Remark] [nvarchar](200) NULL,
	[IsUse] [bit] NULL,
	[LinkID] [nvarchar](200) NULL,
	[LinkName] [nvarchar](200) NULL,
	[BYScol1] [nvarchar](200) NULL,
	[BYScol2] [nvarchar](200) NULL,
	[BYScol3] [nvarchar](200) NULL,
	[BYScol4] [nvarchar](200) NULL,
	[BYScol5] [nvarchar](200) NULL,
 CONSTRAINT [PK_WarnSet1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'Type'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型明称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'TypeName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'Sequence'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表名' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'TableName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表中文名' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'TableCNName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段名' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'FieldName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段中文名' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'FieldCNName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提醒类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'WarnType'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提醒类型名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'WarnTypeName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顺序天数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'OrderDays'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间隔天数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'SpaceDays'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' 提前几天提醒' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'BeforeDays'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'延后几天提醒' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'AfterDays'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提醒往次数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'WarnTimes'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位字段' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'OrgField'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设置人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'SetUserID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设置时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'SetTime'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'IsUse'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'LinkID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'LinkName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'BYScol1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'BYScol2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'BYScol3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'BYScol4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WarnSet', @level2type=N'COLUMN', @level2name=N'BYScol5'

