USE [EbadaScgl]
GO
/****** Object:  Table [dbo].[PJ_gdscrk]    Script Date: 11/08/2012 13:29:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PJ_gdscrk](
	[ID] [nvarchar](50) NOT NULL,
	[num] [nvarchar](50) NULL,
	[OrgCode] [nvarchar](50) NULL,
	[wpmc] [nvarchar](50) NULL,
	[wpgg] [nvarchar](50) NULL,
	[wpdw] [nvarchar](50) NULL,
	[wpsl] [nvarchar](50) NULL,
	[wpdj] [nvarchar](50) NULL,
	[wpcj] [nvarchar](50) NULL,
	[ly] [nvarchar](50) NULL,
	[indate] [datetime] NULL,
	[ckdate] [datetime] NULL,
	[cksl] [nvarchar](50) NULL,
	[yt] [nvarchar](50) NULL,
	[Remark] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
	[lasttime] [datetime] NULL,
	[kcsl] [nvarchar](50) NULL,
	[rkslcount] [varchar](50) NULL,
	[ckslcount] [varchar](50) NULL,
	[kcslcount] [varchar](50) NULL,
 CONSTRAINT [PK_Pj_gdscrk] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出入库单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_gdscrk', @level2type=N'COLUMN',@level2name=N'num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_gdscrk', @level2type=N'COLUMN',@level2name=N'OrgCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_gdscrk', @level2type=N'COLUMN',@level2name=N'wpmc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物品规格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_gdscrk', @level2type=N'COLUMN',@level2name=N'wpgg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物品单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_gdscrk', @level2type=N'COLUMN',@level2name=N'wpdw'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_gdscrk', @level2type=N'COLUMN',@level2name=N'wpsl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单价(单位:元)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_gdscrk', @level2type=N'COLUMN',@level2name=N'wpdj'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'厂家' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_gdscrk', @level2type=N'COLUMN',@level2name=N'wpcj'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_gdscrk', @level2type=N'COLUMN',@level2name=N'ly'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_gdscrk', @level2type=N'COLUMN',@level2name=N'indate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_gdscrk', @level2type=N'COLUMN',@level2name=N'ckdate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_gdscrk', @level2type=N'COLUMN',@level2name=N'cksl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用途' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_gdscrk', @level2type=N'COLUMN',@level2name=N'yt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_gdscrk', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_gdscrk', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_gdscrk', @level2type=N'COLUMN',@level2name=N'lasttime'
GO
/****** Object:  Trigger [insert_pj_gdscrk]    Script Date: 11/08/2012 13:29:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[insert_pj_gdscrk]
   ON  [dbo].[PJ_gdscrk]
   AFTER INSERT
AS 
BEGIN
	declare @InsertedID varchar(50),@OrgCode varchar(50),@wpmc varchar(50),@wpgg varchar(50),@wpdw varchar(50),@ID varchar(50),@rkcount float,@ckcount float,@kccount float;
	select @InsertedID=ID,@OrgCode=OrgCode,@wpmc=wpmc,@wpgg=wpgg,@wpdw=wpdw from inserted;
	select @rkcount=isnull(sum(cast(wpsl as float)),0) from pj_gdscrk where OrgCode=@OrgCode and wpmc=@wpmc and wpgg=@wpgg and wpdw=@wpdw and type='入库';
	select @ckcount=isnull(sum(cast(cksl as float)),0) from pj_gdscrk where OrgCode=@OrgCode and wpmc=@wpmc and wpgg=@wpgg and wpdw=@wpdw and type='出库';
	select @kccount=@rkcount-@ckcount;
	update pj_gdscrk set kcsl=@kccount,rkslcount=@rkcount,ckslcount=@ckcount,kcslcount=@kccount where ID=@InsertedID;
END
GO
