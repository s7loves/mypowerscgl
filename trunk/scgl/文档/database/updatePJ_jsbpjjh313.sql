USE [ebadascgl]
GO
alter TABLE [dbo].[PJ_jsbpjjh] add 
	[bzrq] [datetime] NULL,
	[bzr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[scbzr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编制日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_jsbpjjh', @level2type=N'COLUMN', @level2name=N'bzrq'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编制人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_jsbpjjh', @level2type=N'COLUMN', @level2name=N'bzr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产部主任' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_jsbpjjh', @level2type=N'COLUMN', @level2name=N'scbzr'
GO

alter TABLE [dbo].[PJ_sbdxgggcxmjhsbb] add
	[dsjfzr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[xsjfzr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[shr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[tbr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[tbrq] [datetime] NULL

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地（市）局负责人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbdxgggcxmjhsbb', @level2type=N'COLUMN', @level2name=N'dsjfzr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'县（市）局负责人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbdxgggcxmjhsbb', @level2type=N'COLUMN', @level2name=N'xsjfzr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbdxgggcxmjhsbb', @level2type=N'COLUMN', @level2name=N'shr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填报人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbdxgggcxmjhsbb', @level2type=N'COLUMN', @level2name=N'tbr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填报日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbdxgggcxmjhsbb', @level2type=N'COLUMN', @level2name=N'tbrq'
GO
alter TABLE [dbo].[PJ_sbsjgcxmjhsbb] add
	[dsjfzr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[xsjfzr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[shr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[tbr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[tbrq] [datetime] NULL

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地（市）局负责人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'dsjfzr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'县（市）局负责人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'xsjfzr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'shr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填报人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'tbr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填报日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'tbrq'
GO
