/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     2011-5-17 20:58:26                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PS_dyxl') and o.name = 'FK_PS_DYXL_REFERENCE_PS_TQBYQ')
alter table dbo.PS_dyxl
   drop constraint FK_PS_DYXL_REFERENCE_PS_TQBYQ
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
           where  id = object_id('dbo.PS_dyxl')
            and   type = 'U')
   drop table dbo.PS_dyxl
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
/* Table: PS_gt                                                 */
/*==============================================================*/
create table dbo.PS_gt (
   gtID                 nvarchar(50)         not null,
   LineCode             nvarchar(50)         null,
   gtCode               nvarchar(50)         null,
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
   '杆塔ID',
   'user', 'dbo', 'table', 'PS_gt', 'column', 'gtID'
go

execute sp_addextendedproperty 'MS_Description', 
   '线路编号',
   'user', 'dbo', 'table', 'PS_gt', 'column', 'LineCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '杆塔编号',
   'user', 'dbo', 'table', 'PS_gt', 'column', 'gtCode'
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
/* Table: PS_tq                                                 */
/*==============================================================*/
create table dbo.PS_tq (
   gtID                 nvarchar(50)         null,
   tqID                 nvarchar(50)         not null,
   tqCode               nvarchar(50)         null,
   tqName               nvarchar(50)         null,
   Remark               nvarchar(250)        null,
   constraint PK_PS_TQ primary key (tqID)
)
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

/*==============================================================*/
/* Table: PS_tqbyq                                              */
/*==============================================================*/
create table dbo.PS_tqbyq (
   tqID                 nvarchar(50)         null,
   byqID                nvarchar(50)         not null,
   byqCode              nvarchar(50)         null,
   byqName              nvarchar(50)         null,
   byqModle             nvarchar(50)         null,
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
   constraint PK_PS_TQBYQ primary key (byqID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '台区ID',
   'user', 'dbo', 'table', 'PS_tqbyq', 'column', 'tqID'
go

execute sp_addextendedproperty 'MS_Description', 
   '变台ID',
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
   LineGtbegin          nvarchar(50)         null,
   LineGtend            nvarchar(50)         null,
   WireType             nvarchar(50)         null,
   WireLength           int                  null,
   TotalLength          int                  null,
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
   '线路级别,0干线/1支线/2分线',
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
   '所在单位',
   'user', 'dbo', 'table', 'PS_xl', 'column', 'OrgCode'
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
/* Table: mOrg                                                  */
/*==============================================================*/
create table dbo.mOrg (
   OrgID                nvarchar(50)         not null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   OrgType              nvarchar(50)         null,
   PSafeTime            datetime             null,
   DSafeTime            datetime             null,
   Remark               nvarchar(200)        null,
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
   'bmID',
   'user', 'dbo', 'table', 'mOrg', 'column', 'OrgID'
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
   Sex                  nvarchar(10)         null,
   Birthday             datetime             null,
   LoginID              nvarchar(50)         null,
   Password             varbinary(150)       null,
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

alter table dbo.PS_dyxl
   add constraint FK_PS_DYXL_REFERENCE_PS_TQBYQ foreign key (byqID)
      references dbo.PS_tqbyq (byqID)
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

