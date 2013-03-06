USE [ebadascgl]
go
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('�͵����','','','0','','','',1,0,'','','20130116170504855125','0','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('�豸����','Ebada.Scgl.Sbgl.UCsd_gtM','Ebada.Scgl.Sbgl.dll','1','','','',1,0,'','','20130116170523917625','20130116170504855125','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('��·����','Ebada.Scgl.Sbgl.UCsd_xlTree','Ebada.Scgl.Sbgl.dll','0','','','',1,0,'','','20130116170610292625','20130116170504855125','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('�豸����','Ebada.Scgl.Sbgl.UCsd_sbcsM','Ebada.Scgl.Sbgl.dll','3','','','',1,0,'','','20130219061227096452','20130116170504855125','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('�����·�����޸�','Ebada.Scgl.Sbgl.frmLinewh','Ebada.Scgl.Sbgl.DLL','80','','','',1,0,'','','20130222153514112625','20110510171217589125','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('��ѹ̨�������޸�','Ebada.Scgl.Sbgl.frmLineTQwh','Ebada.Scgl.Sbgl.DLL','90','','','',1,0,'','','20130223170535321500','20110510171217589125','')
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sd_gtsb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sd_gtsb](
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
 CONSTRAINT [PK_SD_GTSB] PRIMARY KEY CLUSTERED 
(
	[sbID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsb', @level2type=N'COLUMN', @level2name=N'gtID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsb', @level2type=N'COLUMN', @level2name=N'sbID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsb', @level2type=N'COLUMN', @level2name=N'sbCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsb', @level2type=N'COLUMN', @level2name=N'sbType'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸�ͺ�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsb', @level2type=N'COLUMN', @level2name=N'sbModle'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsb', @level2type=N'COLUMN', @level2name=N'sbName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsb', @level2type=N'COLUMN', @level2name=N'sbNumber'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsb', @level2type=N'COLUMN', @level2name=N'C1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸����2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsb', @level2type=N'COLUMN', @level2name=N'C2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸����3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsb', @level2type=N'COLUMN', @level2name=N'C3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸����4' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsb', @level2type=N'COLUMN', @level2name=N'C4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸����5' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsb', @level2type=N'COLUMN', @level2name=N'C5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����豸' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsb'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sd_gtsbclb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sd_gtsbclb](
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
 CONSTRAINT [PK_SD_GTSBCLB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsbclb', @level2type=N'COLUMN', @level2name=N'bh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsbclb', @level2type=N'COLUMN', @level2name=N'mc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸�ͺ�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsbclb', @level2type=N'COLUMN', @level2name=N'xh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsbclb', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ParentID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsbclb', @level2type=N'COLUMN', @level2name=N'ParentID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsbclb', @level2type=N'COLUMN', @level2name=N'S1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsbclb', @level2type=N'COLUMN', @level2name=N'S2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsbclb', @level2type=N'COLUMN', @level2name=N'S3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsbclb', @level2type=N'COLUMN', @level2name=N'zl'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsbclb', @level2type=N'COLUMN', @level2name=N'zlCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����������͹���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gtsbclb'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sd_xl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sd_xl](
	[LineID] [nvarchar](50) NOT NULL,
	[ParentID] [nvarchar](50) NULL,
	[LineType] [nvarchar](50) NULL,
	[LineCode] [nvarchar](50) NULL,
	[LineName] [nvarchar](50) NULL,
	[LineNamePath] [nvarchar](250) NULL,
	[LineVol] [nvarchar](50) NULL,
	[OrgCode] [nvarchar](50) NULL,
	[OrgCode2] [nvarchar](50) NULL,
	[Owner] [nvarchar](50) NULL,
	[Contractor] [nvarchar](50) NULL,
	[RunState] [nvarchar](50) NULL,
	[InDate] [datetime] NULL,
	[LineGtbegin] [nvarchar](50) NULL,
	[LineGtend] [nvarchar](50) NULL,
	[WireType] [nvarchar](50) NULL,
	[WireLength] [int] NULL,
	[TotalLength] [int] NULL,
	[gdbj] [int] NULL,
	[TheoryLoss] [decimal](18, 5) NULL,
	[ActualLoss] [decimal](8, 5) NULL,
	[ParentGT] [nvarchar](50) NULL,
	[LineP] [decimal](18, 5) NULL,
	[LineQ] [decimal](18, 5) NULL,
	[K] [decimal](8, 5) NULL,
	[lineKind] [nvarchar](50) NULL,
	[lineNum] [nvarchar](50) NULL,
	[TotalT] [decimal](18, 5) NULL,
	[SectionalizedMessage] [nvarchar](1000) NULL,
	[xlpy] [nvarchar](50) NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
	[c3] [nvarchar](50) NULL,
	[c4] [nvarchar](50) NULL,
	[c5] [nvarchar](50) NULL,
	[c6] [nvarchar](50) NULL,
	[c7] [nvarchar](50) NULL,
	[c8] [nvarchar](50) NULL,
	[c9] [nvarchar](50) NULL,
 CONSTRAINT [PK_SD_XL] PRIMARY KEY CLUSTERED 
(
	[LineID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[sd_xl]') AND name = N'Index_1')
CREATE UNIQUE NONCLUSTERED INDEX [Index_1] ON [dbo].[sd_xl] 
(
	[LineCode] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[sd_xl]') AND name = N'Index_2')
CREATE NONCLUSTERED INDEX [Index_2] ON [dbo].[sd_xl] 
(
	[ParentID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��·ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'LineID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ParentID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'ParentID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��·����,1����/2֧��/3����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'LineType'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��·���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'LineCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��·����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'LineName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��··��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'LineNamePath'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ѹ�ȼ�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'LineVol'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'OrgCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'OrgCode2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ȩ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'Owner'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�а���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'Contractor'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����״̬' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'RunState'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ͷ������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'InDate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʼ�˺�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'LineGtbegin'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ֹ�˺�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'LineGtend'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ͺ�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'WireType'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��·����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'WireLength'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ܳ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'TotalLength'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����뾶' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'gdbj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'TheoryLoss'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʵ������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'ActualLoss'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��·����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'lineKind'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��·��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'lineNum'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ͷ������ʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'TotalT'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��·�ֶ���Ϣ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'SectionalizedMessage'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��·ƴ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'xlpy'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'c6'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'c7'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'c8'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl', @level2type=N'COLUMN', @level2name=N'c9'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�͵���·' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_xl'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sd_sbcs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sd_sbcs](
	[bh] [nvarchar](50) NULL,
	[mc] [nvarchar](50) NULL,
	[xh] [nvarchar](50) NULL,
	[ID] [nvarchar](50) NOT NULL,
	[ParentID] [nvarchar](50) NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
	[c3] [nvarchar](50) NULL,
 CONSTRAINT [PK_SD_SBCS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_sbcs', @level2type=N'COLUMN', @level2name=N'bh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_sbcs', @level2type=N'COLUMN', @level2name=N'mc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸�ͺ�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_sbcs', @level2type=N'COLUMN', @level2name=N'xh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_sbcs', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ParentID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_sbcs', @level2type=N'COLUMN', @level2name=N'ParentID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����,�豸������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_sbcs', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ԥ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_sbcs', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ԥ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_sbcs', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�豸�ͺſ�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_sbcs'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sd_gt]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sd_gt](
	[gtID] [nvarchar](50) NOT NULL,
	[LineCode] [nvarchar](50) NULL,
	[gtCode] [nvarchar](50) NULL,
	[gth] [nvarchar](10) NULL,
	[gtType] [nvarchar](50) NULL,
	[gtModle] [nvarchar](50) NULL,
	[gtHeight] [decimal](5, 1) NULL,
	[gtLon] [decimal](12, 8) NULL,
	[gtLat] [decimal](12, 8) NULL,
	[gtElev] [int] NULL,
	[X54] [int] NULL,
	[Y54] [int] NULL,
	[gtSpan] [decimal](5, 1) NULL,
	[gtMs] [decimal](5, 1) NULL,
	[gtZjfx] [nvarchar](10) NULL,
	[gtZj] [nvarchar](10) NULL,
	[gtJg] [nvarchar](1) NULL,
	[ImageID] [nvarchar](150) NULL,
	[dxplfs] [nvarchar](50) NULL,
	[gtNum] [int] NULL,
	[gtSpan2] [decimal](5, 1) NULL,
	[gtSpan3] [decimal](5, 1) NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
	[c3] [nvarchar](50) NULL,
	[c4] [nvarchar](50) NULL,
	[c5] [nvarchar](50) NULL,
	[c6] [nvarchar](50) NULL,
	[c7] [nvarchar](50) NULL,
	[c8] [nvarchar](50) NULL,
	[c9] [nvarchar](50) NULL,
 CONSTRAINT [PK_SD_GT] PRIMARY KEY CLUSTERED 
(
	[gtID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[sd_gt]') AND name = N'Index_1')
CREATE UNIQUE NONCLUSTERED INDEX [Index_1] ON [dbo].[sd_gt] 
(
	[gtCode] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gtID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��·���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'LineCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������,��·���+������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gtCode'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gth'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gtType'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ͺ�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gtModle'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˸�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gtHeight'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gtLon'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'γ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gtLat'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�߳�' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gtElev'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'X54'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'γ��2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'Y54'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gtSpan'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gtMs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ת�Ƿ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gtZjfx'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ת��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gtZj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gtJg'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������з�ʽ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'dxplfs'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gtNum'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ˮƽ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gtSpan2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ֱ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'gtSpan3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ߵ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ӵ���ʽ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'c3'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'c4'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'c5'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'c6'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'c7'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'c8'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt', @level2type=N'COLUMN', @level2name=N'c9'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�͵��豸����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'sd_gt'

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SD_GT_REFERENCE_SD_XL]') AND parent_object_id = OBJECT_ID(N'[dbo].[sd_gt]'))
ALTER TABLE [dbo].[sd_gt]  WITH CHECK ADD  CONSTRAINT [FK_SD_GT_REFERENCE_SD_XL] FOREIGN KEY([LineCode])
REFERENCES [dbo].[sd_xl] ([LineCode])
ON UPDATE CASCADE
ON DELETE CASCADE
