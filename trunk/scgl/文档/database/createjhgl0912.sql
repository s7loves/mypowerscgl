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
   ��λ����                 nvarchar(50)         null,
   ��λ����                 nvarchar(50)         null,
   �ƻ���Ŀ                 nvarchar(50)         null,
   ʵʩ����                 nvarchar(500)        null,
   ��Ҫ������                nvarchar(50)         null,
   �μ���Ա                 nvarchar(150)        null,
   Ԥ��ʱ��                 datetime             null,
   Ԥ��ʱ��2                datetime             null,
   �ƻ�����                 nvarchar(50)         null,
   �ƻ�����                 nvarchar(50)         null,
   ��ɱ��                 nvarchar(50)         null,
   ���ʱ��                 datetime             null,
   �ܽ�����                 nvarchar(500)        null,
   δ���ԭ��                nvarchar(500)        null,
   ��ѡ���                 nvarchar(10)         null,
   ��λ����                 nvarchar(10)         null,
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
   ��λ����                 nvarchar(50)         null,
   ��λ����                 nvarchar(50)         null,
   �ƻ���Ŀ                 nvarchar(50)         null,
   ʵʩ����                 nvarchar(500)        null,
   ��Ҫ������                nvarchar(50)         null,
   �μ���Ա                 nvarchar(150)        null,
   Ԥ��ʱ��                 datetime             null,
   Ԥ��ʱ��2                datetime             null,
   �ƻ�����                 nvarchar(50)         null,
   �ƻ�����                 nvarchar(50)         null,
   ��ɱ��                 nvarchar(50)         null,
   ���ʱ��                 datetime             null,
   �ܽ�����                 nvarchar(500)        null,
   δ���ԭ��                nvarchar(500)        null,
   ��ѡ���                 nvarchar(10)         null,
   ��λ����                 nvarchar(10)         null,
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
   ��λ����                 nvarchar(50)         null,
   ��λ����                 nvarchar(50)         null,
   �ƻ���Ŀ                 nvarchar(50)         null,
   ʵʩ����                 nvarchar(500)        null,
   ��Ҫ������                nvarchar(50)         null,
   �μ���Ա                 nvarchar(150)        null,
   Ԥ��ʱ��                 datetime             null,
   Ԥ��ʱ��2                datetime             null,
   �ƻ�����                 nvarchar(50)         null,
   �ƻ�����                 nvarchar(50)         null,
   ��ɱ��                 nvarchar(50)         null,
   ���ʱ��                 datetime             null,
   �ܽ�����                 nvarchar(500)        null,
   δ���ԭ��                nvarchar(500)        null,
   ��ѡ���                 nvarchar(10)         null,
   ��λ����                 nvarchar(10)         null,
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
   ��λ����                 nvarchar(50)         null,
   ��λ����                 nvarchar(50)         null,
   ��ʼ����                 datetime             null,
   ��������                 datetime             null,
   ����                   nvarchar(50)         null,
   ��                    nvarchar(50)         null,
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
�� ASC
)
go
