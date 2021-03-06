USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_zbdytz]    脚本日期: 12/04/2011 10:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_zbdytz](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[khmc] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[khdz] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[zdyOrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zdyLineName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zdykgModle] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zbdytype] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zbdyModle] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zbdyrl] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[kgfs] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zbr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[chargeman] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_zbdytz] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_zbdytz', @level2type=N'COLUMN', @level2name=N'khmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户地址' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_zbdytz', @level2type=N'COLUMN', @level2name=N'khdz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主电源所属变电所' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_zbdytz', @level2type=N'COLUMN', @level2name=N'zdyOrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主电源所属线路' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_zbdytz', @level2type=N'COLUMN', @level2name=N'zdyLineName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主电源开关型号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_zbdytz', @level2type=N'COLUMN', @level2name=N'zdykgModle'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自备电源类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_zbdytz', @level2type=N'COLUMN', @level2name=N'zbdytype'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自备电源型号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_zbdytz', @level2type=N'COLUMN', @level2name=N'zbdyModle'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自备电源容量' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_zbdytz', @level2type=N'COLUMN', @level2name=N'zbdyrl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主电源开关与自备电源开关是否互锁' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_zbdytz', @level2type=N'COLUMN', @level2name=N'kgfs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填表人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_zbdytz', @level2type=N'COLUMN', @level2name=N'zbr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_zbdytz', @level2type=N'COLUMN', @level2name=N'chargeman'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_zbdytz', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自备电源设备台账' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_zbdytz'
