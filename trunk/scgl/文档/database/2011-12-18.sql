if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.TX_Layer') and o.name = 'FK_TX_LAYER_REFERENCE_TX_PROJE')
alter table dbo.TX_Layer
   drop constraint FK_TX_LAYER_REFERENCE_TX_PROJE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.TX_Line') and o.name = 'FK_TX_LINE_REFERENCE_TX_LAYER')
alter table dbo.TX_Line
   drop constraint FK_TX_LINE_REFERENCE_TX_LAYER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.TX_Point') and o.name = 'FK_TX_POINT_REFERENCE_TX_LAYER')
alter table dbo.TX_Point
   drop constraint FK_TX_POINT_REFERENCE_TX_LAYER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.TX_Polygon') and o.name = 'FK_TX_POLYG_REFERENCE_TX_LAYER')
alter table dbo.TX_Polygon
   drop constraint FK_TX_POLYG_REFERENCE_TX_LAYER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PX_Objects')
            and   type = 'U')
   drop table dbo.PX_Objects
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.TX_Layer')
            and   type = 'U')
   drop table dbo.TX_Layer
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.TX_Line')
            and   type = 'U')
   drop table dbo.TX_Line
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.TX_Point')
            and   type = 'U')
   drop table dbo.TX_Point
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.TX_Polygon')
            and   type = 'U')
   drop table dbo.TX_Polygon
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.TX_Project')
            and   type = 'U')
   drop table dbo.TX_Project
go

/*==============================================================*/
/* Table: PX_Objects                                            */
/*==============================================================*/
create table dbo.PX_Objects (
   layerid              nvarchar(50)         null,
   id                   nvarchar(50)         not null,
   sbid                 nvarchar(50)         null,
   symbolid             nvarchar(50)         null,
   seq                  int                  null,
   text                 nvarchar(250)        null,
   type                 nvarchar(50)         null,
   points               ntext                null,
   ExData               image                null,
   X                    float                null,
   Y                    float                null,
   Width                float                null,
   Height               float                null,
   Rowstate             timestamp            null,
   constraint PK_PX_OBJECTS primary key (id)
)
go


/*==============================================================*/
/* Table: TX_Layer                                              */
/*==============================================================*/
create table dbo.TX_Layer (
   ProID                nvarchar(50)         null,
   LayerID              nvarchar(50)         not null,
   ParentID             nvarchar(50)         null,
   LayerName            nvarchar(250)        null,
   Description          nvarchar(250)        null,
   LayerOrder           int                  null,
   LayerType            nvarchar(50)         null,
   ExAttribute          ntext                null,
   ExData               image                null,
   constraint PK_TX_LAYER primary key (LayerID)
)
go

/*==============================================================*/
/* Table: TX_Line                                               */
/*==============================================================*/
create table dbo.TX_Line (
   LayerID              nvarchar(50)         null,
   ID                   nvarchar(50)         not null,
   Seq                  float                null,
   Text                 nvarchar(250)        null,
   Points               ntext                null,
   Type                 nvarchar(50)         null,
   ExAttribute          nvarchar(500)        null,
   x                    nvarchar(50)         null,
   y                    nvarchar(50)         null,
   width                nvarchar(50)         null,
   height               nvarchar(50)         null,
   constraint PK_TX_LINE primary key (ID)
)
go

/*==============================================================*/
/* Table: TX_Point                                              */
/*==============================================================*/
create table dbo.TX_Point (
   LayerID              nvarchar(50)         null,
   ID                   nvarchar(50)         not null,
   Seq                  float                null,
   Text                 nvarchar(250)        null,
   Points               ntext                null,
   Type                 nvarchar(50)         null,
   ExAttribute          nvarchar(500)        null,
   x                    nvarchar(50)         null,
   y                    nvarchar(50)         null,
   width                nvarchar(50)         null,
   height               nvarchar(50)         null,
   constraint PK_TX_POINT primary key (ID)
)
go

/*==============================================================*/
/* Table: TX_Polygon                                            */
/*==============================================================*/
create table dbo.TX_Polygon (
   LayerID              nvarchar(50)         null,
   ID                   nvarchar(50)         not null,
   Seq                  float                null,
   Text                 nvarchar(250)        null,
   Points               ntext                null,
   Type                 nvarchar(50)         null,
   ExAttribute          nvarchar(500)        null,
   x                    nvarchar(50)         null,
   y                    nvarchar(50)         null,
   width                nvarchar(50)         null,
   height               nvarchar(50)         null,
   constraint PK_TX_POLYGON primary key (ID)
)
go

/*==============================================================*/
/* Table: TX_Project                                            */
/*==============================================================*/
create table dbo.TX_Project (
   ProID                nvarchar(50)         not null,
   ParentID             nvarchar(50)         null,
   ProjectName          nvarchar(150)        null,
   ProjectCode          nvarchar(50)         null,
   Description          nvarchar(250)        null,
   CreateDate           datetime             null,
   CreateMan            nvarchar(50)         null,
   ExAttribute          nvarchar(4000)       null,
   constraint PK_TX_PROJECT primary key (ProID)
)
go

alter table dbo.TX_Layer
   add constraint FK_TX_LAYER_REFERENCE_TX_PROJE foreign key (ProID)
      references dbo.TX_Project (ProID)
go

alter table dbo.TX_Line
   add constraint FK_TX_LINE_REFERENCE_TX_LAYER foreign key (LayerID)
      references dbo.TX_Layer (LayerID)
go

alter table dbo.TX_Point
   add constraint FK_TX_POINT_REFERENCE_TX_LAYER foreign key (LayerID)
      references dbo.TX_Layer (LayerID)
go

alter table dbo.TX_Polygon
   add constraint FK_TX_POLYG_REFERENCE_TX_LAYER foreign key (LayerID)
      references dbo.TX_Layer (LayerID)
go
