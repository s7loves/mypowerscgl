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
   '缺陷分类统计',
   'user', 'dbo', 'table', 'PJ_qxfl'
go

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'OrgCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供电所名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'OrgName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'LineID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'LineName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视区段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'xlqd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'xssj'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'巡视人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'xsr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'qxnr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'qxlb'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消缺期限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'xcqx'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消除人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'xcr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消除日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'xcrq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'CreateMan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gzrjID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'gzrjID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'qxly'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺陷来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PJ_qxfl', @level2type=N'COLUMN',@level2name=N's1'