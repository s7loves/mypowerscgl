alter table PJ_06sbxs add
  
   xcqx               nvarchar(50)         null default ''

go

execute sp_addextendedproperty 'MS_Description', 
   '��ȱ����',
   'user', 'dbo', 'table', 'PJ_06sbxs', 'column', 'xcqx'
go