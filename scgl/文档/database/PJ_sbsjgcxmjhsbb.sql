USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_sbsjgcxmjhsbb]    脚本日期: 12/27/2011 22:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_sbsjgcxmjhsbb](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[xsjmc] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[gcmc] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[zybr] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[wcsj] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[dgzj] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[qtzj] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sxzjsum] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[S1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[S3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_sbsjgcxmjhsbb] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'县（市）局' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'xsjmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工程项目名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'gcmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主要内容及措施' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'zybr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'完成时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'wcsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所需资金（万元）大改资金' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'dgzj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所需资金（万元）其他' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'qtzj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所需资金（万元）合计' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'sxzjsum'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备更改大修计划' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb'
