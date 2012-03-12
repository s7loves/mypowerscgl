USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_anqgjcrkd]    脚本日期: 03/12/2012 09:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_anqgjcrkd](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[num] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[wpmc] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[wpgg] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[wpdw] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[wpsl] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[wpdj] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[wpcj] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ckdate] [datetime] NULL,
	[cksl] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[kcsl] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[lqdw] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zkcsl] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ssgc] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ssxm] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[indate] [datetime] NULL,
	[syzq] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[scsydate] [datetime] NULL,
	[synx] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[type] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[lasttime] [datetime] NULL,
	[lyparent] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_anqgjcrkd] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出入库单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'OrgName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'OrgCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'wpmc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物品规格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'wpgg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物品单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'wpdw'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'wpsl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单价(单位:元)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'wpdj'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'厂家' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'wpcj'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'ckdate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'cksl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'该物品库存数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'kcsl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领取人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'lqdw'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'zkcsl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属工程' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'ssgc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属分工程' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'ssxm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'indate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'试验周期（年）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'syzq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次试验时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'scsydate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用年限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'synx'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'lasttime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'材料来源ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd', @level2type=N'COLUMN',@level2name=N'lyparent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'安全工器具出入库单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_anqgjcrkd'