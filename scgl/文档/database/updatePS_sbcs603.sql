use ebadascgl
--增加分类
alter TABLE [dbo].[PS_sbcs] add
	[c1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类,设备、材料' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PS_sbcs', @level2type=N'COLUMN', @level2name=N'c1'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预留' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PS_sbcs', @level2type=N'COLUMN', @level2name=N'c2'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预留' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PS_sbcs', @level2type=N'COLUMN', @level2name=N'c3'
GO