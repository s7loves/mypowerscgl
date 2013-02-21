USE [ebadascgl]

GO
/****** 对象:  Table [dbo].[JH_weekman]    脚本日期: 02/21/2013 08:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JH_weekman](
	[ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ParentID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[单位代码] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[单位名称] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[计划项目] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[工作内容] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[协作人员] [nvarchar](150) COLLATE Chinese_PRC_CI_AS NULL,
	[预计时间] [datetime] NULL,
	[预计时间2] [datetime] NULL,
	[完成标记] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[完成时间] [datetime] NULL,
	[总结提升] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[未完成原因] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[评语考核人] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[可选标记] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL,
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
	[单位代码] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[单位名称] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[开始日期] [datetime] NULL,
	[结束日期] [datetime] NULL,
	[标题] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[年月周] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[姓名] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[职务] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[考核人] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[考核结果] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[考核时间] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[c3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_JH_WEEKMANT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('员工周工作','','','0','','','',1,0,'','','20130210171939462250','20120916105926435125','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('周工作计划','Ebada.jhgl.UCJH_weekmant','Ebada.jhgl.dll','0','','','',1,0,'','','20130210172013743500','20130210171939462250','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('部门领导考核','Ebada.jhgl.UCJH_weekmant','Ebada.jhgl.dll','0','showdw','','',1,0,'','','20130210172032274750','20130210171939462250','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('主管领导考核','Ebada.jhgl.UCJH_weekmant','Ebada.jhgl.dll','0','showall','','',1,0,'','','20130210203628692500','20130210171939462250','')
