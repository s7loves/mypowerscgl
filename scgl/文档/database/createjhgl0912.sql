if exists (select 1
            from  sysobjects
           where  id = object_id('JH_monthks')
            and   type = 'U')
   drop table JH_monthks
go

if exists (select 1
            from  sysobjects
           where  id = object_id('JH_weekks')
            and   type = 'U')
   drop table JH_weekks
go

if exists (select 1
            from  sysobjects
           where  id = object_id('JH_yearks')
            and   type = 'U')
   drop table JH_yearks
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('JH_yearkst')
            and   name  = 'Index_1'
            and   indid > 0
            and   indid < 255)
   drop index JH_yearkst.Index_1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('JH_yearkst')
            and   type = 'U')
   drop table JH_yearkst
go

/*==============================================================*/
/* Table: JH_monthks                                            */
/*==============================================================*/
create table JH_monthks (
   ID                   nvarchar(50)         not null,
   ParentID             nvarchar(50)         not null,
   单位代码                 nvarchar(50)         null,
   单位名称                 nvarchar(50)         null,
   计划项目                 nvarchar(50)         null,
   实施内容                 nvarchar(500)        null,
   主要负责人                nvarchar(50)         null,
   参加人员                 nvarchar(150)        null,
   预计时间                 datetime             null,
   预计时间2                datetime             null,
   计划种类                 nvarchar(50)         null,
   计划分类                 nvarchar(50)         null,
   完成标记                 nvarchar(50)         null,
   完成时间                 datetime             null,
   总结提升                 nvarchar(500)        null,
   未完成原因                nvarchar(500)        null,
   可选标记                 nvarchar(10)         null,
   单位分类                 nvarchar(10)         null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   c4                   nvarchar(50)         null,
   c5                   nvarchar(50)         null,
   constraint PK_JH_MONTHKS primary key (ID)
)
go

/*==============================================================*/
/* Table: JH_weekks                                             */
/*==============================================================*/
create table JH_weekks (
   ID                   nvarchar(50)         not null,
   ParentID             nvarchar(50)         not null,
   单位代码                 nvarchar(50)         null,
   单位名称                 nvarchar(50)         null,
   计划项目                 nvarchar(50)         null,
   实施内容                 nvarchar(500)        null,
   主要负责人                nvarchar(50)         null,
   参加人员                 nvarchar(150)        null,
   预计时间                 datetime             null,
   预计时间2                datetime             null,
   计划种类                 nvarchar(50)         null,
   计划分类                 nvarchar(50)         null,
   完成标记                 nvarchar(50)         null,
   完成时间                 datetime             null,
   总结提升                 nvarchar(500)        null,
   未完成原因                nvarchar(500)        null,
   可选标记                 nvarchar(10)         null,
   单位分类                 nvarchar(10)         null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   c4                   nvarchar(50)         null,
   c5                   nvarchar(50)         null,
   constraint PK_JH_WEEKKS primary key (ID)
)
go

/*==============================================================*/
/* Table: JH_yearks                                             */
/*==============================================================*/
create table JH_yearks (
   ID                   nvarchar(50)         not null,
   ParentID             nvarchar(50)         not null,
   单位代码                 nvarchar(50)         null,
   单位名称                 nvarchar(50)         null,
   计划项目                 nvarchar(50)         null,
   实施内容                 nvarchar(500)        null,
   主要负责人                nvarchar(50)         null,
   参加人员                 nvarchar(150)        null,
   预计时间                 datetime             null,
   预计时间2                datetime             null,
   计划种类                 nvarchar(50)         null,
   计划分类                 nvarchar(50)         null,
   完成标记                 nvarchar(50)         null,
   完成时间                 datetime             null,
   总结提升                 nvarchar(500)        null,
   未完成原因                nvarchar(500)        null,
   可选标记                 nvarchar(10)         null,
   单位分类                 nvarchar(10)         null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   c4                   nvarchar(50)         null,
   c5                   nvarchar(50)         null,
   constraint PK_JH_YEARKS primary key (ID)
)
go

/*==============================================================*/
/* Table: JH_yearkst                                            */
/*==============================================================*/
create table JH_yearkst (
   ID                   nvarchar(50)         not null,
   ParentID             nvarchar(50)         null,
   单位代码                 nvarchar(50)         null,
   单位名称                 nvarchar(50)         null,
   开始日期                 datetime             null,
   结束日期                 datetime             null,
   标题                   nvarchar(50)         null,
   年                    nvarchar(50)         null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   constraint PK_JH_YEARKST primary key (ID)
)
go

/*==============================================================*/
/* Index: Index_1                                               */
/*==============================================================*/
create unique index Index_1 on JH_yearkst (
年 ASC
)
go
Delete From [mModule] Where Description='jhgl'

Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('计划管理','','','0','','','',1,0,'','jhgl','20120916105926435125','0','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('全局计划执行时间管理','Ebada.jhgl.UCJH_yearkst','Ebada.jhgl.dll','0','','','',1,0,'','jhgl','20120916105956060125','20120916105926435125','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('计划录入','','','0','','','',1,0,'','jhgl','20120916110042622625','20120916105926435125','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('全年计划任务','','','0','','','',1,0,'','jhgl','20120916110238935125','20120916105926435125','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('全局全年计划','Ebada.jhgl.UCJH_yearks','Ebada.jhgl.dll','1','showtype0','','',1,0,'','jhgl','20120916110306325750','20120916110042622625','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('各科室全年计划','Ebada.jhgl.UCJH_yearks','Ebada.jhgl.dll','3','showtype1','','',1,0,'','jhgl','20120916110316138250','20120916110042622625','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('各科室临时计划','Ebada.jhgl.UCJH_yearks','Ebada.jhgl.dll','4','showtype11','','',1,0,'','jhgl','20120916110324388250','20120916110042622625','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('全局全年计划任务','Ebada.jhgl.UCJH_yearks','Ebada.jhgl.dll','1','showall','','',1,0,'','jhgl','20120916110341028875','20120916110238935125','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('各科室全年计划任务','Ebada.jhgl.UCJH_yearks','Ebada.jhgl.dll','2','showdw','','',1,0,'','jhgl','20120916110351278875','20120916110238935125','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('供、变所全年计划任务','Ebada.jhgl.UCJH_yearks','Ebada.jhgl.dll','3','showdw','','',1,0,'','jhgl','20120916110424997625','20120916110238935125','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('全局临时计划','Ebada.jhgl.UCJH_yearks','Ebada.jhgl.dll','2','showtype00','','',1,0,'','jhgl','20120916204205838625','20120916110042622625','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('供、变所全年计划','Ebada.jhgl.UCJH_yearks','Ebada.jhgl.dll','5','showtype2','','',1,0,'','jhgl','20120916204357948000','20120916110042622625','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('供、变所临时计划','Ebada.jhgl.UCJH_yearks','Ebada.jhgl.dll','6','showtype22','','',1,0,'','jhgl','20120916204425604250','20120916110042622625','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('月计划任务','','','0','','','',1,0,'','jhgl','20120916204610479250','20120916105926435125','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('周计划任务','','','0','','','',1,0,'','jhgl','20120916204619541750','20120916105926435125','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('全局月计划任务','Ebada.jhgl.UCJH_monthks','Ebada.jhgl.dll','1','showall','','',1,0,'','jhgl','20120916232147209375','20120916204610479250','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('全局周计划任务','Ebada.jhgl.UCJH_weekks','Ebada.jhgl.dll','1','showall','','',1,0,'','jhgl','20120916232150318750','20120916204619541750','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('各科室月计划任务','Ebada.jhgl.UCJH_monthks','Ebada.jhgl.dll','2','showdw','','',1,0,'','jhgl','20120916232157318750','20120916204610479250','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('供、变所月计划任务','Ebada.jhgl.UCJH_monthks','Ebada.jhgl.dll','3','showdw','','',1,0,'','jhgl','20120916232218459375','20120916204610479250','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('各科室周计划任务','Ebada.jhgl.UCJH_weekks','Ebada.jhgl.dll','2','showdw','','',1,0,'','jhgl','20120916232237725000','20120916204619541750','')
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('供、变所周计划任务','Ebada.jhgl.UCJH_weekks','Ebada.jhgl.dll','3','showdw','','',1,0,'','jhgl','20120916232246506250','20120916204619541750','')
