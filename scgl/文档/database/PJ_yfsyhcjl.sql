USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_yfsyhcjl]    脚本日期: 09/20/2011 15:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_yfsyhcjl](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[OrgCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[xh] [int] NULL,
	[sj] [datetime] NULL,
	[yssbName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[xhclName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sbModle] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[dw] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sl] [int] NULL,
	[ysMan] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[yxdwMan] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_yfsyhcjl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyhcjl', @level2type=N'COLUMN',@level2name=N'OrgCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyhcjl', @level2type=N'COLUMN',@level2name=N'OrgName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyhcjl', @level2type=N'COLUMN',@level2name=N'xh'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyhcjl', @level2type=N'COLUMN',@level2name=N'sj'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预试设备名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyhcjl', @level2type=N'COLUMN',@level2name=N'yssbName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消耗材料名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyhcjl', @level2type=N'COLUMN',@level2name=N'xhclName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规格型号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyhcjl', @level2type=N'COLUMN',@level2name=N'sbModle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyhcjl', @level2type=N'COLUMN',@level2name=N'dw'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyhcjl', @level2type=N'COLUMN',@level2name=N'sl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预试人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyhcjl', @level2type=N'COLUMN',@level2name=N'ysMan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运行单位人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyhcjl', @level2type=N'COLUMN',@level2name=N'yxdwMan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_yfsyhcjl', @level2type=N'COLUMN',@level2name=N'Remark'