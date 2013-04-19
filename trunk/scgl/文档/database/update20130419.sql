--变电记录
use ebadascgl
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_aqhdjlb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_aqhdjlb](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[zcr] [nvarchar](50) NULL,
	[hdkssj] [nvarchar](50) NULL,
	[hdjssj] [nvarchar](50) NULL,
	[cxry] [nvarchar](500) NULL,
	[qxry] [nvarchar](500) NULL,
	[hdnr] [nvarchar](500) NULL,
	[hdxj] [nvarchar](500) NULL,
	[ldjcpy] [nvarchar](500) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
 CONSTRAINT [PK_BDJL_AQHDJLB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主持人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'zcr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动开始时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'hdkssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动结束时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'hdjssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出席人员' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'cxry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺席人员' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'qxry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'hdnr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动小结' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'hdxj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领导检查评语' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'ldjcpy'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'安全活动记录簿' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_blqdzjlcs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_blqdzjlcs](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[blqmc] [nvarchar](50) NULL,
	[dzrq] [datetime] NULL,
	[dzsj] [datetime] NULL,
	[Axjsqzss] [nvarchar](50) NULL,
	[Bxjsqzss] [nvarchar](50) NULL,
	[Cxjsqzss] [nvarchar](50) NULL,
	[jlr] [nvarchar](50) NULL,
	[dzyy] [nvarchar](500) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
 CONSTRAINT [PK_BDJL_BLQDZJLCS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'避雷器名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'blqmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'动作日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'dzrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'动作时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'dzsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A相计数器指示数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'Axjsqzss'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'B相计数器指示数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'Bxjsqzss'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'C相计数器指示数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'Cxjsqzss'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'jlr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'动作原因' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'dzyy'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'避雷器动作记录次数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_czpdjb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_czpdjb](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[dDate] [datetime] NULL,
	[czpsybh] [nvarchar](50) NULL,
	[czr] [nvarchar](50) NULL,
	[jhr] [nvarchar](50) NULL,
	[zbr] [nvarchar](50) NULL,
	[czrw] [nvarchar](500) NULL,
	[c1] [nvarchar](200) NULL,
	[c2] [nvarchar](200) NULL,
	[c3] [nvarchar](200) NULL,
 CONSTRAINT [PK_BDJL_CZPDJB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'dDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作票使用编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'czpsybh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'czr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'监护人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'jhr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'zbr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作任务' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'czrw'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作票登记簿' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_ddzczl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_ddzczl](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[lb] [nvarchar](50) NULL,
	[kssj] [nvarchar](50) NULL,
	[dd] [nvarchar](50) NULL,
	[bds] [nvarchar](50) NULL,
	[zlbh] [nvarchar](50) NULL,
	[nr] [nvarchar](500) NULL,
	[zzsj] [nvarchar](500) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
 CONSTRAINT [PK_BDJL_DDZCZL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'令别' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'lb'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'kssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'调度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'dd'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变电所' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'bds'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'指令编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'zlbh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'nr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'终止时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'zzsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'调度操作指令记录簿' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_fsgyxjlb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_fsgyxjlb](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[yxdd] [nvarchar](50) NULL,
	[yxtm] [nvarchar](50) NULL,
	[yxkssj] [nvarchar](50) NULL,
	[yxjssj] [nvarchar](50) NULL,
	[cjry] [nvarchar](50) NULL,
	[cljg] [nvarchar](500) NULL,
	[wtjcs] [nvarchar](500) NULL,
	[jljpj] [nvarchar](500) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
 CONSTRAINT [PK_BDJL_FSGYXJLB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'演习地点' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'yxdd'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'演习题目' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'yxtm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'演习开始时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'yxkssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'演习结束时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'yxjssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参加人员' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'cjry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理经过' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'cljg'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发现问题及今后采取的措施' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'wtjcs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结论及评价' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'jljpj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'反事故演习记录簿' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_gzjlzb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_gzjlzb](
	[ID] [nvarchar](50) NOT NULL,
	[ParentID] [nvarchar](50) NULL,
	[sj] [nvarchar](50) NULL,
	[nr] [nvarchar](500) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
 CONSTRAINT [PK_BDJL_GZJLZB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzjlzb', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ParentID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzjlzb', @level2type=N'COLUMN', @level2name=N'ParentID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzjlzb', @level2type=N'COLUMN', @level2name=N'sj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzjlzb', @level2type=N'COLUMN', @level2name=N'nr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzjlzb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzjlzb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzjlzb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运行工作记录子表' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzjlzb'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_gzpdjb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_gzpdjb](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[gzpbh] [nvarchar](50) NULL,
	[gzpzl] [nvarchar](50) NULL,
	[gzpfzr] [nvarchar](50) NULL,
	[gzkssj] [datetime] NULL,
	[gzjssj] [datetime] NULL,
	[gzxkr] [nvarchar](50) NULL,
	[zbz] [nvarchar](50) NULL,
	[gzpqfr] [nvarchar](50) NULL,
	[gzddjnr] [nvarchar](500) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
 CONSTRAINT [PK_BDJL_GZPDJB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作票编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'gzpbh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作票种类' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'gzpzl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作负责人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'gzpfzr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作开始时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'gzkssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作结束时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'gzjssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作许可人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'gzxkr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值班长' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'zbz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作票签发人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'gzpqfr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作地点及工作内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'gzddjnr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作票登记簿' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_jdbhjl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_jdbhjl](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[lineCode] [nvarchar](500) NULL,
	[sbmc] [nvarchar](50) NULL,
	[rq] [datetime] NULL,
	[jdfzr] [nvarchar](50) NULL,
	[zbrjsz] [nvarchar](50) NULL,
	[tsnrjjl] [nvarchar](500) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
 CONSTRAINT [PK_BDJL_JDBHJL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'lineCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'sbmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'rq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'继电负责人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'jdfzr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值班人及所长' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'zbrjsz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'调试内容及结论' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'tsnrjjl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'继电保护记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_kgtzjl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_kgtzjl](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[lineCode] [nvarchar](50) NULL,
	[kgmc] [nvarchar](50) NULL,
	[tzrq] [datetime] NULL,
	[tzsj] [datetime] NULL,
	[kgms] [nvarchar](50) NULL,
	[dlqyxgztzcs] [int] NULL,
	[sgtzcs] [int] NULL,
	[sdfzcs] [int] NULL,
	[jlr] [nvarchar](50) NULL,
	[bhzhzzdqk] [nvarchar](500) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
 CONSTRAINT [PK_BDJL_KGTZJL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'lineCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开关名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'kgmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'跳闸日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'tzrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'跳闸时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'tzsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开关模式' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'kgms'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'断路器允许故障跳闸次数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'dlqyxgztzcs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事故跳闸次数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'sgtzcs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手动分闸次数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'sdfzcs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'jlr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保护、重合闸动作情况及跳闸原因' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'bhzhzzdqk'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开关跳闸记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_sbjxjl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_sbjxjl](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[lineCode] [nvarchar](50) NULL,
	[jxrq] [datetime] NULL,
	[sbmc] [nvarchar](50) NULL,
	[jxxz] [nvarchar](50) NULL,
	[jxfzr] [nvarchar](50) NULL,
	[ysr] [nvarchar](50) NULL,
	[jxxm] [nvarchar](50) NULL,
	[ysyj] [nvarchar](50) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
 CONSTRAINT [PK_BDJL_SBJXJL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'lineCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检修日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'jxrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'sbmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检修性质' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'jxxz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检修负责人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'jxfzr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'验收人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'ysr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检修项目' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'jxxm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'验收意见' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'ysyj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备检修记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_sbqxjl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_sbqxjl](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[sbmc] [nvarchar](50) NULL,
	[qxbh] [nvarchar](50) NULL,
	[fxrq] [datetime] NULL,
	[fxr] [nvarchar](50) NULL,
	[qxlb] [nvarchar](50) NULL,
	[qxnr] [nvarchar](500) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
 CONSTRAINT [PK_BDJL_SBQXJL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'sbmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'qxbh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发现日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'fxrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发现人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'fxr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷类别' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'qxlb'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'qxnr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备缺陷记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_sgyxjlb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_sgyxjlb](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[tq] [nvarchar](50) NULL,
	[cjry] [nvarchar](50) NULL,
	[dsyxfs] [nvarchar](50) NULL,
	[yxtm] [nvarchar](500) NULL,
	[sgxx] [nvarchar](500) NULL,
	[clbz] [nvarchar](500) NULL,
	[shyj] [nvarchar](500) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
 CONSTRAINT [PK_BDJL_SGYXJLB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'天气' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'tq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参加人员' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'cjry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当时运行方式' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'dsyxfs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预想题目' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'yxtm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事故现象' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'sgxx'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理步骤' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'clbz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核意见' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'shyj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事故预想记录簿' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_sgzayc]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_sgzayc](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[fssj] [nvarchar](50) NULL,
	[xz] [nvarchar](50) NULL,
	[jt] [nvarchar](50) NULL,
	[fsjg] [nvarchar](500) NULL,
	[sgsxqk] [nvarchar](500) NULL,
	[yyjfzfx] [nvarchar](500) NULL,
	[dc] [nvarchar](500) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
 CONSTRAINT [PK_BDJL_SGZAYC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发生时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'fssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性质' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'xz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'简题' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'jt'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发生经过' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'fsjg'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事故损失情况(少送电量)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'sgsxqk'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原因及负责分析' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'yyjfzfx'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对策' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'dc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事故、障碍及异常运行记录簿' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_xdctzjlb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_xdctzjlb](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[sj] [datetime] NULL,
	[dcdy] [nvarchar](50) NULL,
	[dl] [nvarchar](50) NULL,
	[trdcgs] [nvarchar](50) NULL,
	[bzdcdy] [nvarchar](50) NULL,
	[jcr] [nvarchar](50) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
 CONSTRAINT [PK_BDJL_XDCTZJLB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'sj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电池电压(伏)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'dcdy'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电流(安)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'dl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'投入电池个数' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'trdcgs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准电池电压(伏)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'bzdcdy'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检测人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'jcr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'蓄电池调整及检测记录簿' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_xdjl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_xdjl](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[xdsj] [datetime] NULL,
	[xdflr] [nvarchar](50) NULL,
	[xdslr] [nvarchar](50) NULL,
	[xdxl] [nvarchar](50) NULL,
	[xddl] [nvarchar](50) NULL,
	[sdsj] [datetime] NULL,
	[sdflr] [nvarchar](50) NULL,
	[sdslr] [nvarchar](50) NULL,
	[xdsdl] [nvarchar](50) NULL,
	[xdzhdl] [nvarchar](50) NULL,
	[bz] [nvarchar](500) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
 CONSTRAINT [PK_BDJL_XDJL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'限电时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'xdsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'限电发令人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'xdflr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'限电受令人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'xdslr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'限电线路' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'xdxl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'限电电流(A)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'xddl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'sdsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电发令人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'sdflr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电受令人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'sdslr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送电时电流(A)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'xdsdl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'限电折合电量(KWH)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'xdzhdl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'bz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'限电记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_yxfxjlb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_yxfxjlb](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[cjry] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
	[nr] [nvarchar](500) NULL,
	[jl] [nvarchar](500) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[sj] [datetime] NULL,
 CONSTRAINT [PK_BDJL_YXFXJLB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参加人员' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'cjry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'nr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结论' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'jl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'sj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运行分析记录' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bdjl_yxgzjlb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bdjl_yxgzjlb](
	[ID] [nvarchar](50) NOT NULL,
	[OrgCode] [nvarchar](50) NULL,
	[jbfzr] [nvarchar](50) NULL,
	[jbry] [nvarchar](50) NULL,
	[jbfzry] [nvarchar](50) NULL,
	[jbryy] [nvarchar](50) NULL,
	[rq] [nvarchar](50) NULL,
	[tq] [nvarchar](50) NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
 CONSTRAINT [PK_BDJL_YXGZJLB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位代码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交班负责人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'jbfzr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交班人员' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'jbry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接班负责人' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'jbfzry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接班人员' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'jbryy'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'rq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'天气' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'tq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运行工作记录簿' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb'

