use [EbadaScgl]
if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PS_sbcs')
            and   type = 'U')
   drop table dbo.PS_sbcs
go

/*==============================================================*/
/* Table: PS_sbcs                                               */
/*==============================================================*/
create table dbo.PS_sbcs (
   bh                   nvarchar(50)         null,
   mc                   nvarchar(50)         null,
   xh                   nvarchar(50)         null,
   ID                   nvarchar(50)         not null,
   ParentID             nvarchar(50)         null,
   constraint PK_PS_SBCS primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '设备型号库',
   'user', 'dbo', 'table', 'PS_sbcs'
go

execute sp_addextendedproperty 'MS_Description', 
   '种类编号',
   'user', 'dbo', 'table', 'PS_sbcs', 'column', 'bh'
go

execute sp_addextendedproperty 'MS_Description', 
   '种类名称',
   'user', 'dbo', 'table', 'PS_sbcs', 'column', 'mc'
go

execute sp_addextendedproperty 'MS_Description', 
   '设备型号',
   'user', 'dbo', 'table', 'PS_sbcs', 'column', 'xh'
go

execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', 'dbo', 'table', 'PS_sbcs', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ParentID',
   'user', 'dbo', 'table', 'PS_sbcs', 'column', 'ParentID'
go
