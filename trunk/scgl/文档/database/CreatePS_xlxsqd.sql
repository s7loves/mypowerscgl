use [EbadaScgl]
if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PS_xlxsqd')
            and   type = 'U')
   drop table dbo.PS_xlxsqd
go

/*==============================================================*/
/* Table: PS_xlxsqd                                             */
/*==============================================================*/
create table dbo.PS_xlxsqd (
   ID                   nvarchar(50)         not null,
   OrgCode              nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   LineID               nvarchar(50)         null,
   LineName             nvarchar(50)         null,
   xlqd                 nvarchar(50)         null,
   xsr                  nvarchar(50)         null,
   constraint PK_PS_XLXSQD primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '��·Ѳ������',
   'user', 'dbo', 'table', 'PS_xlxsqd'
go

execute sp_addextendedproperty 'MS_Description', 
   '��¼ID',
   'user', 'dbo', 'table', 'PS_xlxsqd', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '����������',
   'user', 'dbo', 'table', 'PS_xlxsqd', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '����������',
   'user', 'dbo', 'table', 'PS_xlxsqd', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '��·����',
   'user', 'dbo', 'table', 'PS_xlxsqd', 'column', 'LineID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��·����',
   'user', 'dbo', 'table', 'PS_xlxsqd', 'column', 'LineName'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ѳ������',
   'user', 'dbo', 'table', 'PS_xlxsqd', 'column', 'xlqd'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ѳ����',
   'user', 'dbo', 'table', 'PS_xlxsqd', 'column', 'xsr'
go
