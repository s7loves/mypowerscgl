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
