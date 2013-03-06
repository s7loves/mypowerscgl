USE [ebadascgl]
GO
/****** 对象:  Table [dbo].[BD_SBTZ_ZL]    脚本日期: 03/06/2013 10:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BD_SBTZ_ZL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BD_SBTZ_ZL](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dm] [nvarchar](50) NULL,
	[mc] [nvarchar](50) NULL,
	[jxzq] [nvarchar](50) NULL,
	[pdm] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
 CONSTRAINT [PK_DB_SBTZ_ZL] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

/****** 对象:  Index [Index_1]    脚本日期: 03/06/2013 10:21:04 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[BD_SBTZ_ZL]') AND name = N'Index_1')
CREATE UNIQUE NONCLUSTERED INDEX [Index_1] ON [dbo].[BD_SBTZ_ZL] 
(
	[dm] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'种类代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ_ZL', @level2type=N'COLUMN', @level2name=N'dm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'种类名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ_ZL', @level2type=N'COLUMN', @level2name=N'mc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检修周期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ_ZL', @level2type=N'COLUMN', @level2name=N'jxzq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ_ZL', @level2type=N'COLUMN', @level2name=N'pdm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ_ZL', @level2type=N'COLUMN', @level2name=N'type'

GO
/****** 对象:  Table [dbo].[bd_sbtz_fssb]    脚本日期: 03/06/2013 10:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bd_sbtz_fssb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bd_sbtz_fssb](
	[gtID] [nvarchar](50) NOT NULL,
	[sbID] [nvarchar](50) NOT NULL,
	[sbCode] [nvarchar](50) NULL,
	[sbType] [nvarchar](50) NULL,
	[sbModle] [nvarchar](50) NULL,
	[sbName] [nvarchar](50) NULL,
	[sbNumber] [smallint] NULL,
	[C1] [nvarchar](50) NULL,
	[C2] [nvarchar](50) NULL,
	[C3] [nvarchar](50) NULL,
	[C4] [nvarchar](50) NULL,
	[C5] [nvarchar](50) NULL,
 CONSTRAINT [PK_BD_SBTZ_FSSB] PRIMARY KEY CLUSTERED 
(
	[sbID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变电设备ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtz_fssb', @level2type=N'COLUMN', @level2name=N'gtID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtz_fssb', @level2type=N'COLUMN', @level2name=N'sbID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtz_fssb', @level2type=N'COLUMN', @level2name=N'sbCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备种类' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtz_fssb', @level2type=N'COLUMN', @level2name=N'sbType'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备型号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtz_fssb', @level2type=N'COLUMN', @level2name=N'sbModle'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtz_fssb', @level2type=N'COLUMN', @level2name=N'sbName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备数量' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtz_fssb', @level2type=N'COLUMN', @level2name=N'sbNumber'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备参数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtz_fssb', @level2type=N'COLUMN', @level2name=N'C1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备参数2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtz_fssb', @level2type=N'COLUMN', @level2name=N'C2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备参数3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtz_fssb', @level2type=N'COLUMN', @level2name=N'C3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备参数4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtz_fssb', @level2type=N'COLUMN', @level2name=N'C4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备参数5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtz_fssb', @level2type=N'COLUMN', @level2name=N'C5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变电附属设备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtz_fssb'

GO
/****** 对象:  Table [dbo].[bd_sbtzclb]    脚本日期: 03/06/2013 10:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bd_sbtzclb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bd_sbtzclb](
	[bh] [nvarchar](50) NULL,
	[mc] [nvarchar](50) NULL,
	[xh] [nvarchar](50) NULL,
	[ID] [nvarchar](50) NOT NULL,
	[ParentID] [nvarchar](50) NULL,
	[S1] [nvarchar](50) NULL,
	[S2] [nvarchar](50) NULL,
	[S3] [nvarchar](50) NULL,
	[zl] [nvarchar](50) NULL,
	[zlCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_BD_GTSBCLB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'种类编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtzclb', @level2type=N'COLUMN', @level2name=N'bh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'种类名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtzclb', @level2type=N'COLUMN', @level2name=N'mc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备型号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtzclb', @level2type=N'COLUMN', @level2name=N'xh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtzclb', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ParentID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtzclb', @level2type=N'COLUMN', @level2name=N'ParentID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtzclb', @level2type=N'COLUMN', @level2name=N'S1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtzclb', @level2type=N'COLUMN', @level2name=N'S2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtzclb', @level2type=N'COLUMN', @level2name=N'S3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'种类' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtzclb', @level2type=N'COLUMN', @level2name=N'zl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'种类编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtzclb', @level2type=N'COLUMN', @level2name=N'zlCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变电附属设备材料表' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bd_sbtzclb'

GO
/****** 对象:  Table [dbo].[BD_SBTZ_SX]    脚本日期: 03/06/2013 10:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BD_SBTZ_SX]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BD_SBTZ_SX](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[zldm] [nvarchar](50) NULL,
	[sxcol] [nvarchar](50) NULL,
	[sxname] [nvarchar](50) NULL,
	[sxtype] [nvarchar](50) NULL,
	[norder] [nvarchar](50) NULL,
	[isvisible] [nvarchar](50) NULL CONSTRAINT [DF__DB_SBTZ_S__isvis__06ED0088]  DEFAULT ('是'),
	[defaultvalue] [nvarchar](50) NULL,
	[boxtype] [nvarchar](50) NULL CONSTRAINT [DF__DB_SBTZ_S__boxty__07E124C1]  DEFAULT ('value'),
	[boxvalue] [nvarchar](50) NULL,
	[isdel] [nvarchar](50) NULL CONSTRAINT [DF__DB_SBTZ_S__isdel__08D548FA]  DEFAULT ('是'),
	[isedit] [nvarchar](50) NULL CONSTRAINT [DF__DB_SBTZ_S__isedi__09C96D33]  DEFAULT ('是'),
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
 CONSTRAINT [PK_DB_SBTZ_SX] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属性列' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ_SX', @level2type=N'COLUMN', @level2name=N'sxcol'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属性名' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ_SX', @level2type=N'COLUMN', @level2name=N'sxname'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属性类型,0-文本 1-下拉列表 2-日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ_SX', @level2type=N'COLUMN', @level2name=N'sxtype'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示顺序' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ_SX', @level2type=N'COLUMN', @level2name=N'norder'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ_SX', @level2type=N'COLUMN', @level2name=N'isvisible'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'默认值' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ_SX', @level2type=N'COLUMN', @level2name=N'defaultvalue'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下拉列表取值方式,value-字符串|分割,sql-查询语句' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ_SX', @level2type=N'COLUMN', @level2name=N'boxtype'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下拉列表数据集' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ_SX', @level2type=N'COLUMN', @level2name=N'boxvalue'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可删除' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ_SX', @level2type=N'COLUMN', @level2name=N'isdel'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可修改' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ_SX', @level2type=N'COLUMN', @level2name=N'isedit'

GO
/****** 对象:  Table [dbo].[BD_SBTZ]    脚本日期: 03/06/2013 10:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BD_SBTZ]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BD_SBTZ](
	[sb_id] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NOT NULL,
	[sbvol] [nvarchar](50) NULL,
	[sbtype] [nvarchar](50) NULL,
	[sbname] [nvarchar](50) NULL,
	[sbunit] [nvarchar](50) NULL,
	[jxzq] [int] NULL,
	[a_left] [float] NULL,
	[a_top] [float] NULL,
	[a_width] [float] NULL,
	[a_height] [float] NULL,
	[a_color] [int] NULL,
	[a_orient] [int] NULL,
	[a_itemnum] [int] NULL,
	[a_zdyxnum] [int] NULL,
	[a_extdata] [nvarchar](max) NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
	[c3] [nvarchar](50) NULL,
	[a1] [nvarchar](50) NULL,
	[a2] [nvarchar](50) NULL,
	[a3] [nvarchar](50) NULL,
	[a4] [nvarchar](50) NULL,
	[a5] [nvarchar](50) NULL,
	[a6] [nvarchar](50) NULL,
	[a7] [nvarchar](50) NULL,
	[a8] [nvarchar](50) NULL,
	[a9] [nvarchar](50) NULL,
	[a10] [nvarchar](50) NULL,
	[a11] [nvarchar](50) NULL,
	[a13] [nvarchar](50) NULL,
	[a12] [nvarchar](50) NULL,
	[a14] [nvarchar](50) NULL,
	[a15] [nvarchar](50) NULL,
	[a16] [nvarchar](50) NULL,
	[a17] [nvarchar](50) NULL,
	[a18] [nvarchar](50) NULL,
	[a19] [nvarchar](50) NULL,
	[a20] [nvarchar](50) NULL,
	[a21] [nvarchar](50) NULL,
	[a22] [nvarchar](50) NULL,
	[a23] [nvarchar](50) NULL,
	[a24] [nvarchar](50) NULL,
	[a25] [nvarchar](50) NULL,
	[a26] [nvarchar](50) NULL,
	[a27] [nvarchar](50) NULL,
	[a28] [nvarchar](50) NULL,
	[a29] [nvarchar](50) NULL,
	[a30] [nvarchar](50) NULL,
	[a31] [nvarchar](50) NULL,
	[a32] [nvarchar](50) NULL,
	[a33] [nvarchar](50) NULL,
	[a34] [nvarchar](50) NULL,
	[a35] [nvarchar](50) NULL,
	[a36] [nvarchar](50) NULL,
	[a37] [nvarchar](50) NULL,
	[a38] [nvarchar](50) NULL,
	[a39] [nvarchar](50) NULL,
	[a40] [nvarchar](50) NULL,
	[a41] [nvarchar](50) NULL,
	[a42] [nvarchar](50) NULL,
	[a43] [nvarchar](50) NULL,
	[a44] [nvarchar](50) NULL,
	[a45] [nvarchar](50) NULL,
	[a46] [nvarchar](50) NULL,
	[a47] [nvarchar](50) NULL,
	[a48] [nvarchar](50) NULL,
	[a49] [nvarchar](50) NULL,
	[a50] [nvarchar](50) NULL,
	[a51] [nvarchar](50) NULL,
 CONSTRAINT [PK_DB_SBTZ] PRIMARY KEY CLUSTERED 
(
	[sb_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

/****** 对象:  Index [Index_2]    脚本日期: 03/06/2013 10:21:04 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[BD_SBTZ]') AND name = N'Index_2')
CREATE NONCLUSTERED INDEX [Index_2] ON [dbo].[BD_SBTZ] 
(
	[OrgCode] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO

/****** 对象:  Index [IX_BD_SBTZ_type]    脚本日期: 03/06/2013 10:21:04 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[BD_SBTZ]') AND name = N'IX_BD_SBTZ_type')
CREATE NONCLUSTERED INDEX [IX_BD_SBTZ_type] ON [dbo].[BD_SBTZ] 
(
	[sbtype] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变电站代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电压等级' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'sbvol'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备种类' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'sbtype'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'sbname'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备单元' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'sbunit'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检修周期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'jxzq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备种类' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'a1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'a2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备型号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'a3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序列号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'a4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出产日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'a5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'投产日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'a6'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产厂家' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'a7'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'大修日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'BD_SBTZ', @level2type=N'COLUMN', @level2name=N'a8'

GO
/****** 对象:  Table [dbo].[rRoleOrg]    脚本日期: 03/06/2013 10:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rRoleOrg]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[rRoleOrg](
	[RoleID] [nvarchar](50) NOT NULL,
	[OrgID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_rRoleOrg] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[OrgID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** 对象:  View [dbo].[vRoleOrg]    脚本日期: 03/06/2013 10:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vRoleOrg]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vRoleOrg]
AS
SELECT     dbo.mOrg.OrgID, dbo.mOrg.ParentID, dbo.mOrg.OrgCode, dbo.mOrg.OrgName, dbo.mOrg.OrgType, dbo.mRole.RoleID, dbo.mRole.RoleCode, dbo.mRole.RoleName, 
                      dbo.mRole.RoleType
FROM         dbo.mOrg INNER JOIN
                      dbo.rRoleOrg ON dbo.mOrg.OrgID = dbo.rRoleOrg.OrgID INNER JOIN
                      dbo.mRole ON dbo.rRoleOrg.RoleID = dbo.mRole.RoleID
' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[59] 4[3] 2[21] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "mOrg"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 243
               Right = 178
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "mRole"
            Begin Extent = 
               Top = 5
               Left = 583
               Bottom = 214
               Right = 722
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "rRoleOrg"
            Begin Extent = 
               Top = 2
               Left = 307
               Bottom = 89
               Right = 446
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'vRoleOrg'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'vRoleOrg'

GO
USE [ebadascgl]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_rRoleOrg_mOrg]') AND parent_object_id = OBJECT_ID(N'[dbo].[rRoleOrg]'))
ALTER TABLE [dbo].[rRoleOrg]  WITH CHECK ADD  CONSTRAINT [FK_rRoleOrg_mOrg] FOREIGN KEY([OrgID])
REFERENCES [dbo].[mOrg] ([OrgID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_rRoleOrg_mRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[rRoleOrg]'))
ALTER TABLE [dbo].[rRoleOrg]  WITH CHECK ADD  CONSTRAINT [FK_rRoleOrg_mRole] FOREIGN KEY([RoleID])
REFERENCES [dbo].[mRole] ([RoleID])
ON UPDATE CASCADE
ON DELETE CASCADE
