/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     2011-6-13 17:28:26                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PJ_05jckyjl') and o.name = 'FK_PJ_05JCK_REFERENCE_PJ_05JCK')
alter table dbo.PJ_05jckyjl
   drop constraint FK_PJ_05JCK_REFERENCE_PJ_05JCK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PJ_07jdzzjl') and o.name = 'FK_PJ_07JDZ_REFERENCE_PJ_07JDZ')
alter table dbo.PJ_07jdzzjl
   drop constraint FK_PJ_07JDZ_REFERENCE_PJ_07JDZ
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PJ_11byqbd') and o.name = 'FK_PJ_11BYQBD_REFERENCE_PS_TQBYQ')
alter table dbo.PJ_11byqbd
   drop constraint FK_PJ_11BYQBD_REFERENCE_PS_TQBYQ
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PJ_11byqdydl') and o.name = 'FK_PJ_11BYQdy_REFERENCE_PS_TQBYQ')
alter table dbo.PJ_11byqdydl
   drop constraint FK_PJ_11BYQdy_REFERENCE_PS_TQBYQ
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PJ_11byqdzcl') and o.name = 'FK_PJ_11BYQdz_REFERENCE_PS_TQBYQ')
alter table dbo.PJ_11byqdzcl
   drop constraint FK_PJ_11BYQdz_REFERENCE_PS_TQBYQ
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PJ_12kgbd') and o.name = 'FK_PJ_12KGB_REFERENCE_PS_KG')
alter table dbo.PJ_12kgbd
   drop constraint FK_PJ_12KGB_REFERENCE_PS_KG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PJ_12kgjx') and o.name = 'FK_PJ_12KGJ_REFERENCE_PS_KG')
alter table dbo.PJ_12kgjx
   drop constraint FK_PJ_12KGJ_REFERENCE_PS_KG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PJ_12kgsy') and o.name = 'FK_PJ_12KGS_REFERENCE_PS_KG')
alter table dbo.PJ_12kgsy
   drop constraint FK_PJ_12KGS_REFERENCE_PS_KG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PJ_13dlbhjl') and o.name = 'FK_PJ_13DLB_REFERENCE_PS_TQDLB')
alter table dbo.PJ_13dlbhjl
   drop constraint FK_PJ_13DLB_REFERENCE_PS_TQDLB
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PJ_14aqgjsy') and o.name = 'FK_PJ_14AQG_REFERENCE_PS_AQGJ')
alter table dbo.PJ_14aqgjsy
   drop constraint FK_PJ_14AQG_REFERENCE_PS_AQGJ
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PJ_gzrjnr') and o.name = 'FK_PJ_GZRJN_REFERENCE_PJ_01GZR')
alter table dbo.PJ_gzrjnr
   drop constraint FK_PJ_GZRJN_REFERENCE_PJ_01GZR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PS_aqgj') and o.name = 'FK_PS_AQGJ_REFERENCE_MORG')
alter table dbo.PS_aqgj
   drop constraint FK_PS_AQGJ_REFERENCE_MORG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PS_dyxl') and o.name = 'FK_PS_DYXL_REFERENCE_PS_TQBYQ')
alter table dbo.PS_dyxl
   drop constraint FK_PS_DYXL_REFERENCE_PS_TQBYQ
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PS_gjyb') and o.name = 'FK_PS_GJYB_REFERENCE_MORG')
alter table dbo.PS_gjyb
   drop constraint FK_PS_GJYB_REFERENCE_MORG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PS_gt') and o.name = 'FK_PS_GT_REFERENCE_PS_XL')
alter table dbo.PS_gt
   drop constraint FK_PS_GT_REFERENCE_PS_XL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PS_gtsb') and o.name = 'FK_PS_GTSB_REFERENCE_PS_GT')
alter table dbo.PS_gtsb
   drop constraint FK_PS_GTSB_REFERENCE_PS_GT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PS_kg') and o.name = 'FK_PS_KG_REFERENCE_PS_GT')
alter table dbo.PS_kg
   drop constraint FK_PS_KG_REFERENCE_PS_GT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PS_tq') and o.name = 'FK_PS_TQ_REFERENCE_PS_GT')
alter table dbo.PS_tq
   drop constraint FK_PS_TQ_REFERENCE_PS_GT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PS_tqbyq') and o.name = 'FK_PS_TQBYQ_REFERENCE_PS_TQ')
alter table dbo.PS_tqbyq
   drop constraint FK_PS_TQBYQ_REFERENCE_PS_TQ
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PS_tqdlbh') and o.name = 'FK_PS_TQDLB_REFERENCE_PS_TQ')
alter table dbo.PS_tqdlbh
   drop constraint FK_PS_TQDLB_REFERENCE_PS_TQ
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PS_tqsb') and o.name = 'FK_PS_TQSB_REFERENCE_PS_TQ')
alter table dbo.PS_tqsb
   drop constraint FK_PS_TQSB_REFERENCE_PS_TQ
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PS_xl') and o.name = 'FK_PS_XL_REFERENCE_MORG')
alter table dbo.PS_xl
   drop constraint FK_PS_XL_REFERENCE_MORG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.mModulFun') and o.name = 'FK_MMODULFU_REFERENCE_MMODULE')
alter table dbo.mModulFun
   drop constraint FK_MMODULFU_REFERENCE_MMODULE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.mUser') and o.name = 'FK_MUSER_REFERENCE_MORG')
alter table dbo.mUser
   drop constraint FK_MUSER_REFERENCE_MORG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.rRoleModul') and o.name = 'FK_RROLEMOD_REFERENCE_MMODULFU')
alter table dbo.rRoleModul
   drop constraint FK_RROLEMOD_REFERENCE_MMODULFU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.rRoleModul') and o.name = 'FK_RROLEMOD_REFERENCE_MROLE')
alter table dbo.rRoleModul
   drop constraint FK_RROLEMOD_REFERENCE_MROLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.rUserRole') and o.name = 'FK_RUSERROL_REFERENCE_MROLE')
alter table dbo.rUserRole
   drop constraint FK_RUSERROL_REFERENCE_MROLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.rUserRole') and o.name = 'FK_RUSERROL_REFERENCE_MUSER')
alter table dbo.rUserRole
   drop constraint FK_RUSERROL_REFERENCE_MUSER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.ViewGds')
            and   type = 'V')
   drop view dbo.ViewGds
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_01gzrj')
            and   type = 'U')
   drop table dbo.PJ_01gzrj
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_02aqhd')
            and   type = 'U')
   drop table dbo.PJ_02aqhd
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_03yxfx')
            and   type = 'U')
   drop table dbo.PJ_03yxfx
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_04sgzayc')
            and   type = 'U')
   drop table dbo.PJ_04sgzayc
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_05jcky')
            and   type = 'U')
   drop table dbo.PJ_05jcky
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_05jckyjl')
            and   type = 'U')
   drop table dbo.PJ_05jckyjl
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_06sbxs')
            and   type = 'U')
   drop table dbo.PJ_06sbxs
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_07jdzz')
            and   type = 'U')
   drop table dbo.PJ_07jdzz
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_07jdzzjl')
            and   type = 'U')
   drop table dbo.PJ_07jdzzjl
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_08sbtdjx')
            and   type = 'U')
   drop table dbo.PJ_08sbtdjx
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_09pxjl')
            and   type = 'U')
   drop table dbo.PJ_09pxjl
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_11byqbd')
            and   type = 'U')
   drop table dbo.PJ_11byqbd
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_11byqdydl')
            and   type = 'U')
   drop table dbo.PJ_11byqdydl
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_11byqdzcl')
            and   type = 'U')
   drop table dbo.PJ_11byqdzcl
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_12kgbd')
            and   type = 'U')
   drop table dbo.PJ_12kgbd
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_12kgjx')
            and   type = 'U')
   drop table dbo.PJ_12kgjx
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_12kgsy')
            and   type = 'U')
   drop table dbo.PJ_12kgsy
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_13dlbhjl')
            and   type = 'U')
   drop table dbo.PJ_13dlbhjl
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_14aqgjsy')
            and   type = 'U')
   drop table dbo.PJ_14aqgjsy
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_16')
            and   type = 'U')
   drop table dbo.PJ_16
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_17')
            and   type = 'U')
   drop table dbo.PJ_17
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_18gysbpj')
            and   type = 'U')
   drop table dbo.PJ_18gysbpj
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_19')
            and   type = 'U')
   drop table dbo.PJ_19
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_20')
            and   type = 'U')
   drop table dbo.PJ_20
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_21gzbxdh')
            and   type = 'U')
   drop table dbo.PJ_21gzbxdh
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_22')
            and   type = 'U')
   drop table dbo.PJ_22
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_23')
            and   type = 'U')
   drop table dbo.PJ_23
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_24')
            and   type = 'U')
   drop table dbo.PJ_24
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_25')
            and   type = 'U')
   drop table dbo.PJ_25
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_26')
            and   type = 'U')
   drop table dbo.PJ_26
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_dyk')
            and   type = 'U')
   drop table dbo.PJ_dyk
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PJ_gzrjnr')
            and   type = 'U')
   drop table dbo.PJ_gzrjnr
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PS_aqgj')
            and   type = 'U')
   drop table dbo.PS_aqgj
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PS_dyxl')
            and   type = 'U')
   drop table dbo.PS_dyxl
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PS_gjyb')
            and   type = 'U')
   drop table dbo.PS_gjyb
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.PS_gt')
            and   name  = 'Index_1'
            and   indid > 0
            and   indid < 255)
   drop index dbo.PS_gt.Index_1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PS_gt')
            and   type = 'U')
   drop table dbo.PS_gt
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PS_gtsb')
            and   type = 'U')
   drop table dbo.PS_gtsb
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PS_kg')
            and   type = 'U')
   drop table dbo.PS_kg
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PS_tq')
            and   type = 'U')
   drop table dbo.PS_tq
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PS_tqbyq')
            and   type = 'U')
   drop table dbo.PS_tqbyq
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PS_tqdlbh')
            and   type = 'U')
   drop table dbo.PS_tqdlbh
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PS_tqsb')
            and   type = 'U')
   drop table dbo.PS_tqsb
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.PS_xl')
            and   name  = 'Index_3'
            and   indid > 0
            and   indid < 255)
   drop index dbo.PS_xl.Index_3
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.PS_xl')
            and   name  = 'Index_2'
            and   indid > 0
            and   indid < 255)
   drop index dbo.PS_xl.Index_2
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.PS_xl')
            and   name  = 'Index_1'
            and   indid > 0
            and   indid < 255)
   drop index dbo.PS_xl.Index_1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PS_xl')
            and   type = 'U')
   drop table dbo.PS_xl
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.mModulFun')
            and   type = 'U')
   drop table dbo.mModulFun
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.mModule')
            and   type = 'U')
   drop table dbo.mModule
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.mOrg')
            and   name  = 'idx_bmbh'
            and   indid > 0
            and   indid < 255)
   drop index dbo.mOrg.idx_bmbh
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.mOrg')
            and   type = 'U')
   drop table dbo.mOrg
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.mPost')
            and   type = 'U')
   drop table dbo.mPost
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.mRole')
            and   type = 'U')
   drop table dbo.mRole
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.mUser')
            and   type = 'U')
   drop table dbo.mUser
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.rRoleModul')
            and   type = 'U')
   drop table dbo.rRoleModul
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.rUserRole')
            and   type = 'U')
   drop table dbo.rUserRole
go

execute sp_revokedbaccess dbo
go

/*==============================================================*/
/* User: dbo                                                    */
/*==============================================================*/
execute sp_grantdbaccess dbo
go

/*==============================================================*/
/* Table: PJ_01gzrj                                             */
/*==============================================================*/
create table dbo.PJ_01gzrj (
   gzrjID               nvarchar(50)         not null,
   GdsCode              nvarchar(50)         null,
   GdsName              nvarchar(50)         null,
   rq                   datetime             null,
   xq                   nvarchar(50)         null,
   tq                   nvarchar(50)         null,
   qqry                 nvarchar(500)        null,
   rsaqts               int                  null,
   sbaqts               int                  null,
   js                   nvarchar(500)        null,
   py                   nvarchar(500)        null,
   qz                   nvarchar(50)         null,
   qzrq                 datetime             null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_01GZRJ primary key (gzrjID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '01工作日记',
   'user', 'dbo', 'table', 'PJ_01gzrj'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_01gzrj', 'column', 'gzrjID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_01gzrj', 'column', 'GdsCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_01gzrj', 'column', 'GdsName'
go

execute sp_addextendedproperty 'MS_Description', 
   '日期',
   'user', 'dbo', 'table', 'PJ_01gzrj', 'column', 'rq'
go

execute sp_addextendedproperty 'MS_Description', 
   '星期',
   'user', 'dbo', 'table', 'PJ_01gzrj', 'column', 'xq'
go

execute sp_addextendedproperty 'MS_Description', 
   '天气',
   'user', 'dbo', 'table', 'PJ_01gzrj', 'column', 'tq'
go

execute sp_addextendedproperty 'MS_Description', 
   '缺勤情况',
   'user', 'dbo', 'table', 'PJ_01gzrj', 'column', 'qqry'
go

execute sp_addextendedproperty 'MS_Description', 
   '人身安全天数',
   'user', 'dbo', 'table', 'PJ_01gzrj', 'column', 'rsaqts'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备安全天数',
   'user', 'dbo', 'table', 'PJ_01gzrj', 'column', 'sbaqts'
go

execute sp_addextendedproperty 'MS_Description', 
   '记事',
   'user', 'dbo', 'table', 'PJ_01gzrj', 'column', 'js'
go

execute sp_addextendedproperty 'MS_Description', 
   '评语',
   'user', 'dbo', 'table', 'PJ_01gzrj', 'column', 'py'
go

execute sp_addextendedproperty 'MS_Description', 
   '签字',
   'user', 'dbo', 'table', 'PJ_01gzrj', 'column', 'qz'
go

execute sp_addextendedproperty 'MS_Description', 
   '签字日期',
   'user', 'dbo', 'table', 'PJ_01gzrj', 'column', 'qzrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_01gzrj', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_01gzrj', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PJ_02aqhd                                             */
/*==============================================================*/
create table dbo.PJ_02aqhd (
   ID                   nvarchar(50)         not null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   zcr                  nvarchar(50)         null,
   kssj                 datetime             null,
   jssj                 datetime             null,
   cjry                 nvarchar(500)        null,
   qxry                 nvarchar(150)        null,
   hdnr                 nvarchar(4000)       null,
   hdxj                 nvarchar(4000)       null,
   fyjyjl               nvarchar(4000)       null,
   py                   nvarchar(500)        null,
   qz                   nvarchar(50)         null,
   qzrq                 datetime             null,
   gznrID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_02AQHD primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '02安全活动',
   'user', 'dbo', 'table', 'PJ_02aqhd'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '主持人',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'zcr'
go

execute sp_addextendedproperty 'MS_Description', 
   '开始时间',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'kssj'
go

execute sp_addextendedproperty 'MS_Description', 
   '结束时间',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'jssj'
go

execute sp_addextendedproperty 'MS_Description', 
   '参加人员',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'cjry'
go

execute sp_addextendedproperty 'MS_Description', 
   '缺席人员',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'qxry'
go

execute sp_addextendedproperty 'MS_Description', 
   '活动内容',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'hdnr'
go

execute sp_addextendedproperty 'MS_Description', 
   '活动小结',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'hdxj'
go

execute sp_addextendedproperty 'MS_Description', 
   '发言简要记录',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'fyjyjl'
go

execute sp_addextendedproperty 'MS_Description', 
   '评语',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'py'
go

execute sp_addextendedproperty 'MS_Description', 
   '签字',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'qz'
go

execute sp_addextendedproperty 'MS_Description', 
   '签字日期',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'qzrq'
go

execute sp_addextendedproperty 'MS_Description', 
   'gznrID',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'gznrID'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_02aqhd', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PJ_03yxfx                                             */
/*==============================================================*/
create table dbo.PJ_03yxfx (
   ID                   nvarchar(50)         not null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   zcr                  nvarchar(50)         null,
   rq                   datetime             null,
   cjry                 nvarchar(500)        null,
   zt                   nvarchar(500)        null,
   jy                   nvarchar(4000)       null,
   jr                   nvarchar(4000)       null,
   py                   nvarchar(500)        null,
   qz                   nvarchar(50)         null,
   qzrq                 datetime             null,
   gznrID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_03YXFX primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '03运行分析记录',
   'user', 'dbo', 'table', 'PJ_03yxfx'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_03yxfx', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_03yxfx', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_03yxfx', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '主持人',
   'user', 'dbo', 'table', 'PJ_03yxfx', 'column', 'zcr'
go

execute sp_addextendedproperty 'MS_Description', 
   '日期',
   'user', 'dbo', 'table', 'PJ_03yxfx', 'column', 'rq'
go

execute sp_addextendedproperty 'MS_Description', 
   '参加人员',
   'user', 'dbo', 'table', 'PJ_03yxfx', 'column', 'cjry'
go

execute sp_addextendedproperty 'MS_Description', 
   '主题',
   'user', 'dbo', 'table', 'PJ_03yxfx', 'column', 'zt'
go

execute sp_addextendedproperty 'MS_Description', 
   '纪要',
   'user', 'dbo', 'table', 'PJ_03yxfx', 'column', 'jy'
go

execute sp_addextendedproperty 'MS_Description', 
   '结论及对策',
   'user', 'dbo', 'table', 'PJ_03yxfx', 'column', 'jr'
go

execute sp_addextendedproperty 'MS_Description', 
   '评语',
   'user', 'dbo', 'table', 'PJ_03yxfx', 'column', 'py'
go

execute sp_addextendedproperty 'MS_Description', 
   '签字',
   'user', 'dbo', 'table', 'PJ_03yxfx', 'column', 'qz'
go

execute sp_addextendedproperty 'MS_Description', 
   '签字日期',
   'user', 'dbo', 'table', 'PJ_03yxfx', 'column', 'qzrq'
go

execute sp_addextendedproperty 'MS_Description', 
   'gznrID',
   'user', 'dbo', 'table', 'PJ_03yxfx', 'column', 'gznrID'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_03yxfx', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_03yxfx', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PJ_04sgzayc                                           */
/*==============================================================*/
create table dbo.PJ_04sgzayc (
   ID                   nvarchar(50)         not null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   fsdd                 nvarchar(150)        null,
   tdsj                 datetime             null,
   sdsj                 datetime             null,
   gtdsj                nvarchar(50)         null,
   ssdl                 decimal(8,0)         null,
   clqk                 nvarchar(4000)       null,
   yyfx                 nvarchar(4000)       null,
   fzdc                 nvarchar(500)        null,
   zxr                  nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   gznrID               nvarchar(50)         null,
   constraint PK_PJ_04SGZAYC primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '事故障碍异常记录',
   'user', 'dbo', 'table', 'PJ_04sgzayc'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_04sgzayc', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_04sgzayc', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_04sgzayc', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '发生地点',
   'user', 'dbo', 'table', 'PJ_04sgzayc', 'column', 'fsdd'
go

execute sp_addextendedproperty 'MS_Description', 
   '停电时间',
   'user', 'dbo', 'table', 'PJ_04sgzayc', 'column', 'tdsj'
go

execute sp_addextendedproperty 'MS_Description', 
   '送电时间',
   'user', 'dbo', 'table', 'PJ_04sgzayc', 'column', 'sdsj'
go

execute sp_addextendedproperty 'MS_Description', 
   '共停电时间（时分）',
   'user', 'dbo', 'table', 'PJ_04sgzayc', 'column', 'gtdsj'
go

execute sp_addextendedproperty 'MS_Description', 
   '损失电量',
   'user', 'dbo', 'table', 'PJ_04sgzayc', 'column', 'ssdl'
go

execute sp_addextendedproperty 'MS_Description', 
   '事故情况及处理经过',
   'user', 'dbo', 'table', 'PJ_04sgzayc', 'column', 'clqk'
go

execute sp_addextendedproperty 'MS_Description', 
   '主要原因分析',
   'user', 'dbo', 'table', 'PJ_04sgzayc', 'column', 'yyfx'
go

execute sp_addextendedproperty 'MS_Description', 
   '今后防止对策',
   'user', 'dbo', 'table', 'PJ_04sgzayc', 'column', 'fzdc'
go

execute sp_addextendedproperty 'MS_Description', 
   '防止对策执行人',
   'user', 'dbo', 'table', 'PJ_04sgzayc', 'column', 'zxr'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_04sgzayc', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_04sgzayc', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   'gznrID',
   'user', 'dbo', 'table', 'PJ_04sgzayc', 'column', 'gznrID'
go

/*==============================================================*/
/* Table: PJ_05jcky                                             */
/*==============================================================*/
create table dbo.PJ_05jcky (
   jckyID               nvarchar(50)         not null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   LineID               nvarchar(50)         null,
   gtID                 nvarchar(50)         null,
   kywz                 nvarchar(50)         null,
   kygh                 nvarchar(50)         null,
   kymc                 nvarchar(50)         null,
   ssdw                 nvarchar(50)         null,
   jb                   nvarchar(50)         null,
   gdjl                 decimal(5,1)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_05JCKY primary key (jckyID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '交叉跨越',
   'user', 'dbo', 'table', 'PJ_05jcky'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_05jcky', 'column', 'jckyID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_05jcky', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_05jcky', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路ID',
   'user', 'dbo', 'table', 'PJ_05jcky', 'column', 'LineID'
go

execute sp_addextendedproperty 'MS_Description', 
   '杆塔ID',
   'user', 'dbo', 'table', 'PJ_05jcky', 'column', 'gtID'
go

execute sp_addextendedproperty 'MS_Description', 
   '交叉跨越位置',
   'user', 'dbo', 'table', 'PJ_05jcky', 'column', 'kywz'
go

execute sp_addextendedproperty 'MS_Description', 
   '跨越杆号',
   'user', 'dbo', 'table', 'PJ_05jcky', 'column', 'kygh'
go

execute sp_addextendedproperty 'MS_Description', 
   '被跨越物名称',
   'user', 'dbo', 'table', 'PJ_05jcky', 'column', 'kymc'
go

execute sp_addextendedproperty 'MS_Description', 
   '所属单位',
   'user', 'dbo', 'table', 'PJ_05jcky', 'column', 'ssdw'
go

execute sp_addextendedproperty 'MS_Description', 
   '级别',
   'user', 'dbo', 'table', 'PJ_05jcky', 'column', 'jb'
go

execute sp_addextendedproperty 'MS_Description', 
   '规定距离不小于',
   'user', 'dbo', 'table', 'PJ_05jcky', 'column', 'gdjl'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', 'dbo', 'table', 'PJ_05jcky', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'PJ_05jcky', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PJ_05jckyjl                                           */
/*==============================================================*/
create table dbo.PJ_05jckyjl (
   ID                   nvarchar(50)         not null,
   jckyID               nvarchar(50)         null,
   clrq                 datetime             null,
   scz                  decimal(5,1)         null,
   qw                   nvarchar(50)         null,
   clrqz                nvarchar(50)         null,
   jr                   nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   gzrjID               nvarchar(50)         null,
   constraint PK_PJ_05JCKYJL primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '交叉跨越及对地距离测量记录',
   'user', 'dbo', 'table', 'PJ_05jckyjl'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_05jckyjl', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '交叉跨越ID',
   'user', 'dbo', 'table', 'PJ_05jckyjl', 'column', 'jckyID'
go

execute sp_addextendedproperty 'MS_Description', 
   '测量日期',
   'user', 'dbo', 'table', 'PJ_05jckyjl', 'column', 'clrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '实测值',
   'user', 'dbo', 'table', 'PJ_05jckyjl', 'column', 'scz'
go

execute sp_addextendedproperty 'MS_Description', 
   '气温',
   'user', 'dbo', 'table', 'PJ_05jckyjl', 'column', 'qw'
go

execute sp_addextendedproperty 'MS_Description', 
   '测量人签字',
   'user', 'dbo', 'table', 'PJ_05jckyjl', 'column', 'clrqz'
go

execute sp_addextendedproperty 'MS_Description', 
   '结论',
   'user', 'dbo', 'table', 'PJ_05jckyjl', 'column', 'jr'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_05jckyjl', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_05jckyjl', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_05jckyjl', 'column', 'gzrjID'
go

/*==============================================================*/
/* Table: PJ_06sbxs                                             */
/*==============================================================*/
create table dbo.PJ_06sbxs (
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
   xcr                  nvarchar(50)         null,
   xcrq                 datetime             null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   gzrjID               nvarchar(50)         null,
   constraint PK_PJ_06SBXS primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '设备巡视及缺陷消除记录',
   'user', 'dbo', 'table', 'PJ_06sbxs'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_06sbxs', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_06sbxs', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_06sbxs', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路代码',
   'user', 'dbo', 'table', 'PJ_06sbxs', 'column', 'LineID'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路名称',
   'user', 'dbo', 'table', 'PJ_06sbxs', 'column', 'LineName'
go

execute sp_addextendedproperty 'MS_Description', 
   '巡视区段',
   'user', 'dbo', 'table', 'PJ_06sbxs', 'column', 'xlqd'
go

execute sp_addextendedproperty 'MS_Description', 
   '巡视时间',
   'user', 'dbo', 'table', 'PJ_06sbxs', 'column', 'xssj'
go

execute sp_addextendedproperty 'MS_Description', 
   '巡视人',
   'user', 'dbo', 'table', 'PJ_06sbxs', 'column', 'xsr'
go

execute sp_addextendedproperty 'MS_Description', 
   '缺陷内容',
   'user', 'dbo', 'table', 'PJ_06sbxs', 'column', 'qxnr'
go

execute sp_addextendedproperty 'MS_Description', 
   '缺陷类别',
   'user', 'dbo', 'table', 'PJ_06sbxs', 'column', 'qxlb'
go

execute sp_addextendedproperty 'MS_Description', 
   '消除人',
   'user', 'dbo', 'table', 'PJ_06sbxs', 'column', 'xcr'
go

execute sp_addextendedproperty 'MS_Description', 
   '消除日期',
   'user', 'dbo', 'table', 'PJ_06sbxs', 'column', 'xcrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_06sbxs', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_06sbxs', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_06sbxs', 'column', 'gzrjID'
go

/*==============================================================*/
/* Table: PJ_07jdzz                                             */
/*==============================================================*/
create table dbo.PJ_07jdzz (
   jdzzID               nvarchar(50)         not null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   LineID               nvarchar(50)         null,
   LineName             nvarchar(50)         null,
   gth                  nvarchar(50)         null,
   gzwz                 nvarchar(50)         null,
   sbmc                 nvarchar(50)         null,
   xhgg                 nvarchar(50)         null,
   jddz                 decimal(5,2)         null,
   tz                   nvarchar(500)        null,
   trdzr                decimal(5,2)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   sbID                 nvarchar(50)         null,
   constraint PK_PJ_07JDZZ primary key (jdzzID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '接地装置',
   'user', 'dbo', 'table', 'PJ_07jdzz'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_07jdzz', 'column', 'jdzzID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_07jdzz', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_07jdzz', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路代码',
   'user', 'dbo', 'table', 'PJ_07jdzz', 'column', 'LineID'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路名称',
   'user', 'dbo', 'table', 'PJ_07jdzz', 'column', 'LineName'
go

execute sp_addextendedproperty 'MS_Description', 
   '杆号',
   'user', 'dbo', 'table', 'PJ_07jdzz', 'column', 'gth'
go

execute sp_addextendedproperty 'MS_Description', 
   '安装位置',
   'user', 'dbo', 'table', 'PJ_07jdzz', 'column', 'gzwz'
go

execute sp_addextendedproperty 'MS_Description', 
   '保护设备名称',
   'user', 'dbo', 'table', 'PJ_07jdzz', 'column', 'sbmc'
go

execute sp_addextendedproperty 'MS_Description', 
   '型号规格',
   'user', 'dbo', 'table', 'PJ_07jdzz', 'column', 'xhgg'
go

execute sp_addextendedproperty 'MS_Description', 
   '接地电阻不大于(Ω)',
   'user', 'dbo', 'table', 'PJ_07jdzz', 'column', 'jddz'
go

execute sp_addextendedproperty 'MS_Description', 
   '土质',
   'user', 'dbo', 'table', 'PJ_07jdzz', 'column', 'tz'
go

execute sp_addextendedproperty 'MS_Description', 
   '土壤电阻率(Ω.m)',
   'user', 'dbo', 'table', 'PJ_07jdzz', 'column', 'trdzr'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_07jdzz', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_07jdzz', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '关联设备ID',
   'user', 'dbo', 'table', 'PJ_07jdzz', 'column', 'sbID'
go

/*==============================================================*/
/* Table: PJ_07jdzzjl                                           */
/*==============================================================*/
create table dbo.PJ_07jdzzjl (
   ID                   nvarchar(50)         not null,
   jdzzID               nvarchar(50)         null,
   clrq                 datetime             null,
   tq                   nvarchar(50)         null,
   scz                  decimal(5,2)         null,
   hsz                  decimal(5,2)         null,
   jcqk                 nvarchar(50)         null,
   jr                   nvarchar(50)         null,
   jcr                  nvarchar(10)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   gzrjID               nvarchar(50)         null,
   constraint PK_PJ_07JDZZJL primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '地装置检测记录',
   'user', 'dbo', 'table', 'PJ_07jdzzjl'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_07jdzzjl', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '接地装置ID',
   'user', 'dbo', 'table', 'PJ_07jdzzjl', 'column', 'jdzzID'
go

execute sp_addextendedproperty 'MS_Description', 
   '测量日期',
   'user', 'dbo', 'table', 'PJ_07jdzzjl', 'column', 'clrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '天气',
   'user', 'dbo', 'table', 'PJ_07jdzzjl', 'column', 'tq'
go

execute sp_addextendedproperty 'MS_Description', 
   '实测值',
   'user', 'dbo', 'table', 'PJ_07jdzzjl', 'column', 'scz'
go

execute sp_addextendedproperty 'MS_Description', 
   '换算值',
   'user', 'dbo', 'table', 'PJ_07jdzzjl', 'column', 'hsz'
go

execute sp_addextendedproperty 'MS_Description', 
   '检测情况',
   'user', 'dbo', 'table', 'PJ_07jdzzjl', 'column', 'jcqk'
go

execute sp_addextendedproperty 'MS_Description', 
   '结论',
   'user', 'dbo', 'table', 'PJ_07jdzzjl', 'column', 'jr'
go

execute sp_addextendedproperty 'MS_Description', 
   '检测人',
   'user', 'dbo', 'table', 'PJ_07jdzzjl', 'column', 'jcr'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_07jdzzjl', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_07jdzzjl', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_07jdzzjl', 'column', 'gzrjID'
go

/*==============================================================*/
/* Table: PJ_08sbtdjx                                           */
/*==============================================================*/
create table dbo.PJ_08sbtdjx (
   ID                   nvarchar(50)         not null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   rq                   datetime             null,
   LineName             nvarchar(50)         null,
   jxnr                 nvarchar(50)         null,
   tdsj                 datetime             null,
   sdsj                 datetime             null,
   tdxz                 nvarchar(500)        null,
   gzfzr                nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   gzrjID               nvarchar(50)         null,
   LineID               nvarchar(50)         null,
   constraint PK_PJ_08SBTDJX primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '设备停电检修记录',
   'user', 'dbo', 'table', 'PJ_08sbtdjx'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_08sbtdjx', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_08sbtdjx', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_08sbtdjx', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '日期',
   'user', 'dbo', 'table', 'PJ_08sbtdjx', 'column', 'rq'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路名称',
   'user', 'dbo', 'table', 'PJ_08sbtdjx', 'column', 'LineName'
go

execute sp_addextendedproperty 'MS_Description', 
   '检修内容',
   'user', 'dbo', 'table', 'PJ_08sbtdjx', 'column', 'jxnr'
go

execute sp_addextendedproperty 'MS_Description', 
   '停电时间',
   'user', 'dbo', 'table', 'PJ_08sbtdjx', 'column', 'tdsj'
go

execute sp_addextendedproperty 'MS_Description', 
   '送电时间',
   'user', 'dbo', 'table', 'PJ_08sbtdjx', 'column', 'sdsj'
go

execute sp_addextendedproperty 'MS_Description', 
   '停电性质',
   'user', 'dbo', 'table', 'PJ_08sbtdjx', 'column', 'tdxz'
go

execute sp_addextendedproperty 'MS_Description', 
   '工作负责人',
   'user', 'dbo', 'table', 'PJ_08sbtdjx', 'column', 'gzfzr'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_08sbtdjx', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_08sbtdjx', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_08sbtdjx', 'column', 'gzrjID'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路ID',
   'user', 'dbo', 'table', 'PJ_08sbtdjx', 'column', 'LineID'
go

/*==============================================================*/
/* Table: PJ_09pxjl                                             */
/*==============================================================*/
create table dbo.PJ_09pxjl (
   ID                   nvarchar(50)         not null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   rq                   datetime             null,
   hydd                 nvarchar(50)         null,
   xxss                 nvarchar(50)         null,
   cjrs                 nvarchar(50)         null,
   zcr                  nvarchar(50)         null,
   zjr                  nvarchar(50)         null,
   tm                   nvarchar(250)        null,
   nr                   nvarchar(4000)       null,
   py                   nvarchar(200)        null,
   qz                   nvarchar(50)         null,
   qzrq                 datetime             null,
   gznrID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_09PXJL primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '培训记录',
   'user', 'dbo', 'table', 'PJ_09pxjl'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '日期',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'rq'
go

execute sp_addextendedproperty 'MS_Description', 
   '会议地点',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'hydd'
go

execute sp_addextendedproperty 'MS_Description', 
   '学习时数',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'xxss'
go

execute sp_addextendedproperty 'MS_Description', 
   '参加人数',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'cjrs'
go

execute sp_addextendedproperty 'MS_Description', 
   '主持人',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'zcr'
go

execute sp_addextendedproperty 'MS_Description', 
   '主讲人',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'zjr'
go

execute sp_addextendedproperty 'MS_Description', 
   '题目',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'tm'
go

execute sp_addextendedproperty 'MS_Description', 
   '内容',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'nr'
go

execute sp_addextendedproperty 'MS_Description', 
   '评语',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'py'
go

execute sp_addextendedproperty 'MS_Description', 
   '签字',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'qz'
go

execute sp_addextendedproperty 'MS_Description', 
   '签字日期',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'qzrq'
go

execute sp_addextendedproperty 'MS_Description', 
   'gznrID',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'gznrID'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_09pxjl', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PJ_11byqbd                                            */
/*==============================================================*/
create table dbo.PJ_11byqbd (
   ID                   nvarchar(50)         not null,
   byqID                nvarchar(50)         null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   azrq                 datetime             null,
   azdd                 nvarchar(50)         null,
   ccrq                 datetime             null,
   ccyy                 nvarchar(50)         null,
   gznrID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_11BYQBD primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '变压器变动记录',
   'user', 'dbo', 'table', 'PJ_11byqbd'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_11byqbd', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '变压器ID',
   'user', 'dbo', 'table', 'PJ_11byqbd', 'column', 'byqID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_11byqbd', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_11byqbd', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '安装日期',
   'user', 'dbo', 'table', 'PJ_11byqbd', 'column', 'azrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '安装地点',
   'user', 'dbo', 'table', 'PJ_11byqbd', 'column', 'azdd'
go

execute sp_addextendedproperty 'MS_Description', 
   '撤除日期',
   'user', 'dbo', 'table', 'PJ_11byqbd', 'column', 'ccrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '撤除原因',
   'user', 'dbo', 'table', 'PJ_11byqbd', 'column', 'ccyy'
go

execute sp_addextendedproperty 'MS_Description', 
   'gznrID',
   'user', 'dbo', 'table', 'PJ_11byqbd', 'column', 'gznrID'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_11byqbd', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_11byqbd', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PJ_11byqdydl                                          */
/*==============================================================*/
create table dbo.PJ_11byqdydl (
   ID                   nvarchar(50)         not null,
   byqID                nvarchar(50)         null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   clrq                 datetime             null,
   fjtwz                nvarchar(50)         null,
   ao                   decimal(8,2)         null,
   bo                   decimal(8,2)         null,
   co                   decimal(8,2)         null,
   a                    decimal(8,2)         null,
   b                    decimal(8,2)         null,
   c                    decimal(8,2)         null,
   ao2                  decimal(8,2)         null,
   bo2                  decimal(8,2)         null,
   co2                  decimal(8,2)         null,
   gznrID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_11BYQDYDL primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '变压器电压电流测量记录',
   'user', 'dbo', 'table', 'PJ_11byqdydl'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '变压器ID',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'byqID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '测量日期',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'clrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '分接头位置',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'fjtwz'
go

execute sp_addextendedproperty 'MS_Description', 
   'ao',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'ao'
go

execute sp_addextendedproperty 'MS_Description', 
   'bo',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'bo'
go

execute sp_addextendedproperty 'MS_Description', 
   'co',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'co'
go

execute sp_addextendedproperty 'MS_Description', 
   'a',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'a'
go

execute sp_addextendedproperty 'MS_Description', 
   'b',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'b'
go

execute sp_addextendedproperty 'MS_Description', 
   'c',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'c'
go

execute sp_addextendedproperty 'MS_Description', 
   'ao2',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'ao2'
go

execute sp_addextendedproperty 'MS_Description', 
   'bo2',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'bo2'
go

execute sp_addextendedproperty 'MS_Description', 
   'co2',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'co2'
go

execute sp_addextendedproperty 'MS_Description', 
   'gznrID',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'gznrID'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_11byqdydl', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PJ_11byqdzcl                                          */
/*==============================================================*/
create table dbo.PJ_11byqdzcl (
   ID                   nvarchar(50)         not null,
   byqID                nvarchar(50)         null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   clrq                 datetime             null,
   one2one              int                  null,
   one2d                int                  null,
   two2d                int                  null,
   gznrID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_11BYQDZCL primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '变压器绝缘电阻测量记录',
   'user', 'dbo', 'table', 'PJ_11byqdzcl'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_11byqdzcl', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '变压器ID',
   'user', 'dbo', 'table', 'PJ_11byqdzcl', 'column', 'byqID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_11byqdzcl', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_11byqdzcl', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '测量日期',
   'user', 'dbo', 'table', 'PJ_11byqdzcl', 'column', 'clrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '一次对二次',
   'user', 'dbo', 'table', 'PJ_11byqdzcl', 'column', 'one2one'
go

execute sp_addextendedproperty 'MS_Description', 
   '一次对地',
   'user', 'dbo', 'table', 'PJ_11byqdzcl', 'column', 'one2d'
go

execute sp_addextendedproperty 'MS_Description', 
   '二次对地',
   'user', 'dbo', 'table', 'PJ_11byqdzcl', 'column', 'two2d'
go

execute sp_addextendedproperty 'MS_Description', 
   'gznrID',
   'user', 'dbo', 'table', 'PJ_11byqdzcl', 'column', 'gznrID'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_11byqdzcl', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_11byqdzcl', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PJ_12kgbd                                             */
/*==============================================================*/
create table dbo.PJ_12kgbd (
   ID                   nvarchar(50)         not null,
   kgID                 nvarchar(50)         null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   azrq                 datetime             null,
   azdd                 nvarchar(50)         null,
   gtbh                 nvarchar(50)         null,
   kgCode               nvarchar(50)         null,
   ccrq                 datetime             null,
   ccyy                 nvarchar(50)         null,
   Remark               nvarchar(50)         null,
   gznrID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_12KGBD primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '线路开关变动记录',
   'user', 'dbo', 'table', 'PJ_12kgbd'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_12kgbd', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '开关ID',
   'user', 'dbo', 'table', 'PJ_12kgbd', 'column', 'kgID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_12kgbd', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_12kgbd', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '安装日期',
   'user', 'dbo', 'table', 'PJ_12kgbd', 'column', 'azrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '安装地点',
   'user', 'dbo', 'table', 'PJ_12kgbd', 'column', 'azdd'
go

execute sp_addextendedproperty 'MS_Description', 
   '杆号',
   'user', 'dbo', 'table', 'PJ_12kgbd', 'column', 'gtbh'
go

execute sp_addextendedproperty 'MS_Description', 
   '开关编号',
   'user', 'dbo', 'table', 'PJ_12kgbd', 'column', 'kgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '撤除日期',
   'user', 'dbo', 'table', 'PJ_12kgbd', 'column', 'ccrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '撤除原因',
   'user', 'dbo', 'table', 'PJ_12kgbd', 'column', 'ccyy'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'PJ_12kgbd', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   'gznrID',
   'user', 'dbo', 'table', 'PJ_12kgbd', 'column', 'gznrID'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_12kgbd', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_12kgbd', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PJ_12kgjx                                             */
/*==============================================================*/
create table dbo.PJ_12kgjx (
   ID                   nvarchar(50)         not null,
   kgID                 nvarchar(50)         null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   jxsj                 datetime             null,
   jxnr                 nvarchar(50)         null,
   fzr                  nvarchar(50)         null,
   Remark               nvarchar(50)         null,
   gznrID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_12KGJX primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '线路开关检修记录',
   'user', 'dbo', 'table', 'PJ_12kgjx'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_12kgjx', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '开关ID',
   'user', 'dbo', 'table', 'PJ_12kgjx', 'column', 'kgID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_12kgjx', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_12kgjx', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '检修时间',
   'user', 'dbo', 'table', 'PJ_12kgjx', 'column', 'jxsj'
go

execute sp_addextendedproperty 'MS_Description', 
   '检修内容',
   'user', 'dbo', 'table', 'PJ_12kgjx', 'column', 'jxnr'
go

execute sp_addextendedproperty 'MS_Description', 
   '负责人',
   'user', 'dbo', 'table', 'PJ_12kgjx', 'column', 'fzr'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'PJ_12kgjx', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   'gznrID',
   'user', 'dbo', 'table', 'PJ_12kgjx', 'column', 'gznrID'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_12kgjx', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_12kgjx', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PJ_12kgsy                                             */
/*==============================================================*/
create table dbo.PJ_12kgsy (
   ID                   nvarchar(50)         not null,
   kgID                 nvarchar(50)         null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   azrq                 datetime             null,
   azdd                 nvarchar(50)         null,
   gtbh                 nvarchar(50)         null,
   A_BCO                nvarchar(50)         null,
   B_CAO                nvarchar(50)         null,
   C_ABO                nvarchar(50)         null,
   A_BCO2               nvarchar(50)         null,
   B_CAO2               nvarchar(50)         null,
   C_ABO2               nvarchar(50)         null,
   dy                   nvarchar(50)         null,
   dysj                 nvarchar(50)         null,
   dl                   nvarchar(50)         null,
   dlsj                 nvarchar(50)         null,
   dzA                  nvarchar(50)         null,
   dzB                  nvarchar(50)         null,
   dzC                  nvarchar(50)         null,
   tqjc                 nvarchar(50)         null,
   wgjc                 nvarchar(50)         null,
   syjl                 nvarchar(50)         null,
   syz                  nvarchar(50)         null,
   gznrID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_12KGSY primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '线路开关试验记录',
   'user', 'dbo', 'table', 'PJ_12kgsy'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '开关ID',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'kgID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '日期',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'azrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '天气',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'azdd'
go

execute sp_addextendedproperty 'MS_Description', 
   '温度',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'gtbh'
go

execute sp_addextendedproperty 'MS_Description', 
   'A-BCO',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'A_BCO'
go

execute sp_addextendedproperty 'MS_Description', 
   'B-CAO',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'B_CAO'
go

execute sp_addextendedproperty 'MS_Description', 
   'C-ABO',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'C_ABO'
go

execute sp_addextendedproperty 'MS_Description', 
   'A-BCO2',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'A_BCO2'
go

execute sp_addextendedproperty 'MS_Description', 
   'B-CAO2',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'B_CAO2'
go

execute sp_addextendedproperty 'MS_Description', 
   'C-ABO2',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'C_ABO2'
go

execute sp_addextendedproperty 'MS_Description', 
   '电压(KV)',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'dy'
go

execute sp_addextendedproperty 'MS_Description', 
   '时间(min)',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'dysj'
go

execute sp_addextendedproperty 'MS_Description', 
   '电流(A)',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'dl'
go

execute sp_addextendedproperty 'MS_Description', 
   '时间(S)',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'dlsj'
go

execute sp_addextendedproperty 'MS_Description', 
   'A相(Ω)',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'dzA'
go

execute sp_addextendedproperty 'MS_Description', 
   'B相(Ω)',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'dzB'
go

execute sp_addextendedproperty 'MS_Description', 
   'C相(Ω)',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'dzC'
go

execute sp_addextendedproperty 'MS_Description', 
   '同期检查情况',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'tqjc'
go

execute sp_addextendedproperty 'MS_Description', 
   '外观检查情况',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'wgjc'
go

execute sp_addextendedproperty 'MS_Description', 
   '实验结论',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'syjl'
go

execute sp_addextendedproperty 'MS_Description', 
   '试验者',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'syz'
go

execute sp_addextendedproperty 'MS_Description', 
   'gznrID',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'gznrID'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_12kgsy', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PJ_13dlbhjl                                           */
/*==============================================================*/
create table dbo.PJ_13dlbhjl (
   ID                   nvarchar(50)         not null,
   sbID                 nvarchar(50)         null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   rq                   datetime             null,
   dzdl                 nvarchar(50)         null,
   dzsj                 nvarchar(50)         null,
   yxqk                 nvarchar(50)         null,
   csr                  nvarchar(50)         null,
   gznrID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_13DLBHJL primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '剩余电流动作保护器测试记录',
   'user', 'dbo', 'table', 'PJ_13dlbhjl'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_13dlbhjl', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备ID',
   'user', 'dbo', 'table', 'PJ_13dlbhjl', 'column', 'sbID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_13dlbhjl', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_13dlbhjl', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '日期',
   'user', 'dbo', 'table', 'PJ_13dlbhjl', 'column', 'rq'
go

execute sp_addextendedproperty 'MS_Description', 
   '动作电流',
   'user', 'dbo', 'table', 'PJ_13dlbhjl', 'column', 'dzdl'
go

execute sp_addextendedproperty 'MS_Description', 
   '动作时间',
   'user', 'dbo', 'table', 'PJ_13dlbhjl', 'column', 'dzsj'
go

execute sp_addextendedproperty 'MS_Description', 
   '运行情况,(正常，拒动作)',
   'user', 'dbo', 'table', 'PJ_13dlbhjl', 'column', 'yxqk'
go

execute sp_addextendedproperty 'MS_Description', 
   '测试人',
   'user', 'dbo', 'table', 'PJ_13dlbhjl', 'column', 'csr'
go

execute sp_addextendedproperty 'MS_Description', 
   'gznrID',
   'user', 'dbo', 'table', 'PJ_13dlbhjl', 'column', 'gznrID'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_13dlbhjl', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_13dlbhjl', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PJ_14aqgjsy                                           */
/*==============================================================*/
create table dbo.PJ_14aqgjsy (
   ID                   nvarchar(50)         not null,
   sbID                 nvarchar(50)         null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   rq                   datetime             null,
   jr                   nvarchar(250)        null,
   syr                  nvarchar(10)         null,
   ajqz                 nvarchar(50)         null,
   xcsyrq               datetime             null,
   gznrID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_14AQGJSY primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '安全工器具检查试记录',
   'user', 'dbo', 'table', 'PJ_14aqgjsy'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_14aqgjsy', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备ID',
   'user', 'dbo', 'table', 'PJ_14aqgjsy', 'column', 'sbID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_14aqgjsy', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_14aqgjsy', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '日期',
   'user', 'dbo', 'table', 'PJ_14aqgjsy', 'column', 'rq'
go

execute sp_addextendedproperty 'MS_Description', 
   '结 论',
   'user', 'dbo', 'table', 'PJ_14aqgjsy', 'column', 'jr'
go

execute sp_addextendedproperty 'MS_Description', 
   '试验人',
   'user', 'dbo', 'table', 'PJ_14aqgjsy', 'column', 'syr'
go

execute sp_addextendedproperty 'MS_Description', 
   '安监签字',
   'user', 'dbo', 'table', 'PJ_14aqgjsy', 'column', 'ajqz'
go

execute sp_addextendedproperty 'MS_Description', 
   '下次试验日期',
   'user', 'dbo', 'table', 'PJ_14aqgjsy', 'column', 'xcsyrq'
go

execute sp_addextendedproperty 'MS_Description', 
   'gznrID',
   'user', 'dbo', 'table', 'PJ_14aqgjsy', 'column', 'gznrID'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_14aqgjsy', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_14aqgjsy', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PJ_16                                                 */
/*==============================================================*/
create table dbo.PJ_16 (
   ID                   nvarchar(50)         not null,
   ParentID             nvarchar(50)         null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   LineCode             nvarchar(50)         null,
   LineName             nvarchar(50)         null,
   Remark               nvarchar(50)         null,
   gzrjID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   BigData              image                null,
   constraint PK_PJ_16 primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '高压配电线路条图汇总表',
   'user', 'dbo', 'table', 'PJ_16'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_16', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ParentID',
   'user', 'dbo', 'table', 'PJ_16', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_16', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_16', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路代码',
   'user', 'dbo', 'table', 'PJ_16', 'column', 'LineCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路名称',
   'user', 'dbo', 'table', 'PJ_16', 'column', 'LineName'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'PJ_16', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_16', 'column', 'gzrjID'
go

execute sp_addextendedproperty 'MS_Description', 
   '操作员',
   'user', 'dbo', 'table', 'PJ_16', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '汇总日期',
   'user', 'dbo', 'table', 'PJ_16', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '汇总表',
   'user', 'dbo', 'table', 'PJ_16', 'column', 'BigData'
go

/*==============================================================*/
/* Table: PJ_17                                                 */
/*==============================================================*/
create table dbo.PJ_17 (
   ID                   nvarchar(50)         not null,
   ParentID             nvarchar(50)         null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   LineCode             nvarchar(50)         null,
   LineName             nvarchar(50)         null,
   Remark               nvarchar(50)         null,
   gzrjID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   BigData              image                null,
   constraint PK_PJ_17 primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '高压配电线路条图',
   'user', 'dbo', 'table', 'PJ_17'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_17', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ParentID',
   'user', 'dbo', 'table', 'PJ_17', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_17', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_17', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路代码',
   'user', 'dbo', 'table', 'PJ_17', 'column', 'LineCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路名称',
   'user', 'dbo', 'table', 'PJ_17', 'column', 'LineName'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'PJ_17', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_17', 'column', 'gzrjID'
go

execute sp_addextendedproperty 'MS_Description', 
   '操作员',
   'user', 'dbo', 'table', 'PJ_17', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '生成日期',
   'user', 'dbo', 'table', 'PJ_17', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '生成文档',
   'user', 'dbo', 'table', 'PJ_17', 'column', 'BigData'
go

/*==============================================================*/
/* Table: PJ_18gysbpj                                           */
/*==============================================================*/
create table dbo.PJ_18gysbpj (
   ID                   nvarchar(50)         not null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   rq                   nvarchar(50)         null,
   xh                   int                  null,
   sbdy                 nvarchar(50)         null,
   one                  int                  null,
   two                  int                  null,
   three                int                  null,
   whl                  decimal(8,2)         null,
   qxnr                 nvarchar(250)        null,
   fzdw                 nvarchar(50)         null,
   gzrjID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_18GYSBPJ primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '高压配电设备评级表',
   'user', 'dbo', 'table', 'PJ_18gysbpj'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_18gysbpj', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_18gysbpj', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_18gysbpj', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '日期',
   'user', 'dbo', 'table', 'PJ_18gysbpj', 'column', 'rq'
go

execute sp_addextendedproperty 'MS_Description', 
   '序号',
   'user', 'dbo', 'table', 'PJ_18gysbpj', 'column', 'xh'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备单元名称',
   'user', 'dbo', 'table', 'PJ_18gysbpj', 'column', 'sbdy'
go

execute sp_addextendedproperty 'MS_Description', 
   '一类数量',
   'user', 'dbo', 'table', 'PJ_18gysbpj', 'column', 'one'
go

execute sp_addextendedproperty 'MS_Description', 
   '二类数量',
   'user', 'dbo', 'table', 'PJ_18gysbpj', 'column', 'two'
go

execute sp_addextendedproperty 'MS_Description', 
   '三类数量',
   'user', 'dbo', 'table', 'PJ_18gysbpj', 'column', 'three'
go

execute sp_addextendedproperty 'MS_Description', 
   '完好率',
   'user', 'dbo', 'table', 'PJ_18gysbpj', 'column', 'whl'
go

execute sp_addextendedproperty 'MS_Description', 
   '缺陷内容',
   'user', 'dbo', 'table', 'PJ_18gysbpj', 'column', 'qxnr'
go

execute sp_addextendedproperty 'MS_Description', 
   '负责单位',
   'user', 'dbo', 'table', 'PJ_18gysbpj', 'column', 'fzdw'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_18gysbpj', 'column', 'gzrjID'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_18gysbpj', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_18gysbpj', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PJ_19                                                 */
/*==============================================================*/
create table dbo.PJ_19 (
   ID                   nvarchar(50)         not null,
   ParentID             nvarchar(50)         null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   Remark               nvarchar(50)         null,
   gzrjID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   BigData              image                null,
   constraint PK_PJ_19 primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '高压配电设备完好率汇总表',
   'user', 'dbo', 'table', 'PJ_19'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_19', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ParentID',
   'user', 'dbo', 'table', 'PJ_19', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_19', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_19', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'PJ_19', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_19', 'column', 'gzrjID'
go

execute sp_addextendedproperty 'MS_Description', 
   '操作员',
   'user', 'dbo', 'table', 'PJ_19', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '生成日期',
   'user', 'dbo', 'table', 'PJ_19', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '生成文档',
   'user', 'dbo', 'table', 'PJ_19', 'column', 'BigData'
go

/*==============================================================*/
/* Table: PJ_20                                                 */
/*==============================================================*/
create table dbo.PJ_20 (
   ID                   nvarchar(50)         not null,
   ParentID             nvarchar(50)         null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   tqCode               nvarchar(50)         null,
   tqName               nvarchar(50)         null,
   Remark               nvarchar(50)         null,
   gzrjID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   BigData              image                null,
   constraint PK_PJ_20 primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '低压线路完好率及台区网络图',
   'user', 'dbo', 'table', 'PJ_20'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_20', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ParentID',
   'user', 'dbo', 'table', 'PJ_20', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_20', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_20', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '台区代码',
   'user', 'dbo', 'table', 'PJ_20', 'column', 'tqCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '台区名称',
   'user', 'dbo', 'table', 'PJ_20', 'column', 'tqName'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'PJ_20', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_20', 'column', 'gzrjID'
go

execute sp_addextendedproperty 'MS_Description', 
   '操作员',
   'user', 'dbo', 'table', 'PJ_20', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '生成日期',
   'user', 'dbo', 'table', 'PJ_20', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '生成文档',
   'user', 'dbo', 'table', 'PJ_20', 'column', 'BigData'
go

/*==============================================================*/
/* Table: PJ_21gzbxdh                                           */
/*==============================================================*/
create table dbo.PJ_21gzbxdh (
   ID                   nvarchar(50)         not null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   rq                   datetime             null,
   lxfs                 nvarchar(50)         null,
   yhdz                 nvarchar(50)         null,
   gzjk                 nvarchar(50)         null,
   djr                  nvarchar(10)         null,
   clr                  nvarchar(10)         null,
   gzrjID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_21GZBXDH primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '电力故障报修电话接听记录',
   'user', 'dbo', 'table', 'PJ_21gzbxdh'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_21gzbxdh', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_21gzbxdh', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_21gzbxdh', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '日期',
   'user', 'dbo', 'table', 'PJ_21gzbxdh', 'column', 'rq'
go

execute sp_addextendedproperty 'MS_Description', 
   '联系方式',
   'user', 'dbo', 'table', 'PJ_21gzbxdh', 'column', 'lxfs'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户地址',
   'user', 'dbo', 'table', 'PJ_21gzbxdh', 'column', 'yhdz'
go

execute sp_addextendedproperty 'MS_Description', 
   '故障简况',
   'user', 'dbo', 'table', 'PJ_21gzbxdh', 'column', 'gzjk'
go

execute sp_addextendedproperty 'MS_Description', 
   '登记人',
   'user', 'dbo', 'table', 'PJ_21gzbxdh', 'column', 'djr'
go

execute sp_addextendedproperty 'MS_Description', 
   '处理人',
   'user', 'dbo', 'table', 'PJ_21gzbxdh', 'column', 'clr'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_21gzbxdh', 'column', 'gzrjID'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_21gzbxdh', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_21gzbxdh', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PJ_22                                                 */
/*==============================================================*/
create table dbo.PJ_22 (
   ID                   nvarchar(50)         not null,
   ParentID             nvarchar(50)         null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   ph                   nvarchar(50)         null,
   bxsj                 datetime             null,
   bxdd                 nvarchar(50)         null,
   xlfzr                nvarchar(50)         null,
   xlry                 nvarchar(50)         null,
   zbslr                nvarchar(50)         null,
   bggzqc               nvarchar(50)         null,
   bgfs                 nvarchar(50)         null,
   bxrxm                nvarchar(50)         null,
   lxdh                 nvarchar(50)         null,
   sjgzqc               nvarchar(50)         null,
   sycl                 nvarchar(50)         null,
   dsj                  datetime             null,
   wsj                  datetime             null,
   jhry                 nvarchar(50)         null,
   czry                 nvarchar(50)         null,
   yhqm                 nvarchar(50)         null,
   tdsj                 datetime             null,
   sdsj                 datetime             null,
   tdxl                 nvarchar(50)         null,
   czxm                 nvarchar(150)        null,
   ddsb                 nvarchar(150)        null,
   wxd                  nvarchar(500)        null,
   cljg                 nvarchar(500)        null,
   Remark               nvarchar(50)         null,
   gzrjID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_22 primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '报修服务修理票',
   'user', 'dbo', 'table', 'PJ_22'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ParentID',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所代码',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '供电所名称',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '票号',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'ph'
go

execute sp_addextendedproperty 'MS_Description', 
   '报修时期时间',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'bxsj'
go

execute sp_addextendedproperty 'MS_Description', 
   '报修地点',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'bxdd'
go

execute sp_addextendedproperty 'MS_Description', 
   '修理负责人',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'xlfzr'
go

execute sp_addextendedproperty 'MS_Description', 
   '修理人员',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'xlry'
go

execute sp_addextendedproperty 'MS_Description', 
   '值班受理人',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'zbslr'
go

execute sp_addextendedproperty 'MS_Description', 
   '报修故障情况',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'bggzqc'
go

execute sp_addextendedproperty 'MS_Description', 
   '报告方式',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'bgfs'
go

execute sp_addextendedproperty 'MS_Description', 
   '报修人姓名',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'bxrxm'
go

execute sp_addextendedproperty 'MS_Description', 
   '联系电话',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'lxdh'
go

execute sp_addextendedproperty 'MS_Description', 
   '实际故障情况',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'sjgzqc'
go

execute sp_addextendedproperty 'MS_Description', 
   '所有材料',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'sycl'
go

execute sp_addextendedproperty 'MS_Description', 
   '到现场时间',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'dsj'
go

execute sp_addextendedproperty 'MS_Description', 
   '处理完毕时间',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'wsj'
go

execute sp_addextendedproperty 'MS_Description', 
   '监护人',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'jhry'
go

execute sp_addextendedproperty 'MS_Description', 
   '操作人',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'czry'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户签名',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'yhqm'
go

execute sp_addextendedproperty 'MS_Description', 
   '停电时间',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'tdsj'
go

execute sp_addextendedproperty 'MS_Description', 
   '送电时间',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'sdsj'
go

execute sp_addextendedproperty 'MS_Description', 
   '停电线路杆号',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'tdxl'
go

execute sp_addextendedproperty 'MS_Description', 
   '操作项目',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'czxm'
go

execute sp_addextendedproperty 'MS_Description', 
   '临近带电设备',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'ddsb'
go

execute sp_addextendedproperty 'MS_Description', 
   '危险点及安措',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'wxd'
go

execute sp_addextendedproperty 'MS_Description', 
   '故障处理经过及结果',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'cljg'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'gzrjID'
go

execute sp_addextendedproperty 'MS_Description', 
   '操作员',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '生成日期',
   'user', 'dbo', 'table', 'PJ_22', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PJ_23                                                 */
/*==============================================================*/
create table dbo.PJ_23 (
   ID                   nvarchar(50)         not null,
   ParentID             nvarchar(50)         null,
   cqfw                 nvarchar(250)        null,
   cqdw                 nvarchar(50)         null,
   qdrq                 datetime             null,
   Remark               nvarchar(50)         null,
   gzrjID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   BigData              image                null,
   constraint PK_PJ_23 primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '配电设备产权、维护范围协议书',
   'user', 'dbo', 'table', 'PJ_23'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_23', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ParentID',
   'user', 'dbo', 'table', 'PJ_23', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '产权范围',
   'user', 'dbo', 'table', 'PJ_23', 'column', 'cqfw'
go

execute sp_addextendedproperty 'MS_Description', 
   '产权单位',
   'user', 'dbo', 'table', 'PJ_23', 'column', 'cqdw'
go

execute sp_addextendedproperty 'MS_Description', 
   '签订日期',
   'user', 'dbo', 'table', 'PJ_23', 'column', 'qdrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'PJ_23', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_23', 'column', 'gzrjID'
go

execute sp_addextendedproperty 'MS_Description', 
   '操作员',
   'user', 'dbo', 'table', 'PJ_23', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '生成日期',
   'user', 'dbo', 'table', 'PJ_23', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '生成文档',
   'user', 'dbo', 'table', 'PJ_23', 'column', 'BigData'
go

/*==============================================================*/
/* Table: PJ_24                                                 */
/*==============================================================*/
create table dbo.PJ_24 (
   ID                   nvarchar(50)         not null,
   ParentID             nvarchar(50)         null,
   sj                   nvarchar(250)        null,
   dd                   nvarchar(50)         null,
   nr                   nvarchar(500)        null,
   Remark               nvarchar(50)         null,
   gzrjID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   BigData              image                null,
   constraint PK_PJ_24 primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '设备变更通知书',
   'user', 'dbo', 'table', 'PJ_24'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_24', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ParentID',
   'user', 'dbo', 'table', 'PJ_24', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '变动时间',
   'user', 'dbo', 'table', 'PJ_24', 'column', 'sj'
go

execute sp_addextendedproperty 'MS_Description', 
   '变动地点',
   'user', 'dbo', 'table', 'PJ_24', 'column', 'dd'
go

execute sp_addextendedproperty 'MS_Description', 
   '变动内容',
   'user', 'dbo', 'table', 'PJ_24', 'column', 'nr'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'PJ_24', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_24', 'column', 'gzrjID'
go

execute sp_addextendedproperty 'MS_Description', 
   '操作员',
   'user', 'dbo', 'table', 'PJ_24', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '生成日期',
   'user', 'dbo', 'table', 'PJ_24', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '生成文档',
   'user', 'dbo', 'table', 'PJ_24', 'column', 'BigData'
go

/*==============================================================*/
/* Table: PJ_25                                                 */
/*==============================================================*/
create table dbo.PJ_25 (
   ID                   nvarchar(50)         not null,
   ParentID             nvarchar(50)         null,
   cqdw                 nvarchar(50)         null,
   qdrq                 datetime             null,
   Remark               nvarchar(50)         null,
   gzrjID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   BigData              image                null,
   constraint PK_PJ_25 primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '双（自备）电源协议书',
   'user', 'dbo', 'table', 'PJ_25'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_25', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ParentID',
   'user', 'dbo', 'table', 'PJ_25', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '产权单位',
   'user', 'dbo', 'table', 'PJ_25', 'column', 'cqdw'
go

execute sp_addextendedproperty 'MS_Description', 
   '签订日期',
   'user', 'dbo', 'table', 'PJ_25', 'column', 'qdrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'PJ_25', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_25', 'column', 'gzrjID'
go

execute sp_addextendedproperty 'MS_Description', 
   '操作员',
   'user', 'dbo', 'table', 'PJ_25', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '生成日期',
   'user', 'dbo', 'table', 'PJ_25', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '生成文档',
   'user', 'dbo', 'table', 'PJ_25', 'column', 'BigData'
go

/*==============================================================*/
/* Table: PJ_26                                                 */
/*==============================================================*/
create table dbo.PJ_26 (
   ID                   nvarchar(50)         not null,
   ParentID             nvarchar(50)         null,
   tzdw                 nvarchar(50)         null,
   tzrq                 datetime             null,
   Remark               nvarchar(50)         null,
   gzrjID               nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   BigData              image                null,
   constraint PK_PJ_26 primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '电力线路防护通知书',
   'user', 'dbo', 'table', 'PJ_26'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_26', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ParentID',
   'user', 'dbo', 'table', 'PJ_26', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '通知单位',
   'user', 'dbo', 'table', 'PJ_26', 'column', 'tzdw'
go

execute sp_addextendedproperty 'MS_Description', 
   '通知日期',
   'user', 'dbo', 'table', 'PJ_26', 'column', 'tzrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'PJ_26', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_26', 'column', 'gzrjID'
go

execute sp_addextendedproperty 'MS_Description', 
   '操作员',
   'user', 'dbo', 'table', 'PJ_26', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '生成日期',
   'user', 'dbo', 'table', 'PJ_26', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '生成文档',
   'user', 'dbo', 'table', 'PJ_26', 'column', 'BigData'
go

/*==============================================================*/
/* Table: PJ_dyk                                                */
/*==============================================================*/
create table dbo.PJ_dyk (
   ID                   nvarchar(50)         not null,
   ParentID             nvarchar(50)         null,
   dx                   nvarchar(50)         null,
   sx                   nvarchar(50)         null,
   bh                   nvarchar(50)         null,
   zjm                  nvarchar(50)         null,
   nr4                  nvarchar(2000)       null,
   nr                   nvarchar(2000)       null,
   nr2                  nvarchar(2000)       null,
   nr3                  nvarchar(2000)       null,
   constraint PK_PJ_DYK primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '维护记录相关的短语库，为了提高录入效率',
   'user', 'dbo', 'table', 'PJ_dyk'
go

execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', 'dbo', 'table', 'PJ_dyk', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ParentID',
   'user', 'dbo', 'table', 'PJ_dyk', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '对象',
   'user', 'dbo', 'table', 'PJ_dyk', 'column', 'dx'
go

execute sp_addextendedproperty 'MS_Description', 
   '属性',
   'user', 'dbo', 'table', 'PJ_dyk', 'column', 'sx'
go

execute sp_addextendedproperty 'MS_Description', 
   '短语编号',
   'user', 'dbo', 'table', 'PJ_dyk', 'column', 'bh'
go

execute sp_addextendedproperty 'MS_Description', 
   '助记码',
   'user', 'dbo', 'table', 'PJ_dyk', 'column', 'zjm'
go

execute sp_addextendedproperty 'MS_Description', 
   '短语内容',
   'user', 'dbo', 'table', 'PJ_dyk', 'column', 'nr4'
go

execute sp_addextendedproperty 'MS_Description', 
   '短语内容',
   'user', 'dbo', 'table', 'PJ_dyk', 'column', 'nr'
go

execute sp_addextendedproperty 'MS_Description', 
   '短语内容',
   'user', 'dbo', 'table', 'PJ_dyk', 'column', 'nr2'
go

execute sp_addextendedproperty 'MS_Description', 
   '短语内容',
   'user', 'dbo', 'table', 'PJ_dyk', 'column', 'nr3'
go

/*==============================================================*/
/* Table: PJ_gzrjnr                                             */
/*==============================================================*/
create table dbo.PJ_gzrjnr (
   gznrID               nvarchar(50)         not null,
   gzrjID               nvarchar(50)         null,
   fssj                 datetime             null,
   seq                  int                  null,
   gznr                 nvarchar(500)        null,
   fzr                  nvarchar(50)         null,
   cjry                 nvarchar(200)        null,
   ParentID             nvarchar(50)         null,
   CreateMan            nvarchar(10)         null,
   CreateDate           datetime             null,
   constraint PK_PJ_GZRJNR primary key (gznrID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '工作内容',
   'user', 'dbo', 'table', 'PJ_gzrjnr'
go

execute sp_addextendedproperty 'MS_Description', 
   '内容ID',
   'user', 'dbo', 'table', 'PJ_gzrjnr', 'column', 'gznrID'
go

execute sp_addextendedproperty 'MS_Description', 
   '工作日记ID',
   'user', 'dbo', 'table', 'PJ_gzrjnr', 'column', 'gzrjID'
go

execute sp_addextendedproperty 'MS_Description', 
   '发生时间',
   'user', 'dbo', 'table', 'PJ_gzrjnr', 'column', 'fssj'
go

execute sp_addextendedproperty 'MS_Description', 
   '序号',
   'user', 'dbo', 'table', 'PJ_gzrjnr', 'column', 'seq'
go

execute sp_addextendedproperty 'MS_Description', 
   '工作内容',
   'user', 'dbo', 'table', 'PJ_gzrjnr', 'column', 'gznr'
go

execute sp_addextendedproperty 'MS_Description', 
   '负责人',
   'user', 'dbo', 'table', 'PJ_gzrjnr', 'column', 'fzr'
go

execute sp_addextendedproperty 'MS_Description', 
   '参加人员',
   'user', 'dbo', 'table', 'PJ_gzrjnr', 'column', 'cjry'
go

execute sp_addextendedproperty 'MS_Description', 
   '关联记录',
   'user', 'dbo', 'table', 'PJ_gzrjnr', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写人',
   'user', 'dbo', 'table', 'PJ_gzrjnr', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '填写日期',
   'user', 'dbo', 'table', 'PJ_gzrjnr', 'column', 'CreateDate'
go

/*==============================================================*/
/* Table: PS_aqgj                                               */
/*==============================================================*/
create table dbo.PS_aqgj (
   sbID                 nvarchar(50)         not null,
   OrgID                nvarchar(50)         null,
   sbCode               nvarchar(50)         null,
   sbName               nvarchar(50)         null,
   syzq                 int                  null,
   syxm                 nvarchar(50)         null,
   syrq                 datetime             null,
   syrq2                datetime             null,
   sbType               nvarchar(50)         null,
   sbModle              nvarchar(50)         null,
   constraint PK_PS_AQGJ primary key (sbID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '安全工器具',
   'user', 'dbo', 'table', 'PS_aqgj'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备ID',
   'user', 'dbo', 'table', 'PS_aqgj', 'column', 'sbID'
go

execute sp_addextendedproperty 'MS_Description', 
   '部门ID',
   'user', 'dbo', 'table', 'PS_aqgj', 'column', 'OrgID'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备编号',
   'user', 'dbo', 'table', 'PS_aqgj', 'column', 'sbCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备名称',
   'user', 'dbo', 'table', 'PS_aqgj', 'column', 'sbName'
go

execute sp_addextendedproperty 'MS_Description', 
   '试验周期',
   'user', 'dbo', 'table', 'PS_aqgj', 'column', 'syzq'
go

execute sp_addextendedproperty 'MS_Description', 
   '试验项目',
   'user', 'dbo', 'table', 'PS_aqgj', 'column', 'syxm'
go

execute sp_addextendedproperty 'MS_Description', 
   '试验日期',
   'user', 'dbo', 'table', 'PS_aqgj', 'column', 'syrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '下次试验日期',
   'user', 'dbo', 'table', 'PS_aqgj', 'column', 'syrq2'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备种类',
   'user', 'dbo', 'table', 'PS_aqgj', 'column', 'sbType'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备型号',
   'user', 'dbo', 'table', 'PS_aqgj', 'column', 'sbModle'
go

/*==============================================================*/
/* Table: PS_dyxl                                               */
/*==============================================================*/
create table dbo.PS_dyxl (
   byqID                nvarchar(50)         null,
   dyxlID               nvarchar(50)         not null,
   dyxlCode             nvarchar(50)         null,
   dyxlName             nvarchar(50)         null,
   Remark               nvarchar(250)        null,
   constraint PK_PS_DYXL primary key (dyxlID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '低压线路',
   'user', 'dbo', 'table', 'PS_dyxl'
go

execute sp_addextendedproperty 'MS_Description', 
   '变台ID',
   'user', 'dbo', 'table', 'PS_dyxl', 'column', 'byqID'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路ID',
   'user', 'dbo', 'table', 'PS_dyxl', 'column', 'dyxlID'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路编号',
   'user', 'dbo', 'table', 'PS_dyxl', 'column', 'dyxlCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路名称',
   'user', 'dbo', 'table', 'PS_dyxl', 'column', 'dyxlName'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'PS_dyxl', 'column', 'Remark'
go

/*==============================================================*/
/* Table: PS_gjyb                                               */
/*==============================================================*/
create table dbo.PS_gjyb (
   sbID                 nvarchar(50)         not null,
   OrgID                nvarchar(50)         null,
   sbCode               nvarchar(50)         null,
   sbName               nvarchar(50)         null,
   jdgg                 nvarchar(50)         null,
   dw                   nvarchar(50)         null,
   sl                   int                  null,
   cj                   nvarchar(50)         null,
   lqsj                 datetime             null,
   Remark               nvarchar(50)         null,
   constraint PK_PS_GJYB primary key (sbID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '工具仪表',
   'user', 'dbo', 'table', 'PS_gjyb'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备ID',
   'user', 'dbo', 'table', 'PS_gjyb', 'column', 'sbID'
go

execute sp_addextendedproperty 'MS_Description', 
   '部门ID',
   'user', 'dbo', 'table', 'PS_gjyb', 'column', 'OrgID'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备编号',
   'user', 'dbo', 'table', 'PS_gjyb', 'column', 'sbCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备名称',
   'user', 'dbo', 'table', 'PS_gjyb', 'column', 'sbName'
go

execute sp_addextendedproperty 'MS_Description', 
   '规格精度',
   'user', 'dbo', 'table', 'PS_gjyb', 'column', 'jdgg'
go

execute sp_addextendedproperty 'MS_Description', 
   '单位',
   'user', 'dbo', 'table', 'PS_gjyb', 'column', 'dw'
go

execute sp_addextendedproperty 'MS_Description', 
   '数量',
   'user', 'dbo', 'table', 'PS_gjyb', 'column', 'sl'
go

execute sp_addextendedproperty 'MS_Description', 
   '制造厂家',
   'user', 'dbo', 'table', 'PS_gjyb', 'column', 'cj'
go

execute sp_addextendedproperty 'MS_Description', 
   '领取时间',
   'user', 'dbo', 'table', 'PS_gjyb', 'column', 'lqsj'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'PS_gjyb', 'column', 'Remark'
go

/*==============================================================*/
/* Table: PS_gt                                                 */
/*==============================================================*/
create table dbo.PS_gt (
   gtID                 nvarchar(50)         not null,
   LineCode             nvarchar(50)         null,
   gtCode               nvarchar(50)         null,
   gth                  nvarchar(10)         null,
   gtType               nvarchar(50)         null,
   gtModle              nvarchar(50)         null,
   gtHeight             decimal(5,1)         null,
   gtLon                decimal(12,8)        null,
   gtLat                decimal(12,8)        null,
   gtElev               int                  null,
   X54                  int                  null,
   Y54                  int                  null,
   gtSpan               decimal(5,1)         null,
   constraint PK_PS_GT primary key (gtID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '杆塔',
   'user', 'dbo', 'table', 'PS_gt'
go

execute sp_addextendedproperty 'MS_Description', 
   '杆塔ID',
   'user', 'dbo', 'table', 'PS_gt', 'column', 'gtID'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路编号',
   'user', 'dbo', 'table', 'PS_gt', 'column', 'LineCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '杆塔编号,线路编号+杆塔号',
   'user', 'dbo', 'table', 'PS_gt', 'column', 'gtCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '杆塔号',
   'user', 'dbo', 'table', 'PS_gt', 'column', 'gth'
go

execute sp_addextendedproperty 'MS_Description', 
   '杆塔类别',
   'user', 'dbo', 'table', 'PS_gt', 'column', 'gtType'
go

execute sp_addextendedproperty 'MS_Description', 
   '型号',
   'user', 'dbo', 'table', 'PS_gt', 'column', 'gtModle'
go

execute sp_addextendedproperty 'MS_Description', 
   '杆高',
   'user', 'dbo', 'table', 'PS_gt', 'column', 'gtHeight'
go

execute sp_addextendedproperty 'MS_Description', 
   '经度',
   'user', 'dbo', 'table', 'PS_gt', 'column', 'gtLon'
go

execute sp_addextendedproperty 'MS_Description', 
   '纬度',
   'user', 'dbo', 'table', 'PS_gt', 'column', 'gtLat'
go

execute sp_addextendedproperty 'MS_Description', 
   '高程',
   'user', 'dbo', 'table', 'PS_gt', 'column', 'gtElev'
go

execute sp_addextendedproperty 'MS_Description', 
   '经度2',
   'user', 'dbo', 'table', 'PS_gt', 'column', 'X54'
go

execute sp_addextendedproperty 'MS_Description', 
   '纬度2',
   'user', 'dbo', 'table', 'PS_gt', 'column', 'Y54'
go

execute sp_addextendedproperty 'MS_Description', 
   '档距',
   'user', 'dbo', 'table', 'PS_gt', 'column', 'gtSpan'
go

/*==============================================================*/
/* Index: Index_1                                               */
/*==============================================================*/
create unique index Index_1 on dbo.PS_gt (
gtCode ASC
)
go

/*==============================================================*/
/* Table: PS_gtsb                                               */
/*==============================================================*/
create table dbo.PS_gtsb (
   gtID                 nvarchar(50)         null,
   sbID                 nvarchar(50)         not null,
   sbCode               nvarchar(50)         null,
   sbType               nvarchar(50)         null,
   sbModle              nvarchar(50)         null,
   sbName               nvarchar(50)         null,
   sbNumber             smallint             null,
   C1                   nvarchar(50)         null,
   C2                   nvarchar(50)         null,
   C3                   nvarchar(50)         null,
   C4                   nvarchar(50)         null,
   C5                   nvarchar(50)         null,
   constraint PK_PS_GTSB primary key (sbID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '杆塔设备',
   'user', 'dbo', 'table', 'PS_gtsb'
go

execute sp_addextendedproperty 'MS_Description', 
   '杆塔ID',
   'user', 'dbo', 'table', 'PS_gtsb', 'column', 'gtID'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备ID',
   'user', 'dbo', 'table', 'PS_gtsb', 'column', 'sbID'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备编号',
   'user', 'dbo', 'table', 'PS_gtsb', 'column', 'sbCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备种类',
   'user', 'dbo', 'table', 'PS_gtsb', 'column', 'sbType'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备型号',
   'user', 'dbo', 'table', 'PS_gtsb', 'column', 'sbModle'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备名称',
   'user', 'dbo', 'table', 'PS_gtsb', 'column', 'sbName'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备数量',
   'user', 'dbo', 'table', 'PS_gtsb', 'column', 'sbNumber'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备参数',
   'user', 'dbo', 'table', 'PS_gtsb', 'column', 'C1'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备参数2',
   'user', 'dbo', 'table', 'PS_gtsb', 'column', 'C2'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备参数3',
   'user', 'dbo', 'table', 'PS_gtsb', 'column', 'C3'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备参数4',
   'user', 'dbo', 'table', 'PS_gtsb', 'column', 'C4'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备参数5',
   'user', 'dbo', 'table', 'PS_gtsb', 'column', 'C5'
go

/*==============================================================*/
/* Table: PS_kg                                                 */
/*==============================================================*/
create table dbo.PS_kg (
   gtID                 nvarchar(50)         null,
   kgID                 nvarchar(50)         not null,
   kgCode               nvarchar(50)         null,
   kgName               nvarchar(50)         null,
   kgModle              nvarchar(50)         null,
   kgVol                nvarchar(50)         null,
   kgPhase              nvarchar(50)         null,
   kgCapcity            int                  null,
   kgLineGroup          nvarchar(50)         null,
   kgFactory            nvarchar(50)         null,
   kgNumber             nvarchar(50)         null,
   kgMadeDate           datetime             null,
   kgCloseVol           nvarchar(50)         null,
   kgOpenEle            nvarchar(50)         null,
   kgInstallDate        datetime             null,
   kgInstallAdress      nvarchar(250)        null,
   kgState              nvarchar(50)         null,
   InDate               datetime             null,
   constraint PK_PS_KG primary key (kgID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '线路开关',
   'user', 'dbo', 'table', 'PS_kg'
go

execute sp_addextendedproperty 'MS_Description', 
   '杆塔ID',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'gtID'
go

execute sp_addextendedproperty 'MS_Description', 
   '开关ID',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'kgID'
go

execute sp_addextendedproperty 'MS_Description', 
   '开关编号',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'kgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '开关名称',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'kgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '开关型号',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'kgModle'
go

execute sp_addextendedproperty 'MS_Description', 
   '电压等级',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'kgVol'
go

execute sp_addextendedproperty 'MS_Description', 
   '遮断容量',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'kgPhase'
go

execute sp_addextendedproperty 'MS_Description', 
   '容量',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'kgCapcity'
go

execute sp_addextendedproperty 'MS_Description', 
   '重合装置',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'kgLineGroup'
go

execute sp_addextendedproperty 'MS_Description', 
   '制造厂',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'kgFactory'
go

execute sp_addextendedproperty 'MS_Description', 
   '制造号',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'kgNumber'
go

execute sp_addextendedproperty 'MS_Description', 
   '制造日期',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'kgMadeDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '合闸线圈电压',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'kgCloseVol'
go

execute sp_addextendedproperty 'MS_Description', 
   '跳闸电流',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'kgOpenEle'
go

execute sp_addextendedproperty 'MS_Description', 
   '安装日期',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'kgInstallDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '安装地点',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'kgInstallAdress'
go

execute sp_addextendedproperty 'MS_Description', 
   '状态',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'kgState'
go

execute sp_addextendedproperty 'MS_Description', 
   '投运日期',
   'user', 'dbo', 'table', 'PS_kg', 'column', 'InDate'
go

/*==============================================================*/
/* Table: PS_tq                                                 */
/*==============================================================*/
create table dbo.PS_tq (
   gtID                 nvarchar(50)         null,
   tqID                 nvarchar(50)         not null,
   tqCode               nvarchar(50)         null,
   tqName               nvarchar(50)         null,
   Remark               nvarchar(250)        null,
   Adress               nvarchar(50)         null,
   xlCode               nvarchar(50)         null,
   xlCode2              nvarchar(50)         null,
   Owner                nvarchar(50)         null,
   cby                  nvarchar(50)         null,
   cfy                  nvarchar(50)         null,
   Contractor           nvarchar(50)         null,
   Lowlossrate          decimal(8,5)         null,
   Class                nvarchar(50)         null,
   tclr                 smallint             null,
   hclr                 smallint             null,
   OrgCode              nvarchar(50)         null,
   InDate               datetime             null,
   constraint PK_PS_TQ primary key (tqID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '台区',
   'user', 'dbo', 'table', 'PS_tq'
go

execute sp_addextendedproperty 'MS_Description', 
   '杆塔ID',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'gtID'
go

execute sp_addextendedproperty 'MS_Description', 
   '台区ID',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'tqID'
go

execute sp_addextendedproperty 'MS_Description', 
   '台区编号',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'tqCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '台区名称',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'tqName'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '变台地址',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'Adress'
go

execute sp_addextendedproperty 'MS_Description', 
   '所属线路',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'xlCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '所属分支线路',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'xlCode2'
go

execute sp_addextendedproperty 'MS_Description', 
   '产权',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'Owner'
go

execute sp_addextendedproperty 'MS_Description', 
   '抄表员',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'cby'
go

execute sp_addextendedproperty 'MS_Description', 
   '催费员',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'cfy'
go

execute sp_addextendedproperty 'MS_Description', 
   '承包人',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'Contractor'
go

execute sp_addextendedproperty 'MS_Description', 
   '低损率',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'Lowlossrate'
go

execute sp_addextendedproperty 'MS_Description', 
   '运行班次',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'Class'
go

execute sp_addextendedproperty 'MS_Description', 
   '台抄例日',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'tclr'
go

execute sp_addextendedproperty 'MS_Description', 
   '户抄例日',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'hclr'
go

execute sp_addextendedproperty 'MS_Description', 
   '表字录入单位',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '投运日期',
   'user', 'dbo', 'table', 'PS_tq', 'column', 'InDate'
go

/*==============================================================*/
/* Table: PS_tqbyq                                              */
/*==============================================================*/
create table dbo.PS_tqbyq (
   tqID                 nvarchar(50)         null,
   byqID                nvarchar(50)         not null,
   byqCode              nvarchar(50)         null,
   byqName              nvarchar(50)         null,
   byqModle             nvarchar(50)         null,
   omniseal             bit                  null,
   byqOwner             nvarchar(50)         null,
   byqVol               nvarchar(50)         null,
   byqPhase             nvarchar(50)         null,
   byqCapcity           int                  null,
   byqLineGroup         nvarchar(50)         null,
   byqFactory           nvarchar(50)         null,
   byqNumber            nvarchar(50)         null,
   byqMadeDate          datetime             null,
   byqCycle             nvarchar(50)         null,
   byqVolOne            decimal(8,2)         null,
   byqVolTwo            decimal(8,2)         null,
   byqCurrentOne        decimal(8,2)         null,
   byqCurrentTwo        decimal(8,2)         null,
   byqInstallDate       datetime             null,
   byqInstallAdress     nvarchar(250)        null,
   byqState             nvarchar(50)         null,
   InDate               datetime             null,
   constraint PK_PS_TQBYQ primary key (byqID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '台区变压器',
   'user', 'dbo', 'table', 'PS_tqbyq'
go

execute sp_addextendedproperty 'MS_Description', 
   '台区ID',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'tqID'
go

execute sp_addextendedproperty 'MS_Description', 
   '变压器ID',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqID'
go

execute sp_addextendedproperty 'MS_Description', 
   '变压器编号',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '变压器名称',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqName'
go

execute sp_addextendedproperty 'MS_Description', 
   '变压器型号',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqModle'
go

execute sp_addextendedproperty 'MS_Description', 
   '全密封',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'omniseal'
go

execute sp_addextendedproperty 'MS_Description', 
   '所属',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqOwner'
go

execute sp_addextendedproperty 'MS_Description', 
   '电压等级',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqVol'
go

execute sp_addextendedproperty 'MS_Description', 
   '相别',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqPhase'
go

execute sp_addextendedproperty 'MS_Description', 
   '容量',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqCapcity'
go

execute sp_addextendedproperty 'MS_Description', 
   '结线组别',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqLineGroup'
go

execute sp_addextendedproperty 'MS_Description', 
   '制造厂',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqFactory'
go

execute sp_addextendedproperty 'MS_Description', 
   '制造号',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqNumber'
go

execute sp_addextendedproperty 'MS_Description', 
   '制造日期',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqMadeDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '周波',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqCycle'
go

execute sp_addextendedproperty 'MS_Description', 
   '一次电压',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqVolOne'
go

execute sp_addextendedproperty 'MS_Description', 
   '二次电压',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqVolTwo'
go

execute sp_addextendedproperty 'MS_Description', 
   '一次额定电流',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqCurrentOne'
go

execute sp_addextendedproperty 'MS_Description', 
   '二次额定电流',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqCurrentTwo'
go

execute sp_addextendedproperty 'MS_Description', 
   '安装日期',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqInstallDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '安装地点',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqInstallAdress'
go

execute sp_addextendedproperty 'MS_Description', 
   '状态',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'byqState'
go

execute sp_addextendedproperty 'MS_Description', 
   '投运日期',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'InDate'
go

/*==============================================================*/
/* Table: PS_tqdlbh                                             */
/*==============================================================*/
create table dbo.PS_tqdlbh (
   tqID                 nvarchar(50)         null,
   sbID                 nvarchar(50)         not null,
   tqName               nvarchar(50)         null,
   InstallAdress        nvarchar(50)         null,
   sbCode               nvarchar(50)         null,
   sbModle              nvarchar(50)         null,
   sbName               nvarchar(50)         null,
   Factory              nvarchar(50)         null,
   Number               nvarchar(50)         null,
   MadeDate             datetime             null,
   dzdl                 nvarchar(50)         null,
   dzsj                 nvarchar(50)         null,
   glr                  nvarchar(50)         null,
   InstallDate          datetime             null,
   State                nvarchar(50)         null,
   InDate               datetime             null,
   constraint PK_PS_TQDLBH primary key (sbID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '剩余电流动作保护器',
   'user', 'dbo', 'table', 'PS_tqdlbh'
go

execute sp_addextendedproperty 'MS_Description', 
   '台区ID',
   'user', 'dbo', 'table', 'PS_tqdlbh', 'column', 'tqID'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备ID',
   'user', 'dbo', 'table', 'PS_tqdlbh', 'column', 'sbID'
go

execute sp_addextendedproperty 'MS_Description', 
   '台区名称',
   'user', 'dbo', 'table', 'PS_tqdlbh', 'column', 'tqName'
go

execute sp_addextendedproperty 'MS_Description', 
   '安装地点',
   'user', 'dbo', 'table', 'PS_tqdlbh', 'column', 'InstallAdress'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备编号',
   'user', 'dbo', 'table', 'PS_tqdlbh', 'column', 'sbCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备型号',
   'user', 'dbo', 'table', 'PS_tqdlbh', 'column', 'sbModle'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备名称',
   'user', 'dbo', 'table', 'PS_tqdlbh', 'column', 'sbName'
go

execute sp_addextendedproperty 'MS_Description', 
   '制造厂',
   'user', 'dbo', 'table', 'PS_tqdlbh', 'column', 'Factory'
go

execute sp_addextendedproperty 'MS_Description', 
   '制造号',
   'user', 'dbo', 'table', 'PS_tqdlbh', 'column', 'Number'
go

execute sp_addextendedproperty 'MS_Description', 
   '制造日期',
   'user', 'dbo', 'table', 'PS_tqdlbh', 'column', 'MadeDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '动作电流',
   'user', 'dbo', 'table', 'PS_tqdlbh', 'column', 'dzdl'
go

execute sp_addextendedproperty 'MS_Description', 
   '动作时间',
   'user', 'dbo', 'table', 'PS_tqdlbh', 'column', 'dzsj'
go

execute sp_addextendedproperty 'MS_Description', 
   '管理人',
   'user', 'dbo', 'table', 'PS_tqdlbh', 'column', 'glr'
go

execute sp_addextendedproperty 'MS_Description', 
   '安装日期',
   'user', 'dbo', 'table', 'PS_tqdlbh', 'column', 'InstallDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '状态',
   'user', 'dbo', 'table', 'PS_tqdlbh', 'column', 'State'
go

execute sp_addextendedproperty 'MS_Description', 
   '投运日期',
   'user', 'dbo', 'table', 'PS_tqdlbh', 'column', 'InDate'
go

/*==============================================================*/
/* Table: PS_tqsb                                               */
/*==============================================================*/
create table dbo.PS_tqsb (
   tqID                 nvarchar(50)         null,
   sbID                 nvarchar(50)         not null,
   sbCode               nvarchar(50)         null,
   sbType               nvarchar(50)         null,
   sbModle              nvarchar(50)         null,
   sbName               nvarchar(50)         null,
   sbNumber             smallint             null,
   C1                   nvarchar(50)         null,
   C2                   nvarchar(50)         null,
   C3                   nvarchar(50)         null,
   C4                   nvarchar(50)         null,
   C5                   nvarchar(50)         null,
   constraint PK_PS_TQSB primary key (sbID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '台区设备',
   'user', 'dbo', 'table', 'PS_tqsb'
go

execute sp_addextendedproperty 'MS_Description', 
   '台区ID',
   'user', 'dbo', 'table', 'PS_tqsb', 'column', 'tqID'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备ID',
   'user', 'dbo', 'table', 'PS_tqsb', 'column', 'sbID'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备编号',
   'user', 'dbo', 'table', 'PS_tqsb', 'column', 'sbCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备种类',
   'user', 'dbo', 'table', 'PS_tqsb', 'column', 'sbType'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备型号',
   'user', 'dbo', 'table', 'PS_tqsb', 'column', 'sbModle'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备名称',
   'user', 'dbo', 'table', 'PS_tqsb', 'column', 'sbName'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备数量',
   'user', 'dbo', 'table', 'PS_tqsb', 'column', 'sbNumber'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备参数',
   'user', 'dbo', 'table', 'PS_tqsb', 'column', 'C1'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备参数2',
   'user', 'dbo', 'table', 'PS_tqsb', 'column', 'C2'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备参数3',
   'user', 'dbo', 'table', 'PS_tqsb', 'column', 'C3'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备参数4',
   'user', 'dbo', 'table', 'PS_tqsb', 'column', 'C4'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备参数5',
   'user', 'dbo', 'table', 'PS_tqsb', 'column', 'C5'
go

/*==============================================================*/
/* Table: PS_xl                                                 */
/*==============================================================*/
create table dbo.PS_xl (
   LineID               nvarchar(50)         not null,
   ParentID             nvarchar(50)         null,
   LineType             nvarchar(50)         null,
   LineCode             nvarchar(50)         null,
   LineName             nvarchar(50)         null,
   LineNamePath         nvarchar(250)        null,
   LineVol              nvarchar(50)         null,
   OrgCode              nvarchar(50)         null,
   OrgCode2             nvarchar(50)         null,
   Owner                nvarchar(50)         null default '局属',
   Contractor           nvarchar(50)         null,
   RunState             nvarchar(50)         null default '运行',
   InDate               datetime             null,
   LineGtbegin          nvarchar(50)         null,
   LineGtend            nvarchar(50)         null,
   WireType             nvarchar(50)         null,
   WireLength           int                  null,
   TotalLength          int                  null,
   TheoryLoss           decimal(8,5)         null,
   ActualLoss           decimal(8,5)         null,
   constraint PK_PS_XL primary key (LineID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '配电线路',
   'user', 'dbo', 'table', 'PS_xl'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路ID',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'LineID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ParentID',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路级别,1干线/2支线/3分线',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'LineType'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路编号',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'LineCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路名称',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'LineName'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路路径',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'LineNamePath'
go

execute sp_addextendedproperty 'MS_Description', 
   '电压等级',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'LineVol'
go

execute sp_addextendedproperty 'MS_Description', 
   '所属供电所',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '配出变电所',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'OrgCode2'
go

execute sp_addextendedproperty 'MS_Description', 
   '产权',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'Owner'
go

execute sp_addextendedproperty 'MS_Description', 
   '承包人',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'Contractor'
go

execute sp_addextendedproperty 'MS_Description', 
   '运行状态',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'RunState'
go

execute sp_addextendedproperty 'MS_Description', 
   '投运日期',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'InDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '起始杆号',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'LineGtbegin'
go

execute sp_addextendedproperty 'MS_Description', 
   '终止杆号',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'LineGtend'
go

execute sp_addextendedproperty 'MS_Description', 
   '导线型号',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'WireType'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路长度',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'WireLength'
go

execute sp_addextendedproperty 'MS_Description', 
   '总长度',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'TotalLength'
go

execute sp_addextendedproperty 'MS_Description', 
   '理论线损',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'TheoryLoss'
go

execute sp_addextendedproperty 'MS_Description', 
   '实际线损',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'ActualLoss'
go

/*==============================================================*/
/* Index: Index_1                                               */
/*==============================================================*/
create unique index Index_1 on dbo.PS_xl (
LineCode ASC
)
go

/*==============================================================*/
/* Index: Index_2                                               */
/*==============================================================*/
create index Index_2 on dbo.PS_xl (
ParentID ASC
)
go

/*==============================================================*/
/* Index: Index_3                                               */
/*==============================================================*/
create unique index Index_3 on dbo.PS_xl (
LineCode ASC
)
go

/*==============================================================*/
/* Table: mModulFun                                             */
/*==============================================================*/
create table dbo.mModulFun (
   FunID                nvarchar(50)         not null,
   Modu_ID              nvarchar(50)         null,
   FunCode              nvarchar(50)         null,
   FunName              nvarchar(50)         null,
   Remark               nvarchar(50)         null,
   constraint PK_MMODULFUN primary key (FunID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '模块功能',
   'user', 'dbo', 'table', 'mModulFun'
go

execute sp_addextendedproperty 'MS_Description', 
   '功能ID',
   'user', 'dbo', 'table', 'mModulFun', 'column', 'FunID'
go

execute sp_addextendedproperty 'MS_Description', 
   'Modu_ID',
   'user', 'dbo', 'table', 'mModulFun', 'column', 'Modu_ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '功能编号',
   'user', 'dbo', 'table', 'mModulFun', 'column', 'FunCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '功能名称',
   'user', 'dbo', 'table', 'mModulFun', 'column', 'FunName'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'mModulFun', 'column', 'Remark'
go

/*==============================================================*/
/* Table: mModule                                               */
/*==============================================================*/
create table dbo.mModule (
   Modu_ID              nvarchar(50)         collate Chinese_PRC_CI_AS not null,
   ModuTypes            nvarchar(250)        collate Chinese_PRC_CI_AS null,
   ModuName             nvarchar(100)        collate Chinese_PRC_CI_AS null,
   AssemblyFileName     nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Sequence             int                  null constraint DF__mModule__Sequenc__45BE5BA9 default (0),
   IsCores              nvarchar(50)         collate Chinese_PRC_CI_AS null constraint DF__mModule__IsCores__46B27FE2 default (0),
   Description          nvarchar(500)        collate Chinese_PRC_CI_AS null constraint DF__mModule__Descrip__47A6A41B default rtrim(''),
   ParentID             nvarchar(50)         collate Chinese_PRC_CI_AS null,
   MethodName           nvarchar(50)         collate Chinese_PRC_CI_AS null,
   IconName             nvarchar(50)         collate Chinese_PRC_CI_AS null,
   ActivityFlag         bit                  null,
   visiableFlag         bit                  null,
   constraint PK_mModule primary key nonclustered (Modu_ID)
         WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
)
ON [PRIMARY]
go

execute sp_addextendedproperty 'MS_Description', 
   '模块',
   'user', 'dbo', 'table', 'mModule'
go

execute sp_addextendedproperty 'MS_Description', 
   '模块标识',
   'user', 'dbo', 'table', 'mModule', 'column', 'Modu_ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '模块类型',
   'user', 'dbo', 'table', 'mModule', 'column', 'ModuTypes'
go

execute sp_addextendedproperty 'MS_Description', 
   '模块名称',
   'user', 'dbo', 'table', 'mModule', 'column', 'ModuName'
go

execute sp_addextendedproperty 'MS_Description', 
   '集合文件名',
   'user', 'dbo', 'table', 'mModule', 'column', 'AssemblyFileName'
go

execute sp_addextendedproperty 'MS_Description', 
   '排序',
   'user', 'dbo', 'table', 'mModule', 'column', 'Sequence'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否为核心',
   'user', 'dbo', 'table', 'mModule', 'column', 'IsCores'
go

execute sp_addextendedproperty 'MS_Description', 
   '描述',
   'user', 'dbo', 'table', 'mModule', 'column', 'Description'
go

execute sp_addextendedproperty 'MS_Description', 
   'ParentID',
   'user', 'dbo', 'table', 'mModule', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '方法',
   'user', 'dbo', 'table', 'mModule', 'column', 'MethodName'
go

execute sp_addextendedproperty 'MS_Description', 
   '图标',
   'user', 'dbo', 'table', 'mModule', 'column', 'IconName'
go

execute sp_addextendedproperty 'MS_Description', 
   '作业标记',
   'user', 'dbo', 'table', 'mModule', 'column', 'ActivityFlag'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否显示',
   'user', 'dbo', 'table', 'mModule', 'column', 'visiableFlag'
go

/*==============================================================*/
/* Table: mOrg                                                  */
/*==============================================================*/
create table dbo.mOrg (
   OrgID                nvarchar(50)         not null,
   ParentID             nvarchar(50)         null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   OrgType              nvarchar(50)         null,
   PSafeTime            datetime             null,
   DSafeTime            datetime             null,
   Remark               nvarchar(200)        null,
   OrgCode2             nvarchar(50)         null,
   C1                   nvarchar(200)        null,
   C2                   nvarchar(200)        null,
   C3                   nvarchar(200)        null,
   C4                   nvarchar(200)        null,
   C5                   nvarchar(200)        null,
   constraint PK_MORG primary key nonclustered (OrgID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '部门种类,(0/部门,1/供电所,2/变电所)',
   'user', 'dbo', 'table', 'mOrg'
go

execute sp_addextendedproperty 'MS_Description', 
   '部门ID',
   'user', 'dbo', 'table', 'mOrg', 'column', 'OrgID'
go

execute sp_addextendedproperty 'MS_Description', 
   '上级部门',
   'user', 'dbo', 'table', 'mOrg', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '部门编号',
   'user', 'dbo', 'table', 'mOrg', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '部门名称',
   'user', 'dbo', 'table', 'mOrg', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '部门种类',
   'user', 'dbo', 'table', 'mOrg', 'column', 'OrgType'
go

execute sp_addextendedproperty 'MS_Description', 
   '人生安全启始时间',
   'user', 'dbo', 'table', 'mOrg', 'column', 'PSafeTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备安全启始时间',
   'user', 'dbo', 'table', 'mOrg', 'column', 'DSafeTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'mOrg', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '部门原编号',
   'user', 'dbo', 'table', 'mOrg', 'column', 'OrgCode2'
go

execute sp_addextendedproperty 'MS_Description', 
   '未定义',
   'user', 'dbo', 'table', 'mOrg', 'column', 'C1'
go

execute sp_addextendedproperty 'MS_Description', 
   '未定义2',
   'user', 'dbo', 'table', 'mOrg', 'column', 'C2'
go

execute sp_addextendedproperty 'MS_Description', 
   '未定义3',
   'user', 'dbo', 'table', 'mOrg', 'column', 'C3'
go

execute sp_addextendedproperty 'MS_Description', 
   '未定义4',
   'user', 'dbo', 'table', 'mOrg', 'column', 'C4'
go

execute sp_addextendedproperty 'MS_Description', 
   '未定义5',
   'user', 'dbo', 'table', 'mOrg', 'column', 'C5'
go

/*==============================================================*/
/* Index: idx_bmbh                                              */
/*==============================================================*/
create unique index idx_bmbh on dbo.mOrg (
OrgCode ASC
)
go

/*==============================================================*/
/* Table: mPost                                                 */
/*==============================================================*/
create table dbo.mPost (
   PostID               nvarchar(50)         not null,
   PostCode             nvarchar(50)         null,
   PostName             nvarchar(50)         not null,
   PostType             nvarchar(50)         null,
   ParentID             nvarchar(50)         null,
   Remark               nvarchar(50)         null,
   constraint PK_MPOST primary key (PostID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '岗位',
   'user', 'dbo', 'table', 'mPost'
go

execute sp_addextendedproperty 'MS_Description', 
   '岗位ID',
   'user', 'dbo', 'table', 'mPost', 'column', 'PostID'
go

execute sp_addextendedproperty 'MS_Description', 
   '岗位编号',
   'user', 'dbo', 'table', 'mPost', 'column', 'PostCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '岗位名称',
   'user', 'dbo', 'table', 'mPost', 'column', 'PostName'
go

execute sp_addextendedproperty 'MS_Description', 
   '岗位分类',
   'user', 'dbo', 'table', 'mPost', 'column', 'PostType'
go

execute sp_addextendedproperty 'MS_Description', 
   '上级岗位',
   'user', 'dbo', 'table', 'mPost', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'mPost', 'column', 'Remark'
go

/*==============================================================*/
/* Table: mRole                                                 */
/*==============================================================*/
create table dbo.mRole (
   RoleID               nvarchar(50)         not null,
   RoleCode             nvarchar(50)         null,
   RoleName             nvarchar(50)         null,
   RoleType             nvarchar(50)         null,
   C1                   nvarchar(200)        null,
   C2                   nvarchar(200)        null,
   C3                   nvarchar(200)        null,
   C4                   nvarchar(200)        null,
   C5                   nvarchar(200)        null,
   constraint PK_MROLE primary key (RoleID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '角色',
   'user', 'dbo', 'table', 'mRole'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色ID',
   'user', 'dbo', 'table', 'mRole', 'column', 'RoleID'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色编号',
   'user', 'dbo', 'table', 'mRole', 'column', 'RoleCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色名称',
   'user', 'dbo', 'table', 'mRole', 'column', 'RoleName'
go

execute sp_addextendedproperty 'MS_Description', 
   '特性',
   'user', 'dbo', 'table', 'mRole', 'column', 'RoleType'
go

execute sp_addextendedproperty 'MS_Description', 
   '未定义',
   'user', 'dbo', 'table', 'mRole', 'column', 'C1'
go

execute sp_addextendedproperty 'MS_Description', 
   '未定义2',
   'user', 'dbo', 'table', 'mRole', 'column', 'C2'
go

execute sp_addextendedproperty 'MS_Description', 
   '未定义3',
   'user', 'dbo', 'table', 'mRole', 'column', 'C3'
go

execute sp_addextendedproperty 'MS_Description', 
   '未定义4',
   'user', 'dbo', 'table', 'mRole', 'column', 'C4'
go

execute sp_addextendedproperty 'MS_Description', 
   '未定义5',
   'user', 'dbo', 'table', 'mRole', 'column', 'C5'
go

/*==============================================================*/
/* Table: mUser                                                 */
/*==============================================================*/
create table dbo.mUser (
   UserID               nvarchar(50)         not null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   UserCode             nvarchar(50)         null,
   UserName             nvarchar(10)         null,
   PostName             nvarchar(50)         null,
   Sex                  nvarchar(10)         null,
   Birthday             datetime             null,
   LoginID              nvarchar(50)         null,
   Password             nvarchar(150)        null,
   Alias                nvarchar(10)         null,
   Valid                bit                  null,
   Type                 nvarchar(50)         null,
   Tel                  nvarchar(50)         null,
   Mail                 nvarchar(50)         null,
   C1                   nvarchar(200)        null,
   C2                   nvarchar(200)        null,
   C3                   nvarchar(200)        null,
   C4                   nvarchar(200)        null,
   C5                   nvarchar(200)        null,
   constraint PK_MUSER primary key (UserID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '职员',
   'user', 'dbo', 'table', 'mUser'
go

execute sp_addextendedproperty 'MS_Description', 
   '职员ID',
   'user', 'dbo', 'table', 'mUser', 'column', 'UserID'
go

execute sp_addextendedproperty 'MS_Description', 
   '部门编号',
   'user', 'dbo', 'table', 'mUser', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '部门名称',
   'user', 'dbo', 'table', 'mUser', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '职员编号',
   'user', 'dbo', 'table', 'mUser', 'column', 'UserCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '姓名',
   'user', 'dbo', 'table', 'mUser', 'column', 'UserName'
go

execute sp_addextendedproperty 'MS_Description', 
   '岗位',
   'user', 'dbo', 'table', 'mUser', 'column', 'PostName'
go

execute sp_addextendedproperty 'MS_Description', 
   '姓别',
   'user', 'dbo', 'table', 'mUser', 'column', 'Sex'
go

execute sp_addextendedproperty 'MS_Description', 
   '生日',
   'user', 'dbo', 'table', 'mUser', 'column', 'Birthday'
go

execute sp_addextendedproperty 'MS_Description', 
   '登录ID',
   'user', 'dbo', 'table', 'mUser', 'column', 'LoginID'
go

execute sp_addextendedproperty 'MS_Description', 
   '登录口令',
   'user', 'dbo', 'table', 'mUser', 'column', 'Password'
go

execute sp_addextendedproperty 'MS_Description', 
   '别名',
   'user', 'dbo', 'table', 'mUser', 'column', 'Alias'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否有效',
   'user', 'dbo', 'table', 'mUser', 'column', 'Valid'
go

execute sp_addextendedproperty 'MS_Description', 
   '分类',
   'user', 'dbo', 'table', 'mUser', 'column', 'Type'
go

execute sp_addextendedproperty 'MS_Description', 
   '手机',
   'user', 'dbo', 'table', 'mUser', 'column', 'Tel'
go

execute sp_addextendedproperty 'MS_Description', 
   '电子邮箱',
   'user', 'dbo', 'table', 'mUser', 'column', 'Mail'
go

execute sp_addextendedproperty 'MS_Description', 
   '未定义',
   'user', 'dbo', 'table', 'mUser', 'column', 'C1'
go

execute sp_addextendedproperty 'MS_Description', 
   '未定义2',
   'user', 'dbo', 'table', 'mUser', 'column', 'C2'
go

execute sp_addextendedproperty 'MS_Description', 
   '未定义3',
   'user', 'dbo', 'table', 'mUser', 'column', 'C3'
go

execute sp_addextendedproperty 'MS_Description', 
   '未定义4',
   'user', 'dbo', 'table', 'mUser', 'column', 'C4'
go

execute sp_addextendedproperty 'MS_Description', 
   '未定义5',
   'user', 'dbo', 'table', 'mUser', 'column', 'C5'
go

/*==============================================================*/
/* Table: rRoleModul                                            */
/*==============================================================*/
create table dbo.rRoleModul (
   FunID                nvarchar(50)         not null,
   RoleID               nvarchar(50)         not null,
   constraint PK_RROLEMODUL primary key (FunID, RoleID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '角色权限',
   'user', 'dbo', 'table', 'rRoleModul'
go

execute sp_addextendedproperty 'MS_Description', 
   '功能ID',
   'user', 'dbo', 'table', 'rRoleModul', 'column', 'FunID'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色ID',
   'user', 'dbo', 'table', 'rRoleModul', 'column', 'RoleID'
go

/*==============================================================*/
/* Table: rUserRole                                             */
/*==============================================================*/
create table dbo.rUserRole (
   RoleID               nvarchar(50)         not null,
   UserID               nvarchar(50)         not null,
   constraint PK_RUSERROLE primary key (RoleID, UserID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '职员关联角色',
   'user', 'dbo', 'table', 'rUserRole'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色ID',
   'user', 'dbo', 'table', 'rUserRole', 'column', 'RoleID'
go

execute sp_addextendedproperty 'MS_Description', 
   '职员ID',
   'user', 'dbo', 'table', 'rUserRole', 'column', 'UserID'
go

/*==============================================================*/
/* View: ViewGds                                                */
/*==============================================================*/
create view dbo.ViewGds as
select OrgCode,OrgName,PSafeTime,DSafeTime from mOrg where OrgType='1'
go

alter table dbo.PJ_05jckyjl
   add constraint FK_PJ_05JCK_REFERENCE_PJ_05JCK foreign key (jckyID)
      references dbo.PJ_05jcky (jckyID)
         on update cascade on delete cascade
go

alter table dbo.PJ_07jdzzjl
   add constraint FK_PJ_07JDZ_REFERENCE_PJ_07JDZ foreign key (jdzzID)
      references dbo.PJ_07jdzz (jdzzID)
go

alter table dbo.PJ_11byqbd
   add constraint FK_PJ_11BYQBD_REFERENCE_PS_TQBYQ foreign key (byqID)
      references dbo.PS_tqbyq (byqID)
         on update cascade on delete cascade
go

alter table dbo.PJ_11byqdydl
   add constraint FK_PJ_11BYQdy_REFERENCE_PS_TQBYQ foreign key (byqID)
      references dbo.PS_tqbyq (byqID)
         on update cascade on delete cascade
go

alter table dbo.PJ_11byqdzcl
   add constraint FK_PJ_11BYQdz_REFERENCE_PS_TQBYQ foreign key (byqID)
      references dbo.PS_tqbyq (byqID)
         on update cascade on delete cascade
go

alter table dbo.PJ_12kgbd
   add constraint FK_PJ_12KGB_REFERENCE_PS_KG foreign key (kgID)
      references dbo.PS_kg (kgID)
         on update cascade on delete cascade
go

alter table dbo.PJ_12kgjx
   add constraint FK_PJ_12KGJ_REFERENCE_PS_KG foreign key (kgID)
      references dbo.PS_kg (kgID)
go

alter table dbo.PJ_12kgsy
   add constraint FK_PJ_12KGS_REFERENCE_PS_KG foreign key (kgID)
      references dbo.PS_kg (kgID)
         on update cascade on delete cascade
go

alter table dbo.PJ_13dlbhjl
   add constraint FK_PJ_13DLB_REFERENCE_PS_TQDLB foreign key (sbID)
      references dbo.PS_tqdlbh (sbID)
         on update cascade on delete cascade
go

alter table dbo.PJ_14aqgjsy
   add constraint FK_PJ_14AQG_REFERENCE_PS_AQGJ foreign key (sbID)
      references dbo.PS_aqgj (sbID)
         on update cascade on delete cascade
go

alter table dbo.PJ_gzrjnr
   add constraint FK_PJ_GZRJN_REFERENCE_PJ_01GZR foreign key (gzrjID)
      references dbo.PJ_01gzrj (gzrjID)
         on delete cascade
go

alter table dbo.PS_aqgj
   add constraint FK_PS_AQGJ_REFERENCE_MORG foreign key (OrgID)
      references dbo.mOrg (OrgID)
         on update cascade on delete cascade
go

alter table dbo.PS_dyxl
   add constraint FK_PS_DYXL_REFERENCE_PS_TQBYQ foreign key (byqID)
      references dbo.PS_tqbyq (byqID)
         on update cascade on delete cascade
go

alter table dbo.PS_gjyb
   add constraint FK_PS_GJYB_REFERENCE_MORG foreign key (OrgID)
      references dbo.mOrg (OrgID)
         on update cascade on delete cascade
go

alter table dbo.PS_gt
   add constraint FK_PS_GT_REFERENCE_PS_XL foreign key (LineCode)
      references dbo.PS_xl (LineCode)
         on update cascade on delete cascade
go

alter table dbo.PS_gtsb
   add constraint FK_PS_GTSB_REFERENCE_PS_GT foreign key (gtID)
      references dbo.PS_gt (gtID)
         on update cascade on delete cascade
go

alter table dbo.PS_kg
   add constraint FK_PS_KG_REFERENCE_PS_GT foreign key (gtID)
      references dbo.PS_gt (gtID)
         on update cascade on delete set null
go

alter table dbo.PS_tq
   add constraint FK_PS_TQ_REFERENCE_PS_GT foreign key (gtID)
      references dbo.PS_gt (gtID)
         on update cascade on delete cascade
go

alter table dbo.PS_tqbyq
   add constraint FK_PS_TQBYQ_REFERENCE_PS_TQ foreign key (tqID)
      references dbo.PS_tq (tqID)
         on update cascade on delete cascade
go

alter table dbo.PS_tqdlbh
   add constraint FK_PS_TQDLB_REFERENCE_PS_TQ foreign key (tqID)
      references dbo.PS_tq (tqID)
         on update cascade on delete cascade
go

alter table dbo.PS_tqsb
   add constraint FK_PS_TQSB_REFERENCE_PS_TQ foreign key (tqID)
      references dbo.PS_tq (tqID)
         on update cascade on delete cascade
go

alter table dbo.PS_xl
   add constraint FK_PS_XL_REFERENCE_MORG foreign key (OrgCode)
      references dbo.mOrg (OrgCode)
go

alter table dbo.mModulFun
   add constraint FK_MMODULFU_REFERENCE_MMODULE foreign key (Modu_ID)
      references dbo.mModule (Modu_ID)
         on update cascade on delete cascade
go

alter table dbo.mUser
   add constraint FK_MUSER_REFERENCE_MORG foreign key (OrgCode)
      references dbo.mOrg (OrgCode)
go

alter table dbo.rRoleModul
   add constraint FK_RROLEMOD_REFERENCE_MMODULFU foreign key (FunID)
      references dbo.mModulFun (FunID)
         on update cascade on delete cascade
go

alter table dbo.rRoleModul
   add constraint FK_RROLEMOD_REFERENCE_MROLE foreign key (RoleID)
      references dbo.mRole (RoleID)
         on update cascade on delete cascade
go

alter table dbo.rUserRole
   add constraint FK_RUSERROL_REFERENCE_MROLE foreign key (RoleID)
      references dbo.mRole (RoleID)
         on update cascade on delete cascade
go

alter table dbo.rUserRole
   add constraint FK_RUSERROL_REFERENCE_MUSER foreign key (UserID)
      references dbo.mUser (UserID)
         on update cascade on delete cascade
go

