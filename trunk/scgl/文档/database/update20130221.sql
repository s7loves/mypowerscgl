USE [ebadascgl]

GO
/****** ����:  Table [dbo].[JH_weekman]    �ű�����: 02/21/2013 08:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JH_weekman](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ParentID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[��λ����] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[��λ����] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[�ƻ���Ŀ] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[��������] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[Э����Ա] [nvarchar](150) COLLATE Chinese_PRC_CI_AS NULL,
	[Ԥ��ʱ��] [datetime] NULL,
	[Ԥ��ʱ��2] [datetime] NULL,
	[��ɱ��] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[���ʱ��] [datetime] NULL,
	[�ܽ�����] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[δ���ԭ��] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[���￼����] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[��ѡ���] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[c1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c4] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c5] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_JH_WEEKMAN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[JH_weekmant](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ParentID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[��λ����] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[��λ����] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[��ʼ����] [datetime] NULL,
	[��������] [datetime] NULL,
	[����] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[������] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[����] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ְ��] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[������] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[���˽��] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[����ʱ��] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_JH_WEEKMANT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('Ա���ܹ���','','','0','','','',1,0,'','','20130210171939462250','20120916105926435125','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('�ܹ����ƻ�','Ebada.jhgl.UCJH_weekmant','Ebada.jhgl.dll','0','','','',1,0,'','','20130210172013743500','20130210171939462250','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('�����쵼����','Ebada.jhgl.UCJH_weekmant','Ebada.jhgl.dll','0','showdw','','',1,0,'','','20130210172032274750','20130210171939462250','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('�����쵼����','Ebada.jhgl.UCJH_weekmant','Ebada.jhgl.dll','0','showall','','',1,0,'','','20130210203628692500','20130210171939462250','')
