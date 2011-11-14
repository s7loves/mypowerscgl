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
   'ȱ�ݷ���ͳ��',
   'user', 'dbo', 'table', 'PJ_qxfl'
go

execute sp_addextendedproperty 'MS_Description', 
   '��¼ID',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '����������',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'OrgCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '����������',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'OrgName'
go

execute sp_addextendedproperty 'MS_Description', 
   '��·����',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'LineID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��·����',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'LineName'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ѳ������',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'xlqd'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ѳ��ʱ��',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'xssj'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ѳ����',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'xsr'
go

execute sp_addextendedproperty 'MS_Description', 
   'ȱ������',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'qxnr'
go

execute sp_addextendedproperty 'MS_Description', 
   'ȱ�����',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'qxlb'
go

execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'xcr'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'xcrq'
go

execute sp_addextendedproperty 'MS_Description', 
   '��д��',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'CreateMan'
go

execute sp_addextendedproperty 'MS_Description', 
   '��д����',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   'gzrjID',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 'gzrjID'
go
execute sp_addextendedproperty 'MS_Description', 
   'ȱ����Դ',
   'user', 'dbo', 'table', 'PJ_qxfl', 'column', 's1'
go