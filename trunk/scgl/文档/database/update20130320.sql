USE [ebadascgl]
GO
alter table BD_SBTZ_SX alter column norder int;
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sd_tsqyzl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sd_tsqyzl](
	[ID] [nvarchar](50) NOT NULL,
	[zldm] [nvarchar](50) NOT NULL,
	[zlmc] [nvarchar](50) NULL,
	[isuse] [nvarchar](50) NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
 CONSTRAINT [PK_SD_TSQYZL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[sd_tsqyzl]') AND name = N'Index_1')
CREATE UNIQUE NONCLUSTERED INDEX [Index_1] ON [dbo].[sd_tsqyzl] 
(
	[zldm] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'种类代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzl', @level2type=N'COLUMN', @level2name=N'zldm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'种类名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzl', @level2type=N'COLUMN', @level2name=N'zlmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzl', @level2type=N'COLUMN', @level2name=N'isuse'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzl', @level2type=N'COLUMN', @level2name=N'c2'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sd_tsqyimage]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sd_tsqyimage](
	[ID] [nvarchar](50) NOT NULL,
	[ParentID] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
	[text] [nvarchar](500) NULL,
	[data] [image] NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
 CONSTRAINT [PK_SD_TSQYIMAGE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sd_tsqyzlsx]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sd_tsqyzlsx](
	[ID] [nvarchar](50) NOT NULL,
	[zldm] [nvarchar](50) NOT NULL,
	[sxcol] [nvarchar](50) NULL,
	[sxname] [nvarchar](50) NULL,
	[norder] [int] NULL,
	[vtype] [nvarchar](50) NULL,
	[ctype] [nvarchar](50) NULL,
	[defaultvalue] [nvarchar](max) NULL,
	[inittype] [nvarchar](50) NULL,
	[initsql] [nvarchar](max) NULL,
	[isdel] [nvarchar](50) NULL,
	[isedit] [nvarchar](50) NULL,
	[isuse] [nvarchar](50) NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
 CONSTRAINT [PK_SD_TSQYZLSX] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'种类代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzlsx', @level2type=N'COLUMN', @level2name=N'zldm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属性列' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzlsx', @level2type=N'COLUMN', @level2name=N'sxcol'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属性名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzlsx', @level2type=N'COLUMN', @level2name=N'sxname'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzlsx', @level2type=N'COLUMN', @level2name=N'norder'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzlsx', @level2type=N'COLUMN', @level2name=N'vtype'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控件类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzlsx', @level2type=N'COLUMN', @level2name=N'ctype'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'默认值' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzlsx', @level2type=N'COLUMN', @level2name=N'defaultvalue'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'初始方式' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzlsx', @level2type=N'COLUMN', @level2name=N'inittype'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'初始查询' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzlsx', @level2type=N'COLUMN', @level2name=N'initsql'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可删除' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzlsx', @level2type=N'COLUMN', @level2name=N'isdel'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可编辑' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzlsx', @level2type=N'COLUMN', @level2name=N'isedit'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzlsx', @level2type=N'COLUMN', @level2name=N'isuse'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzlsx', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqyzlsx', @level2type=N'COLUMN', @level2name=N'c2'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sd_tsqy]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sd_tsqy](
	[ID] [nvarchar](50) NOT NULL,
	[zldm] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[LineID] [nvarchar](50) NULL,
	[gtbegin] [nvarchar](50) NULL,
	[gtend] [nvarchar](50) NULL,
	[createdate] [datetime] NULL,
	[createman] [nvarchar](50) NULL,
	[a1] [nvarchar](500) NULL,
	[a2] [nvarchar](500) NULL,
	[a3] [nvarchar](500) NULL,
	[a4] [nvarchar](500) NULL,
	[a5] [nvarchar](500) NULL,
	[a6] [nvarchar](500) NULL,
	[a7] [nvarchar](500) NULL,
	[a8] [nvarchar](500) NULL,
	[a9] [nvarchar](500) NULL,
	[a10] [nvarchar](500) NULL,
	[a11] [nvarchar](500) NULL,
	[a12] [nvarchar](500) NULL,
	[a13] [nvarchar](500) NULL,
	[a14] [nvarchar](500) NULL,
	[a15] [nvarchar](500) NULL,
	[a16] [nvarchar](500) NULL,
	[a17] [nvarchar](500) NULL,
	[a18] [nvarchar](500) NULL,
	[a19] [nvarchar](500) NULL,
	[a20] [nvarchar](500) NULL,
	[a21] [nvarchar](500) NULL,
	[a22] [nvarchar](500) NULL,
	[a23] [nvarchar](500) NULL,
	[a24] [nvarchar](500) NULL,
	[a25] [nvarchar](500) NULL,
 CONSTRAINT [PK_SD_TSQY] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'种类代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_tsqy', @level2type=N'COLUMN', @level2name=N'zldm'

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SD_TSQYZLSX_R_SD_TSQYZL]') AND parent_object_id = OBJECT_ID(N'[dbo].[sd_tsqyzlsx]'))
ALTER TABLE [dbo].[sd_tsqyzlsx]  WITH CHECK ADD  CONSTRAINT [FK_SD_TSQYZLSX_R_SD_TSQYZL] FOREIGN KEY([zldm])
REFERENCES [dbo].[sd_tsqyzl] ([zldm])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sd_tsqy_sd_tsqyzl]') AND parent_object_id = OBJECT_ID(N'[dbo].[sd_tsqy]'))
ALTER TABLE [dbo].[sd_tsqy]  WITH CHECK ADD  CONSTRAINT [FK_sd_tsqy_sd_tsqyzl] FOREIGN KEY([zldm])
REFERENCES [dbo].[sd_tsqyzl] ([zldm])
