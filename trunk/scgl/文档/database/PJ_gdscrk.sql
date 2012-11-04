USE [EbadaScgl]
GO
/****** Object:  Table [dbo].[PJ_gdscrk]    Script Date: 2012/11/4 14:00:54 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Trigger [dbo].[tri_gdscrkd]    Script Date: 2012/11/4 14:00:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tri_gdscrkd]
   ON [dbo].[PJ_gdscrk]
   AFTER INSERT
AS 
BEGIN
	declare @ID varchar(50),@OrgCode varchar(50),@wpmc varchar(50),@wpgg varchar(50),@wpdw varchar(50),@wpsl varchar(50),
			@cksl int,@type varchar(50),@kcsl int,@rkslcount int,@ckslcount int,@InseredID varchar(50);
	select @InseredID=ID,@OrgCode=OrgCode,@wpmc=wpmc,@wpgg=wpgg,@wpdw=wpdw,@wpsl=wpsl,@cksl=cksl,@type=type from inserted;
	if(@type='原始入库材料')
		begin
			update PJ_gdscrk set kcsl='0',wpsl='0',cksl='0',rkslcount='0',ckslcount='0',kcslcount='0' where ID=@InseredID;
		end
	else
		begin
			select @ID=ID from  PJ_gdscrk where OrgCode=@OrgCode and type='原始入库材料' and wpmc=@wpmc and wpgg=@wpgg and wpdw=@wpdw;
			select @rkslcount=isnull(sum(cast(wpsl as int)),0) from PJ_gdscrk where OrgCode=@OrgCode and type='设置库存' and wpmc=@wpmc and wpgg=@wpgg and wpdw=@wpdw;
			select @ckslcount=isnull(sum(cast(cksl as int)),0) from PJ_gdscrk where OrgCode=@OrgCode and type='出库' and wpmc=@wpmc and wpgg=@wpgg and wpdw=@wpdw;
			select @kcsl=@rkslcount - @ckslcount;
			update PJ_gdscrk set rkslcount=@rkslcount,ckslcount=@ckslcount,kcslcount=@kcsl where ID=@InseredID;
			update PJ_gdscrk set kcsl=@kcsl,wpsl=@rkslcount,cksl=@ckslcount where ID=@ID;
		end
END
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
