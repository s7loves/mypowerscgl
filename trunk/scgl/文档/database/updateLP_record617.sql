use ebadascgl
--������Ʊ�ϸ���
alter TABLE [dbo].[LP_record] add
	[bj] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c4] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c5] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���,��Ʊ�ϸ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'LP_record', @level2type=N'COLUMN', @level2name=N'bj'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ԥ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'LP_record', @level2type=N'COLUMN', @level2name=N'c1'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ԥ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'LP_record', @level2type=N'COLUMN', @level2name=N'c2'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ԥ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'LP_record', @level2type=N'COLUMN', @level2name=N'c3'
GO