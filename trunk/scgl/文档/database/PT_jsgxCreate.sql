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
   DeviceType           nvarchar(10)         null default '台式机',
   DeviceMode           nvarchar(50)         null,
   IP                   nvarchar(20)         null,
   Mac                  nvarchar(20)         null,
   Memory               nvarchar(10)         null,
   "Disk"               nvarchar(10)         null,
   CPU                  nvarchar(10)         null,
   Monitor              nvarchar(50)         null,
   BuyDate              datetime             null,
   ChangePath           nvarchar(100)        null default '未流转',
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
   '信息设备',
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
   '所属部门',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'OrgName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '使用者',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'User'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备名称',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'DeviceName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备种类,台式机|笔机本',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'DeviceType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '型号',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'DeviceMode'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'IP号码',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'IP'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '物理网卡号',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'Mac'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '内存',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'Memory'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '硬盘',
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
   '显示器',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'Monitor'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备购置日期',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'BuyDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '流转路径',
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
   '预留1',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留2',
   'user', @CurrentUser, 'table', 'PT_InfoDevice', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留3',
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
   '信息设备流转记录',
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
   '设备ID',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'DeviceID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '流转前部门',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'OrgName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '流转前使用者',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'User'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '流转后部门',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'OrgName2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '流转后使用者',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'User2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '流转日期',
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
   '预留1',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留2',
   'user', @CurrentUser, 'table', 'PT_InfoDeviceChanged', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留3',
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
   '培训登记',
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
   '员工档案ID',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'ygdaID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '培训时间',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'pxsj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '培训内容',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'pxnr'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '平时表现',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'psbx'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '出勤',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'cq'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '实训成绩',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'sjcj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '考试成绩',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'kscj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '总成绩',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'zcj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '授课教师',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'skjs'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '培训地点',
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
   '预留1',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留2',
   'user', @CurrentUser, 'table', 'PT_pxdj', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留3',
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
   '岗位变动情况',
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
   '员工档案ID',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'ygdaID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '现岗位名称',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'xgwmc'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '原岗位名称',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'ygwmmc'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '变动时间',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'bdsj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '变动原因',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'bdyy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
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
   '预留1',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留2',
   'user', @CurrentUser, 'table', 'PT_pxgwbd', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留3',
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
   '培训考试成绩单',
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
   '培训内容ID',
   'user', @CurrentUser, 'table', 'PT_pxkscjd', 'column', 'pxnrID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '序号',
   'user', @CurrentUser, 'table', 'PT_pxkscjd', 'column', 'xh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '单位',
   'user', @CurrentUser, 'table', 'PT_pxkscjd', 'column', 'dw'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '姓名',
   'user', @CurrentUser, 'table', 'PT_pxkscjd', 'column', 'xm'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '分数',
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
   '预留1',
   'user', @CurrentUser, 'table', 'PT_pxkscjd', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留2',
   'user', @CurrentUser, 'table', 'PT_pxkscjd', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留3',
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
   '培训考试内容',
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
   '培训日期',
   'user', @CurrentUser, 'table', 'PT_pxksnr', 'column', 'pxrq'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '培训对象',
   'user', @CurrentUser, 'table', 'PT_pxksnr', 'column', 'pxdx'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '培训人',
   'user', @CurrentUser, 'table', 'PT_pxksnr', 'column', 'pxr'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '考试内容',
   'user', @CurrentUser, 'table', 'PT_pxksnr', 'column', 'ksnr'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '培训地点',
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
   '预留1',
   'user', @CurrentUser, 'table', 'PT_pxksnr', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留2',
   'user', @CurrentUser, 'table', 'PT_pxksnr', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留3',
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
   '员工档案',
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
   '姓名',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'xm'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '性别',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'xb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '政治面貌',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'zzmm'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '出生日期',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'csrq'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '民族',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'mz'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '职称',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'zc'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '原学历',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'yxl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '现学历',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'xxl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '参加工作时间',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'cjgzsj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '身份证号',
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
   '预留1',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留2',
   'user', @CurrentUser, 'table', 'PT_pxygda', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留3',
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
   '企业年金',
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
   '编号',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'bh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '姓名',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'xm'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '身份证号',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'sfzh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '历年合计',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'hj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2008年',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2008'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2009年',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2009'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2010年',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2010'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2011年',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2011'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2012年',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2012'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2013年',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2013'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2014年',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2014'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2015年',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2015'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2016年',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2016'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2017年',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2017'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2018年',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2018'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2019年',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'y2019'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2020年',
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
   '预留1',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留2',
   'user', @CurrentUser, 'table', 'PT_qynj', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留3',
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
   '*年*月10kV降损、电量奖金奖惩表',
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
   '年月,201201',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'ny'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '供电所',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'orgname'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '购电指标',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fgdzb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '实际完成',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fsjwc'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '增减',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fzj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '标准',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fbz'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '奖惩(元)',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fjc'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '购电量',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fgdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '按指标应损失%',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fbzssb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '按指标应损失电量',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fbzssdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '售电量',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fsdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '按实际完成损失%',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fsjssb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '按实际实成电量',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fsjssdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '增减电量',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fzjdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '平均售电单价',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fpjsddj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '奖惩金额标准%',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fjcjeb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '奖惩金额',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'fjcje'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '总计奖惩金额',
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
   '预留1',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留2',
   'user', @CurrentUser, 'table', 'PT_ydkdljcb', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留3',
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
   '月购、售电量电费',
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
   '年月,201201',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'ny'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用电项目',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'ydxm'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '购电量',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fgdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '购电费',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fgdf'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '总购电量',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fzgdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '购电单价',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fgddj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '购电比例',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fgdbl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '售电量',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fsdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '售电费',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fsdf'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '总售电费',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fzsdf'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '售电单价',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'fsddj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '售电比例',
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
   '预留1',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留2',
   'user', @CurrentUser, 'table', 'PT_ydkygsdldf', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留3',
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
   '月维管费',
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
   '年月,201201',
   'user', @CurrentUser, 'table', 'PT_ydkywgf', 'column', 'ny'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '本期',
   'user', @CurrentUser, 'table', 'PT_ydkywgf', 'column', 'bq'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '累计',
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
   '预留1',
   'user', @CurrentUser, 'table', 'PT_ydkywgf', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留2',
   'user', @CurrentUser, 'table', 'PT_ydkywgf', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留3',
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
   '月线损完成情况表',
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
   '年月,201201',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'ny'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '购电量',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fgdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '售电量报表',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fsdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '报表线损%',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fbbxsb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '售电量到户',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fsdldh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '到户线损%',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fdhxsb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '售电量10kV',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fsdl10kv'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '10kV线损%',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'f10kvxsb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '低压购电量',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fdybdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '低压售电量',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'fdysdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '低压线损%',
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
   '预留1',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留2',
   'user', @CurrentUser, 'table', 'PT_ydkyxswcqk', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留3',
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
   '月营销指标完成情况',
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
   '年月,201201',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'ny'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '购电量',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fgdl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '售电量统计报表',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fsdlbb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '售电量销售到户',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fsdldh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '高压线损',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fgyxs'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '综合线损',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fzhxs'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '趸售收入统计报表',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fbssrbb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '趸售收入销售到户',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fbssrdh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '平均购电单价含代收费',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fgddjsf'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '平均购电单价不含代收费',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fgddj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '平均售电单价报表',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fsddjbb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '平均售电单价到户',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fsddjdh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '购千千瓦时收入报表',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'fgdkwbb'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '购千千瓦时收入到户',
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
   '预留1',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留2',
   'user', @CurrentUser, 'table', 'PT_ydkyyxzb', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留3',
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
   保险编号                 nvarchar(20)         collate Chinese_PRC_CI_AS null,
   身份证号                 nvarchar(20)         collate Chinese_PRC_CI_AS null,
   缴费工资                 money                null,
   职工合计                 money                null,
   职工单位缴费               money                null,
   职工个人应缴               money                null,
   姓名                   nvarchar(10)         collate Chinese_PRC_CI_AS null,
   参保类别                 nvarchar(10)         collate Chinese_PRC_CI_AS null default '省直在职',
   单位缴纳大额               money                null,
   个人缴纳大额               money                null,
   单位入个人                money                null,
   生育保险                 money                null,
   补充保险                 money                null,
   合计金额                 money                null,
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
   '医疗保险',
   'user', @CurrentUser, 'table', 'PT_ylbx'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '年',
   'user', @CurrentUser, 'table', 'PT_ylbx', 'column', 'year'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '月',
   'user', @CurrentUser, 'table', 'PT_ylbx', 'column', 'month'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '人员分类,局里-1、电工-2',
   'user', @CurrentUser, 'table', 'PT_ylbx', 'column', 'type'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '参保类别,省直在职|省直退休',
   'user', @CurrentUser, 'table', 'PT_ylbx', 'column', '参保类别'
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
   '住房公积金',
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
   '编号',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'bh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '姓名',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'xm'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '身份证号',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'sfzh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '查询密码',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'pwd'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '公积金账号',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'gjjzh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '银行账号',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'yhzh'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '历年合计',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'hj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2008年',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2008'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2009年',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2009'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2011年',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2011'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2010年',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2010'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2012年',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2012'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2013年',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2013'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2014年',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2014'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2015年',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2015'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2016年',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2016'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2017年',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2017'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2018年',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2018'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2019年',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'y2019'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '2020年',
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
   '预留1',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'c1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留2',
   'user', @CurrentUser, 'table', 'PT_zfgjj', 'column', 'c2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留3',
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
