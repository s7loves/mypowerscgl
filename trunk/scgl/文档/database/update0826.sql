USE [EbadaScgl]
alter table PJ_23 add
  
   qxydd               nvarchar(50)         null default ''

go

execute sp_addextendedproperty 'MS_Description', 
   'ǩЭ��ص�',
   'user', 'dbo', 'table', 'PJ_23', 'column', 'qxydd'
go