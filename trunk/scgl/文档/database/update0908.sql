USE [EbadaScgl]
alter table LP_Record add
  
   OrgName               nvarchar(50)         null default ''
   

go
alter table LP_Temple add
  
   isExplorer               int         null default ((0))


go


execute sp_addextendedproperty 'MS_Description', 
   '��λ����',
   'user', 'dbo', 'table', 'LP_Record', 'column', 'OrgName'
go
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ񵼳�',
   'user', 'dbo', 'table', 'LP_Temple', 'column', 'isExplorer'
go