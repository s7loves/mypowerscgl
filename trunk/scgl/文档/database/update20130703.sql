USE [ebadascgl]
GO
/****** ����:  Table [dbo].[xxgx_ddyb]    �ű�����: 07/03/2013 08:52:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[xxgx_ddyb](
	[id] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[orgcode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[year] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[filename] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[scsj] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[scry] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[filedata] [image] NULL,
	[c1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_xxgx_ddyb] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ļ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ddyb', @level2type=N'COLUMN', @level2name=N'filename'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ʱ��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ddyb', @level2type=N'COLUMN', @level2name=N'scsj'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'xxgx_ddyb', @level2type=N'COLUMN', @level2name=N'scry'
