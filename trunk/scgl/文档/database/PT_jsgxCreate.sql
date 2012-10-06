if exists (select 1
            from  sysobjects
           where  id = object_id('PT_InfoDevice')
            and   type = 'U')
   drop table PT_InfoDevice
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PT_InfoDeviceChanged')
            and   type = 'U')
   drop table PT_InfoDeviceChanged
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PT_pxdj')
            and   type = 'U')
   drop table PT_pxdj
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PT_pxgwbd')
            and   type = 'U')
   drop table PT_pxgwbd
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PT_pxkscjd')
            and   type = 'U')
   drop table PT_pxkscjd
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PT_pxksnr')
            and   type = 'U')
   drop table PT_pxksnr
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PT_pxygda')
            and   type = 'U')
   drop table PT_pxygda
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PT_qynj')
            and   name  = 'Index_2'
            and   indid > 0
            and   indid < 255)
   drop index PT_qynj.Index_2
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PT_qynj')
            and   name  = 'Index_1'
            and   indid > 0
            and   indid < 255)
   drop index PT_qynj.Index_1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PT_qynj')
            and   type = 'U')
   drop table PT_qynj
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PT_ydkdljcb')
            and   type = 'U')
   drop table PT_ydkdljcb
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PT_ydkygsdldf')
            and   type = 'U')
   drop table PT_ydkygsdldf
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PT_ydkywgf')
            and   type = 'U')
   drop table PT_ydkywgf
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PT_ydkyxswcqk')
            and   type = 'U')
   drop table PT_ydkyxswcqk
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PT_ydkyyxzb')
            and   type = 'U')
   drop table PT_ydkyyxzb
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PT_ylbx')
            and   type = 'U')
   drop table PT_ylbx
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PT_zfgjj')
            and   name  = 'Index_3'
            and   indid > 0
            and   indid < 255)
   drop index PT_zfgjj.Index_3
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PT_zfgjj')
            and   name  = 'Index_2'
            and   indid > 0
            and   indid < 255)
   drop index PT_zfgjj.Index_2
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PT_zfgjj')
            and   name  = 'Index_1'
            and   indid > 0
            and   indid < 255)
   drop index PT_zfgjj.Index_1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PT_zfgjj')
            and   type = 'U')
   drop table PT_zfgjj
go

/*==============================================================*/
/* Table: PT_InfoDevice                                         */
/*==============================================================*/
create table PT_InfoDevice (
   ID                   nvarchar(50)         not null,
   OrgName              nvarchar(50)         null,
   "User"               nvarchar(10)         null,
   DeviceName           nvarchar(50)         null,
   DeviceType           nvarchar(10)         null default '̨ʽ��',
   DeviceMode           nvarchar(50)         null,
   IP                   nvarchar(20)         null,
   Mac                  nvarchar(20)         null,
   Memory               nvarchar(10)         null,
   "Disk"               nvarchar(10)         null,
   CPU                  nvarchar(10)         null,
   Monitor              nvarchar(50)         null,
   BuyDate              datetime             null,
   ChangePath           nvarchar(100)        null default 'δ��ת',
   rowversion           timestamp            null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   constraint PK_PT_INFODEVICE primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ϣ�豸',
   'user', @CurrentUser, 'table', 'PT_InfoDevice'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'OrgName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ʹ����',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'User'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�豸����',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'DeviceName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�豸����,̨ʽ��|�ʻ���',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'DeviceType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ͺ�',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'DeviceMode'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'IP����',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'IP'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����������',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'Mac'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ڴ�',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'Memory'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ӳ��',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'Disk'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'CPU',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'CPU'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ʾ��',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'Monitor'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�豸��������',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'BuyDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ת·��',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'ChangePath'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'rowversion',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'rowversion'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��1',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��2',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��3',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'c3'
go

/*==============================================================*/
/* Table: PT_InfoDeviceChanged                                  */
/*==============================================================*/
create table PT_InfoDeviceChanged (
   ID                   nvarchar(50)         not null,
   DeviceID             nvarchar(50)         null,
   OrgName              nvarchar(50)         null,
   "User"               nvarchar(10)         null,
   OrgName2             nvarchar(50)         null,
   User2                nvarchar(10)         null,
   ChangedDate          datetime             null,
   rowversion           timestamp            null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   constraint PK_PT_INFODEVICECHANGED primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ϣ�豸��ת��¼',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�豸ID',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'DeviceID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��תǰ����',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'OrgName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��תǰʹ����',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'User'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ת����',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'OrgName2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ת��ʹ����',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'User2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ת����',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'ChangedDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'rowversion',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'rowversion'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��1',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��2',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��3',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'c3'
go

/*==============================================================*/
/* Table: PT_pxdj                                               */
/*==============================================================*/
create table PT_pxdj (
   ID                   nvarchar(50)         not null,
   ygdaID               nvarchar(50)         null,
   pxsj                 datetime             null,
   pxnr                 nvarchar(100)        null,
   psbx                 float                null,
   cq                   float                null,
   sjcj                 float                null,
   kscj                 float                null,
   zcj                  float                null,
   skjs                 nvarchar(50)         null,
   pxdd                 nvarchar(50)         null,
   rowversion           timestamp            null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   constraint PK_PT_PXDJ primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѵ�Ǽ�',
   'user', @CurrentUser, 'table', 'PT_pxdj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ա������ID',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'ygdaID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѵʱ��',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'pxsj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѵ����',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'pxnr'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ƽʱ����',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'psbx'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'cq'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ʵѵ�ɼ�',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'sjcj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���Գɼ�',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'kscj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ܳɼ�',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'zcj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ڿν�ʦ',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'skjs'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѵ�ص�',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'pxdd'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'rowversion',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'rowversion'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��1',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��2',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��3',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'c3'
go

/*==============================================================*/
/* Table: PT_pxgwbd                                             */
/*==============================================================*/
create table PT_pxgwbd (
   ID                   nvarchar(50)         not null,
   ygdaID               nvarchar(50)         null,
   xgwmc                nvarchar(50)         null,
   ygwmmc               nvarchar(50)         null,
   bdsj                 datetime             null,
   bdyy                 nvarchar(50)         null,
   bz                   nvarchar(50)         null,
   rowversion           timestamp            null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   constraint PK_PT_PXGWBD primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��λ�䶯���',
   'user', @CurrentUser, 'table', 'PT_pxgwbd'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ա������ID',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'ygdaID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ָ�λ����',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'xgwmc'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ԭ��λ����',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'ygwmmc'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�䶯ʱ��',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'bdsj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�䶯ԭ��',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'bdyy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'bz'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'rowversion',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'rowversion'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��1',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��2',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��3',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'c3'
go

/*==============================================================*/
/* Table: PT_pxkscjd                                            */
/*==============================================================*/
create table PT_pxkscjd (
   ID                   nvarchar(50)         not null,
   pxnrID               nvarchar(50)         null,
   xh                   int                  null,
   dw                   nvarchar(50)         null,
   xm                   nvarchar(20)         null,
   fs                   float                null,
   rowversion           timestamp            null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   constraint PK_PT_PXKSCJD primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѵ���Գɼ���',
   'user', @CurrentUser, 'table', 'PT_pxkscjd'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', @CurrentUser, 'table', 'PT_pxkscjd', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѵ����ID',
   'user', @CurrentUser, 'table', 'PT_pxkscjd', 'column', 'pxnrID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���',
   'user', @CurrentUser, 'table', 'PT_pxkscjd', 'column', 'xh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��λ',
   'user', @CurrentUser, 'table', 'PT_pxkscjd', 'column', 'dw'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'PT_pxkscjd', 'column', 'xm'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'PT_pxkscjd', 'column', 'fs'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'rowversion',
   'user', @CurrentUser, 'table', 'PT_pxkscjd', 'column', 'rowversion'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��1',
   'user', @CurrentUser, 'table', 'PT_pxkscjd', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��2',
   'user', @CurrentUser, 'table', 'PT_pxkscjd', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��3',
   'user', @CurrentUser, 'table', 'PT_pxkscjd', 'column', 'c3'
go

/*==============================================================*/
/* Table: PT_pxksnr                                             */
/*==============================================================*/
create table PT_pxksnr (
   ID                   nvarchar(50)         not null,
   pxrq                 datetime             null,
   pxdx                 nvarchar(50)         null,
   pxr                  nvarchar(50)         null,
   ksnr                 nvarchar(150)        null,
   pxdd                 nvarchar(50)         null,
   rowversion           timestamp            null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   constraint PK_PT_PXKSNR primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѵ��������',
   'user', @CurrentUser, 'table', 'PT_pxksnr'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', @CurrentUser, 'table', 'PT_pxksnr', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѵ����',
   'user', @CurrentUser, 'table', 'PT_pxksnr', 'column', 'pxrq'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѵ����',
   'user', @CurrentUser, 'table', 'PT_pxksnr', 'column', 'pxdx'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѵ��',
   'user', @CurrentUser, 'table', 'PT_pxksnr', 'column', 'pxr'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'PT_pxksnr', 'column', 'ksnr'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѵ�ص�',
   'user', @CurrentUser, 'table', 'PT_pxksnr', 'column', 'pxdd'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'rowversion',
   'user', @CurrentUser, 'table', 'PT_pxksnr', 'column', 'rowversion'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��1',
   'user', @CurrentUser, 'table', 'PT_pxksnr', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��2',
   'user', @CurrentUser, 'table', 'PT_pxksnr', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��3',
   'user', @CurrentUser, 'table', 'PT_pxksnr', 'column', 'c3'
go

/*==============================================================*/
/* Table: PT_pxygda                                             */
/*==============================================================*/
create table PT_pxygda (
   ID                   nvarchar(50)         not null,
   xm                   nvarchar(50)         null,
   xb                   nvarchar(20)         null,
   zzmm                 nvarchar(50)         null,
   csrq                 datetime             null,
   mz                   nvarchar(20)         null,
   zc                   nvarchar(20)         null,
   yxl                  nvarchar(20)         null,
   xxl                  nvarchar(20)         null,
   cjgzsj               datetime             null,
   sfzh                 nvarchar(20)         null,
   rowversion           timestamp            null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   constraint PK_PT_PXYGDA primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ա������',
   'user', @CurrentUser, 'table', 'PT_pxygda'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'xm'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ա�',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'xb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ò',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'zzmm'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'csrq'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'mz'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ְ��',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'zc'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ԭѧ��',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'yxl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѧ��',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'xxl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�μӹ���ʱ��',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'cjgzsj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���֤��',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'sfzh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'rowversion',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'rowversion'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��1',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��2',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��3',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'c3'
go

/*==============================================================*/
/* Table: PT_qynj                                               */
/*==============================================================*/
create table PT_qynj (
   ID                   nvarchar(50)         not null,
   bh                   nvarchar(20)         null,
   xm                   nvarchar(20)         null,
   sfzh                 nvarchar(20)         null,
   hj                   money                null,
   y2008                money                null,
   y2009                money                null,
   y2010                money                null,
   y2011                money                null,
   y2012                money                null,
   y2013                money                null,
   y2014                money                null,
   y2015                money                null,
   y2016                money                null,
   y2017                money                null,
   y2018                money                null,
   y2019                money                null,
   y2020                money                null,
   rowversion           timestamp            null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   constraint PK_PT_QYNJ primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ҵ���',
   'user', @CurrentUser, 'table', 'PT_qynj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'bh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'xm'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���֤��',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'sfzh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ϼ�',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'hj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2008��',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2008'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2009��',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2009'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2010��',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2010'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2011��',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2011'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2012��',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2012'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2013��',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2013'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2014��',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2014'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2015��',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2015'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2016��',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2016'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2017��',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2017'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2018��',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2018'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2019��',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2019'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2020��',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2020'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'rowversion',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'rowversion'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��1',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��2',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��3',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'c3'
go

/*==============================================================*/
/* Index: Index_1                                               */
/*==============================================================*/
create unique index Index_1 on PT_qynj (
bh ASC
)
go

/*==============================================================*/
/* Index: Index_2                                               */
/*==============================================================*/
create unique index Index_2 on PT_qynj (
sfzh ASC
)
go

/*==============================================================*/
/* Table: PT_ydkdljcb                                           */
/*==============================================================*/
create table PT_ydkdljcb (
   ID                   nvarchar(50)         not null,
   ny                   nvarchar(10)         null,
   orgname              nvarchar(50)         null,
   fgdzb                float                null,
   fsjwc                float                null,
   fzj                  float                null,
   fbz                  float                null,
   fjc                  float                null,
   fgdl                 float                null,
   fbzssb               float                null,
   fbzssdl              float                null,
   fsdl                 float                null,
   fsjssb               float                null,
   fsjssdl              float                null,
   fzjdl                float                null,
   fpjsddj              float                null,
   fjcjeb               float                null,
   fjcje                float                null,
   fjczje               float                null,
   rowversion           timestamp            null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   constraint PK_PT_YDKDLJCB primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '*��*��10kV���𡢵������𽱳ͱ�',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����,201201',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'ny'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'orgname'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ָ��',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fgdzb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ʵ�����',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fsjwc'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fzj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��׼',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fbz'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����(Ԫ)',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fjc'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fgdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ָ��Ӧ��ʧ%',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fbzssb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ָ��Ӧ��ʧ����',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fbzssdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�۵���',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fsdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ʵ�������ʧ%',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fsjssb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ʵ��ʵ�ɵ���',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fsjssdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fzjdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ƽ���۵絥��',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fpjsddj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ͽ���׼%',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fjcjeb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ͽ��',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fjcje'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ܼƽ��ͽ��',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fjczje'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'rowversion',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'rowversion'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��1',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��2',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��3',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'c3'
go

/*==============================================================*/
/* Table: PT_ydkygsdldf                                         */
/*==============================================================*/
create table PT_ydkygsdldf (
   ID                   nvarchar(50)         not null,
   ny                   nvarchar(10)         null,
   ydxm                 nvarchar(20)         null,
   fgdl                 float                null,
   fgdf                 float                null,
   fzgdl                float                null,
   fgddj                float                null,
   fgdbl                float                null,
   fsdl                 float                null,
   fsdf                 float                null,
   fzsdf                float                null,
   fsddj                float                null,
   fsdbl                float                null,
   rowversion           timestamp            null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   constraint PK_PT_YDKYGSDLDF primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�¹����۵������',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����,201201',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'ny'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�õ���Ŀ',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'ydxm'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fgdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fgdf'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ܹ�����',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fzgdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���絥��',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fgddj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fgdbl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�۵���',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fsdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�۵��',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fsdf'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���۵��',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fzsdf'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�۵絥��',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fsddj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�۵����',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fsdbl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'rowversion',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'rowversion'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��1',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��2',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��3',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'c3'
go

/*==============================================================*/
/* Table: PT_ydkywgf                                            */
/*==============================================================*/
create table PT_ydkywgf (
   ID                   nvarchar(50)         not null,
   ny                   nvarchar(10)         null,
   bq                   float                null,
   lj                   float                null,
   rowversion           timestamp            null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   constraint PK_PT_YDKYWGF primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ά�ܷ�',
   'user', @CurrentUser, 'table', 'PT_ydkywgf'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', @CurrentUser, 'table', 'PT_ydkywgf', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����,201201',
   'user', @CurrentUser, 'table', 'PT_ydkywgf', 'column', 'ny'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'PT_ydkywgf', 'column', 'bq'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ۼ�',
   'user', @CurrentUser, 'table', 'PT_ydkywgf', 'column', 'lj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'rowversion',
   'user', @CurrentUser, 'table', 'PT_ydkywgf', 'column', 'rowversion'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��1',
   'user', @CurrentUser, 'table', 'PT_ydkywgf', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��2',
   'user', @CurrentUser, 'table', 'PT_ydkywgf', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��3',
   'user', @CurrentUser, 'table', 'PT_ydkywgf', 'column', 'c3'
go

/*==============================================================*/
/* Table: PT_ydkyxswcqk                                         */
/*==============================================================*/
create table PT_ydkyxswcqk (
   ID                   nvarchar(50)         not null,
   ny                   nvarchar(10)         null,
   fgdl                 float                null,
   fsdl                 float                null,
   fbbxsb               float                null,
   fsdldh               float                null,
   fdhxsb               float                null,
   fsdl10kv             float                null,
   f10kvxsb             float                null,
   fdybdl               float                null,
   fdysdl               float                null,
   fdyxsb               float                null,
   rowversion           timestamp            null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   constraint PK_PT_YDKYXSWCQK primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������������',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����,201201',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'ny'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fgdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�۵�������',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fsdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������%',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fbbxsb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�۵�������',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fsdldh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������%',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fdhxsb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�۵���10kV',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fsdl10kv'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '10kV����%',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'f10kvxsb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѹ������',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fdybdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѹ�۵���',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fdysdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѹ����%',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fdyxsb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'rowversion',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'rowversion'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��1',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��2',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��3',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'c3'
go

/*==============================================================*/
/* Table: PT_ydkyyxzb                                           */
/*==============================================================*/
create table PT_ydkyyxzb (
   ID                   nvarchar(50)         not null,
   ny                   nvarchar(10)         null,
   fgdl                 float                null,
   fsdlbb               float                null,
   fsdldh               float                null,
   fgyxs                float                null,
   fzhxs                float                null,
   fbssrbb              float                null,
   fbssrdh              float                null,
   fgddjsf              float                null,
   fgddj                float                null,
   fsddjbb              float                null,
   fsddjdh              float                null,
   fgdkwbb              float                null,
   fgdkwdh              float                null,
   rowversion           timestamp            null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   constraint PK_PT_YDKYYXZB primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ӫ��ָ��������',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����,201201',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'ny'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fgdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�۵���ͳ�Ʊ���',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fsdlbb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�۵������۵���',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fsdldh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѹ����',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fgyxs'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ۺ�����',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fzhxs'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������ͳ�Ʊ���',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fbssrbb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����������۵���',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fbssrdh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ƽ�����絥�ۺ����շ�',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fgddjsf'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ƽ�����絥�۲������շ�',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fgddj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ƽ���۵絥�۱���',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fsddjbb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ƽ���۵絥�۵���',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fsddjdh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ǧǧ��ʱ���뱨��',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fgdkwbb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ǧǧ��ʱ���뵽��',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fgdkwdh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'rowversion',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'rowversion'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��1',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��2',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��3',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'c3'
go

/*==============================================================*/
/* Table: PT_ylbx                                               */
/*==============================================================*/
create table PT_ylbx (
   ID                   bigint               identity(1,1),
   year                 varchar(10)          collate Chinese_PRC_CI_AS null,
   month                varchar(10)          collate Chinese_PRC_CI_AS null,
   type                 varchar(50)          collate Chinese_PRC_CI_AS null default '1',
   ���ձ��                 nvarchar(20)         collate Chinese_PRC_CI_AS null,
   ���֤��                 nvarchar(20)         collate Chinese_PRC_CI_AS null,
   �ɷѹ���                 money                null,
   ְ���ϼ�                 money                null,
   ְ����λ�ɷ�               money                null,
   ְ������Ӧ��               money                null,
   ����                   nvarchar(10)         collate Chinese_PRC_CI_AS null,
   �α����                 nvarchar(10)         collate Chinese_PRC_CI_AS null default 'ʡֱ��ְ',
   ��λ���ɴ��               money                null,
   ���˽��ɴ��               money                null,
   ��λ�����                money                null,
   ��������                 money                null,
   ���䱣��                 money                null,
   �ϼƽ��                 money                null,
   c1                   nvarchar(50)         collate Chinese_PRC_CI_AS null,
   c2                   nvarchar(50)         collate Chinese_PRC_CI_AS null,
   c3                   nvarchar(50)         collate Chinese_PRC_CI_AS null,
   c4                   nvarchar(50)         collate Chinese_PRC_CI_AS null,
   rowversion           timestamp            null,
   constraint PK_RS_bx primary key (ID)
         WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
)
ON [PRIMARY]
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ҽ�Ʊ���',
   'user', @CurrentUser, 'table', 'PT_ylbx'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��',
   'user', @CurrentUser, 'table', 'PT_ylbx', 'column', 'year'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��',
   'user', @CurrentUser, 'table', 'PT_ylbx', 'column', 'month'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ա����,����-1���繤-2',
   'user', @CurrentUser, 'table', 'PT_ylbx', 'column', 'type'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�α����,ʡֱ��ְ|ʡֱ����',
   'user', @CurrentUser, 'table', 'PT_ylbx', 'column', '�α����'
go

/*==============================================================*/
/* Table: PT_zfgjj                                              */
/*==============================================================*/
create table PT_zfgjj (
   ID                   nvarchar(50)         not null,
   bh                   nvarchar(20)         null,
   xm                   nvarchar(20)         null,
   sfzh                 nvarchar(20)         null,
   pwd                  nvarchar(20)         null,
   gjjzh                nvarchar(20)         null,
   yhzh                 nvarchar(20)         null,
   hj                   money                null,
   y2008                money                null,
   y2009                money                null,
   y2011                money                null,
   y2010                money                null,
   y2012                money                null,
   y2013                money                null,
   y2014                money                null,
   y2015                money                null,
   y2016                money                null,
   y2017                money                null,
   y2018                money                null,
   y2019                money                null,
   y2020                money                null,
   rowversion           timestamp            null,
   c1                   nvarchar(50)         null,
   c2                   nvarchar(50)         null,
   c3                   nvarchar(50)         null,
   constraint PK_PT_ZFGJJ primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ס��������',
   'user', @CurrentUser, 'table', 'PT_zfgjj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ID',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'bh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'xm'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���֤��',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'sfzh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѯ����',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'pwd'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������˺�',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'gjjzh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����˺�',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'yhzh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ϼ�',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'hj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2008��',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2008'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2009��',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2009'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2011��',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2011'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2010��',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2010'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2012��',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2012'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2013��',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2013'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2014��',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2014'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2015��',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2015'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2016��',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2016'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2017��',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2017'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2018��',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2018'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2019��',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2019'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2020��',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2020'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'rowversion',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'rowversion'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��1',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��2',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ��3',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'c3'
go

/*==============================================================*/
/* Index: Index_1                                               */
/*==============================================================*/
create unique index Index_1 on PT_zfgjj (
bh ASC
)
go

/*==============================================================*/
/* Index: Index_2                                               */
/*==============================================================*/
create unique index Index_2 on PT_zfgjj (
sfzh ASC
)
go

/*==============================================================*/
/* Index: Index_3                                               */
/*==============================================================*/
create unique index Index_3 on PT_zfgjj (
gjjzh ASC
)
go
