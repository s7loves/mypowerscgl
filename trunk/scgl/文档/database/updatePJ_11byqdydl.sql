use [EbadaScgl]
alter table [PJ_11byqdydl] 
add
	[bphd] [float] NULL,
	[tq] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[xh] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[zjr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[by1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[by2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[by3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL
      
	
go

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ƽ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_11byqdydl', @level2type=N'COLUMN', @level2name=N'bphd'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'̨��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_11byqdydl', @level2type=N'COLUMN', @level2name=N'tq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ͺ�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_11byqdydl', @level2type=N'COLUMN', @level2name=N'xh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ݽ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_11byqdydl', @level2type=N'COLUMN', @level2name=N'zjr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_11byqdydl', @level2type=N'COLUMN', @level2name=N'by1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_11byqdydl', @level2type=N'COLUMN', @level2name=N'by2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_11byqdydl', @level2type=N'COLUMN', @level2name=N'by3'
