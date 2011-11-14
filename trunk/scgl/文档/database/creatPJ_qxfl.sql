use [EbadaScgl]
if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_qxfl')
            and   type = 'U')
   drop table dbo.PJ_qxfl
go

/*==============================================================*/
/* Table: PJ_qxfl                                               */
/*==============================================================*/
create table dbo.PJ_qxfl (
   ID                   nvarchar(50)         not null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   LineID               nvarchar(50)         null,
   LineName             nvarchar(50)         null,
   xlqd                 nvarchar(50)         null,
   xssj                 datetime             null,
   xsr                  nvarchar(50)         null,
   qxnr                 nvarchar(500)        null,
   qxlb                 nvarchar(50)         null,
   xcqx                 nvarchar(50)         null,
   xcr                  nvarchar(50)         null,
   xcrq                 datetime             null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   gzrjID               nvarchar(50)         null,
   qxly                 nvarchar(50)         null,
   remark               nvarchar(Max)        null,
   s1                   nvarchar(50)         null,
   s2                   nvarchar(50)         null,
   s3                   nvarchar(50)         null,
   constraint PK_PJ_QXFL primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '缺陷分类统计',
   'user', 'dbo', 'table', 'PJ_qxfl'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路代码',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'LineID'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路名称',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'LineName'
go

execute sp_addextendedproperty 'MS_Description', 
   '巡视区段',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'xlqd'
go

execute sp_addextendedproperty 'MS_Description', 
   '巡视时间',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'xssj'
go

execute sp_addextendedproperty 'MS_Description', 
   '巡视人',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'xsr'
go

execute sp_addextendedproperty 'MS_Description', 
   '缺陷内容',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'qxnr'
go

execute sp_addextendedproperty 'MS_Description', 
   '缺陷类别',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'qxlb'
go

execute sp_addextendedproperty 'MS_Description', 
   '消除人',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'xcr'
go

execute sp_addextendedproperty 'MS_Description', 
   '消除日期',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'xcrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'gzrjID'
go
execute sp_addextendedproperty 'MS_Description', 
   '缺陷来源',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 's1'
go