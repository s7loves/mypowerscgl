USE [ebadascgl]
GO
alter TABLE [dbo].[PJ_jsbpjjh] add 
	[bzrq] [datetime] NULL,
	[bzr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[scbzr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_jsbpjjh', @level2type=N'COLUMN', @level2name=N'bzrq'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_jsbpjjh', @level2type=N'COLUMN', @level2name=N'bzr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_jsbpjjh', @level2type=N'COLUMN', @level2name=N'scbzr'
GO

alter TABLE [dbo].[PJ_sbdxgggcxmjhsbb] add
	[dsjfzr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[xsjfzr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[shr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[tbr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[tbrq] [datetime] NULL

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�أ��У��ָ�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbdxgggcxmjhsbb', @level2type=N'COLUMN', @level2name=N'dsjfzr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�أ��У��ָ�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbdxgggcxmjhsbb', @level2type=N'COLUMN', @level2name=N'xsjfzr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbdxgggcxmjhsbb', @level2type=N'COLUMN', @level2name=N'shr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbdxgggcxmjhsbb', @level2type=N'COLUMN', @level2name=N'tbr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbdxgggcxmjhsbb', @level2type=N'COLUMN', @level2name=N'tbrq'
GO
alter TABLE [dbo].[PJ_sbsjgcxmjhsbb] add
	[dsjfzr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[xsjfzr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[shr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[tbr] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[tbrq] [datetime] NULL

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�أ��У��ָ�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'dsjfzr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�أ��У��ָ�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'xsjfzr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'shr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'tbr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PJ_sbsjgcxmjhsbb', @level2type=N'COLUMN', @level2name=N'tbrq'
GO
