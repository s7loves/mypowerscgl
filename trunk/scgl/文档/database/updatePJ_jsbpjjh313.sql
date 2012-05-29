USE [ebadascgl]

alter TABLE [dbo].[PJ_jsbpjjh] add 
	[bzrq] [datetime] NULL,
	[bzr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[scbzr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编制日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_jsbpjjh', @level2type=N'COLUMN', @level2name=N'bzrq'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编制人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_jsbpjjh', @level2type=N'COLUMN', @level2name=N'bzr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产部主任' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_jsbpjjh', @level2type=N'COLUMN', @level2name=N'scbzr'

