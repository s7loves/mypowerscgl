--����¼
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'zcr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ʼʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'hdkssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'hdjssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ϯ��Ա' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'cxry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ȱϯ��Ա' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'qxry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'hdnr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�С��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'hdxj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�쵼�������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'ldjcpy'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ȫ���¼��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_aqhdjlb'

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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'blqmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'dzrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'dzsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A�������ָʾ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'Axjsqzss'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'B�������ָʾ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'Bxjsqzss'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'C�������ָʾ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'Cxjsqzss'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'jlr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ԭ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'dzyy'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������������¼����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_blqdzjlcs'

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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'dDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����Ʊʹ�ñ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'czpsybh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'czr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�໤��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'jhr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ִ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'zbr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'czrw'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����Ʊ�Ǽǲ�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_czpdjb'

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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'lb'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʼʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'kssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'dd'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'bds'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ָ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'zlbh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'nr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ֹʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'zzsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���Ȳ���ָ���¼��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_ddzczl'

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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ϰ�ص�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'yxdd'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ϰ��Ŀ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'yxtm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ϰ��ʼʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'yxkssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ϰ����ʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'yxjssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�μ���Ա' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'cjry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'cljg'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������⼰����ȡ�Ĵ�ʩ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'wtjcs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ۼ�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'jljpj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���¹���ϰ��¼��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_fsgyxjlb'

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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzjlzb', @level2type=N'COLUMN', @level2name=N'sj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzjlzb', @level2type=N'COLUMN', @level2name=N'nr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzjlzb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzjlzb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzjlzb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���й�����¼�ӱ�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzjlzb'

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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����Ʊ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'gzpbh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����Ʊ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'gzpzl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'gzpfzr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������ʼʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'gzkssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������ʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'gzjssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'gzxkr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ֵ�೤' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'zbz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����Ʊǩ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'gzpqfr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ص㼰��������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'gzddjnr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����Ʊ�Ǽǲ�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_gzpdjb'

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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��·����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'lineCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'sbmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'rq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�̵縺����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'jdfzr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ֵ���˼�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'zbrjsz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������ݼ�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'tsnrjjl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�̵籣����¼' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_jdbhjl'

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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��·����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'lineCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'kgmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��բ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'tzrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��բʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'tzsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ģʽ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'kgms'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��·�����������բ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'dlqyxgztzcs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�¹���բ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'sgtzcs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ֶ���բ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'sdfzcs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'jlr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������غ�բ�����������բԭ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'bhzhzzdqk'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������բ��¼' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_kgtzjl'

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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��·����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'lineCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'jxrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'sbmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'jxxz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���޸�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'jxfzr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'ysr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������Ŀ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'jxxm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'ysyj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸���޼�¼' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbjxjl'

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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'sbmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ȱ�ݱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'qxbh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'fxrq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'fxr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ȱ�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'qxlb'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ȱ������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'qxnr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸ȱ�ݼ�¼' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sbqxjl'

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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'tq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�μ���Ա' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'cjry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʱ���з�ʽ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'dsyxfs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ԥ����Ŀ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'yxtm'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�¹�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'sgxx'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'clbz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'shyj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�¹�Ԥ���¼��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgyxjlb'

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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'fssj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'xz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'jt'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'fsjg'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�¹���ʧ���(���͵���)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'sgsxqk'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ԭ�򼰸������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'yyjfzfx'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Բ�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'dc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�¹ʡ��ϰ����쳣���м�¼��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_sgzayc'

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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'sj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ص�ѹ(��)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'dcdy'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����(��)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'dl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ͷ���ظ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'trdcgs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��׼��ص�ѹ(��)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'bzdcdy'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'jcr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ص���������¼��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdctzjlb'

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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�޵�ʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'xdsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�޵緢����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'xdflr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�޵�������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'xdslr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�޵���·' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'xdxl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�޵����(A)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'xddl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�͵�ʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'sdsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�͵緢����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'sdflr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�͵�������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'sdslr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�͵�ʱ����(A)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'xdsdl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�޵��ۺϵ���(KWH)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'xdzhdl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'bz'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�޵��¼' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_xdjl'

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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�μ���Ա' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'cjry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'nr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'jl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb', @level2type=N'COLUMN', @level2name=N'sj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���з�����¼' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxfxjlb'

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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ฺ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'jbfzr'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������Ա' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'jbry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ӱฺ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'jbfzry'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ӱ���Ա' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'jbryy'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'rq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'tq'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���й�����¼��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'bdjl_yxgzjlb'

