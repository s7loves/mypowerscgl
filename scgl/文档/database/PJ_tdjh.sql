USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_tdjh]    脚本日期: 11/18/2011 09:44:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_tdjh](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[OrgCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[SQOrgname] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[JXSB] [nvarchar](150) COLLATE Chinese_PRC_CI_AS NULL,
	[JXNR] [nvarchar](150) COLLATE Chinese_PRC_CI_AS NULL,
	[TDtime] [datetime] NULL,
	[SDtime] [datetime] NULL,
	[ASSOrgname] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[S1] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[S2] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[S3] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_PJ_tdjh] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写单位代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_tdjh', @level2type=N'COLUMN',@level2name=N'OrgCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_tdjh', @level2type=N'COLUMN',@level2name=N'OrgName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'申请单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_tdjh', @level2type=N'COLUMN',@level2name=N'SQOrgname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停电检修设备' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_tdjh', @level2type=N'COLUMN',@level2name=N'JXSB'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主要检修内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_tdjh', @level2type=N'COLUMN',@level2name=N'JXNR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停电时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_tdjh', @level2type=N'COLUMN',@level2name=N'TDtime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_tdjh', @level2type=N'COLUMN',@level2name=N'SDtime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配合检修单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_tdjh', @level2type=N'COLUMN',@level2name=N'ASSOrgname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_tdjh', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_tdjh', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所月度停电计划' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_tdjh'