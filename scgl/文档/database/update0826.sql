USE [EbadaScgl]
alter table PJ_23 add
  
   qxydd               nvarchar(50)         null default '',
   xybh               nvarchar(50)         null default ''


go

execute sp_addextendedproperty 'MS_Description', 
   '签协议地点',
   'user', 'dbo', 'table', 'PJ_23', 'column', 'qxydd'
go
execute sp_addextendedproperty 'MS_Description', 
   '协议编号',
   'user', 'dbo', 'table', 'PJ_23', 'column', 'xybh'
go