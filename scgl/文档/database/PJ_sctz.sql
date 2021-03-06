USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_sctz]    脚本日期: 12/31/2011 08:50:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_sctz](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[OrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[wpmc] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[wpgg] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[wpdw] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[wpsl] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[indate] [datetime] NULL,
	[Remark] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[S1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_sctz] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sctz', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sctz', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sctz', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物品名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sctz', @level2type=N'COLUMN', @level2name=N'wpmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物品规格' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sctz', @level2type=N'COLUMN', @level2name=N'wpgg'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物品单位' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sctz', @level2type=N'COLUMN', @level2name=N'wpdw'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sctz', @level2type=N'COLUMN', @level2name=N'wpsl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sctz', @level2type=N'COLUMN', @level2name=N'indate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sctz', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sctz', @level2type=N'COLUMN', @level2name=N'S1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sctz', @level2type=N'COLUMN', @level2name=N'S2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sctz', @level2type=N'COLUMN', @level2name=N'S3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产台账' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sctz'
