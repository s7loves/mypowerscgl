USE [EbadaScgl]
alter table [PJ_lcfj]    add
	[flag] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[by1] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[by2] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[by3] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[by4] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL
	
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʶ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfj', @level2type=N'COLUMN', @level2name=N'flag'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfj', @level2type=N'COLUMN', @level2name=N'by1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfj', @level2type=N'COLUMN', @level2name=N'by2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfj', @level2type=N'COLUMN', @level2name=N'by3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_lcfj', @level2type=N'COLUMN', @level2name=N'by4'