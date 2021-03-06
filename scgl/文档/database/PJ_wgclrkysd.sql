USE [EbadaScgl]
GO
/****** 对象:  Table [dbo].[PJ_wgclrkysd]    脚本日期: 03/23/2012 14:09:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PJ_wgclrkysd](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[OrgCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[OrgName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ssgc] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ssxm] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[xmdw] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ghdw] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[xmtz] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[dhht] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[fpbh] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[wpmc] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[wpgg] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[wpdw] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[wpsl] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[wpdj] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[htjg] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[yfk] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[scbh] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[jcjg] [nvarchar](800) COLLATE Chinese_PRC_CI_AS NULL,
	[czwt] [nvarchar](800) COLLATE Chinese_PRC_CI_AS NULL,
	[indate] [datetime] NULL,
	[cljg] [nvarchar](800) COLLATE Chinese_PRC_CI_AS NULL,
	[ysr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[jsfzr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zgjz] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [nvarchar](800) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_PJ_wgclrkysd] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'OrgName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工程项目' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'ssgc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分工程项目' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'ssxm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目单位' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'xmdw'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供货单位' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'ghdw'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目投资（万元）' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'xmtz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订货合同' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'dhht'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发票编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'fpbh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'wpmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规格型号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'wpgg'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'wpdw'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交货数量' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'wpsl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单价（元）' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'wpdj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合同价格（元）' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'htjg'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应付款90%金' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'yfk'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交货数量的生产编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'scbh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检查结果' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'jcjg'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存在问题' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'czwt'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'验收时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'indate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理结果' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'cljg'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'验收人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'ysr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'技术负责人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'jsfzr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主管局长' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'zgjz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd', @level2type=N'COLUMN', @level2name=N'Remark'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网改材料验收单' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_wgclrkysd'
