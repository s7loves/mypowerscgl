USE [ebadascgl]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[xxgx_aqxpj]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[xxgx_aqxpj](
	[id] [nvarchar](50) NOT NULL,
	[orgcode] [nvarchar](50) NULL,
	[year] [nvarchar](50) NULL,
	[filename] [nvarchar](50) NULL,
	[scsj] [nvarchar](50) NULL,
	[scry] [nvarchar](50) NULL,
	[filedata] [image] NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
	[c3] [nvarchar](50) NULL,
 CONSTRAINT [PK_xxgx_aqxpj] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ļ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_aqxpj', @level2type=N'COLUMN', @level2name=N'filename'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_aqxpj', @level2type=N'COLUMN', @level2name=N'scsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_aqxpj', @level2type=N'COLUMN', @level2name=N'scry'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[xxgx_ycjc]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[xxgx_ycjc](
	[id] [nvarchar](50) NOT NULL,
	[sj] [nvarchar](50) NULL,
	[xlmc] [nvarchar](50) NULL,
	[jldmc] [nvarchar](50) NULL,
	[bh] [nvarchar](50) NULL,
	[zxygzdn] [float] NULL,
	[fl1zxygdn] [float] NULL,
	[fl2zxygdn] [float] NULL,
	[fl3zxygdn] [float] NULL,
	[fl4zxygdn] [float] NULL,
	[fxygzdn] [float] NULL,
	[fl1fxygdn] [float] NULL,
	[fl2fxygdn] [float] NULL,
	[fl3fxygdn] [float] NULL,
	[fl4fxygdn] [float] NULL,
	[zxwgzdn] [float] NULL,
	[fl1zxwgdn] [float] NULL,
	[fl2zxwgdn] [float] NULL,
	[fl3zxwgdn] [float] NULL,
	[fl4zxwgdn] [float] NULL,
	[fxwgzdn] [float] NULL,
	[fl1fxwgdn] [float] NULL,
	[fl2fxwgdn] [float] NULL,
	[fl3fxwgdn] [float] NULL,
	[fl4fxwgdn] [float] NULL,
	[wgdn] [float] NULL,
	[c1] [nvarchar](500) NULL,
	[c2] [nvarchar](500) NULL,
	[c3] [nvarchar](500) NULL,
 CONSTRAINT [PK_xxgx_ycjc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'sj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��·����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'xlmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'jldmc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'bh'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����й��ܵ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'zxygzdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����1�����й�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fl1zxygdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����2�����й�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fl2zxygdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����3�����й�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fl3zxygdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����4�����й�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fl4zxygdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����й��ܵ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fxygzdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����1�����й�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fl1fxygdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����2�����й�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fl2fxygdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����3�����й�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fl3fxygdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����4�����й�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fl4fxygdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����޹��ܵ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'zxwgzdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����1�����޹�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fl1zxwgdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����2�����޹�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fl2zxwgdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����3�����޹�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fl3zxwgdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����4�����޹�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fl4zxwgdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����޹��ܵ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fxwgzdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����1�����޹�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fl1fxwgdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����2�����޹�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fl2fxwgdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����3�����޹�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fl3fxwgdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����4�����޹�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'fl4fxwgdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�޹�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'wgdn'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'c1'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'c2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�3' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ycjc', @level2type=N'COLUMN', @level2name=N'c3'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[xxgx_sbnb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[xxgx_sbnb](
	[id] [nvarchar](50) NOT NULL,
	[orgcode] [nvarchar](50) NULL,
	[year] [nvarchar](50) NULL,
	[filename] [nvarchar](50) NULL,
	[scsj] [nvarchar](50) NULL,
	[scry] [nvarchar](50) NULL,
	[filedata] [image] NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
	[c3] [nvarchar](50) NULL,
 CONSTRAINT [PK_xxgx_sbnb] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ļ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_sbnb', @level2type=N'COLUMN', @level2name=N'filename'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_sbnb', @level2type=N'COLUMN', @level2name=N'scsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_sbnb', @level2type=N'COLUMN', @level2name=N'scry'

go


alter table dbo.PJ_21gzbxdh add xcbj nvarchar(50) default 'δ����'
go
alter table dbo.pj_21gzbxdh add jd float default 0,wd float default 0
go
alter table dbo.pj_21gzbxdh add LineID nvarchar(50),tqID nvarchar(50)
go
update PJ_21gzbxdh set xcbj='������' where xcbj is null

go
alter table msys alter column value nvarchar(200)
go
insert into  msys
valus('gpsservice','gpsservice��ַ','http://10.166.137.29:8305/GpsService')
insert into  msys
valus('androidver_sdxj','�͵�Ѳ��ϵͳ','3')
go