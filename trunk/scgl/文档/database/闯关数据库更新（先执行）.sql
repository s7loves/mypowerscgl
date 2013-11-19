drop  table dbo.E_UserPropRecord

/****** ����:  Table [dbo].[E_UserPropRecord]    �ű�����: 11/19/2013 22:40:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_UserPropRecord](
	[ID] [nvarchar](200) NOT NULL,
	[UserID] [nchar](10) NULL,
	[PropID] [nvarchar](50) NULL,
	[Num] [int] NULL,
	[BuyOrUseTime] [datetime] NULL,
	[Flag] [nvarchar](50) NULL,
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'PropID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'Num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'BuyOrUseTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʹ�ü�¼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'Flag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʱ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserPropRecord', @level2type=N'COLUMN',@level2name=N'RowVersion'


/****** ����:  Table [dbo].[E_UserProp]    �ű�����: 11/19/2013 22:44:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_UserProp](
	[ID] [nvarchar](200) NOT NULL,
	[UserID] [nchar](10) NULL,
	[PropID] [nvarchar](50) NULL,
	[Num] [int] NULL,
	[UsedNum] [int] NULL,
	[CanUseNum] [int] NULL,
	[UpdateTime] [datetime] NULL,
	[Sequence] [int] NULL,
	[BySCol1] [nvarchar](200) NULL,
	[BySCol2] [nvarchar](200) NULL,
	[BySCol3] [nvarchar](200) NULL,
	[BySCol4] [nvarchar](200) NULL,
	[BySCol5] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_E_UserProp] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserProp', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserProp', @level2type=N'COLUMN',@level2name=N'PropID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserProp', @level2type=N'COLUMN',@level2name=N'Num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserProp', @level2type=N'COLUMN',@level2name=N'UsedNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʣ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserProp', @level2type=N'COLUMN',@level2name=N'CanUseNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserProp', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserProp', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserProp', @level2type=N'COLUMN',@level2name=N'BySCol1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserProp', @level2type=N'COLUMN',@level2name=N'BySCol2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserProp', @level2type=N'COLUMN',@level2name=N'BySCol3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserProp', @level2type=N'COLUMN',@level2name=N'BySCol4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserProp', @level2type=N'COLUMN',@level2name=N'BySCol5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserProp', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʱ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'E_UserProp', @level2type=N'COLUMN',@level2name=N'RowVersion'