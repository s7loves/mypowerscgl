USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_21dyjcdcbk]    脚本日期: 11/06/2012 08:49:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_21dyjcdcbk](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[GdsCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[GdsName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[year] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[type] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[num] [int] NULL,
	[zzxh] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[by1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[by2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[by3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[by4] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[CreateMan] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_PJ_21dyjcdcbk] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_21dyjcdcbk', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_21dyjcdcbk', @level2type=N'COLUMN', @level2name=N'GdsCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_21dyjcdcbk', @level2type=N'COLUMN', @level2name=N'GdsName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_21dyjcdcbk', @level2type=N'COLUMN', @level2name=N'year'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电压检测点类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_21dyjcdcbk', @level2type=N'COLUMN', @level2name=N'type'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电压检测点序号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_21dyjcdcbk', @level2type=N'COLUMN', @level2name=N'num'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装置型号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_21dyjcdcbk', @level2type=N'COLUMN', @level2name=N'zzxh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_21dyjcdcbk', @level2type=N'COLUMN', @level2name=N'CreateMan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_21dyjcdcbk', @level2type=N'COLUMN', @level2name=N'CreateDate'
