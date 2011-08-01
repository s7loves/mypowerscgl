use EbadaScgl
go
if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PS_Image')
            and   type = 'U')
   drop table dbo.PS_Image
go

/*==============================================================*/
/* Table: PS_Image                                              */
/*==============================================================*/
create table dbo.PS_Image (
   ImageID              nvarchar(50)         not null,
   ImageName            nvarchar(50)         null,
   Remark               nvarchar(150)        null,
   ImageType            nvarchar(50)         null,
   ImageData            image                null,
   constraint PK_PS_IMAGE primary key (ImageID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   'ͼƬ��',
   'user', 'dbo', 'table', 'PS_Image'
go

execute sp_addextendedproperty 'MS_Description', 
   '�豸ID',
   'user', 'dbo', 'table', 'PS_Image', 'column', 'ImageID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ͼƬ����',
   'user', 'dbo', 'table', 'PS_Image', 'column', 'ImageName'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', 'dbo', 'table', 'PS_Image', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'PS_Image', 'column', 'ImageType'
go

execute sp_addextendedproperty 'MS_Description', 
   'ͼƬ',
   'user', 'dbo', 'table', 'PS_Image', 'column', 'ImageData'
go

--�޸�ps_xl

alter table ps_xl add ParentGT   nvarchar(50)   null default '',
	[LineP] [decimal](8, 5) NULL default '',
	[LineQ] [decimal](8, 5) NULL default '',
	[K] [decimal](8, 5) NULL default ''
go

--�޸�ps_gt
alter table ps_gt add
   gtMs                 decimal(5,1)         null default 1.7,
   gtZjfx               nvarchar(10)         null default '',
   gtZj                 nvarchar(10)         null default '',
   gtJg                 nvarchar(1)          null default '��',
   ImageID              nvarchar(150)        null default ''

go


