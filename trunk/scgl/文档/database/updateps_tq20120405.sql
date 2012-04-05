use [EbadaScgl]
alter table [PS_tq] add
	[bcdr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ddj] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[jj] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[nfy] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zmfs] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[dxbs] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[sxbs] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL
	
go
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'补偿电容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_tq', @level2type=N'COLUMN',@level2name=N'bcdr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电动机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_tq', @level2type=N'COLUMN',@level2name=N'ddj'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机井' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_tq', @level2type=N'COLUMN',@level2name=N'jj'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'农副业' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_tq', @level2type=N'COLUMN',@level2name=N'nfy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'照明户数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_tq', @level2type=N'COLUMN',@level2name=N'zmfs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单相表数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_tq', @level2type=N'COLUMN',@level2name=N'dxbs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'三相表数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_tq', @level2type=N'COLUMN',@level2name=N'sxbs'
